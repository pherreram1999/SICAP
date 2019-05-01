using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SICAP
{
    public partial class misProyectos : System.Web.UI.Page
    {
        SICAP.Modelos.Usuario usu;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id_usuario"] == null)
            {
                Response.Redirect("default.aspx");
            }

            if (!IsPostBack)
            {
                var pro = new SICAP.Modelos.Proyecto();
                usu = new SICAP.Modelos.Usuario();
                usu.id_usuario = (int)(Session["id_usuario"]);
                gvMisProyectos.DataSource = usu.traerMisProyectos();
                gvMisProyectos.DataBind();
                foreach (GridViewRow fila in gvMisProyectos.Rows)
                {
                    pro.id_proyecto = int.Parse(fila.Cells[0].Text);
                    pro.fecha_final = fila.Cells[4].Text;
                    
                    if (pro.expirado())
                    {
                        pro.concluir();
                    }
                }
                gvMisProyectos.DataSource = usu.traerMisProyectos();
                gvMisProyectos.DataBind();
            }

            
        }
    }
}