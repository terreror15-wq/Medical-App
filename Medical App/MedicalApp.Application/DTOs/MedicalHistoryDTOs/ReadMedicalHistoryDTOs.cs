using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp.Application.DTOs.MedicalHistoryDTOs
{
    public class ReadMedicalHistoryDTOs
    {
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public string ReasonVisit { get; set; } = string.Empty;
        public string? Symptoms { get; set; }
        public string? Observations { get; set; }
        public int DoctorId { get; set; }
    }
}
