using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicalApp.Application.DTOs.CreatePatientDTOs;
using MedicalApp.Application.DTOs.MedicalOffice;
using MedicalApp.Application.DTOs.PatientDTOs;
using MedicalApp.Application.Interfaces.Repository;
using MedicalApp.Application.Interfaces.Service;
using MedicalApp.Domain.Entities;

namespace MedicalApp.Application.Services
{
    public class PatientService(IPatientRepository repo) : IPatientService
    {
        public async Task AddPatient(CreatePatientDTOs patient)
        {
            var patientDto = new Patient
            {
                Name = patient.Name,
                LastName = patient.LastName,
                Email = patient.Email,
                Phone = patient.Phone,
                IdentityDocument = patient.IdentityDocument,
                DateBirth = patient.DateBirth,
                DateRegister = patient.DateRegister,
                Address = patient.Address
            };

            await repo.AddPatient(patientDto);
        }

        public async Task<IEnumerable<ReadPatientDTOs>> GetAllPatient()
        {
            var patients = await repo.GetAllPatient();

            return patients.Select(patient => new ReadPatientDTOs
            {
                Name = patient.Name,
                LastName = patient.LastName,
                Email = patient.Email,
                Phone = patient.Phone,
                IdentityDocument = patient.IdentityDocument,
                DateBirth = patient.DateBirth,
                DateRegister = patient.DateRegister,
                Address = patient.Address
            });

        }

        public async Task<ReadPatientDTOs> GetPatientById(int id)
        {
            var patient = await repo.GetPatientById(id);
            var patientDto = new ReadPatientDTOs
            {
                Name = patient.Name,
                LastName = patient.LastName,
                Email = patient.Email,
                Phone = patient.Phone,
                IdentityDocument = patient.IdentityDocument,
                DateBirth = patient.DateBirth,
                DateRegister = patient.DateRegister,
                Address = patient.Address
            };

            return patientDto;

        }

        public async Task RemovePatient(int id)
        {
            await repo.RemovePatient(id);
        }

        public async Task UpdatePatient(CreatePatientDTOs patient, int id)
        {
            var Npatient = new Patient
            {
                Name = patient.Name,
                LastName = patient.LastName,
                Email = patient.Email,
                Phone = patient.Phone,
                IdentityDocument = patient.IdentityDocument,
                DateBirth = patient.DateBirth,
                DateRegister = patient.DateRegister,
                Address = patient.Address
            };

            await repo.UpdatePatient(Npatient, id);
        }

    }
}