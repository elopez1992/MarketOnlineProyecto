using Datos.BaseDatos.Modelos;
using Datos.BaseDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Datos.Core;

namespace Datos
{
    //Aqui esta implementado el patron repositorio
    public class DGrupoDescuentos
    {
        Repository<GrupoDescuento> _repository;

        public DGrupoDescuentos()
        {
            _repository = new Repository<GrupoDescuento>();
        }

        public int GrupoDescuentoId { get; set; }
        public string Codigo { get; set; }
        public string DescripcionGD { get; set; }
        public bool Estado { get; set; }
        public int Porcentaje { get; set; }
        public DateTime FechaCreacionGD { get; set; }

        public List<GrupoDescuento> GruposDescuentoTodas()
        {
            return _repository.Consulta().ToList();
        }

        public int GuardarGrupoDescuento(GrupoDescuento grupo)
        {
            if (grupo.GrupoDescuentoId == 0)
            {
                _repository.Agregar(grupo);
                return 1;
            }
            else
            {
                var GrupoDescuentoInDB = _repository.Consulta().FirstOrDefault(c => c.GrupoDescuentoId == grupo.GrupoDescuentoId);

                if (GrupoDescuentoInDB != null)
                {
                    GrupoDescuentoInDB.Codigo = grupo.Codigo;
                    GrupoDescuentoInDB.DescripcionGD = grupo.DescripcionGD;
                    GrupoDescuentoInDB.Estado = grupo.Estado;
                    GrupoDescuentoInDB.Porcentaje = grupo.Porcentaje;

                    _repository.Editar(GrupoDescuentoInDB);
                    return 1;
                }
                return 0;
            }
        }

        public int EliminarGrupoDescuento(int grupodescuentosID)
        {
            var GrupoDescuentoInDB = _repository.Consulta().FirstOrDefault(c => c.GrupoDescuentoId == grupodescuentosID);

            if (GrupoDescuentoInDB != null)
            {
                _repository.Eliminar(GrupoDescuentoInDB);
                return 1;
            }
            return 0;
        }
    }
}
