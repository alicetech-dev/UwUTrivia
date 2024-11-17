using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace AsK
{
    public partial class login : Form
    {
        private int jugadorId;
        private int personajeFotoIdFK;

        public login()
        {
            InitializeComponent();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            juego jg = new juego();
            DataTable resultado = new DataTable();
            try
            {
                resultado = jg.VerificaUsuario(textBoxEmail.Text, textBoxPassword.Text);
                if (resultado.Rows.Count > 0)
                {
                    //jugadorId = Convert.ToInt32(resultado.Rows[0]["JUGADOR_ID"]);
                    //personajeFotoIdFK = Convert.ToInt32(resultado.Rows[0]["JUGADOR_PERSONAJE_IMAGEN_FK"]);

                    principal f = new principal(jugadorId); // Pásale el personajeFotoIdFK
                    f.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error al ingresar, no se encuentra el usuario o no corresponde a contraseña, intente again");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            titulo f = new titulo();
            f.Show();
            this.Close();
        }
    }
}
