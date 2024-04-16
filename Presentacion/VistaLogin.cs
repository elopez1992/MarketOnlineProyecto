using Datos;
using Datos.BaseDatos.Modelos;
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
    public partial class VistaLogin : Form
    {
        public DLogin nvariable;
        public VistaLogin()
        {
            InitializeComponent();
            nvariable = new DLogin();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            Ingresar();
        }

        Boolean validar()
        {
            bool valida = true;
            if (string.IsNullOrEmpty(txtContraseña.Text))
            {
                valida = false;
                MessageBox.Show("Debe de ingresar el Usuario..!");
                txtContraseña.Focus();
            }
            else
            {
                if (string.IsNullOrEmpty(txtUsuario.Text))
                {
                    valida = false;
                    MessageBox.Show("Debe de ingresar la contraseña del usuario..!");
                    txtUsuario.Focus();
                }
                else
                {

                }
            }
            return valida;
        }

        void Ingresar()
        {
            if (validar() == true)
            {
                Login admin = new Login(txtContraseña.Text, txtUsuario.Text);

                bool usuarioValido = admin.VerificarUsuario();

                if (usuarioValido)
                {

                    Form formulario = new VistaMenu();
                    formulario.Show();
                }
                else
                {
                    MessageBox.Show("Usuario y/o contraseña incorrectos. Acceso denegado.");
                }
            }

        }
        private void VistaLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
