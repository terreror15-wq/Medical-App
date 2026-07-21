using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicalApp.Application.Interfaces.Repository;
using MedicalApp.Domain.Entities;
using MedicalApp.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace MedicalApp.Infraestructure.Repositories
{
    public class SpecialyRepository(MedicalAppDbContext _db) : ISpecialyRepository
    {
        public async Task AddSpecialy(Specialy specialy)
        {
            await _db.Specialies.AddAsync(specialy);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Specialy>> GetAllSpecialy()
        {
            var specialy = await _db.Specialies.AsTracking().ToListAsync();
            return specialy;
        }

        public async Task<Specialy> GetSpecialyById(int id)
        {
            var specialy = await _db.Specialies.FindAsync(id);
            if (specialy is null) { return null!; }
            return specialy;
        }

        public async Task RemoveSpecialy(int id)
        {
            var specialy = await GetSpecialyById(id);
            _db.Specialies.Remove(specialy);
            await _db.SaveChangesAsync();
        }

        public Task UpdateSpecialy(Specialy specialy, int id)
        {
            throw new NotImplementedException();
        }
    }
}