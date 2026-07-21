using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicalApp.Application.DTOs.AppointmentDTOs;
using MedicalApp.Application.Interfaces.Repository;
using MedicalApp.Domain.Entities;
using MedicalApp.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace MedicalApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentController(IAppointmentService _service) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadAppointmentDTOs>>> GetAllAppointment()
        {
            var appointment = await _service.GetAppointment();
            return Ok(appointment);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReadAppointmentDTOs>> GetAppointmentById(int id)
        {
            var appointment = await _service.GetAppointmentById(id);

            return Ok(appointment);
        }

        [HttpPost]
        public async Task<ActionResult> AddAppointment(CreateAppointmentDTOs appointment)
        {
            await _service.AddAppointment(appointment);
            return Created();
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> RemoveAppointment(int id)
        {
            await _service.RemoveAppointment(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAppointment(int id, CreateAppointmentDTOs appointment)
        {
            await _service.UpdateAppointment(appointment, id);
            return NoContent();
        }
    }
}