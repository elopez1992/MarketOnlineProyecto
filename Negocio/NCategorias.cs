using Datos;
using Datos.BaseDatos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NCategorias
    {
        private DCategorias dCategorias;

        public NCategorias()
        {
            dCategorias = new DCategorias();
        }

        public List<Categoria> obtenerCategorias()
        {
            return dCategorias.CategoriaTodas();
        }

        public List<Categoria> obtenerCategoriaGrid()
        {
            var Prodcuto = dCategorias.CategoriaTodas().Select(c => new { c.CategoriaId, c.Codigo, c.Descripcion, c.Estado, c.FechaCreacion });
            return dCategorias.CategoriaTodas().ToList();
        }

        public int Agregar(Categoria categoria)
        {
            return dCategorias.GuardarCategoria(categoria);
        }

        public int EditarCategoria(Categoria categoria)
        {
            return dCategorias.GuardarCategoria(categoria);
        }

        public int EliminarCategoria(int categoriaId)
        {
            return dCategorias.EliminarCategoria(categoriaId);
        }

        public List<Categoria> CategoriasActivas()
        {
            return dCategorias.CategoriaTodas().Where(c => c.Estado == true).ToList();
        }

        public List<Categoria> CategoriasInactivas()
        {
            return dCategorias.CategoriaTodas().Where(c => c.Estado == false).ToList();
        }
    }
}
