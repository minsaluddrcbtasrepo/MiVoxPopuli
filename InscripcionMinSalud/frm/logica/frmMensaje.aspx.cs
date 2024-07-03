using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InscripcionMinSalud.frm.logica
{
    public partial class frmMensaje : System.Web.UI.Page
    {
        /// <summary>
        /// Método que se ejecuta al cargar la página y configura los mensajes de título y de mensaje en función de la información almacenada en la sesión.
        /// </summary>
        /// <param name="sender">El objeto que genera el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["msgtitulo"] != null)
                {
                    lbltitulo.Text = Session["msgtitulo"].ToString();
                }
                else
                {
                    lbltitulo.Text = "Mensaje de título no encontrado en la sesión.";
                }

                if (Session["msgmsg"] != null)
                {
                    lblmensaje.Text = Session["msgmsg"].ToString();
                }
                else
                {
                    lblmensaje.Text = "Mensaje no encontrado en la sesión.";
                }
            }
        }


    }
}