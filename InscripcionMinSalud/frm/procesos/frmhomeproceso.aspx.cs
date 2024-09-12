using NegocioInscripcionMinSalud.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InscripcionMinSalud.frm.procesos
{
    public partial class frmhomeproceso : System.Web.UI.Page
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
                else {
                    clsParticipe = "tab-link active current";
                    clsResultados = "tab-link";
                    clsTabParticipe = "tab-content current";
                    clsTabResultados = "tab-content";
                }

                NegocioInscripcionMinSalud.data.clsNegocio obj = new NegocioInscripcionMinSalud.data.clsNegocio();
                var proceso = obj.obtenerProceso(int.Parse(Request.QueryString["cod"]));
                lblNombreProceso.Text = proceso.NOMBRE_PROCESO;
                iframeNominar.Src = "frmInscripcionProceso.aspx?codProceso=" + proceso.COD_PROCESO + "&v=" + Request.QueryString["v"];

                lnkAdopcion.NavigateUrl = lnkAdopcion.NavigateUrl + "?cod=" +Request.QueryString["cod"]+ "&v=" +Request.QueryString["v"]+ "&r=" +Request.QueryString["r"] +"";
                lnkAnalisis.NavigateUrl = lnkAnalisis.NavigateUrl + "?cod=" + Request.QueryString["cod"] + "&v=" + Request.QueryString["v"] + "&r=" + Request.QueryString["r"] + "";
                lnkConsultas.NavigateUrl = lnkConsultas.NavigateUrl + "?cod=" + Request.QueryString["cod"] + "&v=" + Request.QueryString["v"] + "&r=" + Request.QueryString["r"] + "";
                //lnkRevision.NavigateUrl = lnkRevision.NavigateUrl + "?cod=" + Request.QueryString["cod"] + "&v=" + Request.QueryString["v"] + "&r=" + Request.QueryString["r"] + "";

                VIGENCIA vigencia = proceso.VIGENCIA.FirstOrDefault(vig => vig.COD_VIGENCIA == Convert.ToInt32(Request.QueryString["v"]));

                if (vigencia != null)
                {
                    lblNombreProceso.Text = lblNombreProceso.Text +" - "+ vigencia.DESCRIPCION ;
                    if (DateTime.Now > vigencia.FECHA_INICIO && DateTime.Now <= vigencia.FECHA_FIN)
                    {
                        pnlVigenciaNominacion.Visible = true;
                        pnlNoVigenciaNominacion.Visible = false;
                    }
                    else
                    {
                        pnlVigenciaNominacion.Visible = false;
                        pnlNoVigenciaNominacion.Visible = true;
                    }

                    if (vigencia.ABIERTO)
                    {
                        pnlRegistrese.Visible = true;
                        pnlNoRegistrese.Visible = false;
                    }
                    else
                    {
                        pnlRegistrese.Visible = false;
                        pnlNoRegistrese.Visible = true;
                    }
                }
                else
                {
                    pnlVigenciaNominacion.Visible = false;
                    pnlNoVigenciaNominacion.Visible = true;
                }
            }
        }

        /// <summary>
        /// Maneja el evento Page_PreRender de la página.
        /// Controla la visibilidad de los paneles según la existencia de un valor en la sesión y la vigencia del proceso.
        /// </summary>
        protected void Page_PreRender()
        {
            if (Session["SS_COD_REGISTRO"] != null)
            {
                // Si hay un valor en la sesión "SS_COD_REGISTRO", muestra el panel pnlNoRegistrese y oculta pnlRegistrese
                pnlRegistrese.Visible = false;
                pnlNoRegistrese.Visible = true;
            }
            else
            {
                NegocioInscripcionMinSalud.data.clsNegocio negocio = new NegocioInscripcionMinSalud.data.clsNegocio();
                var proceso = negocio.obtenerProceso(int.Parse(Request.QueryString["cod"]));

                VIGENCIA vigencia = proceso.VIGENCIA.FirstOrDefault(vig => vig.COD_VIGENCIA == Convert.ToInt32(Request.QueryString["v"]));

                if (int.Parse(Request.QueryString["cod"]) == 18)
                {
                    // Si el valor de "cod" en la consulta es igual a 18, redirecciona a otra página
                    Response.Redirect("../procesos/frmInscripcionHuerfanas.aspx");
                }
                else
                {
                    if (vigencia != null)
                    {
                        if (vigencia.ABIERTO)
                        {
                            // Si la vigencia está abierta, muestra el panel pnlRegistrese y oculta pnlNoRegistrese
                            pnlRegistrese.Visible = true;
                            pnlNoRegistrese.Visible = false;
                        }
                        else
                        {
                            // Si la vigencia está cerrada, muestra el panel pnlNoRegistrese y oculta pnlRegistrese
                            pnlRegistrese.Visible = false;
                            pnlNoRegistrese.Visible = true;
                        }
                    }
                    else
                    {
                        // Si no hay información de vigencia, muestra el panel pnlRegistrese y oculta pnlNoRegistrese
                        pnlRegistrese.Visible = true;
                        pnlNoRegistrese.Visible = false;
                    }
                }
            }
        }

        /// <summary>
        /// Obtiene una cadena que representa el tipo según los parámetros proporcionados.
        /// </summary>
        /// <param name="esMedicamento">Indica si es un medicamento.</param>
        /// <param name="esProcedimiento">Indica si es un procedimiento.</param>
        /// <param name="esDispositivo">Indica si es un dispositivo.</param>
        /// <param name="esOtro">Indica si es de otro tipo.</param>
        /// <returns>Una cadena que representa el tipo.</returns>
        public string verTipo(object esMedicamento, object esProcedimiento, object esDispositivo, object esOtro)
        {
            // Si esMedicamento es true, se considera como "Medicamentos"
            if (esMedicamento != null && (bool)esMedicamento)
            {
                return "Medicamentos";
            }

            // Si esProcedimiento es true, se considera como "Procedimientos"
            if (esProcedimiento != null && (bool)esProcedimiento)
            {
                return "Procedimientos";
            }

            // Si esDispositivo es true, se considera como "Dispositivos"
            if (esDispositivo != null && (bool)esDispositivo)
            {
                return "Dispositivos";
            }

            // Si esOtro es true, se considera como "Otro"
            if (esOtro != null && (bool)esOtro)
            {
                return "Otro";
            }

            // En caso contrario, se devuelve una cadena vacía
            return "";
        }

        /// <summary>
        /// Obtiene una cadena que representa la presencia o ausencia de conflicto según el parámetro proporcionado.
        /// </summary>
        /// <param name="conflicto">Indica si hay conflicto.</param>
        /// <returns>Una cadena que representa la presencia o ausencia de conflicto.</returns>
        public string verconflicto(object conflicto)
        {
            // Si conflicto es nulo, se considera como "No definido"
            if (conflicto == null)
            {
                return "No definido";
            }

            // Si conflicto es true, se considera como "SI"; de lo contrario, se considera como "NO"
            return (bool)conflicto ? "SI" : "NO";
        }

        /// <summary>
        /// Obtiene una cadena que representa la presencia o ausencia de evidencia según el parámetro proporcionado.
        /// </summary>
        /// <param name="evidencia">Indica si hay evidencia.</param>
        /// <returns>Una cadena que representa la presencia o ausencia de evidencia.</returns>
        public string verEvidencia(object evidencia)
        {
            // Si evidencia es nulo, se considera como "No definido"
            if (evidencia == null)
            {
                return "No definido";
            }

            // Si evidencia es true, se considera como "SI"; de lo contrario, se considera como "NO"
            return (bool)evidencia ? "SI" : "NO";
        }

        /// <summary>
        /// Construye una cadena que representa los criterios de exclusión según los parámetros proporcionados.
        /// </summary>
        /// <param name="a">Indica si se cumple el criterio A.</param>
        /// <param name="b">Indica si se cumple el criterio B.</param>
        /// <param name="c">Indica si se cumple el criterio C.</param>
        /// <param name="d">Indica si se cumple el criterio D.</param>
        /// <param name="e">Indica si se cumple el criterio E.</param>
        /// <param name="f">Indica si se cumple el criterio F.</param>
        /// <returns>Una cadena que representa los criterios de exclusión.</returns>
        public string criteriosEclusion(object a, object b, object c, object d, object e, object f)
        {
            string res = "";

            // Verificar y agregar el criterio A
            if (a != null && (bool)a)
            {
                res += "A,";
            }

            // Verificar y agregar el criterio B
            if (b != null && (bool)b)
            {
                res += "B,";
            }

            // Verificar y agregar el criterio C
            if (c != null && (bool)c)
            {
                res += "C,";
            }

            // Verificar y agregar el criterio D
            if (d != null && (bool)d)
            {
                res += "D,";
            }

            // Verificar y agregar el criterio E
            if (e != null && (bool)e)
            {
                res += "E,";
            }

            // Verificar y agregar el criterio F
            if (f != null && (bool)f)
            {
                res += "F,";
            }

            // Si la cadena no está vacía, eliminar la última coma
            if (res != string.Empty)
            {
                res = res.Substring(0, res.Length - 1);
            }

            return res;
        }

        /// <summary>
        /// Devuelve la descripción del tipo según los parámetros proporcionados.
        /// </summary>
        /// <param name="esMedicamento">Indica si es un medicamento.</param>
        /// <param name="esProcedimiento">Indica si es un procedimiento.</param>
        /// <param name="esDispositivo">Indica si es un dispositivo.</param>
        /// <param name="esOtro">Indica si es de otro tipo.</param>
        /// <param name="medicamento">La descripción del medicamento.</param>
        /// <param name="procedimiento">La descripción del procedimiento.</param>
        /// <param name="dispositivo">La descripción del dispositivo.</param>
        /// <param name="otro">La descripción de otro tipo.</param>
        /// <returns>La descripción del tipo correspondiente.</returns>
        public string verDescripcionTipo(object esMedicamento, object esProcedimiento, object esDispositivo, object esOtro,
            object medicamento, object procedimiento, object dispositivo, object otro)
        {
            // Verificar si es un medicamento y si es así, devolver la descripción del medicamento
            if (esMedicamento != null && (bool)esMedicamento)
            {
                return medicamento.ToString();
            }

            // Verificar si es un procedimiento y si es así, devolver la descripción del procedimiento
            if (esProcedimiento != null && (bool)esProcedimiento)
            {
                return procedimiento.ToString();
            }

            // Verificar si es un dispositivo y si es así, devolver la descripción del dispositivo
            if (esDispositivo != null && (bool)esDispositivo)
            {
                return dispositivo.ToString();
            }

            // Verificar si es de otro tipo y si es así, devolver la descripción de otro tipo
            if (esOtro != null && (bool)esOtro)
            {
                return otro.ToString();
            }

            // Si no se cumple ninguna condición, devolver una cadena vacía
            return "";
        }

        /// <summary>
        /// Maneja el evento ItemDataBound del control DataList "datos".
        /// Se ejecuta cuando un elemento individual se va a enlazar a los datos en el DataList.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        protected void datos_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            // Verificar si el tipo de elemento es Item o AlternatingItem
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                // Encontrar el control Label "lblCodNominacion" en el elemento actual del DataList
                Label lbl = (Label)e.Item.FindControl("lblCodNominacion");

                // Encontrar el control Repeater "grdObjeciones" en el elemento actual del DataList
                Repeater grd = (Repeater)e.Item.FindControl("grdObjeciones");

                // Crear una instancia de la clase de negocios
                NegocioInscripcionMinSalud.data.clsNegocio obj = new NegocioInscripcionMinSalud.data.clsNegocio();

                // Establecer el origen de datos del Repeater con las objeciones para la nominación actual
                grd.DataSource = obj.obtenerObjecionxNominacion(int.Parse(lbl.Text));
                grd.DataBind();
            }
        }

        /// <summary>
        /// Maneja el evento ItemDataBound del control Repeater "rptResultados".
        /// Se ejecuta cuando un elemento individual se va a enlazar a los datos en el Repeater.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        protected void rptResultados_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                // Encontrar el control Label "lblCodNominacion2" en el elemento actual del Repeater
                Label lbl = (Label)e.Item.FindControl("lblCodNominacion2");

                // Encontrar el control GridView "grdObjeciones2" en el elemento actual del Repeater
                GridView grd = (GridView)e.Item.FindControl("grdObjeciones2");

                // Crear una instancia de la clase de negocios
                NegocioInscripcionMinSalud.data.clsNegocio obj = new NegocioInscripcionMinSalud.data.clsNegocio();

                // Establecer el origen de datos del GridView con las objeciones para la nominación actual
                grd.DataSource = obj.obtenerObjecionxNominacion(int.Parse(lbl.Text));
                grd.DataBind();

                // Mostrar u ocultar el Panel "pnlObjeciones" en función de si hay objeciones o no
                Panel pnl = (Panel)e.Item.FindControl("pnlObjeciones");
                pnl.Visible = grd.Rows.Count > 0;
            }
        }

        /// <summary>
        /// Maneja el evento Click del botón "Objetar".
        /// Redirige al usuario a la página "frmObjetar.aspx" con el código de argumento del botón como parte de la URL.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        protected void btnObjetar_Click(object sender, EventArgs e)
        {
            // Obtener el botón que desencadenó el evento
            Button b = (Button)sender;

            // Redirigir a la página "frmObjetar.aspx" con el código de argumento del botón como parte de la URL
            Response.Redirect("../procesos/frmObjetar.aspx?codN=" + b.CommandArgument);
        }

    }
}