using NegocioInscripcionMinSalud.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace InscripcionMinSalud.frm.procesos
{
    public partial class frmHomeProcesoNominacionAAA : System.Web.UI.Page
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

                //AAA
                //cod = 19 & v = 12 & r = 1
                if (proceso != null && proceso.COD_PROCESO == 18)
                {
                    lblDescProceso.Visible = false;
                    lblDescHuerfanas.Visible = true;
                    lblDescProcesoNomi.Visible = false;
                    lblDescHuerfanasNomi.Visible = true;
                    
                }

                if (proceso != null && proceso.ES_AAA == true) {

                    lblDescAAA.Visible=true;
                    iframeNominar.Src = "frmInscripcionProcesoAAA.aspx?codProceso=" + proceso.COD_PROCESO + "&v=" + Request.QueryString["v"];
                }



                lblNombreProceso.Text = proceso.NOMBRE_PROCESO;

                //Cambiar
                HyperLink2.NavigateUrl = HyperLink2.NavigateUrl + "?cod=" + Request.QueryString["cod"] + "&v=" + Request.QueryString["v"] + "&r=" + Request.QueryString["r"] + "";
                HyperLink3.NavigateUrl = HyperLink3.NavigateUrl + "?cod=" + Request.QueryString["cod"] + "&v=" + Request.QueryString["v"] + "&r=" + Request.QueryString["r"] + "";
                HyperLink4.NavigateUrl = HyperLink4.NavigateUrl + "?cod=" + Request.QueryString["cod"] + "&v=" + Request.QueryString["v"] + "&r=" + Request.QueryString["r"] + "";
                HyperLink5.NavigateUrl = HyperLink5.NavigateUrl + "?cod=" + Request.QueryString["cod"] + "&v=" + Request.QueryString["v"] + "&r=" + Request.QueryString["r"] + "";
               
                VIGENCIA vigencia = proceso.VIGENCIA.FirstOrDefault(vig => vig.COD_VIGENCIA == Convert.ToInt32(Request.QueryString["v"]));


                if (vigencia != null)
                {
                    lblNombreProceso.Text = lblNombreProceso.Text + " - " + vigencia.DESCRIPCION;
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

        protected void Page_PreRender()
        {
            if (Session["SS_COD_REGISTRO"] != null)
            {
                pnlRegistrese.Visible = false;
                pnlNoRegistrese.Visible = true;
            }
            else
            {
                NegocioInscripcionMinSalud.data.clsNegocio negocio = new NegocioInscripcionMinSalud.data.clsNegocio();
                var proceso = negocio.obtenerProceso(int.Parse(Request.QueryString["cod"]));

                VIGENCIA vigencia = proceso.VIGENCIA.FirstOrDefault(vig => vig.COD_VIGENCIA == Convert.ToInt32(Request.QueryString["v"]));

                if (vigencia != null)
                {
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
                    pnlRegistrese.Visible = true;
                    pnlNoRegistrese.Visible = false;
                }
            }
        }

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
            if (esDispositivo != null && (bool)esMedicamento)
            {
                return "Dispositivos";
            }
            if (esOtro != null && (bool)esMedicamento)
            {
                return "Otro";
            }
            return "";
        }

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

        //public string criteriosEclusion(object a, object b, object c, object d, object e, object f)
        //{
        //    string res = "";
        //    if (a != null && (bool)a)
        //    {
        //        res += "A,";
        //    }
        //    if (b != null && (bool)b)
        //    {
        //        res += "B,";
        //    }
        //    if (c != null && (bool)c)
        //    {
        //        res += "C,";
        //    }
        //    if (d != null && (bool)d)
        //    {
        //        res += "D,";
        //    }
        //    if (e != null && (bool)e)
        //    {
        //        res += "E,";
        //    }
        //    if (f != null && (bool)f)
        //    {
        //        res += "F,";
        //    }
        //    if (res != string.Empty)
        //    {
        //        res = res.Substring(0, res.Length - 1);
        //    }
        //    return res;
        //}

        //public string verDescripcionTipo(object esMedicamento, object esProcedimiento, object esDispositivo, object esOtro,
        //   object medicamento, object procedimiento, object dispositivo, object otro
        //   )
        //{
        //    if (esMedicamento != null && (bool)esMedicamento)
        //    {
        //        return medicamento.ToString();
        //    }
        //    if (esProcedimiento != null && (bool)esProcedimiento)
        //    {
        //        return procedimiento.ToString();
        //    }
        //    if (esDispositivo != null && (bool)esMedicamento)
        //    {
        //        return dispositivo.ToString();
        //    }
        //    if (esOtro != null && (bool)esMedicamento)
        //    {
        //        return otro.ToString();
        //    }
        //    return "";
        //}


        //Revisar  grd.DataSource = obj.obtenerObjecionxNominacion(int.Parse(lbl.Text))  para huerfanas
        protected void datos_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            Label lbl = (Label)e.Item.FindControl("lblCodNominacion");
            Repeater grd = (Repeater)e.Item.FindControl("grdObjeciones");
            NegocioInscripcionMinSalud.data.clsNegocio obj = new NegocioInscripcionMinSalud.data.clsNegocio();
            grd.DataSource = obj.obtenerObjecionxNominacion(int.Parse(lbl.Text));
            grd.DataBind();
        }

        protected void rptResultados_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            NegocioInscripcionMinSalud.data.clsNegocio obj = new NegocioInscripcionMinSalud.data.clsNegocio();
            var proceso = obj.obtenerProceso(int.Parse(Request.QueryString["cod"]));

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Label lbl = (Label)e.Item.FindControl("lblCodNominacion2");
                GridView grd = (GridView)e.Item.FindControl("grdObjeciones2");
                NegocioInscripcionMinSalud.data.clsNegocio obj2 = new NegocioInscripcionMinSalud.data.clsNegocio();
                grd.DataSource = obj2.obtenerObjecionxNominacionHuerfana(int.Parse(lbl.Text));
                grd.DataBind();
                if (grd.Rows.Count == 0)
                {

                    Panel pnl = (Panel)e.Item.FindControl("pnlObjecionesHuerfanas");
                    pnl.Visible = false;
                }
                else
                {
                    Panel pnl = (Panel)e.Item.FindControl("pnlObjecionesHuerfanas");
                    pnl.Visible = true;
                }
            }
        }

        protected void btnObjetar_Click2(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            Response.Redirect("../procesos/frmObjetarHuerfanas.aspx?codN=" + b.CommandArgument + "&codProceso=" + Request.QueryString["cod"]);
        }

    }
}