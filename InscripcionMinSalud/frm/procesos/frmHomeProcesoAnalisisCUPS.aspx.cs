using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NegocioInscripcionMinSalud.data;

namespace InscripcionMinSalud.frm.procesos
{
    public partial class frmHomeProcesoAnalisisCUPS : System.Web.UI.Page
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
                // Verifica si el parámetro "cod" en la cadena de consulta es nulo
                if (Request.QueryString["cod"] == null)
                {
                    // Redirige a la página de destino en caso de que el parámetro "cod" sea nulo
                    Response.Redirect("../logica/frmDefault.aspx");
                }

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

                // Configura las URL de los hipervínculos lnkIntroduccion, lnkAnalisis, lnkDesicion con los parámetros de la cadena de consulta
                lnkIntroduccion.NavigateUrl = lnkIntroduccion.NavigateUrl + "?cod=" + Request.QueryString["cod"] + "&v=" + Request.QueryString["v"] + "&r=" + Request.QueryString["r"] + "";
                lnkAnalisis.NavigateUrl = lnkAnalisis.NavigateUrl + "?cod=" + Request.QueryString["cod"] + "&v=" + Request.QueryString["v"] + "&r=" + Request.QueryString["r"] + "";
                lnkDesicion.NavigateUrl = lnkDesicion.NavigateUrl + "?cod=" + Request.QueryString["cod"] + "&v=" + Request.QueryString["v"] + "&r=" + Request.QueryString["r"] + "";

                // Mensajes personalizados
                if (Request.QueryString["v"] != null && Request.QueryString["v"] == "3")
                {
                    lblMensaje.Text = "No se ha realizado la sesión, la cual se encuentra programada para agosto de 2019";
                }
            }
        }


        /// <summary>
        /// Maneja el evento Page_PreRender.
        /// </summary>
        protected void Page_PreRender()
        {
            // Verifica si el valor de la cadena de consulta "v o vigencia" es igual a 8
            if (int.Parse(Request.QueryString["v"]) == 8)
            {
                // Comentarios: El siguiente bloque de código está comentado y no tiene un efecto activo en la ejecución actual.
                /*
                this.divParticipe.Visible = true;
                if (Session["SS_COD_REGISTRO"] != null)
                {
                    clsNegocio obj = new clsNegocio();
                    var usuario = obj.obtenerRegistroxCodigo(int.Parse(Session["SS_COD_REGISTRO"].ToString()));
                    if (usuario != null)
                    {
                        if (usuario.ES_PERSONA_JURIDICA == true)
                        {
                            pnlRegistrese.Visible = false;
                            pnlNoRegistrese.Visible = false;
                            pnlVigenciaNominacion.Visible = true;
                        }
                        else
                        {
                            pnlRegistrese.Visible = false;
                            pnlNoRegistrese.Visible = true;
                            pnlVigenciaNominacion.Visible = false;
                        }
                    }
                    else
                    {
                        pnlRegistrese.Visible = true;
                        pnlNoRegistrese.Visible = false;
                        pnlVigenciaNominacion.Visible = false;
                    }
                }
                else
                {
                    pnlRegistrese.Visible = true;
                    pnlNoRegistrese.Visible = false;
                    pnlVigenciaNominacion.Visible = false;
                }
                */
            }
            else
            {
                // Comentarios: El siguiente bloque de código está comentado y no tiene un efecto activo en la ejecución actual.
                //this.divParticipe.Visible = false;
            }
        }


    }
}