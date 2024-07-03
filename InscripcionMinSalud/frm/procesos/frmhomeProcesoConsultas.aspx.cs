using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NegocioInscripcionMinSalud.data;

namespace InscripcionMinSalud.frm.procesos
{
    public partial class frmhomeProcesoConsultas : System.Web.UI.Page
    {
        /// <summary>
        /// Maneja el evento de carga de la página.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            // Verifica si la página se está cargando por primera vez
            if (!IsPostBack)
            {
                // Verifica si el parámetro de cadena de consulta "cod" es nulo
                if (Request.QueryString["cod"] == null)
                {
                    // Redirige a la página de inicio si el parámetro "cod" es nulo
                    Response.Redirect("../logica/frmDefault.aspx");
                }

                // Instancia el objeto de negocio
                NegocioInscripcionMinSalud.data.clsNegocio obj = new NegocioInscripcionMinSalud.data.clsNegocio();

                // Obtiene información sobre el proceso
                var c = obj.obtenerProceso(int.Parse(Request.QueryString["cod"]));

                // Verifica si el proceso no es nulo
                if (c != null)
                {
                    // Obtiene la vigencia del proceso
                    VIGENCIA vigencia = c.VIGENCIA.FirstOrDefault(vig => vig.COD_VIGENCIA == Convert.ToInt32(Request.QueryString["v"]));

                    // Establece el texto del control de etiqueta lblNombreProceso
                    lblNombreProceso.Text = c.NOMBRE_PROCESO + " - " + vigencia.DESCRIPCION;
                }

                // Actualiza las propiedades NavigateUrl de los controles HyperLink basándose en los parámetros de la cadena de consulta
                lnkAdopcion.NavigateUrl = lnkAdopcion.NavigateUrl + "?cod=" + Request.QueryString["cod"] + "&v=" + Request.QueryString["v"] + "&r=" + Request.QueryString["r"];
                lnkHome.NavigateUrl = lnkHome.NavigateUrl + "?cod=" + Request.QueryString["cod"] + "&v=" + Request.QueryString["v"] + "&r=" + Request.QueryString["r"];
                lnkAnalisis.NavigateUrl = lnkAnalisis.NavigateUrl + "?cod=" + Request.QueryString["cod"] + "&v=" + Request.QueryString["v"] + "&r=" + Request.QueryString["r"];

                //Mensajes personalizados
                //if (Request.QueryString["v"] != null && (Request.QueryString["v"] == "3" || Request.QueryString["v"] == "4" ))
                //{
                //    lblMensaje.Text = "Esta consulta se realizó en 2021, por favor remítase a los resultados de consulta a pacientes vigencia 2021." ;
                //}
                //if (Request.QueryString["v"] != null && Request.QueryString["v"] == "8")
                //{
                //    lblMensajeParticipe.Text = "Esta consulta se realizó en 2021, por favor remítase a los resultados de consulta a pacientes vigencia 2021.";
                //}
            }
        }


    }
}