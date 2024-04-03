using Datos.BaseDatos.Modelos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.BaseDatos
{
    public class MarketContex: DbContext
    {
        public MarketContex():base("Name=MarketOnline")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<Categoria> categorias { get; set; }
        public DbSet<GrupoDescuento> grupodescuentos { get; set; }
        public DbSet<UnidadMedida> unidadmedidas { get; set; }
        public DbSet<CondicionPago> condicionpago { get; set; }
        public DbSet<Cliente> cliente { get; set; }
        public DbSet<Producto> productos { get; set; }
    }

}
