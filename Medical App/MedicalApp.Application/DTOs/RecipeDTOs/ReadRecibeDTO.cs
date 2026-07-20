using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalApp.Application.DTOs.RecipeDTOs
{
    public class ReadRecibeDTO
    {
        public DateTime EmisionDate { get; set; } = DateTime.UtcNow;
        public string? Obsevation { get; set; }
    }
}