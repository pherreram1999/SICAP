using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SICAP.DAO
{
    public abstract class Conexion
    {
        private string cdnConexion;
       
        private SqlConnection cnn;        

        public Conexion()
        {
            cdnConexion = @"Data Source = DESKTOP-PB21R03\SQLEXPRESS;Initial Catalog= SICAP ;Trusted_Connection=True;";
            cnn = new SqlConnection(cdnConexion);
        }

        /// <summary>
        /// Consultar una tabla sql
        /// </summary>
        /// <param name="cmd">Se le pasa un sqlcommand</param>
        /// <returns>Retorna un DataTable</returns>
        protected DataTable consulta(SqlCommand cmd)
        {
            try
            {
                cmd.Connection = cnn;
                cnn.Open();
                DataTable tabla = new DataTable();
                tabla.Load(cmd.ExecuteReader());
                cnn.Close();
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
        /// <summary>
        /// Ejecuta la instruccion SQL para la modificacion de tablas
        /// </summary>
        /// <param name="cmd">Se le pasa un sqlcommand</param>
        /// <returns>el numero de filas afectadas</returns>
        protected int ejectuarSQL(SqlCommand cmd)
        {
            try
            {
                cnn.Open();
                cmd.Connection = cnn;
                int resultado = cmd.ExecuteNonQuery();
                cnn.Close();
                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
    }
}