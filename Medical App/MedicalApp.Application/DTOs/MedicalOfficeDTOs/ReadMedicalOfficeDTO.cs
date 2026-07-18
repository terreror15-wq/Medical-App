using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalApp.Application.DTOs.MedicalOffice
{
    public class ReadMedicalOfficeDTO
    {
        public string DoorNumber { get; set; } = string.Empty;
        public string? Floor { get; set; }
        public string? Descripcion { get; set; }
    }
}