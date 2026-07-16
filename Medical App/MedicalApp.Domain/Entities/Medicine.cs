using System;
using System.Collections.Generic;
using System.Text;
using MedicalApp.Domain.Core;
namespace MedicalApp.Domain.Entities
{
    public class Medicine: BaseEntity
    {
      
        public string? Name { get; set; }
        public string ? Presentation { get; set; }
        public string? concetration { get; set; }
        public string? Laboratory { get; set; }

        //public ICollection<RecipeDetail> RecipeDetail {get;set;}= new List <RecipeDetail>();

        
    }
}
