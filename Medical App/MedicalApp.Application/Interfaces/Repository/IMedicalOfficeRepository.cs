using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicalApp.Domain.Entities;

namespace MedicalApp.Application.Interfaces.Repository
{
    public interface IMedicalOfficeRepository
    {
        public Task<MedicalOffice> GetMedicalOfficeById(int id);
        public Task<IEnumerable<MedicalOffice>> GetAllMedicalOffice();
        public Task AddMedicalOffice(MedicalOffice medicalOffice);
        public Task RemoveMedicalOffice(int id);
        public Task UpdateMedicalOffice(MedicalOffice medicalOffice, int id);
    }
}