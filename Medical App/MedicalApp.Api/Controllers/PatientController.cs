using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicalApp.Application.DTOs.CreatePatientDTOs;
using MedicalApp.Application.DTOs.PatientDTOs;
using MedicalApp.Application.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;

namespace MedicalApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientController(IPatientService _service) : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<ActionResult<ReadPatientDTOs>> GetPatientById(int id)
        {
            var patient = await _service.GetPatientById(id);
            return Ok(patient);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadPatientDTOs>>> GetAllPatient()
        {
            var patiens = await _service.GetAllPatient();
            return Ok(patiens);
        }

        [HttpPost]
        public async Task<ActionResult> CreatePatient(CreatePatientDTOs patient)
        {
            await _service.AddPatient(patient);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePatient(int id, CreatePatientDTOs patient)
        {
            await _service.UpdatePatient(patient, id);
            return NoContent();
        }

        [HttpDelete]

        public async Task<ActionResult> RemovePatient(int id)
        {
            await _service.RemovePatient(id);
            return NoContent();
        }




    }
}