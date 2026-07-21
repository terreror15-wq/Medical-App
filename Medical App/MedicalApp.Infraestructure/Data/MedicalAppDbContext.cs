using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicalApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedicalApp.Infraestructure.Data
{
    public class MedicalAppDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RecipeDetail> RecipeDetails { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Diagnosis> Diagnoses { get; set; }
        public DbSet<MedicalHistory> MedicalHistories { get; set; }
        public DbSet<MedicalOffice> MedicalOffices { get; set; }
        public DbSet<Specialy> Specialies { get; set; }
    }
}