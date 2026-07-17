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
        public Task<IEnumerable<Medicine>> GetAllMedicine();
        public Task<Medicine> GetMedicineById(int id);
        public Task<Medicine> UpdateMedicine(int id, Medicine medicine);
        public Task<Medicine> RemuveMedicine(int id);
        public Task<Medicine> AddMedicine(Medicine medicine);
    }
}
