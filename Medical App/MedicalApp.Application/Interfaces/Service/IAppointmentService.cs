using MedicalApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalApp.Domain.Interfaces.Services
{
    public interface IAppointmentService
    {
        public Task<Appointment> GetAppointmentById();
        public Task<IEnumerable<Appointment>> GetAppointment();
        public Task AddAppointment(Appointment appointment);
        public Task RemoveAppointment(int id);
        public Task UpdateAppointment(Appointment appointment, int id);

    }
}
