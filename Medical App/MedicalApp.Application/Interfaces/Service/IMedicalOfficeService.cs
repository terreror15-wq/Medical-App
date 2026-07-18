using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicalApp.Application.DTOs.MedicalOffice;
using MedicalApp.Domain.Entities;

namespace MedicalApp.Application.Interfaces.Service
{
    public interface IMedicalOfficeService
    {
        public Task<ReadMedicalOfficeDTO> GetMedicalOfficeById(int id);
        public Task<IEnumerable<ReadMedicalOfficeDTO>> GetAllMedicalOffice();
        public Task AddMedicalOffice(CreateMedicalOfficeDTO medicalOffice);
        public Task RemoveMedicalOffice(int id);
        public Task UpdateMedicalOffice(CreateMedicalOfficeDTO medicalOffice, int id);
    }
}