using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp.Application.DTOs.RecipeDetailDTOs
{
    public class CreateRecipeDetailDTOs
    {
        public string Doses { get; set; } = string.Empty;
        
        public int DurationDays { get; set; }
        public int RecipeId { get; set; }
    }
}
