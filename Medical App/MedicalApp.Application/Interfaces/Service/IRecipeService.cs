using MedicalApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp.Application.Service
{
    public interface IRecipeService
    {
        public Task<IEnumerable<Recipe>> GetAllRecipe();
        public Task<Recipe> GetRecipeById(int id);
        public Task<Recipe> AddRecipe(Recipe recipe);
        public Task<Recipe> RemuveRecipe(int id);
        public Task<Recipe> UpdateRecipe(int id, Recipe recipe);
    }
}
