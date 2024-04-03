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
    public partial class VistaCliente : Form
    {
        private NCliente nVariable;
        private NGrupoDescuentos nGrupo;
        private NCondicionPago nCondicion;

        public VistaCliente()
        {
            InitializeComponent();
            nVariable = new NCliente();
            nGrupo = new NGrupoDescuentos();
            nCondicion = new NCondicionPago();
        }

        private void VistaCliente_Load(object sender, EventArgs e)
        {
            CargarDatos();
            CargarCombobox();
        }

        private void CargarDatos()
        {
            var grupo = nVariable.obtenerClientes().Select(c => new { c.ClienteId, c.Codigo, c.Nombres, c.Apellidos, c.Estado, /*c.GrupoDescuentoId,*/ c.grupodescuento.DescripcionGD, /*c.CondicionPagoId,*/ c.condionpago.DescripcionCP, c.FechaCreacion });

            DGVDatos.DataSource = grupo.ToList();
        }

        private void CargarCombobox()
        {
            // Grupo de Descuentos
            cmbDescuento.DataSource = nGrupo.GrupoDescuentoActivas()
                                          .Select(c => new { c.GrupoDescuentoId, c.DescripcionGD }).ToList();

            cmbDescuento.ValueMember = "GrupoDescuentoId";
            cmbDescuento.DisplayMember = "DescripcionGD";


            // Condicion de Pagos
            cmbPagos.DataSource = nCondicion.RegistrosActivos()
                              .Select(c => new { c.CondicionPagoId, c.DescripcionCP }).ToList();

            cmbPagos.ValueMember = "CondicionPagoId";
            cmbPagos.DisplayMember = "DescripcionCP";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var Agregar = false;
            var id = txtID.Text.ToString();

            var codigo = txtCodigo.Text.ToString();
            var Nombres = txtNombres.Text.ToString();
            var Apellidos = txtApellido.Text.ToString();

            if (string.IsNullOrEmpty(id) || string.IsNullOrWhiteSpace(id))
            {
                Agregar = true;
            }

            if (string.IsNullOrEmpty(codigo) || string.IsNullOrWhiteSpace(codigo))
            {
                errorProvider1.SetError(txtCodigo, "Debe de ingresar un Codigo");
                return;
            }
            if (string.IsNullOrEmpty(Nombres) || string.IsNullOrWhiteSpace(Nombres))
            {
                errorProvider1.SetError(txtNombres, "Debe de ingresa los Nombres");
                return;
            }
            if (string.IsNullOrEmpty(Apellidos) || string.IsNullOrWhiteSpace(Apellidos))
            {
                errorProvider1.SetError(txtApellido, "Debe de ingresar los Apellidos");
                return;
            }

            if (Agregar)
            {
                nVariable.Agregar(new Datos.BaseDatos.Modelos.Cliente()
                {
                    Codigo = txtCodigo.Text.ToString(),
                    Nombres = txtNombres.Text.ToString(),
                    Apellidos = txtApellido.Text.ToString(),
                    GrupoDescuentoId = int.Parse(cmbDescuento.SelectedValue.ToString()),
                    CondicionPagoId = int.Parse(cmbPagos.SelectedValue.ToString()),
                    Estado = chkEstado.Checked,
                    FechaCreacion = DateTime.Now,
                });
            }
            else
            {
                nVariable.Editar(new Datos.BaseDatos.Modelos.Cliente()
                {
                    ClienteId = int.Parse(id),
                    Codigo = codigo,
                    Nombres = Nombres,
                    Apellidos = Apellidos,
                    Estado = chkEstado.Checked,
                    GrupoDescuentoId = int.Parse(cmbDescuento.SelectedValue.ToString()),
                    CondicionPagoId = int.Parse(cmbPagos.SelectedValue.ToString()),
                });
            }

            CargarDatos();
            LimpiarDatos();
        }

        private void LimpiarDatos()
        {
            txtID.Clear();
            txtCodigo.Clear();
            txtNombres.Clear();
            txtApellido.Clear();
            chkEstado.Checked = false;

            Random random = new Random();
            int index1 = random.Next(0, cmbDescuento.Items.Count);
            int index2 = random.Next(0, cmbPagos.Items.Count);

            cmbDescuento.SelectedIndex = index1;
            cmbPagos.SelectedIndex = index2;
        }

        private void DGVDatos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            bool estado = Convert.ToBoolean(DGVDatos.CurrentRow.Cells["Estado"].Value);

            txtID.Text = DGVDatos.CurrentRow.Cells["ClienteId"].Value.ToString();
            txtCodigo.Text = DGVDatos.CurrentRow.Cells["Codigo"].Value.ToString();
            txtNombres.Text = DGVDatos.CurrentRow.Cells["Nombres"].Value.ToString();
            txtApellido.Text = DGVDatos.CurrentRow.Cells["Apellidos"].Value.ToString();
            dtpFechaCreacion.Text = DGVDatos.CurrentRow.Cells["FechaCreacion"].Value.ToString();
            cmbDescuento.Text = DGVDatos.CurrentRow.Cells["DescripcionGD"].Value.ToString();
            cmbPagos.Text = DGVDatos.CurrentRow.Cells["DescripcionCP"].Value.ToString();
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
    }
}
