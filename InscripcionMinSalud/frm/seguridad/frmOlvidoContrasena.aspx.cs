using NegocioInscripcionMinSalud;
using NegocioInscripcionMinSalud.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InscripcionMinSalud.frm.seguridad
{
    public partial class frmOlvidoContrasena : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Este método valida los datos del formulario de recuperación de contraseña. Verifica si se ha ingresado un usuario y actualiza los estilos CSS en caso de que el campo esté vacío.
        /// </summary>
        /// <returns>Devuelve verdadero si los datos del formulario son válidos; de lo contrario, falso.</returns>
        private bool ValidarDatosFormulario()
        {
            txtUsuario.CssClass = "";
            txtUsuario.Attributes.Remove("placeholder");

            bool error = true;

            if (this.txtUsuario.Text == "")
            {
                txtUsuario.Attributes.Add("placeholder", "Debe ingresar el usuario");
                txtUsuario.CssClass = "form-control errormin";
                error = false;
            }
            else
            {
                txtUsuario.Attributes.Add("class", "form-control");
            }
            return error;
        }


        /// <summary>
        /// Este método maneja la lógica de recuperación de cuenta de usuario. Verifica si los datos del formulario son válidos y envía un correo electrónico con la contraseña asociada al usuario correspondiente. En caso de que el usuario no exista en la base de datos actual, busca en la base de datos anterior y envía la contraseña al correo asociado.
        /// </summary>
        /// <param name="sender">El objeto que genera el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        protected void btnRecuperar_Click(object sender, EventArgs e)
        {
            if (ValidarDatosFormulario())
            {

                clsNegocio obj = new clsNegocio();
                var usuario = obj.obtenerRegistroxUsuario(txtUsuario.Text);

                if (usuario == null)
                {
                    //buscamos si existe en la base anterior de usuarios.
                    NegocioInscripcionMinSalud.Participante participante = NegocioInscripcionMinSalud.Participante.ValidarIngresoParticipante(txtUsuario.Text);
                    if (participante == null)
                    {
                        lblMensaje.Text = "El usuario no se encontro en la base de datos";
                    }
                    else
                    {
                        clsWebUtils email = new clsWebUtils();
                        string asunto = "Solicitud contraseña Mi VOX Pópuli del Ministerio de Salud y Protección Social";
                        string cuerpo = @"Solicitud contraseña Mi VOX Pópuli del Ministerio de Salud y Protección Social
<br>Los datos de ingreso al sistema son<br>
<br>Usuario: <b>" + txtUsuario.Text + @"</b>
<br>Contraseña :<b>" + participante.ContrasenaValor + @"</b>";
                        email.enviarEmail(asunto, cuerpo, participante.Email);
                        lblMensaje.Text = "Se envio la contraseña al correo " + participante.Email;
                    }
                }
                else
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
                    {//usuario activo
                        clsWebUtils email = new clsWebUtils();
                        string asunto = "Solicitud contraseña Mi VOX Pópuli del Ministerio de Salud y Protección Social";
                        string cuerpo = @"
<br>Los datos de ingreso al sistema son<br>
<br>Usuario: <b>" + usuario.NOMBRE_USUARIO + @"</b>
<br>Contraseña :<b>" + usuario.CONTRASENA + @"</b>";
                        email.enviarEmail(asunto, cuerpo, usuario.CORREO);
                        lblMensaje.Text = "Se envio la contraseña al correo " + usuario.CORREO;
                    }
                    else
                    {
                        lblMensaje.Text = "El usuario cancelo la cuenta";
                    }
                }


            }
        }

        /// <summary>
        /// Este método maneja la redirección a la página de recuperación de usuario en caso de que un usuario haya olvidado su contraseña.
        /// </summary>
        /// <param name="sender">El objeto que genera el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        protected void lnkOlvidoContrasena_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/frm/seguridad/frmrecuperarusuario.aspx");
        }


    }
}