using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicalApp.Domain.Entities;

namespace MedicalApp.Application.Interfaces.Repository
{
    public interface IPatientRepository
    {
        public Task<Patient> GetPatientById(int id);
        public Task<IEnumerable<Patient>> GetAllPatient();
        public Task AddPatient(Patient patient);
        public Task RemovePatient(int id);
        public Task UpdatePatient(Patient patient, int id);
    }
}