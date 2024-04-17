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
    public class DPedidoDetalle
    {
        UnitOfWork _unitOfWork;

        public DPedidoDetalle()
        {
            _unitOfWork = new UnitOfWork();
        }

        public int PedidoDetalleId { get; set; }
        public int PedidoId { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int ProductoId { get; set; }
        public decimal Precio { get; set; }
        public decimal Total { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Descuento { get; set; }

        public List<PedidoDetalle> RegistrosTodos()
        {
            return _unitOfWork.Repository<PedidoDetalle>().Consulta().Include(c => c.pedido)
                                                  .Include(c => c.producto)
                                                  .ToList();
        }

        public int Guardar(PedidoDetalle guardar)
        {
            if (guardar.PedidoDetalleId == 0)
            {
                _unitOfWork.Repository<PedidoDetalle>().Agregar(guardar);
                return _unitOfWork.Guardar();
            }
            else
            {
                var ActualizarInDB = _unitOfWork.Repository<PedidoDetalle>().Consulta().FirstOrDefault(c => c.PedidoDetalleId == guardar.PedidoDetalleId);

                if (ActualizarInDB != null)
                {
                    /*ActualizarInDB.PedidoId = guardar.PedidoId;
                    ActualizarInDB.ProductoId = guardar.ProductoId;
                    ActualizarInDB.Cantidad = guardar.Cantidad;
                    ActualizarInDB.Estado = guardar.Estado;
                    ActualizarInDB.FechaPedido = guardar.FechaPedido;
                    ActualizarInDB.Total = guardar.Total;
                    ActualizarInDB.SubTotal = guardar.SubTotal;
                    ActualizarInDB.Descuento = guardar.Descuento;

                    _unitOfWork.Repository<Pedido>().Editar(ActualizarInDB);
                    return _unitOfWork.Guardar();*/
                }
                return 0;
            }
        }

        public int Eliminar(int EliminarPorID)
        {
            try
            {
                var PedidoInDb = _unitOfWork.Repository<PedidoDetalle>().Consulta().FirstOrDefault(c => c.PedidoDetalleId == EliminarPorID);
                if (PedidoInDb != null)
                {
                    _unitOfWork.Repository<PedidoDetalle>().Eliminar(PedidoInDb);
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
