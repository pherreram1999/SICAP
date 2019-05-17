using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using SICAP.DAO;
using System.Data;
using System.Linq;
using System.Web;

namespace SICAP.Modelos
{
    public class Actividad : Conexion
    {
        public int id_actividad { set; get; }
        public bool expirado()
        {
            try
            {
                string query = "SELECT CAST(fecha_entrega AS VARCHAR) AS fecha_entrega FROM actividades WHERE id_actividad = @id_actividad";
                SqlCommand cmd = new SqlCommand(query);
                cmd.Parameters.AddWithValue("@id_actividad", id_actividad);
                DateTime fecha = DateTime.Parse(consulta(cmd).Rows[0]["fecha_entrega"].ToString());
                DateTime hoy = DateTime.Today;
                return (DateTime.Compare(hoy, fecha) > 0) ? true : false;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public int concluir()
        {
            try
            {
                string query = "UPDATE actividades  SET estatus = @estatus WHERE id_actividad = @id_actividad;";
                SqlCommand cmd = new SqlCommand(query);
                cmd.Parameters.AddWithValue("@estatus", 2);
                cmd.Parameters.AddWithValue("id_actividad", id_actividad);
                return ejectuarSQL(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable traerActividades(int id_proyecto)  // esto lo tenemos que presentar en un gridbview.
        {
            try
            {
                string query = "SELECT a.id_actividad, a.actividad,a.observaciones,a.fecha_entrega,e.estatus,a.id_proyecto" +
                    " FROM actividades a INNER JOIN estatus e ON a.estatus = e.id_estatus WHERE id_proyecto = @id_proyecto";
                SqlCommand cmd = new SqlCommand(query);
                cmd.Parameters.AddWithValue("@id_proyecto", id_proyecto);
                return consulta(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int cambiarEstatus(int e)
        {
            try
            {
                string query = "UPDATE actividades SET estatus = @estatus WHERE id_actividad = @id_actividad";
                SqlCommand cmd = new SqlCommand(query);
                cmd.Parameters.AddWithValue("@estatus", e);
                cmd.Parameters.AddWithValue("@id_actividad", id_actividad);
                return ejectuarSQL(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}