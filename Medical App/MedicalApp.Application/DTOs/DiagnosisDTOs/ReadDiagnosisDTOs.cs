using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp.Application.DTOs.DiagnosisDTOs
{
    public class ReadDiagnosisDTOs
    {
        public string? CodeCIE { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime Date { get; set; } = DateTime.UtcNow;
    
    }
}
