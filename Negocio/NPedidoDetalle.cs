using Datos.BaseDatos.Modelos;
using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NPedidoDetalle
    {
        private DPedidoDetalle dvariable;

        public NPedidoDetalle()
        {
            dvariable = new DPedidoDetalle();
        }

        public List<PedidoDetalle> obtener()
        {
            return dvariable.RegistrosTodos();
        }

        public int Agregar(PedidoDetalle agregar)
        {
            return dvariable.Guardar(agregar);
        }

        public int Editar(PedidoDetalle aceptar)
        {
            return dvariable.Guardar(aceptar);
        }

        public int EliminarRegistro(int registroId)
        {
            return dvariable.Eliminar(registroId);
        }

        public List<PedidoDetalle> RegistrosActivos()
        {
            return dvariable.RegistrosTodos().Where(c => c.pedido.Estado == true).ToList();
        }

        public List<PedidoDetalle> RegistrosInactivos()
        {
            return dvariable.RegistrosTodos().Where(c => c.pedido.Estado == false).ToList();
        }
    }
}
