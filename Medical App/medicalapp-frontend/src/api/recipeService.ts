import { httpClient } from "./httpClient";
import type { ApiError, CreateRecipeDTO, ReadRecipeDTO, UpdateRecipeDTO } from "./types";

const BASE_PATH = "/api/Recipe";

export const recipeService = {
  getAll: async (): Promise<ReadRecipeDTO[]> => {
    const { data } = await httpClient.get<ReadRecipeDTO[]>(BASE_PATH);
    return data;
  },

  getById: async (id: number): Promise<ReadRecipeDTO> => {
    const { data } = await httpClient.get<ReadRecipeDTO>(`${BASE_PATH}/${id}`);
    return data;
  },

  create: async (payload: CreateRecipeDTO): Promise<void> => {
    await httpClient.post(BASE_PATH, payload);
  },

  /**
   * ADVERTENCIA (pendiente de confirmar contra Swagger, según el prompt original):
   * `PUT /api/Recipe` NO lleva {id} en la ruta. El controlador espera un
   * parámetro `id` que no está anotado con [FromRoute] ni [FromQuery], así
   * que el binding es ambiguo — probablemente falle con 400 Bad Request,
   * o requiera que el id vaya como query string (`?id=`).
   *
   * Esta función intenta primero `PUT /api/Recipe?id={id}`. Si el backend
   * devuelve 400/404, se relanza el ApiError con el mensaje EXACTO que
   * devolvió el servidor (en vez de silenciarlo) para poder corregirlo
   * en el controlador de ASP.NET Core.
   */
  update: async (id: number, payload: UpdateRecipeDTO): Promise<void> => {
    try {
      await httpClient.put(BASE_PATH, payload, { params: { id } });
    } catch (error) {
      const apiError = error as ApiError;
      console.error(
        `[recipeService.update] Falló PUT ${BASE_PATH}?id=${id}. ` +
          `Respuesta del backend:`,
        apiError
      );
      throw apiError;
    }
  },

  delete: async (id: number): Promise<void> => {
    await httpClient.delete(`${BASE_PATH}/${id}`);
  },
};
