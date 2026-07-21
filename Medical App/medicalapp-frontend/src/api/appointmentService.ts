import { httpClient } from "./httpClient";
import type {
  CreateAppointmentDTO,
  ReadAppointmentDTO,
  UpdateAppointmentDTO,
} from "./types";

const BASE_PATH = "/api/Appointment";

export const appointmentService = {
  getAll: async (): Promise<ReadAppointmentDTO[]> => {
    const { data } = await httpClient.get<ReadAppointmentDTO[]>(BASE_PATH);
    return data;
  },

  getById: async (id: number): Promise<ReadAppointmentDTO> => {
    const { data } = await httpClient.get<ReadAppointmentDTO>(`${BASE_PATH}/${id}`);
    return data;
  },

  // Este endpoint SÍ devuelve 201 Created con el recurso creado en el body
  // (a diferencia de la mayoría, que devuelve 204). Se retorna igual.
  create: async (payload: CreateAppointmentDTO): Promise<ReadAppointmentDTO> => {
    const { data } = await httpClient.post<ReadAppointmentDTO>(BASE_PATH, payload);
    return data;
  },

  update: async (id: number, payload: UpdateAppointmentDTO): Promise<void> => {
    await httpClient.put(`${BASE_PATH}/${id}`, payload);
  },

  delete: async (id: number): Promise<void> => {
    await httpClient.delete(`${BASE_PATH}/${id}`);
  },
};
