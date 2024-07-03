using NegocioInscripcionMinSalud.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InscripcionMinSalud.frm.logica
{
    public partial class frmCambiarPassword : System.Web.UI.Page
    {

        /// <summary>
        /// Este método se ejecuta al cargar la página y redirige a la página predeterminada si no se ha iniciado sesión.
        /// </summary>
        /// <param name="sender">El objeto que genera el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Traemos el correo de la sesión
                if (Session["SS_COD_REGISTRO"] == null || Session["SS_COD_REGISTRO"].ToString() == string.Empty)
                {
                    Response.Redirect("~/default.aspx");
                }
            }
        }

        /// <summary>
        /// Este método valida los campos del formulario de cambio de contraseña.
        /// </summary>
        /// <returns>Devuelve verdadero si los campos del formulario son válidos; de lo contrario, falso.</returns>
        public bool ValidarFormulario()
        {
            //los combos de sde tipo de usuario y los combos de juridicos en cadena se validan en el formulario por javascrip
            //dado que no muestro el formulario si no ha selecionado
            bool error = false;
            LblValidacionCampos.Text = "";
            LblValidacionCampos.Text += "Verifique los Siguientes Campos: ";
                
                #region nombre entidad
                txtActual.CssClass = "";
                txtActual.Attributes.Remove("placeholder");
                if (txtActual.Text == "")
                {
                    error = true;
                    LblValidacionCampos.Text += "Contraseña actual, ";
                    txtActual.Attributes.Add("placeholder", "Debe ingresar la contraseña actual ");
                    txtActual.CssClass = "form-control errormin";
                }
                else
                {
                    txtActual.CssClass = "form-control";
                }

                txtNueva.CssClass = "";
                txtNueva.Attributes.Remove("placeholder");
                if (txtNueva.Text == "")
                {
                    error = true;
                    LblValidacionCampos.Text += "Contraseña nueva, ";
                    txtNueva.Attributes.Add("placeholder", "Debe ingresar la contraseña nueva ");
                    txtNueva.CssClass = "form-control errormin";
                }
                else
                {
                    txtNueva.CssClass = "form-control";
                }

                txtConfirmacion.CssClass = "";
                txtConfirmacion.Attributes.Remove("placeholder");
                if (txtActual.Text == "")
                {
                    error = true;
                    LblValidacionCampos.Text += "Contraseña de confirmación, ";
                    txtConfirmacion.Attributes.Add("placeholder", "Debe ingresar la contraseña de confirmación ");
                    txtConfirmacion.CssClass = "form-control errormin";
                }
                else
                {
                    txtConfirmacion.CssClass = "form-control";
                }
                if (error)
                {
                    return false;
                }

                if (txtNueva.Text != txtConfirmacion.Text)
                {
                    error = true;
                    txtConfirmacion.CssClass = "";
                    txtConfirmacion.Attributes.Remove("placeholder");
                    txtNueva.CssClass = "";
                    txtNueva.Attributes.Remove("placeholder");

                    LblValidacionCampos.Text += "Contraseña de confirmación, ";
                    txtConfirmacion.Attributes.Add("placeholder", "La contraseña nueva y la contraseña de confirmación no son iguales.");
                    txtConfirmacion.CssClass = "form-control errormin";
                    txtNueva.Attributes.Add("placeholder", "La contraseña nueva y la contraseña de confirmación no son iguales.");
                    txtNueva.CssClass = "form-control errormin";


                    return false;
                }

                #endregion

                clsNegocio obj = new clsNegocio();
                var usuario = obj.obtenerRegistroxCodigo(int.Parse(Session["SS_COD_REGISTRO"].ToString()));
                if (usuario != null)
                {
                        if (txtActual.Text.Trim() != usuario.CONTRASENA.Trim())
                        {
                            txtActual.CssClass = "";
                            error = true;
                            txtActual.Attributes.Remove("placeholder");
                            
                           LblValidacionCampos.Text += "Contraseña actual, ";
                           txtActual.Attributes.Add("placeholder", "La contraseña actual no es valida");
                           txtActual.CssClass = "form-control errormin";
                            
                        }
                }

            if (error)
            {
                return false;
            }
         

            return true;
        }

        /// <summary>
        /// Este método se ejecuta cuando se hace clic en el botón "Registrar". Actualiza la contraseña del usuario si los campos del formulario son válidos.
        /// </summary>
        /// <param name="sender">El objeto que genera el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (ValidarFormulario())
            {
                // Lógica para guardar el registro en la base de datos

                clsNegocio obj = new clsNegocio();
                LblValidacionCampos.Text = "Contraseña actualizada satisfactoriamente.";
                obj.actualizarContrasena(int.Parse(Session["SS_COD_REGISTRO"].ToString()), txtNueva.Text);
            }
        }


    }
}