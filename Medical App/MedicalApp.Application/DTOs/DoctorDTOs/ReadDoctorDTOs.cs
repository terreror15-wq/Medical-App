using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalApp.Application.DTOs.DoctorDTOs
{
    public class ReadDoctorDTO
    {
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string RegistrationNumber { get; set; } = string.Empty;
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public bool Active { get; set; } = true;
    }
}