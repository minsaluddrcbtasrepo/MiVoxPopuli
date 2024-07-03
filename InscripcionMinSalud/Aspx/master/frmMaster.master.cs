using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InscripcionMinSalud.Aspx.master
{
    public partial class frmMaster : System.Web.UI.MasterPage
    {
        public string classInicio = "";
        public string classRegistrese = "";
        public string classEncuesta = "";
        public string classContactenos = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Redirect("~/default.aspx");
        }
    }
}