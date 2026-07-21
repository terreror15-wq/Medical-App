using MedicalApp.Application.DTOs.MedicalOffice;
using MedicalApp.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace MedicalApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalOfficeController(MedicalOfficeService service) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<ReadMedicalOfficeDTO>> GetAllMedicalOffice()
        {
            var gettmnedicaloffice = await service.GetAllMedicalOffice();
            return Ok(gettmnedicaloffice);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ReadMedicalOfficeDTO>> GetMedicalOfficeById(int id)
        {
            var getbyid = await service.GetMedicalOfficeById(id);
            return Ok(getbyid);
        }
        [HttpPost]
        public async Task<ActionResult> AddNewMedicalOffice(CreateMedicalOfficeDTO medicalOffice)
        {
            await service.AddMedicalOffice(medicalOffice);
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<ActionResult>UpdateMedicalOffice(int id, CreateMedicalOfficeDTO createMedical)
        {
            await service.UpdateMedicalOffice(createMedical, id);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult>RemuveMedicalOffice(int id)
        {
            await service.RemoveMedicalOffice(id);
            return NoContent();
        }
    }
}
