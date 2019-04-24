using SICAP.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SICAP.Modelos
{
    public class Activdad : Conexion
    {
        public int id_actividad { set; get; }
        public string actividad { set; get; }
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

        public void cargar()
        {
            try
            {
                string query = "SELECT * FROM actividades WHERE id_proyecto = @id_proyecto AND fecha_entrega >= GETDATE() ORDER BY fecha_entrega ASC;";
                SqlCommand cmd = new SqlCommand(query);
                cmd.Parameters.AddWithValue("@id_proyecto", id_proyecto);
                string[] r = new string[2];
                DataTable act = consulta(cmd);
                id_actividad = (int)(act.Rows[0]["id_actividad"]);
                actividad = (string)(act.Rows[0]["actividad"]);
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}