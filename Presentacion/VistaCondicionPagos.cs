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
    public partial class VistaCondicionPagos : Form
    {
        private NCondicionPago nVariable;
        public VistaCondicionPagos()
        {
            InitializeComponent();
            nVariable = new NCondicionPago();
        }

        private void VistaCondicionPagos_Load(object sender, EventArgs e)
        {
            CargarDatos();
            DataGridView();
        }

        private void CargarDatos()
        {
            var grupo = nVariable.obtenerGrupos().Select(c => new { c.CondicionPagoId, c.Codigo, c.DescripcionCP, c.Estado, c.Dias, c.FechaCreacionCP });

            DGVDatos.DataSource = grupo.ToList();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var Agregar = false;
            var id = txtID.Text.ToString();

            var codigo = txtCodigo.Text.ToString();
            var descripcion = txtDescripcion.Text.ToString();
            var dias = txtDias.Text.ToString();

            if (string.IsNullOrEmpty(id) || string.IsNullOrWhiteSpace(id))
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
            if (string.IsNullOrEmpty(dias) || string.IsNullOrWhiteSpace(dias))
            {
                errorProvider1.SetError(txtDias, "Debe de ingresar los Dias");
                return;
            }

            if (Agregar)
            {
                nVariable.Agregar(new Datos.BaseDatos.Modelos.CondicionPago()
                {
                    Codigo = txtCodigo.Text.ToString(),
                    DescripcionCP = txtDescripcion.Text.ToString(),
                    Estado = chkEstado.Checked,
                    Dias = int.Parse(txtDias.Text),
                    FechaCreacionCP = DateTime.Now,
                });
            }
            else
            {
                nVariable.Editar(new Datos.BaseDatos.Modelos.CondicionPago()
                {
                    CondicionPagoId = int.Parse(id),
                    Codigo = codigo,
                    DescripcionCP = descripcion,
                    Dias = int.Parse(dias),
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
            txtDias.Clear();
            chkEstado.Checked = false;

            dtpFechaCreacion.Value = DateTime.Now;
        }

        private void DGVDatos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            bool estado = Convert.ToBoolean(DGVDatos.CurrentRow.Cells["Estado"].Value);

            txtID.Text = DGVDatos.CurrentRow.Cells["CondicionPagoId"].Value.ToString();
            txtCodigo.Text = DGVDatos.CurrentRow.Cells["Codigo"].Value.ToString();
            txtDescripcion.Text = DGVDatos.CurrentRow.Cells["DescripcionCP"].Value.ToString();
            txtDias.Text = DGVDatos.CurrentRow.Cells["Dias"].Value.ToString();
            dtpFechaCreacion.Text = DGVDatos.CurrentRow.Cells["FechaCreacionCP"].Value.ToString();
            chkEstado.Checked = estado;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
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

        public void DataGridView()
        {
            DGVDatos.Columns["CondicionPagoId"].Width = 100;
            DGVDatos.Columns["Codigo"].Width = 150;
            DGVDatos.Columns["DescripcionCP"].Width = 135;
            DGVDatos.Columns["Dias"].Width = 80;
            DGVDatos.Columns["FechaCreacionCP"].Width = 100;
            DGVDatos.Columns["Estado"].Width = 80;
        }
    }
}
