using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp.Application.DTOs.AppointmentDTOs
{
    public class CreateAppointmentDTOs
    {
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public string ReasonForVisit { get; set; } = string.Empty;
        public string? Observations { get; set; }
      
        public int PacienteId { get; set; } 
    }
}
