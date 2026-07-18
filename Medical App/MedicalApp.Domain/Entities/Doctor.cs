using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalApp.Domain.Entities
{
    public class Doctor
    {
     public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string RegistrationNumber { get; set; } = string.Empty;
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public bool Active { get; set; } = true;
        public int SpecialyId { get; set; }
        public Specialy Specialy { get; set; } = null!;
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
        public ICollection<MedicalHistory> Historiales { get; set; } = new List<MedicalHistory>();
        public ICollection<Recipe> Recetas { get; set; } = new List<Recipe>();
    }
}
