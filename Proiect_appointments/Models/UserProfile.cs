using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AppointmentsManager.Data.Models;  // Înlocuiește cu namespace-ul corect al clasei User, dacă este diferit

namespace AppointmentsManager.Data.Models
{
    public class UserProfile
    {
        [Key]
        [ForeignKey("User")]
        public int UserId { get; set; }

        [MaxLength(100)]
        public string FirstName { get; set; }
        [MaxLength(100)]
        public string LastName { get; set; }
        // Alte proprietăți specifice profilului, cum ar fi adresa, telefonul, etc.

        public virtual User User { get; set; }
    }
}
