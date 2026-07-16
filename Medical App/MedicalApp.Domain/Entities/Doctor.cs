using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalApp.Domain.Entities
{
    public class Doctor
    {
        public string Nombres { get; set; } = string.Empty;
        public string Apellidos { get; set; } = string.Empty;
        public string NumeroColegiado { get; set; } = string.Empty;
        public string? Telefono { get; set; }
        public string? Email { get; set; }
        public bool Activo { get; set; } = true;
        public int EspecialidadId { get; set; }

        public Specialy Specialy { get; set; } = null!;
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
        public ICollection<MedicalHistory> Histories { get; set; } = new List<MedicalHistory>();
        public ICollection<Recipe> Recetas { get; set; } = new List<Recipe>();
    }
}
