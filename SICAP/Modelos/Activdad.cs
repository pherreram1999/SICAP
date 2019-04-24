using SICAP.DAO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SICAP.Modelos
{
    public class Activdad : Conexion
    {
        public int id_proyecto { set; get; }
        public string proyecto { set; get; }

        public string getNombreProyecto()
        {
            try
            {
                string query = "SELECT * FROM proyectos WHERE id_proyecto = @id_proyecto";
                SqlCommand cmd = new SqlCommand(query);
                cmd.Parameters.AddWithValue("@id_proyecto",id_proyecto);
                return (string)(consulta(cmd).Rows[0]["proyecto"]);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}