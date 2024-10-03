using System;
using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public class Productos_DTO
    {
        [Key]
        public int Id_Producto { get; set; }

        [Required]
        [Display(Name = "Nombre del Producto")]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Required]
        [Display(Name = "Precio")]
        public decimal Precio { get; set; }

        [Display(Name = "Stock Disponible")]
        public int Stock { get; set; }
    }
}
