using System;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsK
{
    public partial class admin : Form
    {
        public admin()
        {
            InitializeComponent();

            dgvPlayers.BorderStyle = BorderStyle.None;
            
            dgvPlayers.RowPrePaint += dgvPlayers_RowPrePaint2; // activar el color alternado en las filas
            CargarJugadoresEnComboBox(); //llama al metodo aqui en el constructor para que cargue al principio
        }

        private async void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                Jugador datatable = new Jugador();
                DataTable dt = await Task.Run(() => datatable.ObtenerTodosLosJugadores());

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No se encontraron Jugadores en la base de datos.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Cargar los jugadores al DataGridView
                    dgvPlayers.DataSource = dt;
                    // Configurar encabezadosdgvPlayers.Columns["JUGADOR_NOMBRE"].HeaderText = "Nombre";
                    dgvPlayers.Columns["JUGADOR_ID"].HeaderText = "ID";
                    dgvPlayers.Columns["JUGADOR_NOMBRE"].HeaderText = "Nombre";
                    dgvPlayers.Columns["JUGADOR_EMAIL"].HeaderText = "Email";
                    dgvPlayers.Columns["JUGADOR_PASSWORD"].HeaderText = "Password";
                    dgvPlayers.Columns["JUGADOR_PUNTAJE"].HeaderText = "Puntaje";
                    dgvPlayers.Columns["JUGADOR_NIVEL"].HeaderText = "Nivel";
                    dgvPlayers.Columns["JUGADOR_ROL_FK"].HeaderText = "Rol";
                    dgvPlayers.Columns["JUGADOR_PERSONAJE_IMAGEN_FK"].HeaderText = "Personaje";
                    

                    // Ajustar el ancho de las columnas
                    dgvPlayers.Columns["JUGADOR_ID"].Width = 20;
                    dgvPlayers.Columns["JUGADOR_NOMBRE"].Width = 100;
                    dgvPlayers.Columns["JUGADOR_EMAIL"].Width = 150;
                    dgvPlayers.Columns["JUGADOR_PASSWORD"].Width = 100;
                    dgvPlayers.Columns["JUGADOR_PUNTAJE"].Width = 30;
                    dgvPlayers.Columns["JUGADOR_NIVEL"].Width = 30;
                    dgvPlayers.Columns["JUGADOR_ROL_FK"].Width = 30;
                    dgvPlayers.Columns["JUGADOR_PERSONAJE_IMAGEN_FK"].Width = 30;
                    

                    // Estilo del DataGridView
                    dgvPlayers.DefaultCellStyle.Font = new Font("Game Over", 32); // Letra "Game Over"
                    dgvPlayers.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkSlateBlue;
                    dgvPlayers.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                    dgvPlayers.ColumnHeadersDefaultCellStyle.Font = new Font("Game Over", 28, FontStyle.Bold);
                    dgvPlayers.DefaultCellStyle.SelectionBackColor = Color.MediumSlateBlue;
                    dgvPlayers.DefaultCellStyle.SelectionForeColor = Color.White;

                    // color de fondo para el DataGridView
                    dgvPlayers.BackgroundColor = Color.LightBlue; // Color de fondo
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Metodo para cargar la id del jugador y su nombre en el combobox (llama al metodo cargar jugadores en la clase jugador)

        private void CargarJugadoresEnComboBox()
        {
            try
            {
                Jugador datatable = new Jugador();
                DataTable dt = datatable.ObtenerTodosLosJugadores(); // Este método obtiene todos los jugadores desde la base de datos.

                comboBoxPlayers.DataSource = dt;
                comboBoxPlayers.DisplayMember = "JUGADOR_NOMBRE";
                comboBoxPlayers.ValueMember = "JUGADOR_ID";
                comboBoxPlayers.SelectedIndex = -1; // Para que no se seleccione ningún jugador inicialmente.
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los jugadores: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbPlayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxPlayers.SelectedValue != null)
            {
                int jugadorId = Convert.ToInt32(comboBoxPlayers.SelectedValue);

                // Obtener el jugador seleccionado desde la base de datos
                Jugador jugador = new Jugador();
                jugador = jugador.ObtenerJugadorPorId(jugadorId); 

                if (jugador != null)
                {
                    textBoxNombre.Text = jugador.Nombre;
                    textBoxEmail.Text = jugador.Email;
                    textBoxPassword.Text = jugador.Password; 
                    textBoxNivel.Text = jugador.Nivel.ToString();
                    textBoxPuntaje.Text = jugador.Puntaje.ToString();
                    textBoxRolID.Text = jugador.RolId.ToString();
                    textBoxImage.Text = jugador.PersonajeImagenFk.ToString();
                }
            }
        }



        // Método para alternar colores de las filas
        private void dgvPlayers_RowPrePaint2(object sender, DataGridViewRowPrePaintEventArgs rowEventArgs)
        {
            // Alternar colores de las filas entre morado y fucsia
            if (rowEventArgs.RowIndex % 2 == 0)
            {
                dgvPlayers.Rows[rowEventArgs.RowIndex].DefaultCellStyle.BackColor = Color.MediumPurple; // Color morado
            }
            else
            {
                dgvPlayers.Rows[rowEventArgs.RowIndex].DefaultCellStyle.BackColor = Color.Fuchsia; // Color fucsia
            }
        }

        //evento para cuando aprete el boton Erase. y que muestre el panel con el boton Borrar Activado
        private void btnErase_Click(object sender, EventArgs e)
        {
            //Evento del Boton Erase, Tiene que Mostrar El Panel
            // Mostrar el panel
            panelAdmin.Visible = true;

            // Habilitar el botón Borrar y deshabilitar los otros botones
            btnPanelErase.Enabled = true;
            btnPanelAdd.Enabled = false;
            btnPanelActualizar.Enabled = false;

            
            ClearAdminPanel();

            comboBoxPlayers.Enabled = true;  // activar el combobox players

            // asociar el elegir una opcion del combobox con el cambio en el id del jugador seleccionado
            comboBoxPlayers.SelectedIndexChanged += cmbPlayers_SelectedIndexChanged;


        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            panelAdmin.Visible = true;

            // Habilitar el botón Borrar y desactivar los otros botones
            btnPanelErase.Enabled = false;
            btnPanelAdd.Enabled = true;
            btnPanelActualizar.Enabled = false;

            // Limpiar los TextBox para añadir nuevo jugador
            textBoxNombre.Text = "";
            textBoxEmail.Text = "";
            textBoxPassword.Text = "";
            textBoxNivel.Text = "";
            textBoxPuntaje.Text = "";
            textBoxRolID.Text = "";
            textBoxImage.Text = "";
        }

        private void btnPanelAdd_Click(object sender, EventArgs e)
        {
            // Validar que todos los textbox tengan datos
            if (string.IsNullOrWhiteSpace(textBoxNombre.Text) || string.IsNullOrWhiteSpace(textBoxEmail.Text) ||
                string.IsNullOrWhiteSpace(textBoxPassword.Text) || string.IsNullOrWhiteSpace(textBoxNivel.Text) ||
                string.IsNullOrWhiteSpace(textBoxPuntaje.Text) || string.IsNullOrWhiteSpace(textBoxRolID.Text) ||
                string.IsNullOrWhiteSpace(textBoxImage.Text))
            {
                MessageBox.Show("Por favor, completa todos los campos.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // instancear la clase jugador y leer la informacion de los cuadros de texto para entregarsela al metodo
            Jugador nuevoJugador = new Jugador
            {
                Nombre = textBoxNombre.Text,
                Email = textBoxEmail.Text,
                Password = textBoxPassword.Text,  
                Nivel = int.Parse(textBoxNivel.Text),
                Puntaje = int.Parse(textBoxPuntaje.Text),
                RolId = int.Parse(textBoxRolID.Text),
                PersonajeImagenFk = int.Parse(textBoxImage.Text)
            };

            // Llamar al método para agregar el jugador
            Jugador jugador = new Jugador();
            jugador.AgregarJugadorFull(nuevoJugador);

            // Confirmar la operación
            MessageBox.Show("Jugador agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Limpiar los campos después de agregar
            Limpiartextboxs();
        }

        private void Limpiartextboxs()
        {
            textBoxNombre.Text = "";
            textBoxEmail.Text = "";
            textBoxPassword.Text = "";
            textBoxNivel.Text = "";
            textBoxPuntaje.Text = "";
            textBoxRolID.Text = "";
            textBoxImage.Text = "";
        }

        
        private void btnUpdatePlayer_Click(object sender, EventArgs e)
        {
            panelAdmin.Visible = true;

            // Habilitar el botón Borrar y desactivar los demas botones
            btnPanelErase.Enabled = false;
            btnPanelAdd.Enabled = false;
            btnPanelActualizar.Enabled = true;

            // Llenar el ComboBox con los jugadores , este metodo se llama de nuevo, por si hay que actualizar otro jugador para que se actualize tambien el contenido del combobox
            CargarJugadoresEnComboBox();

            // Habilitar el ComboBox para seleccionar el jugador a actualizar


            comboBoxPlayers.Enabled = true;

            // SelectedIndexChanged  para cargar el jugador, lo mismo que arriba asocia el selected index change con el player change
            comboBoxPlayers.SelectedIndexChanged += cmbPlayers_SelectedIndexChanged;

            //validar que se haya elegigo un jugador en el combobox

            if (comboBoxPlayers.SelectedValue != null)   // combobox debe ser distinto de null    
            {
                int jugadorId = Convert.ToInt32(comboBoxPlayers.SelectedValue); // el jugadorId recibe el valor int de comboboxplayers

                // Cargar los detalles del jugador seleccionado
                Jugador jugador = new Jugador();
                jugador = jugador.ObtenerJugadorPorId(jugadorId);  

                if (jugador != null) //jugador tambien debe ser distinto de null
                {
                    textBoxNombre.Text = jugador.Nombre;
                    textBoxEmail.Text = jugador.Email;
                    textBoxPassword.Text = jugador.Password;
                    textBoxNivel.Text = jugador.Nivel.ToString();
                    textBoxPuntaje.Text = jugador.Puntaje.ToString();
                    textBoxRolID.Text = jugador.RolId.ToString();
                    textBoxImage.Text = jugador.PersonajeImagenFk.ToString();
                }
            }
        }


        private void btnPanelActualizar_Click(object sender, EventArgs e)
        {
            // Validar que un jugador esté seleccionado en el ComboBox

            if (comboBoxPlayers.SelectedValue == null)
            {
                MessageBox.Show("Por favor, selecciona un jugador para actualizar.", "Jugador no seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            if (string.IsNullOrWhiteSpace(textBoxNombre.Text) || string.IsNullOrWhiteSpace(textBoxEmail.Text) ||
                string.IsNullOrWhiteSpace(textBoxPassword.Text) || string.IsNullOrWhiteSpace(textBoxNivel.Text) ||
                string.IsNullOrWhiteSpace(textBoxPuntaje.Text) || string.IsNullOrWhiteSpace(textBoxRolID.Text) ||
                string.IsNullOrWhiteSpace(textBoxImage.Text))
            {
                MessageBox.Show("Por favor, completa todos los campos.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Obtener el ID del jugador seleccionado en el ComboBox
            int jugadorId = Convert.ToInt32(comboBoxPlayers.SelectedValue);

            // Crear un objeto Jugador con la información actualizada de los TextBox
            Jugador jugadorActualizado = new Jugador
            {
                JugadorId = jugadorId,  // ID del jugador que se va a actualizar
                Nombre = textBoxNombre.Text,
                Email = textBoxEmail.Text,
                Password = textBoxPassword.Text,  // Si se maneja password
                Nivel = int.Parse(textBoxNivel.Text),
                Puntaje = int.Parse(textBoxPuntaje.Text),
                RolId = int.Parse(textBoxRolID.Text),
                PersonajeImagenFk = int.Parse(textBoxImage.Text)
            };

            // Llamar al método para actualizar el jugador
            Jugador jugador = new Jugador();
            jugador.ActualizarJugador(jugadorActualizado);

            
            MessageBox.Show("Jugador actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            
            Limpiartextboxs();
        }


        //para borrar el jugador con el id. Una vez que se desplego el formulario.

        private void btnPanelErase_Click(object sender, EventArgs e)
        {
            if (comboBoxPlayers.SelectedValue != null)
            {
                int jugadorId = Convert.ToInt32(comboBoxPlayers.SelectedValue);

                //confirmar
                var confirmResult = MessageBox.Show("¿Estás segurisimo de que deseas borrar este Player?",
                                                     "Confirmación de Borrado",
                                                     MessageBoxButtons.YesNo,
                                                     MessageBoxIcon.Warning);

                if (confirmResult == DialogResult.Yes)
                {
                    // instancéa  la clase Jugador y llama al método de borrado que esta en jugador.cs
                    Jugador jugador = new Jugador();
                    jugador.BorrarJugador(jugadorId);

                    // Mensaje de éxito
                    MessageBox.Show("Jugador borrado exitosamente.");

                    //Limpiar los TextBox
                    textBoxNombre.Clear();
                    textBoxEmail.Clear();
                    textBoxPassword.Clear();
                    textBoxNivel.Clear();
                    textBoxPuntaje.Clear();
                    textBoxRolID.Clear();
                    textBoxImage.Clear();

                    // Actualizar el ComboBox 
                    CargarJugadoresEnComboBox(); 
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un jugador para borrar.");
            }
        }

       
        // Método para limpiar todos los textbox
        private void ClearAdminPanel()
        {
            textBoxNombre.Text = "";
            textBoxEmail.Text = "";
            textBoxPassword.Text = "";
            textBoxNivel.Text = "";
            textBoxPuntaje.Text = "";
            textBoxRolID.Text = "";
            textBoxImage.Text = "";
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    
}
