using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SICAP
{
    public partial class usuarios : System.Web.UI.Page
    {
        SICAP.Modelos.Usuario usu;
        protected void Page_Load(object sender, EventArgs e)
        {
            usu = new SICAP.Modelos.Usuario();
            gvUsurios.DataSource = usu.traerUsuarios();
            gvUsurios.DataBind();
        }
    }
}