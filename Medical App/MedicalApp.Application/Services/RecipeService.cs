using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicalApp.Application.DTOs.DoctorDTOs;
using MedicalApp.Application.DTOs.RecipeDTOs;
using MedicalApp.Application.Interfaces;
using MedicalApp.Application.Service;
using MedicalApp.Domain.Entities;

namespace MedicalApp.Application.Services
{
    public class RecipeService(IRecipeRepository repo) : IRecipeService
    {
        public async Task AddRecipe(CreatedRecipeDTO recipe)
        {
            var recipeDto = new Recipe
            {
                Obsevation = recipe.Obsevation,
                EmisionDate = recipe.EmisionDate,
                DoctorId = recipe.DoctorId,
                AppointmentId = recipe.AppointmentId

            };

            await repo.AddRecipe(recipeDto);
        }

        public async Task<IEnumerable<ReadRecibeDTO>> GetAllRecipe()
        {
            var gettingRecipe = await repo.GetAllRecipe();

            return gettingRecipe.Select(x => new ReadRecibeDTO
            {
                Obsevation = x.Obsevation,
                EmisionDate = x.EmisionDate
            });

        }

        public async Task<ReadRecibeDTO> GetRecipeById(int id)
        {
            var recipe = await repo.GetRecipeById(id);

            var recipeDto = new ReadRecibeDTO
            {
                Obsevation = recipe.Obsevation,
                EmisionDate = recipe.EmisionDate
            };

            return recipeDto;
        }

        public async Task RemuveRecipe(int id)
        {
            await repo.RemuveRecipe(id);
        }

        public async Task UpdateRecipe(int id, CreatedRecipeDTO recipe)
        {
            var recipeDto = new Recipe
            {
                Obsevation = recipe.Obsevation,
                EmisionDate = recipe.EmisionDate
            };
            await repo.UpdateRecipe(id, recipeDto);
        }
    }
}