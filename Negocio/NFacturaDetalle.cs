using Datos.BaseDatos.Modelos;
using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NFacturaDetalle
    {
        private DFacturaDetalles dvariable;

        public NFacturaDetalle()
        {
            dvariable = new DFacturaDetalles();
        }

        public List<FacturaDetalle> obtener()
        {
            return dvariable.RegistrosTodos();
        }

        public List<FacturaDetalle> RegistrosActivos()
        {
            return dvariable.RegistrosTodos().Where(c => c.factura.Estado == true).ToList();
        }

        public List<FacturaDetalle> RegistrosInactivos()
        {
            return dvariable.RegistrosTodos().Where(c => c.factura.Estado == false).ToList();
        }
        public int Agregar(FacturaDetalle agregar)
        {
            return dvariable.Guardar(agregar);
        }
    }
}
