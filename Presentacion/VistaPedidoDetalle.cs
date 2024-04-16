using Datos.BaseDatos.Modelos;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarketOnline
{
    public partial class VistaPedidoDetalle : Form
    {
        private NProductos nProducto;
        private NPedidoDetalle nPedidoDetalle;
        private NPedido nPedido;
        private NCliente nCliente;
        private NFactura nFactura;


        public VistaPedidoDetalle()
        {
            InitializeComponent();
            nPedidoDetalle = new NPedidoDetalle();
            nPedido = new NPedido();
            nProducto = new NProductos();
            nCliente = new NCliente();
            nFactura = new NFactura();
        }

        private void VistaPedidoDetalle_Load(object sender, EventArgs e)
        {
            CargarCombobox();
            if (int.TryParse(txtID.Text, out int clienteId))
            {
                CargarDatos();
                ColumnasPEDIDOS();
            }

            BotonAgregar();
        }

        private void CargarDatos()
        {
            if (!int.TryParse(txtID.Text, out int clienteId))
            {
                MessageBox.Show("Por favor ingresa un ID de cliente válido.");
                return;
            }

            clienteId = int.Parse(txtID.Text);

            var grupo = nPedido.obtener()
                               .Where(c => c.ClienteId == clienteId)
                               .Select(c => new
                               {
                                   c.PedidoId,
                                   c.FechaCreacion,
                                   c.FechaPedido,
                                   c.ProductoId,
                                   Producto = c.Producto.DescripcionProducto,
                                   c.Producto.PrecioCompra,
                                   c.Descuento,
                                   c.SubTotal,
                                   c.Total,
                                   c.Cantidad,
                               });

            DGVDatosPedidos.DataSource = grupo.ToList();
        }

        private void CargarCombobox()
        {
            // Clientes
            cmbClientes.DataSource = nCliente.RegistrosActivos()
                                              .Select(c => new { c.ClienteId, NombreCompleto = $"{c.Codigo} - {c.Nombres} {c.Apellidos}" })
                                              .ToList();

            cmbClientes.ValueMember = "ClienteId";
            cmbClientes.DisplayMember = "NombreCompleto";
        }

        public void CargarPedidosDetalles()
        {
            int clienteid = int.Parse(txtID.Text);

            var grupo = nPedidoDetalle.obtener().Where(c => c.pedido.ClienteId == clienteid).Select(c => new { c.PedidoDetalleId, c.PedidoId, c.ProductoId, Producto = c.pedido.Producto.DescripcionProducto, c.FechaCreacion, c.Precio, c.pedido.Cantidad, c.Descuento, c.SubTotal, c.Total  /*c.GrupoDescuentoId,*/  /*c.CondicionPagoId,*/ });

            DGVDatos.DataSource = grupo.ToList();

            CalcularTotal();
        }

        private void cmbClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbClientes.SelectedItem != null)
            {
                var clienteId = cmbClientes.SelectedValue;

                txtID.Text = clienteId.ToString();

                if (int.TryParse(txtID.Text, out int id))
                {
                    CargarDatos();

                    CargarPedidosDetalles();
                }
            }
        }

        public void ColumnasPEDIDOS()
        {
            DGVDatosPedidos.Columns["PedidoId"].Width = 60;
            DGVDatosPedidos.Columns["FechaPedido"].Width = 110;
            DGVDatosPedidos.Columns["Descuento"].Visible = false;
            DGVDatosPedidos.Columns["SubTotal"].Visible = false;
            DGVDatosPedidos.Columns["Total"].Visible = false;
            DGVDatosPedidos.Columns["Cantidad"].Visible = false;

            DGVDatosPedidos.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var id = txtIdPedidoDetalle.Text;

            if (string.IsNullOrEmpty(id) || string.IsNullOrWhiteSpace(id))
            {
                var pedidoId = int.Parse(txtPedidoId.Text);

                foreach (DataGridViewRow row in DGVDatos.Rows)
                {
                    var pedidoIdEnDgv2 = (int)row.Cells["PedidoId"].Value;
                    if (pedidoIdEnDgv2 == pedidoId)
                    {
                        MessageBox.Show("Este registro ya ha sido agregado.", "Registro Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                nPedidoDetalle.Agregar(new Datos.BaseDatos.Modelos.PedidoDetalle()
                {
                    PedidoId = pedidoId,
                    FechaCreacion = dtpFechaCreacion.Value,
                    ProductoId = int.Parse(txtProductoId.Text),
                    Precio = decimal.Parse(txtPrecio.Text),
                    Total = decimal.Parse(txtTotal.Text),
                    SubTotal = decimal.Parse(txtSubTotal.Text),
                    Descuento = decimal.Parse(txtDescuento.Text),
                });
            }

            CargarPedidosDetalles();
            LimpiarDatos();
        }
        public void veryagregar()
        {
            txtPedidoId.Text = DGVDatosPedidos.CurrentRow.Cells["PedidoId"].Value.ToString();
            txtProductoId.Text = DGVDatosPedidos.CurrentRow.Cells["ProductoId"].Value.ToString();
            txtProducto.Text = DGVDatosPedidos.CurrentRow.Cells["Producto"].Value.ToString();
            dtpFechaCreacion.Text = DGVDatosPedidos.CurrentRow.Cells["FechaCreacion"].Value.ToString();
            txtPrecio.Text = DGVDatosPedidos.CurrentRow.Cells["PrecioCompra"].Value.ToString();
            txtCantidad.Text = DGVDatosPedidos.CurrentRow.Cells["Cantidad"].Value.ToString();
            txtDescuento.Text = DGVDatosPedidos.CurrentRow.Cells["Descuento"].Value.ToString();
            txtSubTotal.Text = DGVDatosPedidos.CurrentRow.Cells["SubTotal"].Value.ToString();
            txtTotal.Text = DGVDatosPedidos.CurrentRow.Cells["Total"].Value.ToString();

            var id = txtIdPedidoDetalle.Text;

            if (string.IsNullOrEmpty(id) || string.IsNullOrWhiteSpace(id))
            {
                var pedidoId = int.Parse(txtPedidoId.Text);

                foreach (DataGridViewRow row in DGVDatos.Rows)
                {
                    var pedidoIdEnDgv2 = (int)row.Cells["PedidoId"].Value;
                    if (pedidoIdEnDgv2 == pedidoId)
                    {
                        MessageBox.Show("Este registro ya ha sido agregado.", "Registro Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                nPedidoDetalle.Agregar(new Datos.BaseDatos.Modelos.PedidoDetalle()
                {
                    PedidoId = pedidoId,
                    FechaCreacion = dtpFechaCreacion.Value,
                    ProductoId = int.Parse(txtProductoId.Text),
                    Precio = decimal.Parse(txtPrecio.Text),
                    Total = decimal.Parse(txtTotal.Text),
                    SubTotal = decimal.Parse(txtSubTotal.Text),
                    Descuento = decimal.Parse(txtDescuento.Text),
                });
            }

            CargarPedidosDetalles();
            LimpiarDatos();
        }

        private void DGVDatosPedidos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            veryagregar();
        }

        public void BotonAgregar()
        {
            if (string.IsNullOrWhiteSpace(txtPedidoId.Text))
            {
                btnAgregar.Enabled = false;
            }
            else
            {
                btnAgregar.Enabled = true;
            }
        }

        private void txtPedidoId_TextChanged(object sender, EventArgs e)
        {
            BotonAgregar();
        }

        private void LimpiarDatos()
        {
            txtPedidoId.Clear();
            dtpFechaCreacion.Value = DateTime.Now;
            txtPrecio.Clear();
            txtDescuento.Clear();
            txtTotal.Clear();
            txtSubTotal.Clear();
            txtProducto.Clear();
            txtProductoId.Clear();
            txtCantidad.Clear();
        }

        private void CalcularTotal()
        {
            decimal total = 0;

            foreach (DataGridViewRow row in DGVDatos.Rows)
            {
                if (row.Cells["Total"].Value != null)
                {
                    total += Convert.ToDecimal(row.Cells["Total"].Value);
                }
            }
            //txtTotalSuma.Text = total.ToString();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (DGVDatos.SelectedRows.Count > 0)
            {
                int pedidoDetalleId = Convert.ToInt32(DGVDatos.SelectedRows[0].Cells["PedidoDetalleId"].Value);

                nPedidoDetalle.EliminarRegistro(pedidoDetalleId);

                CargarPedidosDetalles();
            }
            else
            {
                MessageBox.Show("Por favor selecciona una fila/registro para eliminar.");
            }
        }

        private void DGVDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int pedidoDetalleId = Convert.ToInt32(DGVDatos.Rows[e.RowIndex].Cells["PedidoDetalleId"].Value);
            }
        }

        private void btnFacturar_Click(object sender, EventArgs e)
        {

        }

        public void VerAgregarEnFacturas()
        {

        }
        private void DGVDatos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            VerAgregarEnFacturas();
        }
    }
}
