using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InscripcionMinSalud.Aspx.Registro
{
    public partial class frmUpdatePerfil : System.Web.UI.Page
    {
      

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

      

        public bool ValidarFormulario()
        {
            bool error = false;
            LblValidacionCampos.Text = "";
            LblValidacionCampos.Text += "Verifique los Siguientes Campos: ";

            cmbTipoUsuario.CssClass = "";
            cmbTipoUsuario.Attributes.Remove("placeholder");
            if (cmbTipoUsuario.SelectedValue == "0")
            {
                error = true;
                LblValidacionCampos.Text += "Tipo usuario, ";
                cmbTipoUsuario.Attributes.Add("placeholder", "Debe seleccionar un tipo de usuario");
                cmbTipoUsuario.CssClass = "form-control errormin";
            }
            else
            {
                cmbTipoUsuario.CssClass = "form-control";
            }

            cmbTipoPerfil.CssClass = "";
            cmbTipoPerfil.Attributes.Remove("placeholder");
            if (cmbTipoPerfil.SelectedValue == "0")
            {
                error = true;
                LblValidacionCampos.Text += "Tipo perfil, ";
                cmbTipoPerfil.Attributes.Add("placeholder", "Debe seleccionar un tipo de perfil");
                cmbTipoPerfil.CssClass = "form-control errormin";
            }
            else
            {
                cmbTipoFuturo.CssClass = "form-control";
            }

            cmbTipoFuturo.CssClass = "";
            cmbTipoFuturo.Attributes.Remove("placeholder");
            if (cmbTipoFuturo.SelectedValue == "0")
            {
                error = true;
                LblValidacionCampos.Text += "Tipo usuario, ";
                cmbTipoFuturo.Attributes.Add("placeholder", "Debe seleccionar un tipo de usuario");
                cmbTipoFuturo.CssClass = "form-control errormin";
            }
            else
            {
                cmbTipoFuturo.CssClass = "form-control";
            }


            return error;
            
        }

 

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (!ValidarFormulario())
            {
                NegocioInscripcionMinSalud.data.clsNegocio obj = new NegocioInscripcionMinSalud.data.clsNegocio();
                obj.actualizarTipoUsuarioxDocumento(IdentificacionParticipante, short.Parse(cmbTipoFuturo.SelectedValue));
                Response.Redirect("~/Aspx/Registro/frmParticipante.aspx?participante=" + IdentificacionParticipante);
            }
        }

     
        private void cargarTiposUsuario()
        {
           


            if (cmbTipoPerfil.SelectedValue == "1")
            {
                cmbTipoFuturo.DataSource = NegocioInscripcionMinSalud.TipoUsuario.ObtenerTiposUsuarionUEVONatural();

            }else{
                cmbTipoFuturo.DataSource = NegocioInscripcionMinSalud.TipoUsuario.ObtenerTiposUsuarionUEVOJuridico();
            }
             
           

            cmbTipoFuturo.DataTextField = "Nombre";
            cmbTipoFuturo.DataValueField = "Id";
            cmbTipoFuturo.DataBind();



        }

        public void CargarDatos()
        {
            NegocioInscripcionMinSalud.Participante participante = NegocioInscripcionMinSalud.Participante.ObtenerParticipanteNumeroIdentificacion(IdentificacionParticipante);
           
            //

            NegocioInscripcionMinSalud.data.clsNegocio obj = new NegocioInscripcionMinSalud.data.clsNegocio();
            var p = obj.obtenerParticipantexdocumento(Session["IdentificacionParticipante"].ToString());
            if (p.TipoUsuario.ES_NUEVO.HasValue && p.TipoUsuario.ES_NUEVO.Value)
            {
                Response.Redirect("frmparticipante.aspx?participante="+ Session["IdentificacionParticipante"]);
            }
            else {
                cargarTiposUsuario();
                cmbTipoUsuario.SelectedValue = participante.IdTipoUsuario.ToString();
            }
            
          

        }

        /// <summary>
        /// Maneja el evento de carga de la página.
        /// Redirige al usuario a la página predeterminada y realiza acciones específicas durante la carga inicial de la página, como la eliminación de la sesión 'ArchivosCargados' y la carga de datos en función de la sesión 'IdentificacionParticipante'.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Redirect("~/default.aspx"); // Redirige al usuario a la página predeterminada

            if (!IsPostBack)
            {
                Session.Remove("ArchivosCargados"); // Elimina la sesión 'ArchivosCargados'
                cmbTipoUsuario.DataSource = NegocioInscripcionMinSalud.TipoUsuario.ObtenerTiposUsuarioviejo(); // Obtiene los tipos de usuario de una fuente de datos y los asigna como origen de datos al control 'cmbTipoUsuario'
                cmbTipoUsuario.DataTextField = "Nombre"; // Establece el campo de texto para los elementos del control 'cmbTipoUsuario'
                cmbTipoUsuario.DataValueField = "Id"; // Establece el campo de valor para los elementos del control 'cmbTipoUsuario'
                cmbTipoUsuario.DataBind(); // Vincula los datos a 'cmbTipoUsuario'

                if (Session["IdentificacionParticipante"] != null)
                {
                    this.CargarDatos(); // Carga datos específicos según la sesión 'IdentificacionParticipante'
                }
            }
        }



        /// <summary>
        /// Maneja el evento de clic del botón 'salir'.
        /// Invoca el método 'DireccionarPagina' para realizar acciones específicas antes de redirigir al usuario.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        protected void salir_Click(object sender, EventArgs e)
        {
            this.DireccionarPagina(); // Invoca el método 'DireccionarPagina' para realizar acciones específicas antes de redirigir al usuario
        }



        /// <summary>
        /// Elimina la sesión 'ArchivosCargados' y redirige al usuario a la página 'frmOpcionesUsuario.aspx' con un parámetro específico.
        /// </summary>
        private void DireccionarPagina()
        {
            Session.Remove("ArchivosCargados"); // Elimina la sesión 'ArchivosCargados'
            Response.Redirect("~/Aspx/Registro/frmOpcionesUsuario.aspx?participante=" + IdentificacionParticipante); // Redirige al usuario a la página 'frmOpcionesUsuario.aspx' con un parámetro específico
        }






        /// <summary>
        /// Maneja el evento de cambio de selección del combo box 'cmbTipoPerfil' en la interfaz de usuario.
        /// Realiza una verificación condicional basada en el valor seleccionado para determinar la visibilidad de un panel específico ('pnlFuturo').
        /// Carga los tipos de usuario según la selección.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        protected void cmbTipoPerfil_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipoPerfil.SelectedValue == "0")
            {
                pnlFuturo.Visible = false; // Oculta el panel 'pnlFuturo' si se selecciona un valor específico en 'cmbTipoPerfil'
            }
            else
            {
                pnlFuturo.Visible = true; // Muestra el panel 'pnlFuturo' si se selecciona un valor diferente en 'cmbTipoPerfil'
            }
            cargarTiposUsuario(); // Carga los tipos de usuario según la selección
        }

    }

}