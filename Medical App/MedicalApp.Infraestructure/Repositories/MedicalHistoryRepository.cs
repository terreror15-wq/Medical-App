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
    public class MedicalHistoryRepository(MedicalAppDbContext _db) : IMedicalHistoryRepository
    {
        public async Task AddMedicalHistory(MedicalHistory medicalhistory)
        {
            await _db.AddAsync(medicalhistory);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<MedicalHistory>> GetAllMedicalHistory()
        {
            var allmedical = await _db.MedicalHistories.AsNoTracking().ToListAsync();
            return allmedical;

        }

        public async Task<MedicalHistory> GetMedicalHistoryById(int id)
        {
            var medic  = await _db.MedicalHistories.FindAsync(id);
            return medic;
        }

        public async Task RemuveMEdicalHistory(int id)
        {
            var medical = await GetMedicalHistoryById(id);
            _db.MedicalHistories.Remove(medical);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateMedicalHistory(int id, MedicalHistory NMedicalhistory)
        {
            var med = await GetMedicalHistoryById(id);

            med.Date = NMedicalhistory.Date == null ? med.Date : NMedicalhistory.Date;
            med.ReasonVisit = NMedicalhistory.ReasonVisit == null ? med.ReasonVisit : NMedicalhistory.ReasonVisit;
            med.Symptoms = NMedicalhistory.Symptoms == null ? med.Symptoms : NMedicalhistory.Symptoms;
            med.PacientId = NMedicalhistory.PacientId == null ? med.PacientId : NMedicalhistory.PacientId;
            med.DoctorId = NMedicalhistory.DoctorId == null ? med.DoctorId : NMedicalhistory.DoctorId;
            med.AppointmentId = NMedicalhistory.AppointmentId == null ? med.AppointmentId : NMedicalhistory.AppointmentId;
            med.Observations = NMedicalhistory.Observations == null ? med.Observations : NMedicalhistory.Observations;

             _db.MedicalHistories.Update(med);
            await _db.SaveChangesAsync();

        }

      
    }
}
