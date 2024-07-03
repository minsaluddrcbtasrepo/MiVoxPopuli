using NegocioInscripcionMinSalud;
using NegocioInscripcionMinSalud.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InscripcionMinSalud.frm.procesos
{
    public partial class frmInscripcionProceso : System.Web.UI.Page
    {
        class archivos
        {
            public string descripcion { set; get; }
            public string url { set; get; }
        }

        private List<archivos> ArchivosCargados
        {
            get
            {
                if (Session["ArchivosCargadosN"] == null)
                {
                    Session["ArchivosCargadosN"] = new List<archivos>();
                }
                return (List<archivos>)Session["ArchivosCargadosN"];
            }
        }

        private bool ValidarArchivoCargado()
        {
            foreach (var archivoCargado in ArchivosCargados)
            {
                string nombreArchivo = System.IO.Path.GetFileName(archivoCargado.url);

                if (nombreArchivo.StartsWith("3-"))
                {
                    return true;
                }
            }
            return false;
        }

        //private void CargarDatosArchivos()
        //{
        //    foreach (var archivo in ArchivosCargados)
        //    {
        //        string nombreArchivo = System.IO.Path.GetFileName(archivo.url);

        //        if (archivo.url.Contains("\\files\\Temporal"))
        //        {
        //            string pathRelativo = archivo.url.Substring(archivo.url.IndexOf("\\files\\Temporal"));
        //            pathRelativo = "~" + pathRelativo;
        //            lblArchivoView.InnerText = nombreArchivo;
        //            lblArchivoView.HRef = pathRelativo;
        //        }
        //    }
        //}

        protected void DescargarDocumentos()
        {
            string archivo = "";
            archivo = "3-" + Session["ticsfile"] + uploadDocumentoNatural.UploadedFiles[0].FileName;
            string pathArchivo = Server.MapPath("~/files/Temporal");
            if (!System.IO.Directory.Exists(pathArchivo))
            {
                System.IO.Directory.CreateDirectory(pathArchivo);
            }
            pathArchivo = System.IO.Path.Combine(pathArchivo, archivo);
            uploadDocumentoNatural.UploadedFiles.First().SaveAs(pathArchivo);
            Session["archivoPuente"] = pathArchivo;
        }

        protected void uploadDocumentoNatural_FileUploadComplete(object sender, DevExpress.Web.FileUploadCompleteEventArgs e)
        {
            if (uploadDocumentoNatural.UploadedFiles.Count() > 0)
            {
                DescargarDocumentos();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                lnkInicioPosible.NavigateUrl = lnkInicioPosible.NavigateUrl + "?page=" + Request.RawUrl.Replace("InscripcionParticipacionCiudadana", "").Replace("/", "@@").Replace("=", "**").Replace("&", "$$");
            }
            //      lblPaginaAnterior.Text = "~/" + Request.QueryString["page"].Replace("@@", "/").Replace("**", "=").Replace("$$", "");
            if (Session["SS_NOMBRE_USUARIO"] == null || Session["SS_NOMBRE_USUARIO"].ToString() == string.Empty)
            {
                btnGuardar.Visible = false;
                btnGuardarContinuar.Visible = false;
                posibleAclaracioes.Visible = true;
            }else {
                posibleAclaracioes.Visible = false;
            }



            if (Request.QueryString["codProceso"] == null || Request.QueryString["codProceso"].ToString().Trim() == string.Empty)
            {
                Response.Redirect("~/Default.aspx");
                return;
            }
            #region ocultamos paneles de validacion
            pnlValidacionA.Visible = false;
            pnlValidacionB.Visible = false;
            pnlValidacionC.Visible = false;
            pnlValidacionCie10a.Visible = false;
            pnlValidacionCie10b.Visible = false;
            pnlValidacionConflicto.Visible = false;
            pnlValidacionD.Visible = false;
            pnlValidacionE.Visible = false;
            pnlValidacionF.Visible = false;
            
            pnlValidacionNombreTecnologia.Visible = false;
            pnlObservacionesGenerales.Visible = false;
            pnlValidacionEvidencia.Visible = false;
            #endregion
            bool editaAclaraciones = false;
            if (!IsPostBack)
            {
                lblTic.Text = DateTime.Now.Ticks.ToString().Substring(10);
                Session["ticsfile"] = lblTic.Text;
                Session["ArchivosCargadosN"] = null;
                int codR = 0;

                if(Session["SS_COD_REGISTRO"] != null) codR=int.Parse(Session["SS_COD_REGISTRO"].ToString());

                if (Request.QueryString["codN"] != null && Request.QueryString["codN"] != string.Empty)
                {
                    lnkPDF.Visible = true;
                    lnkPDF.HRef = "../informes/frmReportViewer.aspx?cod=" + Request.QueryString["codN"];
                    clsNegocio obj = new clsNegocio();
                    var registro = obj.obtenerNOMINACION_PROCESO(int.Parse(Request.QueryString["codN"]));
                    pnlNominador.Visible = true;


                    if (registro.REGISTRO.ES_PERSONA_NATURAL)
                    {
                  
                        txtNombreNominador.Text = registro.REGISTRO.NOMBRE.Trim() + " " + registro.REGISTRO.APELLIDOS;
                        txtTipoAator.Text = "Persona natural";
                    }
                    else {
                  
                        txtNombreNominador.Text = registro.REGISTRO.NOMBRE.Trim() ;
                        txtTipoAator.Text = registro.REGISTRO.TIPO_JURIDICO.NOMBRE_TIPO_JURIDICO;
                  
                    }
                  

                    foreach ( var  k in registro.ARCHIVOXNOMINACION)
                    {
                        archivos a = new archivos();
                        a.descripcion = k.DESCRIPCION_ARCHIVO;
                        a.url = k.URL_ARCHIVO;
                        ArchivosCargados.Add(a);
                    }
                    if (registro.NRO_RADICADO != null && registro.NRO_RADICADO.Trim() != string.Empty)
                    {
                        pnlFisica.Visible = true;
                        txtRadicado.Text = registro.NRO_RADICADO;
                        txtAnotacion.Text = registro.NOTAS_NOMINACION;
                    }
                    lblCodNominacionProceso.Text = registro.COD_NOMINACION_PROCESO.ToString();
                    txtNombreTecnologia.Text = registro.ID_MANUAL.Trim()+"-"+ registro.NOMBRE_TECNOLOGIA;
                    txtConflicto.Text = registro.OBSERVACIONES_CONFLICTO;
                     txtEnfermedad.Text = registro.NOMBRE_ENFERMEDAD_CONDICION_SALUD;
                    txtEnfermedad2.Text = registro.OBSERVACION_TECNOLOGIA;

                    txtEvidencia.Text = registro.OBSERVACIONES_EVIDENCIA;
                    txtJustificacionA.Text = registro.OBS_CRITERIO_A;
                    txtJustificacionB.Text = registro.OBS_CRITERIO_B;
                    txtJustificacionC.Text = registro.OBS_CRITERIO_C;
                    txtJustificacionD.Text = registro.OBS_CRITERIO_D;
                    txtJustificacionE.Text = registro.OBS_CRITERIO_E;
                    txtJustificacionF.Text = registro.OBS_CRITERIO_F;

                    if (DateTime.Now > new DateTime(2019, 05, 25, 23, 59, 59))
                    {
                        btnObjetar.Visible = false;
                    }

                    /*
                    if (registro.PROCESO.FECHA_FIN_OBJECION 
                        > DateTime.Now && registro.COD_ESTADO_NOMINACION ==3)//tan pronto se dejan de nominar se objetan
                    {
                        btnObjetar.Visible = true;
                    }
                    else {
                        btnObjetar.Visible = false;
                    }*/
                    //queda siempre visile

                    if (registro.ADJUNTA_EVIDENCIA.HasValue)
                    {
                        chkAdjuntaEvidencia.Checked = registro.ADJUNTA_EVIDENCIA.Value;
                        chkNoAdjuntaEvidencia.Checked = !registro.ADJUNTA_EVIDENCIA.Value;
                    }

                    if (registro.CONFLICTO_INTERES.HasValue)
                    {
                        chkConflictoInteres.Checked = registro.CONFLICTO_INTERES.Value;
                        chkNoConflictoInteres.Checked = !registro.CONFLICTO_INTERES.Value;
                    }
                    if (registro.ES_DISPOSITIVO_MEDICO.HasValue)
                        chkEsDispositivoMedico.Checked = registro.ES_DISPOSITIVO_MEDICO.Value;
                    if (registro.ES_MEDICAMENTO.HasValue)
                        chkEsMedicamento.Checked = registro.ES_MEDICAMENTO.Value;
                    if (registro.ES_OTRO.HasValue)
                        chkEsOtro.Checked = registro.ES_OTRO.Value;
                    if (registro.ES_PROCEDIMIENTO.HasValue)
                        chkEsProcedimiento.Checked = registro.ES_PROCEDIMIENTO.Value;
                    if (registro.ES_SERVICIO_SALUD.HasValue)
                        chkServicioSalud.Checked = registro.ES_SERVICIO_SALUD.Value;


                    if (registro.CRITERIO_A.HasValue)
                    chkExclusionA.Checked = registro.CRITERIO_A.Value;
                    if (registro.CRITERIO_B.HasValue)
                        chkExclusionB.Checked = registro.CRITERIO_B.Value;
                    if (registro.CRITERIO_C.HasValue)
                        chkExclusionC.Checked = registro.CRITERIO_C.Value;
                    if (registro.CRITERIO_D.HasValue)
                        chkExclusionD.Checked = registro.CRITERIO_D.Value;
                    if (registro.CRITERIO_E.HasValue)
                        chkExclusionE.Checked = registro.CRITERIO_E.Value;
                    if (registro.CRITERIO_F.HasValue)
                        chkExclusionF.Checked = registro.CRITERIO_F.Value;
                    //if (registro.RUTA_EVIDENCIA != string.Empty)
                    //{
                    //    ArchivosCargados.Add(registro.RUTA_EVIDENCIA);
                    //}

                    if (
                        (Session["SS_COD_REGISTRO"] != null && registro.COD_REGISTRO.ToString() == Session["SS_COD_REGISTRO"].ToString())
                        &&
                        (registro.COD_ESTADO_NOMINACION == 1 || registro.COD_ESTADO_NOMINACION == 4)
                         
                        )
                    {
                        //permite editar lo diligenciado, por defecto viene diligenciado.
                    } else
                    {
                        #region los campos no se pueden modificar en este estado
                        txtConflicto.ReadOnly = true;
                        
                        txtEnfermedad.ReadOnly = true;
                        txtEnfermedad2.ReadOnly = true;
                        txtEvidencia.ReadOnly = true;
                        txtJustificacionA.ReadOnly = true;
                        txtJustificacionB.ReadOnly = true;
                        txtJustificacionC.ReadOnly = true;
                        txtJustificacionD.ReadOnly = true;
                        txtJustificacionE.ReadOnly = true;
                        txtJustificacionF.ReadOnly = true;
                        
                        txtNombreTecnologia.ReadOnly = true;
                        
                        chkAdjuntaEvidencia.Enabled = false;
                        chkConflictoInteres.Enabled = false;
                        chkEsDispositivoMedico.Enabled = false;
                        chkEsMedicamento.Enabled = false;
                        chkEsOtro.Enabled = false;
                        chkEsProcedimiento.Enabled = false;
                        chkServicioSalud.Enabled = false;
                        chkExclusionA.Enabled = false;
                        chkExclusionB.Enabled = false;
                        chkExclusionC.Enabled = false;
                        chkExclusionD.Enabled = false;
                        chkExclusionE.Enabled = false;
                        chkExclusionF.Enabled = false;
                        chkNoAdjuntaEvidencia.Enabled = false;
                        chkNoConflictoInteres.Enabled = false;

                        btnGuardar.Visible = false;
                        btnGuardarContinuar.Visible = false;
                        btnArchivo.Visible = false;
#endregion
                    }

                    if (registro.COD_ESTADO_NOMINACION >2 && Session["SS_COD_REGISTRO"] != null && (registro.COD_REGISTRO.ToString() == Session["SS_COD_REGISTRO"].ToString())
                        )
                    {
                        if (registro.COD_ESTADO_NOMINACION == 4)
                        {//siginifica que va  editar los campos 
                            btnGuardarContinuar.Visible = true;
                            txtConflicto.ReadOnly = false;

                            txtEnfermedad.ReadOnly = false;
                            txtEnfermedad2.ReadOnly = false;
                            txtEvidencia.ReadOnly = false;
                            txtJustificacionA.ReadOnly = false;
                            txtJustificacionB.ReadOnly = false;
                            txtJustificacionC.ReadOnly = false;
                            txtJustificacionD.ReadOnly = false;
                            txtJustificacionE.ReadOnly = false;
                            txtJustificacionF.ReadOnly = false;

                            txtNombreTecnologia.ReadOnly = false;

                            chkAdjuntaEvidencia.Enabled = true;
                            chkConflictoInteres.Enabled = true;
                            chkEsDispositivoMedico.Enabled = true;
                            chkEsMedicamento.Enabled = true;
                            chkEsOtro.Enabled = true;
                            chkEsProcedimiento.Enabled = true;
                            chkServicioSalud.Enabled = true;
                            chkExclusionA.Enabled = true;
                            chkExclusionB.Enabled = true;
                            chkExclusionC.Enabled = true;
                            chkExclusionD.Enabled = true;
                            chkExclusionE.Enabled = true;
                            chkExclusionF.Enabled = true;
                            chkNoAdjuntaEvidencia.Enabled = true;
                            chkNoConflictoInteres.Enabled = true;

                        }
                        pnlValidacionA.Visible = true;
                        pnlValidacionB.Visible = true;
                        pnlValidacionC.Visible = true;
                        pnlValidacionCie10a.Visible = true;
                        pnlValidacionCie10b.Visible = true;
                        //pnlValidacionCie10c.Visible = true;
                        pnlValidacionConflicto.Visible = true;
                        pnlValidacionD.Visible = true;
                        pnlValidacionE.Visible = true;
                        pnlValidacionF.Visible = true;
                        
                        pnlValidacionNombreTecnologia.Visible = true;
                        pnlValidacionEvidencia.Visible = true;
                        pnlObservacionesGenerales.Visible = true;
                        //
                        var nominacion = obj.obtenerVALIDACION_PROCESO(registro.COD_NOMINACION_PROCESO);
                        var parametros = obj.obtenerPARAMETRO_VALIDACION();
                        txtObservacionesGenerales.Text = nominacion.OBSERVACIONES_GENERALES;

                        //cmbGrupoCie10.SelectedValue =


                        var valA = nominacion.DETALLE_VALIDACION_PROCESO.Join(parametros, x => x.COD_PARAMETRO_VALIDACION, x2 => x2.COD_PARAMETRO_VALIDACION, (x, x2) => new { detalle = x, parametro = x2 })
                            .Where(x3 => x3.parametro.COD_GRUPO_PARAMETRO_VALIDACION == 1).Select(x3 => x3.parametro).FirstOrDefault();
                        if (valA != null)
                        {
                            cmbGrupoNombreTecnologia.SelectedValue = valA.COD_PARAMETRO_VALIDACION.ToString();
                            //if (valA.ES_OK )
                            //{
                            //    pnlValidacionNombreTecnologia.Visible = false;
                            //}
                        }

                        var valB = nominacion.DETALLE_VALIDACION_PROCESO.Join(parametros, x => x.COD_PARAMETRO_VALIDACION, x2 => x2.COD_PARAMETRO_VALIDACION, (x, x2) => new { detalle = x, parametro = x2 })
                            .Where(x3 => x3.parametro.COD_GRUPO_PARAMETRO_VALIDACION == 2 && x3.detalle.CONSECUTIVO == 1).Select(x3 => x3.parametro).FirstOrDefault();
                        if (valB != null)
                        {
                            cmbGrupoCie10.SelectedValue = valB.COD_PARAMETRO_VALIDACION.ToString();
                            //if (valB.ES_OK)
                            //{
                            //    pnlValidacionCie10a.Visible = false;
                            //}
                        }

                        var valB2 = nominacion.DETALLE_VALIDACION_PROCESO.Join(parametros, x => x.COD_PARAMETRO_VALIDACION, x2 => x2.COD_PARAMETRO_VALIDACION, (x, x2) => new { detalle = x, parametro = x2 })
                            .Where(x3 => x3.parametro.COD_GRUPO_PARAMETRO_VALIDACION == 2 && x3.detalle.CONSECUTIVO == 2).Select(x3 => x3.parametro).FirstOrDefault();
                        if (valB2 != null)
                        {
                            cmbGrupoCie10b.SelectedValue = valB2.COD_PARAMETRO_VALIDACION.ToString();
                            //if (valB2.ES_OK)
                            //{
                            //    pnlValidacionCie10b.Visible = false;
                            //}
                        }

                        var valB3 = nominacion.DETALLE_VALIDACION_PROCESO.Join(parametros, x => x.COD_PARAMETRO_VALIDACION, x2 => x2.COD_PARAMETRO_VALIDACION, (x, x2) => new { detalle = x, parametro = x2 })
                            .Where(x3 => x3.parametro.COD_GRUPO_PARAMETRO_VALIDACION == 2 && x3.detalle.CONSECUTIVO == 3).Select(x3 => x3.parametro).FirstOrDefault();
                        if (valB3 != null)
                        {
                          //  cmbGrupoCie10c.SelectedValue = valB3.COD_PARAMETRO_VALIDACION.ToString();
                            //if (valB3.ES_OK)
                            //{
                            //    pnlValidacionCie10c.Visible = false;
                            //}
                        }

                       

                        var valG = nominacion.DETALLE_VALIDACION_PROCESO.Join(parametros, x => x.COD_PARAMETRO_VALIDACION, x2 => x2.COD_PARAMETRO_VALIDACION, (x, x2) => new { detalle = x, parametro = x2 })
                            .Where(x3 => x3.parametro.COD_GRUPO_PARAMETRO_VALIDACION == 7 && x3.detalle.CONSECUTIVO == 1).Select(x3 => x3.parametro).FirstOrDefault();
                        if (valG != null)
                        {
                            cmbGrupoCriterioA.SelectedValue = valG.COD_PARAMETRO_VALIDACION.ToString();
                            //if (valG.ES_OK)
                            //{
                            //    pnlValidacionA.Visible = false;
                            //}
                        }
                        var valG2 = nominacion.DETALLE_VALIDACION_PROCESO.Join(parametros, x => x.COD_PARAMETRO_VALIDACION, x2 => x2.COD_PARAMETRO_VALIDACION, (x, x2) => new { detalle = x, parametro = x2 })
                            .Where(x3 => x3.parametro.COD_GRUPO_PARAMETRO_VALIDACION == 7 && x3.detalle.CONSECUTIVO == 2).Select(x3 => x3.parametro).FirstOrDefault();
                        if (valG2 != null)
                        {
                            cmbGrupoCriterioB.SelectedValue = valG2.COD_PARAMETRO_VALIDACION.ToString();
                            //if (valG2.ES_OK)
                            //{
                            //    pnlValidacionB.Visible = false;
                            //}
                        }
                        var valG3 = nominacion.DETALLE_VALIDACION_PROCESO.Join(parametros, x => x.COD_PARAMETRO_VALIDACION, x2 => x2.COD_PARAMETRO_VALIDACION, (x, x2) => new { detalle = x, parametro = x2 })
                            .Where(x3 => x3.parametro.COD_GRUPO_PARAMETRO_VALIDACION == 7 && x3.detalle.CONSECUTIVO == 3).Select(x3 => x3.parametro).FirstOrDefault();
                        if (valG3 != null)
                        {
                            cmbGrupoCriterioC.SelectedValue = valG3.COD_PARAMETRO_VALIDACION.ToString();
                            //if (valG3.ES_OK)
                            //{
                            //    pnlValidacionC.Visible = false;
                            //}
                        }
                        var valG4 = nominacion.DETALLE_VALIDACION_PROCESO.Join(parametros, x => x.COD_PARAMETRO_VALIDACION, x2 => x2.COD_PARAMETRO_VALIDACION, (x, x2) => new { detalle = x, parametro = x2 })
                            .Where(x3 => x3.parametro.COD_GRUPO_PARAMETRO_VALIDACION == 7 && x3.detalle.CONSECUTIVO == 4).Select(x3 => x3.parametro).FirstOrDefault();
                        if (valG4 != null)
                        {
                            cmbGrupoCriterioD.SelectedValue = valG4.COD_PARAMETRO_VALIDACION.ToString();
                            //if (valG4.ES_OK)
                            //{
                            //    pnlValidacionD.Visible = false;
                            //}
                        }
                        var valG5 = nominacion.DETALLE_VALIDACION_PROCESO.Join(parametros, x => x.COD_PARAMETRO_VALIDACION, x2 => x2.COD_PARAMETRO_VALIDACION, (x, x2) => new { detalle = x, parametro = x2 })
                            .Where(x3 => x3.parametro.COD_GRUPO_PARAMETRO_VALIDACION == 7 && x3.detalle.CONSECUTIVO == 5).Select(x3 => x3.parametro).FirstOrDefault();
                        if (valG5 != null)
                        {
                            cmbGrupoCriterioE.SelectedValue = valG5.COD_PARAMETRO_VALIDACION.ToString();
                            //if (valG5.ES_OK)
                            //{
                            //    pnlValidacionE.Visible = false;
                            //}
                        }
                        var valG6 = nominacion.DETALLE_VALIDACION_PROCESO.Join(parametros, x => x.COD_PARAMETRO_VALIDACION, x2 => x2.COD_PARAMETRO_VALIDACION, (x, x2) => new { detalle = x, parametro = x2 })
                            .Where(x3 => x3.parametro.COD_GRUPO_PARAMETRO_VALIDACION == 7 && x3.detalle.CONSECUTIVO == 6).Select(x3 => x3.parametro).FirstOrDefault();
                        if (valG6 != null)
                        {
                            cmbGrupoCriterioF.SelectedValue = valG6.COD_PARAMETRO_VALIDACION.ToString();
                            //if (valG6.ES_OK)
                            //{
                            //    pnlValidacionF.Visible = false;
                            //}
                        }
                        
                        
                        var valH = nominacion.DETALLE_VALIDACION_PROCESO.Join(parametros, x => x.COD_PARAMETRO_VALIDACION, x2 => x2.COD_PARAMETRO_VALIDACION, (x, x2) => new { detalle = x, parametro = x2 })
                            .Where(x3 => x3.parametro.COD_GRUPO_PARAMETRO_VALIDACION == 8).Select(x3 => x3.parametro).FirstOrDefault();
                        if (valH != null)
                        {
                            cmbGrupoEvidencia.SelectedValue = valH.COD_PARAMETRO_VALIDACION.ToString();
                            //if (valH.ES_OK)
                            //{
                            //    pnlValidacionEvidencia.Visible = false;
                            //}
                        }

                        var valK = nominacion.DETALLE_VALIDACION_PROCESO.Join(parametros, x => x.COD_PARAMETRO_VALIDACION, x2 => x2.COD_PARAMETRO_VALIDACION, (x, x2) => new { detalle = x, parametro = x2 })
                            .Where(x3 => x3.parametro.COD_GRUPO_PARAMETRO_VALIDACION == 9).Select(x3 => x3.parametro).FirstOrDefault();
                        if (valK != null)
                        {
                            cmbGrupoConflicto.SelectedValue = valK.COD_PARAMETRO_VALIDACION.ToString();
                            //if (valK.ES_OK) {
                            //    pnlValidacionConflicto.Visible = false;
                            //}
                        }
                        var valconcepto = nominacion.DETALLE_VALIDACION_PROCESO.Join(parametros, x => x.COD_PARAMETRO_VALIDACION, x2 => x2.COD_PARAMETRO_VALIDACION, (x, x2) => new { detalle = x, parametro = x2 })
                            .Where(x3 => x3.parametro.COD_GRUPO_PARAMETRO_VALIDACION == 10).Select(x3 => x3.parametro).FirstOrDefault();
                        if (valconcepto != null)
                        {
                            cmbGrupoConcepto.SelectedValue = valconcepto.COD_PARAMETRO_VALIDACION.ToString();
                        }
                    }

                }
            }

            renderArchivos();
        }

        /// <summary>
        /// Maneja el evento Click del botón "btnGuardarContinuar".
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los argumentos del evento.</param>
        protected void btnGuardarContinuar_Click(object sender, EventArgs e)
        {
            // Llama al método de guardar.
            guardar();

            // Valida y envía si la validación es exitosa.
            if (validar())
            {
                enviar();
            }
        }


        /// <summary>
        /// Maneja el evento Click del botón "btnGuardar".
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los argumentos del evento.</param>
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            // Llama al método de guardar.
            guardar();
        }


        /// <summary>
        /// Valida los campos del formulario antes de guardar la nominación.
        /// </summary>
        /// <returns>True si la validación es exitosa, false si hay errores.</returns>
        private bool validar()
        {
            bool error = false;
            LblValidacionCampos.Text = "";
            LblValidacionCampos.Text += "Verifique los Siguientes Campos: ";
            #region nombre tecnologia
            txtNombreTecnologia.CssClass = "";
            txtNombreTecnologia.Attributes.Remove("placeholder");
            if (txtNombreTecnologia.Text == "")
            {
                error = true;
                LblValidacionCampos.Text += "Nombre de la tecnologia, ";
                txtNombreTecnologia.Attributes.Add("placeholder", "Debe ingresar el nombre de la tecnologia ");
                txtNombreTecnologia.CssClass = "form-control errormin";
            }
            else
            {
                txtNombreTecnologia.CssClass = "form-control";
            }
            #endregion

            #region nombre tecnologia
            txtEnfermedad.CssClass = "";
            txtEnfermedad.Attributes.Remove("placeholder");
            if (txtEnfermedad.Text == "")
            {
                error = true;
                LblValidacionCampos.Text += "Nombre la enfermedad o condición de salud que motiva la nominación de exclusión de la tecnologia , ";
                txtEnfermedad.Attributes.Add("placeholder", "Debe ingresar Nombre la enfermedad o condición de salud que motiva la nominación de exclusión de la tecnologia  ");
                txtEnfermedad.CssClass = "form-control errormin";
            }
            else
            {
                txtEnfermedad.CssClass = "form-control";
            }
            #endregion

            if(!chkEsMedicamento.Checked && !chkServicioSalud.Checked && !chkEsProcedimiento.Checked && !chkEsDispositivoMedico.Checked && !chkEsOtro.Checked)
            {
                error = true;
                LblValidacionCampos.Text += " Seleccionar la opción que mejor describe la tecnología a nominar.,  ";
            }

           
            if (chkExclusionA.Checked && txtJustificacionA.Text.Trim() == string.Empty)
            {
                txtJustificacionA.CssClass = "";
                txtJustificacionA.Attributes.Remove("placeholder");
                LblValidacionCampos.Text += "criterios de exclusión A,  ";
                txtJustificacionA.Attributes.Add("placeholder", "Debe ingresar la descripción del criterios de exclusión");
                txtJustificacionA.CssClass = "form-control errormin";
            }
            if (chkExclusionB.Checked && txtJustificacionB.Text.Trim() == string.Empty)
            {
                txtJustificacionB.CssClass = "";
                txtJustificacionB.Attributes.Remove("placeholder");
                LblValidacionCampos.Text += "criterios de exclusión B,  ";
                txtJustificacionB.Attributes.Add("placeholder", "Debe ingresar la descripción del criterios de exclusión");
                txtJustificacionB.CssClass = "form-control errormin";
            }
            if (chkExclusionC.Checked && txtJustificacionC.Text.Trim() == string.Empty)
            {
                txtJustificacionC.CssClass = "";
                txtJustificacionC.Attributes.Remove("placeholder");
                LblValidacionCampos.Text += "criterios de exclusión C,  ";
                txtJustificacionC.Attributes.Add("placeholder", "Debe ingresar la descripción del criterios de exclusión");
                txtJustificacionC.CssClass = "form-control errormin";
            }
            if (chkExclusionD.Checked && txtJustificacionD.Text.Trim() == string.Empty)
            {
                txtJustificacionD.CssClass = "";
                txtJustificacionD.Attributes.Remove("placeholder");
                LblValidacionCampos.Text += "criterios de exclusión D,  ";
                txtJustificacionD.Attributes.Add("placeholder", "Debe ingresar la descripción del criterios de exclusión");
                txtJustificacionD.CssClass = "form-control errormin";
            }
            if (chkExclusionE.Checked && txtJustificacionE.Text.Trim() == string.Empty)
            {
                txtJustificacionE.CssClass = "";
                txtJustificacionE.Attributes.Remove("placeholder");
                LblValidacionCampos.Text += "criterios de exclusión E,  ";
                txtJustificacionE.Attributes.Add("placeholder", "Debe ingresar la descripción del criterios de exclusión");
                txtJustificacionE.CssClass = "form-control errormin";
            }
            if (chkExclusionF.Checked && txtJustificacionF.Text.Trim() == string.Empty)
            {
                txtJustificacionF.CssClass = "";
                txtJustificacionF.Attributes.Remove("placeholder");
                LblValidacionCampos.Text += "criterios de exclusión F,  ";
                txtJustificacionF.Attributes.Add("placeholder", "Debe ingresar la descripción del criterios de exclusión");
                txtJustificacionF.CssClass = "form-control errormin";
            }
            if (chkAdjuntaEvidencia.Checked && txtEvidencia.Text.Trim() == string.Empty)
            {
                txtEvidencia.CssClass = "";
                txtEvidencia.Attributes.Remove("placeholder");
                LblValidacionCampos.Text += "Relacione la evidencia,  ";
                txtEvidencia.Attributes.Add("placeholder", "Debe Relacionar la evidencia");
                txtEvidencia.CssClass = "form-control errormin";
            }
            if (chkConflictoInteres.Checked && txtConflicto.Text.Trim() == string.Empty)
            {
                txtConflicto.CssClass = "";
                txtConflicto.Attributes.Remove("placeholder");
                LblValidacionCampos.Text += "Relacione el conflicto de interes,  ";
                txtConflicto.Attributes.Add("placeholder", "Debe relacionar el conflicto de interes");
                txtConflicto.CssClass = "form-control errormin";
            }
            if (!chkAdjuntaEvidencia.Checked && !chkNoAdjuntaEvidencia.Checked)
            {
                error = true;
                LblValidacionCampos.Text += "Debe seleccionar si adjunta evidencia,  ";
            }
            if (!chkConflictoInteres.Checked && !chkNoConflictoInteres.Checked )
            {
                error = true;
                LblValidacionCampos.Text += "Debe seleccionar si tiene conflicto de intereses,  ";
            }
            return !error;
        }

        /// <summary>
        /// Envia la nominación y realiza las acciones correspondientes.
        /// </summary>
        private void enviar()
        {
            // Crea una instancia de la clase de negocios.
            clsNegocio cls = new clsNegocio();

            try
            {
                // Intenta convertir el texto del código de nominación a entero.
                int id = int.Parse(lblCodNominacionProceso.Text);
            }
            catch
            {
                // Verifica la presencia del parámetro de vigencia y del código de registro en la sesión.
                if (Request.QueryString["v"] == null || Session["SS_COD_REGISTRO"] == null)
                {
                    // Redirige a la página de inicio de sesión con la información de retorno.
                    Response.Redirect("~/aspx/seguridad/frmLogin.aspx?page=aspx@@evento@@frmconfirmacionevento.aspx");
                    return;
                }
            }

            // Obtiene la información de la nominación proceso.
            var obj = cls.obtenerNOMINACION_PROCESO(int.Parse(lblCodNominacionProceso.Text));

            // Verifica el estado de la nominación.
            if (obj.COD_ESTADO_NOMINACION == 1)
            {
                // Establece el texto para el caso en que la nominación es recibida por primera vez.
                string textoNuevo = "Queremos informarle que su nominación ha sido recibida";

                // Verifica si el código de nominación no está vacío.
                if (lblCodNominacionProceso.Text != string.Empty)
                {
                    // Establece el texto para el caso en que la nominación ya existe.
                    textoNuevo = "Queremos informarle que los cambios de su nominación han sido recibidos";
                }

                // Envia la nominación y actualiza el estado a 2 (Recibido).
                cls.enviarNominacionExlcusiones(int.Parse(lblCodNominacionProceso.Text), 2);

                // Establece el título y el mensaje para la sesión.
                Session["msgtitulo"] = "Gracias por completar su nominación";
                Session["msgmsg"] = $@"Muchas gracias por su participación en el {obj.PROCESO.NOMBRE_PROCESO}. {textoNuevo}
            <br>
            <br>
            Le comunicaremos oportunamente cualquier tipo de novedad con respecto a su nominación.
            <br>
            <br>";

                // Crea una instancia de la clase de utilidades web.
                clsWebUtils email = new clsWebUtils();

                // Obtiene el asunto y el cuerpo del mensaje de la sesión.
                string asunto = Session["msgtitulo"].ToString();
                string cuerpo = Session["msgmsg"].ToString();

                // Envia el correo electrónico.
                email.enviarEmail(asunto, cuerpo, Session["SS_CORREO"].ToString());
            }
            else
            {
                // Envia la nominación y actualiza el estado a 2 (Recibido).
                cls.enviarNominacion(int.Parse(lblCodNominacionProceso.Text), 2);

                // Establece el título y el mensaje para la sesión.
                Session["msgtitulo"] = "Gracias por actualizar su nominación";
                Session["msgmsg"] = $@"Muchas gracias por su participación en el {obj.PROCESO.NOMBRE_PROCESO}. Queremos informarle que los cambios de su nominación han sido recibidos.
            <br>
            <br>
            Le comunicaremos oportunamente cualquier tipo de novedad con respecto a su nominación.
            <br>
            <br>";

                // Crea una instancia de la clase de utilidades web.
                clsWebUtils email = new clsWebUtils();

                // Obtiene el asunto y el cuerpo del mensaje de la sesión.
                string asunto = Session["msgtitulo"].ToString();
                string cuerpo = Session["msgmsg"].ToString();

                // Envia el correo electrónico.
                email.enviarEmail(asunto, cuerpo, Session["SS_CORREO"].ToString());
            }

            // Redirige a la página de mensaje.
            Response.Redirect("~/frm/logica/frmMensajeIframe.aspx");
        }


        /// <summary>
        /// Guarda la información de la nominación en la base de datos.
        /// </summary>
        private void guardar()
        {
            // Verifica si la sesión de código de registro está presente.
            if (Session["SS_COD_REGISTRO"] == null)
            {
                // Redirige a la página de inicio de sesión si la sesión no está presente.
                Response.Redirect("~/aspx/seguridad/frmLogin.aspx");
                return;
            }

            // Inicializa la variable de vigencia.
            int vigencia = 0;

            // Verifica si el parámetro de código de nominación no está presente.
            if (Request.QueryString["codN"] == null)
            {
                // Verifica la presencia del parámetro de vigencia y del código de registro en la sesión.
                if (Request.QueryString["v"] == null || Session["SS_COD_REGISTRO"] == null)
                {
                    // Redirige a la página de inicio de sesión con la información de retorno.
                    Response.Redirect("~/aspx/seguridad/frmLogin.aspx?page=aspx@@evento@@frmconfirmacionevento.aspx");
                    return;
                }
                else
                {
                    // Obtiene la vigencia del parámetro.
                    vigencia = int.Parse(Request.QueryString["v"]);
                }
            }

            // Crea una instancia de la clase de negocios.
            clsNegocio cls = new clsNegocio();

            // Inicializa el código de nominación.
            int? codN = null;

            // Verifica si el texto del código de nominación no está vacío.
            if (lblCodNominacionProceso.Text.Trim() != string.Empty)
            {
                // Convierte el texto del código de nominación a entero y asigna a la variable.
                codN = int.Parse(lblCodNominacionProceso.Text);
            }

            // Crea una lista para almacenar la información de los archivos adjuntos.
            List<ARCHIVOXNOMINACION> lista = new List<ARCHIVOXNOMINACION>();

            // Recorre la lista de archivos cargados.
            for (int k = 0; k < ArchivosCargados.Count; k++)
            {
                // Crea una instancia de ARCHIVOXNOMINACION y asigna la información del archivo actual.
                ARCHIVOXNOMINACION ar = new ARCHIVOXNOMINACION();
                ar.DESCRIPCION_ARCHIVO = ArchivosCargados[k].descripcion;
                ar.URL_ARCHIVO = ArchivosCargados[k].url;

                // Agrega el archivo a la lista.
                lista.Add(ar);
            }

            // Llama al método de la clase de negocios para guardar la nominación.
            var i = cls.guardarNominacion(
                codN,
                int.Parse(Request.QueryString["codProceso"]),
                vigencia,
                int.Parse(Session["SS_COD_REGISTRO"].ToString()),
                chkEsMedicamento.Checked,
                chkEsProcedimiento.Checked,
                chkEsDispositivoMedico.Checked,
                chkEsOtro.Checked,
                chkServicioSalud.Checked,
                txtNombreTecnologia.Text,
                txtEnfermedad.Text,
                txtEnfermedad2.Text,
                chkExclusionA.Checked,
                chkExclusionB.Checked,
                chkExclusionC.Checked,
                chkExclusionD.Checked,
                chkExclusionE.Checked,
                chkExclusionF.Checked,
                txtJustificacionA.Text,
                txtJustificacionB.Text,
                txtJustificacionC.Text,
                txtJustificacionD.Text,
                txtJustificacionE.Text,
                txtJustificacionF.Text,
                (!chkAdjuntaEvidencia.Checked && !chkNoAdjuntaEvidencia.Checked) ? ((bool?)null) : chkAdjuntaEvidencia.Checked,
                txtEvidencia.Text,
                lblArchivoView.HRef,
                (!chkConflictoInteres.Checked && !chkNoConflictoInteres.Checked) ? ((bool?)null) : chkConflictoInteres.Checked,
                txtConflicto.Text,
                lista
            );

            // Asigna el código de nominación resultante al control de etiqueta correspondiente.
            lblCodNominacionProceso.Text = i.ToString();

            // Muestra un mensaje de validación indicando que la información ha sido guardada exitosamente.
            LblValidacionCampos.Text = "La información ha sido guardada exitosamente en su cuenta y estará disponible para ser completada y remitida para el proceso vigente.";
        }


        /// <summary>
        /// Maneja el evento de clic en el botón para adjuntar un archivo.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Los argumentos del evento.</param>
        protected void btnArchivo_Click(object sender, EventArgs e)
        {
            // Limpia la sesión que almacena el archivo temporal.
            Session["archivoPuente"] = null;

            // Muestra el control de popup asociado para adjuntar un archivo.
            popupNuevo.Show();

            // Restablece los campos relacionados al archivo en el detalle.
            txtDescripcionArchivo.Text = "";
            lblErrorDetalle.Text = "";
        }


        /// <summary>
        /// Maneja el evento de clic en el botón de cancelar en el detalle.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Los argumentos del evento.</param>
        protected void btnCancelarDetalle_Click(object sender, EventArgs e)
        {
            // Oculta el control de popup asociado al detalle.
            popupNuevo.Hide();
        }


        /// <summary>
        /// Maneja el evento de clic en el botón "Aceptar" en el detalle del archivo.
        /// </summary>
        protected void BtnAceptarDetalle_Click(object sender, EventArgs e)
        {
            // Verificar que se haya ingresado la descripción del archivo
            if (string.IsNullOrEmpty(txtDescripcionArchivo.Text))
            {
                lblErrorDetalle.Text = "Debe ingresar la descripción del archivo";
                return;
            }

            // Verificar que se haya adjuntado un archivo
            if (Session["archivoPuente"] == null || Session["archivoPuente"].ToString() == string.Empty)
            {
                lblErrorDetalle.Text = "Debe adjuntar el archivo";
                return;
            }

            // Crear un nuevo objeto "archivos" con la descripción y la URL del archivo
            archivos ar = new archivos();
            ar.descripcion = txtDescripcionArchivo.Text;
            ar.url = Session["archivoPuente"].ToString();

            // Agregar el archivo a la lista de archivos cargados
            ArchivosCargados.Add(ar);

            // Ocultar el popup y actualizar la interfaz
            popupNuevo.Hide();
            renderArchivos();
        }


        /// <summary>
        /// Actualiza la interfaz gráfica con la lista de archivos cargados.
        /// </summary>
        private void renderArchivos()
        {
            // Configurar la fuente de datos y actualizar la interfaz
            grdArchivos.DataSource = ArchivosCargados;
            grdArchivos.DataBind();
            pnlGrillaArchivos.Update();
        }


        /// <summary>
        /// Maneja el evento de clic en el botón de eliminar archivo, eliminando el archivo correspondiente de la lista y actualizando la interfaz.
        /// </summary>
        /// <param name="sender">Objeto que generó el evento.</param>
        /// <param name="e">Argumentos del evento de clic.</param>
        protected void btnEliminarArchivo_Click(object sender, ImageClickEventArgs e)
        {
            // Obtener el botón que generó el evento
            ImageButton botonEliminar = (ImageButton)sender;

            // Recorrer la lista de archivos cargados
            for (int i = 0; i < ArchivosCargados.Count; i++)
            {
                // Verificar si la URL del archivo coincide con la del botón
                if (ArchivosCargados[i].url == botonEliminar.ValidationGroup)
                {
                    // Eliminar el archivo de la lista
                    ArchivosCargados.RemoveAt(i);
                    break;
                }
            }

            // Actualizar la interfaz con la lista de archivos modificada
            renderArchivos();
        }


        /// <summary>
        /// Maneja el evento de clic en el botón de objetar, redirigiendo a la página de objeciones.
        /// </summary>
        protected void btnObjetar_Click(object sender, EventArgs e)
        {
            // Construir la URL de redirección con los parámetros necesarios
            string urlRedireccion = $"frmObjetar.aspx?codN={Request.QueryString["codN"]}&codProceso={Request.QueryString["codProceso"]}";

            // Redirigir a la página de objeciones
            Response.Redirect(urlRedireccion);
        }


    }
}