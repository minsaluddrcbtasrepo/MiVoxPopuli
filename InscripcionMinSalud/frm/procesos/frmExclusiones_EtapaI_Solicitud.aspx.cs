using DatosInscripcionMinSalud;
using NegocioInscripcionMinSalud.data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;
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

                    pnlMensajeNoNominador.Visible = false;
                    pnlFormulario.Visible = true;


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


        [WebMethod]
        public static string GuardarAnexo(string nombreArchivo, string archivoBytes)
        {
            try
            {
                // Ruta donde se guardarán los archivos
                string rutaDirectorio = HttpContext.Current.Server.MapPath("~/files/tecnologiasExcluidas/anexosCriterios/");

                if (!Directory.Exists(rutaDirectorio))
                {
                    Directory.CreateDirectory(rutaDirectorio);
                }

                // Generar un nombre único con la fecha y hora actuales
                string fechaHora = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                nombreArchivo = CleanFileName(nombreArchivo);
                string nombreUnicoArchivo = $"{Path.GetFileNameWithoutExtension(nombreArchivo)}_{fechaHora}{Path.GetExtension(nombreArchivo)}";

                // Combinar la ruta del directorio con el nuevo nombre de archivo
                string rutaArchivo = Path.Combine(rutaDirectorio, nombreUnicoArchivo);

                // Convertir el string Base64 a un array de bytes
                byte[] archivoBytesArray = Convert.FromBase64String(archivoBytes);

                // Guardar el archivo en la ruta especificada
                File.WriteAllBytes(rutaArchivo, archivoBytesArray);

                return rutaArchivo;
            }
            catch (Exception ex)
            {
                return "Error al guardar el archivo: " + ex.Message;
            }
        }


        [WebMethod]
        public static Boolean GuardarDatos(PostulacionModel postulacionModel)
        {
            //generar la PostuacionTecnoIogiaExcIuida
            //
            try
            {
                var IdPostulacion = TecnologiaExcluidaSQLHelper.InsertPostuacionTecnoIogiaExcIuida(postulacionModel);
                if (IdPostulacion > 0)
                {
                    foreach (var criterio in postulacionModel.Criterios)
                    {
                        var idCriterioPostulacion = TecnologiaExcluidaSQLHelper.InsertarCriterioExcIusionPostulacion(criterio.Id, IdPostulacion);

                        if (idCriterioPostulacion > 0)
                        {
                            //guardar los anexos
                            foreach (var anexo in criterio.Anexos)
                            {
                                var idAnexo = TecnologiaExcluidaSQLHelper.InsertarAnexoCriterioExcIusionPostulacion(idCriterioPostulacion, anexo.Nombre, anexo.Descripcion, anexo.RutaArchivo, anexo.Justificacion);
                            }
                        }
                    }

                    foreach (var indicadorId in postulacionModel.Indicadores)
                    {
                        var idIndicador = TecnologiaExcluidaSQLHelper.InsertarIndicadorPostulacion(IdPostulacion, Convert.ToInt32(indicadorId));
                    }
                }

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }


        [WebMethod]
        public static Boolean GuardarDatosTest(PostulacionModelTEst postulacionModel)
        {
            //


            return true;

        }






        // Función para limpiar el nombre del archivo
        public static string CleanFileName(string originalFileName)
        {
            if (string.IsNullOrEmpty(originalFileName))
            {
                return string.Empty;
            }

            // Obtener la extensión del archivo
            string fileExtension = Path.GetExtension(originalFileName);
            // Obtener el nombre del archivo sin la extensión
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(originalFileName);

            // Reemplazar caracteres no permitidos con un guion bajo
            string cleanFileName = Regex.Replace(fileNameWithoutExtension, @"[<>:""/\\|?*]", "_");

            // Concatenar el nombre limpio con la extensión original
            return cleanFileName + fileExtension;
        }

    }
}