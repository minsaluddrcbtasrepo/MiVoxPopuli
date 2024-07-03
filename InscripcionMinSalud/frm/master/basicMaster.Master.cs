using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InscripcionMinSalud.frm.master
{
    public partial class basicMaster : System.Web.UI.MasterPage
    {
        /// <summary>
        /// Este método se ejecuta al cargar la página y muestra u oculta los paneles y menús según si la sesión de usuario está activa o no.
        /// </summary>
        /// <param name="sender">El objeto que genera el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Verifica si la sesión de usuario está activa y muestra u oculta los paneles y menús en consecuencia
                if (Session["IdentificacionParticipante"] != null)
                {
                    pnlIniciarSesion.Visible = false;
                    menuRegistrese.Visible = false;
                    menuUpdate.Visible = true;
                }
                else
                {
                    pnlIniciarSesion.Visible = true;
                    menuRegistrese.Visible = true;
                    menuUpdate.Visible = false;
                }
            }
        }

    }
}