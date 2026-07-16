using MedicalApp.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalApp.Domain.Entities
{
    public class MedicalHistory : BaseEntity
    {
      
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public string ReasonVisit { get; set; } = string.Empty;
        public string? Symptoms { get; set; }
        public string? Observations { get; set; }
        //public int PacienteId { get; set; }
        // public Paciente Paciente { get; set; } = null!;
        // public int DoctorId { get; set; }
        // public Doctor Doctor { get; set; } = null!;
        //public int? CitaId { get; set; }
        //public Cita? Cita { get; set; }
        //public ICollection<Diagnostico> Diagnosticos { get; set; }
    }
}
