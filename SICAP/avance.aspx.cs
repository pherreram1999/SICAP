using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SICAP
{
    public partial class avance : System.Web.UI.Page
    {
        SICAP.Modelos.Activdad act;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.Params["id_proyecto"] == null)
            {
                Response.Redirect("misProyectos.aspx");
            }
            act = new SICAP.Modelos.Activdad();
            act.id_proyecto = int.Parse(Request.Params["id_proyecto"]);
            act.cargar();
            
            if (!IsPostBack)
            {
                txtActividad.Text = act.actividad;
            }
            txtFecha.Text = DateTime.Today.ToString("yyyy-MM-dd");

        }
    }
}