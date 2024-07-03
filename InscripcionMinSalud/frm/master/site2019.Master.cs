using NegocioInscripcionMinSalud.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InscripcionMinSalud.frm.master
{
    public partial class site2019 : System.Web.UI.MasterPage
    {
        public int CodItem
        {
            set
            {
                hdnItem.Value = value.ToString();
            }
            get
            {
                if (string.IsNullOrEmpty(hdnItem.Value))
                    return 0;
                else return int.Parse(hdnItem.Value);
            }
        }

        /// <summary>
        /// Realiza una búsqueda de un usuario en la base de datos y realiza acciones en función del estado del usuario y la validez de la contraseña proporcionada.
        /// </summary>
        /// <param name="sender">El objeto que genera el evento.</param>
        /// <param name="e">Los datos del evento.</param>
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
        /// Realiza una búsqueda de un usuario en la base de datos y realiza acciones en función del estado del usuario y la validez de la contraseña proporcionada.
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
        /// Redirecciona a la página para restablecer la contraseña cuando se hace clic en el enlace 'Olvidé mi contraseña'.
        /// </summary>
        /// <param name="sender">El objeto que genera el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        protected void lnkOlvidoContrasena_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/frm/Seguridad/frmOlvidoContrasena.aspx");
        }

        /// <summary>
        /// Oculta el panel de cierre y muestra el panel de inicio de sesión, luego borra la sesión actual.
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