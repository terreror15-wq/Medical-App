using MedicalApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MedicalApp.Application.Interfaces
{
    public interface IMedicalHistoryRepository
    {
        public Task<IEnumerable<MedicalHistory>>GetMedicalHistoryById(int id);
        public Task<MedicalHistory>GetAllMedicalHistory();
        public Task<MedicalHistory>RemuveMEdicalHistory(int id);
        public Task<MedicalHistory>UpdateMedicalHistory(int id, MedicalHistory Medicalhistory);
        public Task<MedicalHistory> AddMedicalHistory(MedicalHistory medicalhistory);
    }
}
