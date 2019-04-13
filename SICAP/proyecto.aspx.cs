using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SICAP;

namespace SICAP
{
    public partial class proyecto : System.Web.UI.Page
    {
        SICAP.Modelos.Usuario usu;
        protected void Page_Load(object sender, EventArgs e)
        {
            usu = new SICAP.Modelos.Usuario();
            if (gvUsuarioPorSeleccionar.Rows.Count == 0)
            {
                gvUsuarioPorSeleccionar.DataSource = usu.traerUsuarios();
                gvUsuarioPorSeleccionar.DataBind();
            }
            gvUsuarioSeleccionados.DataBind();
        }

        protected void txtFechaFinalProyecto_TextChanged(object sender, EventArgs e)
        {
            txtfechaEntregaActividad.Attributes.Add("max",txtFechaFinalProyecto.Text);
        }

        protected void gvUsuarioPorSeleccionar_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow fila = gvUsuarioPorSeleccionar.SelectedRow;
            DataTable table = new DataTable();
            table.Rows.Add();
        }
    }
}