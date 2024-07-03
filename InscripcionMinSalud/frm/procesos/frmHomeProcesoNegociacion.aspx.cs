using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NegocioInscripcionMinSalud.data;

namespace InscripcionMinSalud.frm.procesos
{
    public partial class frmHomeProcesoNegociacion : System.Web.UI.Page
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
                HyperLink1.NavigateUrl = HyperLink1.NavigateUrl + "?cod=" + Request.QueryString["cod"] + "&v=" + Request.QueryString["v"] + "&r=" + Request.QueryString["r"];
                HyperLink3.NavigateUrl = HyperLink3.NavigateUrl + "?cod=" + Request.QueryString["cod"] + "&v=" + Request.QueryString["v"] + "&r=" + Request.QueryString["r"];
                HyperLink4.NavigateUrl = HyperLink4.NavigateUrl + "?cod=" + Request.QueryString["cod"] + "&v=" + Request.QueryString["v"] + "&r=" + Request.QueryString["r"];
                HyperLink5.NavigateUrl = HyperLink5.NavigateUrl + "?cod=" + Request.QueryString["cod"] + "&v=" + Request.QueryString["v"] + "&r=" + Request.QueryString["r"];
            }
        }


    }
}