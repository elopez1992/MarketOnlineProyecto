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
    public class DCondicionPago
    {
        //Repository<CondicionPago> _repository;
        UnitOfWork _unitOfWork;

        public DCondicionPago()
        {
            //_repository = new Repository<CondicionPago>();
            _unitOfWork = new UnitOfWork();

        }

        public int CondicionPagoId { get; set; }
        public string Codigo { get; set; }
        public string DescripcionCP { get; set; }
        public bool Estado { get; set; }
        public int Dias { get; set; }
        public DateTime FechaCreacionCP { get; set; }

        public List<CondicionPago> RegistrosTodos()
        {
            //return _repository.Consulta().ToList();

            return _unitOfWork.Repository<CondicionPago>().Consulta().ToList();
        }

        public int Guardar(CondicionPago guardar)
        {
            if (guardar.CondicionPagoId == 0)
            {
                //_repository.Agregar(guardar);
                //return 1;

                _unitOfWork.Repository<CondicionPago>().Agregar(guardar);
                return _unitOfWork.Guardar();
            }
            else
            {
                //var ActualizarInDB = _repository.Consulta().FirstOrDefault(c => c.CondicionPagoId == guardar.CondicionPagoId);
                var ActualizarInDB = _unitOfWork.Repository<CondicionPago>().Consulta().FirstOrDefault(c => c.CondicionPagoId == guardar.CondicionPagoId);


                if (ActualizarInDB != null)
                {
                    ActualizarInDB.Codigo = guardar.Codigo;
                    ActualizarInDB.DescripcionCP = guardar.DescripcionCP;
                    ActualizarInDB.Estado = guardar.Estado;
                    ActualizarInDB.Dias = guardar.Dias;

                    //_repository.Editar(ActualizarInDB);
                    //return 1;

                    _unitOfWork.Repository<CondicionPago>().Editar(ActualizarInDB);
                    return _unitOfWork.Guardar();
                }
                return 0;
            }
        }

        public int Eliminar(int EliminarPorID)
        {
            var clienteInDb = _unitOfWork.Repository<CondicionPago>().Consulta().FirstOrDefault(c => c.CondicionPagoId == EliminarPorID);
            if (clienteInDb != null)
            {
                _unitOfWork.Repository<CondicionPago>().Eliminar(clienteInDb);
                return _unitOfWork.Guardar();
            }
            return 0;
        }
    }
}
