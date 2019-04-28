using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SICAP
{
    public partial class perfilAvance : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.Params["ID"] == null)
            {
                Response.Redirect("misProyectos.aspx");                
            }
            if (!IsPostBack)
            {
                SICAP.Modelos.Avance avan = new SICAP.Modelos.Avance(int.Parse(Request.Params["ID"]));
                lbAvance.Text = avan.NombreAvance;
                lbObservaciones.Text = avan.observaciones;
                lblFechaRegistro.Text = avan.fecha_registro;
                lblPropietario.Text = avan.usuario;
                string nombreArchivo = avan.rutaDoc.Split('/').Last();
                lblArchivo.Text = "Archivo: " + nombreArchivo;
                if(avan.rutaDoc == "")
                {
                    hlDescargar.CssClass = "btn disabled";
                    lblArchivo.Text = "No se adjunto ningún archivo";
                }
                else
                {
                    hlDescargar.NavigateUrl = avan.rutaDoc;
                }
            }
        }


    }
}