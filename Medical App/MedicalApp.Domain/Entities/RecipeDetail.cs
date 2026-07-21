using MedicalApp.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalApp.Domain.Entities
{
    public class RecipeDetail : BaseEntity
    {
        public string Doses { get; set; } = string.Empty;
        public int DurationDays { get; set; }
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; } = null!;
    }
}
