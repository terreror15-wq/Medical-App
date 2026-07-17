using MedicalApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp.Application.Service
{
    public interface IRecipeDetailService
    {
        public Task<IEnumerable<RecipeDetail>>GetAllRecipeDetail();
        public Task<RecipeDetail> GetRecipeDetailById(int id);
        public Task<RecipeDetail> AddRecipeDetail(RecipeDetail recipedetail);
        public Task<RecipeDetail> RemuveRecipeDetail(int id);
        public Task<RecipeDetail> UpdateRecipeDetail(RecipeDetail recipeDetail, int id);
    }
}
