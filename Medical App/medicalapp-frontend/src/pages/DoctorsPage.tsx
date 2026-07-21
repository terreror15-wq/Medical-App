import { FormEvent, useState } from "react";
import { useQuery } from "@tanstack/react-query";
import { doctorService } from "@/api/doctorService";
import { specialyService } from "@/api/specialyService";
import type { ApiError, CreateDoctorDTO, ReadDoctorDTO, ReadSpecialyDTO } from "@/api/types";
import { useCrudQueries } from "@/hooks/useCrudQueries";
import { ErrorBanner } from "@/components/ErrorBanner";
import { ConfirmDialog } from "@/components/ConfirmDialog";

const emptyForm: CreateDoctorDTO = {
  name: "",
  lastName: "",
  registrationNumber: "",
  phone: "",
  email: "",
  active: true,
  specialyId: 0,
};

export default function DoctorsPage() {
  const { listQuery, createMutation, updateMutation, deleteMutation } = useCrudQueries(
    "doctors",
    doctorService
  );

  // Se carga por separado para poblar el <select> de especialidad en el
  // formulario. Recordatorio: ReadDoctorDTO no trae specialyId, así que
  // en la TABLA no se puede mostrar la especialidad de cada doctor con
  // los endpoints actuales (ver comentario en doctorService.ts).
  const specialiesQuery = useQuery<ReadSpecialyDTO[], ApiError>({
    queryKey: ["specialies"],
    queryFn: specialyService.getAll,
  });

  const [formOpen, setFormOpen] = useState(false);
  const [editingId, setEditingId] = useState<number | null>(null);
  const [form, setForm] = useState<CreateDoctorDTO>(emptyForm);
  const [deleteTarget, setDeleteTarget] = useState<ReadDoctorDTO | null>(null);

  const openCreateForm = () => {
    setEditingId(null);
    setForm(emptyForm);
    setFormOpen(true);
  };

  const openEditForm = (doctor: ReadDoctorDTO) => {
    setEditingId(doctor.id);
    setForm({
      name: doctor.name,
      lastName: doctor.lastName,
      registrationNumber: doctor.registrationNumber,
      phone: doctor.phone ?? "",
      email: doctor.email ?? "",
      active: doctor.active,
      // El GET no trae specialyId; al editar, se deja en 0 y se obliga a
      // reseleccionar la especialidad para no enviar un id inválido/viejo.
      specialyId: 0,
    });
    setFormOpen(true);
  };

  const closeForm = () => {
    setFormOpen(false);
    setEditingId(null);
  };

  const handleSubmit = (e: FormEvent) => {
    e.preventDefault();
    const payload: CreateDoctorDTO = {
      ...form,
      phone: form.phone || null,
      email: form.email || null,
    };

    if (editingId !== null) {
      updateMutation.mutate({ id: editingId, payload }, { onSuccess: closeForm });
    } else {
      createMutation.mutate(payload, { onSuccess: closeForm });
    }
  };

  const confirmDelete = () => {
    if (!deleteTarget) return;
    deleteMutation.mutate(deleteTarget.id, { onSuccess: () => setDeleteTarget(null) });
  };

  const mutationError =
    createMutation.error || updateMutation.error || deleteMutation.error || null;

  return (
    <div>
      <div className="page-header">
        <h2>Doctores</h2>
        <button className="btn btn-primary" onClick={openCreateForm}>
          + Nuevo doctor
        </button>
      </div>

      <ErrorBanner error={listQuery.error ?? specialiesQuery.error ?? mutationError} />

      {formOpen && (
        <div className="card">
          <h3>{editingId !== null ? "Editar doctor" : "Nuevo doctor"}</h3>
          {editingId !== null && (
            <p style={{ fontSize: 13, color: "#b91c1c", marginTop: -4 }}>
              El backend no expone la especialidad actual de este doctor en la lectura:
              selecciona de nuevo la especialidad antes de guardar.
            </p>
          )}
          <form onSubmit={handleSubmit}>
            <div className="form-grid">
              <div className="form-field">
                <label htmlFor="name">Nombre</label>
                <input
                  id="name"
                  type="text"
                  required
                  value={form.name}
                  onChange={(e) => setForm({ ...form, name: e.target.value })}
                />
              </div>
              <div className="form-field">
                <label htmlFor="lastName">Apellido</label>
                <input
                  id="lastName"
                  type="text"
                  required
                  value={form.lastName}
                  onChange={(e) => setForm({ ...form, lastName: e.target.value })}
                />
              </div>
              <div className="form-field">
                <label htmlFor="registrationNumber">Número de colegiatura</label>
                <input
                  id="registrationNumber"
                  type="text"
                  required
                  value={form.registrationNumber}
                  onChange={(e) => setForm({ ...form, registrationNumber: e.target.value })}
                />
              </div>
              <div className="form-field">
                <label htmlFor="specialyId">Especialidad</label>
                <select
                  id="specialyId"
                  required
                  value={form.specialyId}
                  onChange={(e) => setForm({ ...form, specialyId: Number(e.target.value) })}
                >
                  <option value={0} disabled>
                    Selecciona una especialidad
                  </option>
                  {specialiesQuery.data?.map((specialy) => (
                    <option key={specialy.id} value={specialy.id}>
                      {specialy.name}
                    </option>
                  ))}
                </select>
              </div>
              <div className="form-field">
                <label htmlFor="phone">Teléfono</label>
                <input
                  id="phone"
                  type="tel"
                  value={form.phone ?? ""}
                  onChange={(e) => setForm({ ...form, phone: e.target.value })}
                />
              </div>
              <div className="form-field">
                <label htmlFor="email">Email</label>
                <input
                  id="email"
                  type="email"
                  value={form.email ?? ""}
                  onChange={(e) => setForm({ ...form, email: e.target.value })}
                />
              </div>
              <div className="form-field checkbox-field">
                <input
                  id="active"
                  type="checkbox"
                  checked={form.active}
                  onChange={(e) => setForm({ ...form, active: e.target.checked })}
                />
                <label htmlFor="active">Doctor activo</label>
              </div>
            </div>
            <div className="form-actions">
              <button
                type="submit"
                className="btn btn-primary"
                disabled={
                  createMutation.isPending || updateMutation.isPending || form.specialyId === 0
                }
              >
                {editingId !== null ? "Guardar cambios" : "Crear doctor"}
              </button>
              <button type="button" className="btn btn-secondary" onClick={closeForm}>
                Cancelar
              </button>
            </div>
          </form>
        </div>
      )}

      {listQuery.isLoading && <div className="loading-state">Cargando doctores...</div>}

      {!listQuery.isLoading && (listQuery.data?.length ?? 0) === 0 && !listQuery.error && (
        <div className="empty-state">No hay doctores registrados todavía.</div>
      )}

      {!listQuery.isLoading && (listQuery.data?.length ?? 0) > 0 && (
        <table>
          <thead>
            <tr>
              <th>Nombre</th>
              <th>Colegiatura</th>
              <th>Teléfono</th>
              <th>Email</th>
              <th>Estado</th>
              <th></th>
            </tr>
          </thead>
          <tbody>
            {listQuery.data!.map((doctor) => (
              <tr key={doctor.id}>
                <td>
                  Dr. {doctor.name} {doctor.lastName}
                </td>
                <td>{doctor.registrationNumber}</td>
                <td>{doctor.phone ?? "—"}</td>
                <td>{doctor.email ?? "—"}</td>
                <td>
                  <span className={`badge ${doctor.active ? "badge-active" : "badge-inactive"}`}>
                    {doctor.active ? "Activo" : "Inactivo"}
                  </span>
                </td>
                <td className="table-actions">
                  <button className="btn-link" onClick={() => openEditForm(doctor)}>
                    Editar
                  </button>
                  <button className="btn-link danger" onClick={() => setDeleteTarget(doctor)}>
                    Eliminar
                  </button>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      )}

      <ConfirmDialog
        open={deleteTarget !== null}
        title="Eliminar doctor"
        message={`¿Seguro que quieres eliminar a Dr. ${deleteTarget?.name} ${deleteTarget?.lastName}?`}
        onConfirm={confirmDelete}
        onCancel={() => setDeleteTarget(null)}
        confirming={deleteMutation.isPending}
      />
    </div>
  );
}
