using SICAP.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SICAP.Modelos
{
    public class Proyecto : Conexion
    {
        public int id_proyecto { set; get; }
        public string proyecto { set; get; }
        public string observaciones { set; get; }
        public string fecha_inicio { set; get; }
        public string fecha_final { set; get; }
        public List<int> usuarios { set; get; }
        public List<string []> actividades { set; get; } 

        public Proyecto()
        {
            usuarios = new List<int>();
            actividades = new List<string[]>();
        }

        public int guardar()
        {
            try
            {
                string query = "INSERT INTO proyectos(proyecto,observaciones,fecha_inicio,fecha_final) VALUES(@proyecto,@observaciones,@fecha_inicio,@fecha_final)";
                SqlCommand cmd = new SqlCommand(query);
                cmd.Parameters.AddWithValue("@proyecto", proyecto);
                cmd.Parameters.AddWithValue("@observaciones", observaciones);
                cmd.Parameters.AddWithValue("@fecha_inicio", fecha_inicio);
                cmd.Parameters.AddWithValue("fecha_final", fecha_final);
                return ejectuarSQL(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int getID()
        {
            try
            {
                string query= "SELECT TOP 1 4id_proyecto FROM proyectos ORDER BY id_proyecto DESC;";
                DataTable id = consulta(new SqlCommand(query));
                int id_proyectos = (int)(id.Rows[0]["id_proyecto"]);
                return id_proyectos;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void asignarUsuarios()
        {
            try
            {
                string query = "INSERT INTO relaciones (id_usuarios, id_proyecto)VALUES(@id_usuario,@id_proyecto)";
                id_proyecto = getID();

                for(int i = 0; i<usuarios.Count; i++)
                {
                    SqlCommand cmd = new SqlCommand(query);
                    cmd.Parameters.AddWithValue("@id_proyecto", id_proyecto);
                    cmd.Parameters.AddWithValue("@id_usuario", usuarios[i]);
                    ejectuarSQL(cmd);
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }




    }
}