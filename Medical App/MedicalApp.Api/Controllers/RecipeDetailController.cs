using MedicalApp.Application.DTOs.RecipeDetailDTOs;
using MedicalApp.Application.Interfaces;
using MedicalApp.Application.Service;
using MedicalApp.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicalApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeDetailController(RecipeDetailService service) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<ReadRecipeDetailDTOs>> GetAllRecipeDetail()
        {
            var allRecipeDetail = await service.GetAllRecipeDetail();
            return Ok(allRecipeDetail);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ReadRecipeDetailDTOs>>GetRecipeDetailById(int id)
        {
            var recipeDetailid = await service.GetRecipeDetailById(id);
            return Ok(recipeDetailid);
        }
        [HttpPost]
        public async Task<ActionResult>AddRecipeDetail(CreateRecipeDetailDTOs recipeDetailDTOs)
        {
            await service.AddRecipeDetail(recipeDetailDTOs);
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<ActionResult>UpdateRecipeDetail(CreateRecipeDetailDTOs createRecipe, int id)
        {
            await service.UpdateRecipeDetail(createRecipe, id);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult>RemuveRecipeDetail(int id)
        {
            await service.RemuveRecipeDetail(id);
            return NoContent();
        }
    }
}
