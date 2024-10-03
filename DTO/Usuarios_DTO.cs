using System;
using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public class Usuarios_DTO
    {
        [Key]
        public int Id_Usuario { get; set; }

        [Required]
        [Display(Name = "Nombre de Usuario")]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Correo Electrónico")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Rol")]
        public int RolId { get; set; }
    }
}
