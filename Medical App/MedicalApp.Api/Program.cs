using MedicalApp.Application.Interfaces;
using MedicalApp.Application.Interfaces.Repository;
using MedicalApp.Application.Interfaces.Service;
using MedicalApp.Application.Service;
using MedicalApp.Application.Services;
using MedicalApp.Domain.Entities;
using MedicalApp.Domain.Interfaces.Services;
using MedicalApp.Infraestructure.Data;
using MedicalApp.Infraestructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var MyConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<MedicalAppDbContext>(options =>
{
    options.UseNpgsql(MyConnectionString);
});


const string FrontendCorsPolicy = "FrontendCorsPolicy";

builder.Services.AddCors(options =>
{
    options.AddPolicy(FrontendCorsPolicy, policy =>
    {
        policy
            .WithOrigins(
                "http://localhost:5173",
                "http://127.0.0.1:5173"
            )
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});



builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
builder.Services.AddScoped<IDoctorService, DoctorService>();


builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<IPatientService, PatientService>();

builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();


builder.Services.AddScoped<IDiagnosisRepository, DiagnosisRepository>();
builder.Services.AddScoped<IDiagnosisServcice, DiagnosisService>();


builder.Services.AddScoped<IMedicalHistoryRepository, MedicalHistoryRepository>();
builder.Services.AddScoped<IMedicalHistoryService, MedicalHistoryService>();


builder.Services.AddScoped<IMedicalOfficeRepository, MedicalOfficeRepository>();
builder.Services.AddScoped<IMedicalOfficeService, MedicalOfficeService>();


builder.Services.AddScoped<IMedicineRepository, MedicineRepository>();
builder.Services.AddScoped<IMedicineService, MedicineService>();


builder.Services.AddScoped<IRecipeRepository, RecipeRepository>();
builder.Services.AddScoped<IRecipeService, RecipeService>();


builder.Services.AddScoped<IRecipeDetailRepository, RecibeDetailRepository>();
builder.Services.AddScoped<IRecipeDetailService, RecipeDetailService>();


builder.Services.AddScoped<ISpecialyRepository, SpecialyRepository>();
builder.Services.AddScoped<ISpecialyService, SpecialyService>();

builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseCors(FrontendCorsPolicy);

app.MapSwagger();
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();


app.Run();
