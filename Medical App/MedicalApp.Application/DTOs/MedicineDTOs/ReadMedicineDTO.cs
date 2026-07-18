using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalApp.Application.DTOs.MedicineDTOs
{
    public class ReadMedicineDTO
    {
        public string? Name { get; set; }
        public string? Presentation { get; set; }
        public string? concetration { get; set; }
        public string? Laboratory { get; set; }

    }
}