import { FormEvent, useState } from "react";
import { medicalOfficeService } from "@/api/medicalOfficeService";
import type { CreateMedicalOfficeDTO, ReadMedicalOfficeDTO } from "@/api/types";
import { useCrudQueries } from "@/hooks/useCrudQueries";
import { ErrorBanner } from "@/components/ErrorBanner";
import { ConfirmDialog } from "@/components/ConfirmDialog";

const emptyForm: CreateMedicalOfficeDTO = { doorNumber: "", floor: "", descripcion: "" };

export default function MedicalOfficesPage() {
  const { listQuery, createMutation, updateMutation, deleteMutation } = useCrudQueries(
    "medicalOffices",
    medicalOfficeService
  );

  const [formOpen, setFormOpen] = useState(false);
  const [editingId, setEditingId] = useState<number | null>(null);
  const [form, setForm] = useState<CreateMedicalOfficeDTO>(emptyForm);
  const [deleteTarget, setDeleteTarget] = useState<ReadMedicalOfficeDTO | null>(null);

  const openCreateForm = () => {
    setEditingId(null);
    setForm(emptyForm);
    setFormOpen(true);
  };

  const openEditForm = (office: ReadMedicalOfficeDTO) => {
    setEditingId(office.id);
    setForm({
      doorNumber: office.doorNumber,
      floor: office.floor ?? "",
      descripcion: office.descripcion ?? "",
    });
    setFormOpen(true);
  };

  const closeForm = () => {
    setFormOpen(false);
    setEditingId(null);
  };

  const handleSubmit = (e: FormEvent) => {
    e.preventDefault();
    const payload: CreateMedicalOfficeDTO = {
      ...form,
      floor: form.floor || null,
      descripcion: form.descripcion || null,
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
        <h2>Consultorios</h2>
        <button className="btn btn-primary" onClick={openCreateForm}>
          + Nuevo consultorio
        </button>
      </div>

      <ErrorBanner error={listQuery.error ?? mutationError} />

      {formOpen && (
        <div className="card">
          <h3>{editingId !== null ? "Editar consultorio" : "Nuevo consultorio"}</h3>
          <form onSubmit={handleSubmit}>
            <div className="form-grid">
              <div className="form-field">
                <label htmlFor="doorNumber">Número de puerta</label>
                <input
                  id="doorNumber"
                  type="text"
                  required
                  value={form.doorNumber}
                  onChange={(e) => setForm({ ...form, doorNumber: e.target.value })}
                />
              </div>
              <div className="form-field">
                <label htmlFor="floor">Piso</label>
                <input
                  id="floor"
                  type="text"
                  value={form.floor ?? ""}
                  onChange={(e) => setForm({ ...form, floor: e.target.value })}
                />
              </div>
              <div className="form-field span-2">
                <label htmlFor="descripcion">Descripción</label>
                <textarea
                  id="descripcion"
                  rows={3}
                  value={form.descripcion ?? ""}
                  onChange={(e) => setForm({ ...form, descripcion: e.target.value })}
                />
              </div>
            </div>
            <div className="form-actions">
              <button
                type="submit"
                className="btn btn-primary"
                disabled={createMutation.isPending || updateMutation.isPending}
              >
                {editingId !== null ? "Guardar cambios" : "Crear consultorio"}
              </button>
              <button type="button" className="btn btn-secondary" onClick={closeForm}>
                Cancelar
              </button>
            </div>
          </form>
        </div>
      )}

      {listQuery.isLoading && <div className="loading-state">Cargando consultorios...</div>}

      {!listQuery.isLoading && (listQuery.data?.length ?? 0) === 0 && !listQuery.error && (
        <div className="empty-state">No hay consultorios registrados todavía.</div>
      )}

      {!listQuery.isLoading && (listQuery.data?.length ?? 0) > 0 && (
        <table>
          <thead>
            <tr>
              <th>Puerta</th>
              <th>Piso</th>
              <th>Descripción</th>
              <th></th>
            </tr>
          </thead>
          <tbody>
            {listQuery.data!.map((office) => (
              <tr key={office.id}>
                <td>{office.doorNumber}</td>
                <td>{office.floor ?? "—"}</td>
                <td>{office.descripcion ?? "—"}</td>
                <td className="table-actions">
                  <button className="btn-link" onClick={() => openEditForm(office)}>
                    Editar
                  </button>
                  <button className="btn-link danger" onClick={() => setDeleteTarget(office)}>
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
        title="Eliminar consultorio"
        message={`¿Seguro que quieres eliminar el consultorio "${deleteTarget?.doorNumber}"?`}
        onConfirm={confirmDelete}
        onCancel={() => setDeleteTarget(null)}
        confirming={deleteMutation.isPending}
      />
    </div>
  );
}
