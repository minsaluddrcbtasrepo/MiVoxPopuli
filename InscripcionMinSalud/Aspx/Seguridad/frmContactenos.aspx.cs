using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InscripcionMinSalud.Aspx.Seguridad
{
    public partial class frmContactenos : System.Web.UI.Page
    {
        /// <summary>
        /// Redirige a los usuarios a la página de inicio predeterminada.
        /// </summary>
        /// <param name="sender">El objeto que genera el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Redirect("~/default.aspx");
        }

    }
}