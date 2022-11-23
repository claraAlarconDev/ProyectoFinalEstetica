using Microsoft.EntityFrameworkCore;

namespace ProyectoFinalEstetica.Models
{
	public class AgendaContext : DbContext
	{

		
        protected override void OnConfiguring(DbContextOptionsBuilder option)
        {

            if (!option.IsConfigured)
            {
                option.UseSqlServer("server=(localdb)\\MSSQLLocalDB;database=Turnos;Integrated Security=true");
            }
        }
        public DbSet<Turno> Turnos  { get; set; }
        public DbSet<Servicio> Servicios { get; set; }

        public DbSet<Contacto> Contactos { get; set; }

        public DbSet<Administrador> Administradores { get; set; }
    }
}
