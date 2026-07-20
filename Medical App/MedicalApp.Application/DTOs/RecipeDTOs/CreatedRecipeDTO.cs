using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalApp.Application.DTOs.RecipeDTOs
{
    public class CreatedRecipeDTO
    {
        public DateTime EmisionDate { get; set; } = DateTime.UtcNow;
        public string? Obsevation { get; set; }
        public int DoctorId { get; set; }
        public int AppointmentId { get; set; }

    }
}