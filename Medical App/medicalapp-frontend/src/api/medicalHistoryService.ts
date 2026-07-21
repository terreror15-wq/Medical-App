import { httpClient } from "./httpClient";
import type {
  CreateMedicalHistoryDTO,
  ReadMedicalHistoryDTO,
  UpdateMedicalHistoryDTO,
} from "./types";

const BASE_PATH = "/api/MedicalHistory";

export const medicalHistoryService = {
  getAll: async (): Promise<ReadMedicalHistoryDTO[]> => {
    const { data } = await httpClient.get<ReadMedicalHistoryDTO[]>(BASE_PATH);
    return data;
  },

  getById: async (id: number): Promise<ReadMedicalHistoryDTO> => {
    const { data } = await httpClient.get<ReadMedicalHistoryDTO>(`${BASE_PATH}/${id}`);
    return data;
  },

  create: async (payload: CreateMedicalHistoryDTO): Promise<void> => {
    await httpClient.post(BASE_PATH, payload);
  },

  update: async (id: number, payload: UpdateMedicalHistoryDTO): Promise<void> => {
    await httpClient.put(`${BASE_PATH}/${id}`, payload);
  },

  // OJO: igual que Patient, el DELETE recibe el id por QUERY STRING (?id=),
  // no por ruta. Confirmado en el prompt: "DELETE /api/MedicalHistory?id={id}".
  delete: async (id: number): Promise<void> => {
    await httpClient.delete(BASE_PATH, { params: { id } });
  },
};
