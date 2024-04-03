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
    public partial class VistaMenu : Form
    {
        public VistaMenu()
        {
            InitializeComponent();
        }

        private void categoriaDeProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VistaCategoria vista = new VistaCategoria();
            vista.MdiParent = this;
            vista.Show();
        }

        private void grupoDeDescuentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VistaGrupoDescuentos vista = new VistaGrupoDescuentos();
            vista.MdiParent = this;
            vista.Show();
        }

        private void condicionDePagosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VistaCondicionPagos vista = new VistaCondicionPagos();
            vista.MdiParent = this;
            vista.Show();
        }

        private void unidadesDeMedidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VistaUnidadMedida vista = new VistaUnidadMedida();
            vista.MdiParent = this;
            vista.Show();
        }

        private void listadoDeClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VistaCliente vista = new VistaCliente();
            vista.MdiParent = this;
            vista.Show();
        }

        private void listadoDeProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VistaProductos vista = new VistaProductos();
            vista.MdiParent = this;
            vista.Show();
        }
    }
}
