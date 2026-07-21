import { FormEvent, useState } from "react";
import { specialyService } from "@/api/specialyService";
import type { CreateSpecialyDTO, ReadSpecialyDTO } from "@/api/types";
import { useCrudQueries } from "@/hooks/useCrudQueries";
import { ErrorBanner } from "@/components/ErrorBanner";
import { ConfirmDialog } from "@/components/ConfirmDialog";

const emptyForm: CreateSpecialyDTO = { name: "", description: "" };

export default function SpecialiesPage() {
  const { listQuery, createMutation, updateMutation, deleteMutation } = useCrudQueries(
    "specialies",
    specialyService
  );

  const [formOpen, setFormOpen] = useState(false);
  const [editingId, setEditingId] = useState<number | null>(null);
  const [form, setForm] = useState<CreateSpecialyDTO>(emptyForm);
  const [deleteTarget, setDeleteTarget] = useState<ReadSpecialyDTO | null>(null);

  const openCreateForm = () => {
    setEditingId(null);
    setForm(emptyForm);
    setFormOpen(true);
  };

  const openEditForm = (specialy: ReadSpecialyDTO) => {
    setEditingId(specialy.id);
    setForm({ name: specialy.name, description: specialy.description });
    setFormOpen(true);
  };

  const closeForm = () => {
    setFormOpen(false);
    setEditingId(null);
  };

  const handleSubmit = (e: FormEvent) => {
    e.preventDefault();
    if (editingId !== null) {
      updateMutation.mutate({ id: editingId, payload: form }, { onSuccess: closeForm });
    } else {
      createMutation.mutate(form, { onSuccess: closeForm });
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
        <h2>Especialidades</h2>
        <button className="btn btn-primary" onClick={openCreateForm}>
          + Nueva especialidad
        </button>
      </div>

      <ErrorBanner error={listQuery.error ?? mutationError} />

      {formOpen && (
        <div className="card">
          <h3>{editingId !== null ? "Editar especialidad" : "Nueva especialidad"}</h3>
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
              <div className="form-field span-2">
                <label htmlFor="description">Descripción</label>
                <textarea
                  id="description"
                  required
                  rows={3}
                  value={form.description}
                  onChange={(e) => setForm({ ...form, description: e.target.value })}
                />
              </div>
            </div>
            <div className="form-actions">
              <button
                type="submit"
                className="btn btn-primary"
                disabled={createMutation.isPending || updateMutation.isPending}
              >
                {editingId !== null ? "Guardar cambios" : "Crear especialidad"}
              </button>
              <button type="button" className="btn btn-secondary" onClick={closeForm}>
                Cancelar
              </button>
            </div>
          </form>
        </div>
      )}

      {listQuery.isLoading && <div className="loading-state">Cargando especialidades...</div>}

      {!listQuery.isLoading && (listQuery.data?.length ?? 0) === 0 && !listQuery.error && (
        <div className="empty-state">No hay especialidades registradas todavía.</div>
      )}

      {!listQuery.isLoading && (listQuery.data?.length ?? 0) > 0 && (
        <table>
          <thead>
            <tr>
              <th>Nombre</th>
              <th>Descripción</th>
              <th></th>
            </tr>
          </thead>
          <tbody>
            {listQuery.data!.map((specialy) => (
              <tr key={specialy.id}>
                <td>{specialy.name}</td>
                <td>{specialy.description}</td>
                <td className="table-actions">
                  <button className="btn-link" onClick={() => openEditForm(specialy)}>
                    Editar
                  </button>
                  <button
                    className="btn-link danger"
                    onClick={() => setDeleteTarget(specialy)}
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
        title="Eliminar especialidad"
        message={`¿Seguro que quieres eliminar "${deleteTarget?.name}"? Si hay doctores usando esta especialidad, el backend podría rechazar el borrado.`}
        onConfirm={confirmDelete}
        onCancel={() => setDeleteTarget(null)}
        confirming={deleteMutation.isPending}
      />
    </div>
  );
}
