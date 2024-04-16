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
    public class DFactura
    {
        UnitOfWork _unitOfWork;

        public DFactura()
        {
            _unitOfWork = new UnitOfWork();
        }
        public List<Factura> RegistrosTodos()
        {

            return _unitOfWork.Repository<Factura>().Consulta().Include(c => c.Cliente)
                                                  .Include(c => c.pedido)
                                                  .ToList();
        }

        public int Guardar(Factura guardar)
        {
            if (guardar.FacturaId == 0)
            {
                _unitOfWork.Repository<Factura>().Agregar(guardar);
                return _unitOfWork.Guardar();
            }
            else
            {
                var ActualizarInDB = _unitOfWork.Repository<Factura>().Consulta().FirstOrDefault(c => c.FacturaId == guardar.FacturaId);

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
