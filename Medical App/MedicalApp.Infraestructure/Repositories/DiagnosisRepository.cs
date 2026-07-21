using MedicalApp.Application.Interfaces;
using MedicalApp.Domain.Entities;
using MedicalApp.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp.Infraestructure.Repositories
{
    public class DiagnosisRepository(MedicalAppDbContext _db) : IDiagnosisRepository
    {
        public async Task AddDiagnosis(Diagnosis diagnosis)
        {
            await _db.AddAsync(diagnosis);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Diagnosis>> GetAllDiagnosis()
        {
            var alldiagnosis = await _db.Diagnosis.AsNoTracking().ToListAsync();
            return alldiagnosis;
        }

        public async Task<Diagnosis> GetDiagnosisById(int id)
        {
            var diagnosisbyid = await _db.Diagnosis.FindAsync(id);
            return diagnosisbyid;
        }

        public async Task RemuveDiagnosis(int id)
        {
            var rdeg = await GetDiagnosisById(id);
            _db.Diagnosis.Remove(rdeg);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateDiagnosis(int id, Diagnosis diagnosis)
        {
            var ndiagnosis = await GetDiagnosisById(id);

            ndiagnosis.CodeCIE = diagnosis.CodeCIE == null ? ndiagnosis.CodeCIE : diagnosis.CodeCIE;
            ndiagnosis.Description = diagnosis.Description == null ? ndiagnosis.Description : diagnosis.Description;
            ndiagnosis.Date = diagnosis.Date == null ? ndiagnosis.Date : diagnosis.Date;
        }
    }
}
