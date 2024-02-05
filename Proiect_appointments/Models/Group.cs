using Proiect_appointments.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AppointmentsManager.Data.Models
{
    public class Group
    {
        [Key]
        public int GroupId { get; set; }
        public string Name { get; set; }

        // Relație Many-to-Many cu User
        public virtual ICollection<UserGroup> UserGroups { get; set; }
    }
}
