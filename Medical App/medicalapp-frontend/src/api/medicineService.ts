import { httpClient } from "./httpClient";
import type { CreateMedicineDTO, ReadMedicineDTO, UpdateMedicineDTO } from "./types";

const BASE_PATH = "/api/Medicine";

export const medicineService = {
  getAll: async (): Promise<ReadMedicineDTO[]> => {
    const { data } = await httpClient.get<ReadMedicineDTO[]>(BASE_PATH);
    return data;
  },

  getById: async (id: number): Promise<ReadMedicineDTO> => {
    const { data } = await httpClient.get<ReadMedicineDTO>(`${BASE_PATH}/${id}`);
    return data;
  },

  // La ruta acepta {id} en el POST pero no se usa realmente. Devuelve 201.
  create: async (payload: CreateMedicineDTO): Promise<ReadMedicineDTO> => {
    const { data } = await httpClient.post<ReadMedicineDTO>(BASE_PATH, payload);
    return data;
  },

  update: async (id: number, payload: UpdateMedicineDTO): Promise<void> => {
    await httpClient.put(`${BASE_PATH}/${id}`, payload);
  },

  delete: async (id: number): Promise<void> => {
    await httpClient.delete(`${BASE_PATH}/${id}`);
  },
};
