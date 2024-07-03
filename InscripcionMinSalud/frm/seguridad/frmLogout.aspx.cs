using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InscripcionMinSalud.frm.seguridad
{
    public partial class frmLogout : System.Web.UI.Page
    {
        /// <summary>
        /// Este método se ejecuta cuando se carga la página y se encarga de limpiar la sesión actual.
        /// </summary>
        /// <param name="sender">El objeto que genera el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Clear();
        }

    }
}