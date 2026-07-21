import axios, { AxiosError, AxiosInstance } from "axios";
import type { ApiError } from "./types";

const BASE_URL = import.meta.env.VITE_API_BASE_URL ?? "http://localhost:5235";

export const httpClient: AxiosInstance = axios.create({
  baseURL: BASE_URL,
  headers: {
    "Content-Type": "application/json",
  },
});

/**
 * Normaliza cualquier error de red/HTTP a un ApiError consistente,
 * incluyendo el caso típico de que el backend aún no tenga CORS habilitado
 * (en ese caso axios reporta un error de red sin `response`, no un status).
 */
function normalizeError(error: unknown): ApiError {
  if (axios.isAxiosError(error)) {
    const axiosError = error as AxiosError;

    if (!axiosError.response) {
      // Sin respuesta del servidor: casi siempre es CORS no habilitado en el
      // backend, el backend está apagado, o la URL/puerto es incorrecto.
      return {
        status: null,
        message:
          "No se pudo contactar al backend. Verifica que la API esté corriendo, " +
          "que la URL/puerto sean correctos y que CORS esté habilitado en el " +
          "servidor (el backend aún no lo tiene habilitado según lo indicado).",
        details: axiosError.message,
      };
    }

    const status = axiosError.response.status;
    const data = axiosError.response.data as any;

    return {
      status,
      message:
        (data && (data.title || data.message || data.detail)) ||
        `Error ${status} al comunicarse con la API.`,
      details: data,
    };
  }

  return {
    status: null,
    message: "Ocurrió un error inesperado.",
    details: error,
  };
}

httpClient.interceptors.response.use(
  (response) => response,
  (error) => {
    const normalized = normalizeError(error);
    // Se relanza el error normalizado para que los servicios/hooks
    // de cada entidad lo consuman de forma consistente.
    return Promise.reject(normalized);
  }
);
