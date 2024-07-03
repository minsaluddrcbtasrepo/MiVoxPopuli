using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NegocioInscripcionMinSalud.data;

namespace InscripcionMinSalud.frm.procesos
{
    public partial class frmHomeProcesoAnalisis : System.Web.UI.Page
    {
        /// <summary>
        /// Maneja el evento Page_Load.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            // Verifica si la página se carga por primera vez (no es un postback)
            if (!IsPostBack)
            {
                // Verifica si el parámetro de cadena de consulta "cod" es nulo
                if (Request.QueryString["cod"] == null)
                {
                    // Redirige a la página de destino si el parámetro "cod" es nulo
                    Response.Redirect("../logica/frmDefault.aspx");
                }

                // Instancia el objeto de negocio
                NegocioInscripcionMinSalud.data.clsNegocio obj = new NegocioInscripcionMinSalud.data.clsNegocio();

                // Obtiene el proceso según el código en el parámetro "cod"
                var c = obj.obtenerProceso(int.Parse(Request.QueryString["cod"]));

                // Verifica si el proceso no es nulo
                if (c != null)
                {
                    // Obtiene la vigencia asociada al proceso
                    VIGENCIA vigencia = c.VIGENCIA.FirstOrDefault(vig => vig.COD_VIGENCIA == Convert.ToInt32(Request.QueryString["v"]));

                    // Configura el texto del control lblNombreProceso con el nombre del proceso y la descripción de la vigencia
                    lblNombreProceso.Text = c.NOMBRE_PROCESO + " - " + vigencia.DESCRIPCION;
                }

                // Mensajes personalizados (comentados para no interferir con la lógica actual)
                /*
                if (Request.QueryString["v"] != null)
                {
                    lblMensaje.Text = "No se ha realizado la sesión, la cual se encuentra programada para agosto de 2019";
                }
                */
            }
        }


        /// <summary>
        /// Maneja el evento Page_PreRender.
        /// </summary>
        protected void Page_PreRender()
        {
            // Verifica si el valor del parámetro de cadena de consulta "v" es igual a 8
            if (int.Parse(Request.QueryString["v"]) == 8)
            {
                // Muestra el control divParticipe si el valor es igual a 8
                this.divParticipe.Visible = true;

                // Verifica si la sesión contiene el valor SS_COD_REGISTRO
                if (Session["SS_COD_REGISTRO"] != null)
                {
                    // Instancia el objeto de negocio
                    clsNegocio obj = new clsNegocio();

                    // Obtiene el usuario según el código de registro en la sesión
                    var usuario = obj.obtenerRegistroxCodigo(int.Parse(Session["SS_COD_REGISTRO"].ToString()));

                    // Verifica si el usuario no es nulo
                    if (usuario != null)
                    {
                        // Verifica si el usuario es una persona jurídica
                        if (usuario.ES_PERSONA_JURIDICA == true)
                        {
                            // Configuración de visibilidad de paneles para persona jurídica
                            pnlRegistrese.Visible = false;
                            pnlNoRegistrese.Visible = false;
                            pnlVigenciaNominacion.Visible = true;
                        }
                        else
                        {
                            // Configuración de visibilidad de paneles para persona natural
                            pnlRegistrese.Visible = false;
                            pnlNoRegistrese.Visible = true;
                            pnlVigenciaNominacion.Visible = false;
                        }
                    }
                    else
                    {
                        // Configuración de visibilidad de paneles si el usuario es nulo
                        pnlRegistrese.Visible = true;
                        pnlNoRegistrese.Visible = false;
                        pnlVigenciaNominacion.Visible = false;
                    }
                }
                else
                {
                    // Configuración de visibilidad de paneles si la sesión no contiene SS_COD_REGISTRO
                    pnlRegistrese.Visible = true;
                    pnlNoRegistrese.Visible = false;
                    pnlVigenciaNominacion.Visible = false;
                }
            }
            else
            {
                // Oculta el control divParticipe si el valor del parámetro "v" no es igual a 8
                this.divParticipe.Visible = false;
            }
        }


    }
}