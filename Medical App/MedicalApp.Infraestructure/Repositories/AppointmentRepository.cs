using MedicalApp.Application.Interfaces.Repository;
using MedicalApp.Domain.Entities;
using MedicalApp.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace MedicalApp.Infraestructure.Repositories;

public class AppointmentRepository(MedicalAppDbContext _db) : IAppointmentRepository
{
    public async Task AddDAppointment(Appointment appointment)
    {
        await _db.Appointments.AddAsync(appointment);
        await _db.SaveChangesAsync();
    }

    public async Task<IEnumerable<Appointment>> GetAllAppointment()
    {
        var appointment = await _db.Appointments.AsNoTracking().ToListAsync();
        return appointment;
    }

    public async Task<Appointment> GetAppointmentById(int id)
    {
        var appointments = await _db.Appointments.FindAsync(id);
        return appointments;
    }

    public async Task RemoveAppointment(int id)
    {
        var remove = await GetAppointmentById(id);

        _db.Appointments.Remove(remove);
        await _db.SaveChangesAsync();
    }

    public async Task UpdateAppointment(int id, Appointment newAppointment)
    {
        var appointment = await GetAppointmentById(id);

        appointment.Date = newAppointment.Date == null ? appointment.Date : newAppointment.Date;
        appointment.Status = newAppointment.Status == null ? appointment.Status : newAppointment.Status;
        appointment.ReasonForVisit = newAppointment.ReasonForVisit == null ? appointment.ReasonForVisit : newAppointment.ReasonForVisit;
        appointment.Observations = newAppointment.Observations == null ? appointment.Observations : newAppointment.Observations;
        appointment.PatientId = newAppointment.PatientId == null ? appointment.PatientId : newAppointment.PatientId;
    }
}
