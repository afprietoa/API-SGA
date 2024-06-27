using API_SGA.Models;
using Microsoft.EntityFrameworkCore;

namespace API_SGA.Data
{
    public class AppDbContext: DbContext
    {
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Pollutant> Pollutants { get; set; }
        public DbSet<Measure> Measures { get; set; }
        public DbSet<Signal> Signals { get; set; }
        public DbSet<Emergency> Emergencies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Measure>()
            .HasKey(m => new { m.ResourceId, m.PollutantId });

            modelBuilder.Entity<Emergency>()
            .HasKey(e => new { e.ResourceId, e.PollutantId });

            modelBuilder.Entity<Signal>()
            .HasOne(l => l.Emergency);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=MonitoringDb;Username=postgres;Password=admin");
        }

        public void EnsureDatabaseCreated()
        {
            this.Database.EnsureDeleted(); // Eliminar la base de datos
            this.Database.EnsureCreated(); // Crear la base de datos
        }

    }
}
