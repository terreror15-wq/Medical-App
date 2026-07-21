using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicalApp.Application.DTOs.DoctorDTOs;
using MedicalApp.Application.Interfaces.Repository;
using MedicalApp.Application.Interfaces.Service;
using MedicalApp.Domain.Entities;

namespace MedicalApp.Application.Services
{
    public class DoctorService(IDoctorRepository repo) : IDoctorService
    {
        public async Task AddDoctor(CreateDoctorDTO doctor)
        {
            var doctorDTOs = new Doctor
            {
                Name = doctor.Name,
                LastName = doctor.LastName,
                Phone = doctor.Phone,
                Email = doctor.Email,
                Active = doctor.Active
            };
            await repo.AddDoctor(doctorDTOs);
        }

        public async Task<ReadDoctorDTO> GetDoctorById(int id)
        {
            var doc = await repo.GetDoctorById(id);

            var docDto = new ReadDoctorDTO
            {
                Name = doc.Name,
                LastName = doc.LastName,
                Email = doc.Email,
                Phone = doc.Phone,
                Active = doc.Active,
                RegistrationNumber = doc.RegistrationNumber
            };
            return docDto;
        }

        public async Task<IEnumerable<ReadDoctorDTO>> GetDoctors()
        {

            var doctors = await repo.GetDoctors();

            return doctors.Select(x => new ReadDoctorDTO
            {
                Name = x.Name,
                LastName = x.LastName,
                Email = x.Email,
                Phone = x.Phone,
                Active = x.Active,
                RegistrationNumber = x.RegistrationNumber
            }); ;
        }

        public async Task RemoveDoctor(int id)
        {
            await repo.RemoveDoctor(id);
        }

        public async Task UpdateDoctor(CreateDoctorDTO doctor, int id)
        {
            var doctorDTOs = new Doctor
            {
                Name = doctor.Name,
                LastName = doctor.LastName,
                Phone = doctor.Phone,
                Email = doctor.Email,
                Active = doctor.Active
            };

            await repo.UpdateDoctor(doctorDTOs, id);
        }


    }
}