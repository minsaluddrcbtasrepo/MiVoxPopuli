using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InscripcionMinSalud.Aspx
{
    public partial class frmLogin : System.Web.UI.Page
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

        /// <summary>
        /// Maneja el evento de carga de la página. Redirige al usuario a la página predeterminada si no está en modo de publicación. 
        /// Si la consulta de la cadena de consulta "page" no es nula, asigna la página anterior a la etiqueta lblPaginaAnterior. 
        /// Si la identificación del participante está en la sesión, redirige al usuario a la página de participante.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Redirect("~/default.aspx");
            if (!IsPostBack)
            {
                if (Request.QueryString["page"] != null)
                {
                    lblPaginaAnterior.Text = "~/" + Request.QueryString["page"].Replace("@@", "/");
                }

                if (Session["IdentificacionParticipante"] != null)
                {
                    Response.Redirect("~/Aspx/Registro/frmParticipante.aspx");
                }
                //Session["ingreso"] = null;
                //txtUsuario.Attributes.Add("class", "form-control");
                //txtContrasena.Attributes.Add("class", "form-control");
            }
        }

        /// <summary>
        /// Valida los datos del formulario. 
        /// </summary>
        /// <returns>Devuelve un valor booleano que indica si se encontraron errores durante la validación.</returns>
        private bool ValidarDatosFormulario()
        {
            txtUsuario.CssClass = "";
            txtUsuario.Attributes.Remove("placeholder");
            txtContrasena.CssClass = "";
            txtContrasena.Attributes.Remove("placeholder");

            bool error = true;

            if (this.txtUsuario.Text == "")
            {
                txtUsuario.Attributes.Add("placeholder", "Debe ingresar el número de identificación");
                txtUsuario.CssClass = "form-control errormin";
                error = false;
            }
            else
            {
                txtUsuario.Attributes.Add("class", "form-control");
            }

            if (this.txtContrasena.Text == "")
            {
                txtContrasena.Attributes.Add("placeholder", "Debe Ingresar la contraseña");
                txtContrasena.CssClass = "form-control errormin";
                error = false;
            }
            else
            {
                txtContrasena.Attributes.Add("class", "form-control");
            }

            return error;
        }

        /// <summary>
        /// Maneja el evento clic del botón de búsqueda. 
        /// Valida los datos del formulario y procesa la autenticación del usuario. 
        /// Muestra mensajes de error si los datos ingresados no son válidos o si el usuario no ha sido validado o ha sido retirado. 
        /// Redirige al usuario a la página de opciones de usuario si la autenticación es exitosa.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if (ValidarDatosFormulario())
            {
                NegocioInscripcionMinSalud.Participante participante = NegocioInscripcionMinSalud.Participante.ValidarIngresoParticipante(txtUsuario.Text, txtContrasena.Text);

                if (participante == null)
                {
                    participante = NegocioInscripcionMinSalud.Participante.ObtenerParticipanteNumeroIdentificacion(txtUsuario.Text);

                    if (participante == null)
                    {
                        lblMensaje.Text = "Este número de documento no se encuentra registrado en el sistema";
                        lblMensaje.Visible = true;
                    }
                    else
                    {
                        lblMensaje.Text = "Usuario y/o contraseña invalido!";
                        lblMensaje.Visible = true;
                    }
                    return;

                }
                else if (participante.IdEstadoUsuario <= 1)
                {

                    lblMensaje.Text = "Su inscripción no ha sido validada!";
                    lblMensaje.Visible = true;
                    return;
                }
                else if (participante.IdEstadoUsuario == 3)
                {
                    lblMensaje.Text = "Usuario  retirado!";
                    lblMensaje.Visible = true;
                    return;
                }
                else
                {
                    //PASAR COMO PARAMETRO DEL REQUEST LA CEDULA DEL PARTICIPANTE
                    Ingreso = true;
                    Session["IdentificacionParticipante"] = participante.NumeroIdentificacion;
                    if (lblPaginaAnterior.Text == string.Empty)
                    {
                        Response.Redirect("~/Aspx/Registro/frmOpcionesUsuario.aspx");
                    }
                    else
                    {
                        Response.Redirect(lblPaginaAnterior.Text);
                    }
                }
            }
        }

        /// <summary>
        /// Maneja el evento clic del enlace "Olvidó su contraseña". 
        /// Redirige al usuario a la página de recuperación de contraseña.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        protected void lnkOlvidoContrasena_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Aspx/Seguridad/frmOlvidoContrasena.aspx");
        }



    }
}