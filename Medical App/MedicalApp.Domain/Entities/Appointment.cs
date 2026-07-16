using MedicalApp.Domain.BaseEntity;
using MedicalApp.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalApp.Domain.Entities
{
    public class Appointment : BaseEntity
    {
        
        public DateTime Date { get; set; }
        public string Status { get; set; }  //pendiente
        public string  ReasonForVisit { get; set; } = string.Empty;
        public string? Observations { get; set; }
        public DateTime CraateTime { get; set; } = DateTime.UtcNow;
        //public int PacienteId { get; set; }
        //public Paciente Paciente { get; set; } = null!;
       // public int DoctorId { get; set; }
       // public Doctor Doctor { get; set; } = null!;
       // public int ConsultorioId { get; set; }
        //public Consultorio Consultorio { get; set; } = null!;
        //public HistorialMedico? HistorialMedico { get; set; }


    }
}
