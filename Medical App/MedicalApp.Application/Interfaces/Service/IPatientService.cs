using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicalApp.Application.DTOs.CreatePatientDTOs;
using MedicalApp.Application.DTOs.PatientDTOs;
using MedicalApp.Domain.Entities;

namespace MedicalApp.Application.Interfaces.Service
{
    public interface IPatientService
    {
        public Task<ReadPatientDTOs> GetPatientById(int id);
        public Task<IEnumerable<ReadPatientDTOs>> GetAllPatient();
        public Task AddPatient(CreatePatientDTOs patient);
        public Task RemovePatient(int id);
        public Task UpdatePatient(CreatePatientDTOs patient, int id);
    }
}