import { useMutation, useQuery, useQueryClient } from "@tanstack/react-query";
import type { ApiError } from "@/api/types";

interface CrudService<TRead, TCreate, TUpdate> {
  getAll: () => Promise<TRead[]>;
  create: (payload: TCreate) => Promise<unknown>;
  update: (id: number, payload: TUpdate) => Promise<unknown>;
  delete: (id: number) => Promise<void>;
}

/**
 * Hook genérico de CRUD basado en TanStack Query.
 * Centraliza el patrón repetido en las 4 pantallas: listar, crear, editar,
 * eliminar, e invalidar/refrescar la lista después de cada mutación
 * (necesario porque la mayoría de los POST/PUT del backend devuelven
 * 204 No Content, sin el objeto actualizado).
 */
export function useCrudQueries<TRead, TCreate, TUpdate>(
  queryKey: string,
  service: CrudService<TRead, TCreate, TUpdate>
) {
  const queryClient = useQueryClient();

  const listQuery = useQuery<TRead[], ApiError>({
    queryKey: [queryKey],
    queryFn: service.getAll,
  });

  const invalidate = () => queryClient.invalidateQueries({ queryKey: [queryKey] });

  const createMutation = useMutation<unknown, ApiError, TCreate>({
    mutationFn: service.create,
    onSuccess: invalidate,
  });

  const updateMutation = useMutation<unknown, ApiError, { id: number; payload: TUpdate }>({
    mutationFn: ({ id, payload }) => service.update(id, payload),
    onSuccess: invalidate,
  });

  const deleteMutation = useMutation<void, ApiError, number>({
    mutationFn: service.delete,
    onSuccess: invalidate,
  });

  return { listQuery, createMutation, updateMutation, deleteMutation };
}
