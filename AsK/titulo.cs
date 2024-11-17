using System;
using System.Windows.Forms;
using NAudio.Wave; // Necesitas instalar NAudio con NuGet (Install-Package NAudio)
using Microsoft.VisualBasic;


namespace AsK
{
    public partial class titulo : Form
    {
        // Variables estáticas para el reproductor de audio
        private static IWavePlayer waveOut;
        private static AudioFileReader audioFileReader;

        public titulo()
        {
            InitializeComponent();

            // Inicializa el reproductor solo si aún no está inicializado
            if (waveOut == null && audioFileReader == null)
            {
                waveOut = new WaveOutEvent();
                audioFileReader = new AudioFileReader("background.mp3"); // Cambia a .wav si es necesario

                // Configura el evento PlaybackStopped para volver a reproducir la música en bucle
                waveOut.PlaybackStopped += OnPlaybackStopped;

                waveOut.Init(audioFileReader);
                waveOut.Play(); // Inicia la reproducción
            }
        }

        private void OnPlaybackStopped(object sender, StoppedEventArgs e)
        {
            // Reiniciar la posición del archivo y volver a reproducir
            audioFileReader.Position = 0;
            waveOut.Play();
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            // Dirige a la ventana de Creación de Personaje
            NewGame f = new NewGame();
            f.Show();
            this.Hide();
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            // Dirige a la Ventana de Login
            login f = new login();
            f.Show();
            this.Hide();
        }

        private void btnRanking_Click(object sender, EventArgs e)
        {
            // Dirige a la ventana de Ranking
            ranking f = new ranking();
            f.Show();
            this.Hide();
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            //MessageBox que solicita la contraseña de admin. para que funcione este messagebox hay que instalar la referencia Microsoft.Visualbasic y colocar el using
            //using Microsoft.VisualBasic;

            /*string password = Microsoft.VisualBasic.Interaction.InputBox("Ingrese la contraseña de administrador:", "Acceso Admin", "");

             // Verificar la contraseña 
             if (password == "admin123")  
             {
                 // Mostrar el formulario de administración
                 admin admin = new admin();
                 admin.Show();
                 this.Hide();
             }
             else
             {
                 // Mostrar mensaje de error si la contraseña es incorrecta
                 MessageBox.Show("Contraseña incorrecta. Acceso denegado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }
            */


            // Crear una instancia del formulario de autenticación
            authadmin authForm = new authadmin();

            // Mostrar el formulario de autenticación y verificar si las credenciales son correctas
            if (authForm.ShowDialog() == DialogResult.OK)
            {
                // Si las credenciales son correctas, mostrar el formulario de administración
                admin adminForm = new admin();
                adminForm.Show();
            }


        }

        // Método estático para detener la música en caso de necesitarlo
        public static void StopMusic()
        {
            if (waveOut != null && audioFileReader != null)
            {
                waveOut.Stop();
                waveOut.Dispose();
                audioFileReader.Dispose();
                waveOut = null;
                audioFileReader = null;
            }
        }

        // Método para reiniciar la música 
        public static void StartMusic()
        {
            if (waveOut == null && audioFileReader == null)
            {
                waveOut = new WaveOutEvent();
                audioFileReader = new AudioFileReader("background2.mp3");
                waveOut.Init(audioFileReader);
                waveOut.Play();
            }
        }

        // método para NO detener la música cuando se cierra el formulario
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            // No detiene la música, solo cierra el formulario
            base.OnFormClosed(e);
        }

        
    }
}
