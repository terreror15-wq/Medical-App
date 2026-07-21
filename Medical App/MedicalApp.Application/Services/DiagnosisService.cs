using MedicalApp.Application.DTOs.DiagnosisDTOs;
using MedicalApp.Application.Interfaces;
using MedicalApp.Application.Service;
using MedicalApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp.Application.Services
{
    public class DiagnosisService(IDiagnosisRepository repo) : IDiagnosisServcice
    {
        public async Task AddDiagnosis(CreateDiagnosisDTOs diagnosis)
        {
            var ndiagnosos = new Diagnosis
            {
                Date = diagnosis.Date,
                CodeCIE = diagnosis.CodeCIE,
                Description = diagnosis.Description
            };
            await repo.AddDiagnosis(ndiagnosos);
            
        }

        public async Task<IEnumerable<ReadDiagnosisDTOs>> GetAllDiagnosis()
        {
            var gettingall = await repo.GetAllDiagnosis();

            var diagnosis = gettingall.Select(x => new ReadDiagnosisDTOs
            {
                Date = x.Date,
                Description = x.Description,
                CodeCIE = x.CodeCIE
            });
            return diagnosis;
        }

        public async Task<ReadDiagnosisDTOs> GetDiagnosisById(int id)
        {
            var getdiagnosis = await repo.GetDiagnosisById(id);

            var diagnosis = new ReadDiagnosisDTOs
            {
                Date = getdiagnosis.Date,
                Description = getdiagnosis.Description,
                CodeCIE = getdiagnosis.CodeCIE
            };
            return diagnosis;
        }

        public async Task RemuveDiagnosis(int id)
        {
            await repo.RemuveDiagnosis(id);
        }

        public async Task UpdateDiagnosis(int id, CreateDiagnosisDTOs diagnosis)
        {
            var udiagnosis = new Diagnosis
            {
                Date = diagnosis.Date,
                CodeCIE = diagnosis.CodeCIE,
                Description = diagnosis.Description
            };
            await repo.UpdateDiagnosis(id, udiagnosis);
        }
    }
}
