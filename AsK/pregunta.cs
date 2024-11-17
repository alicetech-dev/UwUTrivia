using System.Data.SqlClient;
using System.Data;
using System;
using System.Configuration;
using System.Windows.Forms;

public class Pregunta
{
    public int Id { get; set; }
    public string Texto { get; set; }
    public string RutaImagen { get; set; }
    public int CategoriaId { get; set; }
    public int DificultadId { get; set; } // Id de la dificultad



    //Nuevo Metodo para obtener una pregunta aleatoria, lo cambie para que devolviera la categoria y dificultad,
    //porque primero solo devolvia el texto y la id. esta en el mismo formulario opciones

    public static Pregunta ObtenerPreguntaAleatoria(int dificultadId, int categoriaId)
    {
        Pregunta pregunta = null;

        // Conexión a la base de datos
        string miconexion = ConfigurationManager.ConnectionStrings["LOCAL"].ConnectionString;
        using (SqlConnection connection = new SqlConnection(miconexion))
        {
            // Crea el comando almacenado
            SqlCommand command = new SqlCommand("ObtenerPreguntaAleatoria3", connection);
            command.CommandType = CommandType.StoredProcedure;

            // Parametros del procedimiento almacenado
            command.Parameters.AddWithValue("@NivelDificultadId", dificultadId);
            command.Parameters.AddWithValue("@CategoriaId", categoriaId);


            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                pregunta = new Pregunta
                {
                    Id = Convert.ToInt32(reader["PREGUNTA_ID"]),
                    Texto = reader["PREGUNTA_TEXTO"].ToString(),
                    CategoriaId = (int)reader["PREGUNTA_CATEGORIA_FK"],
                    DificultadId = (int)reader["DIFICULTAD_ID_FK"],
                    RutaImagen = reader["PREGUNTA_RUTA_IMAGEN"].ToString()
                };
            }

        }

        return pregunta;
    }
   

}



// Método para obtener el total de preguntas para una categoría
// y nivel de dificultad para luego randomizarlas aqui hice la query directa sin usar
//procedimiento almacenado porque era mas eficiente es un solo valor el que tiene que recuperar
//lo comente porque no lo ocupe al final, ahora se usa  Random random = new random();

/*public static int ObtenerTotalPreguntasPorCategoriaYDificultad(int categoriaId, int nivelDificultadId)
{
    int totalPreguntas = 0;

    // Cadena de conexión
    string connectionString = ConfigurationManager.ConnectionStrings["LOCAL"].ConnectionString;

    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        // Consulta SQL para contar las preguntas por categoría y nivel de dificultad
        string query = @"SELECT COUNT(*) 
                         FROM PREGUNTA 
                         WHERE PREGUNTA_CATEGORIA_FK = @CategoriaId 
                         AND DIFICULTAD_ID_FK = @DificultadId";

        using (SqlCommand command = new SqlCommand(query, connection))
        {
            // Añadir parámetros a la consulta
            command.Parameters.AddWithValue("@CategoriaId", categoriaId);
            command.Parameters.AddWithValue("@DificultadId", nivelDificultadId);

            // Abrir la conexión
            connection.Open();

            // Ejecutar la consulta y obtener el resultado
            totalPreguntas = (int)command.ExecuteScalar();
        }
    }

    return totalPreguntas;
}
}
*/




