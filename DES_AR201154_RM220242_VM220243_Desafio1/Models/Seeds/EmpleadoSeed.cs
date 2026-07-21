using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DES_AR201154_RM220242_VM220243_Desafio1.Models.Seeds
{
    public class EmpleadoSeed : IEntityTypeConfiguration<Empleado>
    {
        public void Configure(EntityTypeBuilder<Empleado> builder)
        {
            builder.HasData(
                new Empleado
                {
                    ID = 1,
                    Nombre = "John Doe",
                    DepartamentoID = 1,
                    FechaNacimiento = new DateOnly(1985, 5, 20),
                    FechaContratacion = new DateTime(2010, 8, 15),
                    Salario = 50000m,
                    Descripcion = "Empleado con experiencia en RRHH."
                },
                new Empleado
                {
                    ID = 2,
                    Nombre = "Jane Smith",
                    DepartamentoID = 2,
                    FechaNacimiento = new DateOnly(1990, 3, 10),
                    FechaContratacion = new DateTime(2015, 1, 25),
                    Salario = 70000m,
                    Descripcion = "Desarrolladora de software senior."
                },
                new Empleado
                {
                    ID = 3,
                    Nombre = "Mark Johnson",
                    DepartamentoID = 3,
                    FechaNacimiento = new DateOnly(1982, 11, 22),
                    FechaContratacion = new DateTime(2012, 6, 18),
                    Salario = 55000m,
                    Descripcion = "Especialista en ventas y marketing."
                },
                new Empleado
                {
                    ID = 4,
                    Nombre = "Emily Davis",
                    DepartamentoID = 1,
                    FechaNacimiento = new DateOnly(1978, 7, 30),
                    FechaContratacion = new DateTime(2005, 10, 12),
                    Salario = 75000m,
                    Descripcion = "Gerente de Recursos Humanos."
                },
                new Empleado
                {
                    ID = 5,
                    Nombre = "Michael Brown",
                    DepartamentoID = 2,
                    FechaNacimiento = new DateOnly(1995, 12, 5),
                    FechaContratacion = new DateTime(2020, 4, 15),
                    Salario = 60000m,
                    Descripcion = "Ingeniero de soporte técnico."
                }
            );
        }
    }

}