using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicalApp.Application.DTOs.CreateSpecialyDTOs;
using MedicalApp.Application.DTOs.ReadSpecialyDTOs;
using MedicalApp.Application.Interfaces.Repository;
using MedicalApp.Application.Interfaces.Service;
using MedicalApp.Domain.Entities;

namespace MedicalApp.Application.Services
{
    public class SpecialyService(ISpecialyRepository repo) : ISpecialyService
    {
        public async Task AddSpecialy(CreateSpecialyDTO specialy)
        {
            var specialyDto = new Specialy
            {
                Name = specialy.Name,
                Description = specialy.Description

            };

            await repo.AddSpecialy(specialyDto);
        }

        public async Task<IEnumerable<ReadSpecialyDTO>> GetAllSpecialy()
        {
            var listSpecialy = await repo.GetAllSpecialy();
            
            return listSpecialy.Select(specialy => new ReadSpecialyDTO
            {
                Name = specialy.Name,
                Description = specialy.Description
            });
        }

        public async Task<ReadSpecialyDTO> GetSpecialyById(int id)
        {
            var specialy = await repo.GetSpecialyById(id);

            var specialyDto = new ReadSpecialyDTO
            {
                Name = specialy.Name,
                Description = specialy.Description
            };

            return specialyDto;
        }

        public async Task RemoveSpecialy(int id)
        {
            await repo.RemoveSpecialy(id);
        }

        public async Task UpdateSpecialy(CreateSpecialyDTO specialy, int id)
        {
            var NspecialyDto = new Specialy
            {
                Name = specialy.Name,
                Description = specialy.Description
            };

            await repo.UpdateSpecialy(NspecialyDto, id);
        }
    }
}