using MedicalApp.Application.DTOs.MedicineDTOs;
using MedicalApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp.Application.Service
{
    public interface IMedicineService
    {
        public Task<IEnumerable<ReadMedicineDTO>> GetAllMedicine();
        public Task<ReadMedicineDTO> GetMedicineById(int id);
        public Task UpdateMedicine(CreateMedicineDTO medicine, int id);
        public Task RemuveMedicine(int id);
        public Task AddMedicine(CreateMedicineDTO medicine);
    }
}
