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
            if (Session["id_usuario"] == null)
            {
                Response.Redirect("default.aspx");
            }

            proyect = new SICAP.Modelos.Proyecto();

            if (!IsPostBack)
            {
                proyect.id_proyecto = int.Parse(Request.Params["id_proyecto"]);
                proyect.cargarDatos();
                lblNombreProyecto.Text = proyect.proyecto;
                lblObservaciones.Text = proyect.observaciones;
                txtFechaInicio.Text = proyect.fecha_inicio;
                txtFechaFinal.Text = proyect.fecha_final;
            }

            if(dllEstatus.Items.Count == 0)
            {
                string[] estatus = proyect.traerEstatus();
                foreach(string es in estatus)
                {
                    dllEstatus.Items.Add(es);
                }
            }

            if(lbxUsuarios.Items.Count == 0)
            {
                foreach(string user in proyect.traerUsuariosLista())
                {
                    lbxUsuarios.Items.Add(user);
                }
            }

            if(lbxActividades.Items.Count == 0)
            {
                foreach(string actividad in proyect.traerActividades())
                {
                    lbxActividades.Items.Add(actividad);
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
    }
}