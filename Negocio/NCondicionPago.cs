using Datos.BaseDatos.Modelos;
using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NCondicionPago
    {
        private DCondicionPago dvariable;

        public NCondicionPago()
        {
            dvariable = new DCondicionPago();
        }

        public List<CondicionPago> obtenerGrupos()
        {
            return dvariable.RegistrosTodos();
        }

        public int Agregar(CondicionPago agregar)
        {
            return dvariable.Guardar(agregar);
        }

        public int Editar(CondicionPago aceptar)
        {
            return dvariable.Guardar(aceptar);
        }

        public int EliminarRegistro(int registroId)
        {
            return dvariable.Eliminar(registroId);
        }

        public List<CondicionPago> RegistrosActivos()
        {
            return dvariable.RegistrosTodos().Where(c => c.Estado == true).ToList();
        }

        public List<CondicionPago> RegistrosInactivos()
        {
            return dvariable.RegistrosTodos().Where(c => c.Estado == false).ToList();
        }
    }
}
