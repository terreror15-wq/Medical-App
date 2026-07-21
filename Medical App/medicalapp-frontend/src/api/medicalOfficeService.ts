import { httpClient } from "./httpClient";
import type {
  CreateMedicalOfficeDTO,
  ReadMedicalOfficeDTO,
  UpdateMedicalOfficeDTO,
} from "./types";

const BASE_PATH = "/api/MedicalOffice";

export const medicalOfficeService = {
  getAll: async (): Promise<ReadMedicalOfficeDTO[]> => {
    const { data } = await httpClient.get<ReadMedicalOfficeDTO[]>(BASE_PATH);
    return data;
  },

  getById: async (id: number): Promise<ReadMedicalOfficeDTO> => {
    const { data } = await httpClient.get<ReadMedicalOfficeDTO>(`${BASE_PATH}/${id}`);
    return data;
  },

  create: async (payload: CreateMedicalOfficeDTO): Promise<void> => {
    await httpClient.post(BASE_PATH, payload);
  },

  update: async (id: number, payload: UpdateMedicalOfficeDTO): Promise<void> => {
    await httpClient.put(`${BASE_PATH}/${id}`, payload);
  },

  delete: async (id: number): Promise<void> => {
    await httpClient.delete(`${BASE_PATH}/${id}`);
  },
};
