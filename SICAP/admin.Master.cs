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