import type { ApiError } from "@/api/types";

interface ErrorBannerProps {
  error: ApiError | null | undefined;
}

export function ErrorBanner({ error }: ErrorBannerProps) {
  if (!error) return null;

  return (
    <div className="error-banner" role="alert">
      <strong>{error.status ? `Error ${error.status}` : "Error de conexión"}</strong>
      <span>{error.message}</span>
    </div>
  );
}
