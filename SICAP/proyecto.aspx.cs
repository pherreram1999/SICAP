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
        SICAP.Modelos.Proyecto proyect;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id_usuario"] == null)
            {
                Response.Redirect("default.aspx");
            }

            usu = new SICAP.Modelos.Usuario();
            proyect = new SICAP.Modelos.Proyecto();

            if (!IsPostBack)
            {
                DataTable usuarios = usu.traerUsuarios();
                foreach (DataRow usuario in usuarios.Rows)
                {
                    int id = (int)(usuario["id_usuario"]);
                    string nombre = usuario["nombre"].ToString();
                    string paterno = usuario["paterno"].ToString();
                    string materno = usuario["materno"].ToString();
                    string especialidad = usuario["especialidad"].ToString();
                    string area = usuario["area"].ToString();

                    string item = id + " - " + " " + nombre + " " + paterno + " " + materno + " - " + especialidad;

                    lbxUsuarios.Items.Add(item);
                }
            }
        }

        

        protected void btnPasar_Click(object sender, EventArgs e)
        {
            while (lbxUsuarios.GetSelectedIndices().Length > 0)
            {
                lbxUsuariosSeleccionados.Items.Add(lbxUsuarios.SelectedItem);
                lbxUsuarios.Items.Remove(lbxUsuarios.SelectedItem);
            }
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            while (lbxUsuariosSeleccionados.GetSelectedIndices().Length > 0)
            {
                lbxUsuarios.Items.Add(lbxUsuariosSeleccionados.SelectedItem);
                lbxUsuariosSeleccionados.Items.Remove(lbxUsuariosSeleccionados.SelectedItem);
            }
        }

        protected void btnAgregarActividad_Click(object sender, EventArgs e)
        {
            string actividad = txtNombreActividad.Text.Trim() + "/"+txtObservacionesActividad.Text.Trim()+"/"+ txtfechaEntregaActividad.Text;
            lbxActividades.Items.Add(actividad);
        }

        protected void btnCrearProyecto_Click(object sender, EventArgs e)
        {
            foreach(ListItem item in lbxActividades.Items) // con esto asignamos las actividades
            {
                string[] actividad = item.Text.Split('/');
                proyect.actividades.Add(actividad);
            }

            foreach(ListItem item in lbxUsuariosSeleccionados.Items) // con esto asignamos los usuarios al proyecto
            {
                int usuario = int.Parse(char.ToString(item.Text[0]));                
                proyect.usuarios.Add(usuario);
            }

            proyect.proyecto = txtNombre.Text.Trim();
            proyect.fecha_inicio = txtFechaInicialProyecto.Text;
            proyect.fecha_final = txtFechaFinalProyecto.Text;
            proyect.observaciones = txtObservaciones.Text;
            proyect.guardar();
            proyect.asignarUsuarios();
        }
    }
}