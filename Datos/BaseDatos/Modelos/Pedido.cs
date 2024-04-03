using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.BaseDatos.Modelos
{
    public class Pedido
    {
        [Key]
        public int PedidoId { get; set; }

        [Required]
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaPedido { get; set; }
        public bool Estado { get; set; }
        public decimal Total {  get; set; }
        public decimal SubTotal { get; set; }
        public decimal Descuento { get;set; }
    }
}
