using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicalApp.Application.DTOs.MedicineDTOs;
using MedicalApp.Application.Interfaces;
using MedicalApp.Application.Service;
using MedicalApp.Domain.Entities;

namespace MedicalApp.Application.Services
{
    public class MedicineService(IMedicineRepository repo) : IMedicineService
    {
        public async Task AddMedicine(CreateMedicineDTO medicine)
        {
            var Nmedicine = new Medicine
            {
                Name = medicine.Name,
                concetration = medicine.concetration,
                Laboratory = medicine.Laboratory
            };

            await repo.AddMedicine(Nmedicine);
        }

        public async Task<IEnumerable<ReadMedicineDTO>> GetAllMedicine()
        {
            var medications = await repo.GetAllMedicine();

            return medications.Select(medicine => new ReadMedicineDTO
            {
                Name = medicine.Name,
                concetration = medicine.concetration,
                Laboratory = medicine.Laboratory
            });
        }

        public async Task<ReadMedicineDTO> GetMedicineById(int id)
        {
            var medicine = await repo.GetMedicineById(id);
            var Nmedicine = new ReadMedicineDTO
            {
                Name = medicine.Name,
                concetration = medicine.concetration,
                Laboratory = medicine.Laboratory
            };

            return Nmedicine;
        }

        public async Task RemuveMedicine(int id)
        {
            await repo.RemuveMedicine(id);
        }

        public async Task UpdateMedicine(CreateMedicineDTO medicine, int id)
        {
             var Nmedicine = new Medicine
            {
                Name = medicine.Name,
                concetration = medicine.concetration,
                Laboratory = medicine.Laboratory
            };

            await repo.UpdateMedicine(id, Nmedicine);
        }
    }
}