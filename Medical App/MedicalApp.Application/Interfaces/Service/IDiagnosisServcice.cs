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
        public Task<Diagnosis> GetDiagnosisById(int id);
        public Task<IEnumerable<Diagnosis>> GetAllDiagnosis();
        public Task<Diagnosis> UpdateDiagnosis(int id, Diagnosis diagnosis);
        public Task<Diagnosis> RemuveDiagnosis(int id);
        public Task<Diagnosis> AddDiagnosis(Diagnosis diagnosis);
    }
}
