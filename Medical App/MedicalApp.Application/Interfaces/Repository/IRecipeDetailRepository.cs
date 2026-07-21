using MedicalApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp.Application.Interfaces
{
    public interface IRecipeDetailRepository
    {
        public Task<IEnumerable<RecipeDetail>> GetAllRecipeDetail();
        public Task<RecipeDetail> GetRecipeDetailById(int id);
        public Task AddRecipeDetail(RecipeDetail recipedetail);
        public Task RemuveRecipeDetail(int id);
        public Task UpdateRecipeDetail(RecipeDetail recipeDetail, int id);
    }
}
