using Datos.BaseDatos.Modelos;
using Datos.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DUnidadMedida
    {
        //Repository<UnidadMedida> _repository;
        UnitOfWork _unitOfWork;

        public DUnidadMedida()
        {
            //_repository = new Repository<UnidadMedida>();
            _unitOfWork = new UnitOfWork();

        }

        public int UnidadMedidaId { get; set; }
        public string Codigo { get; set; }
        public string DescripcionUM { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaCreacionUM { get; set; }

        public List<UnidadMedida> RegistrosTodos()
        {
            //return _repository.Consulta().ToList();

            return _unitOfWork.Repository<UnidadMedida>().Consulta().ToList();
        }

        public int Guardar(UnidadMedida guardar)
        {
            if (guardar.UnidadMedidaId == 0)
            {
                //_repository.Agregar(guardar);
                //return 1;

                _unitOfWork.Repository<UnidadMedida>().Agregar(guardar);
                return _unitOfWork.Guardar();
            }
            else
            {
                //var ActualizarInDB = _repository.Consulta().FirstOrDefault(c => c.UnidadMedidaId == guardar.UnidadMedidaId);
                var ActualizarInDB = _unitOfWork.Repository<UnidadMedida>().Consulta().FirstOrDefault(c => c.UnidadMedidaId == guardar.UnidadMedidaId);


                if (ActualizarInDB != null)
                {
                    ActualizarInDB.Codigo = guardar.Codigo;
                    ActualizarInDB.DescripcionUM = guardar.DescripcionUM;
                    ActualizarInDB.Estado = guardar.Estado;

                    //_repository.Editar(ActualizarInDB);
                    //return 1;

                    _unitOfWork.Repository<UnidadMedida>().Editar(ActualizarInDB);
                    return _unitOfWork.Guardar();
                }
                return 0;
            }
        }

        //public int Eliminar(int EliminarPorID)
        //{
        //    var RegistroInDB = _repository.Consulta().FirstOrDefault(c => c.UnidadMedidaId == EliminarPorID);

        //    if (RegistroInDB != null)
        //    {
        //        _repository.Eliminar(RegistroInDB);
        //        return 1;
        //    }
        //    return 0;
        //}

        public int Eliminar(int EliminarPorID)
        {
            var clienteInDb = _unitOfWork.Repository<UnidadMedida>().Consulta().FirstOrDefault(c => c.UnidadMedidaId == EliminarPorID);
            if (clienteInDb != null)
            {
                _unitOfWork.Repository<UnidadMedida>().Eliminar(clienteInDb);
                return _unitOfWork.Guardar();
            }
            return 0;
        }
    }
}
