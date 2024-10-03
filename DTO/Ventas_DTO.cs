using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public class Ventas_DTO
    {
        [Key]
        public int ID_Venta { get; set; }

        [Required]
        [Display(Name = "Total de la Venta")]
        public decimal Total { get; set; }

        [Required]
        [Display(Name = "ID del Empleado")]
        public int Empleado_ID { get; set; }

        [Required]
        [Display(Name = "ID del Status")]
        public int Status_ID { get; set; }

        [Required]
        [Display(Name = "Folio")]
        public string Folio { get; set; }

        [Display(Name = "Fecha de la Venta")]
        [DataType(DataType.Date)]
        public DateTime? Fecha_Venta { get; set; }

        [Display(Name = "Disponibilidad")]
        public bool? Disponibilidad { get; set; }

        [Display(Name = "Detalles de Venta")]
        public ICollection<DetalleVentas_DTO> DetalleVentas { get; set; }


    }
}
