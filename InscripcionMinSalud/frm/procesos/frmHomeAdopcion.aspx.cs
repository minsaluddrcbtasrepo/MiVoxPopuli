using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NegocioInscripcionMinSalud.data;

namespace InscripcionMinSalud.frm.procesos
{
    public partial class frmHomeAdopcion : System.Web.UI.Page
    {
        /// <summary>
        /// Maneja el evento Page_Load.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            // Verifica si la página se está cargando por primera vez
            if (!IsPostBack)
            {
                // Crea una instancia de la clase clsNegocio
                NegocioInscripcionMinSalud.data.clsNegocio obj = new NegocioInscripcionMinSalud.data.clsNegocio();

                // Obtiene información del proceso utilizando el parámetro "cod"
                var c = obj.obtenerProceso(int.Parse(Request.QueryString["cod"]));

                // Verifica si se obtuvo información del proceso
                if (c != null)
                {
                    // Obtiene información de la vigencia asociada al proceso utilizando el parámetro "v"
                    VIGENCIA vigencia = c.VIGENCIA.FirstOrDefault(vig => vig.COD_VIGENCIA == Convert.ToInt32(Request.QueryString["v"]));

                    // Actualiza el texto del control lblNombreProceso con información del proceso y la vigencia
                    lblNombreProceso.Text = c.NOMBRE_PROCESO + " - " + vigencia.DESCRIPCION;
                }

                // Configura las URL de los hipervínculos lnkAnalisis, lnkAdopcion, lnkHome y lnkConsultas con los parámetros de la cadena de consulta
                lnkAnalisis.NavigateUrl = lnkAnalisis.NavigateUrl + "?cod=" + Request.QueryString["cod"] + "&v=" + Request.QueryString["v"] + "&r=" + Request.QueryString["r"] + "";
                lnkAdopcion.NavigateUrl = lnkAdopcion.NavigateUrl + "?cod=" + Request.QueryString["cod"] + "&v=" + Request.QueryString["v"] + "&r=" + Request.QueryString["r"] + "";
                lnkHome.NavigateUrl = lnkHome.NavigateUrl + "?cod=" + Request.QueryString["cod"] + "&v=" + Request.QueryString["v"] + "&r=" + Request.QueryString["r"] + "";
                lnkConsultas.NavigateUrl = lnkConsultas.NavigateUrl + "?cod=" + Request.QueryString["cod"] + "&v=" + Request.QueryString["v"] + "&r=" + Request.QueryString["r"] + "";

                // Mensajes personalizados
                // (Comentado para evitar que se muestre)
                // if (Request.QueryString["v"] != null && (Request.QueryString["v"] == "3" || Request.QueryString["v"] == "4"))
                // {
                //     lblMensaje.Text = "No se toma la decisión hasta que se culminen las fases 2 y 3, programada para diciembre de 2019";
                // }
            }
        }

    }
}