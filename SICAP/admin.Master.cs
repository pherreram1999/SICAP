using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SICAP
{
    public partial class admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id_usuario"] == null)
            {
                Response.Redirect("default.aspx");                
            }
            else if((int)(Session["rol"]) == 2)
            {
                hlAdministrar.Visible = false;
                hlProyectos.Visible = false;
                hlEmpleados.Visible = false;
                hlRegistrar.Visible = false;
                hlVerProyectos.Visible = false;
                hlAreas.Visible = false;
                string js = "var p = location.href;var r = p.split('/');" +
                    "if(r[3] == 'misProyectos.aspx') {  } else {var r2 = r[3].split('?'); if(r2[0] == 'perfilProyecto.aspx') {} else " +
                    "{location.href = './misProyectos.aspx'} } ";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "mensaje",
                       js, true);
            }

            if (!IsPostBack)
            {
                hlMiPerfil.NavigateUrl = "usuario.aspx?id_usuario=" + (int)(Session["id_usuario"]); 
            }

            string nombreUsuario = (string)(Session["nombre"]) + " " + (string)(Session["paterno"]) + " " + (string)(Session["materno"]);
            lblNombreUsuario.Text = nombreUsuario;
            userFoto.ImageUrl = (string)(Session["ruta"]);
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session["id_usuario"] = null;
            Response.Redirect("default.aspx");
        }
    }
}