using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient; // Importar System.Data.SqlClient
using System.Configuration;

public class Dificultad
{
    public int Id { get; set; }         // ID de la DIFICULTAD
    public string Nombre { get; set; }  // Nombre de la DIFICULTAD

    // Método para obtener las dificultades desde la base de datos
    public static List<Dificultad> ObtenerDificultades()
    {
        List<Dificultad> dificultades = new List<Dificultad>();
        string miconexion = ConfigurationManager.ConnectionStrings["LOCAL"].ConnectionString;

        using (SqlConnection conn = new SqlConnection(miconexion))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SP_ObtenerDificultades2", conn); // llama al procedimiento almacenado. lo cambie a numero2 porque el 1 me habia quedado mal
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Dificultad dificultad = new Dificultad
                {
                    Id = reader.GetInt32(0),     // Dificultad_Id
                    Nombre = reader.GetString(1) // Nombre
                };
                dificultades.Add(dificultad);
            }

            conn.Close();
        }

        return dificultades;
    }
}
