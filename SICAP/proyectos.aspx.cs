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
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SICAP.Modelos.Proyecto proyect = new SICAP.Modelos.Proyecto();
                proyect.id_estatus = int.Parse(dllEstatus.SelectedValue);
                gvProyectos.DataSource = proyect.traerProyectos();
                gvProyectos.DataBind();

                foreach (GridViewRow fila in gvProyectos.Rows)
                {
                    proyect.id_proyecto = int.Parse(fila.Cells[0].Text);
                    proyect.fecha_final = fila.Cells[4].Text;
                    if (proyect.expirado())
                    {
                        proyect.concluir();
                    }
                }

                gvProyectos.DataSource = proyect.traerProyectos();
                gvProyectos.DataBind();
            }
            
        }

        protected void dllEstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            SICAP.Modelos.Proyecto proyect = new SICAP.Modelos.Proyecto();
            proyect.id_estatus = int.Parse(dllEstatus.SelectedValue);
            gvProyectos.DataSource = proyect.traerProyectos();
            gvProyectos.DataBind();          
        }
    }
}