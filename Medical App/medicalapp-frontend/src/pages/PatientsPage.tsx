import { FormEvent, useState } from "react";
import { patientService } from "@/api/patientService";
import type { CreatePatientDTO, ReadPatientDTO } from "@/api/types";
import { useCrudQueries } from "@/hooks/useCrudQueries";
import { ErrorBanner } from "@/components/ErrorBanner";
import { ConfirmDialog } from "@/components/ConfirmDialog";
import { dateInputToIso, formatDateDisplay, isoToDateInput } from "@/utils/date";

const emptyForm: CreatePatientDTO = {
  name: "",
  lastName: "",
  identityDocument: "",
  dateBirth: "",
  phone: "",
  email: "",
  address: "",
  dateRegister: new Date().toISOString().slice(0, 10) + "T00:00:00",
  active: true,
};

export default function PatientsPage() {
  const { listQuery, createMutation, updateMutation, deleteMutation } = useCrudQueries(
    "patients",
    patientService
  );

  const [formOpen, setFormOpen] = useState(false);
  const [editingId, setEditingId] = useState<number | null>(null);
  const [form, setForm] = useState<CreatePatientDTO>(emptyForm);
  const [deleteTarget, setDeleteTarget] = useState<ReadPatientDTO | null>(null);

  const openCreateForm = () => {
    setEditingId(null);
    setForm(emptyForm);
    setFormOpen(true);
  };

  const openEditForm = (patient: ReadPatientDTO) => {
    setEditingId(patient.id);
    setForm({
      name: patient.name,
      lastName: patient.lastName,
      identityDocument: patient.identityDocument,
      dateBirth: patient.dateBirth,
      phone: patient.phone ?? "",
      email: patient.email ?? "",
      address: patient.address ?? "",
      dateRegister: patient.dateRegister,
      active: patient.active,
    });
    setFormOpen(true);
  };

  const closeForm = () => {
    setFormOpen(false);
    setEditingId(null);
  };

  const handleSubmit = (e: FormEvent) => {
    e.preventDefault();
    const payload: CreatePatientDTO = {
      ...form,
      phone: form.phone || null,
      email: form.email || null,
      address: form.address || null,
    };

    if (editingId !== null) {
      updateMutation.mutate(
        { id: editingId, payload },
        { onSuccess: closeForm }
      );
    } else {
      createMutation.mutate(payload, { onSuccess: closeForm });
    }
  };

  const confirmDelete = () => {
    if (!deleteTarget) return;
    deleteMutation.mutate(deleteTarget.id, {
      onSuccess: () => setDeleteTarget(null),
    });
  };

  const mutationError =
    createMutation.error || updateMutation.error || deleteMutation.error || null;

  return (
    <div>
      <div className="page-header">
        <h2>Pacientes</h2>
        <button className="btn btn-primary" onClick={openCreateForm}>
          + Nuevo paciente
        </button>
      </div>

      <ErrorBanner error={listQuery.error ?? mutationError} />

      {formOpen && (
        <div className="card">
          <h3>{editingId !== null ? "Editar paciente" : "Nuevo paciente"}</h3>
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
                <label htmlFor="identityDocument">Cédula / documento</label>
                <input
                  id="identityDocument"
                  type="text"
                  required
                  value={form.identityDocument}
                  onChange={(e) => setForm({ ...form, identityDocument: e.target.value })}
                />
              </div>
              <div className="form-field">
                <label htmlFor="dateBirth">Fecha de nacimiento</label>
                <input
                  id="dateBirth"
                  type="date"
                  required
                  value={isoToDateInput(form.dateBirth)}
                  onChange={(e) =>
                    setForm({ ...form, dateBirth: dateInputToIso(e.target.value) })
                  }
                />
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
              <div className="form-field span-2">
                <label htmlFor="address">Dirección</label>
                <input
                  id="address"
                  type="text"
                  value={form.address ?? ""}
                  onChange={(e) => setForm({ ...form, address: e.target.value })}
                />
              </div>
              <div className="form-field">
                <label htmlFor="dateRegister">Fecha de registro</label>
                <input
                  id="dateRegister"
                  type="date"
                  required
                  value={isoToDateInput(form.dateRegister)}
                  onChange={(e) =>
                    setForm({ ...form, dateRegister: dateInputToIso(e.target.value) })
                  }
                />
              </div>
              <div className="form-field checkbox-field">
                <input
                  id="active"
                  type="checkbox"
                  checked={form.active}
                  onChange={(e) => setForm({ ...form, active: e.target.checked })}
                />
                <label htmlFor="active">Paciente activo</label>
              </div>
            </div>

            <div className="form-actions">
              <button
                type="submit"
                className="btn btn-primary"
                disabled={createMutation.isPending || updateMutation.isPending}
              >
                {editingId !== null ? "Guardar cambios" : "Crear paciente"}
              </button>
              <button type="button" className="btn btn-secondary" onClick={closeForm}>
                Cancelar
              </button>
            </div>
          </form>
        </div>
      )}

      {listQuery.isLoading && <div className="loading-state">Cargando pacientes...</div>}

      {!listQuery.isLoading && (listQuery.data?.length ?? 0) === 0 && !listQuery.error && (
        <div className="empty-state">No hay pacientes registrados todavía.</div>
      )}

      {!listQuery.isLoading && (listQuery.data?.length ?? 0) > 0 && (
        <table>
          <thead>
            <tr>
              <th>Nombre</th>
              <th>Documento</th>
              <th>F. nacimiento</th>
              <th>Teléfono</th>
              <th>Email</th>
              <th>Estado</th>
              <th></th>
            </tr>
          </thead>
          <tbody>
            {listQuery.data!.map((patient) => (
              <tr key={patient.id}>
                <td>
                  {patient.name} {patient.lastName}
                </td>
                <td>{patient.identityDocument}</td>
                <td>{formatDateDisplay(patient.dateBirth)}</td>
                <td>{patient.phone ?? "—"}</td>
                <td>{patient.email ?? "—"}</td>
                <td>
                  <span className={`badge ${patient.active ? "badge-active" : "badge-inactive"}`}>
                    {patient.active ? "Activo" : "Inactivo"}
                  </span>
                </td>
                <td className="table-actions">
                  <button className="btn-link" onClick={() => openEditForm(patient)}>
                    Editar
                  </button>
                  <button
                    className="btn-link danger"
                    onClick={() => setDeleteTarget(patient)}
                  >
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
        title="Eliminar paciente"
        message={`¿Seguro que quieres eliminar a ${deleteTarget?.name} ${deleteTarget?.lastName}? Esta acción no se puede deshacer.`}
        onConfirm={confirmDelete}
        onCancel={() => setDeleteTarget(null)}
        confirming={deleteMutation.isPending}
      />
    </div>
  );
}
