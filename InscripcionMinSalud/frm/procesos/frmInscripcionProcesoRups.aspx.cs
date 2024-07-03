using NegocioInscripcionMinSalud;
using NegocioInscripcionMinSalud.data;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InscripcionMinSalud.frm.procesos
{
    public partial class frmInscripcionProcesoRups : System.Web.UI.Page
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

        /// <summary>
        /// Valida si hay un archivo cargado con nombre que comienza con "3-".
        /// </summary>
        /// <returns>
        /// <c>true</c> si hay al menos un archivo cargado con nombre que comienza con "3-"; 
        /// <c>false</c> si no hay archivos cargados con ese criterio.
        /// </returns>
        private bool ValidarArchivoCargado()
        {
            // Iterar a través de los archivos cargados
            foreach (var archivoCargado in ArchivosCargados)
            {
                // Obtener el nombre del archivo
                string nombreArchivo = System.IO.Path.GetFileName(archivoCargado.url);

                // Verificar si el nombre del archivo comienza con "3-"
                if (nombreArchivo.StartsWith("3-"))
                {
                    return true; // Se encontró al menos un archivo con el nombre adecuado
                }
            }

            return false; // No se encontraron archivos con el nombre deseado
        }


        private void cargarArchivos()
        {
            if (!IsPostBack)
            {
                Session["ss_rups_FileUpload3_filename"] = null;
                Session["ss_rups_FileUpload3_filepath"] = null;
                Session["ss_rups_FileUpload2_filename"] = null;
                Session["ss_rups_FileUpload2_filepath"] = null;
                Session["ss_rups_FileUpload1_filename"] = null;
                Session["ss_rups_FileUpload1_filepath"] = null;
            }

            if (Session["ss_rups_FileUpload3_filepath"] != null && Session["ss_rups_FileUpload3_filepath"].ToString() != string.Empty)
            {
                lnkArchivo3.InnerText = Session["ss_rups_FileUpload3_filename"].ToString();
                lnkArchivo3.HRef = Session["ss_rups_FileUpload3_filepath"].ToString();
            }

            if (Session["ss_rups_FileUpload2_filepath"] != null && Session["ss_rups_FileUpload2_filepath"].ToString() != string.Empty)
            {
                lnkArchivo2.InnerText = Session["ss_rups_FileUpload2_filename"].ToString();
                lnkArchivo2.HRef = Session["ss_rups_FileUpload2_filepath"].ToString();
            }
            if (Session["ss_rups_FileUpload1_filepath"] != null && Session["ss_rups_FileUpload1_filepath"].ToString() != string.Empty)
            {
                lnkArchivo1.InnerText = Session["ss_rups_FileUpload1_filename"].ToString();
                lnkArchivo1.HRef = Session["ss_rups_FileUpload1_filepath"].ToString();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.QueryString["codProceso"] == null || Request.QueryString["codProceso"].ToString().Trim() == string.Empty)
            {
                Response.Redirect("~/Default.aspx");
                return;
            }
            if (Session["SS_NOMBRE_USUARIO"] == null || Session["SS_NOMBRE_USUARIO"].ToString() == string.Empty)
            {
                if (Request["obs"] == null)
                {
                    btnGuardar.Visible = false;
                    btnGuardarContinuar.Visible = false;
                }
                else
                {
                    string parametros = Request.Url.PathAndQuery;
                    parametros = parametros.Substring(parametros.IndexOf("frm/"));
                    Response.Redirect("~/frm/seguridad/frmLogin.aspx?page=" + parametros.Replace("/", "@@").Replace("=", "**").Replace("&", "$$"));
                }
            }

            //cargamos la ifnormacio de los fileupload que se encuentran en session
            cargarArchivos();

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
                    if ((reg.COD_TIPO_JURIDICO == 1 || reg.COD_TIPO_JURIDICO == 4 || reg.COD_TIPO_JURIDICO == 5 ||
                        reg.COD_TIPO_JURIDICO == 6 || reg.COD_TIPO_JURIDICO == 7 || reg.COD_TIPO_JURIDICO == 12 ||
                        reg.COD_TIPO_JURIDICO == 8 || reg.COD_TIPO_JURIDICO == 9 || reg.COD_TIPO_JURIDICO == 10 ||
                        reg.COD_TIPO_JURIDICO == 28 || reg.COD_TIPO_JURIDICO == 29 || reg.COD_TIPO_JURIDICO == 30 ||
                        reg.COD_TIPO_JURIDICO == 31 || reg.COD_TIPO_JURIDICO == 26 || reg.COD_TIPO_JURIDICO == 11 ||
                        reg.COD_TIPO_JURIDICO == 27 || reg.COD_TIPO_JURIDICO == 13 || reg.COD_TIPO_JURIDICO == 14 ||
                        reg.COD_TIPO_JURIDICO == 15 || reg.COD_TIPO_JURIDICO == 16 || reg.COD_TIPO_JURIDICO == 17 ||
                        reg.COD_TIPO_JURIDICO == 19 || reg.COD_TIPO_JURIDICO == 20 || reg.COD_TIPO_JURIDICO == 18 ||
                        reg.COD_TIPO_JURIDICO == 21 || reg.COD_TIPO_JURIDICO == 22 || reg.COD_TIPO_JURIDICO == 23 ||
                        reg.COD_TIPO_JURIDICO == 24 || reg.COD_TIPO_JURIDICO == 25 || reg.COD_TIPO_JURIDICO == 39)
                        )
                    {
                        pnlMensajeNoNominador.Visible = false;
                        fldProcedimientoNuevo.Visible = false;
                        pnlFormulario.Visible = true;
                        fldEvidencia.Visible = false;
                        msjExperimentacion.Visible = false;
                        fldConflicto.Visible = false;
                        divGuardar.Visible = false;
                        Label51.Visible = false;
                        fldCups.Visible = false;
                        cmbCupsAjusteEstructura.Visible = false;
                        Fieldset1.Visible = false;
                        fldINVIMA.Visible = false;
                        fldFinalidadProcedimiento.Visible = false;
                        fldCarcteristicasNuevo.Visible = false;
                        fldVEntajas.Visible = false;
                        fldEfectividadClinica.Visible = false;
                        fldRecomendaciones.Visible = false;
                        fldAtencion.Visible = false;
                        fldRecursosAdicionales.Visible = false;
                        fldOtrasNominaciones.Visible = false;
                        fldOtrasNominaciones2.Visible = false;
                        fldCarcteristicasNuevo.Visible = false;
                        fldJustificacionNuevo.Visible = false;
                        fldJustificacion.Visible = false;
                        fldTipoProcedimiento.Visible = false;
                        fldDescripcion.Visible = false;
                        fldDescripcionNuevo.Visible = false;
                        fldCIE.Visible = false;
                        fldEfectividadClinica.Visible = false;
                        fldRiesgos.Visible = false;
                        fldEficacia.Visible = false;
                        fldImplementado.Visible = false;
                    }
                    else
                    {
                        pnlMensajeNoNominador.Visible = true;
                        pnlFormulario.Visible = false;
                    }
                    #endregion
                    #region ajustamos visibilidad de paneles de acuerdo al que va a nominar
                    if (reg.ES_PERSONA_NATURAL)
                    {

                        txtNombreNominador.Text = reg.NOMBRE.Trim() + " " + reg.APELLIDOS;
                        txtTipoAator.Text = "Persona natural";
                        txtIdentificacionNominador.Text = reg.DOCUMENTO;
                    }
                    else
                    {

                        txtNombreNominador.Text = reg.NOMBRE.Trim();
                        txtTipoAator.Text = reg.TIPO_JURIDICO.NOMBRE_TIPO_JURIDICO;
                        txtIdentificacionNominador.Text = reg.DOCUMENTO;
                    }
                    #endregion
                }

                if (Request.QueryString["codN"] != null && Request.QueryString["codN"] != string.Empty)
                {
                    pnlFormulario.Visible = true;

                    #region cargamosla informacion de la nominacion
                    var registro = obj.obtenerNOMINACION_PROCESORups(int.Parse(Request.QueryString["codN"]));
                    lblCodNominacionProceso.Text = registro.COD_NOMINACION_PROCESO_RUPS.ToString();
                    if (registro.COD_ESTADO_NOMINACION_RUPS == 2 || registro.COD_ESTADO_NOMINACION_RUPS == 3 || registro.COD_ESTADO_NOMINACION_RUPS > 4)//no deberia poder editar
                    {
                        #region deshabilitamos los controles




                        cmbAmbitoUso.Enabled = false;
                        cmbProcedimientoNacional.Enabled = false;
                        cmbTipoActorNomina.Enabled = false;
                        cmbTipoProcedimiento.Enabled = false;

                        rdAdicionalOtroNo.Enabled = false;
                        rdAdicionalOtroSi.Enabled = false;
                        rdAdultosMayoresNo.Enabled = false;
                        rdAdultosMayoresSi.Enabled = false;
                        rdAgenteBioAdicionalNo.Enabled = false;
                        rdAgenteBioAdicionalSi.Enabled = false;
                        rdAlgunaDiscapacidadNo.Enabled = false;
                        rdAlgunaDiscapacidadSi.Enabled = false;
                        rdAvala.Enabled = false;
                        rdAvalaNo.Enabled = false;
                        rdDesplazadosNo.Enabled = false;
                        rdDesplazadosSi.Enabled = false;
                        rdDispositivoAdicionalNo.Enabled = false;
                        rdDispositivoAdicionalSi.Enabled = false;
                        rdEmbarazoNo.Enabled = false;
                        rdEmbarazoSi.Enabled = false;
                        rdHurefanasNo.Enabled = false;
                        rdHurefanasSi.Enabled = false;
                        rdInfaciaSi.Enabled = false;
                        rdInfanciaNo.Enabled = false;
                        rdInVitroAdicionalNo.Enabled = false;
                        rdInVitroAdicionalSi.Enabled = false;
                        rdMedicamentoAdicionalNo.Enabled = false;
                        rdMedicamentoAdicionalSi.Enabled = false;
                        rdNombrePropio.Enabled = false;
                        rdNombreTercero.Enabled = false;
                        rdproductoBioAdicionalNo.Enabled = false;
                        rdproductoBioAdicionalSi.Enabled = false;
                        rdTerceroJuridico.Enabled = false;
                        rdTerceroNatural.Enabled = false;
                        rdViolenciaNo.Enabled = false;
                        rdViolenciaSi.Enabled = false;
                        txtConflicto.ReadOnly = true;
                        txtCupsAjuste.ReadOnly = true;
                        txtCupsAjuste2.ReadOnly = true;
                        txtCupsAjuste3.ReadOnly = true;
                        //txtCupsAjusteEstructura.ReadOnly = true;
                        //txtCupsCalificacion.ReadOnly = true;
                        txtCupsComparador1.ReadOnly = true;
                        txtCupsComparador2.ReadOnly = true;
                        txtCupsComparador3.ReadOnly = true;
                        txtCupsPopuestoCod.ReadOnly = true;
                        txtCupsPopuestoDes.ReadOnly = true;
                        txtDesccripcionDetallada.ReadOnly = true;
                        txtDisminucionComplicacion.ReadOnly = true;
                        txtEnfermedad.ReadOnly = true;
                        txtEnfermedad2.ReadOnly = true;
                        txtEnfermedad3.ReadOnly = true;
                        txtEstadoInvimaAgebio.ReadOnly = true;
                        txtEstadoInvimaAgeproducto.ReadOnly = true;
                        txtEstadoInvimaDispositivo.ReadOnly = true;
                        txtEstadoInvimaInvitro.ReadOnly = true;
                        //txtEstadoInvimaMedicamento.ReadOnly = true;
                        txtIdentificacionNominador.ReadOnly = true;
                        txtJustificacionNominacion.ReadOnly = true;
                        txtMejoraCalidadVida.ReadOnly = true;
                        txtNitTercero.ReadOnly = true;
                        txtNombreGPC.ReadOnly = true;
                        txtNombreNominador.ReadOnly = true;
                        txtNombreNominadortercero.ReadOnly = true;
                        // txtNombreProcedimiento.ReadOnly = true;
                        txtObservacionesAdicional.ReadOnly = true;
                        txtObservacionesValidacion.ReadOnly = true;
                        txtObservacionInteresSalud.ReadOnly = true;
                        txtOtroAdicional.ReadOnly = true;
                        txtRazonAvala.ReadOnly = true;
                        txtRecomendacionGPC.ReadOnly = true;
                        txtRecursoAdicionalAgebio.ReadOnly = true;
                        txtRecursoAdicionalAgeproducto.ReadOnly = true;
                        txtRecursoAdicionalDispositivo.ReadOnly = true;
                        txtRecursoAdicionalInvitro.ReadOnly = true;
                        txtRecursoAdicionalMedicamento.ReadOnly = true;
                        txtReduccionDiscapacidad.ReadOnly = true;
                        txtReduccionHospitalaria.ReadOnly = true;
                        txtReduccionMorbilidad.ReadOnly = true;
                        txtReduccionMortalidad.ReadOnly = true;
                        txtRegistroInvimaAgeBio.ReadOnly = true;
                        txtRegistroInvimaAgeproducto.ReadOnly = true;
                        txtRegistroInvimaDispositivo.ReadOnly = true;
                        txtRegistroInvimaInvitro.ReadOnly = true;
                        txtRegistroInvimaMedicamento.ReadOnly = true;
                        txtRelevanteAdultosMayores.ReadOnly = true;
                        txtRelevanteAlgunaDiscapacidad.ReadOnly = true;
                        txtRelevanteDesplazados.ReadOnly = true;
                        txtRelevanteEmbarazo.ReadOnly = true;
                        txtRelevanteHuerfanas.ReadOnly = true;
                        txtRelevanteInfancia.ReadOnly = true;
                        txtRelevanteViolencia.ReadOnly = true;
                        txtRiesgosPacienteDescripcion.ReadOnly = true;
                        txtTipoAator.ReadOnly = true;
                        txtVAidacionAgenteBiologico.ReadOnly = true;
                        txtVaidacionAvala.ReadOnly = true;
                        txtVaidacionOtro.ReadOnly = true;
                        txtVaildacionDispositivoAdicional.ReadOnly = true;
                        txtValidacionAmbitoUso.ReadOnly = true;
                        txtValidacionCie10.ReadOnly = true;
                        txtValidacionDismunicionComplicacion.ReadOnly = true;
                        txtValidacionEfectividadClinica.ReadOnly = true;
                        txtValidacionEstudiosSeguridad.ReadOnly = true;
                        txtValidacionFinalidadProcedimiento.ReadOnly = true;
                        txtValidacionGPC.ReadOnly = true;
                        txtValidacionInfoAdicional.ReadOnly = true;
                        txtValidacionInteresSaludPublica.ReadOnly = true;
                        txtValidacionInvitroAdicional.ReadOnly = true;
                        txtValidacionJustificacion.ReadOnly = true;
                        txtValidacionMedicamentoAdicional.ReadOnly = true;
                        txtValidacionMejoraCalidadVida.ReadOnly = true;
                        txtValidacionMejoraOtro.ReadOnly = true;
                        txtValidacionNombreProcedimiento.ReadOnly = true;
                        txtValidacionProdcutoBilogico.ReadOnly = true;
                        txtValidacionPropuestaAjuste.ReadOnly = true;
                        txtValidacionReduccionDiscapacidad.ReadOnly = true;
                        txtValidacionReduccionEstanciaHospital.ReadOnly = true;
                        txtValidacionReduccionMorbilidad.ReadOnly = true;
                        txtValidacionReduccionMortalidad.ReadOnly = true;
                        txtValidacionRiesgosAdversos.ReadOnly = true;
                        txtValidacionTerritorioNacional.ReadOnly = true;
                        txtValidacionTipoProcedimiento.ReadOnly = true;
                        txtValidacionValidador.ReadOnly = true;
                        txtValidacionVulnerabilidad.ReadOnly = true;
                        txtVentajaOtro.ReadOnly = true;

                        chkAdjuntaEvidenciaNo.Enabled = false;
                        chkAdjuntaEvidenciaSi.Enabled = false;
                        chkConflictoInteres.Enabled = false;
                        chkcosmetico.Enabled = false;
                        chkDiagnostico.Enabled = false;
                        chkDisminucionComplicacion.Enabled = false;
                        chkEfectividadClinicaNo.Enabled = false;
                        chkEfectividadClinicaSi.Enabled = false;
                        chkEficaciaClinicaNo.Enabled = false;
                        chkEficaciaClinicaSi.Enabled = false;
                        chkInteresSaludNo.Enabled = false;
                        chkInteresSaludSi.Enabled = false;
                        chkMejoraCalidadVida.Enabled = false;
                        chkNoConflictoInteres.Enabled = false;
                        chkPaliacion.Enabled = false;
                        chkPrevencionEnfermedad.Enabled = false;
                        chkPromocionSalud.Enabled = false;
                        chkReduccionDiscapacidad.Enabled = false;
                        chkAdjuntaEvidenciaNo.Enabled = false;
                        chkReduccionHospitalaria.Enabled = false;
                        chkReduccionMorbilidad.Enabled = false;
                        chkReduccionMortalidad.Enabled = false;
                        chkRehabilitacion.Enabled = false;
                        chkRiesgosPacienteNo.Enabled = false;
                        chkRiesgosPacienteSi.Enabled = false;
                        chkTratamiento.Enabled = false;
                        chkVentajaOtro.Enabled = false;
                        #endregion
                        btnGuardar.Visible = false;
                        btnGuardarContinuar.Visible = false;
                    }
                    var validacion = obj.obtenerValidacionNOMINACION_PROCESORups(int.Parse(Request.QueryString["codN"]));
                    if (validacion != null)
                    {
                        txtVAidacionAgenteBiologico.Text = validacion.VALIDACION_AGENTE_BIOLOGICO;
                        txtVaidacionAvala.Text = validacion.VALIDACION_AVALA;
                        txtVaidacionOtro.Text = validacion.VALIDACION_OTRO;
                        txtVaildacionDispositivoAdicional.Text = validacion.VALIDACION_DISPOSITIVO_ADICIONAL;
                        txtValidacionAmbitoUso.Text = validacion.VALIDACION_AMBITO_USO;
                        txtValidacionCie10.Text = validacion.VALIDACION_CIE10;
                        txtValidacionDismunicionComplicacion.Text = validacion.VALIDACION_REDUCION_COMPLICACION;
                        txtValidacionEfectividadClinica.Text = validacion.VALIDACION_EFECTIVIDAD_CLINICA;
                        txtValidacionEstudiosSeguridad.Text = validacion.VALIDACION_ESTUDIOS_SEGURIDAD;
                        txtValidacionFinalidadProcedimiento.Text = validacion.VALIDACION_FINALIDAD_PROCEDIMIENTO;
                        txtValidacionGPC.Text = validacion.VALIDACION_GPC;
                        txtValidacionInfoAdicional.Text = validacion.VALIDACION_INFO_ADICIONAL;
                        txtValidacionInteresSaludPublica.Text = validacion.VALIDACION_INTERES_SALUD_PUBLICA;
                        txtValidacionInvitroAdicional.Text = validacion.VALIDACION_INVITRO_ADICIONAL;
                        txtValidacionJustificacion.Text = validacion.VALIDACION_JUSTIFICACION;
                        txtValidacionMedicamentoAdicional.Text = validacion.VALIDACION_MEDICAMENTO_ADICIONAL;
                        txtValidacionMejoraCalidadVida.Text = validacion.VALIDACION_MEJORA_VIDA;
                        txtValidacionMejoraOtro.Text = validacion.VALIDACION_MEJORA_OTRO;
                        txtValidacionNombreProcedimiento.Text = validacion.VALIDACION_NOMBRE_PROCEDIMIENTO;
                        txtValidacionProdcutoBilogico.Text = validacion.VALIDACION_PRODUCTO_BIOLOGICO;
                        txtValidacionPropuestaAjuste.Text = validacion.VALIDACION_PROPUESTA_AJUSTE;
                        txtValidacionReduccionDiscapacidad.Text = validacion.VALIDACION_REDUCCION_DISCAPACIDAD;
                        txtValidacionReduccionEstanciaHospital.Text = validacion.VALIDACION_REDUCCION_ESTANCIA_HOS;
                        txtValidacionReduccionMorbilidad.Text = validacion.VALIDACION_REDUCCION_MORBILIDAD;
                        txtValidacionReduccionMortalidad.Text = validacion.VALIDACION_REDUCCION_MORTALIDAD;
                        txtValidacionRiesgosAdversos.Text = validacion.VALIDACION_RIESGOS_ADVERSOS;
                        txtValidacionTerritorioNacional.Text = validacion.VALIDACION_TERITORIO_NACIONAL;
                        txtValidacionTipoProcedimiento.Text = validacion.VALIDACION_TIPO_PROCEDIMIENTO;
                        txtValidacionValidador.Text = validacion.VALIDACION_VALIDADOR;
                        txtValidacionVulnerabilidad.Text = validacion.VALIDACION_VULNERABILIDAD;
                        txtObservacionesValidacion.Text = validacion.OBSERVACIONES_VALIDACION;
                    }


                    pnlNominador.Visible = true;
                    if (registro.REGISTRO.ES_PERSONA_NATURAL)
                    {

                        txtNombreNominador.Text = registro.REGISTRO.NOMBRE.Trim() + " " + registro.REGISTRO.APELLIDOS;
                        txtTipoAator.Text = "Persona natural";
                    }
                    else
                    {

                        txtNombreNominador.Text = registro.REGISTRO.NOMBRE.Trim();
                        txtTipoAator.Text = registro.REGISTRO.TIPO_JURIDICO.NOMBRE_TIPO_JURIDICO;

                    }

                    if (registro.ES_NOMBRE_PROPIO.HasValue)
                    {
                        rdNombrePropio.Checked = registro.ES_NOMBRE_PROPIO.Value;

                        rdNombreTercero.Checked = !registro.ES_NOMBRE_PROPIO.Value;
                    }
                    if (registro.PROPONENTE_NATURAL.HasValue)
                    {
                        rdTerceroJuridico.Checked = registro.PROPONENTE_NATURAL.Value;
                        rdTerceroNatural.Checked = !registro.PROPONENTE_NATURAL.Value;
                    }
                    if (registro.COD_TIPO_JURIDICO_PROPONENTE.HasValue)
                        cmbTipoActorNomina.SelectedValue = registro.COD_TIPO_JURIDICO_PROPONENTE.Value.ToString();

                    txtNombreNominadortercero.Text = registro.NOMBRE_PROPONENTE;
                    txtNitTercero.Text = registro.DOCUMENTO_PROPONENTE;

                    txtIdentificacionNominador.Text = registro.REGISTRO.DOCUMENTO;
                    txtNombreNominador.Text = registro.REGISTRO.NOMBRE;

                    // txtNombreProcedimiento.Text = registro.NOMBRE_PROCEDIMIENTO;
                    cmbTipoProcedimiento.SelectedValue = registro.COD_TIPO_PROCEDIMIENTO.ToString();
                    cmbAmbitoUso.SelectedValue = registro.COD_AMBITO_PROCEDIMIENTO.ToString();
                    txtDesccripcionDetallada.Text = registro.DESCRIPCION;
                    txtEnfermedad.Text = registro.CIE10;
                    txtEnfermedad2.Text = registro.CIE102;
                    txtEnfermedad3.Text = registro.CIE103;
                    if (registro.ES_PROMOCION_SALUD.HasValue)
                        chkPromocionSalud.Checked = registro.ES_PROMOCION_SALUD.Value;

                    if (registro.ES_PREVENCION_ENFERMEDAD.HasValue)
                        chkPrevencionEnfermedad.Checked = registro.ES_PREVENCION_ENFERMEDAD.Value;

                    if (registro.ES_DIAGNOSTICO.HasValue)
                        chkDiagnostico.Checked = registro.ES_DIAGNOSTICO.Value;


                    if (registro.ES_TRATAMIENTO.HasValue)
                        chkTratamiento.Checked = registro.ES_TRATAMIENTO.Value;

                    if (registro.ES_REHABILITACION.HasValue)
                        chkRehabilitacion.Checked = registro.ES_REHABILITACION.Value;

                    if (registro.ES_PALIACION.HasValue)
                        chkPaliacion.Checked = registro.ES_PALIACION.Value;

                    if (registro.ES_COSMETICO.HasValue)
                        chkcosmetico.Checked = registro.ES_COSMETICO.Value;

                    txtCupsAjuste.Text = registro.CUPS_MODIFICAR1;
                    txtCupsAjuste2.Text = registro.CUPS_MODIFICAR2;
                    txtCupsAjuste3.Text = registro.CUPS_MODIFICAR3;
                    //txtCupsAjusteEstructura.Text = registro.ESTRUCTURA_CUPS;
                    txtCupsComparador1.Text = registro.CODIGOCUPS1;
                    txtCupsComparador2.Text = registro.CODIGOCUPS2;
                    txtCupsComparador3.Text = registro.CODIGOCUPS3;

                    //txtCupsCalificacion = registro.CALIFICACION_AJUSTE;
                    txtCupsPopuestoCod.Text = registro.CODIGO_PROPUESTO;
                    txtCupsPopuestoDes.Text = registro.DESCRIPCION_PROPUESTO;

                    txtJustificacionNominacion.Text = registro.JUSTIFICACION;
                    if (registro.SE_REALIZA_ACTUALMENTE_COLOMBIA.HasValue)
                    {
                        if (registro.SE_REALIZA_ACTUALMENTE_COLOMBIA.Value)
                        {
                            cmbProcedimientoNacional.SelectedValue = "1";
                        }
                        else
                        {
                            cmbProcedimientoNacional.SelectedValue = "0";
                        }
                    }
                    if (registro.ES_REDUCCION_MORTALIDAD.HasValue)
                        chkReduccionMortalidad.Checked = registro.ES_REDUCCION_MORTALIDAD.Value;
                    txtReduccionMortalidad.Text = registro.DESCCRIPCION_REDUCCION_MORTALIDAD;


                    if (registro.ES_REDUCCION_MORBILIDAD.HasValue)
                        chkReduccionMorbilidad.Checked = registro.ES_REDUCCION_MORBILIDAD.Value;
                    txtReduccionMorbilidad.Text = registro.DESCRIPCION_REDUCCION_MORBILIDAD;


                    if (registro.ES_REDUCCION_DISCAPCIDAD.HasValue)
                        chkReduccionDiscapacidad.Checked = registro.ES_REDUCCION_DISCAPCIDAD.Value;
                    txtReduccionDiscapacidad.Text = registro.DESCRIPCION_REDUCCION_DISCAPACIDAD;


                    if (registro.ES_REDUCCION_INSTANCIA.HasValue)
                        chkReduccionHospitalaria.Checked = registro.ES_REDUCCION_INSTANCIA.Value;
                    txtReduccionHospitalaria.Text = registro.DESCRIPCION_REDUCCION_INSTANCIA;

                    if (registro.ES_DISMINUCION_COMPLICACION.HasValue)
                        chkDisminucionComplicacion.Checked = registro.ES_DISMINUCION_COMPLICACION.Value;
                    txtDisminucionComplicacion.Text = registro.DESCRIPCION_DISMINUCION_COMPLICACION;


                    if (registro.ES_MEJORA_VIDA.HasValue)
                        chkMejoraCalidadVida.Checked = registro.ES_MEJORA_VIDA.Value;
                    txtMejoraCalidadVida.Text = registro.DESCRIPCION_MEJORA_VIDA;

                    if (registro.ES_OTRO.HasValue)
                        chkVentajaOtro.Checked = registro.ES_OTRO.Value;
                    txtVentajaOtro.Text = registro.DESCRIPCION_OTRO;

                    if (registro.CUENTA_ESTUDIOS_EFECTIVIDAD.HasValue)
                    {
                        chkEfectividadClinicaSi.Checked = registro.CUENTA_ESTUDIOS_EFECTIVIDAD.Value;
                        chkEfectividadClinicaNo.Checked = !registro.CUENTA_ESTUDIOS_EFECTIVIDAD.Value;
                    }
                    string archivo = registro.ARCHIVO_EFECTIVIDAD;
                    if (archivo.Contains("files"))
                    {
                        archivo = archivo.Substring(archivo.IndexOf("files"));
                        archivo = "~/" + archivo;
                    }


                    lnkArchivo1.HRef = archivo;
                    archivo = registro.ARCHIVO_SEGURIDAD;
                    if (archivo.Contains("files"))
                    {
                        archivo = archivo.Substring(archivo.IndexOf("files"));
                        archivo = "~/" + archivo;
                    }
                    lnkArchivo2.HRef = archivo;
                    if (registro.CUENTA_ESTUDIOS_SEGURIDAD.HasValue)
                    {
                        chkEficaciaClinicaSi.Checked = registro.CUENTA_ESTUDIOS_SEGURIDAD.Value;
                        chkEficaciaClinicaNo.Checked = !registro.CUENTA_ESTUDIOS_SEGURIDAD.Value;
                    }

                    if (registro.TIENE_EFECTOS_ADVERSOS.HasValue)
                    {
                        chkRiesgosPacienteSi.Checked = registro.TIENE_EFECTOS_ADVERSOS.Value;
                        chkRiesgosPacienteNo.Checked = !registro.TIENE_EFECTOS_ADVERSOS.Value;
                    }
                    txtRiesgosPacienteDescripcion.Text = registro.DESCRIPCION_EFECTOS_ADVERSOS;
                    if (registro.ES__INTERES_SALUD.HasValue)
                    {
                        chkInteresSaludSi.Checked = registro.ES__INTERES_SALUD.Value;
                        chkInteresSaludNo.Checked = !registro.ES__INTERES_SALUD.Value;
                    }
                    txtObservacionInteresSalud.Text = registro.DESCRIPCION_INTERES_SALUD;

                    txtNombreGPC.Text = registro.NOMBRE_GPC;
                    txtRecomendacionGPC.Text = registro.RECOMENDACION_GPC;

                    if (registro.ADJUNTA_ADICIONAL.HasValue)
                    {
                        chkAdjuntaEvidenciaSi.Checked = registro.ADJUNTA_ADICIONAL.Value;
                        chkAdjuntaEvidenciaNo.Checked = !registro.ADJUNTA_ADICIONAL.Value;
                    }

                    txtObservacionesAdicional.Text = registro.OBSERVACIONES_ADICIONAL;

                    archivo = registro.ARCHIVO_ADICIONAL;
                    if (archivo.Contains("files"))
                    {
                        archivo = archivo.Substring(archivo.IndexOf("files"));
                        archivo = "~/" + archivo;
                    }
                    lnkArchivo3.HRef = archivo;

                    if (registro.RECURSO_ADICIONAL_MEDICAMENTO.HasValue)
                    {
                        rdMedicamentoAdicionalSi.Checked = registro.RECURSO_ADICIONAL_MEDICAMENTO.Value;
                        rdMedicamentoAdicionalNo.Checked = !registro.RECURSO_ADICIONAL_MEDICAMENTO.Value;
                    }
                    txtRecursoAdicionalMedicamento.Text = registro.NOMBRE_RECURSO_MEDICAMENTO;
                    //txtEstadoInvimaMedicamento.Text = registro.ESTADO_RECURSO_MEDICAMENTO;
                    txtRegistroInvimaMedicamento.Text = registro.REGISTRO_INVIMA_RECURSO_MEDICAMENTO;

                    if (registro.RECURSO_ADICIONAL_DISPOSITIVO.HasValue)
                    {
                        rdDispositivoAdicionalSi.Checked = registro.RECURSO_ADICIONAL_DISPOSITIVO.Value;
                        rdDispositivoAdicionalNo.Checked = !registro.RECURSO_ADICIONAL_DISPOSITIVO.Value;
                    }
                    txtRecursoAdicionalDispositivo.Text = registro.NOMBRE_RECURSO_DISPOSITIVO;
                    txtEstadoInvimaDispositivo.Text = registro.ESTADO_RECURSO_DISPOSITIVO;
                    txtRegistroInvimaDispositivo.Text = registro.REGISTRO_INVIMA_DISPOSITIVO;


                    if (registro.RECURSO_ADICIONAL_INVITRO.HasValue)
                    {
                        rdInVitroAdicionalSi.Checked = registro.RECURSO_ADICIONAL_INVITRO.Value;
                        rdInVitroAdicionalNo.Checked = !registro.RECURSO_ADICIONAL_INVITRO.Value;
                    }
                    txtRecursoAdicionalInvitro.Text = registro.NOMBRE_RECURSO_ADICIONAL_INVITRO;
                    txtEstadoInvimaInvitro.Text = registro.ESTADO_RECURSO_ADICIONAL_INVITRO;
                    txtRegistroInvimaInvitro.Text = registro.REGISTRO_INVIMA_INVITRO;


                    if (registro.RECURSO_ADICIONAL_AGEBIOLOGICO.HasValue)
                    {
                        rdAgenteBioAdicionalSi.Checked = registro.RECURSO_ADICIONAL_AGEBIOLOGICO.Value;
                        rdAgenteBioAdicionalNo.Checked = !registro.RECURSO_ADICIONAL_AGEBIOLOGICO.Value;
                    }
                    txtRecursoAdicionalAgebio.Text = registro.NOMBRE_RECURSO_ADICIONAL_AGEBIOLOGICO;
                    txtEstadoInvimaAgebio.Text = registro.ESTADO_RECURSO_ADICIONAL_AGEBIOLOGICO;
                    txtRegistroInvimaAgeBio.Text = registro.REGISTRO_INVIMA_AGEBIOLOGICO;


                    if (registro.RECURSO_ADICIONAL_BIOLOGICO.HasValue)
                    {
                        rdproductoBioAdicionalSi.Checked = registro.RECURSO_ADICIONAL_BIOLOGICO.Value;
                        rdproductoBioAdicionalNo.Checked = !registro.RECURSO_ADICIONAL_BIOLOGICO.Value;
                    }
                    txtRecursoAdicionalAgeproducto.Text = registro.NOMBRE_RECURSO_ADICIONAL_BIOLOGICO;
                    txtEstadoInvimaAgeproducto.Text = registro.ESTADO_RECURSO_ADICIONAL_BIOLOGICO;
                    txtRegistroInvimaAgeproducto.Text = registro.REGISTRO_INVIMA_BIOLOGICO;


                    if (registro.RECURSO_ADICIONAL_OTRO.HasValue)
                    {
                        rdAdicionalOtroSi.Checked = registro.RECURSO_ADICIONAL_OTRO.Value;
                        rdAdicionalOtroNo.Checked = !registro.RECURSO_ADICIONAL_OTRO.Value;
                    }
                    txtOtroAdicional.Text = registro.NOMBRE_RECURSO_ADICIONAL_BIOLOGICO;

                    if (registro.VULNERABLE_INFANCIA.HasValue)
                    {
                        rdInfaciaSi.Checked = registro.VULNERABLE_INFANCIA.Value;
                        rdInfanciaNo.Checked = !registro.VULNERABLE_INFANCIA.Value;
                    }
                    txtRelevanteInfancia.Text = registro.OBS_VULNERABLE_INFANCIA;


                    if (registro.VULNERABLE_EMBARAZO.HasValue)
                    {
                        rdEmbarazoSi.Checked = registro.VULNERABLE_EMBARAZO.Value;
                        rdEmbarazoNo.Checked = !registro.VULNERABLE_EMBARAZO.Value;
                    }
                    txtRelevanteEmbarazo.Text = registro.OBS_VULNERABLE_EMBARAZO;


                    if (registro.VULNERABLE_DESPLAZADOS.HasValue)
                    {
                        rdDesplazadosSi.Checked = registro.VULNERABLE_DESPLAZADOS.Value;
                        rdDesplazadosNo.Checked = !registro.VULNERABLE_DESPLAZADOS.Value;
                    }
                    txtRelevanteDesplazados.Text = registro.OBS_VULNERABLE_DESPLAZADOS;


                    if (registro.VULNERABLE_ARMADO.HasValue)
                    {
                        rdViolenciaSi.Checked = registro.VULNERABLE_ARMADO.Value;
                        rdViolenciaNo.Checked = !registro.VULNERABLE_ARMADO.Value;
                    }
                    txtRelevanteViolencia.Text = registro.OBS_VULNERABLE_ARMADO;


                    if (registro.VULNERABLE_ADULTOS.HasValue)
                    {
                        rdAdultosMayoresSi.Checked = registro.VULNERABLE_ADULTOS.Value;
                        rdAdultosMayoresNo.Checked = !registro.VULNERABLE_ADULTOS.Value;
                    }
                    txtRelevanteAdultosMayores.Text = registro.OBS_VULNERABLE_ADULTOS;
                    //---

                    if (registro.VULNERABLE_DISCAPACIDAD.HasValue)
                    {
                        rdAlgunaDiscapacidadSi.Checked = registro.VULNERABLE_DISCAPACIDAD.Value;
                        rdAlgunaDiscapacidadNo.Checked = !registro.VULNERABLE_DISCAPACIDAD.Value;
                    }
                    txtRelevanteAlgunaDiscapacidad.Text = registro.OBS_VULNERABLE_DISPACAIDAD;


                    if (registro.VULNERABLE_HUERFANOS.HasValue)
                    {
                        rdHurefanasSi.Checked = registro.VULNERABLE_HUERFANOS.Value;
                        rdHurefanasNo.Checked = !registro.VULNERABLE_HUERFANOS.Value;
                    }
                    txtRelevanteHuerfanas.Text = registro.OBS_VULNERABLE_HUERFANOS;

                    if (registro.CONFLICTO_INTERES.HasValue)
                    {
                        chkConflictoInteres.Checked = registro.CONFLICTO_INTERES.Value;
                        chkNoConflictoInteres.Checked = !registro.CONFLICTO_INTERES.Value;
                    }

                    txtConflicto.Text = registro.OBS_CONFLICTO_INTERES;
                    if (registro.AVALA.HasValue)
                    {
                        rdAvala.Checked = registro.AVALA.Value;
                        rdAvalaNo.Checked = !registro.AVALA.Value;
                    }

                    txtRazonAvala.Text = registro.OBS_AVALA;

                    System.Configuration.AppSettingsReader ar = new System.Configuration.AppSettingsReader();
                    string url = ar.GetValue("urlLocal", typeof(string)).ToString();
                    if (lnkArchivo1.HRef != string.Empty)
                    {
                        lnkArchivo1.HRef = url + lnkArchivo1.HRef.Replace("~", "").Replace(@"\", @"/");
                        lnkArchivo1.InnerHtml = "Archivo cargado";
                    }
                    if (lnkArchivo2.HRef != string.Empty)
                    {
                        lnkArchivo2.HRef = url + lnkArchivo2.HRef.Replace("~", "").Replace(@"\", @"/");
                        lnkArchivo2.InnerHtml = "Archivo cargado";
                    }
                    if (lnkArchivo3.HRef != string.Empty)
                    {
                        lnkArchivo3.HRef = url + lnkArchivo3.HRef.Replace("~", "").Replace(@"\", @"/");
                        lnkArchivo3.InnerHtml = "Archivo cargado";
                    }
                    #endregion

                    if (Request["obs"] != null)
                    {
                        #region habilitamos o dehsbilitamos los paneles de validacion
                        pnlMensajeNoNominador.Visible = false;
                        if (txtVAidacionAgenteBiologico.Text.Trim() != string.Empty) pnlVAidacionAgenteBiologico.Visible = true;
                        if (txtVaidacionAvala.Text.Trim() != string.Empty) pnlVaidacionAvala.Visible = true;
                        if (txtVaidacionOtro.Text.Trim() != string.Empty) pnlVaidacionOtro.Visible = true;
                        if (txtVaildacionDispositivoAdicional.Text.Trim() != string.Empty) pnlVaildacionDispositivoAdicional.Visible = true;
                        if (txtValidacionAmbitoUso.Text.Trim() != string.Empty) pnlValidacionAmbitoUso.Visible = true;
                        if (txtValidacionCie10.Text.Trim() != string.Empty) pnlValidacionCie10.Visible = true;
                        if (txtValidacionDismunicionComplicacion.Text.Trim() != string.Empty) pnlValidacionDismunicionComplicacion.Visible = true;
                        if (txtValidacionEfectividadClinica.Text.Trim() != string.Empty) pnlValidacionEfectividadClinica.Visible = true;
                        if (txtValidacionEstudiosSeguridad.Text.Trim() != string.Empty) pnlValidacionEstudiosSeguridad.Visible = true;
                        if (txtValidacionFinalidadProcedimiento.Text.Trim() != string.Empty) pnlValidacionFinalidadProcedimiento.Visible = true;
                        if (txtValidacionGPC.Text.Trim() != string.Empty) pnlValidacionGPC.Visible = true;
                        if (txtValidacionInfoAdicional.Text.Trim() != string.Empty) pnlValidacionInfoAdicional.Visible = true;
                        if (txtValidacionInteresSaludPublica.Text.Trim() != string.Empty) pnlValidacionInteresSaludPublica.Visible = true;
                        if (txtValidacionInvitroAdicional.Text.Trim() != string.Empty) pnlValidacionInvitroAdicional.Visible = true;
                        if (txtValidacionJustificacion.Text.Trim() != string.Empty) pnlValidacionJustificacion.Visible = true;
                        if (txtValidacionMedicamentoAdicional.Text.Trim() != string.Empty) pnlValidacionMedicamentoAdicional.Visible = true;
                        if (txtValidacionMejoraCalidadVida.Text.Trim() != string.Empty) pnlValidacionMejoraCalidadVida.Visible = true;
                        if (txtValidacionMejoraOtro.Text.Trim() != string.Empty) pnlValidacionMejoraOtro.Visible = true;
                        if (txtValidacionNombreProcedimiento.Text.Trim() != string.Empty) pnlValidacionNombreProcedimiento.Visible = true;
                        if (txtValidacionProdcutoBilogico.Text.Trim() != string.Empty) pnlValidacionProdcutoBilogico.Visible = true;
                        if (txtValidacionPropuestaAjuste.Text.Trim() != string.Empty) pnlValidacionPropuestaAjuste.Visible = true;
                        if (txtValidacionReduccionDiscapacidad.Text.Trim() != string.Empty) pnlValidacionReduccionDiscapacidad.Visible = true;
                        if (txtValidacionReduccionEstanciaHospital.Text.Trim() != string.Empty) pnlValidacionReduccionEstanciaHospital.Visible = true;
                        if (txtValidacionReduccionMorbilidad.Text.Trim() != string.Empty) pnlValidacionReduccionMorbilidad.Visible = true;
                        if (txtValidacionReduccionMortalidad.Text.Trim() != string.Empty) pnlValidacionReduccionMortalidad.Visible = true;
                        if (txtValidacionRiesgosAdversos.Text.Trim() != string.Empty) pnlValidacionRiesgosAdversos.Visible = true;
                        if (txtValidacionTerritorioNacional.Text.Trim() != string.Empty) pnlValidacionTerritorioNacional.Visible = true;
                        if (txtValidacionTipoProcedimiento.Text.Trim() != string.Empty) pnlValidacionTipoProcedimiento.Visible = true;
                        if (txtValidacionValidador.Text.Trim() != string.Empty) pnlValidacionValidador.Visible = true;
                        if (txtValidacionVulnerabilidad.Text.Trim() != string.Empty) pnlValidacionVulnerabilidad.Visible = true;
                        if (txtObservacionesValidacion.Text.Trim() != string.Empty) pnlObservacionesValidacion.Visible = true;
                        #endregion
                    }

                    string script = "$(document).ready(function () { $('[id*=btnGuardarContinuar]').click(); });";
                    ClientScript.RegisterStartupScript(this.GetType(), "load", script, true);

                }



            }

        }

        /// <summary>
        /// Manejador de eventos para el clic del botón "Guardar y Continuar".
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        protected void btnGuardarContinuar_Click(object sender, EventArgs e)
        {
            // Verificar si el usuario está autenticado (la sesión existe)
            if (Session["SS_NOMBRE_USUARIO"] == null || Session["SS_NOMBRE_USUARIO"].ToString() == string.Empty)
            {
                // Mostrar un mensaje si la sesión no es válida
                LblValidacionCampos.Text = "La sesión ha finalizado. Por favor, inicie sesión nuevamente.";
                return;
            }

            // Verificar si se ha seleccionado una Propuesta de Ajuste en el ComboBox
            if (cmbCupsCalificacion.SelectedValue != "-1")
            {
                // Validar y procesar según la opción seleccionada en el ComboBox
                if (cmbCupsCalificacion.SelectedValue == "Incluir Procedimiento NUEVO")
                {
                    // Se validan las opciones para incluir un procedimiento nuevo
                    if (validarInclusion())
                    {
                        divGuardar.Visible = false;
                        // Guardar la inclusión y enviar la solicitud
                        if (guardarInclusion())
                        {
                            enviar();
                        }
                        else
                        {
                            // Mostrar mensaje de error si se produce un problema al guardar la inclusión
                            LblValidacionCampos.Text = "Se produjo un error al enviar su solicitud. Por favor, comuníquese al correo lavilar@minsalud.gov.co para recibir soporte.";
                            btnGuardarContinuar.Visible = false;
                            btnGuardar.Visible = false;
                        }
                    }
                }
                else
                {
                    // Se validan las opciones diferentes a la inclusión
                    if (validar())
                    {
                        // Guardar y enviar la solicitud
                        if (guardar())
                        {
                            enviar();
                        }
                        else
                        {
                            // Mostrar mensaje de error si se produce un problema al guardar
                            LblValidacionCampos.Text = "Se produjo un error al enviar su solicitud. Por favor, comuníquese al correo lavilar@minsalud.gov.co para recibir soporte.";
                            btnGuardarContinuar.Visible = false;
                            btnGuardar.Visible = false;
                        }
                    }
                }
            }
            else
            {
                // Mostrar mensaje si no se ha seleccionado la Propuesta de Ajuste
                LblValidacionCampos.Text += "Debe seleccionar la Propuesta de Ajuste.";
                cmbCupsCalificacion.CssClass = "form-control errormin";
            }
        }

        /// <summary>
        /// Manejador de eventos para el clic del botón "Guardar".
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            // Verificar si el usuario está autenticado (la sesión existe)
            if (Session["SS_NOMBRE_USUARIO"] == null || Session["SS_NOMBRE_USUARIO"].ToString() == string.Empty)
            {
                // Mostrar un mensaje si la sesión no es válida
                LblValidacionCampos.Text = "La sesión ha finalizado. Por favor, inicie sesión nuevamente.";
                return;
            }

            // Llamar al método guardar() para guardar o procesar datos
            guardar();
        }

        /// <summary>
        /// Método para validar nominaciones diferentes a la inclusión en la nominación RUPS.
        /// </summary>
        /// <returns>Devuelve true si la validación es exitosa, de lo contrario, devuelve false.</returns>

        private bool validar()
        {
            bool error = false;
            LblValidacionCampos.Text = "";
            LblValidacionCampos.Text += "Verifique los Siguientes Campos: ";

            pnlNombrePropio.Attributes["class"] = "";
            if (!rdNombrePropio.Checked && !rdNombreTercero.Checked)
            {
                error = true;
                LblValidacionCampos.Text += "Debe seleccionar si la nominación es en nombre propio o en nombre de tercero.  ";
                pnlNombrePropio.Attributes["class"] = "errormin";
            }

            if (rdNombreTercero.Checked)
            {
                if (!rdTerceroNatural.Checked
                    && !rdTerceroJuridico.Checked)
                {
                    error = true;
                    LblValidacionCampos.Text += "Debe seleccionar si el proponente es natural o jurídico  ";
                }

                cmbTipoActorNomina.CssClass = "form-control";
                if (cmbTipoActorNomina.SelectedValue == null || cmbTipoActorNomina.SelectedValue.Trim() == string.Empty)
                {
                    error = true;
                    LblValidacionCampos.Text += "Tipo de actor que nomina es obligatorio, ";
                    cmbTipoActorNomina.CssClass = "form-control errormin";
                }

                txtNombreNominadortercero.CssClass = "form-control";
                if (txtNombreNominadortercero.Text == string.Empty)
                {
                    error = true;
                    LblValidacionCampos.Text += "Nombre persona natural  o de la entidad nominadora es obligatorio, ";
                    txtNombreNominadortercero.CssClass = "form-control errormin";
                }

                txtNitTercero.CssClass = "form-control";
                if (txtNitTercero.Text == string.Empty)
                {
                    error = true;
                    LblValidacionCampos.Text += "Documento de identificación del nominador es obligatorio, ";
                    txtNitTercero.CssClass = "form-control errormin";
                }

            }


            #region nombre tecnologia
            //txtNombreProcedimiento.CssClass = "form-control";
            //if (txtNombreProcedimiento.Text == "")
            //{
            //    error = true;
            //    LblValidacionCampos.Text += "Nombre de la tecnologia, ";
            //    txtNombreProcedimiento.CssClass = "form-control errormin";
            //}

            cmbTipoProcedimiento.CssClass = "form-control";
            if (cmbTipoProcedimiento.SelectedValue == null || cmbTipoProcedimiento.SelectedValue.Trim() == string.Empty || cmbTipoProcedimiento.SelectedValue.Trim() == "-1")
            {
                error = true;
                LblValidacionCampos.Text += "Tipo de procedimiento, ";
                cmbTipoProcedimiento.CssClass = "form-control errormin";
            }
            cmbAmbitoUso.CssClass = "form-control";
            if (cmbAmbitoUso.SelectedValue == null || cmbAmbitoUso.SelectedValue.Trim() == string.Empty || cmbAmbitoUso.SelectedValue.Trim() == "-1")
            {
                error = true;
                LblValidacionCampos.Text += "Ámbito de uso del procedimiento, ";
                cmbAmbitoUso.CssClass = "form-control errormin";
            }

            txtDesccripcionDetallada.CssClass = "form-control";
            if (txtDesccripcionDetallada.Text == "")
            {
                error = true;
                LblValidacionCampos.Text += "Descripción detallada del procedimiento, ";
                txtDesccripcionDetallada.CssClass = "form-control errormin";
            }

            txtEnfermedad.CssClass = "form-control";
            if (txtEnfermedad.Text == "")
            {
                error = true;
                LblValidacionCampos.Text += "CIE-10, ";
                txtEnfermedad.CssClass = "form-control errormin";
            }


            #endregion


            fldFinalidadProcedimiento.Attributes["class"] = "";
            if (!chkPromocionSalud.Checked
                && !chkPrevencionEnfermedad.Checked
                && !chkTratamiento.Checked
                && !chkDiagnostico.Checked
                && !chkRehabilitacion.Checked
                && !chkPaliacion.Checked
                && !chkcosmetico.Checked)
            {
                error = true;
                LblValidacionCampos.Text += "Finalidad del procedimiento.  ";
                fldFinalidadProcedimiento.Attributes["class"] = "errormin";
            }

            #region propuesta de ajuste
            //txtCupsAjuste.CssClass = "form-control";
            //if (txtCupsAjuste.Text == "")
            //{
            //    error = true;
            //    LblValidacionCampos.Text += "procedimiento de la CUPS a modificar, ";
            //    txtCupsAjuste.CssClass = "form-control errormin";
            //}


            //txtCupsAjusteEstructura.CssClass = "form-control";
            //if (txtCupsAjusteEstructura.Text == "")
            //{
            //    error = true;
            //    LblValidacionCampos.Text += "Estructura en la CUPS del ajuste, ";
            //    txtCupsAjusteEstructura.CssClass = "form-control errormin";
            //}


            //txtCupsComparador1.CssClass = "form-control";
            //if (txtCupsComparador1.Text == "")
            //{
            //    error = true;
            //    LblValidacionCampos.Text += "Código CUPS del procedimiento comparador o sustituto, ";
            //    txtCupsComparador1.CssClass = "form-control errormin";
            //}

            //txtCupsPopuestoCod.CssClass = "form-control";
            //if (txtCupsPopuestoCod.Text == "")
            //{
            //    error = true;
            //    LblValidacionCampos.Text += "Código propuestos para CUPS, ";
            //    txtCupsPopuestoCod.CssClass = "form-control errormin";
            //}

            //txtCupsPopuestoDes.CssClass = "form-control";
            //if (txtCupsPopuestoDes.Text == "")
            //{
            //    error = true;
            //    LblValidacionCampos.Text += "Descripción propuestos para CUPS, ";
            //    txtCupsPopuestoDes.CssClass = "form-control errormin";
            //}

            txtJustificacionNominacion.CssClass = "form-control";
            if (txtJustificacionNominacion.Text == "")
            {
                error = true;
                LblValidacionCampos.Text += "Justificación de la nominación, ";
                txtJustificacionNominacion.CssClass = "form-control errormin";
            }

            cmbProcedimientoNacional.CssClass = "form-control";
            if (cmbProcedimientoNacional.SelectedValue == null || cmbProcedimientoNacional.SelectedValue.Trim() == string.Empty || cmbProcedimientoNacional.SelectedValue.Trim() == "-1")
            {
                error = true;
                LblValidacionCampos.Text += "Se realiza este procedimiento en el territorio nacional actualmente, ";
                cmbProcedimientoNacional.CssClass = "form-control errormin";
            }
            #endregion
            #region ventajas
            fldVEntajas.Attributes["class"] = "";
            if (!chkReduccionMortalidad.Checked
                && !chkReduccionMorbilidad.Checked
                && !chkReduccionDiscapacidad.Checked
                && !chkReduccionHospitalaria.Checked
                && !chkDisminucionComplicacion.Checked
                && !chkMejoraCalidadVida.Checked
                && !chkVentajaOtro.Checked)
            {
                error = true;
                LblValidacionCampos.Text += "Resultados y ventajas clínicas con el uso del procedimiento.  ";
                fldVEntajas.Attributes["class"] = "errormin";
            }
            txtReduccionMortalidad.CssClass = "form-control";
            if (chkReduccionMortalidad.Checked && txtReduccionMortalidad.Text.Trim() == string.Empty)
            {
                error = true;
                LblValidacionCampos.Text += "Reducción mortalidad, ";
                txtReduccionMortalidad.CssClass = "form-control errormin";
            }

            txtReduccionMorbilidad.CssClass = "form-control";
            if (chkReduccionMorbilidad.Checked && txtReduccionMorbilidad.Text.Trim() == string.Empty)
            {
                error = true;
                LblValidacionCampos.Text += "Reducción morbilidad, ";
                txtReduccionMorbilidad.CssClass = "form-control errormin";
            }
            txtReduccionDiscapacidad.CssClass = "form-control";
            if (chkReduccionDiscapacidad.Checked && txtReduccionDiscapacidad.Text.Trim() == string.Empty)
            {
                error = true;
                LblValidacionCampos.Text += "Reducción discapacidad, ";
                txtReduccionDiscapacidad.CssClass = "form-control errormin";
            }
            txtReduccionHospitalaria.CssClass = "form-control";
            if (chkReduccionHospitalaria.Checked && txtReduccionHospitalaria.Text.Trim() == string.Empty)
            {
                error = true;
                LblValidacionCampos.Text += "Reducción hospitalaria, ";
                txtReduccionHospitalaria.CssClass = "form-control errormin";
            }
            txtDisminucionComplicacion.CssClass = "form-control";
            if (chkDisminucionComplicacion.Checked && txtDisminucionComplicacion.Text.Trim() == string.Empty)
            {
                error = true;
                LblValidacionCampos.Text += "Disminución complicación, ";
                txtDisminucionComplicacion.CssClass = "form-control errormin";
            }
            txtMejoraCalidadVida.CssClass = "form-control";
            if (chkMejoraCalidadVida.Checked && txtMejoraCalidadVida.Text.Trim() == string.Empty)
            {
                error = true;
                LblValidacionCampos.Text += "Mejora calidad de vida, ";
                txtMejoraCalidadVida.CssClass = "form-control errormin";
            }
            txtVentajaOtro.CssClass = "form-control";
            if (chkVentajaOtro.Checked && txtVentajaOtro.Text.Trim() == string.Empty)
            {
                error = true;
                LblValidacionCampos.Text += "Descripción en Resultados y ventajas clínicas con el uso del procedimiento, ";
                txtVentajaOtro.CssClass = "form-control errormin";
            }

            #endregion

            if (!chkEfectividadClinicaSi.Checked
                && !chkEfectividadClinicaNo.Checked)
            {
                error = true;
                LblValidacionCampos.Text += "El procedimiento cuenta con estudios de efectividad Clínica.  ";
            }

            if (!chkEficaciaClinicaSi.Checked
                && !chkEficaciaClinicaNo.Checked)
            {
                error = true;
                LblValidacionCampos.Text += "El procedimiento cuenta con estudios de seguridad y eficacia Clínica.  ";
            }

            if (!chkRiesgosPacienteSi.Checked
                && !chkRiesgosPacienteNo.Checked)
            {
                error = true;
                LblValidacionCampos.Text += "El procedimiento tiene riesgos y efectos adversos para el páciente.  ";
            }
            txtRiesgosPacienteDescripcion.CssClass = "form-control";
            if (chkRiesgosPacienteSi.Checked && txtRiesgosPacienteDescripcion.Text.Trim() == string.Empty)
            {
                error = true;
                LblValidacionCampos.Text += "Descripción riesgos y efectos adversos, ";
                txtRiesgosPacienteDescripcion.CssClass = "form-control errormin";
            }
            if (!chkInteresSaludSi.Checked && !chkInteresSaludNo.Checked)
            {
                error = true;
                LblValidacionCampos.Text += "El procedimiento es de interés en Salud Pública.  ";
            }

            txtNombreGPC.CssClass = "form-control";
            if (txtNombreGPC.Text.Trim() == string.Empty)
            {
                error = true;
                LblValidacionCampos.Text += "Nombre de la GPC, ";
                txtNombreGPC.CssClass = "form-control errormin";
            }
            else if (txtNombreGPC.Text.Length > 3000)
            {
                error = true;
                LblValidacionCampos.Text += "Nombre de la GPC excede 3000 carácteres, ";
                txtRecomendacionGPC.CssClass = "form-control errormin";
            }

            txtRecomendacionGPC.CssClass = "form-control";
            if (txtRecomendacionGPC.Text.Trim() == string.Empty)
            {
                error = true;
                LblValidacionCampos.Text += "Recomendación de la GPC, ";
                txtRecomendacionGPC.CssClass = "form-control errormin";
            }
            else if (txtRecomendacionGPC.Text.Length > 3000)
            {
                error = true;
                LblValidacionCampos.Text += "Recomendación de la GPC excede 3000 carácteres, ";
                txtRecomendacionGPC.CssClass = "form-control errormin";
            }

            if (!rdExperimentacionSI.Checked)
            {
                if (!chkAdjuntaEvidenciaSi.Checked
                    && !chkAdjuntaEvidenciaNo.Checked)
                {
                    error = true;
                    LblValidacionCampos.Text += "Adjunta Evidencia,.  ";
                }
            }
            else
            {
                error = true;
                LblValidacionCampos.Text += "Los procedimientos en fase de experimentación no pueden ser nominados para la actualización de la CUPS,.  ";
            }

            if (!rdMedicamentoAdicionalSi.Checked
               && !rdMedicamentoAdicionalNo.Checked)
            {
                error = true;
                LblValidacionCampos.Text += "Medicamento adicional,.  ";
            }


            txtRecursoAdicionalMedicamento.CssClass = "form-control";
            if (rdMedicamentoAdicionalSi.Checked && txtRecursoAdicionalMedicamento.Text.Trim() == string.Empty)
            {
                error = true;
                LblValidacionCampos.Text += "Nombre del recurso adicional que requiere el procedimiento, ";
                txtRecursoAdicionalMedicamento.CssClass = "form-control errormin";
            }
            //txtEstadoInvimaMedicamento.CssClass = "form-control";
            if (rdMedicamentoAdicionalSi.Checked && cmbEstadoInvimaMedicamento.SelectedValue.ToString() == string.Empty)
            {
                error = true;
                LblValidacionCampos.Text += "Estado del Registro Sanitario Invima, ";
                // txtEstadoInvimaMedicamento.CssClass = "form-control errormin";
            }
            txtRegistroInvimaMedicamento.CssClass = "form-control";
            if (rdMedicamentoAdicionalSi.Checked && txtRegistroInvimaMedicamento.Text.Trim() == string.Empty)
            {
                error = true;
                LblValidacionCampos.Text += "Registro Sanitario Invima, ";
                txtRegistroInvimaMedicamento.CssClass = "form-control errormin";
            }
            //

            txtRecursoAdicionalDispositivo.CssClass = "form-control";
            if (rdDispositivoAdicionalSi.Checked && txtRecursoAdicionalDispositivo.Text.Trim() == string.Empty)
            {
                error = true;
                LblValidacionCampos.Text += "Nombre del recurso adicional que requiere el procedimiento, ";
                txtRecursoAdicionalDispositivo.CssClass = "form-control errormin";
            }
            //txtEstadoInvimaMedicamento.CssClass = "form-control";
            if (rdDispositivoAdicionalSi.Checked && txtEstadoInvimaDispositivo.Text.Trim() == string.Empty)
            {
                error = true;
                LblValidacionCampos.Text += "Estado del Registro Sanitario Invima, ";
                txtEstadoInvimaDispositivo.CssClass = "form-control errormin";
            }
            txtRegistroInvimaMedicamento.CssClass = "form-control";
            if (rdDispositivoAdicionalSi.Checked && txtRegistroInvimaDispositivo.Text.Trim() == string.Empty)
            {
                error = true;
                LblValidacionCampos.Text += "Registro Sanitario Invima, ";
                txtRegistroInvimaDispositivo.CssClass = "form-control errormin";
            }


            txtRecursoAdicionalInvitro.CssClass = "form-control";
            if (rdInVitroAdicionalSi.Checked && txtRecursoAdicionalInvitro.Text.Trim() == string.Empty)
            {
                error = true;
                LblValidacionCampos.Text += "Nombre del recurso adicional que requiere el procedimiento, ";
                txtRecursoAdicionalInvitro.CssClass = "form-control errormin";
            }
            txtEstadoInvimaInvitro.CssClass = "form-control";
            if (rdInVitroAdicionalSi.Checked && txtEstadoInvimaInvitro.Text.Trim() == string.Empty)
            {
                error = true;
                LblValidacionCampos.Text += "Estado del Registro Sanitario Invima, ";
                txtEstadoInvimaInvitro.CssClass = "form-control errormin";
            }
            txtRegistroInvimaInvitro.CssClass = "form-control";
            if (rdInVitroAdicionalSi.Checked && txtRegistroInvimaInvitro.Text.Trim() == string.Empty)
            {
                error = true;
                LblValidacionCampos.Text += "Registro Sanitario Invima, ";
                txtRegistroInvimaInvitro.CssClass = "form-control errormin";
            }
            //

            txtRecursoAdicionalAgebio.CssClass = "form-control";
            if (rdAgenteBioAdicionalSi.Checked && txtRecursoAdicionalAgebio.Text.Trim() == string.Empty)
            {
                error = true;
                LblValidacionCampos.Text += "Nombre del recurso adicional que requiere el procedimiento, ";
                txtRecursoAdicionalAgebio.CssClass = "form-control errormin";
            }
            txtEstadoInvimaAgebio.CssClass = "form-control";
            if (rdAgenteBioAdicionalSi.Checked && txtEstadoInvimaAgebio.Text.Trim() == string.Empty)
            {
                error = true;
                LblValidacionCampos.Text += "Estado del Registro Sanitario Invima, ";
                txtEstadoInvimaAgebio.CssClass = "form-control errormin";
            }
            txtRegistroInvimaAgeBio.CssClass = "form-control";
            if (rdAgenteBioAdicionalSi.Checked && txtRegistroInvimaAgeBio.Text.Trim() == string.Empty)
            {
                error = true;
                LblValidacionCampos.Text += "Registro Sanitario Invima, ";
                txtRegistroInvimaAgeBio.CssClass = "form-control errormin";
            }

            //

            txtRecursoAdicionalAgeproducto.CssClass = "form-control";
            if (rdproductoBioAdicionalSi.Checked && txtRecursoAdicionalAgeproducto.Text.Trim() == string.Empty)
            {
                error = true;
                LblValidacionCampos.Text += "Nombre del recurso adicional que requiere el procedimiento, ";
                txtRecursoAdicionalAgeproducto.CssClass = "form-control errormin";
            }
            txtEstadoInvimaAgeproducto.CssClass = "form-control";
            if (rdproductoBioAdicionalSi.Checked && txtEstadoInvimaAgeproducto.Text.Trim() == string.Empty)
            {
                error = true;
                LblValidacionCampos.Text += "Estado del Registro Sanitario Invima, ";
                txtEstadoInvimaAgeproducto.CssClass = "form-control errormin";
            }
            txtRegistroInvimaAgeproducto.CssClass = "form-control";
            if (rdproductoBioAdicionalSi.Checked && txtRegistroInvimaAgeproducto.Text.Trim() == string.Empty)
            {
                error = true;
                LblValidacionCampos.Text += "Registro Sanitario Invima, ";
                txtRegistroInvimaAgeproducto.CssClass = "form-control errormin";
            }
            //--
            txtOtroAdicional.CssClass = "form-control";
            if (rdAdicionalOtroSi.Checked && txtOtroAdicional.Text.Trim() == string.Empty)
            {
                error = true;
                LblValidacionCampos.Text += "Especifique, ";
                txtOtroAdicional.CssClass = "form-control errormin";
            }

            if (!rdInfaciaSi.Checked && !rdInfanciaNo.Checked)
            {
                error = true;
                LblValidacionCampos.Text += "Infancia y adolecencia,  ";
            }
            if (!rdEmbarazoSi.Checked && !rdEmbarazoNo.Checked)
            {
                error = true;
                LblValidacionCampos.Text += "Mujeres en estado de embarazo,  ";
            }
            if (!rdDesplazadosSi.Checked && !rdDesplazadosNo.Checked)
            {
                error = true;
                LblValidacionCampos.Text += "Desplazados,  ";
            }
            if (!rdViolenciaSi.Checked && !rdViolenciaNo.Checked)
            {
                error = true;
                LblValidacionCampos.Text += "Victimas de violencia y del conflicto armado,  ";
            }
            if (!rdAdultosMayoresSi.Checked && !rdAdultosMayoresNo.Checked)
            {
                error = true;
                LblValidacionCampos.Text += "Adultos mayores,  ";
            }
            if (!rdAlgunaDiscapacidadSi.Checked && !rdAlgunaDiscapacidadNo.Checked)
            {
                error = true;
                LblValidacionCampos.Text += "Personas con algún tipo de discapacidad,  ";
            }
            if (!rdHurefanasSi.Checked && !rdHurefanasNo.Checked)
            {
                error = true;
                LblValidacionCampos.Text += "Personas con enfermedades huérfanas,  ";
            }


            if (chkConflictoInteres.Checked && txtConflicto.Text.Trim() == string.Empty)
            {
                txtConflicto.CssClass = "";
                txtConflicto.Attributes.Remove("placeholder");
                LblValidacionCampos.Text += "Relacione el conflicto de interes,  ";
                txtConflicto.Attributes.Add("placeholder", "Debe relacionar el conflicto de interes");
                txtConflicto.CssClass = "form-control errormin";
            }

            if (!chkConflictoInteres.Checked && !chkNoConflictoInteres.Checked)
            {
                error = true;
                LblValidacionCampos.Text += "Debe seleccionar si tiene conflicto de intereses,  ";
            }

            if (!rdAvala.Checked && !rdAvalaNo.Checked)
            {
                error = true;
                LblValidacionCampos.Text += "La agremiación o asociación científica avala la nominación,  ";
            }
            txtRazonAvala.CssClass = "form-control";
            if (rdAvalaNo.Checked && txtRazonAvala.Text.Trim() == string.Empty)
            {
                error = true;
                LblValidacionCampos.Text += "indique la razón, ";
                txtRazonAvala.CssClass = "form-control errormin";
            }

            return !error;
        }

        /// <summary>
        /// Método para validar la inclusión de información en la nominación RUPS.
        /// </summary>
        /// <returns>Devuelve true si la validación es exitosa, de lo contrario, devuelve false.</returns>

        private bool validarInclusion()
        {
            bool error = false;
            LblValidacionCampos.Text = "";
            LblValidacionCampos.Text += "Verifique los Siguientes Campos: ";

            pnlNombrePropio.Attributes["class"] = "";
            if (!rdNombrePropio.Checked && !rdNombreTercero.Checked)
            {
                error = true;
                LblValidacionCampos.Text += "Debe seleccionar si la nominación es en nombre propio o en nombre de tercero.  ";
                pnlNombrePropio.Attributes["class"] = "errormin";
            }

            if (rdNombreTercero.Checked)
            {
                if (!rdTerceroNatural.Checked
                    && !rdTerceroJuridico.Checked)
                {
                    error = true;
                    LblValidacionCampos.Text += "Debe seleccionar si el proponente es natural o jurídico  ";
                }

                cmbTipoActorNomina.CssClass = "form-control";
                if (cmbTipoActorNomina.SelectedValue == null || cmbTipoActorNomina.SelectedValue.Trim() == string.Empty)
                {
                    error = true;
                    LblValidacionCampos.Text += "Tipo de actor que nomina es obligatorio, ";
                    cmbTipoActorNomina.CssClass = "form-control errormin";
                }

                txtNombreNominadortercero.CssClass = "form-control";
                if (txtNombreNominadortercero.Text == string.Empty)
                {
                    error = true;
                    LblValidacionCampos.Text += "Nombre persona natural  o de la entidad nominadora es obligatorio, ";
                    txtNombreNominadortercero.CssClass = "form-control errormin";
                }

                txtNitTercero.CssClass = "form-control";
                if (txtNitTercero.Text == string.Empty)
                {
                    error = true;
                    LblValidacionCampos.Text += "Documento de identificación del nominador es obligatorio, ";
                    txtNitTercero.CssClass = "form-control errormin";
                }

            }

            cmbCupsCalificacion.CssClass = "form-control";
            if (cmbCupsCalificacion.SelectedValue == "-1" || cmbCupsCalificacion.SelectedValue.Trim() == string.Empty)
            {
                error = true;
                LblValidacionCampos.Text += "Tipo de ajuste es obligatorio, ";
                cmbCupsCalificacion.CssClass = "form-control errormin";
            }

            if (!rdExperimentacionSI.Checked && !rdExperimentacionNO.Checked)
            {
                error = true;
                LblValidacionCampos.Text += "Debe seleccionar si la nominación esta en fase de experimentación.  ";
            }

            cmbCupsAjusteEstructura.CssClass = "form-control";
            if (cmbCupsAjusteEstructura.SelectedValue == "-1" || cmbCupsAjusteEstructura.SelectedValue.Trim() == string.Empty)
            {
                error = true;
                LblValidacionCampos.Text += "Estructura en la CUPS de la nominación, ";
                cmbCupsAjusteEstructura.CssClass = "form-control errormin";
            }

            txtCupsPopuestoCod.CssClass = "form-control";
            if (txtCupsPopuestoCod.Text == "")
            {
                error = true;
                LblValidacionCampos.Text += "Código propuesto para CUPS , ";
                txtCupsPopuestoCod.CssClass = "form-control errormin";
            }

            txtCupsPopuestoDes.CssClass = "form-control";
            if (txtCupsPopuestoDes.Text == "")
            {
                error = true;
                LblValidacionCampos.Text += "Descripción propuesto para CUPS , ";
                txtCupsPopuestoDes.CssClass = "form-control errormin";
            }

            txtJustificacionNuevo.CssClass = "form-control";
            if (txtJustificacionNuevo.Text == "")
            {
                error = true;
                LblValidacionCampos.Text += "Justificación de la nominación, ";
                txtJustificacionNominacion.CssClass = "form-control errormin";
            }

            txtDescProcNuevo.CssClass = "form-control";
            if (txtDescProcNuevo.Text == "")
            {
                error = true;
                LblValidacionCampos.Text += "Descripción detallada del procedimiento, ";
                txtDescProcNuevo.CssClass = "form-control errormin";
            }

            txtDecCriterioNuevo.CssClass = "form-control";
            if (txtDecCriterioNuevo.Text == "")
            {
                error = true;
                LblValidacionCampos.Text += "Describir la formación académica requerida para la ejecución del procedimiento, ";
                txtDecCriterioNuevo.CssClass = "form-control errormin";
            }


            fldFinalidadProcedimiento.Attributes["class"] = "";
            if (!chkPromocionSalud.Checked
                && !chkPrevencionEnfermedad.Checked
                && !chkTratamiento.Checked
                && !chkDiagnostico.Checked
                && !chkRehabilitacion.Checked
                && !chkPaliacion.Checked
                && !chkcosmetico.Checked)
            {
                error = true;
                LblValidacionCampos.Text += "Finalidad del procedimiento.  ";
                fldFinalidadProcedimiento.Attributes["class"] = "errormin";
            }

            cmbTipoProcedimiento.CssClass = "form-control";
            if (cmbTipoProcedimiento.SelectedValue == "-1" || cmbTipoProcedimiento.SelectedValue.Trim() == string.Empty)
            {
                error = true;
                LblValidacionCampos.Text += "Tipo de procedimiento, ";
                cmbTipoProcedimiento.CssClass = "form-control errormin";
            }

            cmbAmbitoUso.CssClass = "form-control";
            if (cmbAmbitoUso.SelectedValue == null || cmbAmbitoUso.SelectedValue.Trim() == string.Empty || cmbAmbitoUso.SelectedValue.Trim() == "-1")
            {
                error = true;
                LblValidacionCampos.Text += "Ámbito de uso del procedimiento, ";
                cmbAmbitoUso.CssClass = "form-control errormin";
            }

            txtEnfermedad.CssClass = "form-control";
            if (txtEnfermedad.Text == "")
            {
                error = true;
                LblValidacionCampos.Text += "CIE-10, ";
                txtEnfermedad.CssClass = "form-control errormin";
            }

            txtDesGrupoPoblacionalNuevo.CssClass = "form-control";
            if (txtDesGrupoPoblacionalNuevo.Text == "")
            {
                error = true;
                LblValidacionCampos.Text += "Describir el grupo poblacional, ";
                txtDesGrupoPoblacionalNuevo.CssClass = "form-control errormin";
            }

            txtNombreGPC.CssClass = "form-control";
            if (txtNombreGPC.Text.Trim() == string.Empty)
            {
                error = true;
                LblValidacionCampos.Text += "Nombre de la GPC, ";
                txtNombreGPC.CssClass = "form-control errormin";
            }
            else if (txtNombreGPC.Text.Length > 3000)
            {
                error = true;
                LblValidacionCampos.Text += "Nombre de la GPC excede 3000 carácteres, ";
                txtRecomendacionGPC.CssClass = "form-control errormin";
            }

            txtRecomendacionGPC.CssClass = "form-control";
            if (txtRecomendacionGPC.Text.Trim() == string.Empty)
            {
                error = true;
                LblValidacionCampos.Text += "Recomendación de la GPC,";
                txtRecomendacionGPC.CssClass = "form-control errormin";
            }
            else if (txtRecomendacionGPC.Text.Length > 3000) 
            {
                error = true;
                LblValidacionCampos.Text += "Recomendación de la GPC excede 3000 carácteres, ";
                txtRecomendacionGPC.CssClass = "form-control errormin";
            }
            


            txtNumeroPacientes.CssClass = "form-control";
            if (txtNumeroPacientes.Text == "")
            {
                error = true;
                LblValidacionCampos.Text += "Número de pacientes que se beneficiaran con el procedimiento, ";
                txtNumeroPacientes.CssClass = "form-control errormin";
            }


            if (!rdRemplazaSI.Checked && !rdRemplazaNO.Checked)
            {
                error = true;
                LblValidacionCampos.Text += "Debe seleccionar si el procedimiento remplaza alguno de los procedimientos";
            }
            else
            {
                if (rdRemplazaSI.Checked)
                {
                    txtRemplaza.CssClass = "form-control";
                    if (txtRemplaza.Text == "")
                    {
                        error = true;
                        LblValidacionCampos.Text += "¿Cuál procedimiento remplaza?, ";
                        txtRemplaza.CssClass = "form-control errormin";
                    }
                }
            }



            if (!rdRiesgoSI.Checked && !rdRiesgoNo.Checked)
            {
                error = true;
                LblValidacionCampos.Text += "¿El procedimiento tiene riesgos?";
            }
            else
            {
                if (rdRiesgoSI.Checked)
                {
                    txtRiesgo.CssClass = "form-control";
                    if (txtRiesgo.Text == "")
                    {
                        error = true;
                        LblValidacionCampos.Text += "Describa las principales complicaciones del procedimiento, ";
                        txtRiesgo.CssClass = "form-control errormin";
                    }
                }
            }

            txtResultados.CssClass = "form-control";
            if (txtResultados.Text == "")
            {
                error = true;
                LblValidacionCampos.Text += "Describa los principales resultados y ventajas, ";
                txtResultados.CssClass = "form-control errormin";
            }

            txtOtrasIntervenciones.CssClass = "form-control";
            if (txtOtrasIntervenciones.Text == "")
            {
                error = true;
                LblValidacionCampos.Text += "¿Qué otras intervenciones/acciones de rutina se realizan durante el procedimiento?, ";
                txtOtrasIntervenciones.CssClass = "form-control errormin";
            }

            txtTecnologiasEjecucion.CssClass = "form-control";
            if (txtTecnologiasEjecucion.Text == "")
            {
                error = true;
                LblValidacionCampos.Text += "Describir la(s) tecnología(s) requerida(s) para la ejecución del procedimiento, ";
                txtTecnologiasEjecucion.CssClass = "form-control errormin";
            }



            if (chkDispositivoMedicamento.Checked) { 

                if (!rdINVIMA1SI.Checked && !rdINVIMA1NO.Checked)
                {
                    error = true;
                    LblValidacionCampos.Text += "Dispositivo médico o un medicamento 1";
                }
                else
                {
                    if (rdINVIMA1SI.Checked)
                    {
                        txtINVIMA1.CssClass = "form-control";
                        if (txtINVIMA1.Text == "")
                        {
                            error = true;
                            LblValidacionCampos.Text += "Nombre del recurso adicional que requiere el procedimiento dispositivo 1, ";
                            txtINVIMA1.CssClass = "form-control errormin";
                        }

                        txtNumINVIMA1.CssClass = "form-control";
                        if (txtNumINVIMA1.Text == "")
                        {
                            error = true;
                            LblValidacionCampos.Text += ">No. del Registro Sanitario Invima dispositivo 1, ";
                            txtNumINVIMA1.CssClass = "form-control errormin";
                        }

                        cmbEstadoINVIMA1.CssClass = "form-control";
                        if (cmbEstadoINVIMA1.SelectedValue == null || cmbEstadoINVIMA1.SelectedValue.Trim() == string.Empty || cmbEstadoINVIMA1.SelectedValue.Trim() == "-1")
                        {
                            error = true;
                            LblValidacionCampos.Text += "Estado Registro Sanitario Invima dispositivo 1, ";
                            cmbEstadoINVIMA1.CssClass = "form-control errormin";
                        }

                    }

                }

                if (rdINVIMA2SI.Checked)
                {
                    txtINVIMA2.CssClass = "form-control";
                    if (txtINVIMA2.Text == "")
                    {
                        error = true;
                        LblValidacionCampos.Text += "Nombre del recurso adicional que requiere el procedimiento dispositivo 2, ";
                        txtINVIMA2.CssClass = "form-control errormin";
                    }

                    txtNumINVIMA2.CssClass = "form-control";
                    if (txtNumINVIMA2.Text == "")
                    {
                        error = true;
                        LblValidacionCampos.Text += ">No. del Registro Sanitario Invima dispositivo 2, ";
                        txtNumINVIMA2.CssClass = "form-control errormin";
                    }

                    cmbEstadoINVIMA2.CssClass = "form-control";
                    if (cmbEstadoINVIMA2.SelectedValue == null || cmbEstadoINVIMA2.SelectedValue.Trim() == string.Empty || cmbEstadoINVIMA2.SelectedValue.Trim() == "-2")
                    {
                        error = true;
                        LblValidacionCampos.Text += "Estado Registro Sanitario Invima dispositivo 2, ";
                        cmbEstadoINVIMA2.CssClass = "form-control errormin";
                    }

                }

                if (rdINVIMA3SI.Checked)
                {
                    txtINVIMA3.CssClass = "form-control";
                    if (txtINVIMA3.Text == "")
                    {
                        error = true;
                        LblValidacionCampos.Text += "Nombre del recurso adicional que requiere el procedimiento dispositivo 3, ";
                        txtINVIMA3.CssClass = "form-control errormin";
                    }

                    txtNumINVIMA3.CssClass = "form-control";
                    if (txtNumINVIMA3.Text == "")
                    {
                        error = true;
                        LblValidacionCampos.Text += ">No. del Registro Sanitario Invima dispositivo 3, ";
                        txtNumINVIMA3.CssClass = "form-control errormin";
                    }

                    cmbEstadoINVIMA3.CssClass = "form-control";
                    if (cmbEstadoINVIMA3.SelectedValue == null || cmbEstadoINVIMA3.SelectedValue.Trim() == string.Empty || cmbEstadoINVIMA3.SelectedValue.Trim() == "-3")
                    {
                        error = true;
                        LblValidacionCampos.Text += "Estado Registro Sanitario Invima dispositivo 3, ";
                        cmbEstadoINVIMA3.CssClass = "form-control errormin";
                    }
                }

            }
         

            if (!chkEfectividadClinicaSi.Checked && !chkEfectividadClinicaNo.Checked)
            {
                error = true;
                LblValidacionCampos.Text += "¿El procedimiento cuenta con estudios de efectividad Clínica?, ";
            }

            if (!chkEficaciaClinicaSi.Checked && !chkEficaciaClinicaNo.Checked)
            {
                error = true;
                LblValidacionCampos.Text += "¿El procedimiento cuenta con estudios de seguridad y eficacia Clínica?, ";
            }


            if (!rdEnTerritorioSI.Checked && !rdEnTerritorioNO.Checked)
            {
                error = true;
                LblValidacionCampos.Text += "Se cuenta con la capacidad para ser implementado de manera segura, eficaz y con calidad en el Territorio Nacional?";
            }
            else
            {
                if (rdEnTerritorioSI.Checked)
                {
                    txtEnTerritorio.CssClass = "form-control";
                    if (txtEnTerritorio.Text == "")
                    {
                        error = true;
                        LblValidacionCampos.Text += "Justifique si se cuenta con la capacidad para ser implementado, ";
                        txtEnTerritorio.CssClass = "form-control errormin";
                    }
                }
            }

            if (!rdRealizadoTerritorioSI.Checked && !rdRealizadoTerritorioNO.Checked)
            {
                error = true;
                LblValidacionCampos.Text += "¿El procedimiento ya se está realizando en el territorio nacional?";
            }
            else
            {
                if (rdRealizadoTerritorioSI.Checked)
                {
                    txtRealizadoTerritorio.CssClass = "form-control";
                    if (txtRealizadoTerritorio.Text == "")
                    {
                        error = true;
                        LblValidacionCampos.Text += "¿En qué instituciones y ciudades conoce   que se realiza actualmente el procedimiento?, ";
                        txtRealizadoTerritorio.CssClass = "form-control errormin";
                    }

                    txtCUPSRealizacion.CssClass = "form-control";
                    if (txtCUPSRealizacion.Text == "")
                    {
                        error = true;
                        LblValidacionCampos.Text += "¿Con qué código CUPS actualmente se está prescribiendo el procedimiento?, ";
                        txtCUPSRealizacion.CssClass = "form-control errormin";
                    }

                    txtYearRealizacion.CssClass = "form-control";
                    if (txtYearRealizacion.Text == "")
                    {
                        error = true;
                        LblValidacionCampos.Text += "¿Desde qué año se realiza en Colombia?, ";
                        txtYearRealizacion.CssClass = "form-control errormin";
                    }
                }
            }

            if (!rdOtrosSistemasCodificacionSI.Checked && !rdOtrosSistemasCodificacionNO.Checked)
            {
                error = true;
                LblValidacionCampos.Text += "El procedimiento ha sido incluido en otros sistemas de codificación?";
            }
            else
            {
                if (rdOtrosSistemasCodificacionSI.Checked)
                {
                    txtOtrosSistemasCodificacion.CssClass = "form-control";
                    if (txtOtrosSistemasCodificacion.Text == "")
                    {
                        error = true;
                        LblValidacionCampos.Text += "Justifique si ha sido incluido en otros sistemas de codificación, ";
                        txtOtrosSistemasCodificacion.CssClass = "form-control errormin";
                    }
                }
            }

            if (rdExperimentacionSI.Checked)
            {

                LblValidacionCampos.Text += "Los procedimientos en fase de experimentación no pueden ser nominados para la actualización de la CUPS,.  ";
            }
            else
            {
                if (!chkAdjuntaEvidenciaSi.Checked
                   && !chkAdjuntaEvidenciaNo.Checked)
                {
                    error = true;
                    LblValidacionCampos.Text += "Adjunta Evidencia,.  ";
                }
            }

            if (chkConflictoInteres.Checked && txtConflicto.Text.Trim() == string.Empty)
            {
                txtConflicto.CssClass = "";
                txtConflicto.Attributes.Remove("placeholder");
                LblValidacionCampos.Text += "Relacione el conflicto de interes,  ";
                txtConflicto.Attributes.Add("placeholder", "Debe relacionar el conflicto de interes");
                txtConflicto.CssClass = "form-control errormin";
            }

            if (!chkConflictoInteres.Checked && !chkNoConflictoInteres.Checked)
            {
                error = true;
                LblValidacionCampos.Text += "Debe seleccionar si tiene conflicto de intereses,  ";
            }

            if (!rdAvala.Checked && !rdAvalaNo.Checked)
            {
                error = true;
                LblValidacionCampos.Text += "La agremiación o asociación científica avala la nominación,  ";
            }
            txtRazonAvala.CssClass = "form-control";
            if (rdAvalaNo.Checked && txtRazonAvala.Text.Trim() == string.Empty)
            {
                error = true;
                LblValidacionCampos.Text += "indique la razón, ";
                txtRazonAvala.CssClass = "form-control errormin";
            }

            return !error;
        }

        /// <summary>
        /// Método para enviar la nominación RUPS y notificar al usuario por correo electrónico.
        /// </summary>
        private void enviar()
        {
            // Crea una instancia de la clase de negocio.
            clsNegocio cls = new clsNegocio();

            // Obtiene la nominación RUPS.
            var obj = cls.obtenerNOMINACION_PROCESORups(int.Parse(lblCodNominacionProceso.Text));

            // Verifica el estado de la nominación.
            if (obj.COD_ESTADO_NOMINACION_RUPS <= 2)
            {
                // Cambia el estado de la nominación y envía un correo de confirmación.
                cls.enviarNominacion(int.Parse(lblCodNominacionProceso.Text), 2);
                Session["msgtitulo"] = "Gracias por completar su nominación";
                Session["msgmsg"] = @"Muchas gracias por su participación en la " + obj.PROCESO.NOMBRE_PROCESO + @" Queremos informarle que su nominación ha sido recibida.
            <br>
            <br>
            Le comunicaremos oportunamente cualquier tipo de novedad con respecto a su nominación.
            <br>
            <br>";

                // Crea una instancia de la clase de utilidades web.
                clsWebUtils email = new clsWebUtils();

                // Obtiene el asunto y el cuerpo del mensaje de sesión.
                string asunto = Session["msgtitulo"].ToString();
                string cuerpo = Session["msgmsg"].ToString();

                // Envía el correo electrónico al usuario.
                email.enviarEmail(asunto, cuerpo, Session["SS_CORREO"].ToString());
            }

            // Redirige a la página de mensaje.
            Response.Redirect("~/frm/logica/frmMensajeIframe.aspx");
        }


        /// <summary>
        /// Método para guardar la información de nominación RUPS en la base de datos.
        /// </summary>
        /// <returns>True si la información se guardó correctamente, False en caso contrario.</returns>
        private bool guardar()
        {
            // Deshabilita y oculta el botón 'btnGuardarContinuar'.
            btnGuardarContinuar.Enabled = false;

            // Crea una instancia de la clase de negocio.
            clsNegocio cls = new clsNegocio();

            int? codN = null;
            int temp = 0;
            int.TryParse(lblCodNominacionProceso.Text, out temp);
            if (lblCodNominacionProceso.Text.Trim() != string.Empty && temp != 0)
            {
                codN = temp;
            }

            try
            {
                // Declara y asigna valores a las variables de archivos.
                string archivo1 = "";
                string archivo2 = "";
                string archivo3 = "";

                // Llama al método de la clase de negocio para guardar la nominación RUPS.
                var i = cls.guardarNominacionRups(codN, int.Parse(Request.QueryString["codProceso"]),
                    int.Parse(Session["SS_COD_REGISTRO"].ToString()), DateTime.Now,

                    // txtNombreProcedimiento.Text, 
                    int.Parse(cmbTipoProcedimiento.SelectedValue),
                    int.Parse(cmbAmbitoUso.SelectedValue),
                    txtDesccripcionDetallada.Text, txtEnfermedad.Text, txtEnfermedad2.Text, txtEnfermedad3.Text,

                    chkPromocionSalud.Checked, chkPrevencionEnfermedad.Checked, chkDiagnostico.Checked,
                    chkTratamiento.Checked, chkRehabilitacion.Checked, chkPaliacion.Checked, chkcosmetico.Checked,
                    txtCupsAjuste.Text, txtCupsAjuste2.Text, txtCupsAjuste3.Text, cmbCupsAjusteEstructura.SelectedValue,
                    txtCupsComparador1.Text, txtCupsComparador2.Text, txtCupsComparador3.Text, cmbCupsCalificacion.SelectedValue,
                    txtCupsPopuestoCod.Text, txtCupsPopuestoDes.Text, txtJustificacionNominacion.Text,
                    cmbProcedimientoNacional.SelectedValue == "1",
                    chkReduccionMortalidad.Checked, txtReduccionMortalidad.Text,
                    chkReduccionMorbilidad.Checked, txtReduccionMorbilidad.Text,
                    chkReduccionDiscapacidad.Checked, txtReduccionDiscapacidad.Text,
                    chkReduccionHospitalaria.Checked, txtReduccionHospitalaria.Text,
                    chkDisminucionComplicacion.Checked, txtDisminucionComplicacion.Text,
                    chkMejoraCalidadVida.Checked, txtMejoraCalidadVida.Text, chkVentajaOtro.Checked,
                    txtVentajaOtro.Text, chkEfectividadClinicaSi.Checked, lnkArchivo1.HRef, chkEficaciaClinicaSi.Checked,
                    lnkArchivo2.HRef, chkRiesgosPacienteSi.Checked, txtRiesgosPacienteDescripcion.Text,
                    chkInteresSaludSi.Checked, txtObservacionInteresSalud.Text,
                    txtNombreGPC.Text, txtRecomendacionGPC.Text, chkAdjuntaEvidenciaSi.Checked,
                    txtObservacionesAdicional.Text, lnkArchivo3.HRef,
                    rdMedicamentoAdicionalSi.Checked, txtRecursoAdicionalMedicamento.Text,
                    cmbEstadoInvimaMedicamento.SelectedValue, txtRegistroInvimaMedicamento.Text,
                    rdDispositivoAdicionalSi.Checked, txtRecursoAdicionalDispositivo.Text,
                    txtEstadoInvimaDispositivo.Text, txtRegistroInvimaDispositivo.Text,
                    rdInVitroAdicionalSi.Checked, txtRecursoAdicionalInvitro.Text,
                    txtEstadoInvimaInvitro.Text, txtRegistroInvimaInvitro.Text,
                    rdAgenteBioAdicionalSi.Checked, txtRecursoAdicionalAgebio.Text,
                    txtEstadoInvimaAgebio.Text, txtRegistroInvimaAgeBio.Text,
                    rdproductoBioAdicionalSi.Checked, txtRecursoAdicionalAgeproducto.Text,
                    txtEstadoInvimaAgeproducto.Text, txtRegistroInvimaAgeproducto.Text,
                    rdAdicionalOtroSi.Checked, txtOtroAdicional.Text,
                    rdInfaciaSi.Checked, txtRelevanteInfancia.Text,
                    rdEmbarazoSi.Checked, txtRelevanteEmbarazo.Text,
                    rdDesplazadosSi.Checked, txtRelevanteDesplazados.Text,
                    rdViolenciaSi.Checked, txtRelevanteViolencia.Text,
                    rdAdultosMayoresSi.Checked, txtRelevanteAdultosMayores.Text,
                    rdAlgunaDiscapacidadSi.Checked, txtRelevanteAlgunaDiscapacidad.Text,
                    rdHurefanasSi.Checked, txtRelevanteHuerfanas.Text,
                    chkConflictoInteres.Checked, txtConflicto.Text,
                    rdAvala.Checked, txtRazonAvala.Text,
                    rdTerceroNatural.Checked ? (int?)null : int.Parse(cmbTipoActorNomina.SelectedValue), rdTerceroNatural.Checked,
                        rdTerceroJuridico.Checked, txtNombreNominadortercero.Text,
                    txtNitTercero.Text, rdNombrePropio.Checked
                    , int.Parse(Request.QueryString["v"]));

                // Cambia el estado de la nominación RUPS.
                cls.cambiarEstadoNominacionRups(i, 2);
                lblCodNominacionProceso.Text = i.ToString();
                LblValidacionCampos.Text = "La información ha sido guardada exitosamente en su cuenta y estará disponible para ser completada y remitida para el proceso vigente.";

                return true;
            }
            catch (DbEntityValidationException ex)
            {
                // Captura y maneja excepciones de validación de entidad de la base de datos.
                var errorMessages = ex.EntityValidationErrors
                    .SelectMany(x => x.ValidationErrors)
                    .Select(x => x.ErrorMessage);

                // Une la lista de mensajes de error en una cadena.
                var fullErrorMessage = string.Join("; ", errorMessages);
                LblValidacionCampos.Text = "Problema al guardar el registro, algunos campos superan el tamaño máximo de 3000 caracteres <br>" + fullErrorMessage;
                btnGuardar.Visible = true;

                Desktop.Logging.Logger.Write(ex);
                if (ex.InnerException != null)
                {
                    Desktop.Logging.Logger.Write(ex.InnerException);
                }

                foreach (var validationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}", validationErrors.Entry.Entity.ToString(), validationError.ErrorMessage);
                        //raise a new exception inserting the current one as the InnerException
                        Desktop.Logging.Logger.Write(message);
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                // Captura y maneja otros errores.
                LblValidacionCampos.Text = "Problema al guardar el registro, algunos campos superan el tamaño máximo de 3000 caracteres <br>" + ex.Message;
                btnGuardar.Visible = true;
                return false;
            }
        }


        /// <summary>
        /// Método para guardar la información de inclusión en la base de datos.
        /// </summary>
        /// <returns>True si la información se guardó correctamente, False en caso contrario.</returns>
        private bool guardarInclusion()
        {
            // Habilita y hace visible el botón 'btnGuardarContinuar'.
            btnGuardarContinuar.Enabled = true;
            btnGuardarContinuar.Visible = true;

            // Crea una instancia de la clase de negocio.
            clsNegocio cls = new clsNegocio();

            int? codN = null;
            int temp = 0;
            int.TryParse(lblCodNominacionProceso.Text, out temp);
            if (lblCodNominacionProceso.Text.Trim() != string.Empty && temp != 0)
            {
                codN = temp;
            }

            try
            {
                // Declara y asigna valores a las variables de archivos.
                string archivo1 = "";
                string archivo2 = "";
                string archivo3 = "";

                // Llama al método de la clase de negocio para guardar la nominación de inclusión.
                var i = cls.guardarNominacionRupsInclusion(
                    codN,
                    int.Parse(Request.QueryString["codProceso"]),
                    int.Parse(Session["SS_COD_REGISTRO"].ToString()),
                    DateTime.Now,
                    int.Parse(Request.QueryString["v"]),
                    rdNombrePropio.Checked,
                    rdTerceroNatural.Checked,
                    rdTerceroJuridico.Checked,
                    Convert.ToInt32(cmbTipoActorNomina.SelectedValue),
                    txtNombreNominadortercero.Text.Trim().Trim(),
                    txtNitTercero.Text.Trim().Trim(),
                    cmbCupsCalificacion.SelectedValue.ToString(),
                    rdExperimentacionSI.Checked,
                    cmbCupsAjusteEstructura.SelectedValue.ToString(),
                    txtCupsPopuestoCod.Text.Trim(),
                    txtCupsPopuestoDes.Text.Trim(),
                    txtJustificacionNuevo.Text.Trim(),
                    txtDescProcNuevo.Text.Trim(),
                    txtDecCriterioNuevo.Text.Trim(),
                    chkPromocionSalud.Checked,
                    chkPrevencionEnfermedad.Checked,
                    chkDiagnostico.Checked,
                    chkTratamiento.Checked,
                    chkRehabilitacion.Checked,
                    chkPaliacion.Checked,
                    chkcosmetico.Checked,
                    int.Parse(cmbTipoProcedimiento.SelectedValue),
                    int.Parse(cmbAmbitoUso.SelectedValue),
                    txtEnfermedad.Text.Trim(),
                    txtEnfermedad2.Text.Trim(),
                    txtEnfermedad3.Text.Trim(),
                    txtDesGrupoPoblacionalNuevo.Text.Trim(),
                    int.Parse(txtNumeroPacientes.Text.Trim()),
                    rdRemplazaSI.Checked,
                    txtRemplaza.Text.Trim(),
                    rdRiesgoSI.Checked,
                    txtRiesgo.Text.Trim(),
                    txtResultados.Text.Trim(),
                    txtOtrasIntervenciones.Text.Trim(),
                    txtTecnologiasEjecucion.Text.Trim(),
                    rdINVIMA1SI.Checked,
                    txtINVIMA1.Text.Trim(),
                    txtNumINVIMA1.Text.Trim(),
                    cmbEstadoINVIMA1.SelectedValue.ToString(),
                    rdINVIMA2SI.Checked,
                    txtINVIMA2.Text.Trim(),
                    txtNumINVIMA2.Text.Trim(),
                    cmbEstadoINVIMA2.SelectedValue.ToString(),
                    rdINVIMA3SI.Checked,
                    txtINVIMA3.Text.Trim(),
                    txtNumINVIMA3.Text.Trim(),
                    cmbEstadoINVIMA3.SelectedValue.ToString(),
                    chkEfectividadClinicaSi.Checked,
                    lnkArchivo1.HRef,
                    chkEficaciaClinicaSi.Checked,
                    lnkArchivo2.HRef,
                    rdEnTerritorioSI.Checked,
                    txtEnTerritorio.Text.Trim(),
                    rdRealizadoTerritorioSI.Checked,
                    txtRealizadoTerritorio.Text.Trim(),
                    txtCUPSRealizacion.Text.Trim(),
                    txtYearRealizacion.Text.Trim(),
                    rdOtrosSistemasCodificacionSI.Checked,
                    txtOtrosSistemasCodificacion.Text.Trim(),
                    chkAdjuntaEvidenciaSi.Checked,
                    txtObservacionesAdicional.Text.Trim(),
                    lnkArchivo3.HRef,
                    chkConflictoInteres.Checked,
                    txtConflicto.Text.Trim(),
                    rdAvala.Checked,
                    txtRazonAvala.Text.Trim(),
                    txtNombreGPC.Text.Trim(),
                    txtRecomendacionGPC.Text.Trim()
                );

                // Cambia el estado de la nominación a 2 (En revisión).
                cls.cambiarEstadoNominacionRups(i, 2);

                // Actualiza el valor del código de nominación en la etiqueta correspondiente.
                lblCodNominacionProceso.Text = i.ToString();

                // Muestra un mensaje indicando que la información ha sido guardada exitosamente.
                LblValidacionCampos.Text = "La información ha sido guardada exitosamente en su cuenta y estará disponible para ser completada y remitida para el proceso vigente.";

                return true;
            }
            catch (DbEntityValidationException ex)
            {
                // Captura y maneja errores de validación de entidades.
                var errorMessages = ex.EntityValidationErrors
                    .SelectMany(x => x.ValidationErrors)
                    .Select(x => x.ErrorMessage);

                // Une la lista de mensajes de error en una cadena.
                var fullErrorMessage = string.Join("; ", errorMessages);
                LblValidacionCampos.Text = "Problema al guardar el registro, algunos campos superan el tamaño máximo de 3000 caracteres <br>" + fullErrorMessage;
                btnGuardar.Visible = true;
                Desktop.Logging.Logger.Write(ex);
                if (ex.InnerException != null)
                {
                    Desktop.Logging.Logger.Write(ex.InnerException);
                }
              
                foreach (var validationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}", validationErrors.Entry.Entity.ToString(), validationError.ErrorMessage);
                        //raise a new exception inserting the current one as the InnerException
                        Desktop.Logging.Logger.Write(message);
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                // Captura y maneja otros errores.
                LblValidacionCampos.Text = "Problema al guardar el registro, algunos campos superan el tamaño máximo de 3000 caracteres <br>" + ex.Message;
                btnGuardar.Visible = true;
                Desktop.Logging.Logger.Write(ex);
                if (ex.InnerException != null)
                {
                    Desktop.Logging.Logger.Write(ex.InnerException);
                }
                return false;
            }
        }


        /// <summary>
        /// Controlador de eventos para el clic en el botón 'btnObjetar'.
        /// Redirige a la página "frmObjetar.aspx" con parámetros en la URL, incluyendo el código de nominación y el código de proceso.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento (en este caso, el botón 'btnObjetar').</param>
        /// <param name="e">Los datos del evento.</param>
        protected void btnObjetar_Click(object sender, EventArgs e)
        {
            // Redirige a la página "frmObjetar.aspx" con parámetros en la URL, incluyendo el código de nominación y el código de proceso.
            Response.Redirect("frmObjetar.aspx?codN=" + Request.QueryString["codN"] + "&codProceso=" + Request.QueryString["codProceso"]);
        }


        /// <summary>
        /// Controlador de eventos para el cambio de ítem seleccionado en el DropDownList 'cmbCupsCalificacion'.
        /// Ajusta la visibilidad de varios controles en la interfaz de usuario según la selección del usuario.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento (en este caso, el DropDownList).</param>
        /// <param name="e">Los datos del evento.</param>
        protected void cmbCupsCalificacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCupsCalificacion.SelectedValue != "-1")
            {
                Label51.Visible = true;
                cmbCupsAjusteEstructura.Visible = true;
                fldCups.Visible = true;
                fldEvidencia.Visible = true;
                fldConflicto.Visible = true;
                divGuardar.Visible = true;
                msjExperimentacion.Visible = false;
                
                if (cmbCupsCalificacion.SelectedValue == "Incluir Procedimiento NUEVO")
                {
                    if (rdExperimentacionSI.Checked == true)
                    {
                        Label51.Visible = false;
                        cmbCupsAjusteEstructura.Visible = false;
                        fldCups.Visible = false;
                        fldEvidencia.Visible = false;
                        fldConflicto.Visible = false;
                        divGuardar.Visible = false;
                        Fieldset1.Visible = false;
                        fldProcedimientoNuevo.Visible = false;
                        fldCarcteristicasNuevo.Visible = false;
                        fldFinalidadProcedimiento.Visible = false;
                        fldVEntajas.Visible = false;
                        fldEfectividadClinica.Visible = false;
                       
                        fldAtencion.Visible = false;
                        fldRecursosAdicionales.Visible = false;
                        fldOtrasNominaciones.Visible = false;
                        fldOtrasNominaciones2.Visible = false;
                        fldCarcteristicasNuevo.Visible = false;
                        fldJustificacionNuevo.Visible = false;
                        fldJustificacion.Visible = false;
                        fldTipoProcedimiento.Visible = false;
                        fldDescripcion.Visible = false;
                        fldDescripcionNuevo.Visible = true;
                        fldCIE.Visible = false;
                        fldEfectividadClinica.Visible = false;
                        fldRiesgos.Visible = false;
                        fldINVIMA.Visible = false;
                        fldEficacia.Visible = false;
                        fldImplementado.Visible = false;

                    }
                    else
                    {

                        Fieldset1.Visible = false;
                        fldProcedimientoNuevo.Visible = true;
                        fldCarcteristicasNuevo.Visible = true;
                        fldFinalidadProcedimiento.Visible = true;
                        fldVEntajas.Visible = false;
                        fldEfectividadClinica.Visible = false;
                        fldRecomendaciones.Visible = true;
                        fldAtencion.Visible = false;
                        fldRecursosAdicionales.Visible = false;
                        fldOtrasNominaciones.Visible = false;
                        fldOtrasNominaciones2.Visible = false;
                        fldCarcteristicasNuevo.Visible = true;
                        fldJustificacionNuevo.Visible = true;
                        fldJustificacion.Visible = false;
                        fldTipoProcedimiento.Visible = true;
                        fldDescripcion.Visible = false;
                        fldDescripcionNuevo.Visible = true;
                        fldCIE.Visible = true;
                        fldEfectividadClinica.Visible = true;
                        fldRiesgos.Visible = false;
                        fldINVIMA.Visible = false;
                        fldEficacia.Visible = true;
                        fldImplementado.Visible = true;
                    }

                }
                else
                {
                    msjExperimentacion.Visible = false;
                    Fieldset1.Visible = true;
                    fldProcedimientoNuevo.Visible = false;
                    fldFinalidadProcedimiento.Visible = true;
                    fldCarcteristicasNuevo.Visible = false;
                    fldVEntajas.Visible = true;
                    fldEfectividadClinica.Visible = true;
                    fldRecomendaciones.Visible = true;
                    fldAtencion.Visible = true;
                    fldRecursosAdicionales.Visible = true;
                    fldOtrasNominaciones.Visible = true;
                    fldOtrasNominaciones2.Visible = true;
                    fldCarcteristicasNuevo.Visible = false;
                    fldJustificacionNuevo.Visible = false;
                    fldJustificacion.Visible = true;
                    fldTipoProcedimiento.Visible = true;
                    fldDescripcion.Visible = true;
                    fldDescripcionNuevo.Visible = false;
                    fldCIE.Visible = true;
                    fldEfectividadClinica.Visible = true;
                    fldRiesgos.Visible = true;
                    fldINVIMA.Visible = false;
                    fldEficacia.Visible = false;
                    fldImplementado.Visible = false;
                    fldEficacia.Visible = true;
                    fldImplementado.Visible = false;
                }
            }
        }

        /// <summary>
        /// Controlador de eventos para el cambio de estado del RadioButton 'rdExperimentacion'.
        /// Si el RadioButton para experimentación está seleccionado, ajusta la visibilidad de varios controles en la interfaz de usuario.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento (en este caso, el RadioButton).</param>
        /// <param name="e">Los datos del evento.</param>
        protected void rdExperimentacion_CheckedChanged(object sender, EventArgs e)
        {
            if (rdExperimentacionSI.Checked)
            {
                // Muestra ciertos controles y oculta otros cuando el RadioButton para experimentación está seleccionado.
                msjExperimentacion.Visible = true;
                pnlMensajeNoNominador.Visible = false;
                fldProcedimientoNuevo.Visible = false;
                pnlFormulario.Visible = true;
                fldEvidencia.Visible = false;
                // ... (continuar con la lista de ajustes de visibilidad)

                // Puedes seguir ajustando la visibilidad de más controles según sea necesario.

            }
            else
            {
                // Oculta el mensaje de experimentación si el RadioButton no está seleccionado.
                msjExperimentacion.Visible = false;
            }
        }

        /// <summary>
        /// Controlador de eventos para el cambio de estado del CheckBox 'chkDispositivoMedicamento'.
        /// Si el CheckBox está marcado, hace visible el control fldINVIMA; de lo contrario, lo oculta.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento (en este caso, el CheckBox).</param>
        /// <param name="e">Los datos del evento.</param>
        protected void chkDispositivoMedicamento_CheckedChanged(object sender, EventArgs e)
        {
            // Verifica si el CheckBox está marcado.
            if (chkDispositivoMedicamento.Checked)
            {
                // Si está marcado, hace visible el control fldINVIMA.
                fldINVIMA.Visible = true;
            }
            else
            {
                // Si no está marcado, oculta el control fldINVIMA.
                fldINVIMA.Visible = false;
            }
        }

    }
}