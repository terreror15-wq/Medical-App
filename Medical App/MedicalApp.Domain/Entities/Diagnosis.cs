using MedicalApp.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalApp.Domain.Entities
{
    public class Diagnosis : BaseEntity
    {
        
        public string? CodeCIE { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public int MedicalHistoryId { get; set; }
        public MedicalHistory MedicalHistory { get; set; } = null!;
    }
}
