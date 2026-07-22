using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DES_AR201154_RM220242_VM220243_Desafio1.Migrations
{
    /// <inheritdoc />
    public partial class Migracion_Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departamentos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamentos", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FechaNacimiento = table.Column<DateOnly>(type: "date", nullable: false),
                    FechaContratacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DepartamentoID = table.Column<int>(type: "int", nullable: false),
                    Salario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Empleados_Departamentos_DepartamentoID",
                        column: x => x.DepartamentoID,
                        principalTable: "Departamentos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Departamentos",
                columns: new[] { "ID", "Descripcion", "Nombre" },
                values: new object[,]
                {
                    { 1, "Gestiona el personal de la empresa.", "Recursos Humanos" },
                    { 2, "Desarrollo y mantenimiento de sistemas.", "Tecnología" },
                    { 3, "Encargado de la comercialización de productos.", "Ventas" }
                });

            migrationBuilder.InsertData(
                table: "Empleados",
                columns: new[] { "ID", "DepartamentoID", "Descripcion", "FechaContratacion", "FechaNacimiento", "Nombre", "Salario" },
                values: new object[,]
                {
                    { 1, 1, "Empleado con experiencia en RRHH.", new DateTime(2010, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1985, 5, 20), "John Doe", 50000m },
                    { 2, 2, "Desarrolladora de software senior.", new DateTime(2015, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1990, 3, 10), "Jane Smith", 70000m },
                    { 3, 3, "Especialista en ventas y marketing.", new DateTime(2012, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1982, 11, 22), "Mark Johnson", 55000m },
                    { 4, 1, "Gerente de Recursos Humanos.", new DateTime(2005, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1978, 7, 30), "Emily Davis", 75000m },
                    { 5, 2, "Ingeniero de soporte técnico.", new DateTime(2020, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1995, 12, 5), "Michael Brown", 60000m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_DepartamentoID",
                table: "Empleados",
                column: "DepartamentoID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Empleados");

            migrationBuilder.DropTable(
                name: "Departamentos");
        }
    }
}
