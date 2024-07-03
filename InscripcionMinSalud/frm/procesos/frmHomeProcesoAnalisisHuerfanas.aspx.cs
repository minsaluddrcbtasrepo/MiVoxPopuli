using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NegocioInscripcionMinSalud.data;


namespace InscripcionMinSalud.frm.procesos
{
    public partial class frmHomeProcesoAnalisisHuerfanas : System.Web.UI.Page
    {
        /// <summary>
        /// Maneja el evento Page_Load del formulario.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            // Verifica si la página se está cargando por primera vez
            if (!IsPostBack)
            {
                // Verifica si el parámetro "cod" no está presente en la cadena de consulta
                if (Request.QueryString["cod"] == null)
                {
                    // Redirecciona a la página predeterminada si el parámetro "cod" no está presente
                    Response.Redirect("../logica/frmDefault.aspx");
                }

                // Crea una instancia de la clase de negocio
                NegocioInscripcionMinSalud.data.clsNegocio obj = new NegocioInscripcionMinSalud.data.clsNegocio();

                // Obtiene información del proceso según el parámetro "cod"
                var c = obj.obtenerProceso(int.Parse(Request.QueryString["cod"]));

                // Verifica si se encontró información del proceso
                if (c != null)
                {
                    // Obtiene información de la vigencia según el parámetro "v"
                    VIGENCIA vigencia = c.VIGENCIA.FirstOrDefault(vig => vig.COD_VIGENCIA == Convert.ToInt32(Request.QueryString["v"]));

                    // Actualiza el texto del control lblNombreProceso con información del proceso y la vigencia
                    lblNombreProceso.Text = c.NOMBRE_PROCESO + " - " + vigencia.DESCRIPCION;
                }

                // Actualiza las URL de los hipervínculos con información de la cadena de consulta
                lnkAdopcion.NavigateUrl = lnkAdopcion.NavigateUrl + "?cod=" + Request.QueryString["cod"] + "&v=" + Request.QueryString["v"] + "&r=" + Request.QueryString["r"] + "";
                lnkHome.NavigateUrl = lnkHome.NavigateUrl + "?cod=" + Request.QueryString["cod"] + "&v=" + Request.QueryString["v"] + "&r=" + Request.QueryString["r"] + "";

                //Mensajes personalizados
                if (Request.QueryString["v"] != null && Request.QueryString["v"] == "3")
                {
                    lblMensaje.Text = "No se ha realizado la sesión, la cual se encuentra programada para agosto de 2019";
                }
            }
        }

    }
}