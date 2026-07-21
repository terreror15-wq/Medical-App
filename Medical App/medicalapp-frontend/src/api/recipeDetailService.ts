import { httpClient } from "./httpClient";
import type {
  CreateRecipeDetailDTO,
  ReadRecipeDetailDTO,
  UpdateRecipeDetailDTO,
} from "./types";

const BASE_PATH = "/api/RecipeDetail";

export const recipeDetailService = {
  getAll: async (): Promise<ReadRecipeDetailDTO[]> => {
    const { data } = await httpClient.get<ReadRecipeDetailDTO[]>(BASE_PATH);
    return data;
  },

  getById: async (id: number): Promise<ReadRecipeDetailDTO> => {
    const { data } = await httpClient.get<ReadRecipeDetailDTO>(`${BASE_PATH}/${id}`);
    return data;
  },

  create: async (payload: CreateRecipeDetailDTO): Promise<void> => {
    await httpClient.post(BASE_PATH, payload);
  },

  update: async (id: number, payload: UpdateRecipeDetailDTO): Promise<void> => {
    await httpClient.put(`${BASE_PATH}/${id}`, payload);
  },

  delete: async (id: number): Promise<void> => {
    await httpClient.delete(`${BASE_PATH}/${id}`);
  },
};
