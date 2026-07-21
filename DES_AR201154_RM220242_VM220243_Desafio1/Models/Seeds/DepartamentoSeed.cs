using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DES_AR201154_RM220242_VM220243_Desafio1.Models.Seeds
{
        public class DepartamentoSeed : IEntityTypeConfiguration<Departamento>
        {
            public void Configure(EntityTypeBuilder<Departamento> builder)
            {
                builder.HasData(
                    new Departamento
                    {
                        ID = 1,
                        Nombre = "Recursos Humanos",
                        Descripcion = "Gestiona el personal de la empresa."
                    },
                    new Departamento
                    {
                        ID = 2,
                        Nombre = "Tecnología",
                        Descripcion = "Desarrollo y mantenimiento de sistemas."
                    },
                    new Departamento
                    {
                        ID = 3,
                        Nombre = "Ventas",
                        Descripcion = "Encargado de la comercialización de productos."
                    }
                );
            }
        }
}