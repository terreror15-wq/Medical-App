using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicalApp.Application.DTOs.RecipeDTOs;
using MedicalApp.Application.Service;
using Microsoft.AspNetCore.Mvc;

namespace MedicalApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecipeController(IRecipeService _service) : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<ActionResult<ReadRecibeDTO>> GetRecipeById(int id)
        {
            var recipe = await _service.GetRecipeById(id);
            return Ok(recipe);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadRecibeDTO>>> GetAllRecipes(int id)
        {
            var recipes = await _service.GetAllRecipe();
            return Ok(recipes);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateRecipe(int id, CreatedRecipeDTO recipe)
        {
            await _service.UpdateRecipe(id, recipe);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult> AddRecipe(CreatedRecipeDTO recipe)
        {
            await _service.AddRecipe(recipe);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveRecipe(int id)
        {
            await _service.RemuveRecipe(id);
            return NoContent();
        }
    }
}