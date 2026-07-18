using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicalApp.Application.DTOs.MedicalOffice;
using MedicalApp.Application.Interfaces.Repository;
using MedicalApp.Application.Interfaces.Service;
using MedicalApp.Domain.Entities;

namespace MedicalApp.Application.Services
{
    public class MedicalOfficeService(IMedicalOfficeRepository repo) : IMedicalOfficeService
    {
        public async Task AddMedicalOffice(CreateMedicalOfficeDTO mOffice)
        {
            var medicalOffice = new MedicalOffice
            {
                DoorNumber = mOffice.DoorNumber,
                Floor = mOffice.Floor,
                Descripcion = mOffice.Descripcion
            };
            await repo.AddMedicalOffice(medicalOffice);

        }

        public async Task<IEnumerable<ReadMedicalOfficeDTO>> GetAllMedicalOffice()
        {
            var mOffices = await repo.GetAllMedicalOffice();
            return mOffices.Select(x => new ReadMedicalOfficeDTO
            {
                DoorNumber = x.DoorNumber,
                Floor = x.Floor,
                Descripcion = x.Descripcion
            });
        }

        public async Task<ReadMedicalOfficeDTO> GetMedicalOfficeById(int id)
        {
            var mOffice = await repo.GetMedicalOfficeById(id);
            var mOfficeDto = new ReadMedicalOfficeDTO
            {
                DoorNumber = mOffice.DoorNumber,
                Floor = mOffice.Floor,
                Descripcion = mOffice.Descripcion
            };

            return mOfficeDto;
        }

        public async Task RemoveMedicalOffice(int id)
        {
            await repo.RemoveMedicalOffice(id);
        }

        public async Task UpdateMedicalOffice(CreateMedicalOfficeDTO mOffice, int id)
        {
            var medicalOffice = new MedicalOffice
            {
                DoorNumber = mOffice.DoorNumber,
                Floor = mOffice.Floor,
                Descripcion = mOffice.Descripcion
            };
            await repo.UpdateMedicalOffice(medicalOffice, id);
        }
    }
}