using MedicalApp.Application.Interfaces.Repository;
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
    public class DoctorRepository(MedicalAppDbContext _db) : IDoctorRepository
    {
        public async Task AddDoctor(Doctor doctor)
        {
            await _db.Doctors.AddAsync(doctor);
            await _db.SaveChangesAsync();
        }

        public async Task<Doctor> GetDoctorById(int id)
        {
            var doctor = await  _db.Doctors.FindAsync(id);

            return doctor;
            
        }

        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            var alldoc = await _db.Doctors.AsNoTracking().ToListAsync();
            return alldoc;
        }

        public async Task RemoveDoctor(int id)
        {
            var getdoc = await GetDoctorById(id);
            _db.Doctors.Remove(getdoc);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateDoctor(Doctor Newdoctor, int id)
        {
            var doctor = await GetDoctorById(id);

            doctor.Name = Newdoctor.Name == null ? doctor.Name : Newdoctor.Name;
            doctor.LastName = Newdoctor.LastName == null ? doctor.LastName : Newdoctor.LastName;
            doctor.Email = Newdoctor.Email == null ? doctor.Email : Newdoctor.Email;
            doctor.RegistrationNumber = Newdoctor.RegistrationNumber == null ? doctor.RegistrationNumber : Newdoctor.RegistrationNumber;
            doctor.Active = Newdoctor.Active == null ? doctor.Active : Newdoctor.Active;
            doctor.SpecialyId = Newdoctor.SpecialyId == null ? doctor.SpecialyId : Newdoctor.SpecialyId;
            doctor.Phone = Newdoctor.Phone == null ? doctor.Phone : Newdoctor.Phone;

            _db.Doctors.Update(doctor);
            await _db.SaveChangesAsync();
        }
    }
}
