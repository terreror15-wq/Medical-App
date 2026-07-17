using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicalApp.Domain.Entities;

namespace MedicalApp.Application.Interfaces.Service
{
    public interface ISpecialyService
    {
        public Task<Specialy> GetSpecialyById(int id);
        public Task<IEnumerable<Specialy>> GetAllSpecialy();
        public Task AddSpecialy(Specialy specialy);
        public Task RemoveSpecialy(int id);
        public Task UpdateSpecialy(Specialy specialy, int id);
    }
}