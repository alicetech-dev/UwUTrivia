using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System;
using System.Windows.Forms;

public class Jugador
{
    public int JugadorId { get; set; }
    public string Nombre { get; set; }
    public string Email { get; set; }
    public int Nivel { get; set; }
    public int PersonajeImagenFk { get; set; }
    public int Puntaje { get; set; }
    public string Password { get; set; }  // Asegúrate de que esta propiedad esté definida
    public int RolId { get; set; }  // Asegúrate de que esta propiedad esté definida


    //metodo para obtener los datos de un jugador enviando el Id como parametro al Procedimiento ALmacenado esto es para el combobox
    public Jugador ObtenerJugadorPorId(int jugadorId)
    {
        Jugador jugador = null;
        string miconexion = ConfigurationManager.ConnectionStrings["LOCAL"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(miconexion))
        {
            using (SqlCommand cmd = new SqlCommand("SP_ObtenerJugadorPorId", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@JugadorId", jugadorId);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    jugador = new Jugador
                    {
                        JugadorId = (int)reader["JUGADOR_ID"],
                        Nombre = reader["JUGADOR_NOMBRE"].ToString(),
                        Email = reader["JUGADOR_EMAIL"].ToString(),
                        Password = reader["JUGADOR_PASSWORD"].ToString(), // Añadir el Password
                        Nivel = (int)reader["JUGADOR_NIVEL"],
                        Puntaje = (int)reader["JUGADOR_PUNTAJE"],
                        RolId = (int)reader["JUGADOR_ROL_FK"],                        
                        PersonajeImagenFk = (int)reader["JUGADOR_PERSONAJE_IMAGEN_FK"]
                    };
                }
            }
        }
        return jugador;
    }
    public void BorrarJugador(int jugadorId)
    {
        string miconexion = ConfigurationManager.ConnectionStrings["LOCAL"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(miconexion))
        {
            using (SqlCommand cmd = new SqlCommand("SP_BorrarJugador", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@JugadorId", jugadorId);

                conn.Open();
                cmd.ExecuteNonQuery(); // Ejecuta el procedimiento almacenado
            }
        }
    }
    
    //metodo para el ADD player, este es un addplayer de Admin, que tiene todos los campos de la tabla, distinto al add player de jugador normal.

    public void AgregarJugadorFull(Jugador jugador)
    {
        string miconexion = ConfigurationManager.ConnectionStrings["LOCAL"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(miconexion))
        {
            using (SqlCommand cmd = new SqlCommand("SP_AgregarJugadorFull", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", jugador.Nombre);
                cmd.Parameters.AddWithValue("@Email", jugador.Email);
                cmd.Parameters.AddWithValue("@Password", jugador.Password);
                cmd.Parameters.AddWithValue("@Nivel", jugador.Nivel);
                cmd.Parameters.AddWithValue("@Puntaje", jugador.Puntaje);
                cmd.Parameters.AddWithValue("@RolId", jugador.RolId);
                cmd.Parameters.AddWithValue("@PersonajeImagenFk", jugador.PersonajeImagenFk);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }

    //Metodo actualizar jugador

    public void ActualizarJugador(Jugador jugador)
    {
        string miconexion = ConfigurationManager.ConnectionStrings["LOCAL"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(miconexion))
        {
            using (SqlCommand cmd = new SqlCommand("SP_ActualizarJugador", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@JugadorId", jugador.JugadorId);
                cmd.Parameters.AddWithValue("@Nombre", jugador.Nombre);
                cmd.Parameters.AddWithValue("@Email", jugador.Email);
                cmd.Parameters.AddWithValue("@Password", jugador.Password);
                cmd.Parameters.AddWithValue("@Nivel", jugador.Nivel);
                cmd.Parameters.AddWithValue("@Puntaje", jugador.Puntaje);
                cmd.Parameters.AddWithValue("@RolId", jugador.RolId);
                cmd.Parameters.AddWithValue("@PersonajeImagenFk", jugador.PersonajeImagenFk);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }


    //Cargar el Ranking de Jugadores
    public DataTable CargarJugadores()
    {
        DataTable dt = new DataTable();

        try
        {
            string miconexion = ConfigurationManager.ConnectionStrings["LOCAL"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(miconexion))
            {
                conn.Open();

                // Define el comando SQL para ejecutar el procedimiento almacenado
                using (SqlCommand cmd = new SqlCommand("ObtenerJugadoresOrdenadosPorPuntaje", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure; // Indica que es un procedimiento almacenado

                    // Crea un SqlDataAdapter para rellenar la DataTable
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al cargar los datos: {ex.Message}", ex);
        }

        return dt;
    }
    public string ObtenerRutaImagenPersonaje(int jugadorId)
    {
        string rutaImagen = string.Empty; //declarar la variable para recibir la ruta de la imagen
        string miconexion = ConfigurationManager.ConnectionStrings["LOCAL"].ConnectionString;

        using (SqlConnection conn = new SqlConnection(miconexion))
        {
            using (SqlCommand cmd = new SqlCommand("ObtenerRutaImagenPersonaje", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@JugadorId", jugadorId);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    rutaImagen = reader["PERSONAJE_RUTA_IMAGEN"].ToString();
                }
            }
        }

        return rutaImagen;
    }


    //metodo para obtener todos los jugadores para cargarlos en el datagrid y en el combobox del formulario admin.cs

    public DataTable ObtenerTodosLosJugadores()
    {
        string miconexion = ConfigurationManager.ConnectionStrings["LOCAL"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(miconexion))
        {
            using (SqlCommand command = new SqlCommand("ObtenerTodosLosJugadores", conn))
            {
                command.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();

                try
                {
                    conn.Open();
                    adapter.Fill(dt);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener los jugadores: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }

                return dt;
            }
        }
    }


    //guarda el puntaje del jugador luego de terminar el juego
    //este metodo me queda pendiente hacerlo usando un procedimiento almacenado en vez de una consulta directa a a base de datos
    public void GuardarPuntaje(int jugadorID, int puntaje)
    {
        string miconexion = ConfigurationManager.ConnectionStrings["LOCAL"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(miconexion))
        {
            try
            {
                conn.Open();

                //consulta SQL para actualizar el puntaje
                string query = "UPDATE JUGADOR SET JUGADOR_PUNTAJE = @puntaje WHERE JUGADOR_ID = @jugadorId";

                // Crea un SqlCommand para ejecutar la consulta
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    // Define los parámetros de la consulta
                    command.Parameters.AddWithValue("@JugadorId", jugadorID);
                    command.Parameters.AddWithValue("@Puntaje", puntaje);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                //mostrar el error si es que ocurre algun problema
                MessageBox.Show($"Error al guardar el puntaje: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        
        
    }
}

    


