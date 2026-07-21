/**
 * El backend espera fechas ISO completas, ej "2025-01-01T00:00:00".
 * Los inputs HTML de tipo date solo trabajan con "YYYY-MM-DD".
 * Estas funciones convierten entre ambos formatos.
 */

// "2025-01-01T00:00:00" -> "2025-01-01" (para precargar un <input type="date">)
export function isoToDateInput(iso: string | null | undefined): string {
  if (!iso) return "";
  return iso.slice(0, 10);
}

// "2025-01-01" -> "2025-01-01T00:00:00" (para enviar al backend)
export function dateInputToIso(dateOnly: string): string {
  if (!dateOnly) return "";
  return `${dateOnly}T00:00:00`;
}

// Formato legible para mostrar en tablas, ej "01/01/2025"
export function formatDateDisplay(iso: string | null | undefined): string {
  if (!iso) return "—";
  const datePart = iso.slice(0, 10);
  const [year, month, day] = datePart.split("-");
  if (!year || !month || !day) return datePart;
  return `${day}/${month}/${year}`;
}
