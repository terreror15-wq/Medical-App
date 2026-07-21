using MedicalApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp.Application.Interfaces
{
    public interface IDiagnosisRepository
    {
        public Task<Diagnosis>GetDiagnosisById(int id);
        public Task<IEnumerable<Diagnosis>>GetAllDiagnosis();
        public Task UpdateDiagnosis(int id, Diagnosis diagnosis);
        public Task RemuveDiagnosis(int id);
        public Task AddDiagnosis(Diagnosis diagnosis);
    }
}
