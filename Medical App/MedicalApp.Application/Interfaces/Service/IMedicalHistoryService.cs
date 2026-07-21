using MedicalApp.Application.DTOs.MedicalHistoryDTOs;
using MedicalApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp.Application.Service
{
    public interface IMedicalHistoryService
    {
        public Task<IEnumerable<ReadMedicalHistoryDTOs>> GetMedicalHistoryById(int id);
        public Task<ReadMedicalHistoryDTOs> GetAllMedicalHistory();
        public Task RemuveMEdicalHistory(int id);
        public Task UpdateMedicalHistory(int id, CreateMedicalHistoryDTOs Medicalhistory);
        public Task AddMedicalHistory(CreateMedicalHistoryDTOs medicalhistory);
    }
}
