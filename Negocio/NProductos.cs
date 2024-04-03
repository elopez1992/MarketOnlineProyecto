using Datos.BaseDatos.Modelos;
using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NProductos
    {
        private DProductos dvariable;

        public NProductos()
        {
            dvariable = new DProductos();
        }

        public List<Producto> obtenerProductos()
        {
            return dvariable.RegistrosTodos();
        }

        public int Agregar(Producto agregar)
        {
            return dvariable.Guardar(agregar);
        }

        public int Editar(Producto aceptar)
        {
            return dvariable.Guardar(aceptar);
        }

        public int EliminarRegistro(int registroId)
        {
            return dvariable.Eliminar(registroId);
        }

        public List<Producto> RegistrosActivos()
        {
            return dvariable.RegistrosTodos().Where(c => c.Estado == true).ToList();
        }

        public List<Producto> RegistrosInactivos()
        {
            return dvariable.RegistrosTodos().Where(c => c.Estado == false).ToList();
        }
    }
}
