using MedicalApp.Application.DTOs.MedicalHistoryDTOs;
using MedicalApp.Application.DTOs.MedicineDTOs;
using MedicalApp.Application.Interfaces;
using MedicalApp.Application.Service;
using MedicalApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp.Application.Services
{
    public class MedicalHistoryService(IMedicalHistoryRepository repo) : IMedicalHistoryService
    {
        public async Task AddMedicalHistory(CreateMedicalHistoryDTOs medicalhistory)
        {
            var addmedicalhistory = new MedicalHistory
            {
                Date = medicalhistory.Date,
                ReasonVisit = medicalhistory.ReasonVisit,
                Symptoms = medicalhistory.Symptoms,
                Observations = medicalhistory.Observations,
                PacientId = medicalhistory.PacientId,
                AppointmentId = medicalhistory.AppointmentId

            };
            await repo.AddMedicalHistory(addmedicalhistory);
            
            
        }

        public async Task<IEnumerable<ReadMedicalHistoryDTOs>>GetAllMedicalHistory()
        {
            var gettingallmedical = await repo.GetAllMedicalHistory();

            var gettingmedical = gettingallmedical.Select(x => new ReadMedicalHistoryDTOs
            {
                Date = x.Date,
                ReasonVisit = x.ReasonVisit,
                Symptoms = x.Symptoms,
                Observations = x.Observations,
                DoctorId = x.DoctorId

            });
            return gettingmedical;

            
            
        }

        public async Task<ReadMedicalHistoryDTOs>GetMedicalHistoryById(int id)
        {
            var nmedical = await repo.GetMedicalHistoryById(id);

            var medicalDTO = new ReadMedicalHistoryDTOs
            {
                Date = nmedical.Date,
                ReasonVisit = nmedical.ReasonVisit,
                Symptoms = nmedical.Symptoms,
                Observations = nmedical.Observations,
                DoctorId = nmedical.DoctorId
            };
            return medicalDTO;
        }

        public async Task RemuveMEdicalHistory(int id)
        {
            await repo.RemuveMEdicalHistory(id);
        }

        public async Task UpdateMedicalHistory(int id, CreateMedicalHistoryDTOs medicalhistory)
        {
            var umedical = new MedicalHistory
            {
                Date = medicalhistory.Date,
                ReasonVisit = medicalhistory.ReasonVisit,
                Symptoms = medicalhistory.Symptoms,
                Observations = medicalhistory.Observations,
                PacientId = medicalhistory.PacientId,
                DoctorId = medicalhistory.DoctorId,
                AppointmentId = medicalhistory.AppointmentId
            };
            await repo.UpdateMedicalHistory(id, umedical);
            
        }
    }
}
