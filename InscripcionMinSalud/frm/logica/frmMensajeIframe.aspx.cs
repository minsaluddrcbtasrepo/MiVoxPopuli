using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InscripcionMinSalud.frm.logica
{
    public partial class frmMensajeIframe : System.Web.UI.Page
    {
        /// <summary>
        /// Este método se ejecuta cuando se carga la página y configura los mensajes de título y de mensaje en función de la información almacenada en la sesión.
        /// </summary>
        /// <param name="sender">El objeto que genera el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            // Configura los mensajes de título y de mensaje en función de la información almacenada en la sesión

            // Si no es una solicitud POST, recupera los mensajes almacenados en la sesión y configura los controles de la página
            if (!IsPostBack)
            {
                if (Session["msgtitulo"] != null)
                {
                    lbltitulo.Text = Session["msgtitulo"].ToString();
                }
                else
                {
                    lbltitulo.Text = "";
                }

                if (Session["msgmsg"] != null)
                {
                    lblmensaje.Text = Session["msgmsg"].ToString();
                }
                else
                {
                    lblmensaje.Text = "";
                }
            }
        }

        protected void btnFinalizar_Click(object sender, EventArgs e)
        {
            //Response.Redirect("~/Default.aspx");
        }
        


    }
}