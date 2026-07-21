using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicalApp.Application.DTOs.DiagnosisDTOs;
using MedicalApp.Application.Interfaces;
using MedicalApp.Application.Interfaces.Repository;
using MedicalApp.Application.Service;
using Microsoft.AspNetCore.Mvc;

namespace MedicalApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DiagnosisController(IDiagnosisServcice _service) : ControllerBase
    {
        [HttpGet("{id}")]

        public async Task<ActionResult<ReadDiagnosisDTOs>> GetDiagnosisById(int id)
        {
            var Diagnosis = _service.GetDiagnosisById(id);
            return Ok(Diagnosis);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadDiagnosisDTOs>>> GetDiagnosisById()
        {
            var Diagnosiss = _service.GetAllDiagnosis();
            return Ok(Diagnosiss);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateDiagnosis(int id, CreateDiagnosisDTOs diagnosis)
        {
            await _service.UpdateDiagnosis(id, diagnosis);
            return NoContent();
        }

        [HttpPost("{id}")]
        public async Task<ActionResult> AddDiagnosis(CreateDiagnosisDTOs diagnosis)
        {
            await _service.AddDiagnosis(diagnosis);
            return Created();
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> RemoveDiagnosis(int id)
        {
            await _service.RemuveDiagnosis(id);
            return NoContent();
        }
    }
}