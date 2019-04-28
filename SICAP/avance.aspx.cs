using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SICAP
{
    public partial class avance : System.Web.UI.Page
    {
        SICAP.Modelos.Avance avan;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.Params["id_proyecto"] == null)
            {
                Response.Redirect("misProyectos.aspx");
            }
                               
            
            if (!IsPostBack)
            {
                txtFecha.Text = DateTime.Today.ToString("yyyy-MM-dd");
                avan = new SICAP.Modelos.Avance();
                avan.id_proyecto = int.Parse(Request.Params["id_proyecto"]);
                foreach(string actividad in avan.getActividades())
                {
                    dllActividades.Items.Add(actividad);
                }
            }

        }


        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            avan = new SICAP.Modelos.Avance();
            avan.NombreAvance = txtNombreAvance.Text.Trim();
            avan.observaciones = txtObservaciones.Text;
            avan.id_proyecto = int.Parse(Request.Params["id_proyecto"]);
            avan.id_usuario = (int)(Session["id_usuario"]);
            avan.id_actividad = int.Parse(char.ToString(dllActividades.SelectedItem.Text[0]));
            

            if (fuArchivos.HasFile)
            {
                string[] extension = fuArchivos.FileName.Split('.');
                string ruta = Server.MapPath(".") + "./Documentos/" + extension[1];
                if (!Directory.Exists(ruta))
                {
                    Directory.CreateDirectory(ruta);
                }              
                ruta += "./" + fuArchivos.FileName;
                fuArchivos.SaveAs(ruta);
                ruta = "~/Documentos/" + extension[1] + "/" + fuArchivos.FileName;
                avan.guardar(ruta);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "mensaje",
                        string.Format("alert('avance registrado'); location.href='./avances.aspx?id_proyecto={0}'", avan.id_proyecto), true);
            }
            else
            {
                avan.guardar();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "mensaje",
                        string.Format("alert('avance registrado'); location.href='./avances.aspx?id_proyecto={0}'", avan.id_proyecto), true);
            }


        }
    }
}