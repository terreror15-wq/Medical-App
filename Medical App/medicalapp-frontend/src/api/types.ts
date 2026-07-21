/**
 * Tipos que reflejan EXACTAMENTE los DTOs del backend ASP.NET Core.
 * No se agregan campos que no estén documentados en el swagger/prompt original.
 *
 * Convención de nombres: se respetan los nombres de campo tal cual los expone
 * el backend, incluyendo inconsistencias conocidas:
 *  - Medicine.concetration (con typo, NO "concentration")
 *  - Appointment.pacienteId (en español, con "e")
 *  - MedicalHistory.pacientId (en español, SIN "e" — distinto de Appointment)
 *  - MedicalOffice.descripcion (en español, sin acento tipado)
 */

// ---------------------------------------------------------------------------
// Patient
// ---------------------------------------------------------------------------
export interface PatientDTO {
  name: string;
  lastName: string;
  identityDocument: string;
  dateBirth: string; // ISO date string, ej "2025-01-01T00:00:00"
  phone: string | null;
  email: string | null;
  address: string | null;
  dateRegister: string; // ISO date string
  active: boolean;
}

// El backend no confirma un shape distinto para lectura vs creación,
// así que Read/Create comparten forma. Se añade el id solo para las
// respuestas que sí lo incluyen (GET), nunca se envía en el body de POST.
export interface ReadPatientDTO extends PatientDTO {
  id: number;
}
export type CreatePatientDTO = PatientDTO;
export type UpdatePatientDTO = PatientDTO;

// ---------------------------------------------------------------------------
// Doctor
// ---------------------------------------------------------------------------
export interface DoctorDTO {
  name: string;
  lastName: string;
  registrationNumber: string;
  phone: string | null;
  email: string | null;
  active: boolean;
  specialyId: number;
}

export type CreateDoctorDTO = DoctorDTO;
export type UpdateDoctorDTO = DoctorDTO;

// ReadDoctorDTO NO expone specialyId según el prompt: solo el DTO de creación
// lo trae. Si necesitas mostrar la especialidad en el listado, hay que cruzar
// manualmente con GET /api/Specialy (ver doctorService.getAllWithSpecialy).
export interface ReadDoctorDTO {
  id: number;
  name: string;
  lastName: string;
  registrationNumber: string;
  phone: string | null;
  email: string | null;
  active: boolean;
}

// ---------------------------------------------------------------------------
// Specialy
// ---------------------------------------------------------------------------
export interface SpecialyDTO {
  name: string;
  description: string;
}
export interface ReadSpecialyDTO extends SpecialyDTO {
  id: number;
}
export type CreateSpecialyDTO = SpecialyDTO;
export type UpdateSpecialyDTO = SpecialyDTO;

// ---------------------------------------------------------------------------
// MedicalOffice
// ---------------------------------------------------------------------------
export interface MedicalOfficeDTO {
  doorNumber: string;
  floor: string | null;
  descripcion: string | null;
}
export interface ReadMedicalOfficeDTO extends MedicalOfficeDTO {
  id: number;
}
export type CreateMedicalOfficeDTO = MedicalOfficeDTO;
export type UpdateMedicalOfficeDTO = MedicalOfficeDTO;

// ---------------------------------------------------------------------------
// Appointment
// ---------------------------------------------------------------------------
export interface AppointmentDTO {
  date: string; // ISO date string
  status: string | null;
  reasonForVisit: string;
  observations: string | null;
  pacienteId: number;
}
export interface ReadAppointmentDTO extends AppointmentDTO {
  id: number;
}
export type CreateAppointmentDTO = AppointmentDTO;
export type UpdateAppointmentDTO = AppointmentDTO;

// ---------------------------------------------------------------------------
// MedicalHistory
// ---------------------------------------------------------------------------
export interface MedicalHistoryDTO {
  date: string;
  reasonVisit: string;
  symptoms: string | null;
  observations: string | null;
  pacientId: number;
  doctorId: number;
  appointmentId: number;
}
export interface ReadMedicalHistoryDTO extends MedicalHistoryDTO {
  id: number;
}
export type CreateMedicalHistoryDTO = MedicalHistoryDTO;
export type UpdateMedicalHistoryDTO = MedicalHistoryDTO;

// ---------------------------------------------------------------------------
// Diagnosis
// ---------------------------------------------------------------------------
export interface DiagnosisDTO {
  codeCIE: string | null;
  description: string;
  date: string;
}
export interface ReadDiagnosisDTO extends DiagnosisDTO {
  id: number;
}
export type CreateDiagnosisDTO = DiagnosisDTO;
export type UpdateDiagnosisDTO = DiagnosisDTO;

// ---------------------------------------------------------------------------
// Recipe / Receta
// ---------------------------------------------------------------------------
export interface RecipeDTO {
  emisionDate: string;
  obsevation: string | null; // typo respetado tal cual lo expone el backend
  doctorId: number;
  appointmentId: number;
}
export interface ReadRecipeDTO extends RecipeDTO {
  id: number;
}
export type CreateRecipeDTO = RecipeDTO;
export type UpdateRecipeDTO = RecipeDTO;

// ---------------------------------------------------------------------------
// RecipeDetail
// ---------------------------------------------------------------------------
export interface RecipeDetailDTO {
  doses: string;
  durationDays: number;
  recipeId: number;
}
export interface ReadRecipeDetailDTO extends RecipeDetailDTO {
  id: number;
}
export type CreateRecipeDetailDTO = RecipeDetailDTO;
export type UpdateRecipeDetailDTO = RecipeDetailDTO;

// ---------------------------------------------------------------------------
// Medicine
// ---------------------------------------------------------------------------
export interface MedicineDTO {
  name: string | null;
  presentation: string | null;
  concetration: string | null; // OJO: typo intencional, así lo espera el backend
  laboratory: string | null;
}
export interface ReadMedicineDTO extends MedicineDTO {
  id: number;
}
export type CreateMedicineDTO = MedicineDTO;
export type UpdateMedicineDTO = MedicineDTO;

// ---------------------------------------------------------------------------
// Error normalizado que expone el httpClient hacia la UI
// ---------------------------------------------------------------------------
export interface ApiError {
  status: number | null;
  message: string;
  details?: unknown;
}
