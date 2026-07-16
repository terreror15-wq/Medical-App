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

        //public Especialidad Especialidad { get; set; } = null!;
        //public ICollection<Cita> Citas { get; set; } = new List<Cita>();
        //public ICollection<HistorialMedico> Historiales { get; set; } = new List<HistorialMedico>();
        //public ICollection<Receta> Recetas { get; set; } = new List<Receta>();
    }
}