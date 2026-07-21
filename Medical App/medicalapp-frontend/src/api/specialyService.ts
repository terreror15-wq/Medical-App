import { httpClient } from "./httpClient";
import type { CreateSpecialyDTO, ReadSpecialyDTO, UpdateSpecialyDTO } from "./types";

const BASE_PATH = "/api/Specialy";

export const specialyService = {
  getAll: async (): Promise<ReadSpecialyDTO[]> => {
    const { data } = await httpClient.get<ReadSpecialyDTO[]>(BASE_PATH);
    return data;
  },

  getById: async (id: number): Promise<ReadSpecialyDTO> => {
    const { data } = await httpClient.get<ReadSpecialyDTO>(`${BASE_PATH}/${id}`);
    return data;
  },

  create: async (payload: CreateSpecialyDTO): Promise<void> => {
    await httpClient.post(BASE_PATH, payload);
  },

  update: async (id: number, payload: UpdateSpecialyDTO): Promise<void> => {
    await httpClient.put(`${BASE_PATH}/${id}`, payload);
  },

  delete: async (id: number): Promise<void> => {
    await httpClient.delete(`${BASE_PATH}/${id}`);
  },
};
