using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InscripcionMinSalud.Aspx
{
    public partial class Confirmar : System.Web.UI.Page
    {
        /// <summary>
        /// Redirige a la página de inicio predeterminada cuando se carga la página.
        /// </summary>
        /// <param name="sender">El objeto que genera el evento.</param>
        /// <param name="e">Los argumentos del evento.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Redirect("~/default.aspx");
        }

        /// <summary>
        /// Redirige al formulario de inicio de sesión al hacer clic en el botón "Salir".
        /// </summary>
        /// <param name="sender">El objeto que genera el evento.</param>
        /// <param name="e">Los argumentos del evento.</param>
        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Aspx/Seguridad/frmLogin.aspx");
        }


    }
}