using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace AppointmentsManager.Data.Models
{
    public class User : IdentityUser
    {
        // Consideră utilizarea unui sistem de roluri mai robust dacă este necesar
        public string Role { get; set; } = "User"; // Rolurile pot fi "Admin", "User", etc.

        // Relație One-to-Many cu Appointments
        public virtual ICollection<Appointment> Appointments { get; set; }

        // Alte atribute necesare, cum ar fi data creării contului, statusul contului, etc.
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;

        // Proprietatea de navigare pentru UserProfile
        public virtual UserProfile UserProfile { get; set; }

        public virtual ICollection<UserGroup> UserGroups { get; set; }

        // Constructor pentru inițializarea colecțiilor
        public User()
        {
            Appointments = new HashSet<Appointment>();
            UserGroups = new HashSet<UserGroup>();
        }
    }
}
