using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SICAP
{
    public partial class avance : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtFecha.Text = DateTime.Today.ToString("yyyy-MM-dd");
        }
    }
}