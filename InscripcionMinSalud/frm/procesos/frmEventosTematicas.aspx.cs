using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InscripcionMinSalud.frm.procesos
{
    public partial class frmEventosTematicas : System.Web.UI.Page
    {
        /// <summary>
        /// Maneja el evento Page_Load.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            // Redirige a la página "frmEventosTematica.aspx" incluyendo los parámetros de la cadena de consulta originales
            Response.Redirect("frmEventosTematica.aspx?" + Request.QueryString);
        }

    }
}