using MedicalApp.Application.Interfaces.Repository;
using MedicalApp.Domain.Entities;
using MedicalApp.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Numerics;
using System.Text;

namespace MedicalApp.Infraestructure.Repositories
{
    public class MedicalOfficeRepository(MedicalAppDbContext _db) : IMedicalOfficeRepository
    {
        public async Task AddMedicalOffice(MedicalOffice medicalOffice) 
        {         
            await _db.MedicalOffices.AddAsync(medicalOffice);
            await _db.SaveChangesAsync();
        
        }

        public async Task<IEnumerable<MedicalOffice>> GetAllMedicalOffice()
        {
            var medicalOffice = await _db.MedicalOffices.AsNoTracking().ToListAsync();
            return medicalOffice;
        }

        public async Task<MedicalOffice> GetMedicalOfficeById(int id)
        {
            var getMedicalOffice = await _db.MedicalOffices.FindAsync(id);
            return getMedicalOffice;
        }

        public async Task RemoveMedicalOffice(int id)
        {
            var remove = await GetMedicalOfficeById(id);
            _db.Remove(remove);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateMedicalOffice(MedicalOffice newMedicalOffice, int id)
        {
            var medicalOffice = await GetMedicalOfficeById(id);

            medicalOffice.DoorNumber = newMedicalOffice.DoorNumber == null ? medicalOffice.DoorNumber : newMedicalOffice.DoorNumber;
            medicalOffice.Floor = newMedicalOffice.Floor == null ? medicalOffice.Floor : medicalOffice.Floor;
            medicalOffice.Descripcion = newMedicalOffice.Descripcion == null ? medicalOffice.Descripcion : newMedicalOffice.Descripcion;

        }
    }
}
