using MedicalApp.Application.DTOs.DiagnosisDTOs;
using MedicalApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp.Application.Service
{
    public interface IDiagnosisServcice
    {
        public Task<ReadDiagnosisDTOs> GetDiagnosisById(int id);
        public Task<IEnumerable<ReadDiagnosisDTOs>> GetAllDiagnosis();
        public Task UpdateDiagnosis(int id, CreateDiagnosisDTOs diagnosis);
        public Task RemuveDiagnosis(int id);
        public Task AddDiagnosis(CreateDiagnosisDTOs diagnosis);
    }
}
