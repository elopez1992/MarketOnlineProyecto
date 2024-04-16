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
    public partial class VistaPedidos : Form
    {
        private NProductos nProducto;
        private NCliente nCliente;
        private NPedido nPedido;
        private NFactura nFactura;

        public VistaPedidos()
        {
            InitializeComponent();
            nCliente = new NCliente();
            nPedido = new NPedido();
            nProducto = new NProductos();
            nFactura = new NFactura();
        }

        private void VistaPedidos_Load(object sender, EventArgs e)
        {
            CargarDatos();
            CargarCombobox();
            ColumnasDataGrid();
        }

        private void CargarDatos()
        {
            var grupo = nPedido.obtener().Select(c => new { c.PedidoId, c.ClienteId, InformacionCliente= c.Cliente.Codigo + " " + c.Cliente.Nombres + " " + c.Cliente.Apellidos, c.FechaCreacion, c.FechaPedido, c.Estado, c.Total, c.SubTotal, c.Descuento, c.ProductoId, Producto = c.Producto.DescripcionProducto, c.Cantidad  /*c.GrupoDescuentoId,*/  /*c.CondicionPagoId,*/ });

            DGVDatos.DataSource = grupo.ToList();
        }

        private void CargarCombobox()
        {
            // Clientes
            cmbClientes.DataSource = nCliente.RegistrosActivos()
                                              .Select(c => new { c.ClienteId, NombreCompleto = $"{c.Codigo} - {c.Nombres} {c.Apellidos}" })
                                              .ToList();

            cmbClientes.ValueMember = "ClienteId";
            cmbClientes.DisplayMember = "NombreCompleto";

            // Productos
            cmbProducto.DataSource = nProducto.RegistrosActivos()
                                              .Select(c => new { c.ProductoId, ProductosDescripcion = $"{c.ProductoId} - {c.DescripcionProducto}" })
                                              .ToList();

            cmbProducto.ValueMember = "ProductoId";
            cmbProducto.DisplayMember = "ProductosDescripcion";
        }

        private void cmbClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbClientes.SelectedValue != null)
            {
                string clienteIdStr = cmbClientes.SelectedValue.ToString();
                if (int.TryParse(clienteIdStr, out int clienteId))
                {
                    var cliente = nCliente.obtenerClientes().FirstOrDefault(c => c.ClienteId == clienteId);
                    if (cliente != null)
                    {
                        txtNombres.Text = cliente.Nombres;
                        txtApellido.Text = cliente.Apellidos;
                        txtDescuento.Text = cliente.grupodescuento.Porcentaje.ToString();
                    }
                }
            }
        }

        public void comboxProducto()
        {
            if (cmbProducto.SelectedValue == null)
                return;

            if (!int.TryParse(cmbProducto.SelectedValue.ToString(), out int productoId))
                return;

            var producto = nProducto.obtenerProductos().FirstOrDefault(c => c.ProductoId == productoId);
            if (producto == null)
                return;

            txtProducto.Text = producto.DescripcionProducto;
            decimal precioCompra = producto.PrecioCompra;
            decimal cantidad = (decimal)nupdCantidad.Value;
            int descuento = int.Parse(txtDescuento.Text);
            decimal totalSinDescuento = precioCompra * cantidad;
            decimal montoDescuento = totalSinDescuento * (descuento / 100m);
            decimal precioConDescuento = totalSinDescuento - montoDescuento;

            if (cantidad == 1 || nupdCantidad.Value > 1)
                txtTotal.Text = precioConDescuento.ToString();
            else
                txtTotal.Text = precioCompra.ToString();

            txtSubTotal.Text = totalSinDescuento.ToString();
        }

        private void cmbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboxProducto();
        }

        private void nupdCantidad_ValueChanged(object sender, EventArgs e)
        {
            comboxProducto();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var Agregar = false;
            var id = txtID.Text.Trim();

            if (string.IsNullOrEmpty(id) || string.IsNullOrWhiteSpace(id))
            {
                Agregar = true;
            }

            if (Agregar)
            {
                nPedido.Agregar(new Datos.BaseDatos.Modelos.Pedido()
                {
                    ClienteId = int.Parse(cmbClientes.SelectedValue.ToString()),
                    ProductoId = int.Parse(cmbProducto.SelectedValue.ToString()),
                    Cantidad = int.Parse(nupdCantidad.Value.ToString()),
                    Estado = chkEstado.Checked,
                    FechaCreacion = DateTime.Now,
                    FechaPedido = DateTime.Now,
                    Total = decimal.Parse(txtTotal.Text.ToString()),
                    SubTotal = decimal.Parse(txtSubTotal.Text.ToString()),
                    Descuento = int.Parse(txtDescuento.Text.ToString()),
                });
            }
            else
            {
                nPedido.Editar(new Datos.BaseDatos.Modelos.Pedido()
                {
                    PedidoId = int.Parse(id),
                    ClienteId = int.Parse(cmbClientes.SelectedValue.ToString()),
                    ProductoId = int.Parse(cmbProducto.SelectedValue.ToString()),
                    Cantidad = int.Parse(nupdCantidad.Value.ToString()),
                    Estado = chkEstado.Checked,
                    FechaPedido = dtpFechaPedido.Value,
                    Total = decimal.Parse(txtTotal.Text.ToString()),
                    SubTotal = decimal.Parse(txtSubTotal.Text.ToString()),
                    Descuento = int.Parse(txtDescuento.Text.ToString()),
                });
            }

            CargarDatos();
            LimpiarDatos();
        }

        private void LimpiarDatos()
        {
            txtID.Clear();
            nupdCantidad.Value = 1;
            chkEstado.Checked = false;

            dtpFechaCreacion.Value = DateTime.Now;
            dtpFechaPedido.Value = DateTime.Now;

            Random random = new Random();
            int index2 = random.Next(0, cmbProducto.Items.Count);
            cmbProducto.SelectedIndex = index2;
        }

        private void DGVDatos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) 
            {
                DataGridViewRow fila = DGVDatos.Rows[e.RowIndex];

                txtID.Text = DGVDatos.CurrentRow.Cells["PedidoId"].Value.ToString();

                int clienteId = Convert.ToInt32(fila.Cells["ClienteId"].Value);
                var cliente = nCliente.RegistrosActivos().FirstOrDefault(c => c.ClienteId == clienteId);
                if (cliente != null)
                {
                    cmbClientes.SelectedValue = clienteId;
                    txtNombres.Text = cliente.Nombres;
                    txtApellido.Text = cliente.Apellidos;
                    txtDescuento.Text = cliente.grupodescuento.Porcentaje.ToString();
                }

                int productoId = Convert.ToInt32(fila.Cells["ProductoId"].Value);
                var producto = nProducto.RegistrosActivos().FirstOrDefault(p => p.ProductoId == productoId);
                if (producto != null)
                {
                    cmbProducto.SelectedValue = productoId;
                    txtProducto.Text = producto.DescripcionProducto;
                    decimal precioCompra = producto.PrecioCompra;
                }

                nupdCantidad.Value = Convert.ToDecimal(fila.Cells["Cantidad"].Value);
                txtTotal.Text = DGVDatos.CurrentRow.Cells["Total"].Value.ToString();
                txtSubTotal.Text = DGVDatos.CurrentRow.Cells["SubTotal"].Value.ToString();
                dtpFechaCreacion.Text = DGVDatos.CurrentRow.Cells["FechaCreacion"].Value.ToString();
                dtpFechaPedido.Text = DGVDatos.CurrentRow.Cells["FechaPedido"].Value.ToString();
                chkEstado.Checked = Convert.ToBoolean(fila.Cells["Estado"].Value);
            }
        }

        public void ColumnasDataGrid()
        {
            DGVDatos.Columns["PedidoId"].Width = 60;
            DGVDatos.Columns["ClienteId"].Width = 60;
            DGVDatos.Columns["InformacionCliente"].Width = 235;
            DGVDatos.Columns["FechaCreacion"].Visible = false;
            DGVDatos.Columns["FechaPedido"].Width = 110;
            DGVDatos.Columns["Estado"].Width = 60;
            DGVDatos.Columns["Total"].Width = 80;
            DGVDatos.Columns["SubTotal"].Width = 60;
            DGVDatos.Columns["Descuento"].Width = 60;
            DGVDatos.Columns["ProductoId"].Width = 70;
            DGVDatos.Columns["Producto"].Width = 126;
            DGVDatos.Columns["Cantidad"].Width = 60;

            DGVDatos.Columns["InformacionCliente"].HeaderText = "Informacion del Cliente";

            foreach (DataGridViewColumn columna in DGVDatos.Columns)
            {
                if (columna.Name != "InformacionCliente" && columna.Name != "Producto")
                {
                    columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }

            DGVDatos.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            var id = txtID.Text.ToString();

            if (string.IsNullOrEmpty(id) || string.IsNullOrWhiteSpace(id))
            {
                return;
            }
            nPedido.EliminarRegistro(int.Parse(id));
            CargarDatos();
            LimpiarDatos();
        }


        private void rbTodas_CheckedChanged(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void rbActivas_CheckedChanged(object sender, EventArgs e)
        {
            var grupo = nPedido.obtener().Select(c => new { c.PedidoId, c.ClienteId, InformacionCliente = c.Cliente.Codigo + " " + c.Cliente.Nombres + " " + c.Cliente.Apellidos, c.FechaCreacion, c.FechaPedido, c.Estado, c.Total, c.SubTotal, c.Descuento, c.ProductoId, Producto = c.Producto.DescripcionProducto, c.Cantidad  /*c.GrupoDescuentoId,*/  /*c.CondicionPagoId,*/ });
            DGVDatos.DataSource = grupo.ToList().Where(c => c.Estado == true).ToList();
            ColumnasDataGrid();
        }

        private void rbInactivas_CheckedChanged(object sender, EventArgs e)
        {
            var grupo = nPedido.obtener().Select(c => new { c.PedidoId, c.ClienteId, InformacionCliente = c.Cliente.Codigo + " " + c.Cliente.Nombres + " " + c.Cliente.Apellidos, c.FechaCreacion, c.FechaPedido, c.Estado, c.Total, c.SubTotal, c.Descuento, c.ProductoId, Producto = c.Producto.DescripcionProducto, c.Cantidad  /*c.GrupoDescuentoId,*/  /*c.CondicionPagoId,*/ });
            DGVDatos.DataSource = grupo.ToList().Where(c => c.Estado == false).ToList();
            ColumnasDataGrid();
        }

        private void btnFacturar_Click(object sender, EventArgs e)
        {
            var id = txtID.Text;

            if (string.IsNullOrEmpty(id) || string.IsNullOrWhiteSpace(id))
            {
                return;
            }
            else
            {
                nFactura.Agregar(new Datos.BaseDatos.Modelos.Factura()
                {
                    ClienteId = int.Parse(cmbClientes.SelectedValue.ToString()),
                    PedidoId = int.Parse(txtID.Text),
                    FechaCreacion = dtpFechaCreacion.Value,
                    FechaFactura = DateTime.Now,
                    Estado = chkEstado.Checked,
                    Total = decimal.Parse(txtTotal.Text),
                    SubTotal = decimal.Parse(txtSubTotal.Text),
                    Descuento = decimal.Parse(txtDescuento.Text),
                });

                MessageBox.Show("Facturado...");
                LimpiarDatos();
            }            
        }

        private void btnVistaPedidosDetalles_Click(object sender, EventArgs e)
        {
            VistaPedidoDetalle vista = new VistaPedidoDetalle();
            //vista.MdiParent = this;
            vista.Show();
        }
    }
}
