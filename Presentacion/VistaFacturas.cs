using Datos;
using Datos.BaseDatos.Modelos;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarketOnline
{
    public partial class VistaFacturas : Form
    {
        private NFactura nFactura;
        private NFacturaDetalle nFacturaDetalle;

        public VistaFacturas()
        {
            InitializeComponent();
            nFactura = new NFactura();
            nFacturaDetalle = new NFacturaDetalle();
        }

        private void VistaFacturas_Load(object sender, EventArgs e)
        {
            CargarDatos();
            CargarDetalles();

            DGVFacturas.Columns["InformacionCliente"].Width = 200;
            DGVDetalles.Columns["DescripcionProducto"].Width = 200;

        }
        private void CargarDatos()
        {
            var grupo = nFactura.obtener().Select(c => new { c.FacturaId, c.PedidoId, c.pedido.ClienteId, InformacionCliente = c.pedido.Cliente.Codigo + " " + c.pedido.Cliente.Nombres + " " + c.pedido.Cliente.Apellidos, c.pedido.ProductoId, c.FechaCreacion, c.FechaFactura, c.Estado, c.Total, c.pedido.SubTotal, c.Descuento, });

            DGVFacturas.DataSource = grupo.ToList();
        }
        public void CargarDetalles()
        {
            //var grupo = nFacturaDetalle.obtener().Select(c => new { c.FacturaId, c.factura.PedidoId, c.factura.pedido.ClienteId, InformacionCliente = c.factura.pedido.Cliente.Codigo + " " + c.factura.pedido.Cliente.Nombres + " " + c.factura.pedido.Cliente.Apellidos, c.FechaCreacion, c.factura.FechaFactura, c.factura.Estado, c.Total, c.SubTotal, c.Descuento, c.factura.pedido.Cantidad, c.factura.Cliente.condionpago });
            var grupo = nFacturaDetalle.obtener().Select(c => new { c.FacturaId, c.FechaCreacion, c.ProductoId, c.producto.DescripcionProducto, c.Total, c.SubTotal, c.Descuento, c.producto.PrecioCompra,});

            DGVDetalles.DataSource = grupo.ToList();
        }
        public void EnviarDatosTXT()
        {
            txtfacturaid.Text = DGVFacturas.CurrentRow.Cells["FacturaId"].Value.ToString();
            txtProductoId.Text = DGVFacturas.CurrentRow.Cells["ProductoId"].Value.ToString();
            //txtProducto.Text = DGVDatos.CurrentRow.Cells["Producto"].Value.ToString();
            dtpFechaCreacion.Text = DGVFacturas.CurrentRow.Cells["FechaCreacion"].Value.ToString();
            //txtPrecio.Text = DGVFacturas.CurrentRow.Cells["Precio"].Value.ToString();
            txtTotal.Text = DGVFacturas.CurrentRow.Cells["Total"].Value.ToString();
            txtSubTotal.Text = DGVFacturas.CurrentRow.Cells["SubTotal"].Value.ToString();
            txtDescuento.Text = DGVFacturas.CurrentRow.Cells["Descuento"].Value.ToString();

            var id = txtfacturadetalleid.Text;

            if (string.IsNullOrEmpty(id) || string.IsNullOrWhiteSpace(id))
            {
                var facturaid = int.Parse(txtfacturaid.Text);

                foreach (DataGridViewRow row in DGVDetalles.Rows)
                {
                    var FacturaIdEnDgv2 = (int)row.Cells["FacturaId"].Value;
                    if (FacturaIdEnDgv2 == facturaid)
                    {
                        MessageBox.Show("Este registro ya ha sido agregado.", "Registro Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                nFacturaDetalle.Agregar(new Datos.BaseDatos.Modelos.FacturaDetalle()
                {
                    FacturaId = facturaid,
                    FechaCreacion = dtpFechaCreacion.Value,
                    ProductoId = int.Parse(txtProductoId.Text),
                    //Precio = decimal.Parse(txtPrecio.Text),
                    Total = decimal.Parse(txtTotal.Text),
                    SubTotal = decimal.Parse(txtSubTotal.Text),
                    Descuento = decimal.Parse(txtDescuento.Text),
                });
            }

            CargarDetalles();
            //LimpiarDatos();
        }

        private void DGVFacturas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EnviarDatosTXT();
            
        }
    }
}
