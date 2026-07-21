using DES_AR201154_RM220242_VM220243_Desafio1.Models;
using DES_AR201154_RM220242_VM220243_Desafio1.Models.Seeds;
using Microsoft.EntityFrameworkCore;
public class DBContext : DbContext
{
        public DBContext(DbContextOptions<DBContext> options):base(options){

        }

        public DbSet<Departamento> Departamentos { get; set; }

        public DbSet<Empleado> Empleados { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Departamento>()
                .HasMany(d => d.Empleado)
                .WithOne(e => e.Departamento)
                .HasForeignKey(e => e.DepartamentoID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.ApplyConfiguration(new DepartamentoSeed());
            modelBuilder.ApplyConfiguration(new EmpleadoSeed());
        }
}
