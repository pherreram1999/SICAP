using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SICAP
{
    public partial class avances : System.Web.UI.Page
    {
        SICAP.Modelos.Avance act;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["id_proyecto"] == null)
            {
                Response.Redirect("proyectos.aspx");
            }


            if (!IsPostBack)
            {
                SICAP.Modelos.Proyecto pro = new SICAP.Modelos.Proyecto();
                pro.id_proyecto = int.Parse(Request.Params["id_proyecto"]);
                pro.cargarDatos();
                lblNombreProyecto.Text = pro.proyecto;
                SICAP.Modelos.Avance avan = new SICAP.Modelos.Avance();
                avan.id_proyecto = pro.id_proyecto;
                gvAvances.DataSource = avan.traerAvances();
                gvAvances.DataBind();                
                hlAgregarAvance.NavigateUrl = "avance.aspx?id_proyecto=" + pro.id_proyecto;

                if (pro.estatus != "Activo")
                {
                    hlAgregarAvance.Enabled = false;
                    hlAgregarAvance.CssClass = "btn-floating btn-large tooltipped disabled";
                }
            
            }

            

            
        }
    }
}