import { Navigate, Route, Routes } from "react-router-dom";
import { Layout } from "@/components/Layout";
import PatientsPage from "@/pages/PatientsPage";
import DoctorsPage from "@/pages/DoctorsPage";
import SpecialiesPage from "@/pages/SpecialiesPage";
import MedicalOfficesPage from "@/pages/MedicalOfficesPage";

export default function App() {
  return (
    <Routes>
      <Route element={<Layout />}>
        <Route index element={<Navigate to="/pacientes" replace />} />
        <Route path="/pacientes" element={<PatientsPage />} />
        <Route path="/doctores" element={<DoctorsPage />} />
        <Route path="/especialidades" element={<SpecialiesPage />} />
        <Route path="/consultorios" element={<MedicalOfficesPage />} />
        <Route path="*" element={<Navigate to="/pacientes" replace />} />
      </Route>
    </Routes>
  );
}
