using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SICAP
{
    public partial class _default : System.Web.UI.Page
    {
        SICAP.Modelos.Usuario usu;
        protected void Page_Load(object sender, EventArgs e)
        {
            usu = new Modelos.Usuario();
        }

        protected void btnIniciar_Click1(object sender, EventArgs e)
        {
            usu.email = txtCorreo.Text.Trim();
            usu.contrasena = txtContrasena.Text;
            
            if (usu.validarAcceso())
            {
                if (usu.rol == 0)
                {
                    Response.Redirect("usuarios.aspx");
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "mensaje",
                        "alert('Se manda a usuario')", true);
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "mensaje",
                        "alert('Usuario y/o contraseña incorrectos')", true);
            }
        }

       
       
    }
}