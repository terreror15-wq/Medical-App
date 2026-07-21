import { NavLink, Outlet } from "react-router-dom";

const links = [
  { to: "/pacientes", label: "Pacientes" },
  { to: "/doctores", label: "Doctores" },
  { to: "/especialidades", label: "Especialidades" },
  { to: "/consultorios", label: "Consultorios" },
];

export function Layout() {
  return (
    <div className="app-shell">
      <header className="app-header">
        <h1>MedicalApp</h1>
        <nav className="app-nav">
          {links.map((link) => (
            <NavLink
              key={link.to}
              to={link.to}
              className={({ isActive }) => (isActive ? "nav-link active" : "nav-link")}
            >
              {link.label}
            </NavLink>
          ))}
        </nav>
      </header>
      <main className="app-main">
        <Outlet />
      </main>
    </div>
  );
}
