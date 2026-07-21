using MedicalApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp.Application.Interfaces
{
    public interface IRecipeRepository
    {
        public Task<IEnumerable<Recipe>>GetAllRecipe();
        public Task<Recipe>GetRecipeById(int id);
        public Task AddRecipe(Recipe recipe);
        public Task RemuveRecipe(int id);
        public Task UpdateRecipe(int id, Recipe recipe);

    }
}
