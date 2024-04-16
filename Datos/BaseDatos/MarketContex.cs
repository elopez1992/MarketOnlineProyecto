using Datos.BaseDatos.Modelos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SqlClient;
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

        public SqlConnection GetConexion()
        {
            SqlConnection SqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["MarketOnline"].ToString());
            return SqlCon;
        }

        public DbSet<Categoria> categorias { get; set; }
        public DbSet<GrupoDescuento> grupodescuentos { get; set; }
        public DbSet<UnidadMedida> unidadmedidas { get; set; }
        public DbSet<CondicionPago> condicionpago { get; set; }
        public DbSet<Cliente> cliente { get; set; }
        public DbSet<Producto> productos { get; set; }
        public DbSet<Pedido> pedidos { get; set; }
        public DbSet<Factura> factura { get; set; }
        public DbSet<PedidoDetalle> pedidosDetalle { get; set; }
        public DbSet<FacturaDetalle> facturaDetalles { get; set; }

        public DbSet<Login> login { get; set; }
    }

}
