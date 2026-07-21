using MedicalApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp.Application.Interfaces
{
    public interface IMedicineRepository
    {
        public Task<IEnumerable<Medicine>>GetAllMedicine();
        public Task<Medicine>GetMedicineById(int id);
        public Task UpdateMedicine(int id, Medicine medicine);
        public Task RemuveMedicine(int id);
        public Task AddMedicine(Medicine medicine);
    }
}
