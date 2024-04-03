using Datos.BaseDatos.Modelos;
using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NUnidadMedida
    {
        private DUnidadMedida dvariable;

        public NUnidadMedida()
        {
            dvariable = new DUnidadMedida();
        }

        public List<UnidadMedida> obtenerGrupos()
        {
            return dvariable.RegistrosTodos();
        }

        public int Agregar(UnidadMedida agregar)
        {
            return dvariable.Guardar(agregar);
        }

        public int Editar(UnidadMedida aceptar)
        {
            return dvariable.Guardar(aceptar);
        }

        public int EliminarRegistro(int registroId)
        {
            return dvariable.Eliminar(registroId);
        }

        public List<UnidadMedida> RegistrosActivos()
        {
            return dvariable.RegistrosTodos().Where(c => c.Estado == true).ToList();
        }

        public List<UnidadMedida> RegistrosInactivos()
        {
            return dvariable.RegistrosTodos().Where(c => c.Estado == false).ToList();
        }
    }
}
