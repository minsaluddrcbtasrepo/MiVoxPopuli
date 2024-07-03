using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InscripcionMinSalud.Aspx.Seguridad
{
    public partial class frmLogoOut : System.Web.UI.Page
    {
        /// <summary>
        /// Obtiene o establece un valor booleano que indica si el usuario ha iniciado sesión. Si el valor es nulo, indica que no se ha realizado ningún inicio de sesión. 
        /// </summary>
        private bool? Ingreso
        {
            get
            {
                if (Session["ingreso"] == null)
                {
                    return null;
                }
                else
                {
                    return Convert.ToBoolean(Session["ingreso"]);
                }
            }
            set
            {
                Session["ingreso"] = value;
            }
        }

        /// <summary>
        /// Maneja el evento de carga de la página. Redirige al usuario a la página predeterminada y elimina la sesión actual. Luego, redirige al usuario a la página de inicio de sesión.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Redirect("~/default.aspx");
            Session.Clear();
            Response.Redirect("frmLogin.aspx");
        }

    }
}