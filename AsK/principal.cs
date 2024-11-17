using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Drawing;


namespace AsK
{
    public partial class principal : Form
    {
        //aqui definimos las variables globales
        private List<Categoria> categorias; // Lista de categorías obtenidas de la base de datos
        private List<Dificultad> dificultades; // Lista de dificultades obtenidas de la base de datos
        private int jugadorId; // Almacenar el jugadorId
        private List<Alternativa> alternativas; // Declarar como variable de clase
        private int puntajeActual = 0;
        private Pregunta preguntaActual;
        private List<int> preguntasUsadas = new List<int>();
        private List<Pregunta> todasLasPreguntas; // Lista global de todas las preguntas
        private int indicePreguntaActual = 0; // Índice para llevar el control de la pregunta actual


        public principal(int jugadorId)
        {
            InitializeComponent();
            this.jugadorId = jugadorId; // Asigna el jugadorId pasado
            this.Load += new EventHandler(Opciones_Load); // Vincular el evento Load
        }

        private void Opciones_Load(object sender, EventArgs e)
        {
            CargarCategoriasYDificultades(); // Cargar categorías y dificultades al cargar el formulario

            Jugador jugador = new Jugador();
            string rutaImagen = jugador.ObtenerRutaImagenPersonaje(jugadorId);
            // Cargar y asignar la imagen del personaje al PictureBox
            
            if (!string.IsNullOrEmpty(rutaImagen))
            {
                pictureBoxPersonaje.Image = Image.FromFile(rutaImagen);
                pictureBoxPersonaje.SizeMode = PictureBoxSizeMode.StretchImage; // Para ajustar la imagen al PictureBox
            }
        }

        private void CargarCategoriasYDificultades()
        {
            // Cargar las categorías desde el procedimiento almacenado
            categorias = Categoria.ObtenerCategorias();

            // Cargar las dificultades desde el procedimiento almacenado
            dificultades = Dificultad.ObtenerDificultades();

            // Limpiar el ComboBox y agregar la opción "Al Azar" para categorías
            comboBoxCategoria.Items.Clear();
            comboBoxCategoria.Items.Add("Al Azar");

            foreach (var categoria in categorias)//el foreach recorre cada elemento de la lista categorias que se cargo y lo añade al combobox
            {
                comboBoxCategoria.Items.Add(categoria.Nombre); // Mostrar el nombre en el ComboBox
            }

            // Limpiar el ComboBox y agregar la opción "Al Azar" para dificultades
            comboBoxDificultad.Items.Clear();
            comboBoxDificultad.Items.Add("Al Azar");

            foreach (var dificultad in dificultades) //el foreach recorre cada elemento de la lista dificultades y la añade al combobox 
            {
                comboBoxDificultad.Items.Add(dificultad.Nombre); // Mostrar el nombre en el ComboBox
            }

            // Establecer como predeterminada la opción "Al Azar"
            comboBoxCategoria.SelectedIndex = 0;
            comboBoxDificultad.SelectedIndex = 0;

            // Vincular el evento para actualizar la descripción al cambiar de categoría
            comboBoxCategoria.SelectedIndexChanged += comboBoxCategoria_SelectedIndexChanged;
        }

        // Evento para mostrar en el RichTextBox la descripción de la categoría seleccionada, al cambiar el index del combobox
        private void comboBoxCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxCategoria.SelectedIndex > 0) // Excluir la opción "Al Azar" si el selected item es mayor a 0
            {
                // Obtener la categoría seleccionada (el índice debe ajustarse porque la opción "Al Azar" está en el índice 0)
                Categoria categoriaSeleccionada = categorias[comboBoxCategoria.SelectedIndex - 1];

                // Actualizar el RichTextBox con la descripción de la categoría
                rtbDescripcion.Text = categoriaSeleccionada.Descripcion;
            }
            else
            {
                // Si la opción seleccionada es "Al Azar", limpiar el RichTextBox
                //rtbDescripcion.Clear();
                rtbDescripcion.Text = "Se te haran preguntas de todas las categorias disponibles";
            }
        }


        //EVENTO DEL BOTON COMENZAR A JUGAR. se me olvido cambiarle el nombre del boton y quedo como button1 uWu
        private void button1_Click(object sender, EventArgs e)
        {
            CargarPregunta();
            // Obtener el nivel de dificultad seleccionado
            int selectedNivel = comboBoxDificultad.SelectedIndex;

            // Obtener la categoría seleccionada
            int selectedCategoria = comboBoxCategoria.SelectedIndex;

            // Si selecciona "Al Azar" para dificultad
            if (selectedNivel == 0)
            {
                // usa Random() para generar un valor entre 1 (Principiante) y 4 (Genio)
                selectedNivel = new Random().Next(1, 5);
            }

            // Si selecciona "Al Azar" para categoría
            if (selectedCategoria == 0)
            {
                // Genera un valor aleatorio entre 1 y el número total de categorías
                selectedCategoria = new Random().Next(1, categorias.Count + 1);
            }

            // Obtener el ID de la categoría y el nivel seleccionados en el combobox
            int categoriaId = categorias[selectedCategoria - 1].Id;
            int nivelDificultadId = dificultades[selectedNivel - 1].Id;
                        
        }

        private void CargarPregunta()
        {
            // Obtener aleatoriamente la categoría y la dificultad
            int categoriaId = ObtenerCategoriaAleatoria();
            int nivelDificultadId = ObtenerDificultadAleatoria();

            Pregunta preguntaSeleccionada = null;

            // obtener una pregunta aleatoria de la base de datos
            //aqui se usa el bucle Do-While de C# (hacer - mientras)
            do
            {
                preguntaSeleccionada = Pregunta.ObtenerPreguntaAleatoria(nivelDificultadId, categoriaId);

                if (preguntaSeleccionada == null)
                {
                    // Si no hay más preguntas, mostrar un mensaje
                    MessageBox.Show("No se encontraron más preguntas disponibles.");
                    return;
                }

            } while (preguntaSeleccionada == null);

            preguntaActual = preguntaSeleccionada;

            // Mostrar la pregunta en el RichTextBox
            richTextBoxPregunta.Text = preguntaActual.Texto;

            // Obtener y mostrar las alternativas
            alternativas = Alternativa.ObtenerAlternativasPorPregunta(preguntaActual.Id);
            radioButton1.Text = alternativas[0].Texto;
            radioButton2.Text = alternativas[1].Texto;
            radioButton3.Text = alternativas[2].Texto;
            radioButton4.Text = alternativas[3].Texto;

            // Desactivar el botón play. para que no se pueda cambiar
            // la pregunta hasta que se responda la pregunta actual
            button1.Enabled = false;
        }
        private Random random = new Random(); // Instancia única de Random, esto para que no se esten siempre 
        //repitiendo las mismas preguntas y sea todo mas aleatorizado. Si tengo tiempo este metodo se va a cambiar por
        //otro que primero carga todas las preguntas en memoria y las baraja y luego las va mostrando de una en una, porque random
        //existe la posibilidad de que se repitan 

        // Método para obtener una categoría aleatoria

        private int ObtenerCategoriaAleatoria()
        {
            // Generar un valor aleatorio entre 1 y el número total de categorías
            return new Random().Next(1, categorias.Count + 1); 
        }

        // Método para obtener una dificultad aleatoria
        private int ObtenerDificultadAleatoria()
        {
            // Generar un valor aleatorio entre 1 y 4 (suponiendo que hay 4 niveles de dificultad)
            return new Random().Next(1, 5); // 1 = Principiante, 2 = Normal, 3 = Difícil, 4 = Genio
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            // Obtener la alternativa correcta desde la base de datos a traves de un metodo, le envia al metodo el id de la pregunta,(el id lo lee del metodo preguntaactual.)
            // con un procedimiento almacenado (obteneralternativacorrecta).este metodo devuelve el texto como string, de la alternativa cuya llave foránea.  Fk_pregunta_Id coincide con el Id de la pregunta, se crea una variable que recibe el texto de la 
            //alternativa correcta y compara ese texto con el texto del radiobutton seleccionado y sin son iguales es porque esa era la alternativa correcta.

            string alternativaCorrectaTexto = Alternativa.ObtenerAlternativaCorrecta(preguntaActual.Id);

            // Verificar si la alternativa seleccionada es correcta
            bool esCorrecta = false;

            // Comparar la alternativa seleccionada con la alternativa correcta
            if (radioButton1.Checked && radioButton1.Text == alternativaCorrectaTexto)
            {
                esCorrecta = true;
            }
            else if (radioButton2.Checked && radioButton2.Text == alternativaCorrectaTexto)
            {
                esCorrecta = true;
            }
            else if (radioButton3.Checked && radioButton3.Text == alternativaCorrectaTexto)
            {
                esCorrecta = true;
            }
            else if (radioButton4.Checked && radioButton4.Text == alternativaCorrectaTexto)
            {
                esCorrecta = true;
            }

            if (esCorrecta)
            {
                // Obtener el ID de dificultad actual
                int dificultadId = preguntaActual.DificultadId;

                // Solo calcular el puntaje si la dificultad es válida
                if (dificultadId > 0)
                {
                    int puntajePorDificultad = ObtenerPuntajePorDificultad(dificultadId); // 
                    puntajeActual += puntajePorDificultad;

                    // Actualizar el TextBox del puntaje
                    textBoxPuntaje.Text = puntajeActual.ToString();
                }

                
                MessageBox.Show("¡Respuesta Correcta!");

                // hbilitar nuevamente el botón para cambiar la pregunta
                button1.Enabled = true;

                // Cargar una nueva pregunta (con categoría y dificultad aleatorias)
                CargarPregunta();
            }
            else
            {
                // Si la respuesta es incorrecta, muestra el mensaje y guarda el puntaje
                MessageBox.Show("Respuesta incorrecta. PERDISTE!!!");

                Jugador jugador = new Jugador();
                jugador.GuardarPuntaje(jugadorId, puntajeActual); // Método para guardar puntaje

                titulo f = new titulo();
                f.Show();
                this.Close();
            }
        }

        // Método para obtener el puntaje según la dificultad, para que las mas dificiles valgan mas puntos
        private int ObtenerPuntajePorDificultad(int dificultadId)
        {
            switch (dificultadId)
            {
                case 1: return 10; // Principiante
                case 2: return 20; // Normal
                case 3: return 30; // Difícil
                case 4: return 40; // Genio
                default: return 0; // Si la dificultad no es válida
            }
        }
               
    }
}