using AppointmentsManager.Data.Models;
using Proiect_appointments.Models;
using Proiect_appointments.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proiect_appointments.Services
{
    public class AppointmentServices
    {
        private readonly IAppointmentRepository _repository;

        public AppointmentServices(IAppointmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Appointment>> GetAllAppointmentsAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Appointment> GetAppointmentByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAppointmentAsync(Appointment appointment)
        {
            await _repository.AddAsync(appointment);
        }

        public async Task UpdateAppointmentAsync(Appointment appointment)
        {
            await _repository.UpdateAsync(appointment);
        }

        public async Task DeleteAppointmentAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        // Aici poți adăuga alte metode specifice necesare aplicației tale
    }
}
