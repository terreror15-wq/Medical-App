using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicalApp.Application.DTOs.DoctorDTOs;
using MedicalApp.Domain.Entities;

namespace MedicalApp.Application.Interfaces.Service
{
    public interface IDoctorService
    {
        public Task<ReadDoctorDTO> GetDoctorById(int id);
        public Task<IEnumerable<ReadDoctorDTO>> GetDoctors();
        public Task AddDoctor(CreateDoctorDTO doctor);
        public Task RemoveDoctor(int id);
        public Task UpdateDoctor(CreateDoctorDTO doctor, int id);
    }
}