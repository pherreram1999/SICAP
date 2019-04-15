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
            usu = new Modelos.Usuario();

            if (!IsPostBack)
            {
                
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

            if (ddlArea.Items.Count == 1)
            {
                foreach (DataRow row in usu.traerAreas().Rows)
                {
                    ddlArea.Items.Add(row["area"].ToString());
                }
            }

        }

        protected void btnRegisrar_Click(object sender, EventArgs e)
        {
            usu.id_usuario = int.Parse(Request.Params["id_usuario"]);
            usu.nombre = txtNombre.Text.Trim();
            usu.paterno = txtPaterno.Text.Trim();
            usu.materno = txtMaterno.Text.Trim();
            usu.email = txtEmail.Text.Trim();
            usu.especialidad = txtEspecialidad.Text.Trim();
            usu.contrasena = txtContrasena.Text.Trim();
            usu.telefono = txtTelefono.Text.Trim();
            usu.ruta = imgPerfil.ImageUrl;
            usu.area = usu.asignarArea(ddlArea.Text);
            usu.rol = (ddlRol.Text == "Administrador") ? 1 : 2; 

            if (!usu.correoExistente())
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "mensaje",
                        "alert('correo electronico ya registrado')", true);
            }
            else if (txtContrasena.Text.Trim() != txtConfirmarContrasena.Text.Trim())
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "mensaje",
                        "alert('las contraseñas no coinciden')", true);
            }
            else if (ddlRol.Text == "Elija rol de usuario" || ddlArea.Text == "Elija area")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "mensaje",
                        "alert('Favor de completar todos los campos')", true);
            }
            else
            {
                usu.modificarUsuario();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "mensaje",
                        "alert('Datos modificados correctamente'); location.href= './usuarios.aspx'", true);
            }
        }
    }
}