using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Datos.BaseDatos.Modelos
{
    public class Login
    {
        [Key]
        public int UsuarioId { get; set; }

        [Required]
        public string UsuarioLogin { get; set; }

        [Required]
        public string Nombre { get; set; }

        public string Clave { get; set; }
        public bool Estado { get; set; }


        public Login() { }
        public Login(string user, string contra)
        {
            UsuarioLogin = user;
            Clave = contra;
        }

        public bool VerificarUsuario()
        {
            bool usuarioValido = false;

            MarketContex conexion = new MarketContex();
            SqlConnection sqlCon = conexion.GetConexion();

            try
            {
                sqlCon.Open();

                string consulta = "SELECT COUNT(*) FROM Login WHERE UsuarioLogin = @Usuario AND Clave = @Clave";

                using (SqlCommand cmd = new SqlCommand(consulta, sqlCon))
                {
                    cmd.Parameters.AddWithValue("@Usuario", UsuarioLogin);
                    cmd.Parameters.AddWithValue("@Clave", Clave);

                    int count = (int)cmd.ExecuteScalar();

                    usuarioValido = count > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlCon.Close();
            }

            return usuarioValido;
        }

    }
}
