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
    public partial class frmInscripcionProcesoUPC : System.Web.UI.Page
    {
        class archivos
        {
            public string descripcion { set; get; }
            public string url { set; get; }
        }



        private void cargarArchivos()
        {
            if (!IsPostBack)
            {

                Session["ss_upc_FileUpload7_filename"] = null;
                Session["ss_upc_FileUpload7_filepath"] = null;
                Session["ss_upc_FileUpload6_filename"] = null;
                Session["ss_upc_FileUpload6_filepath"] = null;

                Session["ss_upc_FileUpload4_filename"] = null;
                Session["ss_upc_FileUpload4_filepath"] = null;
                Session["ss_upc_FileUpload3_filename"] = null;
                Session["ss_upc_FileUpload3_filepath"] = null;
                Session["ss_upc_FileUpload2_filename"] = null;
                Session["ss_upc_FileUpload2_filepath"] = null;
                Session["ss_upc_FileUpload1_filename"] = null;
                Session["ss_upc_FileUpload1_filepath"] = null;
            }

            if (Session["ss_upc_FileUpload7_filepath"] != null && Session["ss_upc_FileUpload7_filepath"].ToString() != string.Empty)
            {
                lnkArchivo7.InnerText = Session["ss_upc_FileUpload7_filename"].ToString();
                lnkArchivo7.HRef = Session["ss_upc_FileUpload7_filepath"].ToString();
            }


            if (Session["ss_upc_FileUpload6_filepath"] != null && Session["ss_upc_FileUpload6_filepath"].ToString() != string.Empty)
            {
                lnkArchivo6.InnerText = Session["ss_upc_FileUpload6_filename"].ToString();
                lnkArchivo6.HRef = Session["ss_upc_FileUpload6_filepath"].ToString();
            }



            if (Session["ss_upc_FileUpload4_filepath"] != null && Session["ss_upc_FileUpload4_filepath"].ToString() != string.Empty)
            {
                lnkArchivo4.InnerText = Session["ss_upc_FileUpload4_filename"].ToString();
                lnkArchivo4.HRef = Session["ss_upc_FileUpload4_filepath"].ToString();
            }

            if (Session["ss_upc_FileUpload3_filepath"] != null && Session["ss_upc_FileUpload3_filepath"].ToString() != string.Empty)
            {
                lnkArchivo3.InnerText = Session["ss_upc_FileUpload3_filename"].ToString();
                lnkArchivo3.HRef = Session["ss_upc_FileUpload3_filepath"].ToString();
            }

            if (Session["ss_upc_FileUpload2_filepath"] != null && Session["ss_upc_FileUpload2_filepath"].ToString() != string.Empty)
            {
                lnkArchivo2.InnerText = Session["ss_upc_FileUpload2_filename"].ToString();
                lnkArchivo2.HRef = Session["ss_upc_FileUpload2_filepath"].ToString();
            }
            if (Session["ss_upc_FileUpload1_filepath"] != null && Session["ss_upc_FileUpload1_filepath"].ToString() != string.Empty)
            {
                lnkArchivo1.InnerText = Session["ss_upc_FileUpload1_filepath"].ToString();
                lnkArchivo1.HRef = Session["ss_upc_FileUpload1_filepath"].ToString();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            DateTime limite = new DateTime(2018, 06, 14, 10, 0, 0);
            if (DateTime.Now > limite)
            {
                Response.Redirect("~/Default.aspx");
            }

            //if (Session["SS_NOMBRE_USUARIO"] == null || Session["SS_NOMBRE_USUARIO"].ToString() == string.Empty)
            //{
            //    Response.Redirect("~/frm/seguridad/frmLogin.aspx?page=" + this.Request.RawUrl.Replace("/", "@@").Replace("=", "**").Replace("&", "$$"));
            //    return;
            //}
            //cargamos la ifnormacio de los fileupload que se encuentran en session
            cargarArchivos();

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




            clsNegocio obj = new clsNegocio();
            if (!IsPostBack)
            {
                int codR = 0;

                if (Session["SS_COD_REGISTRO"] != null) codR = int.Parse(Session["SS_COD_REGISTRO"].ToString());
                //cargamos la infomracion del registro
                if (codR != 0)
                {
                    var reg = obj.obtenerRegistroxCodigo(codR);

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
                    //si esta modificando la nominacion solo deberia verla si es el autor


                    #region carga mosla informacion de la nominacion
                    var registro = obj.obtenerNOMINACION_PROCESOUPC(int.Parse(Request.QueryString["codN"]));

                    if (registro.COD_REGISTRO.ToString() != Session["SS_COD_REGISTRO"].ToString().Trim())
                    {
                        Response.Redirect("~/default.aspx");
                    }
                    var frm3 = obj.obtenerUPC_FORMULARIO3(int.Parse(Request.QueryString["codN"]));
                    lblCodNominacionUPC.Text = registro.COD_NOMINACION_PROCESO_UPC.ToString();
                    if (registro.COD_ESTADO_NOMINACION_UPC == 2 || registro.COD_ESTADO_NOMINACION_UPC == 3 || registro.COD_ESTADO_NOMINACION_UPC > 4)//no deberia poder editar
                    {
                        #region deshabilitamos los controles

                        rdAdicionalOtroNo.Enabled = false;
                        rdAdicionalOtroSi.Enabled = false;
                        rdAdultosMayoresNo.Enabled = false;
                        rdAdultosMayoresSi.Enabled = false;
                        rdAgenteBioAdicionalNo.Enabled = false;
                        rdAgenteBioAdicionalSi.Enabled = false;
                        rdAlgunaDiscapacidadNo.Enabled = false;
                        rdAlgunaDiscapacidadSi.Enabled = false;
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

                        rdproductoBioAdicionalNo.Enabled = false;
                        rdproductoBioAdicionalSi.Enabled = false;

                        //rdViolenciaNo.Enabled = false;
                        //rdViolenciaSi.Enabled = false;
                        //txtConflicto.ReadOnly = true;
                        //txtCupsAjuste.ReadOnly = true;
                        //txtCupsAjuste2.ReadOnly = true;
                        //txtCupsAjuste3.ReadOnly = true;
                        //txtCupsAjusteEstructura.ReadOnly = true;
                        //txtCupsCalificacion.ReadOnly = true;
                        //txtCupsComparador1.ReadOnly = true;
                        //txtCupsComparador2.ReadOnly = true;
                        //txtCupsComparador3.ReadOnly = true;
                        //txtCupsPopuestoCod.ReadOnly = true;
                        //txtCupsPopuestoDes.ReadOnly = true;
                        //txtDesccripcionDetallada.ReadOnly = true;
                        //txtDisminucionComplicacion.ReadOnly = true;
                        //txtEnfermedad.ReadOnly = true;
                        //txtEnfermedad2.ReadOnly = true;
                        //txtEnfermedad3.ReadOnly = true;
                        //txtEstadoInvimaAgebio.ReadOnly = true;
                        //txtEstadoInvimaAgeproducto.ReadOnly = true;
                        //txtEstadoInvimaDispositivo.ReadOnly = true;
                        //txtEstadoInvimaInvitro.ReadOnly = true;
                        //txtEstadoInvimaMedicamento.ReadOnly = true;
                        //txtIdentificacionNominador.ReadOnly = true;
                        //txtJustificacionNominacion.ReadOnly = true;
                        //txtMejoraCalidadVida.ReadOnly = true;

                        ////txtNombreGPC.ReadOnly = true;
                        ////txtNombreNominador.ReadOnly = true;
                        ////txtNombreTecnologia.ReadOnly = true;
                        ////txtObservacionesAdicional.ReadOnly = true;
                        ////txtObservacionesValidacion.ReadOnly = true;
                        ////txtObservacionInteresSalud.ReadOnly = true;
                        ////txtOtroAdicional.ReadOnly = true;
                        ////txtRazonAvala.ReadOnly = true;
                        ////txtRecomendacionGPC.ReadOnly = true;
                        ////txtRecursoAdicionalAgebio.ReadOnly = true;
                        ////txtRecursoAdicionalAgeproducto.ReadOnly = true;
                        ////txtRecursoAdicionalDispositivo.ReadOnly = true;
                        ////txtRecursoAdicionalInvitro.ReadOnly = true;
                        ////txtRecursoAdicionalMedicamento.ReadOnly = true;
                        ////txtReduccionDiscapacidad.ReadOnly = true;
                        ////txtReduccionHospitalaria.ReadOnly = true;
                        ////txtReduccionMorbilidad.ReadOnly = true;
                        ////txtReduccionMortalidad.ReadOnly = true;
                        ////txtRegistroInvimaAgeBio.ReadOnly = true;
                        ////txtRegistroInvimaAgeproducto.ReadOnly = true;
                        ////txtRegistroInvimaDispositivo.ReadOnly = true;
                        ////txtRegistroInvimaInvitro.ReadOnly = true;
                        ////txtRegistroInvimaMedicamento.ReadOnly = true;
                        ////txtRelevanteAdultosMayores.ReadOnly = true;
                        ////txtRelevanteAlgunaDiscapacidad.ReadOnly = true;
                        ////txtRelevanteDesplazados.ReadOnly = true;
                        ////txtRelevanteEmbarazo.ReadOnly = true;
                        ////txtRelevanteHuerfanas.ReadOnly = true;
                        ////txtRelevanteInfancia.ReadOnly = true;
                        ////txtRelevanteViolencia.ReadOnly = true;
                        ////txtRiesgosPacienteDescripcion.ReadOnly = true;
                        ////txtTipoAator.ReadOnly = true;
                        ////txtVAidacionAgenteBiologico.ReadOnly = true;
                        ////txtVaidacionAvala.ReadOnly = true;
                        ////txtVaidacionOtro.ReadOnly = true;
                        ////txtVaildacionDispositivoAdicional.ReadOnly = true;

                        ////txtValidacionCie10.ReadOnly = true;
                        ////txtValidacionDismunicionComplicacion.ReadOnly = true;
                        ////txtValidacionEfectividadClinica.ReadOnly = true;
                        ////txtValidacionEstudiosSeguridad.ReadOnly = true;
                        ////txtValidacionFinalidadProcedimiento.ReadOnly = true;
                        ////txtValidacionGPC.ReadOnly = true;
                        ////txtValidacionInfoAdicional.ReadOnly = true;
                        ////txtValidacionInteresSaludPublica.ReadOnly = true;
                        ////txtValidacionInvitroAdicional.ReadOnly = true;
                        ////txtValidacionJustificacion.ReadOnly = true;
                        ////txtValidacionMedicamentoAdicional.ReadOnly = true;
                        ////txtValidacionMejoraCalidadVida.ReadOnly = true;
                        ////txtValidacionMejoraOtro.ReadOnly = true;
                        ////txtValidacionNombreTecnologia.ReadOnly = true;
                        ////txtValidacionProdcutoBilogico.ReadOnly = true;
                        ////txtValidacionPropuestaAjuste.ReadOnly = true;
                        ////txtValidacionReduccionDiscapacidad.ReadOnly = true;
                        ////txtValidacionReduccionEstanciaHospital.ReadOnly = true;
                        ////txtValidacionReduccionMorbilidad.ReadOnly = true;
                        ////txtValidacionReduccionMortalidad.ReadOnly = true;
                        ////txtValidacionRiesgosAdversos.ReadOnly = true;
                        ////txtValidacionTerritorioNacional.ReadOnly = true;
                        ////txtValidacionTipoProcedimiento.ReadOnly = true;
                        ////txtValidacionVulnerabilidad.ReadOnly = true;
                        ////txtVentajaOtro.ReadOnly = true;

                        chkAdjuntaEvidenciaNo.Enabled = false;
                        chkAdjuntaEvidenciaSi.Enabled = false;
                        chkConflictoInteres.Enabled = false;

                        chkDisminucionComplicacion.Enabled = false;
                        chkEfectividadClinicaNo.Enabled = false;
                        chkEfectividadClinicaSi.Enabled = false;
                        chkEficaciaClinicaNo.Enabled = false;
                        ;

                        chkVentajaOtro.Enabled = false;
                        #endregion
                        btnGuardar.Visible = false;
                        btnGuardarContinuar.Visible = false;
                    }

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

                    txtValidacionGeneral.Text = registro.OBSERVACIONES_VALIDACION;

                    txtCartaPresentacion.Text = registro.CARTA_PRESENTACION;
                    txtNombreTecnologia.Text = registro.NOMBRE_TECNOLOGIA;
                    txtNombreComercialTecnologia.Text = registro.NOMBRE_COMERCIAL;
                    txtIndicacionUsoTecnologia.Text = registro.INDICACION_USO;
                    txtJustificacionPropuesta.Text = registro.JUSTIFICACION;
                    txtEnfermedad.Text = registro.CIE10;
                    txtEnfermedad2.Text = registro.CIE102;
                    txtEnfermedad3.Text = registro.CIE103;
                    if (registro.ES_MEDICAMENTO.HasValue)
                        rdMedicamento.Checked = registro.ES_MEDICAMENTO.Value;
                    if (registro.ES_PROCEDIMIENTO.Value)
                        rdProcedimiento.Checked = registro.ES_PROCEDIMIENTO.Value;

                    if (registro.ES_DISPOSITIVO.HasValue)
                        rdDispositivoMedico.Checked = registro.ES_DISPOSITIVO.Value;

                    if (registro.ES_OTRO.HasValue)
                        rdOtro.Checked = registro.ES_OTRO.Value;

                    if (registro.ES_TITULAR_REGISTRO_TSN.HasValue)
                        chkTitularRegistro.Checked = registro.ES_TITULAR_REGISTRO_TSN.Value;

                    txtTitularRegistro.Text = registro.OBS_TITULAR_REGISTRO_TSN;

                    if (registro.ES_FABRICANTE_TSN.HasValue)
                        chkFabricante.Checked = registro.ES_FABRICANTE_TSN.Value;

                    txtFabricante.Text = registro.OBS_FABRICANTE_TSN;

                    if (registro.ES_IMPORTADOR_TSN.HasValue)
                        chkImportador.Checked = registro.ES_IMPORTADOR_TSN.Value;
                    txtImportador.Text = registro.OBS_IMPORTADOR;

                    if (registro.ES_ACONDICIONADOR_TSN.HasValue)
                        chkAcondicionador.Checked = registro.ES_ACONDICIONADOR_TSN.Value;


                    txtAcondicionador.Text = registro.OBS_ACONDICIONDOR_TSN;
                    if (registro.ES_PRESTADOR_TSN.HasValue)
                        chkPrestadorServicio.Checked = registro.ES_PRESTADOR_TSN.Value;
                    txtPrestadorServicio.Text = registro.OBS_PRESTADOR_TSN;

                    if (registro.ES_USUARIO_TSN.HasValue)
                        chkUsuarioTecnologia.Checked = registro.ES_USUARIO_TSN.Value;
                    txtUsuarioTecnologia.Text = registro.OBS_USUARIO_TSN;
                    if (registro.ES_OTRO_TSN.HasValue)
                        chkRelacionOtro.Checked = registro.ES_OTRO_TSN.Value;

                    txtRelacionOtro.Text = registro.OBS_OTRO_TSN;
                    txtPrincipioActivo.Text = registro.PRINCIPIO_ACTIVO;
                    txtCodigoATC.Text = registro.CODIGO_ATC;
                    txtFormaFarmaceutica.Text = registro.FORMA_FARMACEUTICA;
                    txtConcentracion.Text = registro.CONCENTRACION;
                    txtViaAdministracion.Text = registro.VIA_ADMINSITRACION;
                    txtOtraIndicacionesMedicamento.Text = registro.OTRAS_INDICACIONES_MEDICAMENTO;
                    txtRegistroSanitario.Text = registro.REGISTRO_SANITARIO;
                    txtObservacionesMedicamento.Text = registro.OBSERVACIONES_MEDICAMENTO;
                    txtCupsAjuste.Text = registro.CODIGO_CUPS;
                    txtIndicionesProcedimiento.Text = registro.INDICACION_PROCEDIMIENTO;

                    if (registro.COD_TIPO_PROCEDIMIENTO_UPC.HasValue)
                        cmbTipoProcedimiento.SelectedValue = registro.COD_TIPO_PROCEDIMIENTO_UPC.Value.ToString();
                    txtObservacionesProcedimientos.Text = registro.OBSERVACIONES_PROCEDIMIENTO;
                    txtRegistroSanitarioDispositivo.Text = registro.REGISTRO_SANITARIO_DISPOSITIVO;

                    if (registro.COD_TIPO_DISPOSITIVO.HasValue)
                        cmbTipoDispositivo.SelectedValue = registro.COD_TIPO_DISPOSITIVO.Value.ToString();
                    if (registro.COD_CLASIFICACION_RIESGO.HasValue)
                        cmbClasificacionRiesgo.SelectedValue = registro.COD_CLASIFICACION_RIESGO.Value.ToString();


                    txtIndicionesDispositivo.Text = registro.INDICACIONES_DISPOSITIVO;
                    txtObservacionesDispositivo.Text = registro.OBSERVACIONES_DISPOSITIVO;
                    if (registro.ES_PRIMERA.HasValue)
                        chkPrimeraLinea.Checked = registro.ES_PRIMERA.Value;

                    if (registro.ES_SEGUNDA.HasValue)
                        chkSegundaLinea.Checked = registro.ES_SEGUNDA.Value;

                    if (registro.ES_TERCERA.HasValue)
                        chkTerceraLinea.Checked = registro.ES_TERCERA.Value;

                    if (registro.ES_COTIDIANO.HasValue)
                        chkUsocotidiano.Checked = registro.ES_COTIDIANO.Value;

                    if (registro.ES_OTRA_IMPORTANCIA.HasValue)
                        chkOtroImportacia.Checked = registro.ES_OTRA_IMPORTANCIA.Value;

                    txtObservacionesImportancia.Text = registro.OBS_OTRA_IMPORTANCIA;
                    if (registro.ES_O1_MUJER.HasValue)
                        chkObj0a1Mujer.Checked = registro.ES_O1_MUJER.Value;

                    if (registro.ES_O1_HOMBRE.HasValue)
                        chkObj0a1Hombre.Checked = registro.ES_O1_HOMBRE.Value;

                    txtObj0a1.Text = registro.OBS_ES_01;
                    if (registro.ES_1_4MUJER.HasValue)
                        chkObj1a4Mujer.Checked = registro.ES_1_4MUJER.Value;
                    if (registro.ES_1_4HOMBRE.HasValue)
                        chkObj1a4Hombre.Checked = registro.ES_1_4HOMBRE.Value;
                    txtObj1a4.Text = registro.OBS_ES_1_4;
                    if (registro.ES_5_14_MUJER.HasValue)
                        chkObj5a14Mujer.Checked = registro.ES_5_14_MUJER.Value;

                    if (registro.ES_5_14_HOMBRE.HasValue)
                        chkObj5a14Hombre.Checked = registro.ES_5_14_HOMBRE.Value;
                    txtObj5a14.Text = registro.ES_5_14_OBS;
                    if (registro.ES_15_18_MUJER.HasValue)
                        chkObj15a28Mujer.Checked = registro.ES_15_18_MUJER.Value;

                    if (registro.ES_15_18_HOMBRE.HasValue)
                        chkObj15a28Hombre.Checked = registro.ES_15_18_HOMBRE.Value;
                    txtObj15a28.Text = registro.ES_15_18_OBS;
                    if (registro.ES_19_29_MUJER.HasValue)
                        chkObj19a29Mujer.Checked = registro.ES_19_29_MUJER.Value;
                    if (registro.ES_19_29_HOMBRE.HasValue)
                        chkObj19a29Hombre.Checked = registro.ES_19_29_HOMBRE.Value;
                    txtObj19a29.Text = registro.ES_19_29_OBS;
                    if (registro.ES_30_44_MUJER.HasValue)
                        chkObj30a44Mujer.Checked = registro.ES_30_44_MUJER.Value;
                    if (registro.ES_30_44_HOMBRE.HasValue)
                        chkObj30a44Hombre.Checked = registro.ES_30_44_HOMBRE.Value;
                    txtObj30a44.Text = registro.ES_30_44_OBS;
                    if (registro.ES_45_59_MUJER.HasValue)
                        chkObj45a59Mujer.Checked = registro.ES_45_59_MUJER.Value;
                    if (registro.ES_45_59_HOMBRE.HasValue)
                        chkObj45a59Hombre.Checked = registro.ES_45_59_HOMBRE.Value;
                    txtObj45a59.Text = registro.ES_45_59_OBS;
                    if (registro.ES_60_69_MUJER.HasValue)
                        chkObj60a69Mujer.Checked = registro.ES_60_69_MUJER.Value;
                    if (registro.ES_60_69_HOMBRE.HasValue)
                        chkObj60a69Hombre.Checked = registro.ES_60_69_HOMBRE.Value;
                    txtObj60a69.Text = registro.ES_60_69_OBS;
                    if (registro.ES_70_79_MUJER.HasValue)
                        chkObj70a79Mujer.Checked = registro.ES_70_79_MUJER.Value;
                    if (registro.ES_70_79_HOMBRE.HasValue)
                        chkObj70a79Hombre.Checked = registro.ES_70_79_HOMBRE.Value;
                    txtObj70a79.Text = registro.ES_70_79_OBS;
                    if (registro.ES_80_100_MUJER.HasValue)
                        chkObj80a100Mujer.Checked = registro.ES_80_100_MUJER.Value;
                    if (registro.ES_80_100_HOMBRE.HasValue)
                        chkObj80a100Hombre.Checked = registro.ES_80_100_HOMBRE.Value;
                    txtObj80a100.Text = registro.ES_80_100_OBS;
                    if (registro.ES_PROMOCION_SALUD.HasValue)
                        chkEtapaPromocionSalud.Checked = registro.ES_PROMOCION_SALUD.Value;
                    if (registro.ES_PREVENCION_ENFERMEDAD.HasValue)
                        chkEtapaPrevencionEnfermedad.Checked = registro.ES_PREVENCION_ENFERMEDAD.Value;

                    if (registro.ES_DIAGNOSTICO.HasValue)
                        chkEtapaDiagnostico.Checked = registro.ES_DIAGNOSTICO.Value;

                    if (registro.ES_TRATAMIENTO.HasValue)
                        chkEtapaTratamiento.Checked = registro.ES_TRATAMIENTO.Value;
                    if (registro.ES_REHABILITACION.HasValue)
                        chkEtapaRehabilitacion.Checked = registro.ES_REHABILITACION.Value;
                    if (registro.ES_PALIACION.HasValue)
                        chkEtapaPaliacion.Checked = registro.ES_PALIACION.Value;
                    if (registro.ES_COSMETICO.HasValue)
                        chkEtapacosmetico.Checked = registro.ES_COSMETICO.Value;

                    cmbAmbitoUso.SelectedValue = registro.COD_AMBITO_UPC.ToString();
                    if (registro.ES_REDUCCION_MORTALIDAD.HasValue)
                        chkReduccionMortalidad.Checked = registro.ES_REDUCCION_MORTALIDAD.Value;
                    txtReduccionMortalidad.Text = registro.OBS_ES_REDUCCION_MORTALIDAD;
                    if (registro.ES_REDUCCION_MORBILIDAD.HasValue)
                        chkReduccionMorbilidad.Checked = registro.ES_REDUCCION_MORBILIDAD.Value;
                    txtReduccionMorbilidad.Text = registro.OBS_ES_REDUCCION_MORBILIDAD;
                    if (registro.ES_DISMINUCION_INSTANCIA.HasValue)
                        chkReduccionHospitalaria.Checked = registro.ES_DISMINUCION_INSTANCIA.Value;
                    txtReduccionHospitalaria.Text = registro.OBS_ES_DISMINUCION_INSTANCIA;
                    if (registro.ES_MEJORA_CALIDAD_VIDA.HasValue)
                        chkMejoraCalidadVida.Checked = registro.ES_MEJORA_CALIDAD_VIDA.Value;
                    txtMejoraCalidadVida.Text = registro.OBS_ES_MEJORA_CALIDAD_VIDA;
                    if (registro.ES_OTRO_USO_TENOCLOGIA.HasValue)
                        chkVentajaOtro.Checked = registro.ES_OTRO_USO_TENOCLOGIA.Value;
                    txtVentajaOtro.Text = registro.OBS_ES_OTRO_USO_TECNOLOGIA;
                    if (registro.TIENE_EFECTIVIDAD.HasValue)
                    {
                        chkEfectividadClinicaSi.Checked = registro.TIENE_EFECTIVIDAD.Value;
                        chkEfectividadClinicaNo.Checked = !registro.TIENE_EFECTIVIDAD.Value;
                    }
                    string archivo = "";
                    archivo = registro.ARCHIVO_EFECTIVIDAD;
                    if (archivo.Contains("files"))
                    {
                        archivo = archivo.Substring(archivo.IndexOf("files"));
                        archivo = "~/" + archivo;
                    }
                    lnkArchivo1.HRef = archivo;
                    //--
                    archivo = registro.ARCHIVO_SEGURIDAD;
                    if (archivo.Contains("files"))
                    {
                        archivo = archivo.Substring(archivo.IndexOf("files"));
                        archivo = "~/" + archivo;
                    }
                    lnkArchivo2.HRef = archivo;
                    //--
                    archivo = registro.ARCHIVO_EFICACIA;
                    if (archivo.Contains("files"))
                    {
                        archivo = archivo.Substring(archivo.IndexOf("files"));
                        archivo = "~/" + archivo;
                    }
                    lnkArchivo3.HRef = archivo;


                    //--fin archivos

                    if (registro.TIENE_SEGURIDAD.HasValue)
                    {
                        chkSeguridadClinicaSi.Checked = registro.TIENE_SEGURIDAD.Value;
                        chkSeguridadClinicaNo.Checked = !registro.TIENE_SEGURIDAD.Value;
                    }

                    if (registro.TIENE_EFICACIA.HasValue)
                    {
                        chkEficaciaClinicaSi.Checked = registro.TIENE_EFICACIA.Value;
                        chkEficaciaClinicaNo.Checked = !registro.TIENE_EFICACIA.Value;
                    }
                    if (registro.OTRA_EVIDENCIA.HasValue)
                    {
                        chkEvidenciaOtroSi.Checked = registro.OTRA_EVIDENCIA.Value;
                        chkEvidenciaOtroNo.Checked = !registro.OTRA_EVIDENCIA.Value;
                    }
                    txtEvidenciaOtro.Text = registro.OBS_OTRA_EVIDENCIA;
                    if (registro.ES_EXTERIOR.HasValue)
                    {
                        chkPrestaExteriorSI.Checked = registro.ES_EXTERIOR.Value;
                        chkPrestaExteriorNo.Checked = !registro.ES_EXTERIOR.Value;
                    }
                    txtObservacionPrestaExterior.Text = registro.OBS_ES_EXTERIOR;
                    txtNombreGPC.Text = registro.NOMBRE_GPC;
                    txtRecomendacionGPC.Text = registro.RECOMENDACION_GPC;
                    if (registro.PRIMERA_INFANCIA.HasValue)
                    {
                        rdInfaciaSi.Checked = registro.PRIMERA_INFANCIA.Value;
                        rdInfanciaNo.Checked = !registro.PRIMERA_INFANCIA.Value;
                    }
                    txtRelevanteInfancia.Text = registro.OBS_PRIMERA_INFANACIA;
                    if (registro.EMBARAZO.HasValue)
                    {
                        rdEmbarazoSi.Checked = registro.EMBARAZO.Value;
                        rdEmbarazoNo.Checked = !registro.EMBARAZO.Value;
                    }
                    txtRelevanteEmbarazo.Text = registro.OBS_EMBARAZO;
                    if (registro.DESPLAZADOS.HasValue)
                    {
                        rdDesplazadosSi.Checked = registro.DESPLAZADOS.Value;
                        rdDesplazadosNo.Checked = !registro.DESPLAZADOS.Value;
                    }
                    txtRelevanteDesplazados.Text = registro.OBS_DESPLAZADOS;
                    if (registro.VICTIMAS_ARMADAS.HasValue)
                    {
                        rdViolenciaSi.Checked = registro.VICTIMAS_ARMADAS.Value;
                        rdViolenciaNo.Checked = !registro.VICTIMAS_ARMADAS.Value;
                    }
                    txtRelevanteViolencia.Text = registro.OBS_VICTIMAS_ARMADAS;
                    if (registro.ADULTOS_MAYORES.HasValue)
                    {
                        rdAdultosMayoresSi.Checked = registro.ADULTOS_MAYORES.Value;
                        rdAdultosMayoresNo.Checked = !registro.ADULTOS_MAYORES.Value;
                    }
                    txtRelevanteAdultosMayores.Text = registro.OBS_ADULTOS_MAYORES;
                    if (registro.DISCAPACIDAD.HasValue)
                    {
                        rdAlgunaDiscapacidadSi.Checked = registro.DISCAPACIDAD.HasValue;
                        rdAlgunaDiscapacidadNo.Checked = !registro.DISCAPACIDAD.HasValue;
                    }
                    txtRelevanteAlgunaDiscapacidad.Text = registro.OBS_DISCAPACIDAD;
                    if (registro.ENF_HUERFANADAS.HasValue)
                    {
                        rdHurefanasSi.Checked = registro.ENF_HUERFANADAS.Value;
                        rdHurefanasNo.Checked = !registro.ENF_HUERFANADAS.Value;
                    }
                    txtRelevanteHuerfanas.Text = registro.OBS_ENF_HUERFANAS;
                    if (registro.ES_SALUD_PUBLICA.HasValue)
                    {
                        rdInteresSaludSi.Checked = registro.ES_SALUD_PUBLICA.Value;
                        rdInteresSaludNo.Checked = !registro.ES_SALUD_PUBLICA.Value;
                    }
                    txtObservacionesInteresSalud.Text = registro.OBS_SALUD_PUBLICA;
                    if (registro.ES_RECURSO_MEDICAMENTO.HasValue)
                    {
                        rdMedicamentoAdicionalSi.Checked = registro.ES_RECURSO_MEDICAMENTO.Value;
                        rdMedicamentoAdicionalNo.Checked = !registro.ES_RECURSO_MEDICAMENTO.Value;
                    }
                    txtRecursoAdicionalMedicamento.Text = registro.OBS_ES_RECURSO_MEDICAMENTO;
                    if (registro.ES_RECURSO_DISPOSITIVO.HasValue)
                    {
                        rdDispositivoAdicionalSi.Checked = registro.ES_RECURSO_DISPOSITIVO.Value;
                        rdDispositivoAdicionalNo.Checked = !registro.ES_RECURSO_DISPOSITIVO.Value;
                    }
                    txtRecursoAdicionalDispositivo.Text = registro.OBS_ES_RECURSO_DISPOSITIVO;
                    if (registro.ES_RECURSO_INVITRO.HasValue)
                    {
                        rdInVitroAdicionalSi.Checked = registro.ES_RECURSO_INVITRO.Value;
                        rdInVitroAdicionalNo.Checked = !registro.ES_RECURSO_INVITRO.Value;
                    }
                    txtRecursoAdicionalInvitro.Text = registro.OBS_ES_RECURSO_INVITRO;
                    if (registro.ES_AGENTE_BIOLOGICO.HasValue)
                    {
                        rdAgenteBioAdicionalSi.Checked = registro.ES_AGENTE_BIOLOGICO.Value;
                        rdAgenteBioAdicionalNo.Checked = !registro.ES_AGENTE_BIOLOGICO.Value;
                    }
                    txtRecursoAdicionalAgebio.Text = registro.OBS_ES_AGENTE_BIOLOGICO;
                    if (registro.ES_PRODCUTO_BIOLOGICO.HasValue)
                    {
                        rdproductoBioAdicionalSi.Checked = registro.ES_PRODCUTO_BIOLOGICO.Value;
                        rdproductoBioAdicionalNo.Checked = !registro.ES_PRODCUTO_BIOLOGICO.Value;
                    }
                    txtRecursoAdicionalAgeproducto.Text = registro.OBS_ES_PRODCUTO_BIOLOGICO;
                    if (registro.ES_OTRO_RECURSO_ADICIONAL.HasValue)
                    {
                        rdAdicionalOtroSi.Checked = registro.ES_OTRO_RECURSO_ADICIONAL.Value;
                        rdAdicionalOtroNo.Checked = !registro.ES_OTRO_RECURSO_ADICIONAL.Value;
                    }
                    txtOtroAdicional.Text = registro.OBS_ES_OTRO_RECURSO_ADICIONAL;
                    txtComparador.Text = registro.NOMBRE_COMPARADOR;
                    txtCodigoATCComparador.Text = registro.CODIGO_ATC_COMPARADOR;
                    txtCoberturaPbsupc.Text = registro.COBERTURA;
                    if (registro.ADJUNTA_EVIDENCIA.HasValue)
                    {
                        chkAdjuntaEvidenciaSi.Checked = registro.ADJUNTA_EVIDENCIA.Value;

                        chkAdjuntaEvidenciaNo.Checked = !registro.ADJUNTA_EVIDENCIA.Value;
                    }
                    txtObservacionesAdicional.Text = registro.OBS_EVIDENCIA;

                    archivo = registro.ARCHIVO_EVIDENCIA;
                    if (archivo.Contains("files"))
                    {
                        archivo = archivo.Substring(archivo.IndexOf("files"));
                        archivo = "~/" + archivo;
                    }
                    lnkArchivo4.HRef = archivo;

                    if (registro.CONFLICTO_SI.HasValue)
                    {
                        chkConflictoInteres.Checked = registro.CONFLICTO_SI.Value;
                        chkNoConflictoInteres.Checked = !registro.CONFLICTO_SI.Value;
                    }

                    txtConflicto.Text = registro.OBS_CONFLICTO;

                    archivo = registro.ULR_FORMATO4;
                    if (archivo.Contains("files"))
                    {
                        archivo = archivo.Substring(archivo.IndexOf("files"));
                        archivo = "~/" + archivo;
                    }
                    lnkArchivo6.HRef = archivo;

                    archivo = registro.URL_FORMATO5;
                    if (archivo.Contains("files"))
                    {
                        archivo = archivo.Substring(archivo.IndexOf("files"));
                        archivo = "~/" + archivo;
                    }
                    lnkArchivo7.HRef = archivo;

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
                    if (lnkArchivo4.HRef != string.Empty)
                    {
                        lnkArchivo4.HRef = url + lnkArchivo4.HRef.Replace("~", "").Replace(@"\", @"/");
                        lnkArchivo4.InnerHtml = "Archivo cargado";
                    }

                    if (lnkArchivo6.HRef != string.Empty)
                    {
                        lnkArchivo6.HRef = url + lnkArchivo6.HRef.Replace("~", "").Replace(@"\", @"/");
                        lnkArchivo6.InnerHtml = "Archivo cargado";
                    }
                    if (lnkArchivo7.HRef != string.Empty)
                    {
                        lnkArchivo7.HRef = url + lnkArchivo7.HRef.Replace("~", "").Replace(@"\", @"/");
                        lnkArchivo7.InnerHtml = "Archivo cargado";
                    }
                    if (frm3 != null)
                    {
                        if (frm3.COD_TIPO_NOMINACION_MEDICAMENTO.HasValue)
                            cmbTipoNominacionMedicamento.SelectedValue = frm3.COD_TIPO_NOMINACION_MEDICAMENTO.Value.ToString();

                        txtObstipoTecnologia.Text = frm3.OBS_TIPO_NOMINACION_MEDICAMENTO;
                        txtNumCasasFarmaceuticas.Text = frm3.NumCasasFarmaceuticas;
                        txtNumAnosMedicamento.Text = frm3.NumAnosMedicamento;
                        txtCodCumMedicamento.Text = frm3.CodCumMedicamento;
                        txtDosisPediatraMedicamentos.Text = frm3.DosisPediatraMedicamentos;
                        txtDosisAdultosMedicamentos.Text = frm3.DosisAdultosMedicamentos;
                        txtIndicacionMedicamento.Text = frm3.IndicacionMedicamento;
                        txtPrecioPorFormaFarma.Text = frm3.PrecioPorFormaFarma;
                        txtPrecioPorConcentracion.Text = frm3.PrecioPorConcentracion;
                        txtPrecioPorPresentacion.Text = frm3.PrecioPorPresentacion;
                        txtValorCOPMedicamento.Text = frm3.ValorCOPMedicamento;
                        txtUnidadMedidaMedicamento.Text = frm3.UnidadMedidaMedicamento;
                        if (frm3.ReaccionesAdversasSI.HasValue)
                        {
                            chkReaccionesAdversas.Checked = frm3.ReaccionesAdversasSI.Value;
                        }
                        txtReaccionesAdversas.Text = frm3.OBSReaccionesAdversas;
                        if (frm3.Contraindicaciones.HasValue)
                            chkReaccionesAdversas.Checked = frm3.Contraindicaciones.Value;
                        txtReaccionesAdversas.Text = frm3.OBSContraindicaciones;
                        if (frm3.AdvertenciasPrecauciones.HasValue)
                            chkAdvertenciasPrecauciones.Checked = frm3.AdvertenciasPrecauciones.Value;
                        txtAdvertenciasPrecauciones.Text = frm3.OSBAdvertenciasPrecauciones;
                        if (frm3.Interacciones.HasValue)
                            chkInteracciones.Checked = frm3.Interacciones.Value;
                        txtInteracciones.Text = frm3.OBSInteracciones;
                        if (frm3.Interrupcion.HasValue)
                            chkInterrupcion.Checked = frm3.Interrupcion.Value;
                        txtInterrupcion.Text = frm3.OSBInterrupcion;
                        if (frm3.ListadoEscencialesSi.HasValue)
                        {
                            rdListadoEscencialesSi.Checked = frm3.ListadoEscencialesSi.Value;
                            rdListadoEscencialesNo.Checked = !frm3.ListadoEscencialesSi.Value;
                        }
                        txtObservacionesListadoEscencial.Text = frm3.ObservacionesListadoEscencial;
                        txtNombreGPCMedicamento.Text = frm3.NombreGPCMedicamento;
                        txtRecomendacionMedicamentoGPC.Text = frm3.RecomendacionMedicamentoGPC;
                        txtGradoRecomendacionMedicamentoGPC.Text = frm3.GradoRecomendacionMedicamentoGPC;
                        if (frm3.NuevoProcedimientoSi.HasValue)
                        {
                            rdNuevoProcedimientoSi.Checked = frm3.NuevoProcedimientoSi.Value;
                            rdNuevoProcedimientoNo.Checked = !frm3.NuevoProcedimientoSi.Value;
                        }
                        txtObservacionesNuevoProcedimiento.Text = frm3.ObservacionesNuevoProcedimiento;
                        txtIpsREalizanProcedimiento.Text = frm3.IpsREalizanProcedimiento;
                        txtNumAnosProcedimento.Text = frm3.NumAnosProcedimento;
                        txtFrecuenciaProcedimiento.Text = frm3.FrecuenciaProcedimiento;
                        txtFrecuenciaAplicacionProcedimiento.Text = frm3.FrecuenciaAplicacionProcedimiento;
                        txtDuracionProcedimiento.Text = frm3.DuracionProcedimiento;
                        txtPrecioDuracionProcedimiento.Text = frm3.PrecioDuracionProcedimiento;
                        txtNombreGPCProcedimiento.Text = frm3.NombreGPCProcedimiento;
                        txtRecomendacionProcedimientoGPC.Text = frm3.RecomendacionProcedimientoGPC;
                        txtGradoRecomendacionProcedimientoGPC.Text = frm3.GradoRecomendacionProcedimientoGPC;
                        txtdesenlacesProcedimiento.Text = frm3.desenlacesProcedimiento;
                        txtResultadosSeguridadProcedimiento.Text = frm3.ResultadosSeguridadProcedimiento;
                        txtTamanoPoblacion.Text = frm3.TamanoPoblacion;
                        txtTamanoPoblacionColombiana.Text = frm3.TamanoPoblacionColombiana;
                        txtRElacionTsnCArgaEnfermedad.Text = frm3.RElacionTsnCArgaEnfermedad;
                        txtBeneficios.Text = frm3.Beneficios;
                        if (frm3.TSNReduceMortalidadSi.HasValue)
                        {
                            rdTSNReduceMortalidadSi.Checked = frm3.TSNReduceMortalidadSi.Value;
                            rdTSNReduceMortalidadNo.Checked = !frm3.TSNReduceMortalidadSi.Value;
                        }
                        txtTSNReduceMortalidad.Text = frm3.OBSTSNReduceMortalidad;
                        if (frm3.TSNMejoraDiscapacidadSi.HasValue)
                        {
                            rdTSNMejoraDiscapacidadSi.Checked = frm3.TSNMejoraDiscapacidadSi.Value;
                            rdTSNMejoraDiscapacidadNo.Checked = !frm3.TSNMejoraDiscapacidadSi.Value;
                        }
                        txtTSNMejoraDiscapacidad.Text = frm3.OBSTSNMejoraDiscapacidadSi;




                    }


                    #endregion

                    if (Request["obs"] != null)
                    {
                        #region habilitamos o dehsbilitamos los paneles de validacion
                        pnlValidacionGeneral.Visible = true;
                        #endregion
                    }
                }
            }

        }

        /// <summary>
        /// Manejador del evento clic del botón "Guardar y Continuar". 
        /// Verifica si el usuario ha iniciado sesión antes de realizar la operación.
        /// Realiza la validación antes de guardar y luego guarda y envía la información.
        /// </summary>
        /// <param name="sender">El objeto que genera el evento (botón "Guardar y Continuar").</param>
        /// <param name="e">Los datos del evento.</param>
        protected void btnGuardarContinuar_Click(object sender, EventArgs e)
        {
            // Verifica si el usuario ha iniciado sesión al comprobar si la variable de sesión "SS_NOMBRE_USUARIO" es nula o vacía.
            if (Session["SS_NOMBRE_USUARIO"] == null || Session["SS_NOMBRE_USUARIO"].ToString() == string.Empty)
            {
                // Si el usuario no ha iniciado sesión, muestra un mensaje y sale del método.
                LblValidacionCampos.Text = "Sesión finalizada. Por favor, ingrese nuevamente su usuario y contraseña.";
                return;
            }

            // Realiza la validación antes de proceder con el guardado.
            if (validar())
            {
                try
                {
                    // Guarda la información.
                    guardar();

                    // Envía la información.
                    enviar();
                }
                catch (DbEntityValidationException ex2)
                {
                    // Maneja las excepciones específicas de validación de entidades.
                    string error = "";
                    foreach (var eve in ex2.EntityValidationErrors)
                    {
                        error += string.Format("Error temporal en el servidor. Entidad \"{0}\" en estado \"{1}\" tiene los siguientes errores de validación:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            error += string.Format(" - Propiedad: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }

                    Desktop.Logging.Logger.Write(ex2);
                    if (ex2.InnerException != null)
                    {
                        Desktop.Logging.Logger.Write(ex2.InnerException);
                    }

                    foreach (var validationErrors in ex2.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            string message = string.Format("{0}:{1}", validationErrors.Entry.Entity.ToString(), validationError.ErrorMessage);
                            //raise a new exception inserting the current one as the InnerException
                            Desktop.Logging.Logger.Write(message);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Maneja otras excepciones generales.
                    LblValidacionCampos.Text = "Ocurrió un problema al guardar la nominación. Recuerde que los campos de texto deben tener como máximo 4000 caracteres. " + ex.Message;
                }
            }
        }


        /// <summary>
        /// Manejador del evento clic del botón de guardar. 
        /// Verifica si el usuario ha iniciado sesión antes de realizar la operación de guardar.
        /// </summary>
        /// <param name="sender">El objeto que genera el evento (botón de guardar).</param>
        /// <param name="e">Los datos del evento.</param>
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            // Verifica si el usuario ha iniciado sesión al comprobar si la variable de sesión "SS_NOMBRE_USUARIO" es nula o vacía.
            if (Session["SS_NOMBRE_USUARIO"] == null || Session["SS_NOMBRE_USUARIO"].ToString() == string.Empty)
            {
                // Si el usuario no ha iniciado sesión, muestra un mensaje y sale del método.
                LblValidacionCampos.Text = "Sesión finalizada. Por favor, ingrese nuevamente su usuario y contraseña.";
                return;
            }

            // Si el usuario ha iniciado sesión, llama al método 'guardar'.
            guardar();
        }


        private bool validar()
        {
            bool error = false;
            LblValidacionCampos.Text = "";
            LblValidacionCampos.Text += "Verifique los Siguientes Campos: ";

            txtCartaPresentacion.CssClass = "form-control";
            if (txtCartaPresentacion.Text == "")
            {
                error = true;
                LblValidacionCampos.Text += "Carta de presentación, ";
                txtCartaPresentacion.CssClass = "form-control errormin";
            }

            fldRelacionTsn.Attributes["class"] = "";
            if (!chkAcondicionador.Checked && !chkPrestadorServicio.Checked
              && !chkUsuarioTecnologia.Checked && !chkRelacionOtro.Checked
               && !chkImportador.Checked && !chkFabricante.Checked && !chkTitularRegistro.Checked)
            {
                error = true;
                LblValidacionCampos.Text += "Relación del nominador con la TSN.  ";
                fldRelacionTsn.Attributes["class"] = "errormin";
            }



            #region nombre tecnologia

            fldTipoTEcnologia.Attributes["class"] = "";
            if (!rdMedicamento.Checked
              && !rdProcedimiento.Checked
              && !rdDispositivoMedico.Checked
              && !rdOtro.Checked
             )
            {
                error = true;
                LblValidacionCampos.Text += "Información de la tecnología propuesta.  ";
                fldTipoTEcnologia.Attributes["class"] = "errormin";
            }

            txtNombreTecnologia.CssClass = "form-control";
            if (txtNombreTecnologia.Text == "")
            {
                error = true;
                LblValidacionCampos.Text += "Nombre de la tecnologia, ";
                txtNombreTecnologia.CssClass = "form-control errormin";
            }

            txtIndicacionUsoTecnologia.CssClass = "form-control";
            if (txtIndicacionUsoTecnologia.Text == "")
            {
                error = true;
                LblValidacionCampos.Text += "Indicación de uso de la tecnología propuesta, ";
                txtIndicacionUsoTecnologia.CssClass = "form-control errormin";
            }


            txtEnfermedad.CssClass = "form-control";
            if (txtEnfermedad.Text == "")
            {
                error = true;
                LblValidacionCampos.Text += "CIE-10, ";
                txtEnfermedad.CssClass = "form-control errormin";
            }


            #endregion




            if (rdMedicamento.Checked)
            {
                txtPrincipioActivo.CssClass = "form-control";
                if (txtPrincipioActivo.Text.Trim() == string.Empty)
                {
                    LblValidacionCampos.Text += "Principio activo.  ";
                    txtPrincipioActivo.CssClass = "form-control errormin";
                }
                txtCodigoATC.CssClass = "form-control";
                if (txtCodigoATC.Text.Trim() == string.Empty)
                {
                    LblValidacionCampos.Text += "Codigo ATC.  ";
                    txtCodigoATC.CssClass = "form-control errormin";
                }
                txtFormaFarmaceutica.CssClass = "form-control";
                if (txtFormaFarmaceutica.Text.Trim() == string.Empty)
                {
                    LblValidacionCampos.Text += "Forma farmacéutica.  ";
                    txtFormaFarmaceutica.CssClass = "form-control errormin";
                }
                txtConcentracion.CssClass = "form-control";
                if (txtConcentracion.Text.Trim() == string.Empty)
                {
                    LblValidacionCampos.Text += "Concentración.  ";
                    txtConcentracion.CssClass = "form-control errormin";
                }
                txtViaAdministracion.CssClass = "form-control";
                if (txtViaAdministracion.Text.Trim() == string.Empty)
                {
                    LblValidacionCampos.Text += "Vía de administración.  ";
                    txtViaAdministracion.CssClass = "form-control errormin";
                }

                txtRegistroSanitario.CssClass = "form-control";
                if (txtRegistroSanitario.Text.Trim() == string.Empty)
                {
                    LblValidacionCampos.Text += "Registro Sanitario.  ";
                    txtRegistroSanitario.CssClass = "form-control errormin";
                }

            }
            if (rdProcedimiento.Checked)
            {
                txtCupsAjuste.CssClass = "form-control";
                if (txtCupsAjuste.Text.Trim() == string.Empty)
                {
                    LblValidacionCampos.Text += "Código CUPS.  ";

                    txtCupsAjuste.CssClass = "form-control errormin";
                }
                txtIndicionesProcedimiento.CssClass = "form-control";
                if (txtIndicionesProcedimiento.Text.Trim() == string.Empty)
                {
                    LblValidacionCampos.Text += "Indicaciones diferentes a la propuesta.  ";

                    txtIndicionesProcedimiento.CssClass = "form-control errormin";
                }
            }
            if (rdDispositivoMedico.Checked)
            {
                txtIndicionesDispositivo.CssClass = "form-control";
                if (txtIndicionesDispositivo.Text.Trim() == string.Empty)
                {
                    LblValidacionCampos.Text += "Indicaciones del dispositivo.  ";

                    txtIndicionesDispositivo.CssClass = "form-control errormin";
                }
            }
            fldFinalidadProcedimiento.Attributes["class"] = "";
            if (!chkPrimeraLinea.Checked
              && !chkSegundaLinea.Checked
              && !chkTerceraLinea.Checked
              && !chkUsocotidiano.Checked
              && !chkOtroImportacia.Checked
             )
            {
                error = true;
                LblValidacionCampos.Text += "Importancia de la tecnología.  ";
                fldFinalidadProcedimiento.Attributes["class"] = "errormin";
            }
            txtObservacionesImportancia.CssClass = "form-control";

            if (chkOtroImportacia.Checked && txtObservacionesImportancia.Text.Trim() == string.Empty)
            {
                LblValidacionCampos.Text += "Importancia de la tecnología especifique el otro.  ";

                txtObservacionesImportancia.CssClass = "form-control errormin";
            }

            //
            Fieldsetpoblacionobj.Attributes["class"] = "";
            if (!chkObj0a1Mujer.Checked
              && !chkObj0a1Hombre.Checked
              && !chkObj1a4Mujer.Checked
              && !chkObj1a4Hombre.Checked
              && !chkObj5a14Mujer.Checked
              && !chkObj5a14Hombre.Checked
              && !chkObj15a28Mujer.Checked
              && !chkObj15a28Hombre.Checked
              && !chkObj19a29Mujer.Checked
              && !chkObj19a29Hombre.Checked
              && !chkObj30a44Mujer.Checked
              && !chkObj30a44Hombre.Checked
              && !chkObj45a59Mujer.Checked
              && !chkObj45a59Hombre.Checked
              && !chkObj60a69Mujer.Checked
              && !chkObj60a69Hombre.Checked
              && !chkObj70a79Mujer.Checked
              && !chkObj70a79Hombre.Checked
              && !chkObj80a100Mujer.Checked
              && !chkObj80a100Hombre.Checked)
            {
                error = true;
                LblValidacionCampos.Text += "Población objetivo de la tecnología.  ";
                Fieldsetpoblacionobj.Attributes["class"] = "errormin";
            }


            FieldsetEtapa.Attributes["class"] = "";
            if (
                !chkEtapaPromocionSalud.Checked
              && !chkEtapaPrevencionEnfermedad.Checked
              && !chkEtapaDiagnostico.Checked
              && !chkEtapaTratamiento.Checked
              && !chkEtapaRehabilitacion.Checked
              && !chkEtapaPaliacion.Checked
              && !chkEtapacosmetico.Checked)
            {
                error = true;
                LblValidacionCampos.Text += "Etapa del ciclo de atención.  ";
                FieldsetEtapa.Attributes["class"] = "errormin";
            }

            #region ventajas
            fldVEntajas.Attributes["class"] = "";
            if (!chkReduccionMortalidad.Checked
                && !chkReduccionMorbilidad.Checked
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
                LblValidacionCampos.Text += "El procedimiento cuenta con estudios de efectividad.  ";
            }
            if (chkEfectividadClinicaSi.Checked && lnkArchivo1.HRef == string.Empty)
            {
                error = true;
                LblValidacionCampos.Text += "adjunte el archivo de estudios de efectividad.  ";
            }

            if (!chkSeguridadClinicaSi.Checked
                && !chkSeguridadClinicaNo.Checked)
            {
                error = true; LblValidacionCampos.Text += "El procedimiento cuenta con estudios de seguridad.  ";
            }
            if (chkSeguridadClinicaSi.Checked && lnkArchivo2.HRef == string.Empty)
            {
                error = true;
                LblValidacionCampos.Text += "adjunte el archivo de estudios de seguridad.  ";
            }

            if (!chkEficaciaClinicaSi.Checked
                && !chkEficaciaClinicaNo.Checked)
            {
                error = true;
                LblValidacionCampos.Text += "El procedimiento cuenta con estudios de eficacia.  ";
            }
            if (chkEficaciaClinicaSi.Checked && lnkArchivo3.HRef == string.Empty)
            {
                error = true;
                LblValidacionCampos.Text += "adjunte el archivo de estudios de eficacia.  ";
            }
            if (!chkEvidenciaOtroSi.Checked
              && !chkEvidenciaOtroNo.Checked)
            {
                error = true;
                LblValidacionCampos.Text += "El procedimiento cuenta con otra evidencia cientifica.  ";
            }

            txtEvidenciaOtro.Attributes.Remove("placeholder");
            if (chkEvidenciaOtroSi.Checked && txtEvidenciaOtro.Text == string.Empty)
            {
                error = true;
                LblValidacionCampos.Text += "Enúncie la otra evidencia cientifica.  ";
                txtEvidenciaOtro.Attributes.Add("placeholder", "Relacione Nombre del recurso adicional del Medicamento");
                txtEvidenciaOtro.CssClass = "form-control errormin";
            }
            else
            {
                txtEvidenciaOtro.CssClass = "form-control ";
            }

            if (!chkPrestaExteriorSI.Checked && !chkPrestaExteriorNo.Checked)
            {
                error = true;
                LblValidacionCampos.Text += "La tecnología  se presta en el exterior?,  ";
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
            if (!rdInteresSaludSi.Checked && !rdInteresSaludNo.Checked)
            {
                error = true;
                LblValidacionCampos.Text += "la tecnología es de interes en salud pública? (Plan Decenal de Salud Pública 2012-2021),  ";
            }
            if (!rdMedicamentoAdicionalSi.Checked && !rdMedicamentoAdicionalNo.Checked)
            {
                error = true;
                LblValidacionCampos.Text += "Especifique Medicamentos del grupo recurso adicional,  ";
            }
            txtRecursoAdicionalMedicamento.Attributes.Remove("placeholder");

            if (rdMedicamentoAdicionalSi.Checked && txtRecursoAdicionalMedicamento.Text == string.Empty)
            {
                LblValidacionCampos.Text += "Relacione Nombre del recurso adicional del Medicamento,  ";
                txtRecursoAdicionalMedicamento.Attributes.Add("placeholder", "Relacione Nombre del recurso adicional del Medicamento");
                txtRecursoAdicionalMedicamento.CssClass = "form-control errormin";
            }
            else
            {
                txtRecursoAdicionalMedicamento.CssClass = "form-control ";
            }
            //--
            if (!rdDispositivoAdicionalSi.Checked && !rdDispositivoAdicionalNo.Checked)
            {
                error = true;
                LblValidacionCampos.Text += "Especifique Dispostivos del grupo recurso adicional,  ";
            }
            txtRecursoAdicionalDispositivo.Attributes.Remove("placeholder");

            if (rdDispositivoAdicionalSi.Checked && txtRecursoAdicionalDispositivo.Text == string.Empty)
            {
                LblValidacionCampos.Text += "Relacione Nombre del recurso adicional del Dispostivo,  ";
                txtRecursoAdicionalDispositivo.Attributes.Add("placeholder", "Relacione Nombre del recurso adicional del Dispostivo");
                txtRecursoAdicionalDispositivo.CssClass = "form-control errormin";
            }
            else
            {
                txtRecursoAdicionalDispositivo.CssClass = "form-control";
            }

            if (!rdInVitroAdicionalSi.Checked && !rdInVitroAdicionalNo.Checked)
            {
                error = true;
                LblValidacionCampos.Text += "Especifique Reactivo In Vitro del grupo recurso adicional,  ";
            }
            txtRecursoAdicionalInvitro.Attributes.Remove("placeholder");

            if (rdInVitroAdicionalSi.Checked && txtRecursoAdicionalInvitro.Text == string.Empty)
            {
                LblValidacionCampos.Text += "Relacione Nombre del recurso adicional del Reactivo In Vitroo,  ";
                txtRecursoAdicionalInvitro.Attributes.Add("placeholder", "Relacione Nombre del recurso adicional del Reactivo In Vitro");
                txtRecursoAdicionalInvitro.CssClass = "form-control errormin";
            }
            else
            {
                txtRecursoAdicionalInvitro.CssClass = "form-control";
            }


            if (!rdAgenteBioAdicionalSi.Checked && !rdAgenteBioAdicionalNo.Checked)
            {
                error = true;
                LblValidacionCampos.Text += "Especifique Agente Biológico del grupo recurso adicional,  ";
            }

            txtRecursoAdicionalAgebio.Attributes.Remove("placeholder");
            if (rdAgenteBioAdicionalSi.Checked && txtRecursoAdicionalAgebio.Text == string.Empty)
            {
                LblValidacionCampos.Text += "Relacione Nombre del recurso adicional del Agente Biológico,  ";
                txtRecursoAdicionalAgebio.Attributes.Add("placeholder", "Relacione Nombre del recurso adicional del Agente Biológico");
                txtRecursoAdicionalAgebio.CssClass = "form-control errormin";
            }
            else
            {
                txtRecursoAdicionalAgebio.CssClass = "form-control";
            }

            if (!rdproductoBioAdicionalSi.Checked && !rdproductoBioAdicionalNo.Checked)
            {
                error = true;
                LblValidacionCampos.Text += "Especifique Producto Biológico del grupo recurso adicional,  ";
            }
            txtRecursoAdicionalAgeproducto.Attributes.Remove("placeholder");
            if (rdproductoBioAdicionalSi.Checked && txtRecursoAdicionalAgeproducto.Text == string.Empty)
            {
                LblValidacionCampos.Text += "Relacione Nombre del recurso adicional del Producto Biológico,  ";
                txtRecursoAdicionalAgeproducto.Attributes.Add("placeholder", "Relacione Nombre del recurso adicional del Producto Biológico");
                txtRecursoAdicionalAgeproducto.CssClass = "form-control errormin";
            }
            else
            {
                txtRecursoAdicionalAgeproducto.CssClass = "form-control";
            }

            if (!rdAdicionalOtroSi.Checked && !rdAdicionalOtroNo.Checked)
            {
                error = true;
                LblValidacionCampos.Text += "Especifique si es otro recurso adicional,  ";
            }
            txtOtroAdicional.Attributes.Remove("placeholder");
            if (rdOtro.Checked && txtOtroAdicional.Text == string.Empty)
            {
                LblValidacionCampos.Text += "Relacione el otro recurso adicional,  ";
                txtOtroAdicional.Attributes.Add("placeholder", "relacione el otro recurso adicional");
                txtOtroAdicional.CssClass = "form-control errormin";
            }
            else
            {
                txtOtroAdicional.CssClass = "form-control";
            }
            //-----
            if (!chkAdjuntaEvidenciaSi.Checked && !chkAdjuntaEvidenciaNo.Checked)
            {
                error = true;
                LblValidacionCampos.Text += "Debe seleccionar si adjunta evidencia,  ";
            }

            if (chkAdjuntaEvidenciaSi.Checked && lnkArchivo4.HRef == string.Empty)
            {
                error = true;
                LblValidacionCampos.Text += "Debe adjuntar  la evidencia,  ";

            }

            if (!chkConflictoInteres.Checked && !chkNoConflictoInteres.Checked)
            {
                error = true;
                LblValidacionCampos.Text += "Debe seleccionar si tiene conflicto de intereses,  ";
            }
            txtConflicto.Attributes.Remove("placeholder");
            if (chkConflictoInteres.Checked && txtConflicto.Text.Trim() == string.Empty)
            {
                txtConflicto.CssClass = "";
                txtConflicto.Attributes.Remove("placeholder");
                LblValidacionCampos.Text += "Relacione el conflicto de interes,  ";
                txtConflicto.Attributes.Add("placeholder", "Debe relacionar el conflicto de interes");
                txtConflicto.CssClass = "form-control errormin";
            }
            else
            {
                txtConflicto.CssClass = "form-control";

            }
            //si es ua sociedad cientifica debe adjuntar el formato 3 4 5
            clsNegocio c = new clsNegocio();
            var reg = c.obtenerRegistroxCodigo(int.Parse(Session["SS_COD_REGISTRO"].ToString()));
            if (reg.COD_TIPO_JURIDICO.HasValue)
            {
                if (reg.COD_TIPO_JURIDICO == 8 || reg.COD_TIPO_JURIDICO == 9 || reg.COD_TIPO_JURIDICO == 10 || reg.COD_TIPO_JURIDICO == 11 || reg.COD_TIPO_JURIDICO == 12
                    || reg.COD_TIPO_JURIDICO == 13 || reg.COD_TIPO_JURIDICO == 14 || reg.COD_TIPO_JURIDICO == 15
                      || reg.COD_TIPO_JURIDICO == 16 || reg.COD_TIPO_JURIDICO == 17 || reg.COD_TIPO_JURIDICO == 18
                        || reg.COD_TIPO_JURIDICO == 19 || reg.COD_TIPO_JURIDICO == 20 || reg.COD_TIPO_JURIDICO == 21
                          || reg.COD_TIPO_JURIDICO == 37)
                {
                    //validamos todos los campos del formulario 3
                    if (rdMedicamento.Checked)
                    {
                        #region zona de medicamentos
                        if (cmbTipoNominacionMedicamento.SelectedValue == null || cmbTipoNominacionMedicamento.SelectedValue == string.Empty ||
                            cmbTipoNominacionMedicamento.SelectedValue == "-1")
                        {
                            error = true;
                            LblValidacionCampos.Text += "opción acorde al medicamento propuesto de la lista desplegable,  ";

                            cmbTipoNominacionMedicamento.CssClass = "form-control errormin";
                        }
                        else
                        {
                            cmbTipoNominacionMedicamento.CssClass = "form-control";
                        }
                        //-------
                        txtObstipoTecnologia.CssClass = "form-control";
                        if (txtObstipoTecnologia.Text.Trim() == string.Empty)
                        {
                            LblValidacionCampos.Text += "Observaciones del medicamento propuesto de la lista desplegable,  ";
                            txtObstipoTecnologia.CssClass = "form-control errormin";
                        }
                        //-------
                        txtNumCasasFarmaceuticas.CssClass = "form-control";
                        if (txtNumCasasFarmaceuticas.Text.Trim() == string.Empty)
                        {
                            LblValidacionCampos.Text += "cuantas casas farmacéuticas comercializan el principio activo,  ";
                            txtNumCasasFarmaceuticas.CssClass = "form-control errormin";
                        }
                        //-------
                        txtNumAnosMedicamento.CssClass = "form-control";
                        if (txtNumAnosMedicamento.Text.Trim() == string.Empty)
                        {
                            LblValidacionCampos.Text += "Número de años que lleva comercializando el medicamento en Colombia,  ";
                            txtNumAnosMedicamento.CssClass = "form-control errormin";
                        }
                        //-------
                        txtCodCumMedicamento.CssClass = "form-control";
                        if (txtCodCumMedicamento.Text.Trim() == string.Empty)
                        {
                            LblValidacionCampos.Text += "Códigos CUM correspondientes al laboratorio que nomina el medicamento, separando cada código CUM ";
                            txtCodCumMedicamento.CssClass = "form-control errormin";
                        }
                        //-------
                        txtDosisPediatraMedicamentos.CssClass = "form-control";
                        if (txtDosisPediatraMedicamentos.Text.Trim() == string.Empty)
                        {
                            LblValidacionCampos.Text += "Pediatría, ";
                            txtDosisPediatraMedicamentos.CssClass = "form-control errormin";
                        }
                        //-------
                        txtDosisAdultosMedicamentos.CssClass = "form-control";
                        if (txtDosisAdultosMedicamentos.Text.Trim() == string.Empty)
                        {
                            LblValidacionCampos.Text += "Adultos, ";
                            txtDosisAdultosMedicamentos.CssClass = "form-control errormin";
                        }
                        //-------
                        txtIndicacionMedicamento.CssClass = "form-control";
                        if (txtIndicacionMedicamento.Text.Trim() == string.Empty)
                        {
                            LblValidacionCampos.Text += "Registre para la indicación objeto de la solicitud, ";
                            txtIndicacionMedicamento.CssClass = "form-control errormin";
                        }
                        //-------
                        txtPrecioPorFormaFarma.CssClass = "form-control";
                        if (txtPrecioPorFormaFarma.Text.Trim() == string.Empty)
                        {
                            LblValidacionCampos.Text += "Precio por forma farmacéutica, ";
                            txtPrecioPorFormaFarma.CssClass = "form-control errormin";
                        }
                        //-------
                        txtPrecioPorConcentracion.CssClass = "form-control";
                        if (txtPrecioPorConcentracion.Text.Trim() == string.Empty)
                        {
                            LblValidacionCampos.Text += "Precio por concentración, ";
                            txtPrecioPorConcentracion.CssClass = "form-control errormin";
                        }
                        //-------
                        txtPrecioPorPresentacion.CssClass = "form-control";
                        if (txtPrecioPorPresentacion.Text.Trim() == string.Empty)
                        {
                            LblValidacionCampos.Text += "Precio por presentación comercial asociada para cada CUM, ";
                            txtPrecioPorPresentacion.CssClass = "form-control errormin";
                        }
                        //-------
                        txtValorCOPMedicamento.CssClass = "form-control";
                        if (txtValorCOPMedicamento.Text.Trim() == string.Empty)
                        {
                            LblValidacionCampos.Text += "Valor total COP por tratamiento (por persona), ";
                            txtValorCOPMedicamento.CssClass = "form-control errormin";
                        }
                        //-------
                        txtUnidadMedidaMedicamento.CssClass = "form-control";
                        if (txtUnidadMedidaMedicamento.Text.Trim() == string.Empty)
                        {
                            LblValidacionCampos.Text += "Unidad de medida (Día, Mes, Año, Ciclo), ";
                            txtUnidadMedidaMedicamento.CssClass = "form-control errormin";
                        }
                        //--
                        if (!rdListadoEscencialesSi.Checked && !rdListadoEscencialesNo.Checked)
                        {
                            error = true;
                            LblValidacionCampos.Text += "si la tecnología hace parte del Listado de Medicamentos Esenciales de la OMS en caso afirmativo registre el número de la versión consultada en el campo observaciones,  ";
                        }
                        //-------
                        txtNombreGPCMedicamento.CssClass = "form-control";
                        if (txtNombreGPCMedicamento.Text.Trim() == string.Empty)
                        {
                            LblValidacionCampos.Text += "Nombre de la GPC, ";
                            txtNombreGPCMedicamento.CssClass = "form-control errormin";
                        }
                        //-------
                        txtRecomendacionMedicamentoGPC.CssClass = "form-control";
                        if (txtRecomendacionMedicamentoGPC.Text.Trim() == string.Empty)
                        {
                            LblValidacionCampos.Text += "Recomendación de la GPC, ";
                            txtRecomendacionMedicamentoGPC.CssClass = "form-control errormin";
                        }
                        //-------
                        txtGradoRecomendacionMedicamentoGPC.CssClass = "form-control";
                        if (txtGradoRecomendacionMedicamentoGPC.Text.Trim() == string.Empty)
                        {
                            LblValidacionCampos.Text += "Grado de recomendación de la GPC, ";
                            txtGradoRecomendacionMedicamentoGPC.CssClass = "form-control errormin";
                        }
                        #endregion
                    }
                    else if (rdProcedimiento.Checked)
                    {
                        #region zona de procedimiento
                        //--
                        if (!rdNuevoProcedimientoSi.Checked && !rdNuevoProcedimientoNo.Checked)
                        {
                            error = true;
                            LblValidacionCampos.Text += "¿El procedimiento nominado corresponde a una nueva indicación de un procedimiento ya cubierto en el Plan de Beneficios?,  ";
                        }
                        //-------
                        txtObservacionesNuevoProcedimiento.CssClass = "form-control";
                        if (txtObservacionesNuevoProcedimiento.Text.Trim() == string.Empty)
                        {
                            LblValidacionCampos.Text += "Observaciones nuevo procedimiento,  ";
                            txtObservacionesNuevoProcedimiento.CssClass = "form-control errormin";
                        }
                        //-------
                        txtIpsREalizanProcedimiento.CssClass = "form-control";
                        if (txtIpsREalizanProcedimiento.Text.Trim() == string.Empty)
                        {
                            LblValidacionCampos.Text += "¿cuáles IPS realizan el procedimiento actualmente en Colombia?,  ";
                            txtIpsREalizanProcedimiento.CssClass = "form-control errormin";
                        }
                        //-------
                        txtNumAnosProcedimento.CssClass = "form-control";
                        if (txtNumAnosProcedimento.Text.Trim() == string.Empty)
                        {
                            LblValidacionCampos.Text += "¿Número de años que lleva siendo utilizado el procedimiento nominado en Colombia?,  ";
                            txtNumAnosProcedimento.CssClass = "form-control errormin";
                        }
                        //-------
                        txtFrecuenciaProcedimiento.CssClass = "form-control";
                        if (txtFrecuenciaProcedimiento.Text.Trim() == string.Empty)
                        {
                            LblValidacionCampos.Text += "Indique la frecuencia de aplicación del procedimiento en un paciente ,  ";
                            txtFrecuenciaProcedimiento.CssClass = "form-control errormin";
                        }
                        //-------
                        txtFrecuenciaAplicacionProcedimiento.CssClass = "form-control";
                        if (txtFrecuenciaAplicacionProcedimiento.Text.Trim() == string.Empty)
                        {
                            LblValidacionCampos.Text += "Indique la frecuencia de aplicación del procedimiento en un paciente ,  ";
                            txtFrecuenciaAplicacionProcedimiento.CssClass = "form-control errormin";
                        }
                        //-------
                        txtDuracionProcedimiento.CssClass = "form-control";
                        if (txtDuracionProcedimiento.Text.Trim() == string.Empty)
                        {
                            LblValidacionCampos.Text += "Indique la duración del procedimiento ,  ";
                            txtDuracionProcedimiento.CssClass = "form-control errormin";
                        }
                        //-------
                        txtPrecioDuracionProcedimiento.CssClass = "form-control";
                        if (txtPrecioDuracionProcedimiento.Text.Trim() == string.Empty)
                        {
                            LblValidacionCampos.Text += "Indique el precio de la realización del  procedimiento ,  ";
                            txtPrecioDuracionProcedimiento.CssClass = "form-control errormin";
                        }
                        //-------
                        txtNombreGPCProcedimiento.CssClass = "form-control";
                        if (txtNombreGPCProcedimiento.Text.Trim() == string.Empty)
                        {
                            LblValidacionCampos.Text += "Nombre de la GPC ,  ";
                            txtNombreGPCProcedimiento.CssClass = "form-control errormin";
                        }
                        //-------
                        txtRecomendacionProcedimientoGPC.CssClass = "form-control";
                        if (txtRecomendacionProcedimientoGPC.Text.Trim() == string.Empty)
                        {
                            LblValidacionCampos.Text += "Recomendación de la GPC ,  ";
                            txtRecomendacionProcedimientoGPC.CssClass = "form-control errormin";
                        }
                        //-------
                        txtGradoRecomendacionProcedimientoGPC.CssClass = "form-control";
                        if (txtGradoRecomendacionProcedimientoGPC.Text.Trim() == string.Empty)
                        {
                            LblValidacionCampos.Text += "Grado de recomendación de la GPC ,  ";
                            txtGradoRecomendacionProcedimientoGPC.CssClass = "form-control errormin";
                        }
                        //-------
                        txtdesenlacesProcedimiento.CssClass = "form-control";
                        if (txtdesenlacesProcedimiento.Text.Trim() == string.Empty)
                        {
                            LblValidacionCampos.Text += "Describa los desenlaces esperados con el uso de la TSN ,  ";
                            txtdesenlacesProcedimiento.CssClass = "form-control errormin";
                        }
                        //-------
                        txtdesenlacesProcedimiento.CssClass = "form-control";
                        if (txtdesenlacesProcedimiento.Text.Trim() == string.Empty)
                        {
                            LblValidacionCampos.Text += "Describa los desenlaces esperados con el uso de la TSN ,  ";
                            txtdesenlacesProcedimiento.CssClass = "form-control errormin";
                        }
                        #endregion
                    }

                    #region zona de vlidaciones de formulario 3
                    //-------
                    txtTamanoPoblacion.CssClass = "form-control";
                    if (txtTamanoPoblacion.Text.Trim() == string.Empty)
                    {
                        LblValidacionCampos.Text += "Tamaño de la población afectada con el problema de salud en la población colombiana ,  ";
                        txtTamanoPoblacion.CssClass = "form-control errormin";
                    }
                    //-------
                    txtTamanoPoblacionColombiana.CssClass = "form-control";
                    if (txtTamanoPoblacionColombiana.Text.Trim() == string.Empty)
                    {
                        LblValidacionCampos.Text += "Tamaño de la población colombiana que  se beneficia con el uso de la TSN ,  ";
                        txtTamanoPoblacionColombiana.CssClass = "form-control errormin";
                    }
                    //-------
                    txtRElacionTsnCArgaEnfermedad.CssClass = "form-control";
                    if (txtRElacionTsnCArgaEnfermedad.Text.Trim() == string.Empty)
                    {
                        LblValidacionCampos.Text += "Describa la relación de la TSN con la carga de enfermedad para Colombia ,  ";
                        txtRElacionTsnCArgaEnfermedad.CssClass = "form-control errormin";
                    }
                    //-------
                    txtBeneficios.CssClass = "form-control";
                    if (txtBeneficios.Text.Trim() == string.Empty)
                    {
                        LblValidacionCampos.Text += "Describa los beneficios para el paciente con el uso de la TSN ,  ";
                        txtBeneficios.CssClass = "form-control errormin";
                    }

                    if (!rdTSNReduceMortalidadSi.Checked && !rdTSNReduceMortalidadNo.Checked)
                    {
                        error = true;
                        LblValidacionCampos.Text += "¿La TSN contribuye directamente a la reducción de la mortalidad?,  ";
                    }
                    if (rdTSNReduceMortalidadSi.Checked)
                    {
                        //-------
                        txtTSNReduceMortalidad.CssClass = "form-control";
                        if (txtTSNReduceMortalidad.Text.Trim() == string.Empty)
                        {
                            LblValidacionCampos.Text += "Describa los beneficios para el paciente con el uso de la TSN ,  ";
                            txtTSNReduceMortalidad.CssClass = "form-control errormin";
                        }
                    }
                    //--

                    if (!rdTSNMejoraDiscapacidadSi.Checked && !rdTSNMejoraDiscapacidadNo.Checked)
                    {
                        error = true;
                        LblValidacionCampos.Text += "La TSN contribuye directamente a la mejora de la condición de discapacidad?,  ";
                    }
                    if (rdTSNMejoraDiscapacidadSi.Checked)
                    {
                        //-------
                        txtTSNMejoraDiscapacidad.CssClass = "form-control";
                        if (txtTSNMejoraDiscapacidad.Text.Trim() == string.Empty)
                        {
                            LblValidacionCampos.Text += "Describa los beneficios para el paciente con el uso de la TSN ,  ";
                            txtTSNMejoraDiscapacidad.CssClass = "form-control errormin";
                        }
                    }
                    #endregion
                    if (lnkArchivo6.HRef == string.Empty)
                    {
                        error = true;
                        LblValidacionCampos.Text += "Debe adjuntar el formato 4,  ";
                    }

                    if (lnkArchivo7.HRef == string.Empty)
                    {
                        error = true;
                        LblValidacionCampos.Text += "Debe adjuntar el formato 5,  ";
                    }
                }
            }

            return !error;
        }
        /// <summary>
        /// Guarda la información del formulario de nominación UPC en la base de datos.
        /// </summary>
        private void enviar()
        {
            clsNegocio cls = new clsNegocio();
            var obj = cls.obtenerNOMINACION_PROCESOUPC(int.Parse(lblCodNominacionUPC.Text));
            //if (obj.COD_ESTADO_NOMINACION_RUPS <= 2)
            {
                // cls.enviarNominacion(int.Parse(lblCodNominacionUPC.Text), 2);
                Session["msgtitulo"] = "Gracias por completar su nominación";
                Session["msgmsg"] = @"Muchas gracias por su participación en el  " + obj.PROCESO.NOMBRE_PROCESO + @". Queremos informarle que su nominación ha sido recibida.
  <br>
<br>
<br>
Le comunicaremos oportunamente cualquier tipo de novedad con respecto a su nominación.
<br>
<br>
";
                clsWebUtils email = new clsWebUtils();
                string asunto = Session["msgtitulo"].ToString();

                string cuerpo = Session["msgmsg"].ToString();
                email.enviarEmail(asunto, cuerpo, Session["SS_CORREO"].ToString());

            }/*
            else
            {
                cls.enviarNominacion(int.Parse(lblCodNominacionProceso.Text), 2);
                Session["msgtitulo"] = "Gracias por actualizadar su nominación ";
                Session["msgmsg"] = @"Muchas gracias por su participación en el  " + obj.PROCESO.NOMBRE_PROCESO + @". Queremos informarle que su nominación ha sido recibida.
<br>
<br>
Le comunicaremos oportunamente cualquier tipo de novedad con respecto a su nominación.
<br>
<br>";

                clsWebUtils email = new clsWebUtils();
                string asunto = Session["msgtitulo"].ToString();

                string cuerpo = Session["msgmsg"].ToString();
                email.enviarEmail(asunto, cuerpo, Session["SS_CORREO"].ToString());
            }
            */
            Response.Redirect("~/frm/logica/frmMensajeIframe.aspx");
        }

        private void guardar()
        {

            clsNegocio cls = new clsNegocio();
            int? codN = null;
            if (lblCodNominacionUPC.Text.Trim() != string.Empty)
            {
                codN = int.Parse(lblCodNominacionUPC.Text);
            }
            int? COD_TIPO_PROCEDIMIENTO_UPC = null;
            int? COD_TIPO_DISPOSITIVO = null;
            int? COD_CLASIFICACION_RIESGO = null;
            if (rdProcedimiento.Checked)
            {
                if (cmbTipoProcedimiento.SelectedValue != string.Empty)
                    COD_TIPO_PROCEDIMIENTO_UPC = int.Parse(cmbTipoProcedimiento.SelectedValue);
            }
            if (rdDispositivoMedico.Checked)
            {
                if (cmbTipoDispositivo.SelectedValue != string.Empty)
                    COD_TIPO_DISPOSITIVO = int.Parse(cmbTipoDispositivo.SelectedValue);

                if (cmbClasificacionRiesgo.SelectedValue != string.Empty)
                    COD_CLASIFICACION_RIESGO = int.Parse(cmbClasificacionRiesgo.SelectedValue);


            }
            var i = 0;
            i = cls.guardarNominacionUPC(codN, int.Parse(Request.QueryString["codProceso"]), DateTime.Now,
            int.Parse(Session["SS_COD_REGISTRO"].ToString()),


txtCartaPresentacion.Text, txtNombreTecnologia.Text, txtNombreComercialTecnologia.Text,
txtIndicacionUsoTecnologia.Text, txtJustificacionPropuesta.Text, txtEnfermedad.Text, txtEnfermedad2.Text, txtEnfermedad3.Text,
rdMedicamento.Checked, rdProcedimiento.Checked, rdDispositivoMedico.Checked, rdOtro.Checked,
chkTitularRegistro.Checked, txtTitularRegistro.Text, chkFabricante.Checked, txtFabricante.Text,
chkImportador.Checked, txtImportador.Text, chkAcondicionador.Checked, txtAcondicionador.Text,
chkPrestadorServicio.Checked, txtPrestadorServicio.Text, chkUsuarioTecnologia.Checked, txtUsuarioTecnologia.Text,
chkRelacionOtro.Checked, txtRelacionOtro.Text, txtPrincipioActivo.Text, txtCodigoATC.Text, txtFormaFarmaceutica.Text,
txtConcentracion.Text, txtViaAdministracion.Text, txtOtraIndicacionesMedicamento.Text,
txtRegistroSanitario.Text, txtObservacionesMedicamento.Text, txtCupsAjuste.Text, txtIndicionesProcedimiento.Text,
 COD_TIPO_PROCEDIMIENTO_UPC, txtObservacionesProcedimientos.Text, txtRegistroSanitarioDispositivo.Text,
 COD_TIPO_DISPOSITIVO, COD_CLASIFICACION_RIESGO,
txtIndicionesDispositivo.Text,
 txtObservacionesDispositivo.Text, chkPrimeraLinea.Checked, "", chkSegundaLinea.Checked, "",
chkTerceraLinea.Checked, "", chkUsocotidiano.Checked, "", chkOtroImportacia.Checked,
 txtObservacionesImportancia.Text,

chkObj0a1Mujer.Checked, chkObj0a1Hombre.Checked, txtObj0a1.Text,
 chkObj1a4Mujer.Checked, chkObj1a4Hombre.Checked, txtObj1a4.Text,
 chkObj5a14Mujer.Checked, chkObj5a14Hombre.Checked, txtObj5a14.Text,
 chkObj15a28Mujer.Checked, chkObj15a28Hombre.Checked, txtObj15a28.Text,
 chkObj19a29Mujer.Checked, chkObj19a29Hombre.Checked, txtObj19a29.Text,
 chkObj30a44Mujer.Checked, chkObj30a44Hombre.Checked, txtObj30a44.Text,
 chkObj45a59Mujer.Checked, chkObj45a59Hombre.Checked, txtObj45a59.Text,
chkObj60a69Mujer.Checked, chkObj60a69Hombre.Checked, txtObj60a69.Text,
 chkObj70a79Mujer.Checked, chkObj70a79Hombre.Checked, txtObj70a79.Text,
chkObj80a100Mujer.Checked, chkObj80a100Hombre.Checked, txtObj80a100.Text,
chkEtapaPromocionSalud.Checked, "",

chkEtapaPrevencionEnfermedad.Checked, "",
chkEtapaDiagnostico.Checked, "", chkEtapaTratamiento.Checked,
  "", chkEtapaRehabilitacion.Checked, "", chkEtapaPaliacion.Checked, "",
chkEtapacosmetico.Checked, "", int.Parse(cmbAmbitoUso.SelectedValue),
chkReduccionMortalidad.Checked, txtReduccionMortalidad.Text,
chkReduccionMorbilidad.Checked, txtReduccionMorbilidad.Text, chkReduccionHospitalaria.Checked, txtReduccionHospitalaria.Text,
chkMejoraCalidadVida.Checked, txtMejoraCalidadVida.Text, chkVentajaOtro.Checked, txtVentajaOtro.Text,
chkEfectividadClinicaSi.Checked, lnkArchivo1.HRef,

chkSeguridadClinicaSi.Checked, lnkArchivo2.HRef,
chkEficaciaClinicaSi.Checked, lnkArchivo3.HRef,
chkEvidenciaOtroSi.Checked, txtEvidenciaOtro.Text, chkPrestaExteriorSI.Checked, txtObservacionPrestaExterior.Text,
txtNombreGPC.Text, txtRecomendacionGPC.Text,
rdInfaciaSi.Checked, txtRelevanteInfancia.Text, rdEmbarazoSi.Checked, txtRelevanteEmbarazo.Text,
rdDesplazadosSi.Checked, txtRelevanteDesplazados.Text,
rdViolenciaSi.Checked, txtRelevanteViolencia.Text,
rdAdultosMayoresSi.Checked, txtRelevanteAdultosMayores.Text, rdAlgunaDiscapacidadSi.Checked, txtRelevanteAlgunaDiscapacidad.Text,
rdHurefanasSi.Checked, txtRelevanteHuerfanas.Text, rdInteresSaludSi.Checked,
txtObservacionesInteresSalud.Text,
rdMedicamentoAdicionalSi.Checked,
  txtRecursoAdicionalMedicamento.Text, rdDispositivoAdicionalSi.Checked,
  txtRecursoAdicionalDispositivo.Text, rdInVitroAdicionalSi.Checked,
txtRecursoAdicionalInvitro.Text, rdAgenteBioAdicionalSi.Checked, txtRecursoAdicionalAgebio.Text,
rdproductoBioAdicionalSi.Checked, txtRecursoAdicionalAgeproducto.Text,
rdAdicionalOtroSi.Checked, txtOtroAdicional.Text,

txtComparador.Text, txtCodigoATCComparador.Text, txtCoberturaPbsupc.Text,
 chkAdjuntaEvidenciaSi.Checked, txtObservacionesAdicional.Text, lnkArchivo4.HRef, chkConflictoInteres.Checked, txtConflicto.Text,
  "", lnkArchivo6.HRef, lnkArchivo7.HRef);

            //guardamos el formulario 3
            int? COD_TIPO_NOMINACION_MEDICAMENTO = null;
            if (rdMedicamento.Checked)
            {
                COD_TIPO_NOMINACION_MEDICAMENTO = int.Parse(cmbTipoNominacionMedicamento.SelectedValue);
            }
            try
            {
                cls.guardarUPC_FORMULARIO3(i, COD_TIPO_NOMINACION_MEDICAMENTO,
                   txtObstipoTecnologia.Text, txtNumCasasFarmaceuticas.Text,
                   txtNumAnosMedicamento.Text, txtCodCumMedicamento.Text, txtDosisPediatraMedicamentos.Text,
                   txtDosisAdultosMedicamentos.Text, txtIndicacionMedicamento.Text, txtPrecioPorFormaFarma.Text,
                   txtPrecioPorConcentracion.Text, txtPrecioPorPresentacion.Text,
                   txtValorCOPMedicamento.Text, txtUnidadMedidaMedicamento.Text,
                   chkReaccionesAdversas.Checked, txtReaccionesAdversas.Text,
                   chkReaccionesAdversas.Checked, txtReaccionesAdversas.Text,
                   chkAdvertenciasPrecauciones.Checked, txtAdvertenciasPrecauciones.Text,
                   chkInteracciones.Checked, txtInteracciones.Text,
                   chkInterrupcion.Checked, txtInterrupcion.Text,
                   rdListadoEscencialesSi.Checked, txtObservacionesListadoEscencial.Text,
                   txtNombreGPCMedicamento.Text, txtRecomendacionMedicamentoGPC.Text,
                   txtGradoRecomendacionMedicamentoGPC.Text, rdNuevoProcedimientoSi.Checked,
                   txtObservacionesNuevoProcedimiento.Text, txtIpsREalizanProcedimiento.Text,
                   txtNumAnosProcedimento.Text, txtFrecuenciaProcedimiento.Text,
                   txtFrecuenciaAplicacionProcedimiento.Text, txtDuracionProcedimiento.Text,
                   txtPrecioDuracionProcedimiento.Text, txtNombreGPCProcedimiento.Text,
                   txtRecomendacionProcedimientoGPC.Text, txtGradoRecomendacionProcedimientoGPC.Text,
                   txtdesenlacesProcedimiento.Text,
                   txtResultadosSeguridadProcedimiento.Text,
                   txtTamanoPoblacion.Text,
                   txtTamanoPoblacionColombiana.Text,
                   txtRElacionTsnCArgaEnfermedad.Text,
                   txtBeneficios.Text,
                   rdTSNReduceMortalidadSi.Checked,
                   txtTSNReduceMortalidad.Text,
                   rdTSNMejoraDiscapacidadSi.Checked,
                   txtTSNMejoraDiscapacidad.Text
                   );
            }
            catch (Exception) { }
            //if (lblCodNominacionProceso.Text.Trim() != string.Empty)
            //
            //{
            // siempre que guarda la deja pendiente por validacion
            cls.cambiarEstadoNominacionUPC(i, 2);
            //}
            lblCodNominacionUPC.Text = i.ToString();
            LblValidacionCampos.Text = "La información ha sido guardada exitosamente en su cuenta y estará disponible para ser completada y remitida para el proceso vigente.";

        }

        /// <summary>
        /// Manejador del evento clic del botón para objetar. Redirige a la página "frmObjetar.aspx" con parámetros en la URL.
        /// </summary>
        /// <param name="sender">El objeto que genera el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        protected void btnObjetar_Click(object sender, EventArgs e)
        {
            // Se redirige a la página frmObjetar.aspx con los parámetros codN y codProceso en la URL.
            Response.Redirect("frmObjetar.aspx?codN=" + Request.QueryString["codN"] + "&codProceso=" + Request.QueryString["codProceso"]);
        }


    }
}