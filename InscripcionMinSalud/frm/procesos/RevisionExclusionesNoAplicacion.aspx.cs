using NegocioInscripcionMinSalud.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace InscripcionMinSalud.frm.procesos
{
    public partial class RevisionExclusionesNoAplicacion : System.Web.UI.Page
    {
        public string clsParticipe = "tab-link";
        public string clsResultados = "tab-link";

        public string clsTabParticipe = "tab-content";
        public string clsTabResultados = "tab-content";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["cod"] == null)
                {
                    Response.Redirect("../logica/frmDefault.aspx");
                }
                else if (int.Parse(Request.QueryString["cod"]) == 18)
                {
                    Response.Redirect("../procesos/frmInscripcionHuerfanas.aspx");
                }


                if (Request.QueryString["r"] != null)
                {
                    clsParticipe = "tab-link";
                    clsResultados = "tab-link active current";

                    clsTabParticipe = "tab-content";
                    clsTabResultados = "tab-content current";
                }
                else
                {
                    clsParticipe = "tab-link active current";
                    clsResultados = "tab-link";
                    clsTabParticipe = "tab-content current";
                    clsTabResultados = "tab-content";
                }

                NegocioInscripcionMinSalud.data.clsNegocio obj = new NegocioInscripcionMinSalud.data.clsNegocio();
                var proceso = obj.obtenerProceso(int.Parse(Request.QueryString["cod"]));
                lblNombreProceso.Text = proceso.NOMBRE_PROCESO;
                //iframeNominar.Src = "frmInscripcionProceso.aspx?codProceso=" + proceso.COD_PROCESO + "&v=" + Request.QueryString["v"];

                lnkAdopcion.NavigateUrl = lnkAdopcion.NavigateUrl + "?cod=" + Request.QueryString["cod"] + "&v=" + Request.QueryString["v"] + "&r=" + Request.QueryString["r"] + "";
                lnkAnalisis.NavigateUrl = lnkAnalisis.NavigateUrl + "?cod=" + Request.QueryString["cod"] + "&v=" + Request.QueryString["v"] + "&r=" + Request.QueryString["r"] + "";
                lnkConsultas.NavigateUrl = lnkConsultas.NavigateUrl + "?cod=" + Request.QueryString["cod"] + "&v=" + Request.QueryString["v"] + "&r=" + Request.QueryString["r"] + "";
                lnkRevision.NavigateUrl = lnkRevision.NavigateUrl + "?cod=" + Request.QueryString["cod"] + "&v=" + Request.QueryString["v"] + "&r=" + Request.QueryString["r"] + "";

                VIGENCIA vigencia = proceso.VIGENCIA.FirstOrDefault(vig => vig.COD_VIGENCIA == Convert.ToInt32(Request.QueryString["v"]));

                if (vigencia != null)
                {
                    lblNombreProceso.Text = lblNombreProceso.Text + " - " + vigencia.DESCRIPCION;
                  
                }
                else
                {
                   
                }
            }
        }

        /// <summary>
        /// Este método se ejecuta antes de que se renderice la página.
        /// </summary>
        protected void Page_PreRender()
        {
            if (Session["SS_COD_REGISTRO"] != null)
            {
                // pnlRegistrese.Visible = false;
                // pnlNoRegistrese.Visible = true;
            }
            else
            {
                NegocioInscripcionMinSalud.data.clsNegocio negocio = new NegocioInscripcionMinSalud.data.clsNegocio();
                var proceso = negocio.obtenerProceso(int.Parse(Request.QueryString["cod"]));

                VIGENCIA vigencia = proceso.VIGENCIA.FirstOrDefault(vig => vig.COD_VIGENCIA == Convert.ToInt32(Request.QueryString["v"]));

                if (int.Parse(Request.QueryString["cod"]) == 18)
                {
                    Response.Redirect("../procesos/frmInscripcionHuerfanas.aspx");
                }
                else
                {
                    if (vigencia != null)
                    {
                        //if (vigencia.ABIERTO)
                        //{
                        //    pnlRegistrese.Visible = true;
                        //    pnlNoRegistrese.Visible = false;
                        //}
                        //else
                        //{
                        //    pnlRegistrese.Visible = false;
                        //    pnlNoRegistrese.Visible = true;
                        //}
                    }
                    else
                    {
                        //pnlRegistrese.Visible = true;
                        //pnlNoRegistrese.Visible = false;
                    }
                }
            }
        }


        /// <summary>
        /// Este método devuelve una cadena que representa el tipo de registro.
        /// </summary>
        /// <param name="esMedicamento">Un objeto que indica si el registro es un medicamento.</param>
        /// <param name="esProcedimiento">Un objeto que indica si el registro es un procedimiento.</param>
        /// <param name="esDispositivo">Un objeto que indica si el registro es un dispositivo.</param>
        /// <param name="esOtro">Un objeto que indica si el registro es de otro tipo.</param>
        /// <returns>Una cadena que representa el tipo de registro.</returns>
        public string verTipo(object esMedicamento, object esProcedimiento, object esDispositivo, object esOtro)
        {
            if (esMedicamento != null && (bool)esMedicamento)
            {
                return "Medicamentos";
            }
            if (esProcedimiento != null && (bool)esProcedimiento)
            {
                return "Procedimientos";
            }
            if (esDispositivo != null && (bool)esDispositivo)
            {
                return "Dispositivos";
            }
            if (esOtro != null && (bool)esOtro)
            {
                return "Otro";
            }
            return "";
        }

        /// <summary>
        /// Este método devuelve una cadena que indica la presencia o ausencia de un conflicto.
        /// </summary>
        /// <param name="conflicto">Un objeto que indica si hay conflicto.</param>
        /// <returns>Una cadena que representa la presencia o ausencia de conflicto.</returns>
        public string verconflicto(object conflicto)
        {
            if (conflicto == null)
            {
                return "No definido";
            }
            if (conflicto != null && (bool)conflicto)
            {
                return "SI";
            }
            return "NO";
        }


        public string verEvidencia(object evidencia)
        {
            if (evidencia == null)
            {
                return "No definido";
            }
            if (evidencia != null && (bool)evidencia)
            {
                return "SI";
            }
            return "NO";
        }

        /// <summary>
        /// Este método genera una cadena de criterios de exclusión basada en los parámetros proporcionados.
        /// </summary>
        /// <param name="a">Un objeto que indica el criterio A.</param>
        /// <param name="b">Un objeto que indica el criterio B.</param>
        /// <param name="c">Un objeto que indica el criterio C.</param>
        /// <param name="d">Un objeto que indica el criterio D.</param>
        /// <param name="e">Un objeto que indica el criterio E.</param>
        /// <param name="f">Un objeto que indica el criterio F.</param>
        /// <returns>Una cadena que representa los criterios de exclusión seleccionados.</returns>
        public string criteriosEclusion(
            object a, object b, object c, object d, object e, object f
        )
        {
            string res = "";
            if (a != null && (bool)a)
            {
                res += "A,";
            }
            if (b != null && (bool)b)
            {
                res += "B,";
            }
            if (c != null && (bool)c)
            {
                res += "C,";
            }
            if (d != null && (bool)d)
            {
                res += "D,";
            }
            if (e != null && (bool)e)
            {
                res += "E,";
            }
            if (f != null && (bool)f)
            {
                res += "F,";
            }
            if (res != string.Empty)
            {
                res = res.Substring(0, res.Length - 1);
            }
            return res;
        }

        /// <summary>
        /// Este método devuelve una descripción basada en los parámetros proporcionados, indicando el tipo de la entidad.
        /// </summary>
        /// <param name="esMedicamento">Un objeto que indica si la entidad es un medicamento.</param>
        /// <param name="esProcedimiento">Un objeto que indica si la entidad es un procedimiento.</param>
        /// <param name="esDispositivo">Un objeto que indica si la entidad es un dispositivo.</param>
        /// <param name="esOtro">Un objeto que indica si la entidad es de otro tipo.</param>
        /// <param name="medicamento">El valor a mostrar si la entidad es un medicamento.</param>
        /// <param name="procedimiento">El valor a mostrar si la entidad es un procedimiento.</param>
        /// <param name="dispositivo">El valor a mostrar si la entidad es un dispositivo.</param>
        /// <param name="otro">El valor a mostrar si la entidad es de otro tipo.</param>
        /// <returns>Una cadena que representa la descripción del tipo de entidad.</returns>
        public string verDescripcionTipo(
            object esMedicamento, object esProcedimiento, object esDispositivo, object esOtro,
            object medicamento, object procedimiento, object dispositivo, object otro
        )
        {
            if (esMedicamento != null && (bool)esMedicamento)
            {
                return medicamento.ToString();
            }
            if (esProcedimiento != null && (bool)esProcedimiento)
            {
                return procedimiento.ToString();
            }
            if (esDispositivo != null && (bool)esDispositivo)
            {
                return dispositivo.ToString();
            }
            if (esOtro != null && (bool)esOtro)
            {
                return otro.ToString();
            }
            return "";
        }


        /// <summary>
        /// Este método se ejecuta cuando se enlaza un elemento de datos a un elemento en el control DataList datos.
        /// Configura los datos para el elemento actual; sin embargo, actualmente está comentado y no se utiliza para enlazar datos al Repeater grdObjeciones.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento (debe ser el control DataList datos).</param>
        /// <param name="e">Los argumentos del evento que contienen la información sobre el elemento enlazado.</param>
        protected void datos_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            // Se obtienen las referencias a los controles dentro del elemento actual del DataList.
            Label lbl = (Label)e.Item.FindControl("lblCodNominacion");
            Repeater grd = (Repeater)e.Item.FindControl("grdObjeciones");

            // Se obtiene la instancia del objeto de negocio para manejar la lógica de datos.
            NegocioInscripcionMinSalud.data.clsNegocio obj = new NegocioInscripcionMinSalud.data.clsNegocio();

            // Actualmente, el siguiente bloque de código está comentado y no se utiliza para enlazar datos al Repeater grdObjeciones.
            // Descomenta y ajusta según sea necesario si decides utilizar este bloque.
            //grd.DataSource = obj.obtenerObjecionxNominacion(int.Parse(lbl.Text));
            //grd.DataBind();
        }

        /// <summary>
        /// Este método se ejecuta cuando se enlaza un elemento de datos a un elemento en el control Repeater rptResultados.
        /// Configura los datos para el elemento actual y, si hay objeciones asociadas, muestra el panel de objeciones; de lo contrario, lo oculta.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento (debe ser el control Repeater rptResultados).</param>
        /// <param name="e">Los argumentos del evento que contienen la información sobre el elemento enlazado.</param>
        protected void rptResultados_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                // Se obtienen las referencias a los controles dentro del elemento actual del Repeater.
                Label lbl = (Label)e.Item.FindControl("lblCodNominacion2");
                GridView grd = (GridView)e.Item.FindControl("grdObjeciones2");

                // Se obtiene la instancia del objeto de negocio para manejar la lógica de datos.
                NegocioInscripcionMinSalud.data.clsNegocio obj = new NegocioInscripcionMinSalud.data.clsNegocio();

                // Se enlaza la fuente de datos al GridView utilizando el código de nominación.
                grd.DataSource = obj.obtenerObjecionxNominacion(int.Parse(lbl.Text));
                grd.DataBind();

                // Se verifica si hay objeciones asociadas al código de nominación actual y se muestra u oculta el panel en consecuencia.
                Panel pnl = (Panel)e.Item.FindControl("pnlObjeciones");
                pnl.Visible = grd.Rows.Count > 0;
            }
        }


        /// <summary>
        /// Maneja el evento de clic en el botón "Revisión". Redirige a la página de solicitud de revisión
        /// pasando el código del registro como argumento en la URL.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento (debe ser un botón).</param>
        /// <param name="e">Los argumentos del evento.</param>
        protected void btnRevision_Click(object sender, EventArgs e)
        {
            // Se obtiene el botón que generó el evento.
            Button b = (Button)sender;

            // Se redirige a la página de solicitud de revisión, pasando el código del registro como argumento en la URL.
            Response.Redirect("../procesos/frmSolicitarRevision.aspx?codN=" + b.CommandArgument);
        }


    }
}