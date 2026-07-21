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
        public int PacientId { get; set; }
        public Patient Paciente { get; set; } = null!;
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; } = null!;
        public int? AppointmentId { get; set; }
        public Appointment? Appointment { get; set; }
        public ICollection<Diagnosis> Diagnoses { get; set; }  = new List<Diagnosis>();
    }
}
