using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SICAP;

namespace SICAP
{
    public partial class proyecto : System.Web.UI.Page
    {
        SICAP.Modelos.Usuario usu;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (lbxUsuarios.Items.Count == 0)
            {
                usu = new SICAP.Modelos.Usuario();
                DataTable usuarios = usu.traerUsuarios();
                foreach (DataRow usuario in usuarios.Rows)
                {
                    int id = (int)(usuario["id_usuario"]);
                    string nombre = usuario["nombre"].ToString();
                    string paterno = usuario["paterno"].ToString();
                    string materno = usuario["materno"].ToString();
                    string especialidad = usuario["especialidad"].ToString();
                    string area = usuario["area"].ToString();

                    string item = id + " - " + " " + nombre + " " + paterno + " " + materno + " - " + especialidad;

                    lbxUsuarios.Items.Add(item);
                }
            }
        }

        protected void lkAsignar_Click(object sender, EventArgs e)
        {
            string message = "";
            foreach (ListItem item in lbxUsuarios.Items)
            {
                message += item.Text + " " + item.Value + "\\n";
            }
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('" + message + "');", true);
        }

       

      
       
    }
}