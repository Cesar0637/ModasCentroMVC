//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ModasCentroMVC
{
    using System;
    using System.Collections.Generic;
    
    public partial class DetalleVentas
    {
        public int ID_Detalle_Venta { get; set; }
        public Nullable<int> Venta_ID { get; set; }
        public int Producto_ID { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio_Unitario { get; set; }
        public decimal SubTotal { get; set; }
        public Nullable<bool> disponibilidad { get; set; }
    
        public virtual Productos Productos { get; set; }
        public virtual Ventas Ventas { get; set; }
    }
}
