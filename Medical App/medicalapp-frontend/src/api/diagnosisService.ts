import { httpClient } from "./httpClient";
import type { CreateDiagnosisDTO, ReadDiagnosisDTO, UpdateDiagnosisDTO } from "./types";

const BASE_PATH = "/api/Diagnosis";

export const diagnosisService = {
  getAll: async (): Promise<ReadDiagnosisDTO[]> => {
    const { data } = await httpClient.get<ReadDiagnosisDTO[]>(BASE_PATH);
    return data;
  },

  getById: async (id: number): Promise<ReadDiagnosisDTO> => {
    const { data } = await httpClient.get<ReadDiagnosisDTO>(`${BASE_PATH}/${id}`);
    return data;
  },

  // La ruta acepta {id} en el POST pero no se usa realmente (según el prompt);
  // se envía solo el body a la ruta base. Devuelve 201 Created.
  create: async (payload: CreateDiagnosisDTO): Promise<ReadDiagnosisDTO> => {
    const { data } = await httpClient.post<ReadDiagnosisDTO>(BASE_PATH, payload);
    return data;
  },

  update: async (id: number, payload: UpdateDiagnosisDTO): Promise<void> => {
    await httpClient.put(`${BASE_PATH}/${id}`, payload);
  },

  delete: async (id: number): Promise<void> => {
    await httpClient.delete(`${BASE_PATH}/${id}`);
  },
};
