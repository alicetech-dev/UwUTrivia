using System;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsK
{
    public partial class ranking : Form
    {
        public ranking()
        {
            InitializeComponent();
            // Establecer el DataGridView sin bordes
            dgvRanking.BorderStyle = BorderStyle.None;
            // Suscribirse al evento para alternar colores de filas
            dgvRanking.RowPrePaint += dgvRanking_RowPrePaint;
        }

        private async void btnRead_Click(object sender, EventArgs e)
        {
            try
            {
                Jugador datatable = new Jugador();
                DataTable dt = await Task.Run(() => datatable.CargarJugadores());

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No se encontraron Jugadores en la base de datos.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    //MessageBox.Show($"Cantidad de filas cargadas: {dt.Rows.Count}");
                    //la comenté porque no me gusta ese mensaje, que cargue directamente al apretar el boton sin mostrar cuantas filas cargó

                    dgvRanking.AutoGenerateColumns = false; // Desactivar la generación automática de columnas para que se genere con el formato
                    //customizado por mi

                    dgvRanking.DataSource = dt;

                    // Configurar encabezados
                    dgvRanking.Columns["JUGADOR_NOMBRE"].HeaderText = "Nombre";
                    dgvRanking.Columns["JUGADOR_PUNTAJE"].HeaderText = "Puntaje";
                    dgvRanking.Columns["JUGADOR_NIVEL"].HeaderText = "Nivel";

                    // Ajustar el ancho de las columnas
                    dgvRanking.Columns["JUGADOR_NOMBRE"].Width = 200;
                    dgvRanking.Columns["JUGADOR_PUNTAJE"].Width = 100;
                    dgvRanking.Columns["JUGADOR_NIVEL"].Width = 100;

                    // Estilo del DataGridView
                    dgvRanking.DefaultCellStyle.Font = new Font("Game Over", 32); //aqui le ponemos la letra game over xD
                    dgvRanking.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkSlateBlue;
                    dgvRanking.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                    dgvRanking.ColumnHeadersDefaultCellStyle.Font = new Font("Game Over", 42, FontStyle.Bold);
                    dgvRanking.DefaultCellStyle.SelectionBackColor = Color.MediumSlateBlue;
                    dgvRanking.DefaultCellStyle.SelectionForeColor = Color.White;

                    // Establecer un color de fondo para el DataGridView
                    dgvRanking.BackgroundColor = Color.LightBlue; // Color de fondo que se ajuste a tu diseño
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btncargardgv.Enabled = true; // Reactiva el botón
            }
        }

        private void dgvRanking_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            // Alternar colores de las filas entre morado y fucsia
            if (e.RowIndex % 2 == 0)
            {
                dgvRanking.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.MediumPurple; // Color morado
            }
            else
            {
                dgvRanking.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Fuchsia; // Color fucsia
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


