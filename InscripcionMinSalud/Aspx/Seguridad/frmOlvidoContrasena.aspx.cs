using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


  

public class donante
{   
    public string contrasena { get; set; }
}



namespace InscripcionMinSalud.Aspx
{
    public partial class frmOlvidoContrasena : System.Web.UI.Page
    {
        /// <summary>
        /// Carga la página y redirige al usuario a la página predeterminada.
        /// Además, carga los combos del formulario.
        /// </summary>
        /// <param name="sender">El objeto que genera el evento.</param>
        /// <param name="e">Los argumentos del evento.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Redirect("~/default.aspx");
            CargarCombosFormulario();
        }

        /// <summary>
        /// Redirige al usuario a la página de inicio de sesión cuando se hace clic en el botón Regresar.
        /// </summary>
        /// <param name="sender">El objeto que genera el evento.</param>
        /// <param name="e">Los argumentos del evento.</param>
        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Aspx/Seguridad/frmLogin.aspx");
        }

        /// <summary>
        /// Carga los combos del formulario con las preguntas secretas obtenidas de la base de datos.
        /// </summary>
        private void CargarCombosFormulario()
        {
            if (!IsPostBack)
            {
                cmbPregunta.DataSource = NegocioInscripcionMinSalud.PreguntaSecreta.ObtenerPregunta();
                cmbPregunta.DataTextField = "TextoPregunta";
                cmbPregunta.DataValueField = "Id";
                cmbPregunta.DataBind();
            }
        }

        /// <summary>
        /// Valida los datos del formulario de registro. Verifica si los campos obligatorios tienen valores adecuados y si se ha seleccionado una pregunta secreta válida.
        /// </summary>
        /// <returns>Devuelve true si los datos son válidos, de lo contrario, devuelve false.</returns>
        private bool ValidarDatosFormulario()
        {
            txtUsuario.CssClass = "";
            txtUsuario.Attributes.Remove("placeholder");
            txtRespuestaSecreta.CssClass = "";
            txtRespuestaSecreta.Attributes.Remove("placeholder");
            cmbPregunta.CssClass = "";
            cmbPregunta.Attributes.Remove("placeholder");

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

            if (this.txtRespuestaSecreta.Text == "")
            {
                txtRespuestaSecreta.Attributes.Add("placeholder", "Debe ingresar la respuesta a la pregunta");
                txtRespuestaSecreta.CssClass = "form-control errormin";
                error = false;
            }
            else
            {
                txtRespuestaSecreta.Attributes.Add("class", "form-control");
            }

            if (this.cmbPregunta.SelectedIndex == 0)
            {
                cmbPregunta.Attributes.Add("placeholder", "Debe seleccionar una pregunta");
                cmbPregunta.CssClass = "form-control errormin";
                error = false;
            }
            else
            {
                cmbPregunta.Attributes.Add("class", "form-control");
            }

            return error;
        }

        /// <summary>
        /// Maneja el evento de clic en el botón de búsqueda. Verifica si los datos del formulario son válidos. Si los datos son válidos, se realiza un cambio de contraseña para el participante correspondiente y se envía la nueva contraseña al correo electrónico registrado.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if (ValidarDatosFormulario())
            {
                string correoDonante = NegocioInscripcionMinSalud.Participante.CambioContrasenaParticipante(this.txtUsuario.Text, Convert.ToInt32(this.cmbPregunta.SelectedValue), this.txtRespuestaSecreta.Text);

                if (correoDonante == null)
                {
                    lblMensaje.Text = "Los datos ingresados son erróneos, por favor verifique";
                }
                else if (correoDonante == "Error")
                {
                    lblMensaje.Text = "No se pudo enviar la contraseña al correo electrónico registrado. El usuario no posee un correo electrónico válido. Por favor, póngase en contacto con el administrador.";
                }
                else
                {
                    lblMensaje.Text = "Su nueva contraseña se ha enviado al correo: " + correoDonante;
                }
            }
        }

    }

}