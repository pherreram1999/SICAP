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
        public string estatus { set; get; }
        public int id_estatus { get; set; }
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
                string query= "SELECT TOP 1 id_proyecto FROM proyectos ORDER BY id_proyecto DESC;";
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
                string query = "INSERT INTO relaciones (id_usuarios, id_proyecto)VALUES(@id_usuario,@id_proyecto);";                

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

        public void asignarActividades()
        {
            try
            {
                string query = "INSERT INTO actividades (actividad,observaciones,fecha_entrega,id_proyecto) " +
                    "VALUES (@actividad,@observaciones,@fecha_entrega,@id_proyecto);";
                for(int i = 0; i < actividades.Count; i++)
                {
                    SqlCommand cmd = new SqlCommand(query);
                    cmd.Parameters.AddWithValue("@actividad", actividades[i][0]);
                    cmd.Parameters.AddWithValue("@observaciones",actividades[i][1]);
                    cmd.Parameters.AddWithValue("@fecha_entrega", actividades[i][2]);
                    cmd.Parameters.AddWithValue("@id_proyecto", id_proyecto);
                    ejectuarSQL(cmd);
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public DataTable traerProyectos()
        {
            try
            {
                string query = "SELECT p.id_proyecto, p.proyecto, p.fecha_registro, CAST(p.fecha_inicio AS VARCHAR) AS fecha_inicio" +
                    ",CAST(p.fecha_final AS VARCHAR) AS fecha_final, e.estatus FROM proyectos" +
                    " p INNER JOIN estatus e ON p.estatus = e.id_estatus WHERE p.estatus = @estatus";
                SqlCommand cmd = new SqlCommand(query);
                cmd.Parameters.AddWithValue("@estatus", id_estatus);
                return consulta(cmd);                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

       

        public void cargarDatos() // aun tenemos que ver como cargar a los usuarios
        {
            try
            {
                string query = "SELECT p.id_proyecto, p.proyecto, p.fecha_registro,CAST(p.fecha_inicio AS varchar) as fecha_inicio ,CAST(p.fecha_final AS varchar) as fecha_final ,p.observaciones," +
                    " e.estatus FROM proyectos p INNER JOIN estatus e ON p.estatus = e.id_estatus WHERE id_proyecto = @id_proyecto;";
                SqlCommand cmd = new SqlCommand(query);
                cmd.Parameters.AddWithValue("@id_proyecto",id_proyecto);
                DataTable pro = consulta(cmd);
                proyecto = (string)(pro.Rows[0]["proyecto"]);
                observaciones = (string)(pro.Rows[0]["observaciones"]);
                fecha_inicio = (string)(pro.Rows[0]["fecha_inicio"]);
                fecha_final = (string)(pro.Rows[0]["fecha_final"]);
                estatus = (string)(pro.Rows[0]["estatus"]);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string[] traerUsuariosLista()
        {
            try
            {
                string query = "SELECT u.id_usuario, u.nombre, u.paterno, u.materno, u.especialidad FROM relaciones" +
                    " r INNER JOIN usuarios u ON r.id_usuarios = u.id_usuario WHERE r.id_proyecto = @id_proyecto;";
                SqlCommand cmd = new SqlCommand(query);
                cmd.Parameters.AddWithValue("@id_proyecto", id_proyecto);
                DataTable pro = consulta(cmd);
                string[] user = new string[pro.Rows.Count];
                for(int i = 0; i < pro.Rows.Count; i++)
                {
                    string usuario = Convert.ToString((int)(pro.Rows[i]["id_usuario"]));
                    usuario += " - " + (string)(pro.Rows[i]["nombre"]);
                    usuario += " " + (string)(pro.Rows[i]["paterno"]);
                    usuario += " " + (string)(pro.Rows[i]["materno"]);
                    usuario += " - " + (string)(pro.Rows[i]["especialidad"]);
                    user[i] = usuario;
                }
                return user;
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
                string query = "UPDATE proyectos SET estatus = @estatus WHERE id_proyecto = @id_proyecto";
                SqlCommand cmd = new SqlCommand(query);
                cmd.Parameters.AddWithValue("@estatus", e);
                cmd.Parameters.AddWithValue("@id_proyecto", id_proyecto);
                return ejectuarSQL(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public bool expirado()
        {
            try
            {                
                DateTime fecha = DateTime.Parse(fecha_final);                
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
                string query = "UPDATE proyectos SET estatus = @estatus WHERE id_proyecto = @id_proyecto;";
                SqlCommand cmd = new SqlCommand(query);
                cmd.Parameters.AddWithValue("@estatus", 2);
                cmd.Parameters.AddWithValue("id_proyecto", id_proyecto);
                return ejectuarSQL(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool eliminarProyecto()
        {
            try
            {                
                string ocupado = "SELECT estatus FROM proyectos WHERE id_proyecto = @id_proyecto";
                SqlCommand cmd = new SqlCommand(ocupado);
                cmd.Parameters.AddWithValue("@id_proyecto",id_proyecto);
                bool eliminado = (consulta(cmd).Rows[0]["estatus"].ToString() == "1") ? true : false;
                if (!eliminado)
                {
                    string queryRelaciones = "DELETE FROM relaciones WHERE id_proyecto = @id_proyecto; ";
                    string queryAvances = "DELETE FROM avances WHERE id_proyecto = @id_proyecto; ";
                    string queryActividades = "DELETE FROM actividades WHERE id_proyecto = @id_proyecto; ";
                    string queryProyectos = "DELETE FROM proyectos WHERE id_proyecto = @id_proyecto; ";

                    SqlCommand cmd2 = new SqlCommand(queryRelaciones);
                    cmd2.Parameters.AddWithValue("@id_proyecto", id_proyecto);
                    int e  = ejectuarSQL(cmd2);

                    SqlCommand cmd3 = new SqlCommand(queryAvances);
                    cmd3.Parameters.AddWithValue("@id_proyecto", id_proyecto);
                    e = ejectuarSQL(cmd3);

                    SqlCommand cmd4 = new SqlCommand(queryActividades);
                    cmd4.Parameters.AddWithValue("@id_proyecto", id_proyecto);
                    e = ejectuarSQL(cmd4);

                    SqlCommand cmd5 = new SqlCommand(queryProyectos);
                    cmd5.Parameters.AddWithValue("@id_proyecto", id_proyecto);
                    e = ejectuarSQL(cmd5);
                }
                return eliminado;
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            


        }

     


    }
}