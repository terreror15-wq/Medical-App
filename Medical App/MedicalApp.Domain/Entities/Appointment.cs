using MedicalApp.Domain.Entities;
using MedicalApp.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalApp.Domain.Entities
{
    public class Appointment : BaseEntity
    {

        public DateTime Date { get; set; }
        public string Status { get; set; }
        public string ReasonForVisit { get; set; } = string.Empty;
        public string? Observations { get; set; }
        public DateTime CraateTime { get; set; } = DateTime.UtcNow;
        public int PacienteId { get; set; }
        public Patient Patient { get; set; } = null!;
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; } = null!;
        public int ConsultorioId { get; set; }
        public MedicalOffice MedicalOffice { get; set; } = null!;
        public MedicalHistory? MedicalHistory { get; set; }


    }
}
