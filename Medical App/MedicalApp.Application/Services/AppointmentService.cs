using MedicalApp.Application.DTOs.AppointmentDTOs;
using MedicalApp.Application.Interfaces.Repository;
using MedicalApp.Domain.Entities;
using MedicalApp.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp.Application.Services
{
    public class AppointmentService(IAppointmentRepository repo) : IAppointmentService
    {
        public async Task AddAppointment(CreateAppointmentDTOs appointment)
        {
            var cappointment = new Appointment
            {
                Date = appointment.Date,
                Status = appointment.Status,
                Observations = appointment.Observations,
                PacienteId = appointment.PacienteId,
                ReasonForVisit = appointment.ReasonForVisit
            };
            await repo.AddDAppointment(cappointment);
        }

        public async Task<IEnumerable<ReadAppointmentDTOs>> GetAppointment()
        {
            var gettingall = await repo.GetAllAppointment();

            var allappointment = gettingall.Select(x => new ReadAppointmentDTOs
            {
                Date = x.Date,
                Status = x.Status,
                Observations = x.Observations,
                PacienteId = x.PacienteId,
                ReasonForVisit = x.ReasonForVisit
            });
            return allappointment;

            
        }

        public async Task<ReadAppointmentDTOs> GetAppointmentById(int id)
        {
            var appointmentDT = await repo.GetAppointmentById(id);

            var nappointment = new ReadAppointmentDTOs
            {
                Date = appointmentDT.Date,
                Status = appointmentDT.Status,
                Observations = appointmentDT.Observations,
                PacienteId = appointmentDT.PacienteId,
                ReasonForVisit = appointmentDT.ReasonForVisit

            };
            return nappointment;
        }

        public async Task RemoveAppointment(int id)
        {
            await repo.RemuveAppointment(id);
        }

        public async Task UpdateAppointment(int id, CreateAppointmentDTOs appointment)
        {
            var uappointment = new Appointment
            {
                Date = appointment.Date,
                Status = appointment.Status,
                Observations = appointment.Observations,
                PacienteId = appointment.PacienteId,
                ReasonForVisit = appointment.ReasonForVisit
            };
            await repo.UpdateAppointment(id,uappointment);
        }
    }
}
