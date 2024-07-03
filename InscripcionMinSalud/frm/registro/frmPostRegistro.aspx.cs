using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InscripcionMinSalud.frm.registro
{
    public partial class frmPostRegistro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["correoRegistrado"] != null && Session["correoRegistrado"].ToString().Trim() != string.Empty)
            {
                lblCorreo.Text = Session["correoRegistrado"].ToString();
            }
        }
    }
}