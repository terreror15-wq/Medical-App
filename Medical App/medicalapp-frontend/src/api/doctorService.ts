import { httpClient } from "./httpClient";
import { specialyService } from "./specialyService";
import type {
  CreateDoctorDTO,
  ReadDoctorDTO,
  ReadSpecialyDTO,
  UpdateDoctorDTO,
} from "./types";

const BASE_PATH = "/api/Doctor";

export interface DoctorWithSpecialy extends ReadDoctorDTO {
  // Enriquecido en el cliente porque ReadDoctorDTO no expone specialyId.
  specialy: ReadSpecialyDTO | null;
}

export const doctorService = {
  getAll: async (): Promise<ReadDoctorDTO[]> => {
    const { data } = await httpClient.get<ReadDoctorDTO[]>(BASE_PATH);
    return data;
  },

  getById: async (id: number): Promise<ReadDoctorDTO> => {
    const { data } = await httpClient.get<ReadDoctorDTO>(`${BASE_PATH}/${id}`);
    return data;
  },

  create: async (payload: CreateDoctorDTO): Promise<void> => {
    await httpClient.post(BASE_PATH, payload);
  },

  update: async (id: number, payload: UpdateDoctorDTO): Promise<void> => {
    await httpClient.put(`${BASE_PATH}/${id}`, payload);
  },

  delete: async (id: number): Promise<void> => {
    await httpClient.delete(`${BASE_PATH}/${id}`);
  },

  /**
   * ReadDoctorDTO NO incluye specialyId (según el prompt, solo el DTO de
   * creación lo trae). Para poder mostrar la especialidad en un listado,
   * esta función cruza doctores con especialidades por NOMBRE del doctor
   * no es posible; como el backend no expone el vínculo en la lectura,
   * NO hay forma confiable de mapear doctor -> especialidad solo con estos
   * endpoints. Se deja este helper como placeholder que devuelve
   * `specialy: null` y un comentario explicando la limitación real del
   * backend, para que se resuelva ahí (agregar specialyId a ReadDoctorDTO).
   */
  getAllWithSpecialy: async (): Promise<DoctorWithSpecialy[]> => {
    const [doctors] = await Promise.all([doctorService.getAll(), specialyService.getAll()]);

    return doctors.map((doctor) => ({
      ...doctor,
      specialy: null, // Bloqueado hasta que el backend exponga specialyId en el GET.
    }));
  },
};
