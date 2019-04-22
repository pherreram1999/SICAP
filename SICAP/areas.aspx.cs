using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SICAP
{
    public partial class areas : System.Web.UI.Page
    {
        SICAP.Modelos.Usuario usu;
        protected void Page_Load(object sender, EventArgs e)
        {
            usu = new SICAP.Modelos.Usuario();

            gvAreas.DataSource = usu.traerAreas();
            gvAreas.DataBind();

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            usu.AgregarArea(txtArea.Text.Trim());
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "mensaje",
                        "alert('Area agregada correctamente'); location.href='./areas.aspx'", true);
        }

        protected void gvAreas_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow fila = gvAreas.SelectedRow;
            if (!usu.areaEnUso(fila.Cells[0].Text))
            {
                usu.eliminarArea(fila.Cells[0].Text);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "mensaje",
                            "alert('Area eliminada correctamente'); location.href='./areas.aspx'", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "mensaje",
                       "alert('El area se encuentra en uso'); location.href='./areas.aspx'", true);
            }

           

            
        }
    }
}