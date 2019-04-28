using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SICAP
{
    public partial class proyectos : System.Web.UI.Page
    {
        SICAP.Modelos.Proyecto proyect;
        protected void Page_Load(object sender, EventArgs e)
        {
            

            if (!IsPostBack)
            {
                proyect = new SICAP.Modelos.Proyecto();
                gvProyectos.DataSource = proyect.traerProyectos();

                foreach (GridViewRow fila in gvProyectos.Rows)
                {
                    proyect.id_proyecto = int.Parse(fila.Cells[0].Text);
                    if (proyect.expirado())
                    {
                        proyect.concluir();
                    }
                }
                gvProyectos.DataSource = proyect.traerProyectos();
                gvProyectos.DataBind();
            }
        }
    }
}