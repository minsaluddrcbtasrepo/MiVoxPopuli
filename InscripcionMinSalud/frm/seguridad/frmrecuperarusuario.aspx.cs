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
    public partial class frmrecuperarusuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Este método valida los datos ingresados en el formulario de recuperación de cuenta. Verifica si se ha ingresado un número de documento y una respuesta secreta válidos. En caso de campos vacíos, establece mensajes de error correspondientes y cambia el estilo de los campos para resaltar el error.
        /// </summary>
        /// <returns>Devuelve un valor booleano que indica si los datos del formulario son válidos (true) o no (false).</returns>
        private bool ValidarDatosFormulario()
        {
            txtUsuario.CssClass = "";
            txtUsuario.Attributes.Remove("placeholder");


            txtRespuestaSecreta.CssClass = "";
            txtRespuestaSecreta.Attributes.Remove("placeholder");

            bool error = true;

            if (this.txtUsuario.Text == "")
            {
                txtUsuario.Attributes.Add("placeholder", "Debe ingresar el número de documento");
                txtUsuario.CssClass = "form-control errormin";
                error = false;
            }
            else
            {
                txtUsuario.Attributes.Add("class", "form-control");
            }

            if (this.txtRespuestaSecreta.Text == "")
            {
                txtRespuestaSecreta.Attributes.Add("placeholder", "Debe ingresar la respuesta secreta");
                txtRespuestaSecreta.CssClass = "form-control errormin";
                error = false;
            }
            else
            {
                txtRespuestaSecreta.Attributes.Add("class", "form-control");
            }

            return error;
        }


        /// <summary>
        /// Este método se ejecuta cuando se hace clic en el botón de recuperación y verifica la información del formulario. Si la información es válida, recupera la cuenta de usuario según el número de documento ingresado y envía un correo electrónico con la información de inicio de sesión al usuario registrado.
        /// </summary>
        /// <param name="sender">El objeto que genera el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        protected void btnRecuperar_Click(object sender, EventArgs e)
        {
            if (ValidarDatosFormulario())
            {

                clsNegocio obj = new clsNegocio();
                var usuario = obj.obtenerRegistroxdocumento(txtUsuario.Text);

                if (usuario == null)
                {
                    lblMensaje.Text = "El número de documento no se encontró en la base de datos";
                }
                else
                {
                    if (txtRespuestaSecreta.Text.Trim() != usuario.RESPUESTA_PREGUNTA_SECRETA.Trim())
                    {
                        lblMensaje.Text = "La respuesta secreta no coincide";
                        return;
                    }

                    if (usuario.COD_ESTADO_REGISTRO == 1)
                    {
                        lblMensaje.Text = "El número de documento no ha validado el correo electrónico";
                    }
                    else if (usuario.COD_ESTADO_REGISTRO == 2 || usuario.COD_ESTADO_REGISTRO == 4)
                    {
                        lblMensaje.Text = "El registro del número de documento está en proceso de validación";
                    }
                    else if (usuario.COD_ESTADO_REGISTRO == 3)
                    {
                        lblMensaje.Text = "El registro del número de documento está en proceso de validación";
                    }
                    else if (usuario.COD_ESTADO_REGISTRO == 5)
                    {//usuario activo
                        clsWebUtils email = new clsWebUtils();
                        string asunto = "Solicitud usuario Mi VOX Pópuli del Ministerio de Salud y Protección Social";
                        string cuerpo = @"
<br>Los datos de ingreso al sistema son<br>
<br>Usuario: <b>" + usuario.NOMBRE_USUARIO + @"</b>
<br>Contraseña :<b>" + usuario.CONTRASENA + @"</b>";
                        email.enviarEmail(asunto, cuerpo, usuario.CORREO);
                        lblMensaje.Text = "Su usuario es  " + usuario.NOMBRE_USUARIO + " se envió la información de acceso al correo " + usuario.CORREO;
                    }
                    else
                    {
                        lblMensaje.Text = "El usuario canceló la cuenta";
                    }
                }


            }
        }


    }
}