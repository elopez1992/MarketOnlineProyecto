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
    public partial class VistaGrupoDescuentos : Form
    {
        private NGrupoDescuentos nGrupo;
        public VistaGrupoDescuentos()
        {
            InitializeComponent();
            nGrupo = new NGrupoDescuentos();
        }

        private void VistaGrupoDescuentos_Load(object sender, EventArgs e)
        {
            CargarDatos();
            DataGridView();
        }

        private void CargarDatos()
        {
            var grupo = nGrupo.obtenerGrupos().Select(c => new { c.GrupoDescuentoId, c.Codigo, c.DescripcionGD, c.Estado, c.Porcentaje, c.FechaCreacionGD });

            DGVDatos.DataSource = grupo.ToList();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var Agregar = false;
            var grupodescuentoId = txtID.Text.ToString();

            var codigo = txtCodigo.Text.ToString();
            var descripcion = txtDescripcion.Text.ToString();
            var porcentaje = txtPorcentaje.Text.ToString();

            if (string.IsNullOrEmpty(grupodescuentoId) || string.IsNullOrWhiteSpace(grupodescuentoId))
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
            if (string.IsNullOrEmpty(porcentaje) || string.IsNullOrWhiteSpace(porcentaje))
            {
                errorProvider1.SetError(txtDescripcion, "Debe de ingresar un Porcentaje");
                return;
            }

            if (Agregar)
            {
                nGrupo.Agregar(new Datos.BaseDatos.Modelos.GrupoDescuento()
                {
                    Codigo = txtCodigo.Text.ToString(),
                    DescripcionGD = txtDescripcion.Text.ToString(),
                    Estado = chkEstado.Checked,
                    Porcentaje = int.Parse(txtPorcentaje.Text),
                    FechaCreacionGD = DateTime.Now,
                });
            }
            else
            {
                nGrupo.EditarGrupoDescuento(new Datos.BaseDatos.Modelos.GrupoDescuento()
                {
                    GrupoDescuentoId = int.Parse(grupodescuentoId),
                    Codigo = codigo,
                    DescripcionGD = descripcion,
                    Porcentaje = int.Parse(porcentaje),
                    Estado = chkEstado.Checked,
                });
            }

            CargarDatos();
            LimpiarDatos();
        }

        private void LimpiarDatos()
        {
            txtID.Clear();
            txtCodigo.Clear();
            txtDescripcion.Clear();
            txtPorcentaje.Clear();
            chkEstado.Checked = false;

            dtpFechaCreacion.Value = DateTime.Now;
        }

        private void DGVDatos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            bool estado = Convert.ToBoolean(DGVDatos.CurrentRow.Cells["Estado"].Value);

            txtID.Text = DGVDatos.CurrentRow.Cells["GrupoDescuentoId"].Value.ToString();
            txtCodigo.Text = DGVDatos.CurrentRow.Cells["Codigo"].Value.ToString();
            txtDescripcion.Text = DGVDatos.CurrentRow.Cells["DescripcionGD"].Value.ToString();
            txtPorcentaje.Text = DGVDatos.CurrentRow.Cells["Porcentaje"].Value.ToString();
            dtpFechaCreacion.Text = DGVDatos.CurrentRow.Cells["FechaCreacionGD"].Value.ToString();
            chkEstado.Checked = estado;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            var id = txtID.Text.ToString();

            if (string.IsNullOrEmpty(id) || string.IsNullOrWhiteSpace(id))
            {
                return;
            }
            nGrupo.EliminarGrupoDescuento(int.Parse(id));
            CargarDatos();
            LimpiarDatos();
        }

        private void rbTodas_CheckedChanged(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void rbActivas_CheckedChanged(object sender, EventArgs e)
        {
            DGVDatos.DataSource = nGrupo.GrupoDescuentoActivas();
        }

        private void rbInactivas_CheckedChanged(object sender, EventArgs e)
        {
            DGVDatos.DataSource = nGrupo.GrupoDescuentoInactivas();
        }

        public void DataGridView()
        {
            DGVDatos.Columns["GrupoDescuentoId"].Width = 100;
            DGVDatos.Columns["Codigo"].Width = 150;
            DGVDatos.Columns["DescripcionGD"].Width = 135;
            DGVDatos.Columns["Porcentaje"].Width = 80;
            DGVDatos.Columns["FechaCreacionGD"].Width = 100;
            DGVDatos.Columns["Estado"].Width = 80;
        }
    }
}
