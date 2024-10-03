using System;
using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public class Domicilios_DTO
    {
        [Key]
        public int Id_Domicilio { get; set; }

        [Required]
        [Display(Name = "Calle")]
        public string Calle { get; set; }

        [Required]
        [Display(Name = "Número Exterior")]
        public string NumeroExterior { get; set; }

        [Display(Name = "Número Interior")]
        public string NumeroInterior { get; set; }

        [Required]
        [Display(Name = "Ciudad")]
        public string Ciudad { get; set; }

        [Required]
        [Display(Name = "Código Postal")]
        public string CodigoPostal { get; set; }
    }
}
