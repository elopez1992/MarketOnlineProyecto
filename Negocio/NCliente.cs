using Datos.BaseDatos.Modelos;
using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NCliente
    {
        private DClientes dvariable;

        public NCliente()
        {
            dvariable = new DClientes();
        }

        public List<Cliente> obtenerClientes()
        {
            return dvariable.RegistrosTodos();
        }

        public int Agregar(Cliente agregar)
        {
            return dvariable.Guardar(agregar);
        }

        public int Editar(Cliente aceptar)
        {
            return dvariable.Guardar(aceptar);
        }

        public int EliminarRegistro(int registroId)
        {
            return dvariable.Eliminar(registroId);
        }

        public List<Cliente> RegistrosActivos()
        {
            return dvariable.RegistrosTodos().Where(c => c.Estado == true).ToList();
        }

        public List<Cliente> RegistrosInactivos()
        {
            return dvariable.RegistrosTodos().Where(c => c.Estado == false).ToList();
        }
    }
}
