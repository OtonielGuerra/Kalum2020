using System.IO;
using Kalum2020_v1.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Kalum2020_v1.DataContext
{
    public class KalumDB : DbContext
    {
        public KalumDB(DbContextOptions<KalumDB> options) : base(options)
        {
            
        }
        public DbSet<Alumno> Alumnos {get; set;}
        public DbSet<AsignacionAlumno> AsignacionAlumnos { get; set; }
        public DbSet<CarreraTecnica> CarrerasTecnicas { get; set; }
        public DbSet<Clase> Clases { get; set; }
        public DbSet<Horario> Horarios { get; set; }
        public DbSet<Instructor> Instructores { get; set; }
        public DbSet<Salon> Salones { get; set; }
        public DbSet<Rol> RolesApp { get; set; }
        public DbSet<Usuario> UsuariosApp { get; set; }
        public DbSet<UsuarioRol> UsuariosRoles { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json").Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }
        //Si tiene mas de una llave primaria
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsuarioRol>()
                .HasKey(x => new { x.UsuarioId, x.RoleId });
        }
        public KalumDB()
        {

        }
    }


}