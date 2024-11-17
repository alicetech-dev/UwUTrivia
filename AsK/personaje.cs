using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public class Personaje
{
    // declarar las variables que van a recibir y escribir las Propiedades del personaje
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string RutaImagen { get; set; }
    public string Biografia { get; set; }

    // Método para obtener personajes desde la base de datos utilizando un procedimiento almacenado
    public static List<Personaje> ObtenerPersonajes()
    {
        List<Personaje> personajes = new List<Personaje>();
        string miconexion = ConfigurationManager.ConnectionStrings["LOCAL"].ConnectionString;

        try
        {
            // Usar conexión a la base de datos
            using (SqlConnection conn = new SqlConnection(miconexion))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SP_ObtenerPersonajes", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader();

                // Leer los datos que envia el procediiento almacenado. Envia 4 cadenas que van en el orden en que se hizo la base de datos, 0 id, 1 nombre, 2 Biografia, 3 rutaimagen (las imagenes quedan en la carpeta /bin/debug/ del proyecto)
                while (reader.Read())
                {
                    Personaje personaje = new Personaje
                    {
                        Id = reader.GetInt32(0),         // Personaje_Id
                        Nombre = reader.GetString(1),    // Nombre
                        Biografia = reader.GetString(2), // Biografia
                        RutaImagen = reader.GetString(3) // RutaImagen
                    };

                    personajes.Add(personaje);
                }
            }
        }
        catch (Exception ex)
        {
            // Manejo de excepciones
            throw new Exception("Error al obtener los personajes: " + ex.Message);
        }

        return personajes;


    }

    //metodo para obtener el personaje elegido por el jugador para el juego
    public static Personaje ObtenerPersonajePorJugador(int jugadorId)
    {
        Personaje personaje = null;
        string miconexion = ConfigurationManager.ConnectionStrings["LOCAL"].ConnectionString;
        using (SqlConnection connection = new SqlConnection(miconexion))
        {
            SqlCommand command = new SqlCommand("SP_ObtenerPersonajePorJugador", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@JugadorId", jugadorId);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                personaje = new Personaje
                {
                    Id = Convert.ToInt32(reader["PersonajeId"]),
                    Nombre = reader["Nombre"].ToString(),
                    RutaImagen = reader["RutaImagen"].ToString()
                };
            }
        }

        return personaje;
    }



}
