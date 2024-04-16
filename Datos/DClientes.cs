using Datos.BaseDatos.Modelos;
using Datos.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Datos
{
    public class DClientes
    {
        //Repository<Cliente> _repository;
        UnitOfWork _unitOfWork;
        public DClientes()
        {
            //_repository = new Repository<Cliente>();
            _unitOfWork = new UnitOfWork();
        }

        public int ClienteId { get; set; }
        public string Codigo { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public int GrupoDescuentoId { get; set; }
        public int CondicionPagoId { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaCreacion { get; set; }

        public List<Cliente> RegistrosTodos()
        {
            /*return _repository.Consulta().Include(c => c.grupodescuento)
                                         .Include(c => c.condionpago)
                                         .ToList();*/

            return _unitOfWork.Repository<Cliente>().Consulta().Include(c => c.grupodescuento)
                                      .Include(c => c.condionpago)
                                      .ToList();
        }

        public int Guardar(Cliente guardar)
        {
            if (guardar.ClienteId == 0)
            {
                _unitOfWork.Repository<Cliente>().Agregar(guardar);
                return _unitOfWork.Guardar();
            }
            else
            {
                var ActualizarInDB = _unitOfWork.Repository<Cliente>().Consulta().FirstOrDefault(c => c.ClienteId == guardar.ClienteId);

                if (ActualizarInDB != null)
                {
                    ActualizarInDB.Codigo = guardar.Codigo;
                    ActualizarInDB.Nombres = guardar.Nombres;
                    ActualizarInDB.Apellidos = guardar.Apellidos;
                    ActualizarInDB.GrupoDescuentoId = guardar.GrupoDescuentoId;
                    ActualizarInDB.CondicionPagoId = guardar.CondicionPagoId;
                    ActualizarInDB.Estado = guardar.Estado;

                    _unitOfWork.Repository<Cliente>().Editar(ActualizarInDB);
                    return _unitOfWork.Guardar();
                }
                return 0;
            }
        }

        public int Eliminar(int EliminarPorID)
        {                       
            var clienteInDb = _unitOfWork.Repository<Cliente>().Consulta().FirstOrDefault(c => c.ClienteId == EliminarPorID);
            if (clienteInDb != null)
            {
                _unitOfWork.Repository<Cliente>().Eliminar(clienteInDb);
                return _unitOfWork.Guardar();
            }            
            return 0;
        }
    }
}
