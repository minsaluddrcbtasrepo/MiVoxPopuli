using NegocioInscripcionMinSalud;
using NegocioInscripcionMinSalud.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InscripcionMinSalud.frm.registro
{
    public partial class verificar : System.Web.UI.Page
    {
        /**
    * Método que se activa al cargar la página y maneja la lógica relacionada con el token de solicitud de registro.
    * Verifica el token de la URL y realiza las acciones correspondientes según el estado del registro asociado.
    * @param sender El objeto que genera el evento.
    * @param e Los argumentos del evento.
    */
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["token"] != null)
                {
                    string correo = Request.QueryString["token"];
                    var c = correo.ToCharArray();
                    correo = "";
                    for (int k = 0; k < c.Length; k++)
                    {
                        c[k] = (char)(c[k] - 4);
                        correo = correo + c[k];
                    }

                    int idRegistro = 0;
                    if (correo.Contains("|"))
                    {
                        string[] datos = correo.Split('|');
                        correo = datos[0];
                        idRegistro = Convert.ToInt32(datos[1]);
                    }

                    clsNegocio obj = new clsNegocio();
                    var r = obj.obtenerRegistroxCorreo(correo, idRegistro);
                    if (r == null)
                    {
                        lnkNovalido.Visible = true;
                    }
                    else if (r.COD_ESTADO_REGISTRO == 1)
                    {
                        //lo validamos
                        lnkValido.Visible = true;
                        bool send = false;
                        obj.validarCorreoElectronico(r, null, out send);
                        if (send)
                        {//enviamos el correo de creacion de cuenta en los casos de validacion automatica
                            clsWebUtils email = new clsWebUtils();
                            string asunto = "Respuesta solicitud registro Mi VOX Pópuli del Ministerio de Salud y Protección Social";
                            string password = Guid.NewGuid().ToString();
                            password = password.Substring(2, 8);
                            obj.actualizarContrasena(r.COD_REGISTRO, password);

                            string cuerpo = @"Muchas gracias por su interés en la inscripción en Mi VOX Pópuli del Ministerio de Salud y Protección Social. Queremos informarle que su solicitud ha sido <b>ACEPTADA.</b>
                    <br>Los datos de ingreso al sistema son<br>
                    <br>Usuario: <b>" + r.NOMBRE_USUARIO + @"</b>
                    <br>Contraseña :<b>" + password + @"</b>
                    <br><br>Le pedimos esté atento de los correos que recibirá de parte del Ministerio de Salud y Protección Social.<br> ";
                            email.enviarEmail(asunto, cuerpo, correo);
                        }
                    }
                    else
                    {
                        lnkValidadoPrevio.Visible = true;
                    }
                }
            }
        }

        /**
 * Método que maneja el evento de clic en el botón de salida, redirigiendo al usuario a la página de inicio de sesión.
 * @param sender El control que invoca el evento.
 * @param e El objeto de argumentos de evento.
 */
        protected void btnSalir_Click(object sender, EventArgs e)
        {
            // Redirige al usuario a la página de inicio de sesión
            Response.Redirect("~/frm/Seguridad/frmLogin.aspx");
        }
    }
}