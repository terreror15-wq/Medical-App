using System;
using System.Collections.Generic;
using System.Text;
using MedicalApp.Domain.Core;

namespace MedicalApp.Domain.Entities
{
    public class Recipe : BaseEntity
    {
        public DateTime EmisionDate { get; set; } = DateTime.UtcNow;
        public string? Obsevation { get; set; }
        public int AppointmentId { get; set; }
        public Appointment Appointment { get; set; } = null!;
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; } = null!;
        public ICollection<RecipeDetail> Detalles { get; set; } = new List<RecipeDetail>();

    }
}
