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
    public partial class VistaCategorias : Form
    {
        private NCategorias nCategorias;
        public VistaCategorias()
        {
            InitializeComponent();
            nCategorias = new NCategorias();
        }

        private void VistaCategorias_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            var categoria = nCategorias.obtenerCategorias().Select(c => new { c.CategoriaId, c.Codigo, c.Descripcion, c.Estado, c.FechaCreacion });

            //DGVCategorias.DataSource = nCategorias.obtenerCategorias();

            DGVCategorias.DataSource = categoria.ToList();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var Agregar = false;
            var CategoriaId = txtCategoriaId.Text.ToString();

            var codigo = txtCodigo.Text.ToString();
            var descripcion = txtDescripcion.Text.ToString();

            if (string.IsNullOrEmpty(CategoriaId) || string.IsNullOrWhiteSpace(CategoriaId))
            {
                Agregar = true;
            }

            if (string.IsNullOrEmpty(codigo) || string.IsNullOrWhiteSpace(codigo))
            {
                errorProvider1.SetError(txtCodigo, "Debe de ingresar un Codigo");
                return;
            }
            if (string.IsNullOrEmpty(descripcion) || string.IsNullOrWhiteSpace(descripcion))
            {
                errorProvider1.SetError(txtDescripcion, "Debe de ingresar una Descripcion");
                return;
            }

            if (Agregar)
            {
                nCategorias.Agregar(new Datos.BaseDatos.Modelos.Categoria()
                {
                    Codigo = txtCodigo.Text.ToString(),
                    Descripcion = txtDescripcion.Text.ToString(),
                    Estado = chkEstado.Checked,
                    FechaCreacion = DateTime.Now,
                });
            }
            else
            {
                nCategorias.EditarCategoria(new Datos.BaseDatos.Modelos.Categoria()
                {
                    CategoriaId = int.Parse(CategoriaId),
                    Codigo = codigo,
                    Descripcion = descripcion,
                    Estado = chkEstado.Checked,
                    FechaCreacion = DateTime.Now,
                });
            }

            CargarDatos();
            LimpiarDatos();
        }

        public void LimpiarDatos()
        {
            txtCategoriaId.Clear();
            txtCodigo.Clear();
            txtDescripcion.Clear();
            chkEstado.Checked = false;

            dtpFechaCreacion.Value = DateTime.Now;
        }

        private void DGVCategorias_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            bool estado = Convert.ToBoolean(DGVCategorias.CurrentRow.Cells["Estado"].Value);

            txtCategoriaId.Text = DGVCategorias.CurrentRow.Cells["CategoriaId"].Value.ToString();
            txtCodigo.Text = DGVCategorias.CurrentRow.Cells["Codigo"].Value.ToString();
            txtDescripcion.Text = DGVCategorias.CurrentRow.Cells["Descripcion"].Value.ToString();
            dtpFechaCreacion.Text = DGVCategorias.CurrentRow.Cells["FechaCreacion"].Value.ToString();
            chkEstado.Checked = estado;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            var categoriaId = txtCategoriaId.Text.ToString();

            if (string.IsNullOrEmpty(categoriaId) || string.IsNullOrWhiteSpace(categoriaId))
            {
                return;
            }
            nCategorias.EliminarCategoria(int.Parse(categoriaId));
            CargarDatos();
            LimpiarDatos();
        }

        private void rbTodas_CheckedChanged(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void rbActivas_CheckedChanged(object sender, EventArgs e)
        {
            DGVCategorias.DataSource = nCategorias.CategoriasActivas();
        }

        private void rbInactivas_CheckedChanged(object sender, EventArgs e)
        {
            DGVCategorias.DataSource = nCategorias.CategoriasInactivas();
        }
    }
}
