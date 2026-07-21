import { httpClient } from "./httpClient";
import type { CreatePatientDTO, ReadPatientDTO, UpdatePatientDTO } from "./types";

const BASE_PATH = "/api/Patient";

export const patientService = {
  getAll: async (): Promise<ReadPatientDTO[]> => {
    const { data } = await httpClient.get<ReadPatientDTO[]>(BASE_PATH);
    return data;
  },

  getById: async (id: number): Promise<ReadPatientDTO> => {
    const { data } = await httpClient.get<ReadPatientDTO>(`${BASE_PATH}/${id}`);
    return data;
  },

  // POST devuelve 204 No Content: no hay objeto creado en el body,
  // hay que refrescar el listado (getAll) después de llamar a create.
  create: async (payload: CreatePatientDTO): Promise<void> => {
    await httpClient.post(BASE_PATH, payload);
  },

  // PUT devuelve 204 No Content: refrescar tras editar.
  update: async (id: number, payload: UpdatePatientDTO): Promise<void> => {
    await httpClient.put(`${BASE_PATH}/${id}`, payload);
  },

  // OJO: a diferencia del resto de entidades, el DELETE de Patient
  // recibe el id por QUERY STRING (?id=), no por ruta.
  // Confirmado en el prompt original: "DELETE /api/Patient?id={id}".
  delete: async (id: number): Promise<void> => {
    await httpClient.delete(BASE_PATH, { params: { id } });
  },
};
