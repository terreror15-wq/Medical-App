using MedicalApp.Application.DTOs.RecipeDetailDTOs;
using MedicalApp.Application.Interfaces;
using MedicalApp.Application.Service;
using MedicalApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp.Application.Services
{
    public class RecipeDetailService(IRecipeDetailRepository repo) : IRecipeDetailService
    {
        public async Task AddRecipeDetail(CreateRecipeDetailDTOs recipedetail)
        {
            var Recipe = new RecipeDetail
            {
                Doses = recipedetail.Doses,
                DurationDays = recipedetail.DurationDays,
                RecipeId = recipedetail.RecipeId
            };
            await repo.AddRecipeDetail(Recipe);
        }

        public async Task<IEnumerable<ReadRecipeDetailDTOs>> GetAllRecipeDetail()
        {
            var gettingall = await repo.GetAllRecipeDetail();

            var nrecipedetail = gettingall.Select(x => new ReadRecipeDetailDTOs
            {
                Doses = x.Doses,
                DurationDays = x.DurationDays
            });
            return nrecipedetail;
        }

        public async Task<ReadRecipeDetailDTOs>GetRecipeDetailById(int id)
        {
            var drdetail = await repo.GetRecipeDetailById(id);

            var nrecipedetail = new ReadRecipeDetailDTOs
            {
                Doses = drdetail.Doses,
                DurationDays = drdetail.DurationDays
            };
            return nrecipedetail;
        }

        public async Task RemuveRecipeDetail(int id)
        {
            await repo.RemuveRecipeDetail(id);
        }

        public async Task UpdateRecipeDetail(CreateRecipeDetailDTOs recipeDetail, int id)
        {
            var urecipeD = new RecipeDetail
            {
                Doses = recipeDetail.Doses,
                DurationDays = recipeDetail.DurationDays,
                RecipeId = recipeDetail.RecipeId

            };
            await repo.UpdateRecipeDetail(urecipeD, id);
        }
    }
}
