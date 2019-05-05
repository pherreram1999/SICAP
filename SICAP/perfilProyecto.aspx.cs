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
            if ((int)(Session["rol"]) == 2)
            {
                dllEstatus.Visible = false;
                btnEstatus.Visible = false;
                lblEstatus.Visible = false;
                eliminarBoton.Visible = false;
                hlEliminarProyecto.Visible = false;
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
                SICAP.Modelos.Actividad act = new SICAP.Modelos.Actividad();
                gvActividades.DataSource = act.traerActividades(proyect.id_proyecto);
                gvActividades.DataBind();

                for (int i = 0; i < gvActividades.Rows.Count; i++)
                {
                    act.id_actividad = int.Parse(gvActividades.Rows[i].Cells[0].Text);
                    if (act.expirado())
                    {
                        act.concluir();
                    }
                }

                gvActividades.DataSource = act.traerActividades(proyect.id_proyecto);
                gvActividades.DataBind();

                if (proyect.expirado())
                {
                    proyect.concluir();
                    dllEstatus.SelectedItem.Text = proyect.estatus;
                    btnEstatus.Enabled = false;
                    btnEstatus.CssClass = "btn disabled";
                    btnEstatus.Text = "Proyecto expirado";
                    lblMensaje.Visible = true;
                }


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

        protected void btnAvances_Click(object sender, EventArgs e)
        {
            string pagina = string.Format("avances.aspx?id_proyecto= {0}",Request.Params["id_proyecto"]);
            Response.Redirect(pagina);
        }

        protected void eliminarBoton_Click(object sender, EventArgs e)
        {
            SICAP.Modelos.Proyecto pro = new SICAP.Modelos.Proyecto();
            pro.id_proyecto = int.Parse(Request.Params["id_proyecto"]);
            if (!pro.eliminarProyecto())
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "mensaje",
                        "alert('Proyeco eliminado'); location.href='./proyectos.aspx'", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "mensaje",
                        "alert('El proyecto se encuentra actualmente activo'); ", true);
            }
            
            
        }
    }
}