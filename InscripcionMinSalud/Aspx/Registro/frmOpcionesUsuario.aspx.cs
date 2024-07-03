using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InscripcionMinSalud.Aspx.Registro
{
    public partial class frmOpcionesUsuario : System.Web.UI.Page
    {
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

        public string IdentificacionParticipante
        {
            get
            {
                if (Session["IdentificacionParticipante"] == null)
                {
                    return null;
                }
                return Session["IdentificacionParticipante"].ToString();
            }
            set
            {
                Session["IdentificacionParticipante"] = value;
            }
        }

        /// <summary>
        /// Carga los datos del participante en la aplicación.
        /// </summary>
        public void CargarDatos()
        {
            NegocioInscripcionMinSalud.Participante donante = NegocioInscripcionMinSalud.Participante.ObtenerParticipanteNumeroIdentificacion(IdentificacionParticipante);

            if (donante.IdTipoUsuario == 9 || donante.IdTipoIdentificacion == 11)
            {
                this.lblNombres.InnerText = "<strong>Nombre del Participante:</strong>    " + donante.Nombres + " " + donante.Apellidos;
                this.lblNombres.InnerHtml = lblNombres.InnerText;
            }
            else
            {
                this.lblNombres.InnerText = "<strong>Nombre del Participante:</strong>    " + donante.Nombres;
                this.lblNombres.InnerHtml = lblNombres.InnerText;
            }
            this.txtCedulas.InnerText = "<strong>Número de identificación:</strong>  " + donante.NumeroIdentificacion;
            this.txtCedulas.InnerHtml = txtCedulas.InnerText;
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Redirect("~/default.aspx");
            if (Session["IdentificacionParticipante"] == null)
            {
                    Response.Redirect("~/Aspx/Seguridad/frmLogin.aspx");
                    return;
            }
            if (!IsPostBack)
            {
                                    
                    CargarDatos();
             
            }
        }

        /// <summary>
        /// Redirige al formulario de modificación de datos del participante.
        /// </summary>
        /// <param name="sender">El control que genera el evento.</param>
        /// <param name="e">Los argumentos del evento.</param>
        protected void btnModificarDatos2_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Aspx/Registro/frmParticipante.aspx?participante=" + IdentificacionParticipante);
        }

        /// <summary>
        /// Cierra la sesión y redirige al formulario de inicio de sesión.
        /// </summary>
        /// <param name="sender">El control que genera el evento.</param>
        /// <param name="e">Los argumentos del evento.</param>
        protected void btnSalir2_Click(object sender, ImageClickEventArgs e)
        {
            Session.Clear();
            Response.Redirect("~/Aspx/Seguridad/frmLogin.aspx");
        }

        /// <summary>
        /// Redirige al formulario de confirmación de eventos.
        /// </summary>
        /// <param name="sender">El control que genera el evento.</param>
        /// <param name="e">Los argumentos del evento.</param>
        protected void btnEventos_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Aspx/evento/frmConfirmacionEvento.aspx");
        }


    }
}