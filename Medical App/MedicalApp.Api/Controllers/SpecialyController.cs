using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicalApp.Application.DTOs.CreateSpecialyDTOs;
using MedicalApp.Application.DTOs.ReadSpecialyDTOs;
using MedicalApp.Application.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;

namespace MedicalApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SpecialyController(ISpecialyService _service) : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<ActionResult<ReadSpecialyDTO>> GetSpecialyById(int id)
        {
            var specialy = await _service.GetSpecialyById(id);
            return Ok(specialy);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadSpecialyDTO>>> GetAllSpecialy()
        {
            var specialties = await _service.GetAllSpecialy();
            return Ok(specialties);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> RemoveSpecialy(int id)
        {
            await _service.RemoveSpecialy(id);
            return NoContent();
        }

        [HttpPost]

        public async Task<ActionResult> CreateSpecialy(CreateSpecialyDTO specialy)
        {
            await _service.AddSpecialy(specialy);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ReadSpecialyDTO>> UpdateSpecialy(int id, CreateSpecialyDTO specialy)
        {
            await _service.UpdateSpecialy(specialy, id);
            return NoContent();
        }
    }
}