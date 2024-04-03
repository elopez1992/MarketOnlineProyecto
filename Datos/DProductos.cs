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
    public class DProductos
    {
        Repository<Producto> _repository;
        public DProductos()
        {
            _repository = new Repository<Producto>();
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
            return _repository.Consulta().Include(c => c.categoria)
                                         .Include(c => c.unidadmedida)
                                         .ToList();
        }

        public int Guardar(Producto guardar)
        {
            if (guardar.ProductoId == 0)
            {
                _repository.Agregar(guardar);
                return 1;
            }
            else
            {
                var ActualizarInDB = _repository.Consulta().FirstOrDefault(c => c.ProductoId == guardar.ProductoId);

                if (ActualizarInDB != null)
                {
                    ActualizarInDB.DescripcionProducto = guardar.DescripcionProducto;
                    ActualizarInDB.CategoriaId = guardar.CategoriaId;
                    ActualizarInDB.UnidadMedidaId = guardar.UnidadMedidaId;
                    ActualizarInDB.Estado = guardar.Estado;
                    ActualizarInDB.PrecioCompra = guardar.PrecioCompra;

                    _repository.Editar(ActualizarInDB);
                    return 1;
                }
                return 0;
            }
        }

        public int Eliminar(int EliminarPorID)
        {
            var RegistroInDB = _repository.Consulta().FirstOrDefault(c => c.ProductoId == EliminarPorID);

            if (RegistroInDB != null)
            {
                _repository.Eliminar(RegistroInDB);
                return 1;
            }
            return 0;
        }
    }
}
