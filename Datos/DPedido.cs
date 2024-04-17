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
    public class DPedido
    {
       //Repository<Pedido> _repository;
        UnitOfWork _unitOfWork;

        public DPedido()
        {
            //_repository = new Repository<Pedido>();
            _unitOfWork = new UnitOfWork();
        }

        public int PedidoId { get; set; }

        public int ClienteId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaPedido { get; set; }
        public bool Estado { get; set; }
        public decimal Total { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Descuento { get; set; }

        public List<Pedido> RegistrosTodos()
        {
            //return _repository.Consulta().ToList();

            return _unitOfWork.Repository<Pedido>().Consulta().Include(c => c.Cliente)
                                                  .Include(c => c.Producto)
                                                  .ToList();
        }

        public int Guardar(Pedido guardar)
        {
            if (guardar.PedidoId == 0)
            {
                _unitOfWork.Repository<Pedido>().Agregar(guardar);
                return _unitOfWork.Guardar();
            }
            else
            {
                var ActualizarInDB = _unitOfWork.Repository<Pedido>().Consulta().FirstOrDefault(c => c.PedidoId == guardar.PedidoId);

                if (ActualizarInDB != null)
                {
                    ActualizarInDB.ClienteId = guardar.ClienteId;
                    ActualizarInDB.ProductoId = guardar.ProductoId;
                    ActualizarInDB.Cantidad = guardar.Cantidad;
                    ActualizarInDB.Estado = guardar.Estado;
                    ActualizarInDB.FechaPedido = guardar.FechaPedido;
                    ActualizarInDB.Total = guardar.Total;
                    ActualizarInDB.SubTotal = guardar.SubTotal;
                    ActualizarInDB.Descuento = guardar.Descuento;

                    _unitOfWork.Repository<Pedido>().Editar(ActualizarInDB);
                    return _unitOfWork.Guardar();
                }
                return 0;
            }
        }

        public int Eliminar(int EliminarPorID)
        {
            try
            {
                var PedidoInDb = _unitOfWork.Repository<Pedido>().Consulta().FirstOrDefault(c => c.PedidoId == EliminarPorID);
                if (PedidoInDb != null)
                {
                    _unitOfWork.Repository<Pedido>().Eliminar(PedidoInDb);
                    return _unitOfWork.Guardar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return 0;
        }
    }
}
