using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
namespace DES_AR201154_RM220242_VM220243_Desafio1.Models
{

    public class Empleado
        {
            public int ID { get; set; }

            [Required(ErrorMessage = "Nombre del empleado es requerido.")]
            [StringLength(100, MinimumLength = 2, ErrorMessage = "El nombre debe tener entre 2 y 100 caracteres.")]
            [Display(Name = "Nombre del empleado")]
            public string Nombre { get; set; } = string.Empty;

            [Required(ErrorMessage = "Campo requerido, no puede quedar vacío.")]
            [DataType(DataType.Date)]
            [Display(Name = "Fecha de nacimiento")]
            [CustomValidation(typeof(Empleado), nameof(ValidarFechaNacimiento), ErrorMessage = "La fecha de nacimiento no puede ser en el futuro.")]
            public DateOnly FechaNacimiento { get; set; }

            [Required(ErrorMessage = "Campo requerido, no puede quedar vacío.")]
            [DataType(DataType.Date)]
            [Display(Name = "Fecha de contratación")]
            [CustomValidation(typeof(Empleado), nameof(ValidarFechaContratacion), ErrorMessage = "La fecha de contratación no puede ser en el futuro.")]
            public DateTime FechaContratacion { get; set; }

            [Required(ErrorMessage = "El departamento es obligatorio.")]
            [ForeignKey(nameof(Departamento))]
            [Display(Name = "Departamento")]
            public int DepartamentoID { get; set; }

            [ValidateNever]
            public Departamento Departamento { get; set; } = null!;

            [Required(ErrorMessage = "El salario es obligatorio.")]
            [Range(typeof(decimal), "0.01", "999999999.99", ErrorMessage = "El salario no debe permitir valores negativos ni cero.")]
            [Column(TypeName = "decimal(18,2)")]
            [Display(Name = "Salario")]
            public decimal Salario { get; set; }

            [Display(Name = "Descripción")]
            public string? Descripcion { get; set; }

            public static ValidationResult? ValidarFechaNacimiento(DateOnly fechaNacimiento, ValidationContext context)
            {
                if (fechaNacimiento > DateOnly.FromDateTime(DateTime.Today))
                {
                    return new ValidationResult(
                        "La fecha de nacimiento no puede ser en el futuro.",
                        new[] { context.MemberName! });
                }

                return ValidationResult.Success;
            }

        public static ValidationResult? ValidarFechaContratacion(DateTime fechaContratacion, ValidationContext context)
        {
            if (fechaContratacion.Date > DateTime.Today)
            {
                return new ValidationResult(
                    "La fecha de contratación no puede ser en el futuro.",
                    new[] { context.MemberName! });
            }

            return ValidationResult.Success;
        }  
    }
}

