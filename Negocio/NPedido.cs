﻿using Datos.BaseDatos.Modelos;
using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NPedido
    {
        private DPedido dvariable;

        public NPedido()
        {
            dvariable = new DPedido();
        }

        public List<Pedido> obtener()
        {
            return dvariable.RegistrosTodos();
        }

        public int Agregar(Pedido agregar)
        {
            return dvariable.Guardar(agregar);
        }

        public int Editar(Pedido aceptar)
        {
            return dvariable.Guardar(aceptar);
        }

        public int EliminarRegistro(int registroId)
        {
            return dvariable.Eliminar(registroId);
        }

        public List<Pedido> RegistrosActivos()
        {
            return dvariable.RegistrosTodos().Where(c => c.Estado == true).ToList();
        }

        public List<Pedido> RegistrosInactivos()
        {
            return dvariable.RegistrosTodos().Where(c => c.Estado == false).ToList();
        }
    }
}
