/*  este maingame es el que mas problemas esta dando, pero ya tengo una idea de los cambios que hay que hacer, los ire anotando aca
 *  1- modificar el procedimiento almacenado para que liste las preguntas de la base de dato, segun el nivel de dificultad y la categoria. no solo por el niel
2- seleccionar el avatar del personaje, llamando al procedimiento segun el id del jugador y el Jugador_personaje_id_fk
3- cambiar los puntajes de las respuestas, no segun el nivel del jugador. sino que segun el nivel de dificultad de la pregunta, esto se selecciona en el formulario opciones, pero tambien cada
pregunta tiene una propiedad DICULTAD_ID_FK en la base de datos que es intrinseca a la pregunta.
el principal problema con la aplicacion esta en el codigo de esta clase maingame.cs que hace que no funcione.
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; 
using System.Configuration;

namespace AsK
{
    public partial class maingame : Form
    {
        private int jugadorId;
        private int nivelDificultad;
        private int categoriaId;
        private int personajeFotoIdFK;

        public maingame(int jugadorId, int selectedNivel, int selectedCategoria, int personajeFotoIdFK)  
         {
            InitializeComponent();
            //this.jugadorId = jugadorId;
            this.nivelDificultad = selectedNivel;
            this.categoriaId = selectedCategoria;
            //this.personajeFotoIdFK = personajeFotoIdFK;
        }
        private void maingame_Load(object sender, EventArgs e)
        {

            /*if (Pregunta.VerificarConexion()) // Agrega el método VerificarConexion en Pregunta.cs
            {
                ObtenerPersonajesPorJugador();
                CargarNuevaPregunta();

                
            }
            else
            {
                MessageBox.Show("Error al conectar con la base de datos.");
                return; // Detener la carga del formulario si hay un error
            }
            

            // Configurar el temporizador
            gameTimer = new System.Windows.Forms.Timer();
            gameTimer.Interval = 1000;
            gameTimer.Tick += new EventHandler(Timer_Tick);
            gameTimer.Start();
        
            */
        }
        /*public void CargarNuevaPregunta()
        {
            Jugador jugador = new Jugador();
            

            // Obtener la pregunta para el nivel de dificultad y categoria seleccionados
            var pregunta = Pregunta.ObtenerPreguntaPorNivelYCategoria(nivelDificultad, categoriaId);

            if (pregunta != null)
            {
                // Mostrar la pregunta
                richTextBoxPregunta.Text = pregunta.Texto;

                // Cargar la imagen de la pregunta o una imagen por defecto
                pictureBoxImagen.Image = pregunta.RutaImagen != null ?
                    Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, pregunta.RutaImagen)) :
                    Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "img/defaultquestion.jpg"));

                // Cargar las alternativas
                var alternativas = Alternativa.ObtenerAlternativasPorPregunta(pregunta.Id);
                comboBoxAlternativas.Items.Clear();
                foreach (var alternativa in alternativas)
                {
                    comboBoxAlternativas.Items.Add(alternativa.Texto);
                }

                comboBoxAlternativas.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("No se encontró ninguna pregunta para este nivel.");
            }
        }
        */
        private void ObtenerPersonajesPorJugador()
        {
            Jugador jugador = new Jugador();
            

            var personajeObtenido = Personaje.ObtenerPersonajePorJugador(jugadorId); // Llama al método estático

            if (personajeObtenido != null)
            {
                pictureBoxPersonaje.Image = Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, personajeObtenido.RutaImagen));
            }
            else
            {
                pictureBoxPersonaje.Image = Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "img/defaultcharacter.jpg"));
            }

            // Establecer el nivel del jugador
            textBoxNivel.Text = jugador.Nivel.ToString();
            textBoxPuntaje.Text = jugador.Puntaje.ToString();
        }



        private void DesbloquearItems()
        {
            Jugador jugador = new Jugador();
            int itemsDesbloqueados = jugador.Puntaje / 50;

            if (itemsDesbloqueados > 0 && itemsDesbloqueados <= 6)
            {
                for (int i = 1; i <= itemsDesbloqueados; i++)
                {
                    var pictureBox = this.Controls.Find($"pictureBoxItem{i}", true).FirstOrDefault() as PictureBox;
                    if (pictureBox != null)
                    {
                        pictureBox.Image = Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"img/item{i}.jpg"));
                    }
                }
            }
        }
        private System.Windows.Forms.Timer gameTimer;
        private int remainingTime = 600;



        private void Timer_Tick(object sender, EventArgs e)
        {
            remainingTime--;
            textBoxTimer.Text = TimeSpan.FromSeconds(remainingTime).ToString(@"mm\:ss");

            if (remainingTime <= 0)
            {
                gameTimer.Stop();
                MessageBox.Show("Se ha acabado el tiempo. Fin del juego.");
                this.Close();
            }
        }


        private void btnBack_Click(object sender, EventArgs e)
        {
            titulo f = new titulo();
            f.Show();
            this.Close();
        }


        /*private void btnResponder_Click(object sender, EventArgs e)
        {
            Pregunta pregunta = new Pregunta(); // Necesitas instanciar la pregunta
            Jugador jugador = new Jugador();
            var alternativaSeleccionada = comboBoxAlternativas.SelectedItem.ToString();
            var esCorrecta = Pregunta.VerificarRespuestaCorrecta(pregunta.Id, alternativaSeleccionada);

            if (esCorrecta)
            {
                // Sumar puntaje según el nivel de dificultad de la pregunta contestada
                int puntajeAOtorgar = 0;
                switch (nivelDificultad)
                {
                    case 1: // Fácil
                        puntajeAOtorgar = 5;
                        break;
                    case 2: // Medio
                        puntajeAOtorgar = 10;
                        break;
                    case 3: // Difícil
                        puntajeAOtorgar = 15;
                        break;
                    case 4: // Genio
                        puntajeAOtorgar = 20;
                        break;
                }

                jugador.ActualizarPuntaje(puntajeAOtorgar);
                textBoxPuntaje.Text = jugador.Puntaje.ToString();

                // Verificar desbloqueo de ítems
                DesbloquearItems();

                // Cargar nueva pregunta
                CargarNuevaPregunta();
            }
            else
            {
                MessageBox.Show("Respuesta incorrecta.");
            }
        
        }
        */
    }
}
