using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.BaseDatos.Modelos
{
    public class Producto
    {
        [Key]
        public int ProductoId { get; set; }

        [Required]
        [MaxLength(50)]
        public string DescripcionProducto { get; set; }

        //--------------------------------------------------
        public int CategoriaId { get; set; }
        public int UnidadMedidaId { get; set; }
        //--------------------------------------------------

        public DateTime FechaCreacion { get; set; }
        public bool Estado { get; set; }

        [Required]
        public decimal PrecioCompra { get; set; }


        //--------------------------------------------------
        public Categoria categoria { get; set; }
        public UnidadMedida unidadmedida { get; set; }
        //--------------------------------------------------
    }
}
