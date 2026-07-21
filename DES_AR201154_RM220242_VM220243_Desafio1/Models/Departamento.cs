using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DES_AR201154_RM220242_VM220243_Desafio1.Models
{
        public class Departamento
        {
            public int ID { get; set; }

            [Required(ErrorMessage = "Nombre del departamento requerido.")]
            [StringLength(100, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 100 caracteres.")]
            [Display(Name = "Nombre del departamento")]
            public string Nombre { get; set; } = string.Empty;

            [Display(Name = "Descripción")]
            public string? Descripcion { get; set; }

            public ICollection<Empleado> Empleado { get; set; } = new List<Empleado>();
        }
}
