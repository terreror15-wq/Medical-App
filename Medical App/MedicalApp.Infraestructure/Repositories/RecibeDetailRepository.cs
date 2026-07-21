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
    public class RecibeDetailRepository(MedicalAppDbContext _db) : IRecipeDetailRepository
    {
        public async Task AddRecipeDetail(RecipeDetail recipedetail)
        {
            await _db.RecipeDetails.AddAsync(recipedetail);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<RecipeDetail>> GetAllRecipeDetail()
        {
            var recipeDetails = await _db.RecipeDetails.AsNoTracking().ToListAsync();
            return recipeDetails;
        }

        public async Task<RecipeDetail> GetRecipeDetailById(int id)
        {
            var recipeDetail = await _db.RecipeDetails.FindAsync(id);
            return recipeDetail!;
        }

        public async Task RemuveRecipeDetail(int id)
        {
            var recipeDetail = await GetRecipeDetailById(id);

            _db.RecipeDetails.Remove(recipeDetail);

            await _db.SaveChangesAsync();
        }

        public async Task UpdateRecipeDetail(RecipeDetail NewrecipeDetail, int id)
        {
            var recipeDetail = await GetRecipeDetailById(id);

            recipeDetail.Doses = NewrecipeDetail.Doses;
            recipeDetail.DurationDays = NewrecipeDetail.DurationDays;
            recipeDetail.RecipeId = NewrecipeDetail.RecipeId;

            _db.RecipeDetails.Update(recipeDetail);

            await _db.SaveChangesAsync();

        }
    }
}