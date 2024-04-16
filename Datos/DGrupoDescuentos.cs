using Datos.BaseDatos.Modelos;
using Datos.BaseDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Datos.Core;
using System.Data.Entity;

namespace Datos
{
    //Aqui esta implementado el patron repositorio
    public class DGrupoDescuentos
    {
        //Repository<GrupoDescuento> _repository;
        UnitOfWork _unitOfWork;

        public DGrupoDescuentos()
        {
            //_repository = new Repository<GrupoDescuento>();
            _unitOfWork = new UnitOfWork();
        }

        public int GrupoDescuentoId { get; set; }
        public string Codigo { get; set; }
        public string DescripcionGD { get; set; }
        public bool Estado { get; set; }
        public int Porcentaje { get; set; }
        public DateTime FechaCreacionGD { get; set; }

        public List<GrupoDescuento> GruposDescuentoTodas()
        {
            //return _repository.Consulta().ToList();
            return _unitOfWork.Repository<GrupoDescuento>().Consulta().ToList();
        }

        public int GuardarGrupoDescuento(GrupoDescuento grupo)
        {
            if (grupo.GrupoDescuentoId == 0)
            {
                //_repository.Agregar(grupo);
                //return 1;
                _unitOfWork.Repository<GrupoDescuento>().Agregar(grupo);
                return _unitOfWork.Guardar();
            }
            else
            {
                var ActualizarInDB = _unitOfWork.Repository<GrupoDescuento>().Consulta().FirstOrDefault(c => c.GrupoDescuentoId == grupo.GrupoDescuentoId);

                if (ActualizarInDB != null)
                {
                    ActualizarInDB.Codigo = grupo.Codigo;
                    ActualizarInDB.DescripcionGD = grupo.DescripcionGD;
                    ActualizarInDB.Estado = grupo.Estado;
                    ActualizarInDB.Porcentaje = grupo.Porcentaje;

                    //_repository.Editar(GrupoDescuentoInDB);
                    //return 1;

                    _unitOfWork.Repository<GrupoDescuento>().Editar(ActualizarInDB);
                    return _unitOfWork.Guardar();
                }
                return 0;
            }
        }

        public int EliminarGrupoDescuento(int EliminarPorID)
        {
            var registroInDb = _unitOfWork.Repository<GrupoDescuento>().Consulta().FirstOrDefault(c => c.GrupoDescuentoId == EliminarPorID);
            if (registroInDb != null)
            {
                _unitOfWork.Repository<GrupoDescuento>().Eliminar(registroInDb);
                return _unitOfWork.Guardar();
            }
            return 0;
        }
    }
    
}
