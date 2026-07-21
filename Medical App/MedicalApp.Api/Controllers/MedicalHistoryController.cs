using MedicalApp.Application.DTOs.MedicalHistoryDTOs;
using MedicalApp.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicalApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalHistoryController(MedicalHistoryService service) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<ReadMedicalHistoryDTOs>> GetAllMedicalHistory()
        {
            var gettingallmedical = await service.GetAllMedicalHistory();
            return Ok(gettingallmedical);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ReadMedicalHistoryDTOs>>GetMedicalHistoryById(int id)
        {
            var gettingmedicalH = await service.GetMedicalHistoryById(id);
            return Ok(gettingmedicalH);
        }
        [HttpPost]
        public async Task<ActionResult> AddMedicalHystory(CreateMedicalHistoryDTOs medical)
        {
            await service.AddMedicalHistory(medical);
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<ActionResult>UpdameMedicalHistory(int id, CreateMedicalHistoryDTOs medicalhistory)
        {
            await service.UpdateMedicalHistory(id, medicalhistory);
            return NoContent();
        }
        [HttpDelete]
        public async Task<ActionResult>RemuveMedicalHistory(int id)
        {
            await service.RemuveMEdicalHistory(id);
            return NoContent();
        }
    }
}
