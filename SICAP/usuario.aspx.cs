using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SICAP
{
    public partial class usuario : System.Web.UI.Page
    {
        SICAP.Modelos.Usuario usu;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id_usuario"] == null)
            {
                Response.Redirect("default.aspx");
            }

            if (!IsPostBack)
            {
                usu = new Modelos.Usuario();
                usu.id_usuario = int.Parse(Request.Params["id_usuario"]);
                DataTable usuario = usu.traerUsuario();
                imgPerfil.ImageUrl = (string) (usuario.Rows[0]["ruta"]);
                txtNombre.Text = (string)(usuario.Rows[0]["nombre"]);
                txtPaterno.Text = (string)(usuario.Rows[0]["paterno"]);
                txtMaterno.Text = (string)(usuario.Rows[0]["materno"]);
                txtEmail.Text = (string)(usuario.Rows[0]["email"]);
                txtEspecialidad.Text = (string)(usuario.Rows[0]["especialidad"]);
                txtTelefono.Text = (string) (usuario.Rows[0]["telefono"]);
                ddlArea.SelectedItem.Text = (string)(usuario.Rows[0]["area"]);
                ddlRol.SelectedItem.Text = (string)(usuario.Rows[0]["rol"]);
            }

        }

    

        
    }
}