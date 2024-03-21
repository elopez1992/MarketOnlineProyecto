using Datos.BaseDatos.Modelos;
using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NGrupoDescuentos
    {
        private DGrupoDescuentos dGrupo;

        public NGrupoDescuentos()
        {
            dGrupo = new DGrupoDescuentos();
        }

        public List<GrupoDescuento> obtenerGrupos()
        {
            return dGrupo.GruposDescuentoTodas();
        }

        public List<GrupoDescuento> obtenerGruposGrid()
        {
            var Prodcuto = dGrupo.GruposDescuentoTodas().Select(c => new { c.GrupoDescuentoId, c.Codigo, c.DescripcionGD, c.Estado, c.Porcentaje, c.FechaCreacionGD });
            return dGrupo.GruposDescuentoTodas().ToList();
        }

        public int Agregar(GrupoDescuento grupo)
        {
            return dGrupo.GuardarGrupoDescuento(grupo);
        }

        public int EditarGrupoDescuento(GrupoDescuento grupo)
        {
            return dGrupo.GuardarGrupoDescuento(grupo);
        }

        public int EliminarGrupoDescuento(int grupodescuentoID)
        {
            return dGrupo.EliminarGrupoDescuento(grupodescuentoID);
        }

        public List<GrupoDescuento> GrupoDescuentoActivas()
        {
            return dGrupo.GruposDescuentoTodas().Where(c => c.Estado == true).ToList();
        }

        public List<GrupoDescuento> GrupoDescuentoInactivas()
        {
            return dGrupo.GruposDescuentoTodas().Where(c => c.Estado == false).ToList();
        }
    }
}
