using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicalApp.Application.Interfaces.Repository;
using MedicalApp.Domain.Entities;
using MedicalApp.Infraestructure.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace MedicalApp.Infraestructure.Repositories
{
    public class DoctorRepository(MedicalAppDbContext _db) : IDoctorRepository
    {
        public async Task AddDoctor(Doctor doctor)
        {
            await _db.Doctors.AddAsync(doctor);
            await _db.SaveChangesAsync();
        }

        public async Task<Doctor> GetDoctorById(int id)
        {
            var findDoctor = await _db.Doctors.FindAsync(id); ;

            if (findDoctor is null)
            {
                return null!;
            }
            return findDoctor;
        }

        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            var doctors = await _db.Doctors.AsNoTracking().ToListAsync();
            return doctors;
        }

        public async Task RemoveDoctor(int id)
        {
            var findDoctor = await GetDoctorById(id);
            _db.Doctors.Remove(findDoctor);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateDoctor(Doctor Newdoctor, int id)
        {
            var doctor = await GetDoctorById(id);

            doctor.Name = Newdoctor.Name == null ? doctor.Name : Newdoctor.Name;
            doctor.LastName = Newdoctor.LastName;
            doctor.Active = Newdoctor.Active;
            doctor.Phone = Newdoctor.Phone;

            _db.Doctors.Update(doctor);

            await _db.SaveChangesAsync();
        }
    }
}