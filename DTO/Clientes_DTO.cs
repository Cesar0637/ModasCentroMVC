using System;
using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public class Clientes_DTO
    {
        [Key]
        public int Id_Cliente { get; set; }

        [Required]
        [Display(Name = "Nombre Completo")]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Correo Electrónico")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Teléfono")]
        [Phone]
        public string Telefono { get; set; }
    }
}

