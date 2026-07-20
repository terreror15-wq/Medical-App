using MedicalApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp.Application.Interfaces.Repository
{
    public interface IAppointmentRepository
    {
        public Task<Appointment> GetAppointmentById (int id);
        public Task<IEnumerable<Appointment>> GetAllAppointment();
        public Task UpdateAppointment(int id, Appointment appointment);
        public Task RemuveAppointment(int id);
        public Task AddDAppointment(Appointment appointment);
    }
}
