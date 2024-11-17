using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient; // Importar System.Data.SqlClient
using System.Configuration;

public class Categoria
{
    public int Id { get; set; }
    public string Nombre { get; set; }      // CATEGORIA_NOMBRE
    public string Icono { get; set; }       // CATEGORIA_ICONO
    public string Descripcion { get; set; } // CATEGORIA_DESCRIPCION

    // Aquí puedes agregar métodos específicos para la clase si es necesario

    public static List<Categoria> ObtenerCategorias()
    {
        List<Categoria> categorias = new List<Categoria>();
        string miconexion = ConfigurationManager.ConnectionStrings["LOCAL"].ConnectionString;

        using (SqlConnection conn = new SqlConnection(miconexion))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SP_ObtenerCategorias2", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Categoria categoria = new Categoria
                {
                    Id = reader.GetInt32(0),
                    Nombre = reader.GetString(1),       // CATEGORIA_NOMBRE
                    Icono = reader.GetString(2),        // CATEGORIA_ICONO
                    Descripcion = reader.GetString(3)   // CATEGORIA_DESCRIPCION
                };
                categorias.Add(categoria);
            }

            conn.Close();
        }

        return categorias;
    }
}
