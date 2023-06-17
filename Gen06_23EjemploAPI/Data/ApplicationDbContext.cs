using Gen06_23EjemploAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Gen06_23EjemploAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<CAerolinea> Aerolineas { get; set; }

        public DbSet<Avion> Aviones { get; set; }
        public DbSet<Aeropuerto> Aeropuertos { get; set; }
    }
}