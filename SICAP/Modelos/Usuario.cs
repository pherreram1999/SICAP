using SICAP.DAO;
using SICAP.Utelirias;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SICAP.Modelos
{
    public class Usuario : Conexion
    {
        public int id_usuario { set; get; }
        public string nombre { set; get; }
        public string paterno { set; get; }
        public string materno { set; get; }
        public string telefono { set; get; }
        public string email { set; get; }
        public string especialidad { set; get; }
        public string contrasena { set; get; }
        public int area { set; get; }
        public int rol { set; get; }
        public string ruta { get; set; }


        public bool guardar()
        {
            try
            {
                string query = "INSERT INTO usuarios(nombre,paterno,materno,telefono,email,especialidad,contrasena,area,rol,ruta)"
                + "values(dbo.InitCap(@nombre),dbo.InitCap(@paterno),dbo.InitCap(@materno),@telefono,@email,dbo.InitCap(@especialidad),@contrasena,@area,@rol,@ruta)";
                SqlCommand cmd = new SqlCommand(query);
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@materno", materno);
                cmd.Parameters.AddWithValue("@paterno", paterno);
                cmd.Parameters.AddWithValue("@telefono", telefono);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@especialidad", especialidad);
                cmd.Parameters.AddWithValue("@contrasena", Encriptar.GetSHA1(contrasena));
                cmd.Parameters.AddWithValue("@area", area);
                cmd.Parameters.AddWithValue("@rol", rol);
                cmd.Parameters.AddWithValue("@ruta", ruta);
                return (ejectuarSQL(cmd) > 0) ? true : false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public bool validarAcceso()
        {
            try
            {
                string query = "SELECT id_usuario,rol, nombre,paterno,materno,ruta FROM usuarios WHERE email = @email AND contrasena = @contrasena";
                SqlCommand cmd = new SqlCommand(query);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@contrasena",Encriptar.GetSHA1(contrasena));
                DataTable usuario = consulta(cmd);
                if (usuario.Rows.Count > 0)
                {
                    id_usuario = (int)(usuario.Rows[0]["id_usuario"]);
                    rol = int.Parse(usuario.Rows[0]["rol"].ToString());
                    nombre = (string)(usuario.Rows[0]["nombre"]);
                    paterno = (string)(usuario.Rows[0]["paterno"]);
                    materno = (string)(usuario.Rows[0]["materno"]);
                    ruta = (string)(usuario.Rows[0]["ruta"]);
                }
                return (usuario.Rows.Count > 0) ? true : false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public bool correoExistente()
        {
            try
            {
                string query = "SELECT email FROM usuarios WHERE email = @email";
                DataTable usuarios = new DataTable();
                SqlCommand cmd = new SqlCommand(query);
                cmd.Parameters.AddWithValue("@email", email);
                usuarios = consulta(cmd);
                return (usuarios.Rows.Count > 0) ? true : false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public int asignarArea(string area)
        {
            try
            {
                string query = "SELECT id_area from areas WHERE area = @area";
                SqlCommand cmd = new SqlCommand(query);
                cmd.Parameters.AddWithValue("@area", area);
                return int.Parse(consulta(cmd).Rows[0]["id_area"].ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public DataTable traerAreas()
        {
            try
            {
                string query = "SELECT area FROM Areas";
                SqlCommand cmd = new SqlCommand(query);
                return consulta(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable traerUsuarios()
        {
            try
            {
                string query = "SELECT U.id_usuario, U.nombre,U.paterno,U.materno,U.ruta,A.area, U.especialidad  FROM usuarios U INNER JOIN areas A ON U.area = A.id_area;";
                SqlCommand cmd = new SqlCommand(query);
                return consulta(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable traerUsuario()
        {
            try
            {
                string query = "SELECT U.id_usuario, U.nombre,U.paterno,U.materno,U.email,U.telefono,U.ruta,A.area, U.especialidad, R.rol FROM usuarios U INNER JOIN "
                + "areas A ON U.area = A.id_area INNER JOIN roles R ON U.rol = R.id_rol WHERE U.id_usuario = @id_usuario;";
                SqlCommand cmd = new SqlCommand(query);
                cmd.Parameters.AddWithValue("@id_usuario", id_usuario);
                return consulta(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int modificarUsuario()
        {
            try
            {
                string query = "UPDATE usuarios SET nombre = dbo.InitCap(@nombre), paterno = dbo.InitCap(@paterno), materno = dbo.InitCap(@materno), rol = @rol,  area = @area, telefono = @telefono, " +
                    "email = @email, especialidad = dbo.InitCap(@especialidad), ruta = @ruta WHERE id_usuario = @id_usuario";
                SqlCommand cmd = new SqlCommand(query);
                cmd.Parameters.AddWithValue("@nombre",nombre);
                cmd.Parameters.AddWithValue("@paterno", paterno);
                cmd.Parameters.AddWithValue("@materno", materno);
                cmd.Parameters.AddWithValue("@rol", rol);            
                cmd.Parameters.AddWithValue("@area", area);
                cmd.Parameters.AddWithValue("@telefono", telefono);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@especialidad", especialidad);
                cmd.Parameters.AddWithValue("@ruta", ruta);
                cmd.Parameters.AddWithValue("@id_usuario",id_usuario);
                return ejectuarSQL(cmd);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

       

        public string getNombreUsuario()
        {
            try
            {
                string query = "SELECT * FROM usuarios WHERE email = @email";
                SqlCommand cmd = new SqlCommand(query);
                cmd.Parameters.AddWithValue("@email",email);
                DataTable usuario = consulta(cmd);
                string nombre = (string)(usuario.Rows[0]["nombre"]);
                nombre += " " + (string)(usuario.Rows[0]["paterno"]);
                nombre += " " + (string)(usuario.Rows[0]["materno"]);
                return nombre;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int actualizarPass(string pass)
        {
            try
            {
                string query = "UPDATE usuarios SET contrasena = @contrasena WHERE email = @email";
                SqlCommand cmd = new SqlCommand(query);
                cmd.Parameters.AddWithValue("@contrasena",pass);
                cmd.Parameters.AddWithValue("@email",email);
                return ejectuarSQL(cmd);
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int CambiarPass(string pass)
        {
            try
            {
                string query = "UPDATE usuarios SET contrasena = @contrasena WHERE id_usuario=@id_usuario";
                SqlCommand cmd = new SqlCommand(query);
                cmd.Parameters.AddWithValue("@contrasena",Encriptar.GetSHA1(pass));
                cmd.Parameters.AddWithValue("@id_usuario", id_usuario);
                return ejectuarSQL(cmd);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public bool validarPass()
        {
            try
            {
                string query = "SELECT contrasena FROM usuarios WHERE contrasena = @contrasena AND id_usuario= @id_usuario";
                SqlCommand cmd = new SqlCommand(query);
                cmd.Parameters.AddWithValue("@contrasena", Encriptar.GetSHA1(contrasena));
                cmd.Parameters.AddWithValue("@id_usuario", id_usuario);
                return (consulta(cmd).Rows.Count > 0) ? true : false;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        public int AgregarArea(string a)
        {
            try
            {
                string query = "INSERT INTO areas(area) VALUES (@area); ";
                SqlCommand cmd = new SqlCommand(query);
                cmd.Parameters.AddWithValue("@area", a);
                return ejectuarSQL(cmd);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
        public bool areaEnUso(string a)
        {
            try
            {
                string query = "SELECT A.area  FROM usuarios U INNER JOIN areas A ON U.area = A.id_area WHERE A.area = @area;";
                SqlCommand cmd = new SqlCommand(query);
                cmd.Parameters.AddWithValue("@area", a);
                return (consulta(cmd).Rows.Count > 0) ? true : false;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public int eliminarArea(string a)
        {
            try
            {

                string query = "DELETE FROM areas WHERE area=@area;";
                SqlCommand cmd = new SqlCommand(query);
                cmd.Parameters.AddWithValue("@area", a);
                return ejectuarSQL(cmd);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public DataTable traerMisProyectos()
        {
            try
            {
                string query = "SELECT p.id_proyecto, p.proyecto, p.fecha_registro,CAST(p.fecha_inicio AS varchar) as fecha_inicio ,CAST(p.fecha_final AS varchar) as fecha_final FROM relaciones r INNER JOIN usuarios u ON r.id_usuarios = u.id_usuario " +
                    "INNER JOIN proyectos p ON r.id_proyecto = p.id_proyecto WHERE r.id_usuarios = @id_usuario AND estatus = 1;";
                SqlCommand cmd = new SqlCommand(query);
                cmd.Parameters.AddWithValue("@id_usuario", id_usuario);
                return consulta(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //public bool isBusy()
        //{
        //    try
        //    {


        //    }
        //    catch (Exception ex)
        //    {

        //        throw new Exception(ex.Message);
        //    }
        //}

    }
}