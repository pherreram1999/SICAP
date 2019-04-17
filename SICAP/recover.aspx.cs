using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SICAP
{
    public partial class recover : System.Web.UI.Page
    {
        SICAP.Modelos.Usuario usu;
        protected void Page_Load(object sender, EventArgs e)
        {
            usu = new SICAP.Modelos.Usuario();
        }

        protected void btnRecuperar_Click(object sender, EventArgs e)
        {
            usu.email = txtEmail.Text.Trim();
            if (usu.correoExistente())
            {
                string contrasena = SICAP.Utelirias.GenerarPass.get();
                string mensaje = "Hola " + usu.getNombreUsuario() + ", tu nueva contraseña es: <stronG>" + contrasena + "</strong>";
                contrasena = SICAP.Utelirias.Encriptar.GetSHA1(contrasena);
                usu.actualizarPass(contrasena);
                SICAP.Utelirias.Correo.EnviarCorreo(usu.email, "nueva contraseña SICAP", mensaje);

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "mensaje",
                        "alert('La nueva contraseña se ha enviado a tu correo electronico'); location.href= './default.aspx'", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "mensaje",
                        "alert('El correo no se encuentra registrado');", true);
            }
        }
    }
}