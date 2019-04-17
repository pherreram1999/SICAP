﻿using SICAP.DAO;
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
                + "values(@nombre,@paterno,@materno,@telefono,@email,@especialidad,@contrasena,@area,@rol,@ruta)";
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
                string query = "SELECT rol, nombre,paterno,materno,ruta FROM usuarios WHERE email = @email AND contrasena = @contrasena";
                SqlCommand cmd = new SqlCommand(query);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@contrasena",Encriptar.GetSHA1(contrasena));
                DataTable usuario = consulta(cmd);
                if (usuario.Rows.Count > 0)
                {
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
                string query = "SELECT U.id_usuario, U.nombre,U.paterno,U.materno,A.area, U.especialidad  FROM usuarios U INNER JOIN areas A ON U.area = A.id_area;";
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
                string query = "UPDATE usuarios SET nombre = @nombre, paterno = @paterno, materno = @materno, rol = @rol, contrasena = @contrasena, area = @area, telefono = @telefono, " +
                    "email = @email, especialidad = @especialidad, ruta = @ruta WHERE id_usuario = @id_usuario";
                SqlCommand cmd = new SqlCommand(query);
                cmd.Parameters.AddWithValue("@nombre",nombre);
                cmd.Parameters.AddWithValue("@paterno", paterno);
                cmd.Parameters.AddWithValue("@materno", materno);
                cmd.Parameters.AddWithValue("@rol", rol);
                cmd.Parameters.AddWithValue("@contrasena", Encriptar.GetSHA1(contrasena));
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
    }
}