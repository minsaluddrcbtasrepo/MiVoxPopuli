using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InscripcionMinSalud.Aspx.Registro
{
    public partial class verificar : System.Web.UI.Page
    {
        /// <summary>
        /// Maneja el evento de carga de la página.
        /// Redirige al usuario a la página predeterminada ('default.aspx').
        /// Realiza validaciones específicas si la solicitud no es una devolución de datos del formulario.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Redirect("~/default.aspx"); // Redirige al usuario a la página predeterminada ('default.aspx')

            if (!IsPostBack)
            {
                if (Request.QueryString["token"] != null)
                {
                    string correo = Request.QueryString["token"]; // Obtiene el token de la consulta de la URL
                    var c = correo.ToCharArray(); // Convierte el correo electrónico en un arreglo de caracteres
                    correo = ""; // Inicializa la cadena de correo electrónico

                    // Itera sobre cada carácter en el arreglo y realiza un desplazamiento de 4 posiciones hacia atrás en la tabla ASCII
                    for (int k = 0; k < c.Length; k++)
                    {
                        c[k] = (char)(c[k] - 4);
                        correo = correo + c[k]; // Reconstruye el correo electrónico modificado
                    }

                    if (correo.Contains("|"))
                    {
                        correo = correo.Split('|').First();
                    }

                    if (NegocioInscripcionMinSalud.Participante.ValidarRegistroCorreo(correo) == true)
                    {
                        // Verifica la cuenta y muestra controles específicos en la interfaz de usuario
                        lnkValido.Visible = true; // Muestra el enlace 'lnkValido'
                        lnkNovalido.Visible = false; // Oculta el enlace 'lnkNovalido'
                    }
                }
            }
        }


        /// <summary>
        /// Maneja el evento de clic del botón 'Salir' en la interfaz de usuario.
        /// Redirige al usuario a la página de inicio de sesión.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Aspx/Seguridad/frmLogin.aspx"); // Redirige al usuario a la página de inicio de sesión
        }
    }
}