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
    public partial class VistaProductos : Form
    {
        private NProductos nVariable;
        private NCategorias nCategorias;
        private NUnidadMedida nUnidad;
        public VistaProductos()
        {
            InitializeComponent();
            nVariable = new NProductos();
            nCategorias = new NCategorias();
            nUnidad = new NUnidadMedida();
        }

        private void VistaProductos_Load(object sender, EventArgs e)
        {
            CargarDatos();
            CargarCombobox();
        }

        private void CargarDatos()
        {
            var grupo = nVariable.obtenerProductos().Select(c => new { c.ProductoId, c.DescripcionProducto, c.categoria.Descripcion, c.unidadmedida.DescripcionUM, c.FechaCreacion, c.Estado, c.PrecioCompra });

            DGVDatos.DataSource = grupo.ToList();
        }

        private void CargarCombobox()
        {
            // Categorias
            cmbCategoria.DataSource = nCategorias.CategoriasActivas()
                                          .Select(c => new { c.CategoriaId, c.Descripcion }).ToList();

            cmbCategoria.ValueMember = "CategoriaId";
            cmbCategoria.DisplayMember = "Descripcion";


            // Unidades
            cmbUnidadMediad.DataSource = nUnidad.RegistrosActivos()
                              .Select(c => new { c.UnidadMedidaId, c.DescripcionUM }).ToList();

            cmbUnidadMediad.ValueMember = "UnidadMedidaId";
            cmbUnidadMediad.DisplayMember = "DescripcionUM";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var Agregar = false;
            var id = txtID.Text.ToString();

            var preciocompra = txtPrecioCompra.Text.ToString();
            var descripcion = txtDescripcion.Text.ToString();

            if (string.IsNullOrEmpty(id) || string.IsNullOrWhiteSpace(id))
            {
                Agregar = true;
            }
            if (string.IsNullOrEmpty(descripcion) || string.IsNullOrWhiteSpace(descripcion))
            {
                errorProvider1.SetError(txtDescripcion, "Debe de ingresar el nombre del Producto");
                return;
            }
            if (string.IsNullOrEmpty(preciocompra) || string.IsNullOrWhiteSpace(preciocompra))
            {
                errorProvider1.SetError(txtPrecioCompra, "Debe de ingresar un Valor");
                return;
            }

            if (Agregar)
            {
                nVariable.Agregar(new Datos.BaseDatos.Modelos.Producto()
                {
                    DescripcionProducto= txtDescripcion.Text.ToString(),
                    CategoriaId = int.Parse(cmbCategoria.SelectedValue.ToString()),
                    UnidadMedidaId = int.Parse(cmbUnidadMediad.SelectedValue.ToString()),
                    Estado = chkEstado.Checked,
                    PrecioCompra = decimal.Parse(txtPrecioCompra.Text),
                    FechaCreacion = DateTime.Now,
                });
            }
            else
            {
                nVariable.Editar(new Datos.BaseDatos.Modelos.Producto()
                {
                    ProductoId = int.Parse(id),
                    DescripcionProducto = descripcion,
                    Estado = chkEstado.Checked,
                    CategoriaId = int.Parse(cmbCategoria.SelectedValue.ToString()),
                    UnidadMedidaId = int.Parse(cmbUnidadMediad.SelectedValue.ToString()),
                    PrecioCompra = decimal.Parse(preciocompra),
                });
            }

            CargarDatos();
            LimpiarDatos();
        }
        private void LimpiarDatos()
        {
            txtID.Clear();
            txtDescripcion.Clear();
            txtPrecioCompra.Clear();
            chkEstado.Checked = false;

            Random random = new Random();
            int index1 = random.Next(0, cmbCategoria.Items.Count);
            int index2 = random.Next(0, cmbUnidadMediad.Items.Count);

            cmbCategoria.SelectedIndex = index1;
            cmbUnidadMediad.SelectedIndex = index2;
        }

        private void DGVDatos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            bool estado = Convert.ToBoolean(DGVDatos.CurrentRow.Cells["Estado"].Value);

            txtID.Text = DGVDatos.CurrentRow.Cells["ProductoId"].Value.ToString();
            txtDescripcion.Text = DGVDatos.CurrentRow.Cells["DescripcionProducto"].Value.ToString();
            dtpFechaCreacion.Text = DGVDatos.CurrentRow.Cells["FechaCreacion"].Value.ToString();
            cmbCategoria.Text = DGVDatos.CurrentRow.Cells["Descripcion"].Value.ToString();
            cmbUnidadMediad.Text = DGVDatos.CurrentRow.Cells["DescripcionUM"].Value.ToString();
            txtPrecioCompra.Text = DGVDatos.CurrentRow.Cells["PrecioCompra"].Value.ToString();
            chkEstado.Checked = estado;
        }

        private void rbTodas_CheckedChanged(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void rbActivas_CheckedChanged(object sender, EventArgs e)
        {
            DGVDatos.DataSource = nVariable.RegistrosActivos();
        }

        private void rbInactivas_CheckedChanged(object sender, EventArgs e)
        {
            DGVDatos.DataSource = nVariable.RegistrosInactivos();
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            var id = txtID.Text.ToString();

            if (string.IsNullOrEmpty(id) || string.IsNullOrWhiteSpace(id))
            {
                return;
            }
            nVariable.EliminarRegistro(int.Parse(id));
            CargarDatos();
            LimpiarDatos();
        }
    }
}
