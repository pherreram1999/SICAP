using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SICAP
{
    public partial class perfilProyecto : System.Web.UI.Page
    {
        SICAP.Modelos.Proyecto proyect;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["id_proyecto"] == null)
            {
                Response.Redirect("proyectos.aspx");
            }

            if (!IsPostBack)
            {
                proyect = new SICAP.Modelos.Proyecto();
                proyect.id_proyecto = int.Parse(Request.Params["id_proyecto"]);
                proyect.cargarDatos();
                lblNombreProyecto.Text = proyect.proyecto;
                lblObservaciones.Text = proyect.observaciones;
                txtFechaInicio.Text = proyect.fecha_inicio;
                txtFechaFinal.Text = proyect.fecha_final;
                dllEstatus.SelectedItem.Text = proyect.estatus;
                gvActividades.DataSource = proyect.traerActividades();
                gvActividades.DataBind();
            }


            if (lbxUsuarios.Items.Count == 0)
            {
                foreach(string user in proyect.traerUsuariosLista())
                {
                    lbxUsuarios.Items.Add(user);
                }
            }

            
            
        }

        protected void btnEstatus_Click(object sender, EventArgs e)
        {
            if(btnEstatus.Text != "Cancelar modificacion")
            {
                dllEstatus.Enabled = true;
                btnEstatus.Text = "Cancelar modificacion";
                btnEstatus.CssClass = "btn red";
            }
            else
            {
                dllEstatus.Enabled = false;
                btnEstatus.Text = "Modificar estatus";
                btnEstatus.CssClass = "btn";
            }
        }

        protected void dllEstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            proyect = new SICAP.Modelos.Proyecto();
            proyect.id_proyecto = int.Parse(Request.Params["id_proyecto"]);
            proyect.cambiarEstatus(int.Parse(dllEstatus.SelectedItem.Value));
            dllEstatus.Enabled = false;
            btnEstatus.CssClass = "btn";
            btnEstatus.Text = "Modificar estatus";
        }
    }
}