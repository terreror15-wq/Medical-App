using MedicalApp.Application.DTOs.AppointmentDTOs;
using MedicalApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalApp.Domain.Interfaces.Services
{
    public interface IAppointmentService
    {
        public Task<ReadAppointmentDTOs> GetAppointmentById();
        public Task<IEnumerable<ReadAppointmentDTOs>> GetAppointment();
        public Task AddAppointment(CreateAppointmentDTOs appointment);
        public Task RemoveAppointment(int id);
        public Task UpdateAppointment(CreateAppointmentDTOs appointment, int id);

    }
}
