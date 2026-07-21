using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicalApp.Application.DTOs.MedicineDTOs;
using MedicalApp.Application.Service;
using Microsoft.AspNetCore.Mvc;

namespace MedicalApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedicineController(IMedicineService _service) : ControllerBase
    {
        [HttpGet("{id}")]

        public async Task<ActionResult<ReadMedicineDTO>> GetMedicineById(int id)
        {
            var medicine = _service.GetMedicineById(id);
            return Ok(medicine);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadMedicineDTO>>> GetMedicineById()
        {
            var medicines = _service.GetAllMedicine();
            return Ok(medicines);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateMedicine(int id, CreateMedicineDTO medicine)
        {
            await _service.UpdateMedicine(medicine, id);
            return NoContent();
        }

        [HttpPost("{id}")]
        public async Task<ActionResult> AddMedicine(CreateMedicineDTO medicine)
        {
            await _service.AddMedicine(medicine);
            return Created();
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> RemoveMedicine(int id)
        {
            await _service.RemuveMedicine(id);
            return NoContent();
        }
    }
}