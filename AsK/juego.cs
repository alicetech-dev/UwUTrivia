using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Estos Using hay que colocarlos son lo mas importante
//Tambien se debe cargar la libreria System.Configuration. en agregar referencias
using System.Data.Sql; //Para Usar Sql
using System.Configuration; //para configurar la coneccion
using System.ComponentModel;
using System.Drawing;
using AsK.Properties;



/*AQUI COLOCAREMOS TODOS LOS METODOS QUE CORRESPONDEN AL GAMEPLAY */


namespace AsK

{
    public class juego
    {

        //
        public Jugador jugador { get; set; }
        public int tiempoRestante { get; set; } = 600; // 10 minutos

        
        public void IniciarTemporizador(System.Windows.Forms.Timer timer)
        {
            timer.Interval = 1000;
            timer.Tick += (sender, e) =>
            {
                tiempoRestante--;
                if (tiempoRestante <= 0)
                {
                    timer.Stop();
                    // Lógica para terminar el juego
                }
            };
            timer.Start();
        }


        //crear la conexion..

        string miconexion = ConfigurationManager.ConnectionStrings["LOCAL"].ConnectionString;


        //Metodo para el formulario de Login

        public DataTable VerificaUsuario(string Email, string Password)
        {

            SqlConnection conn = new SqlConnection(miconexion);
            SqlDataReader dr = null;
            DataTable dt = new DataTable();


            try
            {

                conn.Open();
                #region LLamar al Procedimiento
                SqlCommand cmd = new SqlCommand("Autentificacion4", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                #endregion
                #region Entregar los parámetros al procedimiento
                cmd.Parameters.Add("@Email", SqlDbType.VarChar, 100);
                cmd.Parameters["@Email"].Value = Email;
                cmd.Parameters.Add("@Password", SqlDbType.VarChar, 100);
                cmd.Parameters["@Password"].Value = Password;
                #endregion
                #region Ejecutar el Procedimiento
                dr = cmd.ExecuteReader();
                #endregion
                #region Cargar DataTable
                dt.Load(dr);
                #endregion
                #region Cerrar la Conexion
                conn.Close();
                #endregion
                return dt;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

       


        // Método para Crear un Jugador
        public string AgregarJugador(string Nombre, string Email, string Password, int PersonajeId)
        {
            string resultado = null;

            try
            {
                #region Abre la conexión y llama al procedimiento almacenado
                SqlConnection conn = new SqlConnection(miconexion);
                conn.Open();

                SqlCommand cmd = new SqlCommand("SP_AgregarJugador", conn);
                /* Llama al Procedimiento almacenado (Stored Procedure) SP_AgregarJugador */
                #endregion

                cmd.CommandType = CommandType.StoredProcedure;

                // Parámetros para el procedimiento almacenado
                cmd.Parameters.Add("@Nombre", SqlDbType.VarChar, 100);
                cmd.Parameters["@Nombre"].Value = Nombre;

                cmd.Parameters.Add("@Email", SqlDbType.VarChar, 100);
                cmd.Parameters["@Email"].Value = Email;

                cmd.Parameters.Add("@Password", SqlDbType.VarChar, 100);
                cmd.Parameters["@Password"].Value = Password;


                cmd.Parameters.Add("@Nivel", SqlDbType.Int).Value = 1; // Nivel predeterminado

                cmd.Parameters.Add("@Puntaje", SqlDbType.Int).Value = 0; // Puntaje inicial

                cmd.Parameters.Add("@RolId", SqlDbType.Int).Value = 1; // Rol predeterminado es 1 "Jugador"

                // Parámetro del Personaje seleccionado por el jugador
                cmd.Parameters.Add("@PersonajeId", SqlDbType.Int);
                cmd.Parameters["@PersonajeId"].Value = PersonajeId;

                // Ejecutar el procedimiento almacenado
                cmd.ExecuteNonQuery();

                resultado = "Jugador Agregado Exitosamente, Disfruta el Juego";
                conn.Close();
                return resultado;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        //Metodo para cargar las categorias en el DATAGRID DE RANKING
        
        //cambie este metodo a la clase jugador.cs porque es mas logico tener ahi todo lo que corresponde al jugador




    }



}
