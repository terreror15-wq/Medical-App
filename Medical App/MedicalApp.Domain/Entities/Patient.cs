using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalApp.Domain.Entities
{
    public class Patient
    {
        public int Id { get; set; }
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
        public ICollection<Appointment> Appointment { get; set; } = new List<Appointment>();
        public ICollection<MedicalHistory> Histories { get; set; } = new List<MedicalHistory>();
        public ICollection<Recipe> Recetas { get; set; } = new List<Recipe>();

    }
}