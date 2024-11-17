using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace AsK
{
    public class Alternativa
    {
        public int Id { get; set; }
        public string Texto { get; set; }
        public bool EsCorrecta { get; set; }
        public int AlternativaCorrecta { get; set; }


        public static List<Alternativa> ObtenerAlternativasPorPregunta(int preguntaId)
        {
            List<Alternativa> alternativas = new List<Alternativa>();
            #region conexion a la base de datos
            string miconexion = ConfigurationManager.ConnectionStrings["LOCAL"].ConnectionString;

            // Conexión a la base de datos
            using (SqlConnection conn = new SqlConnection(miconexion))
            #endregion
            {
                SqlCommand cmd = new SqlCommand("ObtenerAlternativasPorPregunta", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PreguntaId", preguntaId);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Alternativa alternativa = new Alternativa();
                    alternativa.Texto = reader["ALTERNATIVA_TEXTO"].ToString();
                    alternativa.EsCorrecta = Convert.ToBoolean(reader["ALTERNATIVA_ES_CORRECTA"]);
                    alternativas.Add(alternativa);
                }

                reader.Close();
            }

            return alternativas;
        }
        // Método para obtener la alternativa correcta desde la base de datos

        public static string ObtenerAlternativaCorrecta(int preguntaId)
        {
            string textoCorrecto = "";

            string miconexion = ConfigurationManager.ConnectionStrings["LOCAL"].ConnectionString;

            // Conexión a la base de datos
            using (SqlConnection conn = new SqlConnection(miconexion))
            {
                SqlCommand command = new SqlCommand("ObtenerAlternativaCorrecta", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@PreguntaId", preguntaId);

                conn.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // Obtener el texto de la alternativa correcta
                    textoCorrecto = reader["ALTERNATIVA_TEXTO"].ToString();
                }

                reader.Close();
            }

            return textoCorrecto;
        }

        

    }

}

