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
            if(Request.Params["id_usuario"] == null)
            {
                Response.Redirect("usuarios.aspx");
            } 
            else if(new SICAP.Modelos.Proyecto().comprobarExistencia("usuarios","id_usuario",int.Parse(Request.Params["id_usuario"])))
            {
                usu = new SICAP.Modelos.Usuario();
                usu.id_usuario = int.Parse(Request.Params["id_usuario"]);
                if (usu.isAdmin() && (int)(Session["id_usuario"]) != 1)
                {
                    btnHabilitar.CssClass = "btn disabled right";
                    hlDesUsu.Visible = false;
                    hlHabUsu.Visible = false;
                    
                }
                else if(int.Parse(Request.Params["id_usuario"]) == (int)(Session["id_usuario"]))
                {
                    btnHabilitar.CssClass = "btn disabled right";
                    hlDesUsu.Visible = false;
                    hlHabUsu.Visible = false;
                    
                }
            }
            else
            {
                Response.Redirect("usuarios.aspx");
            }
            usu = new Modelos.Usuario();                    
            usu.id_usuario = int.Parse(Request.Params["id_usuario"]);            

            if (!usu.IsHabiltado())
            {
                hlDesUsu.Visible = false;
                hlHabUsu.Visible = true;
                btnHabilitar.CssClass = "btn right disabled";
                
            }

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

                

                gvProyectosUsu.DataSource = usu.traerMisProyectos();
                gvProyectosUsu.DataBind();                
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
            
            usu.telefono = txtTelefono.Text.Trim();
            usu.ruta = imgPerfil.ImageUrl;
            usu.area = usu.asignarArea(ddlArea.Text);
            usu.rol = (ddlRol.Text == "Administrador") ? 1 : 2;
            SICAP.Utelirias.Validacion val = new SICAP.Utelirias.Validacion();


            if (ddlRol.Text == "Elija rol de usuario" || ddlArea.Text == "Elija area")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "mensaje",
                        "alert('Favor de completar todos los campos')", true);
            }
            else if (val.hasAnumber(txtNombre.Text) || val.hasAnumber(txtPaterno.Text) || val.hasAnumber(txtMaterno.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "mensaje",
                        "alert('El campo de nombre solo puede contener letras, no numeros')", true);
            }
            else if (!val.hasAnumber(txtTelefono.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "mensaje",
                        "alert('El campo de telefono solo puede tener numeros')", true);
            }
            else
            {
                usu.modificarUsuario();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "mensaje",
                        "alert('Datos modificados correctamente'); location.href= './usuarios.aspx'", true);
            }
        }

        protected void lbPerfil_Click(object sender, EventArgs e)
        {
            if (fuPerfil.HasFile)
            {
                if (SICAP.Modelos.Usuario.validarExtensionImg(fuPerfil.FileName))
                {
                    usu.ruta = "./Imagenes/" + fuPerfil.FileName;
                    fuPerfil.SaveAs(Server.MapPath(".") + usu.ruta);
                    imgPerfil.ImageUrl = usu.ruta;
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "mensaje",
                        "alert('La imagen no tiene un formato valido; PNG,JPG o GIF');", true);
                }
                
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "mensaje",
                        "alert('No ha selecionado ningun archvio');", true);
            }
        }

        protected void btnHabilitar_Click(object sender, EventArgs e)
        {
            if(btnHabilitar.Text == "Modificar")
            {
                txtEmail.Enabled = true;
                txtEspecialidad.Enabled = true;
                txtMaterno.Enabled = true;
                txtNombre.Enabled = true;
                txtPaterno.Enabled = true;
                txtTelefono.Enabled = true;
                btnRegisrar.Enabled = true;
                fuPerfil.Enabled = true;
                if((int)(Session["id_usuario"]) == 1)
                {
                    ddlRol.Enabled = true;
                }
                ddlArea.Enabled = true;
                btnHabilitar.Text = "Cancelar Modificacion";
                btnHabilitar.CssClass = " btn red white-text right";
            }
            else 
            {
                Response.Redirect("usuarios.aspx");
            }
        }

      
        protected void btnDeshabilitarUusuario_Click1(object sender, EventArgs e)
        {            
            var usuario = new SICAP.Modelos.Usuario();
            usuario.id_usuario = int.Parse(Request.Params["id_usuario"]);
            usuario.deshabilitar();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "mensaje",
                        string.Format("location.href='./usuario.aspx?id_usuario={0}'",Request.Params["id_usuario"]), true);
        }

        protected void btnHabilitarUsuario_Click(object sender, EventArgs e)
        {
            var usuario = new SICAP.Modelos.Usuario();
            usuario.id_usuario = int.Parse(Request.Params["id_usuario"]);
            usuario.habilitar();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "mensaje",
                        string.Format("location.href='./usuario.aspx?id_usuario={0}'", Request.Params["id_usuario"]), true);
        }
    }
}