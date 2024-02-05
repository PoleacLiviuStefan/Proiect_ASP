using AppointmentsManager.Data.Models;
using Proiect_appointments.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proiect_appointments.Repositories
{
    public interface IAppointmentRepository
    {
        Task<IEnumerable<Appointment>> GetAllAsync();
        Task<Appointment> GetByIdAsync(int id);
        Task AddAsync(Appointment appointment);
        Task UpdateAsync(Appointment appointment);
        Task DeleteAsync(int id);
        // Alte metode specifice cum ar fi metodele pentru căutare sau filtrare
    }
}
