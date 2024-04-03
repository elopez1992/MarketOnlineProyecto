using Datos.BaseDatos;
using Datos.BaseDatos.Modelos;
using Datos.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DCategorias
    {
        //private MarketContex context;

        Repository<Categoria> _repository;

        public DCategorias()
        {
            //context = new MarketContex();

            _repository = new Repository<Categoria>();
        }

        public int CategoriaId { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaCreacion { get; set; }

        public List<Categoria> CategoriaTodas()
        {
            //return context.categorias.ToList();
            return _repository.Consulta().ToList();
        }

        public int GuardarCategoria(Categoria categoria)
        {
            if (categoria.CategoriaId == 0)
            {
                //context.categorias.Add(categoria);
                //return context.SaveChanges();

                _repository.Agregar(categoria);
                return 1;
            }
            else
            {
                //var CategoriaInDB = context.categorias.Find(categoria.CategoriaId);

                var CategoriaInDB = _repository.Consulta().FirstOrDefault(c=>c.CategoriaId == categoria.CategoriaId);

                if (CategoriaInDB != null)
                {
                    CategoriaInDB.Codigo = categoria.Codigo;
                    CategoriaInDB.Descripcion = categoria.Descripcion;
                    CategoriaInDB.Estado = categoria.Estado;

                    _repository.Editar(CategoriaInDB);
                    return 1;

                    //CategoriaInDB.FechaCreacion = categoria.FechaCreacion;
                    //return context.SaveChanges();
                }
                return 0;
            }
        }

        public int EliminarCategoria(int categoriaId)
        {
            //var CategoriaInDB = context.categorias.Find(categoriaId);

            var CategoriaInDB = _repository.Consulta().FirstOrDefault(c => c.CategoriaId == categoriaId);

            if (CategoriaInDB != null)
            {
                //context.categorias.Remove(CategoriaInDB);
                //return context.SaveChanges();
                 
                _repository.Eliminar(CategoriaInDB);
                return 1;
            }
            return 0;
        }
    }
}
