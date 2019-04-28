using SICAP.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SICAP.Modelos
{
    public class Avance : Conexion
    {
        public int id_avance { set; get; }
        public string NombreAvance { set; get; }
        public string fecha_registro { set; get; }
        public string observaciones { set; get; }
        public string rutaDoc { set; get; }
        public int id_actividad { set; get; }
        public string actividad { set; get; }
        public int id_proyecto { set; get; }
        public int id_usuario { set; get; }
        public string usuario { set; get; }
        
        public Avance() { }
        public Avance(int id_avance)
        {
            try
            {
                string query = "SELECT a.id_avance AS ID,a.ArchivoRuta ,a.avance,a.observaciones,CAST(a.fecha_registro AS varchar) " +
                    "AS fecha_registro,CONCAT(u.nombre,' ',u.paterno,' ',u.materno) AS Nombre FROM avances a INNER " +
                    "JOIN usuarios u ON a.id_usuario = u.id_usuario WHERE a.id_avance = @ID;";
                SqlCommand cmd = new SqlCommand(query);
                cmd.Parameters.AddWithValue("@ID",id_avance);
                DataTable a = consulta(cmd);
                NombreAvance = (string)(a.Rows[0]["avance"]);
                observaciones = (string)(a.Rows[0]["observaciones"]);
                rutaDoc = (string)(a.Rows[0]["ArchivoRuta"]);
                fecha_registro = (string)(a.Rows[0]["fecha_registro"]);
                usuario = (string)(a.Rows[0]["Nombre"]);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        

        public List<string> getActividades()
        {
            try
            {
                string query = "SELECT * FROM actividades WHERE id_proyecto = @id_proyecto AND fecha_entrega >= GETDATE() ORDER BY fecha_entrega ASC;";
                SqlCommand cmd = new SqlCommand(query);
                cmd.Parameters.AddWithValue("@id_proyecto", id_proyecto);
                DataTable act = consulta(cmd);
                List<string> actividades = new List<string>();
                
                for(int i = 0; i < act.Rows.Count; i++)
                {
                    string fila = act.Rows[i]["id_actividad"].ToString() + " - " + act.Rows[i]["actividad"].ToString();                    
                    actividades.Add(fila);
                }
                return actividades;
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int guardar()
        {
            try
            {
                string query = "INSERT INTO avances(avance,observaciones,id_actividad,id_usuario,id_proyecto) " +
                    "VALUES(@avance,@observaciones,@id_actividad,@id_usuario,@id_proyecto)";
                SqlCommand cmd = new SqlCommand(query);
                cmd.Parameters.AddWithValue("@avance",NombreAvance);
                cmd.Parameters.AddWithValue("@observaciones", observaciones);                
                cmd.Parameters.AddWithValue("@id_actividad", id_actividad);
                cmd.Parameters.AddWithValue("@id_usuario", id_usuario);
                cmd.Parameters.AddWithValue("@id_proyecto", id_proyecto);
                return ejectuarSQL(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int guardar(string ruta)
        {
            try
            {
                string query = "INSERT INTO avances(avance,observaciones,ArchivoRuta,id_actividad,id_usuario,id_proyecto) " +
                    "VALUES(@avance,@observaciones,@ruta,@id_actividad,@id_usuario,@id_proyecto)";
                SqlCommand cmd = new SqlCommand(query);
                cmd.Parameters.AddWithValue("@avance", NombreAvance);
                cmd.Parameters.AddWithValue("@observaciones", observaciones);
                cmd.Parameters.AddWithValue("@id_actividad", id_actividad);
                cmd.Parameters.AddWithValue("@id_usuario", id_usuario);
                cmd.Parameters.AddWithValue("@id_proyecto", id_proyecto);              
                cmd.Parameters.AddWithValue("@ruta", ruta);

                return ejectuarSQL(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable traerAvances()
        {
            try
            {
                string query = "SELECT a.id_avance AS ID ,a.avance,a.observaciones,ac.actividad,a.fecha_registro,CONCAT(u.nombre,' ',u.paterno,' ',u.materno)" +
                    " AS Nombre FROM avances a INNER JOIN usuarios u ON a.id_usuario = u.id_usuario INNER JOIN actividades ac ON a.id_actividad = ac.id_actividad " +
                    "WHERE a.id_proyecto = @id_proyecto";
                SqlCommand cmd = new SqlCommand(query);
                cmd.Parameters.AddWithValue("@id_proyecto", id_proyecto);
                return consulta(cmd);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        



    }
}