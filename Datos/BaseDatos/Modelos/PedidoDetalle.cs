using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.BaseDatos.Modelos
{
    public class PedidoDetalle
    {
        [Key]
        public int PedidoDetalleId { get; set; }
        //---------------------------------------------
        [Required]
        public int PedidoId { get; set; }
        public Pedido pedido { get; set; }
        //----------------------------------------------
        public DateTime FechaCreacion { get; set; }

        //----------------------------------------------
        public int ProductoId { get; set; }
        public Producto producto { get; set; }
        //-----------------------------------------------
        public decimal Precio { get; set; }
        public decimal Total { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Descuento { get; set; }


    }
}
