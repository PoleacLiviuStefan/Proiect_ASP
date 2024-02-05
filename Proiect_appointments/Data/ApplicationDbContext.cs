using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Duende.IdentityServer.EntityFramework.Options;
using AppointmentsManager.Data.Models;

namespace Proiect_appointments.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<User>
    // Folosim clasa User personalizată
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options,
            IOptions<OperationalStoreOptions> operationalStoreOptions)
            : base(options, operationalStoreOptions)
        {
        }

        // DbSet-uri pentru entitățile din modelul tău de date
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; } // Adaugă DbSet pentru UserProfile
        public DbSet<UserGroup> UserGroups { get; set; } // Adaugă DbSet pentru UserGroup
        public DbSet<Group> Groups { get; set; } // Presupunând că ai o entitate Group

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ... alte configurări ale modelului

            // Configurarea cheii primare compuse pentru UserGroup
            modelBuilder.Entity<UserGroup>()
                .HasKey(ug => new { ug.UserId, ug.GroupId }); // Definește cheia primară compusă

            // Configurarea relațiilor pentru UserGroup
            modelBuilder.Entity<UserGroup>()
                .HasOne(ug => ug.User)
                .WithMany(u => u.UserGroups)
                .HasForeignKey(ug => ug.UserId);

            modelBuilder.Entity<UserGroup>()
                .HasOne(ug => ug.Group)
                .WithMany(g => g.UserGroups)
                .HasForeignKey(ug => ug.GroupId);
        }
    }
}
