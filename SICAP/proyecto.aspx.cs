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
            usu = new SICAP.Modelos.Usuario();
            proyect = new SICAP.Modelos.Proyecto();

            

            if (!IsPostBack)
            {
                txtFechaInicialProyecto.Text = DateTime.Today.ToString("yyyy-MM-dd");
                txtFechaInicialProyecto.Attributes.Add("min", DateTime.Today.ToString("yyyy-MM-dd"));
                txtFechaFinalProyecto.Attributes.Add("min", DateTime.Today.ToString("yyyy-MM-dd"));
                txtfechaEntregaActividad.Attributes.Add("min", DateTime.Today.ToString("yyyy-MM-dd"));

                DataTable usuarios = usu.traerUsuarios();
                foreach (DataRow usuario in usuarios.Rows)
                {
                    /// aqui es donde lo concateno tengo que hacer forech entonces??
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

            

            if(lbxUsuariosSeleccionados.Items.Count > 0)
            {
                if(lbxActividades.Items.Count > 0)
                {
                    DateTime incial = DateTime.Parse(proyect.fecha_inicio);
                    DateTime final = DateTime.Parse(proyect.fecha_final);
                    if(DateTime.Compare(incial,final) == 0)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "mensaje",
                                    "alert('Error: la fecha de incio y termino son identicas,favor de verificar las fechas');", true);
                    }
                    else if(DateTime.Compare(incial,final) > 0)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "mensaje",
                                    "alert('Error: la fecha de inicio sobrepasa a fecha de termino') location.href= './proyecto.aspx';", true);
                    }
                    else
                    {
                        proyect.guardar();
                        proyect.id_proyecto = proyect.getID();
                        proyect.asignarUsuarios();
                        proyect.asignarActividades();
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "mensaje",
                                    "alert('Proyecto Creado correctamente'); location.href='./proyectos.aspx'", true);
                    }                    
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "mensaje",
                        "alert('No se ha agregado ninguna actividad');", true);
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "mensaje",
                        "alert('No se ha selecionado ningun usuario');", true);
            }
        }

        protected void txtFechaFinalProyecto_TextChanged(object sender, EventArgs e)
        {
            txtfechaEntregaActividad.Attributes.Add("max",txtFechaFinalProyecto.Text);
        }

        protected void txtFechaInicialProyecto_TextChanged(object sender, EventArgs e)
        {
            txtFechaFinalProyecto.Attributes.Add("min",txtFechaInicialProyecto.Text);
            txtfechaEntregaActividad.Attributes.Add("min",txtFechaInicialProyecto.Text);
        }
    }
}