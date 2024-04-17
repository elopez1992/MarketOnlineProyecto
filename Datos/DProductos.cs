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
    public class DProductos
    {
        UnitOfWork _unitOfWork;

        public DProductos()
        {
            _unitOfWork = new UnitOfWork();
        }
        public int ProductoId { get; set; }
        public string DescripcionProducto { get; set; }
        public int CategoriaId { get; set; }
        public int UnidadMedidaId { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool Estado { get; set; }
        public decimal PrecioCompra { get; set; }

        public List<Producto> RegistrosTodos()
        {
            return _unitOfWork.Repository<Producto>().Consulta().Include(c => c.categoria)
                                      .Include(c => c.unidadmedida)
                                      .ToList();
        }

        public int Guardar(Producto guardar)
        {
            if (guardar.ProductoId == 0)
            {
                _unitOfWork.Repository<Producto>().Agregar(guardar);
                return _unitOfWork.Guardar();
            }
            else
            {
                var ActualizarInDB = _unitOfWork.Repository<Producto>().Consulta().FirstOrDefault(c => c.ProductoId == guardar.ProductoId);

                if (ActualizarInDB != null)
                {
                    ActualizarInDB.DescripcionProducto = guardar.DescripcionProducto;
                    ActualizarInDB.CategoriaId = guardar.CategoriaId;
                    ActualizarInDB.UnidadMedidaId = guardar.UnidadMedidaId;
                    ActualizarInDB.Estado = guardar.Estado;
                    ActualizarInDB.PrecioCompra = guardar.PrecioCompra;

                    _unitOfWork.Repository<Producto>().Editar(ActualizarInDB);
                    return _unitOfWork.Guardar();
                }
                return 0;
            }
        }

        public int Eliminar(int EliminarPorID)
        {           
            var clienteInDb = _unitOfWork.Repository<Producto>().Consulta().FirstOrDefault(c => c.ProductoId == EliminarPorID);
            if (clienteInDb != null)
            {
                _unitOfWork.Repository<Producto>().Eliminar(clienteInDb);
                return _unitOfWork.Guardar();
            }            
            return 0;
        }
    }
}
