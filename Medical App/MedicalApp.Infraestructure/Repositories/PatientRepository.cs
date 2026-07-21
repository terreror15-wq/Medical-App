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
    internal class PatientRepository(MedicalAppDbContext _db) : IPatientRepository
    {
        public async Task AddPatient(Patient patient)
        {
            await _db.Patients.AddAsync(patient);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Patient>> GetAllPatient()
        {
            var allpatient = await _db.Patients.AsNoTracking().ToListAsync();

            return allpatient;
        }

        public async Task<Patient> GetPatientById(int id)
        {
            var patient = await _db.Patients.FindAsync(id);
            return patient;
        }

        public async Task RemovePatient(int id)
        {
            var patiendid = await GetPatientById(id);
            _db.Patients.Remove(patiendid);
            await _db.SaveChangesAsync();
        }

        public async Task UpdatePatient(Patient patient, int id)
        {
            var pat = await GetPatientById(id);

            pat.Name = patient.Name == null ? pat.Name : patient.Name;
            pat.LastName = patient.LastName == null ? pat.LastName : patient.LastName;
            pat.IdentityDocument = patient.IdentityDocument == null ? pat.IdentityDocument : patient.IdentityDocument;
            pat.Phone = patient.Phone == null ? pat.Phone : patient.Phone;
            pat.Email = patient.Email == null ? pat.Email : patient.Email;
            pat.Address = patient.Address == null ? pat.Address : patient.Address;
            pat.DateBirth = patient.DateBirth == null ? pat.DateBirth : patient.DateBirth;
            pat.DateRegister = patient.DateRegister == null ? pat.DateRegister : patient.DateRegister;
            pat.Active = patient.Active == null ? pat.Active : patient.Active;
            pat.Address = patient.Address == null ? pat.Address : patient.Address;
            
        }
    }
}
