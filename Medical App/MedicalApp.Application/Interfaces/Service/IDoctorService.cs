using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicalApp.Domain.Entities;

namespace MedicalApp.Application.Interfaces.Service
{
    public interface IDoctorService
    {
        public Task<Doctor> GetDoctorById(int id);
        public Task<IEnumerable<Doctor>> GetDoctors();
        public Task AddDoctor(Doctor doctor);
        public Task RemoveDoctor(int id);
        public Task UpdateDoctor(Doctor doctor, int id);
    }
}