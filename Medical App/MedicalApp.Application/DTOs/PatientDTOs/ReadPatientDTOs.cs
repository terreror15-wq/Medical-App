using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalApp.Application.DTOs.PatientDTOs
{
    public class ReadPatientDTOs
    {
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string IdentityDocument { get; set; } = string.Empty;
        public DateTime DateBirth { get; set; }
        //public Genero Genero { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public DateTime DateRegister { get; set; } = DateTime.UtcNow;
        public bool Active { get; set; } = true;
    }
}