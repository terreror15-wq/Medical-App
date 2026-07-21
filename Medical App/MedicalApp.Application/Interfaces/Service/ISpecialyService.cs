using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicalApp.Application.DTOs.CreateSpecialyDTOs;
using MedicalApp.Application.DTOs.ReadSpecialyDTOs;
using MedicalApp.Domain.Entities;

namespace MedicalApp.Application.Interfaces.Service
{
    public interface ISpecialyService
    {
        public Task<ReadSpecialyDTO> GetSpecialyById(int id);
        public Task<IEnumerable<ReadSpecialyDTO>> GetAllSpecialy();
        public Task AddSpecialy(CreateSpecialyDTO specialy);
        public Task RemoveSpecialy(int id);
        public Task UpdateSpecialy(CreateSpecialyDTO specialy, int id);
    }
}