using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient; // Importar System.Data.SqlClient
using System.Configuration;

namespace AsK
{
    public partial class NewGame : Form
    {
        // Variables globales para personajes y el índice
        private List<Personaje> personajes;
        private int indexPersonaje = 0;
        private int personajeFotoIdFK; // Variable para almacenar el ID de la imagen del personaje

        public NewGame()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.NewGame_Load);
        }

        // Método para cargar un personaje en el formulario
        private void CargarPersonaje()
        {
            if (personajes.Count > 0)
            {
                // Obtener la ruta base del proyecto
                string rutaBase = Application.StartupPath;

                // Concatenar con la ruta relativa de la imagen del personaje
                string rutaImagen = System.IO.Path.Combine(rutaBase, personajes[indexPersonaje].RutaImagen.Replace("/", "\\"));

                // Verificar si la imagen existe
                if (System.IO.File.Exists(rutaImagen))
                {
                    pbPersonaje.Image = Image.FromFile(rutaImagen);
                }
                else
                {
                    MessageBox.Show("No se encontró la imagen: " + rutaImagen);
                }

                // Mostrar el nombre del personaje
                lblNombrePersonaje.Text = personajes[indexPersonaje].Nombre;

                // Mostrar la biografía del personaje en el RichTextBox
                rtbBiografiaPersonaje.Text = personajes[indexPersonaje].Biografia;
            }
            else
            {
                MessageBox.Show("No se encontraron personajes.");
            }
        }

        // cargar los personajes para que esten listos para elegir, cuando se abra este formulario NewGame
        private void NewGame_Load(object sender, EventArgs e)
        {
            // Llamar al método que obtiene los personajes desde la base de datos
            personajes = Personaje.ObtenerPersonajes();

            if (personajes.Count > 0)
            {
                CargarPersonaje(); // Mostrar el primer personaje
            }
        }

        // Evento del botón Guardar
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener los datos del formulario
                string nombre = textBoxNombre.Text.Trim();
                string email = textBoxCorreo.Text.Trim();
                string password = textBoxPassword.Text;
                int personajeId = personajes[indexPersonaje].Id;

                // Validar que no esten vacios los textbox nombre, email y password.
                if (string.IsNullOrWhiteSpace(nombre))
                {
                    MessageBox.Show("El campo 'Nombre' es obligatorio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxNombre.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(email))
                {
                    MessageBox.Show("El campo 'Correo electrónico' es obligatorio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxCorreo.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(password))
                {
                    MessageBox.Show("El campo 'Contraseña' es obligatorio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxPassword.Focus();
                    return;
                }

                // Obtener la conexión a la base de datos
                string miconexion = ConfigurationManager.ConnectionStrings["LOCAL"].ConnectionString;

                // Agregar el nuevo jugador y obtener el ID del jugador y el ID de la imagen del personaje
                using (SqlConnection conn = new SqlConnection(miconexion))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SP_AgregarJugadorYObtenerPersonajeId", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Nombre", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Nombre"].Value = nombre;
                    cmd.Parameters.Add("@Email", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Email"].Value = email;
                    cmd.Parameters.Add("@Password", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Password"].Value = password;
                    cmd.Parameters.Add("@Nivel", SqlDbType.Int).Value = 1; // Nivel predeterminado
                    cmd.Parameters.Add("@Puntaje", SqlDbType.Int).Value = 0; // Puntaje inicial
                    cmd.Parameters.Add("@RolId", SqlDbType.Int).Value = 1; // Rol predeterminado es 1 "Jugador"
                    cmd.Parameters.Add("@PersonajeId", SqlDbType.Int);
                    cmd.Parameters["@PersonajeId"].Value = personajeId;

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        int jugadorId = Convert.ToInt32(reader["JugadorId"]);
                        personajeFotoIdFK = Convert.ToInt32(reader["PersonajeId"]);

                        // Abrir el siguiente formulario y cerrar este
                        principal f = new principal(jugadorId);
                        f.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Error al guardar el jugador.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el jugador: " + ex.Message);
            }
        }

        // Evento del botón Anterior para cambiar el personaje
        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (indexPersonaje > 0)
            {
                indexPersonaje--;
                CargarPersonaje(); // Cargar el personaje anterior
            }
        }

        // Evento del botón Siguiente para cambiar el personaje
        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (indexPersonaje < personajes.Count - 1)
            {
                indexPersonaje++;
                CargarPersonaje(); // Cargar el siguiente personaje
            }
        }
    }
}
