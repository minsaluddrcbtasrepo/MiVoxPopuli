using NegocioInscripcionMinSalud.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InscripcionMinSalud.Aspx.evento
{
    public partial class frmConfirmacionEvento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Redirect("~/default.aspx");
            if (Session["ingreso"] == null)
            {
                Response.Redirect("~/aspx/seguridad/frmLogin.aspx?page=aspx@@evento@@frmconfirmacionevento.aspx");
                return;
            }
            if (!IsPostBack)
            {
                //clsNegocio dominio = new clsNegocio();
                //var eventos = dominio.obtenerParticipacionEvento(Session["IdentificacionParticipante"].ToString(),11,"1" ).FirstOrDefault();
                //if (eventos != null)
                //{
                //    txtApellido.Text = eventos.apellido_acompanante;
                //    txtNombre.Text = eventos.nombre_acompanante;
                //    txtEmail.Text = eventos.email_acompanante;

                //    txtApellido1.Text = eventos.apellido_acompanante;
                //    txtNombre1.Text = eventos.nombre_acompanante;
                //    txtEmail1.Text = eventos.email_acompanante;
                //}
                //var eventos2 = dominio.obtenerParticipacionEvento(Session["IdentificacionParticipante"].ToString(), 11, "2").FirstOrDefault();
                //if (eventos2 != null)
                //{
                //    txtApellido2.Text = eventos2.apellido_acompanante;
                //    txtNombre2.Text = eventos2.nombre_acompanante;
                //    txtEmail2.Text = eventos2.email_acompanante;
                //}
                //var eventos3 = dominio.obtenerParticipacionEvento(Session["IdentificacionParticipante"].ToString(), 11, "3").FirstOrDefault();
                //if (eventos3 != null)
                //{
                //    txtApellido3.Text = eventos3.apellido_acompanante;
                //    txtNombre3.Text = eventos3.nombre_acompanante;
                //    txtEmail3.Text = eventos3.email_acompanante;
                //}
                //var eventos4 = dominio.obtenerParticipacionEvento(Session["IdentificacionParticipante"].ToString(), 11, "4").FirstOrDefault();
                //if (eventos4 != null)
                //{
                //    txtApellido4.Text = eventos4.apellido_acompanante;
                //    txtNombre4.Text = eventos4.nombre_acompanante;
                //    txtemail4.Text = eventos4.email_acompanante;
                //}
                //var eventos5 = dominio.obtenerParticipacionEvento(Session["IdentificacionParticipante"].ToString(), 11, "5").FirstOrDefault();
                //if (eventos5 != null)
                //{
                //    txtApellido5.Text = eventos5.apellido_acompanante;
                //    txtNombre5.Text = eventos5.nombre_acompanante;
                //    txtemail5.Text = eventos5.email_acompanante;
                //}
                //var eventos6 = dominio.obtenerParticipacionEvento(Session["IdentificacionParticipante"].ToString(), 11, "6").FirstOrDefault();
                //if (eventos6 != null)
                //{
                //    txtApellido6.Text = eventos6.apellido_acompanante;
                //    txtNombre6.Text = eventos6.nombre_acompanante;
                //    txtEmail6.Text = eventos6.email_acompanante;
                //}
                //var eventos7 = dominio.obtenerParticipacionEvento(Session["IdentificacionParticipante"].ToString(), 11, "7").FirstOrDefault();
                //if (eventos7 != null)
                //{
                //    txtApellido7.Text = eventos7.apellido_acompanante;
                //    txtNombre7.Text = eventos7.nombre_acompanante;
                //    txtEmail7.Text = eventos7.email_acompanante;
                //}
                //var eventos8 = dominio.obtenerParticipacionEvento(Session["IdentificacionParticipante"].ToString(), 11, "8").FirstOrDefault();
                //if (eventos8 != null)
                //{
                //    txtApellido8.Text = eventos8.apellido_acompanante;
                //    txtNombre8.Text = eventos8.nombre_acompanante;
                //    txtEmail8.Text = eventos8.email_acompanante;
                //}
                //var eventos9 = dominio.obtenerParticipacionEvento(Session["IdentificacionParticipante"].ToString(), 11, "9").FirstOrDefault();
                //if (eventos9 != null)
                //{
                //    txtApellidos9.Text = eventos9.apellido_acompanante;
                //    txtNombres9.Text = eventos9.nombre_acompanante;
                //    txtEmail9.Text = eventos9.email_acompanante;
                //}
                //var eventos10 = dominio.obtenerParticipacionEvento(Session["IdentificacionParticipante"].ToString(), 11, "10").FirstOrDefault();
                //if (eventos10 != null)
                //{
                //    txtApellido10.Text = eventos10.apellido_acompanante;
                //    txtNombre10.Text = eventos10.nombre_acompanante;
                //    txtEmail10.Text = eventos10.email_acompanante;
                //}
              
            }
        }
        /// <summary>
        /// Maneja el evento de clic del botón de confirmación en la interfaz de usuario.
        /// Realiza validaciones y lógica condicional en función de las propiedades de participante y la selección de opciones.
        /// Muestra controles específicos en la interfaz de usuario y llama a métodos adicionales según las condiciones especificadas.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        protected void btnconfirmar_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            List<int> lista = new List<int>();
           
            lista.Add(11);
            if (lista.Count == 0)
            {
                lblError.Text = "Debe selecionar una opción";
                return;
            }
            clsNegocio dominio = new clsNegocio();
            var participante = dominio.obtenerParticipantexdocumento(Session["IdentificacionParticipante"].ToString());

            pnlDelegadosExtras.Visible = false;
            pnlDelegadoSolo.Visible = true;

            if ((participante.TipoUsuario.ES_JURIDICA.HasValue &&
                participante.TipoUsuario.ES_JURIDICA.Value) || participante.IdTipoUsuario == 9 || participante.IdTipoUsuario == 11)
            {
                pnldelegado1.Visible = false;
                pnldelegado2.Visible = false;
                pnldelegado3.Visible = false;
                pnldelegado4.Visible = false;
                pnldelegado5.Visible = false;
                pnldelegado6.Visible = false;
                pnldelegado7.Visible = false;
                pnldelegado8.Visible = false;
                pnldelegado9.Visible = false;
                pnldelegado10.Visible = false;

                //soportan 5 delegados
                if (participante.IdTipoUsuario == 4 ||
                    participante.IdTipoUsuario == 5 ||
                    participante.IdTipoUsuario == 6
                    )
                {
                    pnlDelegadosExtras.Visible = true;
                    pnlDelegadoSolo.Visible = false;
                    pnldelegado1.Visible = true;
                    pnldelegado2.Visible = true;
                    pnldelegado3.Visible = true;
                    pnldelegado4.Visible = true;
                    pnldelegado5.Visible = true;
                    mostrarPopUp();
                }
                else if (participante.IdTipoUsuario == 1 ||
                  participante.IdTipoUsuario == 2 ||
                  participante.IdTipoUsuario == 3 ||
                           participante.IdTipoUsuario == 10 ||
                  participante.IdTipoUsuario == 16
                  )
                {
                    pnlDelegadosExtras.Visible = true;
                    pnlDelegadoSolo.Visible = false;
                    pnldelegado1.Visible = true;
                    pnldelegado2.Visible = true;
                    mostrarPopUp();
                }
                else if (participante.IdTipoUsuario == 7 ||
                participante.IdTipoUsuario == 8 ||
                participante.IdTipoUsuario == 12 ||
                participante.IdTipoUsuario == 13 ||
                participante.IdTipoUsuario == 15 ||
                participante.IdTipoUsuario == 18)
                {
                    guardar();
                }else {//7   8    12    13    15    18 no piden delegados
                      //pnlDelegadosExtras.Visible = false;
                      //pnlDelegadoSolo.Visible = true;
                    pnlDelegadosExtras.Visible = true;
                    pnlDelegadoSolo.Visible = false;
                    pnldelegado1.Visible = true;
                    mostrarPopUp();
                }
            }
            else {
                guardar();
            }

        }

        /// <summary>
        /// Muestra un control emergente (popup) en la interfaz de usuario.
        /// Restablece el texto de error del control emergente y muestra el popup en la pantalla.
        /// </summary>
        public void mostrarPopUp()
        {
            lblErrorPopUp.Text = ""; // Restablece el texto de error del control emergente a una cadena vacía
            popupNuevo.Show(); // Muestra el control emergente (popup) 'popupNuevo' en la pantalla
        }

        /// <summary>
        /// Guarda la información de participantes en la base de datos después de realizar las validaciones necesarias.
        /// </summary>
        private void guardar()
        {
            List<int> lista = new List<int>(); // Inicializa una nueva lista de enteros
            lista.Add(11); // Agrega un valor específico a la lista

            clsNegocio dominio = new clsNegocio(); // Inicializa una nueva instancia de la clase 'clsNegocio'
            string documento = Session["IdentificacionParticipante"].ToString(); // Obtiene el documento de la sesión actual

            if (pnlDelegadosExtras.Visible)
            {
            //    dominio.guardarParticipacionEvento(lista, documento, txtNombre1.Text, txtApellido1.Text, txtEmail1.Text, "1");
            //    dominio.guardarParticipacionEvento(lista, documento, txtNombre2.Text, txtApellido2.Text, txtEmail2.Text, "2");
            //    dominio.guardarParticipacionEvento(lista, documento, txtNombre3.Text, txtApellido3.Text, txtEmail3.Text, "3");
            //    dominio.guardarParticipacionEvento(lista, documento, txtNombre4.Text, txtApellido4.Text, txtemail4.Text, "4");
            //    dominio.guardarParticipacionEvento(lista, documento, txtNombre5.Text, txtApellido5.Text, txtemail5.Text, "5");
            //    dominio.guardarParticipacionEvento(lista, documento, txtNombre6.Text, txtApellido6.Text, txtEmail6.Text, "6");
            //    dominio.guardarParticipacionEvento(lista, documento, txtNombre7.Text, txtApellido7.Text, txtEmail7.Text, "7");
            //    dominio.guardarParticipacionEvento(lista, documento, txtNombre8.Text, txtApellido8.Text, txtEmail8.Text, "8");
            //    dominio.guardarParticipacionEvento(lista, documento, txtNombres9.Text, txtApellidos9.Text, txtEmail9.Text, "9");
            //    dominio.guardarParticipacionEvento(lista, documento, txtNombre10.Text, txtApellido10.Text, txtEmail10.Text, "10");
            }
            else {

            //dominio.guardarParticipacionEvento(lista,documento , txtNombre.Text, txtApellido.Text,  txtEmail.Text,"1");
            }
            // Actualiza la interfaz de usuario y muestra un mensaje de confirmación de guardado
            lblError.Text = "Se guardó la confirmación";
            popupNuevo.Hide(); // Oculta el control emergente (popup) 'popupNuevo'
            pnlinicial.Visible = false; // Hace que el panel 'pnlinicial' sea invisible
            pnlfinal.Visible = true; // Hace que el panel 'pnlfinal' sea visible
            pnlForm.Update(); // Actualiza el panel 'pnlForm' en la página web utilizando Ajax
        }

        /// <summary>
        /// Maneja el evento de clic del botón de aceptar en la interfaz de usuario.
        /// Realiza validaciones de campos obligatorios según la visibilidad de los controles y luego llama al método 'guardar' si las validaciones son exitosas.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            if (pnlDelegadoSolo.Visible)
            {
                if (txtNombre.Text == string.Empty)
                {
                    lblErrorPopUp.Text = "El nombre es obligatorio";
                    return;
                }
                if (txtApellido.Text == string.Empty)
                {
                    lblErrorPopUp.Text = "El apellido es obligatorio";
                    return;
                }
                if (txtEmail.Text == string.Empty)
                {
                    lblErrorPopUp.Text = "El email es obligatorio";
                    return;
                }
            }
            else
            {
                if (txtNombre1.Text == string.Empty)
                {
                    lblErrorPopUp.Text = "El nombre es obligatorio";
                    return;
                }
                if (txtApellido1.Text == string.Empty)
                {
                    lblErrorPopUp.Text = "El apellido es obligatorio";
                    return;
                }
                if (txtEmail1.Text == string.Empty)
                {
                    lblErrorPopUp.Text = "El email es obligatorio";
                    return;
                }
            }
            guardar(); // Llama al método 'guardar' si las validaciones son exitosas
        }

        protected void btnConfirmarsinAcompanante_Click(object sender, EventArgs e)
        {
            txtApellido.Text = "";
            txtEmail.Text = "";
            txtNombre.Text = "";
            pnlDelegadosExtras.Visible = false;
            guardar();
        }

        /// <summary>
        /// Maneja el evento de clic del botón de cancelar en el detalle de algún elemento.
        /// Oculta un control emergente (popup) y actualiza un panel específico en la página web utilizando Ajax.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        protected void btnCancelarDetalle_Click(object sender, EventArgs e)
        {
            popupNuevo.Hide(); // Oculta el control emergente (popup) 'popupNuevo'
            pnlForm.Update(); // Actualiza el panel 'pnlForm' en la página web utilizando Ajax
        }


    }
}