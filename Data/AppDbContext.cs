// Data/AppDbContext.cs
using Microsoft.EntityFrameworkCore;
using VotreApplication.Models;

namespace VotreApplication.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options)
        {
        }

        // DbSets pour vos modèles
        public DbSet<Vol> Vols { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuration des relations
            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Client)
                .WithMany(c => c.Reservations)
                .HasForeignKey(r => r.ClientId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Vol)
                .WithMany(v => v.Reservations)
                .HasForeignKey(r => r.VolId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}