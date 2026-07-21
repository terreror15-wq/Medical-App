using MedicalApp.Application.DTOs.RecipeDTOs;
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
        public Task<IEnumerable<ReadRecibeDTO>> GetAllRecipe();
        public Task<ReadRecibeDTO> GetRecipeById(int id);
        public Task AddRecipe(CreatedRecipeDTO recipe);
        public Task RemuveRecipe(int id);
        public Task UpdateRecipe(int id, CreatedRecipeDTO recipe);
    }
}
