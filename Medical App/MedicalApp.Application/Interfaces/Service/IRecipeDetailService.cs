using MedicalApp.Application.DTOs.RecipeDTOs;
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
        public Task<IEnumerable<ReadRecibeDTO>>GetAllRecipeDetail();
        public Task<ReadRecibeDTO> GetRecipeDetailById(int id);
        public Task AddRecipeDetail(CreatedRecipeDTO recipedetail);
        public Task RemuveRecipeDetail(int id);
        public Task UpdateRecipeDetail(CreatedRecipeDTO recipeDetail, int id);
    }
}
