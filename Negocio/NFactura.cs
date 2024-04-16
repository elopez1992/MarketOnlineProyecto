using Datos;
using Datos.BaseDatos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NFactura
    {
        private DFactura dvariable;

        public NFactura()
        {
            dvariable = new DFactura();
        }

        public List<Factura> obtener()
        {
            return dvariable.RegistrosTodos();
        }

        public List<Factura> RegistrosActivos()
        {
            return dvariable.RegistrosTodos().Where(c => c.Estado == true).ToList();
        }

        public List<Factura> RegistrosInactivos()
        {
            return dvariable.RegistrosTodos().Where(c => c.Estado == false).ToList();
        }
        public int Agregar(Factura agregar)
        {
            return dvariable.Guardar(agregar);
        }
    }
}
