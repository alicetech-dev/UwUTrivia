using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsK
{
    public partial class authadmin : Form
    {
        public authadmin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Verificar. aqui se define el usuario y password de admin. directo en el codigo.(hardcoded) si se quisiera hacer con base de datos
            //habria que llamar a un procedimiento almacenado y verificar. (pero ya es too much)
            if (txtUsuario.Text == "admin" && txtPassword.Text == "admin123")  
            {
                // Cerrar el formulario con resultado OK si los datos son correctos
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                // Mostrar un mensaje de error si los datos el admin son incorrectos
                MessageBox.Show("Credenciales incorrectas. Inténtelo nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }
    }
}
