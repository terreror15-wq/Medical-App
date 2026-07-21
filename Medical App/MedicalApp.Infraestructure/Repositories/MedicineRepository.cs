using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicalApp.Application.Interfaces;
using MedicalApp.Domain.Entities;
using MedicalApp.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace MedicalApp.Infraestructure.Repositories
{
    public class MedicineRepository(MedicalAppDbContext _db) : IMedicineRepository
    {
        public async Task AddMedicine(Medicine medicine)
        {
            await _db.Medicines.AddAsync(medicine);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Medicine>> GetAllMedicine()
        {
            var medicines = await _db.Medicines.AsNoTracking().ToListAsync();
            return medicines;
        }

        public async Task<Medicine> GetMedicineById(int id)
        {
            var medicine = await _db.Medicines.FindAsync(id);
            if (medicine is null)
            {
                return null!;
            }

            return medicine;
        }

        public async Task RemuveMedicine(int id)
        {
            var medicine = await GetMedicineById(id);
            _db.Medicines.Remove(medicine);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateMedicine(int id, Medicine newMedicine)
        {
            var medicine = await GetMedicineById(id);

            medicine.Name = newMedicine.Name;
            medicine.Laboratory = newMedicine.Laboratory;
            medicine.Presentation = newMedicine.Presentation;

            _db.Medicines.Update(medicine);

            await _db.SaveChangesAsync();
        }
    }
}