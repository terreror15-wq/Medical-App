using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicalApp.Application.Interfaces;
using MedicalApp.Domain.Entities;
using MedicalApp.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace MedicalApp.Infraestructure.Repositories
{
    public class RecipeRepository(MedicalAppDbContext _db) : IRecipeRepository
    {
        public async Task AddRecipe(Recipe recipe)
        {
            await _db.Recipes.AddAsync(recipe);
            await _db.SaveChangesAsync();

        }

        public async Task<IEnumerable<Recipe>> GetAllRecipe()
        {
            var recipes = await _db.Recipes.AsNoTracking().ToListAsync();
            return recipes;
        }

        public async Task<Recipe> GetRecipeById(int id)
        {
            var recipe = await _db.Recipes.FindAsync(id);
            if (recipe is null)
            {
                return null!;
            }
            ;

            return recipe;
        }

        public async Task RemuveRecipe(int id)
        {
            var recipe = await _db.Recipes.FindAsync(id);
            if (recipe is null)
            {
                return;
            };
            _db.Recipes.Remove(recipe);

        }

        public async Task UpdateRecipe(int id, Recipe newRecipe)
        {
            var recipe = await _db.Recipes.FindAsync(id);

            recipe!.EmisionDate = newRecipe.EmisionDate;
            recipe.Obsevation = newRecipe.Obsevation;
            recipe.AppointmentId = newRecipe.AppointmentId;
            recipe.DoctorId = newRecipe.DoctorId;

            _db.Recipes.Update(recipe);
            await _db.SaveChangesAsync();
        }
    }
}