using DatosInscripcionMinSalud;
using NegocioInscripcionMinSalud.data;
using System;
using System.Collections.Generic;
using System.Web.Services;

namespace InscripcionMinSalud.frm.procesos
{
    public partial class frmExclusiones_EtapaI_Solicitud : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.QueryString["codProceso"] == null || Request.QueryString["codProceso"].ToString().Trim() == string.Empty)
            {
                Response.Redirect("~/Default.aspx");
                return;
            }
            if (Session["SS_NOMBRE_USUARIO"] == null || Session["SS_NOMBRE_USUARIO"].ToString() == string.Empty)
            {

                string parametros = Request.Url.PathAndQuery;
                parametros = parametros.Substring(parametros.IndexOf("frm/"));
                Response.Redirect("~/frm/seguridad/frmLogin.aspx?page=" + parametros.Replace("/", "@@").Replace("=", "**").Replace("&", "$$"));
            }



            clsNegocio obj = new clsNegocio();
            if (!IsPostBack)
            {
                int codR = 0;

                if (Session["SS_COD_REGISTRO"] != null) codR = int.Parse(Session["SS_COD_REGISTRO"].ToString());
                //cargamos la infomracion del registro
                if (codR != 0)
                {
                    var reg = obj.obtenerRegistroxCodigo(codR);
                    #region ajustamos visibilidad de los paneles para la nominacion
                    var tiposJuridicos = new List<int?> { 1, 4, 5, 6, 7, 8, 9, 10, 12, 28, 29, 30, 31, 26, 11, 27, 13, 14, 15, 16, 17, 19, 20, 18, 21, 22, 23, 24, 25, 39 };

                    if (tiposJuridicos.Contains(reg.COD_TIPO_JURIDICO))
                    {
                        pnlMensajeNoNominador.Visible = false;
                        pnlFormulario.Visible = true;

                    }
                    else
                    {
                        pnlMensajeNoNominador.Visible = true;
                        pnlFormulario.Visible = false;
                    }
                    #endregion

                }


            }

        }


        [WebMethod]
        public static List<TecnologiaExcluidaDto> GetTecnologiasExcluidas()
        {
            return TecnologiaExcluidaSQLHelper.GetListadoTecnoIogiaExCluida();
        }

        [WebMethod]
        public static List<IndicacionExclusionDto> GetIndicaciones(Int32 idTecnologia)
        {
            return TecnologiaExcluidaSQLHelper.GetListadoTecnoIogiaExCluida(idTecnologia);
        }

        [WebMethod]
        public static List<CriterioExcIusionDto> GetCriterios(Int32 idTecnologia)
        {
            return TecnologiaExcluidaSQLHelper.GetListadoCriterioExcIusion(idTecnologia);
        }


    }
}