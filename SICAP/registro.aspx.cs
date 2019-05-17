﻿using SICAP.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SICAP
{
    public partial class registro : System.Web.UI.Page
    {
        SICAP.Modelos.Usuario usu;
        
        protected void Page_Load(object sender, EventArgs e)
        {


            usu = new SICAP.Modelos.Usuario();

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

            if (usu.correoExistente())
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
                usu.guardar();
                SICAP.Utelirias.Correo.EnviarCorreo(txtEmail.Text,"Registro SICAP",string.Format("Buen dia,<strong>{0}</strong>,<br /> tu correo es: {1} <br /> tu contraseña es: {2} <br /> con estas credenciales podras acceder al sistema",
                    txtNombre.Text.Trim() + " " + txtPaterno.Text.Trim() + " " + txtMaterno.Text.Trim(),txtEmail.Text.Trim(),txtContrasena.Text));
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "mensaje",
                        "alert('usuario guardado correctamente'); location.href='./usuarios.aspx'", true);
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
    }
}