using Datos.BaseDatos.Modelos;
using Datos.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DFacturaDetalles
    {
        UnitOfWork _unitOfWork;

        public DFacturaDetalles()
        {
            _unitOfWork = new UnitOfWork();
        }
        public List<FacturaDetalle> RegistrosTodos()
        {

            return _unitOfWork.Repository<FacturaDetalle>().Consulta().Include(c => c.factura)
                                                  .Include(c => c.producto)
                                                  .ToList();
        }

        public int Guardar(FacturaDetalle guardar)
        {
            if (guardar.FacturaDetalleId == 0)
            {
                _unitOfWork.Repository<FacturaDetalle>().Agregar(guardar);
                return _unitOfWork.Guardar();
            }
            else
            {
                var ActualizarInDB = _unitOfWork.Repository<FacturaDetalle>().Consulta().FirstOrDefault(c => c.FacturaDetalleId == guardar.FacturaDetalleId);

                if (ActualizarInDB != null)
                {
                    //ActualizarInDB.ClienteId = guardar.ClienteId;
                    //ActualizarInDB.ProductoId = guardar.ProductoId;
                    //ActualizarInDB.Cantidad = guardar.Cantidad;
                    //ActualizarInDB.Estado = guardar.Estado;
                    //ActualizarInDB.FechaPedido = guardar.FechaPedido;
                    //ActualizarInDB.Total = guardar.Total;
                    //ActualizarInDB.SubTotal = guardar.SubTotal;
                    //ActualizarInDB.Descuento = guardar.Descuento;

                    //_unitOfWork.Repository<Pedido>().Editar(ActualizarInDB);
                    return _unitOfWork.Guardar();
                }
                return 0;
            }
        }
    }
}
