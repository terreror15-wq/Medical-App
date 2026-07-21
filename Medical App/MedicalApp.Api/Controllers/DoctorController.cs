using MedicalApp.Application.DTOs.DoctorDTOs;
using MedicalApp.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace MedicalApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController(DoctorService service) : ControllerBase
    {
        [HttpGet]

        public async Task<ActionResult<ReadDoctorDTO>> GetAllDoctors()
        {
           var gettindoctors = await service.GetDoctors();

            return Ok(gettindoctors);
            
        }
        [HttpGet("{id}")]

        public async Task<ActionResult<ReadDoctorDTO>>GetDoctorById(int id)
        {
            var doctobyid = await service.GetDoctorById(id);

            return Ok(doctobyid);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult>UpdateDoctor(int id, CreateDoctorDTO createDoctor)
        {
            await service.UpdateDoctor(createDoctor, id);

            return NoContent();
        }
        [HttpPost]
        public async Task<ActionResult>AddDoctor(CreateDoctorDTO ndoctor)
        {
            await service.AddDoctor(ndoctor);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> RemuveDoctor(int id)
        {
            await service.RemoveDoctor(id);
            return NoContent();
        }
        

    }
}
