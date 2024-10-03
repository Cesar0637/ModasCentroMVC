using System;
using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public class DetalleVentas_DTO
    {
        [Key]
        public int Id_DetalleVenta { get; set; }

        [Required]
        [Display(Name = "Venta")]
        public int VentaId { get; set; }

        [Required]
        [Display(Name = "Producto")]
        public int ProductoId { get; set; }

        [Required]
        [Display(Name = "Cantidad")]
        public int Cantidad { get; set; }

        [Required]
        [Display(Name = "Precio Unitario")]
        public decimal PrecioUnitario { get; set; }
    }
}
