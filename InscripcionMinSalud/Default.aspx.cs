using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InscripcionMinSalud
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["SS_COD_REGISTRO"] == null || Session["SS_COD_REGISTRO"].ToString().Trim() == string.Empty)
            {
                Response.Redirect("~/frm/logica/frmdefault.aspx");
            }
            else {
                Response.Redirect("~/frm/logica/frmdefault.aspx");
            }
            
        }
        
    }
}