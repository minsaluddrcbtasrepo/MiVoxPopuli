using NegocioInscripcionMinSalud.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InscripcionMinSalud.frm.seguridad
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
        /// Este método se ejecuta cada vez que se carga la página y realiza ciertas operaciones dependiendo de si se está cargando la página por primera vez o si es una solicitud posterior.
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["page"] != null)
                {
                        lblPaginaAnterior.Text = "~/" + Request.QueryString["page"].Replace("@@", "/").Replace("**", "=").Replace("$$", "&");
                   
                }

                //if (Session["IdentificacionParticipante"] != null)
                //{
                //    Response.Redirect("~/Aspx/Registro/frmParticipante.aspx");
                //}
                //Session["ingreso"] = null;
                //txtUsuario.Attributes.Add("class", "form-control");
                //txtContrasena.Attributes.Add("class", "form-control");
            }
        }

        /// <summary>
        /// Este método se encarga de validar los datos del formulario antes de procesar la solicitud de inicio de sesión.
        /// </summary>
        /// <returns>Devuelve verdadero si los datos del formulario son válidos, de lo contrario, falso.</returns>
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
        /// Este método maneja la lógica de autenticación de usuarios y redirecciona en función de diferentes escenarios.
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
                        lblMensaje.Text = "El usuario no ha validado el correo electrónico";
                    }
                    else if (usuario.COD_ESTADO_REGISTRO == 2 || usuario.COD_ESTADO_REGISTRO == 4)
                    {
                        lblMensaje.Text = "El registro del usuario está en proceso de validación";
                    }
                    else if (usuario.COD_ESTADO_REGISTRO == 3)
                    {
                        lblMensaje.Text = "El registro del usuario está en proceso de validación";
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
                            if (lblPaginaAnterior.Text == string.Empty)
                            {
                                Response.Redirect("~/Default.aspx");
                            }
                            else
                            {
                                Response.Redirect(lblPaginaAnterior.Text);
                            }
                        }
                        else
                        {
                            lblMensaje.Text = "Usuario y/o contraseña inválidos!";
                        }
                    }
                    else
                    {
                        lblMensaje.Text = "El usuario canceló la cuenta";
                    }
                }
                else
                {
                    // Deberíamos considerar la posibilidad de migrar los datos del registro anterior.
                    NegocioInscripcionMinSalud.Participante participante = NegocioInscripcionMinSalud.Participante.ValidarIngresoParticipante(txtUsuario.Text, txtContrasena.Text);

                    if (participante == null)
                    {
                        lblMensaje.Text = "Usuario y/o contraseña inválidos!";
                        lblMensaje.Visible = true;
                        return;
                    }
                    else if (participante.IdEstadoUsuario <= 1)
                    {
                        // Si la inscripción no ha sido validada, el usuario debería registrarse de nuevo.
                        return;
                    }
                    else if (participante.IdEstadoUsuario == 3)
                    {
                        // Si el usuario está retirado, debería registrarse de nuevo.
                        return;
                    }
                    else
                    {
                        // PASAR COMO PARÁMETRO DEL REQUEST LA CÉDULA DEL PARTICIPANTE
                        Ingreso = true;
                        Session["IdentificacionParticipante"] = participante.NumeroIdentificacion;
                        Response.Redirect("~/frm/Registro/frmMigrarCuenta.aspx");
                    }
                }
            }
        }


        /// <summary>
        /// Este método maneja el clic en el enlace de recuperación de contraseña y redirige a la página correspondiente.
        /// </summary>
        /// <param name="sender">El objeto que genera el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        protected void lnkOlvidoContrasena_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/frm/Seguridad/frmOlvidoContrasena.aspx");
        }

    }
}