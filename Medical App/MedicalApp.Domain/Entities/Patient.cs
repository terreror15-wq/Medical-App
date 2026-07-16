using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalApp.Domain.Entities
{
    public class Patient
    {
        public int Id { get; set; }
        public string Nombres { get; set; } = string.Empty;
        public string Apellidos { get; set; } = string.Empty;
        public string DocumentoIdentidad { get; set; } = string.Empty;
        public DateTime FechaNacimiento { get; set; }
        //public Genero Genero { get; set; }
        public string? Telefono { get; set; }
        public string? Email { get; set; }
        public string? Direccion { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool Activo { get; set; } = true;
        //public ICollection<Cita> Citas { get; set; } = new List<Cita>();
        //public ICollection<HistorialMedico> Historiales { get; set; } = new List<HistorialMedico>();
        //public ICollection<Receta> Recetas { get; set; } = new List<Receta>();

    }
}