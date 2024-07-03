using NegocioInscripcionMinSalud.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InscripcionMinSalud.frm.master
{
    public partial class masterc : System.Web.UI.MasterPage
    {
        /// <summary>
        /// Este método se ejecuta cuando se carga la página y realiza una serie de acciones, como verificar si es una solicitud de envío de datos, verificar la existencia de ciertos parámetros en la URL y establecer la visibilidad de los paneles de cierre e inicio de sesión según el estado de la sesión.
        /// </summary>
        /// <param name="sender">El objeto que genera el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["page"] != null)
                {
                    lblPaginaAnterior.Text = "~/" + Request.QueryString["page"].Replace("@@", "/").Replace("**", "=").Replace("$$", "&");
                }

                if (Session["SS_COD_REGISTRO"] != null)
                {
                    pnlCerrar.Visible = true;
                    pnlIngreso.Visible = false;
                }
                else
                {
                    pnlCerrar.Visible = false;
                    pnlIngreso.Visible = true;
                }
            }
        }

        /// <summary>
        /// Valida los datos ingresados en el formulario, como el nombre de usuario y la contraseña, y establece el estilo y los mensajes de error correspondientes si los campos están vacíos.
        /// </summary>
        /// <returns>Un valor booleano que indica si los datos del formulario son válidos.</returns>
        private bool ValidarDatosFormulario()
        {
            txtUsuario.CssClass = "";
            txtUsuario.Attributes.Remove("placeholder");
            txtContrasena.CssClass = "";
            txtContrasena.Attributes.Remove("placeholder");

            bool error = true;

            if (this.txtUsuario.Text == "")
            {
                txtUsuario.Attributes.Add("placeholder", "Debe ingresar el Usuario");
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
        /// Este método se ejecuta cuando se hace clic en el botón de búsqueda y valida los datos del formulario de inicio de sesión. Luego, realiza acciones en función de la validación de los datos, como verificar el estado del registro del usuario y redirigir a páginas correspondientes.
        /// </summary>
        /// <param name="sender">El objeto que genera el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if (ValidarDatosFormulario())
            {

                clsNegocio obj = new clsNegocio();
                var usuario = obj.obtenerRegistroxUsuario(txtUsuario.Text);
                if (usuario != null)
                {
                    if (usuario.COD_ESTADO_REGISTRO == 1)
                    {
                        lblMensaje.Text = "El usuario no ha validado el corrreo electrónico";
                    }
                    else if (usuario.COD_ESTADO_REGISTRO == 2 || usuario.COD_ESTADO_REGISTRO == 4)
                    {
                        lblMensaje.Text = "El registro del usuario esta en proceso de validación";
                    }
                    else if (usuario.COD_ESTADO_REGISTRO == 3)
                    {
                        lblMensaje.Text = "El registro del usuario esta en proceso de validación";
                    }
                    else if (usuario.COD_ESTADO_REGISTRO == 5)
                    {
                        if (txtContrasena.Text.Trim() == usuario.CONTRASENA.Trim())
                        {
                            Session["SS_COD_REGISTRO"] = usuario.COD_REGISTRO;
                            Session["SS_NOMBRE_USUARIO"] = usuario.NOMBRE_USUARIO;
                            if (usuario.ES_PERSONA_NATURAL)
                                Session["SS_NOMBRE"] = usuario.NOMBRE.Trim() + " " + usuario.APELLIDOS;
                            else
                                Session["SS_NOMBRE"] = usuario.NOMBRE.Trim();
                            Session["SS_CORREO"] = usuario.CORREO;
                            Response.Redirect(Request.RawUrl);
                            //if (lblPaginaAnterior.Text == string.Empty)
                            //{
                            //    Response.Redirect("~/Default.aspx");
                            //}
                            //else
                            //{
                            //    Response.Redirect(lblPaginaAnterior.Text);
                            //}
                        }
                        else
                        {

                            lblMensaje.Text = "Usuario y/o contraseña invalido!";
                        }
                    }
                    else
                    {
                        lblMensaje.Text = "El usuario cancelo la cuenta";
                    }
                }
                else
                {
                    //deberiamos mirar la posibilidad de migrar los datos del registro anterior.
                    NegocioInscripcionMinSalud.Participante participante = NegocioInscripcionMinSalud.Participante.ValidarIngresoParticipante(txtUsuario.Text, txtContrasena.Text);

                    if (participante == null)
                    {
                        lblMensaje.Text = "Usuario y/o contraseña invalido!";
                        lblMensaje.Visible = true;
                        //participante = NegocioInscripcionMinSalud.Participante.ObtenerParticipanteNumeroIdentificacion(txtUsuario.Text);

                        //if (participante == null)
                        //{
                        //    lblMensaje.Text = "Este número de documento no se encuentra registrado en el sistema";
                        //    lblMensaje.Visible = true;
                        //}
                        //else
                        //{
                        //    lblMensaje.Text = "Usuario y/o contraseña invalido!";
                        //    lblMensaje.Visible = true;
                        //}
                        return;

                    }
                    else if (participante.IdEstadoUsuario <= 1)
                    {
                        //si la inscripcion no ha sido validada deberia registrarse de nuevo
                        //lblMensaje.Text = "Su inscripción no ha sido validada!";
                        //lblMensaje.Visible = true;
                        return;
                    }
                    else if (participante.IdEstadoUsuario == 3)
                    {
                        return;
                    }
                    else
                    {
                        //PASAR COMO PARAMETRO DEL REQUEST LA CEDULA DEL PARTICIPANTE
                        Session["IdentificacionParticipante"] = participante.NumeroIdentificacion;
                        Response.Redirect("~/frm/Registro/frmMigrarCuenta.aspx");
                    }
                }
            }
        }

        /// <summary>
        /// Este método se ejecuta cuando se hace clic en el enlace "Olvidé mi contraseña" y redirige al usuario a la página de recuperación de contraseña.
        /// </summary>
        /// <param name="sender">El objeto que genera el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        protected void lnkOlvidoContrasena_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/frm/Seguridad/frmOlvidoContrasena.aspx");
        }

        /// <summary>
        /// Este método se ejecuta cuando se hace clic en el enlace "Cerrar sesión" y oculta el panel de cierre de sesión mientras muestra el panel de inicio de sesión. Además, borra la sesión actual.
        /// </summary>
        /// <param name="sender">El objeto que genera el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        protected void lnkCerrar_Click(object sender, EventArgs e)
        {
            pnlCerrar.Visible = false;
            pnlIngreso.Visible = true;

            Session.Clear();
        }

    }
}