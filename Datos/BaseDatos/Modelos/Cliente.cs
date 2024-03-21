using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.BaseDatos.Modelos
{
    public class Cliente
    {
        [Key]
        public int ClienteId { get; set; }

        [Required]
        [MaxLength(15)]
        public string Codigo { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nombres { get; set; }

        [Required]
        [MaxLength(50)]
        public string Apellidos { get; set; }

        //----------------------------------------
        public int GrupoDescuentoId { get; set; }
        public int CondicionPagoId { get; set; }
        //----------------------------------------

        public bool Estado { get; set; }

        [Required]
        public DateTime FechaCreacion { get; set; }


        //--------------------------------------------------
        public GrupoDescuento grupodescuento { get; set; }
        public CondicionPago condionpago { get; set; }
        //--------------------------------------------------
    }
}
