using System;
using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public class Roles_DTO
    {
        [Key]
        public int Id_Rol { get; set; }

        [Required]
        [Display(Name = "Nombre del Rol")]
        public string Nombre { get; set; }

        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }
    }
}
