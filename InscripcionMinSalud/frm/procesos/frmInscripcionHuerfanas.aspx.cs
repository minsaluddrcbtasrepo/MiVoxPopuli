using NegocioInscripcionMinSalud;
using NegocioInscripcionMinSalud.data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InscripcionMinSalud.frm.procesos
{
    public partial class frmInscripcionHuerfanas : System.Web.UI.Page
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

        protected void DescargarDocumentos()
        {
            string archivo = "";
            archivo = "3-" + Session["ticsfile"] + uploadDocumentoNatural.UploadedFiles[0].FileName;
            string pathArchivo = Server.MapPath("~/files/DocumentosHuerfanas");
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
            }
            else
            {
                posibleAclaracioes.Visible = false;
            }



            if (Request.QueryString["codProceso"] == null || Request.QueryString["codProceso"].ToString().Trim() == string.Empty)
            {
                Response.Redirect("~/Default.aspx");
                return;
            }
            #region ocultamos paneles de validacion


            pnlValidacionConflicto.Visible = false;

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
                if (Session["SS_COD_REGISTRO"] != null) codR = int.Parse(Session["SS_COD_REGISTRO"].ToString());

                //cargamos la infomracion del registro
                clsNegocio obj = new clsNegocio();
                if (codR != 0)
                {
                    var reg = obj.obtenerRegistroxCodigo(codR);
                    #region ajustamos visibilidad de los paneles para la nominacion
                    if (reg.COD_TIPO_JURIDICO == 1 || reg.COD_TIPO_JURIDICO == 4 || reg.COD_TIPO_JURIDICO == 5 ||
                        reg.COD_TIPO_JURIDICO == 6 || reg.COD_TIPO_JURIDICO == 7 ||
                        reg.COD_TIPO_JURIDICO == 8 || reg.COD_TIPO_JURIDICO == 9 || reg.COD_TIPO_JURIDICO == 10 || reg.COD_TIPO_JURIDICO == 11 || reg.COD_TIPO_JURIDICO == 12 ||
                        reg.COD_TIPO_JURIDICO == 28 || reg.COD_TIPO_JURIDICO == 29 || reg.COD_TIPO_JURIDICO == 30 ||
                        reg.COD_TIPO_JURIDICO == 31 || reg.COD_TIPO_JURIDICO == 26 ||
                        reg.COD_TIPO_JURIDICO == 27 || reg.COD_TIPO_JURIDICO == 13 || reg.COD_TIPO_JURIDICO == 14 ||
                        reg.COD_TIPO_JURIDICO == 15 ||
                        reg.COD_TIPO_JURIDICO == 16 || reg.COD_TIPO_JURIDICO == 17 || reg.COD_TIPO_JURIDICO == 18 ||
                        reg.COD_TIPO_JURIDICO == 19 || reg.COD_TIPO_JURIDICO == 20 ||
                        reg.COD_TIPO_JURIDICO == 21 || reg.COD_TIPO_JURIDICO == 22 || reg.COD_TIPO_JURIDICO == 23 ||
                        reg.COD_TIPO_JURIDICO == 24 || reg.COD_TIPO_JURIDICO == 25
                        )
                    {
                        //   pnlMensajeNoNominador.Visible = false;
                        //   pnlFormulario.Visible = true;
                    }
                    else
                    {
                        //   pnlMensajeNoNominador.Visible = true;
                        //   pnlFormulario.Visible = false;
                    }
                    #endregion
                    #region ajustamos visibilidad de paneles de acuerdo al que va a nominar
                    if (reg.ES_PERSONA_NATURAL)
                    {

                        txtNombreNominador.Text = reg.NOMBRE.Trim() + " " + reg.APELLIDOS;
                        txtTipoAator.Text = "Persona natural";
                        txtIdentificacionNominador.Text = reg.DOCUMENTO;
                        txtEmailNominador.Text = reg.CORREO;
                    }
                    else
                    {
                        txtNombreNominador.Text = reg.NOMBRE.Trim();
                        txtTipoAator.Text = "Pesona Juridica - " + obj.obtenerTipoJuridicoxCodigo(int.Parse(reg.COD_TIPO_JURIDICO.ToString()));
                        txtIdentificacionNominador.Text = reg.DOCUMENTO;
                        txtEmailNominador.Text = reg.CORREO;
                    }
                    #endregion
                }


                if (Request.QueryString["codN"] != null && Request.QueryString["codN"] != string.Empty)
                {
                    lnkPDF.Visible = true;
                    lnkPDF.HRef = "../informes/frmReportViewer.aspx?cod=" + Request.QueryString["codN"];
                    var registro = obj.obtenerNOMINACION_PROCESO(int.Parse(Request.QueryString["codN"]));
                    pnlNominador.Visible = true;

                    foreach (var k in registro.ARCHIVOXNOMINACION)
                    {
                        archivos a = new archivos();
                        a.descripcion = k.DESCRIPCION_ARCHIVO;
                        a.url = k.URL_ARCHIVO;
                        ArchivosCargados.Add(a);
                    }

                    lblCodNominacionProceso.Text = registro.COD_NOMINACION_PROCESO.ToString();
                    txtNombreTecnologia.Text = registro.ID_MANUAL.Trim() + "-" + registro.NOMBRE_TECNOLOGIA;
                    txtConflicto.Text = registro.OBSERVACIONES_CONFLICTO;
                    //txtEnfermedad.Text = registro.NOMBRE_ENFERMEDAD_CONDICION_SALUD;
                    //txtEnfermedad2.Text = registro.OBSERVACION_TECNOLOGIA;

                    txtEvidencia.Text = registro.OBSERVACIONES_EVIDENCIA;

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

                    /* if (registro.CONFLICTO_INTERES.HasValue)
                     {
                         chkConflictoInteres.Checked = registro.CONFLICTO_INTERES.Value;
                         chkNoConflictoInteres.Checked = !registro.CONFLICTO_INTERES.Value;
                     }*/
                    /* if (registro.ES_DISPOSITIVO_MEDICO.HasValue)
                         chkEsDispositivoMedico.Checked = registro.ES_DISPOSITIVO_MEDICO.Value;
                     if (registro.ES_MEDICAMENTO.HasValue)
                         chkEsMedicamento.Checked = registro.ES_MEDICAMENTO.Value;*/

                    /* if (registro.ES_PROCEDIMIENTO.HasValue)
                         chkEsProcedimiento.Checked = registro.ES_PROCEDIMIENTO.Value;*/

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
                    }
                    else
                    {
                        #region los campos no se pueden modificar en este estado
                        txtConflicto.ReadOnly = true;
                        txtInteresEconomico.ReadOnly = true;

                        //txtEnfermedad.ReadOnly = true;
                        //txtEnfermedad2.ReadOnly = true;

                        txtNombreTecnologia.ReadOnly = true;

                        chkAdjuntaEvidencia.Enabled = false;
                        //chkConflictoInteres.Enabled = false;
                        //  chkEsDispositivoMedico.Enabled = false;
                        // chkEsMedicamento.Enabled = false;
                        // chkEsOtro.Enabled = false;
                        // chkEsProcedimiento.Enabled = false;

                        chkNoAdjuntaEvidencia.Enabled = false;
                        //chkNoConflictoInteres.Enabled = false;

                        btnGuardar.Visible = false;
                        btnGuardarContinuar.Visible = false;
                        btnArchivo.Visible = false;
                        #endregion
                    }

                    if (registro.COD_ESTADO_NOMINACION > 2 && Session["SS_COD_REGISTRO"] != null && (registro.COD_REGISTRO.ToString() == Session["SS_COD_REGISTRO"].ToString())
                        )
                    {
                        if (registro.COD_ESTADO_NOMINACION == 4)
                        {//siginifica que va  editar los campos 
                            btnGuardarContinuar.Visible = true;
                            txtConflicto.ReadOnly = false;

                            //txtEnfermedad.ReadOnly = false;
                            //txtEnfermedad2.ReadOnly = false;
                            txtEvidencia.ReadOnly = false;

                            txtNombreTecnologia.ReadOnly = false;


                            //     chkEsDispositivoMedico.Enabled = true;
                            //     chkEsMedicamento.Enabled = true;
                            // chkEsOtro.Enabled = true;
                            //    chkEsProcedimiento.Enabled = true;

                            chkNoAdjuntaEvidencia.Enabled = true;


                        }

                        //pnlValidacionCIE10a.Visible = true;
                        //pnlValidacionCIE10b.Visible = true;
                        //pnlValidacionCIE10c.Visible = true;
                        pnlValidacionConflicto.Visible = true;


                        //pnlValidacionNombreTecnologia.Visible = true;
                        pnlValidacionEvidencia.Visible = true;
                        pnlObservacionesGenerales.Visible = true;
                        //
                        var nominacion = obj.obtenerVALIDACION_PROCESO(registro.COD_NOMINACION_PROCESO);
                        var parametros = obj.obtenerPARAMETRO_VALIDACION();
                        txtObservacionesGenerales.Text = nominacion.OBSERVACIONES_GENERALES;

                        //cmbGrupoCIE10.SelectedValue =


                        var valA = nominacion.DETALLE_VALIDACION_PROCESO.Join(parametros, x => x.COD_PARAMETRO_VALIDACION, x2 => x2.COD_PARAMETRO_VALIDACION, (x, x2) => new { detalle = x, parametro = x2 })
                            .Where(x3 => x3.parametro.COD_GRUPO_PARAMETRO_VALIDACION == 1).Select(x3 => x3.parametro).FirstOrDefault();
                        if (valA != null)
                        {
                            //cmbGrupoNombreTecnologia.SelectedValue = valA.COD_PARAMETRO_VALIDACION.ToString();
                            //if (valA.ES_OK )
                            //{
                            //    pnlValidacionNombreTecnologia.Visible = false;
                            //}
                        }

                        var valB = nominacion.DETALLE_VALIDACION_PROCESO.Join(parametros, x => x.COD_PARAMETRO_VALIDACION, x2 => x2.COD_PARAMETRO_VALIDACION, (x, x2) => new { detalle = x, parametro = x2 })
                            .Where(x3 => x3.parametro.COD_GRUPO_PARAMETRO_VALIDACION == 2 && x3.detalle.CONSECUTIVO == 1).Select(x3 => x3.parametro).FirstOrDefault();
                        if (valB != null)
                        {
                            // cmbGrupoCIE10.SelectedValue = valB.COD_PARAMETRO_VALIDACION.ToString();
                            //if (valB.ES_OK)
                            //{
                            //    pnlValidacionCIE10a.Visible = false;
                            //}
                        }

                        var valB2 = nominacion.DETALLE_VALIDACION_PROCESO.Join(parametros, x => x.COD_PARAMETRO_VALIDACION, x2 => x2.COD_PARAMETRO_VALIDACION, (x, x2) => new { detalle = x, parametro = x2 })
                            .Where(x3 => x3.parametro.COD_GRUPO_PARAMETRO_VALIDACION == 2 && x3.detalle.CONSECUTIVO == 2).Select(x3 => x3.parametro).FirstOrDefault();
                        if (valB2 != null)
                        {
                            //cmbGrupoCIE10b.SelectedValue = valB2.COD_PARAMETRO_VALIDACION.ToString();
                            //if (valB2.ES_OK)
                            //{
                            //    pnlValidacionCIE10b.Visible = false;
                            //}
                        }

                        var valB3 = nominacion.DETALLE_VALIDACION_PROCESO.Join(parametros, x => x.COD_PARAMETRO_VALIDACION, x2 => x2.COD_PARAMETRO_VALIDACION, (x, x2) => new { detalle = x, parametro = x2 })
                            .Where(x3 => x3.parametro.COD_GRUPO_PARAMETRO_VALIDACION == 2 && x3.detalle.CONSECUTIVO == 3).Select(x3 => x3.parametro).FirstOrDefault();
                        if (valB3 != null)
                        {
                            //  cmbGrupoCIE10c.SelectedValue = valB3.COD_PARAMETRO_VALIDACION.ToString();
                            //if (valB3.ES_OK)
                            //{
                            //    pnlValidacionCIE10c.Visible = false;
                            //}
                        }



                        var valG = nominacion.DETALLE_VALIDACION_PROCESO.Join(parametros, x => x.COD_PARAMETRO_VALIDACION, x2 => x2.COD_PARAMETRO_VALIDACION, (x, x2) => new { detalle = x, parametro = x2 })
                            .Where(x3 => x3.parametro.COD_GRUPO_PARAMETRO_VALIDACION == 7 && x3.detalle.CONSECUTIVO == 1).Select(x3 => x3.parametro).FirstOrDefault();

                        var valG5 = nominacion.DETALLE_VALIDACION_PROCESO.Join(parametros, x => x.COD_PARAMETRO_VALIDACION, x2 => x2.COD_PARAMETRO_VALIDACION, (x, x2) => new { detalle = x, parametro = x2 })
                            .Where(x3 => x3.parametro.COD_GRUPO_PARAMETRO_VALIDACION == 7 && x3.detalle.CONSECUTIVO == 5).Select(x3 => x3.parametro).FirstOrDefault();


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
        /// Evento que se ejecuta al hacer clic en el botón de guardar y continuar.
        /// Realiza la validación de los campos, guarda la nominación y luego la envía.
        /// </summary>
        /// <param name="sender">Objeto que desencadenó el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        protected void btnGuardarContinuar_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                guardar();
                enviar();
            }
        }

        /// <summary>
        /// Evento que se ejecuta al hacer clic en el botón de guardar.
        /// Invoca el método de guardado de la nominación de enfermedad huérfana.
        /// </summary>
        /// <param name="sender">Objeto que desencadenó el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            guardar();
        }

        /// <summary>
        /// Método que realiza la validación de los campos antes de guardar o enviar la nominación de enfermedad huérfana.
        /// </summary>
        /// <returns>True si la validación es exitosa, false en caso contrario.</returns>
        private bool validar()
        {
            // Variable que indica si hay errores en la validación
            bool error = false;

            // Limpieza de mensajes de validación anteriores
            LblValidacionCampos.Text = "";

            // Configuración del estilo de borde para la opción de cambio
            opcionCambio.Attributes.Remove("border-color");
            opcionCambio.Attributes.CssStyle.Add("border-color", "#f3a740");

            // Validación de la selección de opciones de cambio
            if (!chkEsIncluir.Checked && !chkEsExcluir.Checked && !chkEsCambio.Checked && !chkCodigo.Checked && !chkPruebaDiagnostica.Checked && !chkDiciplina.Checked)
            {
                error = true;
                LblValidacionCampos.Text += "Debe seleccionar la opción que describe el cambio a nominar,  ";
                opcionCambio.Attributes.CssStyle.Add("border-color", "red");
            }

            // Validación del campo de especialidad si la opción es inclusión
            if (chkEsIncluir.Checked && String.IsNullOrEmpty(txtEspecialidad.Text.Trim()))
            {
                LblValidacionCampos.Text += "Especialidad 1 de la nominación, ";
                txtEspecialidad.Attributes.Add("placeholder", "Debe ingresar el nombre de la especialidad ");
                txtEspecialidad.CssClass = "form-control errormin";
            }

            // Validación del nombre de la nominación
            if (chkEsIncluir.Checked)
            {
                txtNombreTecnologiaInclusion.CssClass = "";
                txtNombreTecnologiaInclusion.Attributes.Remove("placeholder");
                if (String.IsNullOrEmpty(txtNombreTecnologiaInclusion.Text.Trim()))
                {
                    error = true;
                    LblValidacionCampos.Text += "Nombre de la nominación, ";
                    txtNombreTecnologiaInclusion.Attributes.Add("placeholder", "Debe ingresar el nombre de la enfermedad que nómina");
                    txtNombreTecnologiaInclusion.CssClass = "form-control errormin";
                }
                else
                {
                    txtNombreTecnologiaInclusion.CssClass = "form-control";
                }
            }
            else
            {
                txtNombreTecnologia.CssClass = "";
                txtNombreTecnologia.Attributes.Remove("placeholder");
                if (String.IsNullOrEmpty(txtNombreTecnologia.Text.Trim()))
                {
                    error = true;
                    LblValidacionCampos.Text += "Nombre de la nominación, ";
                    txtNombreTecnologia.Attributes.Add("placeholder", "Debe ingresar el nombre de la enfermedad que nómina ");
                    txtNombreTecnologia.CssClass = "form-control errormin";
                }
                else
                {
                    txtNombreTecnologia.CssClass = "form-control";
                }
            }

            // Validación de la justificación
            txtDescriptJustifica.CssClass = "";
            txtDescriptJustifica.Attributes.Remove("placeholder");
            if (String.IsNullOrEmpty(txtDescriptJustifica.Text.Trim()))
            {
                error = true;
                txtDescriptJustifica.Attributes.Add("placeholder", "Debe ingresar la justificación de la nominación ");
                txtDescriptJustifica.CssClass = "form-control errormin";
            }
            else
            {
                txtDescriptJustifica.CssClass = "form-control";
            }

            // Validación de la evidencia si está seleccionada la opción de adjuntar evidencia
            if (chkAdjuntaEvidencia.Checked && txtEvidencia.Text.Trim() == string.Empty)
            {
                txtEvidencia.CssClass = "";
                txtEvidencia.Attributes.Remove("placeholder");
                LblValidacionCampos.Text += "Relacione la evidencia,  ";
                txtEvidencia.Attributes.Add("placeholder", "Debe relacionar la evidencia");
                txtEvidencia.CssClass = "form-control errormin";
            }

            // Validación de la selección de opciones de adjuntar o no adjuntar evidencia
            if (!chkAdjuntaEvidencia.Checked && !chkNoAdjuntaEvidencia.Checked)
            {
                error = true;
                LblValidacionCampos.Text += "Debe seleccionar si adjunta evidencia,  ";
            }

            // Validación de campos relacionados con conflicto de intereses
            txtInteresEconomico.CssClass = "";
            txtInteresEconomico.Attributes.Remove("placeholder");
            if (chkConflictoInteres.Checked && chkNoConflictoInteres.Checked)
            {
                error = true;
                LblValidacionCampos.Text += "Debe informar si tiene conflicto de intereses, ";
                txtConflicto.Attributes.Add("placeholder", "Descripción del conflicto ");
                txtConflicto.CssClass = "form-control errormin";
            }

            return !error;
        }

        /// <summary>
        /// Método que realiza el envío de la nominación de enfermedad huérfana.
        /// </summary>
        private void enviar()
        {
            // Declaración e inicialización de la capa de negocios
            clsNegocio cls = new clsNegocio();

            try
            {
                // Intento de conversión del código de nominación a entero
                int id = int.Parse(lblCodNominacionProceso.Text);
            }
            catch
            {
                // Redirección en caso de error en la conversión
                if (Request.QueryString["v"] == null || Session["SS_COD_REGISTRO"] == null)
                {
                    Response.Redirect("~/aspx/seguridad/frmLogin.aspx?page=aspx@@evento@@frmconfirmacionevento.aspx");
                    return;
                }
            }

            // Obtención de la nominación y el proceso asociado
            var obj = cls.obtenerNOMINACION_HUERFANA(int.Parse(lblCodNominacionProceso.Text));
            var proceso = cls.obtenerProceso(obj.COD_PROCESO);

            // Verificación del estado de la nominación


            // Envío de la nominación y configuración del mensaje
            cls.enviarNominacionExlcusiones(int.Parse(lblCodNominacionProceso.Text), 2);

            if (ConfigurationManager.AppSettings["MensajeNominacionHuerfanas"] != null)
            {
                try
                {
                    System.IO.StreamReader archivo = new System.IO.StreamReader(ConfigurationManager.AppSettings["MensajeNominacionHuerfanas"]);
                    string cuerpoMensajeHuerfanas = archivo.ReadToEnd();
                    archivo.Close();

                    Session["msgtitulo"] = "Gracias por completar su nominación";

                    // Envío del correo electrónico
                    clsWebUtils email = new clsWebUtils();
                    string asunto = Session["msgtitulo"].ToString();                    
                    email.enviarEmailHuerfanas(asunto, cuerpoMensajeHuerfanas, Session["SS_CORREO"].ToString());
                    Session["msgmsg"] = cuerpoMensajeHuerfanas.Replace("<h3>Cordial saludo:</h3>", "").Replace("Atentamente,", "");
                    
                }
                catch (Exception ex)
                {
                    
                }

            }

            // Redirección a la página de mensajes
            Response.Redirect("~/frm/logica/frmMensajeIframe.aspx");
        }


        /// <summary>
        /// Método que realiza el guardado de la nominación de enfermedad huérfana.
        /// </summary>
        private void guardar()
        {
            // Declaración e inicialización de variables
            int vigencia = 0;
            clsNegocio cls = new clsNegocio();
            int? codN = null;
            bool evidencia;
            bool conflictoIntereses;
            string nombre = "";
            string cie10 = "";
            int codigoHuerfana = 0;

            // Verificación de la sesión del usuario
            if (Session["SS_COD_REGISTRO"] == null)
            {
                Response.Redirect("~/aspx/seguridad/frmLogin.aspx");
                return;
            }

            // Verificación de los parámetros de la consulta
            if (Request.QueryString["codN"] == null)
            {
                if (Request.QueryString["v"] == null || Session["SS_COD_REGISTRO"] == null)
                {
                    //Response.Redirect("~/aspx/seguridad/frmLogin.aspx?page=aspx@@evento@@frmconfirmacionevento.aspx");
                    return;
                }
                else
                {
                    vigencia = int.Parse(Request.QueryString["v"]);
                }
            }

            // Obtención del código de nominación si está presente
            if (lblCodNominacionProceso.Text.Trim() != string.Empty)
            {
                codN = int.Parse(lblCodNominacionProceso.Text);
            }

            // Creación de la lista de archivos
            List<ARCHIVOXNOMINACION_HUERFANA> lista = new List<ARCHIVOXNOMINACION_HUERFANA>();

            // Iteración sobre los archivos cargados
            for (int k = 0; k < ArchivosCargados.Count; k++)
            {
                ARCHIVOXNOMINACION_HUERFANA ar = new ARCHIVOXNOMINACION_HUERFANA();
                ar.DESCRIPCION_ARCHIVO = ArchivosCargados[k].descripcion;
                ar.URL_ARCHIVO = ArchivosCargados[k].url;
                lista.Add(ar);
            }

            // Determinación de los valores de las variables booleanas
            evidencia = chkAdjuntaEvidencia.Checked && !chkNoAdjuntaEvidencia.Checked;
            conflictoIntereses = chkConflictoInteres.Checked;

            // Asignación de valores según la opción de inclusión
            if (chkEsIncluir.Checked)
            {
                nombre = txtNombreTecnologiaInclusion.Text;
                cie10 = txtCIEInclusion.Text;
            }
            else
            {
                nombre = txtNombreTecnologia.Text;
                cie10 = txtCIE.Text;
                codigoHuerfana = int.Parse(txtCodigo.Text);
            }

            // Llamada al método de guardado en la capa de negocio
            var i = cls.guardarNominacionHuerfana(
                codN,
                int.Parse(Request.QueryString["codProceso"]),
                vigencia,
                int.Parse(Session["SS_COD_REGISTRO"].ToString()),
                chkEsIncluir.Checked,
                chkEsExcluir.Checked,
                chkEsCambio.Checked,
                chkCodigo.Checked,
                chkPruebaDiagnostica.Checked,
                chkDiciplina.Checked,
                codigoHuerfana,
                nombre,
                cie10,
                cmbTipoConfirmacion.SelectedValue.ToString(),
                txtEspecialidad.Text,
                txtEspecialidad2.Text,
                txtEspecialidad3.Text,
                txtEspecialidad4.Text,
                txtEspecialidad5.Text,
                txtConfirmatoria1.Text,
                txtCups1.Text,
                txtNuevoNombre.Text,
                txtCIENuevoNombre.Text,
                cmbCodigoModificar.SelectedValue.ToString(),
                txtNuevoCodigo.Text,
                txtConfirmatoriaActual.Text,
                txtCupsConfirmatoriaActual.Text,
                txtConformatoriaPropuesta.Text,
                txtCupsConformatoriaPropuesta.Text,
                txtPruebaAlterna.Text,
                txtCUPSPruebaAlterna.Text,
                txtEspActual.Text,
                txtEspActual2.Text,
                txtEspActual3.Text,
                txtEspActual4.Text,
                txtEspActual5.Text,
                txtEspecialidadPropuesta.Text,
                txtEspecialidadPropuesta2.Text,
                txtEspecialidadPropuesta3.Text,
                txtEspecialidadPropuesta4.Text,
                txtEspecialidadPropuesta5.Text,
                txtDescriptJustifica.Text,
                evidencia,
                txtEvidencia.Text,
                lblArchivoView.HRef,
                conflictoIntereses,
                txtConflicto.Text,
                lista
            );

            // Asignación del código de nominación al label correspondiente
            lblCodNominacionProceso.Text = i.ToString();

            // Mensaje de validación
            LblValidacionCampos.Text = "La información ha sido guardada exitosamente en su cuenta y estará disponible para ser completada y remitida para el proceso vigente.";
        }

        /// <summary>
        /// Maneja el evento de clic en el botón de archivo.
        /// Restablece la sesión del archivo, muestra el popup para agregar detalles del archivo
        /// y restablece el campo de descripción del archivo junto con los mensajes de error.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        protected void btnArchivo_Click(object sender, EventArgs e)
        {
            // Restablecer la sesión del archivo
            Session["archivoPuente"] = null;

            // Mostrar el popup para agregar detalles del archivo
            popupNuevo.Show();

            // Restablecer el campo de descripción del archivo y los mensajes de error
            txtDescripcionArchivo.Text = "";
            lblErrorDetalle.Text = "";
        }

        /// <summary>
        /// Maneja el evento de clic en el botón de cancelar en el formulario de detalles del archivo.
        /// Oculta el popup de detalles del archivo sin realizar ninguna acción adicional.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        protected void btnCancelarDetalle_Click(object sender, EventArgs e)
        {
            // Ocultar el popup de detalles del archivo
            popupNuevo.Hide();
        }

        /// <summary>
        /// Maneja el evento de clic en el botón de aceptar en el formulario de detalles del archivo.
        /// Valida la descripción del archivo y la existencia de un archivo adjunto.
        /// Agrega un nuevo objeto "archivos" a la lista de archivos cargados con la descripción y la URL del archivo adjunto.
        /// Oculta el popup de detalles del archivo y actualiza la interfaz de usuario con la lista actualizada de archivos.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        protected void btnAceptarDetalle_Click(object sender, EventArgs e)
        {
            // Validar la descripción del archivo
            if (txtDescripcionArchivo.Text == string.Empty)
            {
                lblErrorDetalle.Text = "Debe ingresar la descripción del archivo";
                return;
            }

            // Validar la existencia de un archivo adjunto
            if ((Session["archivoPuente"] == null || Session["archivoPuente"].ToString() == string.Empty))
            {
                lblErrorDetalle.Text = "Debe adjuntar el archivo";
                return;
            }

            // Crear un nuevo objeto "archivos" con la descripción y la URL del archivo adjunto
            archivos ar = new archivos();
            ar.descripcion = txtDescripcionArchivo.Text;
            ar.url = Session["archivoPuente"].ToString();

            // Agregar el nuevo archivo a la lista de archivos cargados
            ArchivosCargados.Add(ar);

            // Ocultar el popup de detalles del archivo
            popupNuevo.Hide();

            // Actualizar la interfaz de usuario con la lista actualizada de archivos
            renderArchivos();
        }

        /// <summary>
        /// Actualiza la interfaz de usuario con la lista actual de archivos cargados. Enlaza la lista de archivos al control GridView y actualiza el panel correspondiente.
        /// </summary>
        private void renderArchivos()
        {
            // Enlaza la lista de archivos al control GridView
            grdArchivos.DataSource = ArchivosCargados;
            grdArchivos.DataBind();

            // Actualiza el panel correspondiente en la interfaz de usuario
            pnlGrillaArchivos.Update();
        }

        /// <summary>
        /// Maneja el evento de clic en el botón para eliminar un archivo cargado. Elimina el archivo correspondiente de la lista de archivos cargados y actualiza la interfaz de usuario.
        /// </summary>
        /// <param name="sender">Objeto que provocó el evento (ImageButton).</param>
        /// <param name="e">Argumentos del evento (ImageClickEventArgs).</param>
        protected void btnelimnarARchivo_Click(object sender, ImageClickEventArgs e)
        {
            // Obtiene el ImageButton que provocó el evento
            ImageButton b = (ImageButton)sender;

            // Busca el archivo correspondiente en la lista de archivos cargados y lo elimina
            for (int k = 0; k < ArchivosCargados.Count; k++)
            {
                if (ArchivosCargados[k].url == b.ValidationGroup)
                {
                    ArchivosCargados.RemoveAt(k);
                    break;
                }
            }

            // Actualiza la interfaz de usuario renderizando la lista de archivos actualizada
            renderArchivos();
        }

        /// <summary>
        /// Maneja el evento de clic en el botón "Objetar", redirigiendo a la página de objeciones con los parámetros correspondientes.
        /// </summary>
        /// <param name="sender">Objeto que provocó el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        protected void btnObjetar_Click(object sender, EventArgs e)
        {
            // Redirige a la página de objeciones con los parámetros del código de nominación y el código de proceso
            Response.Redirect("frmObjetar.aspx?codN=" + Request.QueryString["codN"] + "&codProceso=" + Request.QueryString["codProceso"]);
        }

        /// <summary>
        /// Maneja el evento de clic en el botón "Quitar 2".
        /// </summary>
        /// <param name="sender">Objeto que provocó el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        protected void Quitar2_Click(object sender, EventArgs e)
        {
            // Muestra el botón de agregar 2
            btnAgregar2.Visible = true;

            // Oculta el div de la especialidad 2
            divEspecialidad2.Visible = false;

            // Vacía el contenido del cuadro de texto
            txtEspecialidad2.Text = "";
        }

        /// <summary>
        /// Maneja el evento de clic en el botón "Agregar 2".
        /// </summary>
        /// <param name="sender">Objeto que provocó el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        protected void btnAgregar2_Click(object sender, EventArgs e)
        {
            // Oculta el botón de agregar 2
            btnAgregar2.Visible = false;

            // Muestra el div de la especialidad 2
            divEspecialidad2.Visible = true;
        }

        /// <summary>
        /// Maneja el evento de clic en el botón "Agregar 3".
        /// </summary>
        /// <param name="sender">Objeto que provocó el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        protected void btnAgregar3_Click(object sender, EventArgs e)
        {
            // Oculta el botón de agregar 3
            btnAgregar3.Visible = false;

            // Muestra el div de la especialidad 3
            divEspecialidad3.Visible = true;
        }

        /// <summary>
        /// Maneja el evento de clic en el botón "Quitar 3".
        /// </summary>
        /// <param name="sender">Objeto que provocó el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        protected void Quitar3_Click(object sender, EventArgs e)
        {
            // Muestra el botón de agregar 3
            btnAgregar3.Visible = true;

            // Oculta el div de la especialidad 3
            divEspecialidad3.Visible = false;

            // Vacía el contenido del cuadro de texto
            txtEspecialidad3.Text = "";
        }


        /// <summary>
        /// Maneja el evento de clic en el botón "Agregar 4".
        /// </summary>
        /// <param name="sender">Objeto que provocó el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        protected void btnAgregar4_Click(object sender, EventArgs e)
        {
            // Oculta el botón de agregar 4
            btnAgregar4.Visible = false;

            // Muestra el div de la especialidad 4
            divEspecialidad4.Visible = true;
        }

        /// <summary>
        /// Maneja el evento de clic en el botón "Quitar 4".
        /// </summary>
        /// <param name="sender">Objeto que provocó el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        protected void Quitar4_Click(object sender, EventArgs e)
        {
            // Muestra el botón de agregar 5
            btnAgregar5.Visible = true;

            // Oculta el div de la especialidad 4
            divEspecialidad4.Visible = false;

            // Vacía el contenido del cuadro de texto
            txtEspecialidad4.Text = "";
        }

        /// <summary>
        /// Maneja el evento de clic en el botón "Agregar 5".
        /// </summary>
        /// <param name="sender">Objeto que provocó el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        protected void btnAgregar5_Click(object sender, EventArgs e)
        {
            // Oculta el botón de agregar 5
            btnAgregar5.Visible = false;

            // Muestra el div de la especialidad 5
            divEspecialidad5.Visible = true;
        }

        /// <summary>
        /// Maneja el evento de clic en el botón "Quitar 5".
        /// </summary>
        /// <param name="sender">Objeto que provocó el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        protected void Quitar5_Click(object sender, EventArgs e)
        {
            // Muestra el botón de agregar 5
            btnAgregar5.Visible = true;

            // Oculta el div de la especialidad 5
            divEspecialidad5.Visible = false;

            // Vacía el contenido del cuadro de texto
            txtEspecialidad5.Text = "";
        }

        /// <summary>
        /// Maneja el evento de clic en el botón "Quitar Especialidad Actual 2".
        /// </summary>
        /// <param name="sender">Objeto que provocó el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        protected void btnQuitarEspActual2_Click(object sender, EventArgs e)
        {
            // Muestra el botón de agregar de la especialidad actual 2
            btnAgregarEspActual2.Visible = true;

            // Oculta el div de la especialidad actual 2
            divEspActual2.Visible = false;

            // Vacía el contenido del cuadro de texto
            txtEspActual2.Text = "";
        }

        /// <summary>
        /// Maneja el evento de clic en el botón "Agregar Especialidad Actual 2".
        /// </summary>
        /// <param name="sender">Objeto que provocó el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        protected void btnAgregarEspActual2_Click(object sender, EventArgs e)
        {
            // Oculta el botón de agregar de la especialidad actual 2
            btnAgregarEspActual2.Visible = false;

            // Muestra el div de la especialidad actual 2
            divEspActual2.Visible = true;
        }

        /// <summary>
        /// Maneja el evento de clic en el botón "Agregar Especialidad Actual 3".
        /// </summary>
        /// <param name="sender">Objeto que provocó el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        protected void btnAgregarEspActual3_Click(object sender, EventArgs e)
        {
            // Oculta el botón de agregar de la especialidad actual 3
            btnAgregarEspActual3.Visible = false;

            // Muestra el div de la especialidad actual 3
            divEspActual3.Visible = true;
        }

        /// <summary>
        /// Maneja el evento de clic en el botón "Quitar Especialidad Actual 3".
        /// </summary>
        /// <param name="sender">Objeto que provocó el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        protected void btnQuitarEspActual3_Click(object sender, EventArgs e)
        {
            // Muestra el botón de agregar de la especialidad actual 3
            btnAgregarEspActual3.Visible = true;

            // Oculta el div de la especialidad actual 3
            divEspActual3.Visible = false;

            // Vacía el contenido del cuadro de texto
            txtEspActual3.Text = "";
        }

        /// <summary>
        /// Maneja el evento de clic en el botón "Agregar Especialidad Actual 4".
        /// </summary>
        /// <param name="sender">Objeto que provocó el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        protected void btnAgregarEspActual4_Click(object sender, EventArgs e)
        {
            // Oculta el botón de agregar de la especialidad actual 4
            btnAgregarEspActual4.Visible = false;

            // Muestra el div de la especialidad actual 4
            divEspActual4.Visible = true;
        }

        /// <summary>
        /// Maneja el evento de clic en el botón "Quitar Especialidad Actual 4".
        /// </summary>
        /// <param name="sender">Objeto que provocó el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        protected void btnQuitarEspActual4_Click(object sender, EventArgs e)
        {
            // Muestra el botón de agregar de la especialidad actual 5
            btnAgregarEspActual5.Visible = true;

            // Oculta el div de la especialidad actual 4
            divEspActual4.Visible = false;

            // Vacía el contenido del cuadro de texto
            txtEspActual4.Text = "";
        }

        /// <summary>
        /// Maneja el evento de clic en el botón "Agregar Especialidad Actual 5".
        /// </summary>
        /// <param name="sender">Objeto que provocó el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        protected void btnAgregarEspActual5_Click(object sender, EventArgs e)
        {
            // Oculta el botón de agregar de la especialidad actual 5
            btnAgregarEspActual5.Visible = false;

            // Muestra el div de la especialidad actual 5
            divEspActual5.Visible = true;
        }

        /// <summary>
        /// Maneja el evento de clic en el botón "Quitar Especialidad Actual 5".
        /// </summary>
        /// <param name="sender">Objeto que provocó el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        protected void btnQuitarEspActual5_Click(object sender, EventArgs e)
        {
            // Muestra el botón de agregar de la especialidad actual 5
            btnAgregarEspActual5.Visible = true;

            // Oculta el div de la especialidad actual 5
            divEspActual5.Visible = false;

            // Vacía el contenido del cuadro de texto
            txtEspActual5.Text = "";
        }

        /// <summary>
        /// Maneja el evento de clic en el botón "Quitar Especialidad Propuesta 2".
        /// </summary>
        /// <param name="sender">Objeto que provocó el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        protected void QuitarEspPropuesta2_Click(object sender, EventArgs e)
        {
            // Muestra el botón de agregar de la especialidad propuesta 2
            btnAgregarEspPropuesta2.Visible = true;

            // Oculta el div de la especialidad propuesta 2
            divEspecialidadPropuesta2.Visible = false;

            // Vacía el contenido del cuadro de texto
            txtEspecialidadPropuesta2.Text = "";
        }

        /// <summary>
        /// Maneja el evento de clic en el botón "Agregar Especialidad Propuesta 2".
        /// </summary>
        /// <param name="sender">Objeto que provocó el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        protected void btnAgregarEspPropuesta2_Click(object sender, EventArgs e)
        {
            // Oculta el botón de agregar
            btnAgregarEspPropuesta2.Visible = false;

            // Muestra el div de la especialidad propuesta 2
            divEspecialidadPropuesta2.Visible = true;
        }

        /// <summary>
        /// Maneja el evento de clic en el botón "Agregar Especialidad Propuesta 3".
        /// </summary>
        /// <param name="sender">Objeto que provocó el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        protected void btnAgregarEspPropuesta3_Click(object sender, EventArgs e)
        {
            // Oculta el botón de agregar
            btnAgregarEspPropuesta3.Visible = false;

            // Muestra el div de la especialidad propuesta 3
            divEspecialidadPropuesta3.Visible = true;
        }

        /// <summary>
        /// Maneja el evento de clic en el botón "Quitar Especialidad Propuesta 3".
        /// </summary>
        /// <param name="sender">Objeto que provocó el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        protected void QuitarEspPropuesta3_Click(object sender, EventArgs e)
        {
            // Muestra el botón de agregar de la especialidad propuesta 3
            btnAgregarEspPropuesta3.Visible = true;

            // Oculta el div de la especialidad propuesta 3
            divEspecialidadPropuesta3.Visible = false;

            // Vacía el contenido del cuadro de texto
            txtEspecialidadPropuesta3.Text = "";
        }

        /// <summary>
        /// Maneja el evento de clic en el botón "Agregar Especialidad Propuesta 4".
        /// </summary>
        /// <param name="sender">Objeto que provocó el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        protected void btnAgregarEspPropuesta4_Click(object sender, EventArgs e)
        {
            // Oculta el botón de agregar
            btnAgregarEspPropuesta4.Visible = false;

            // Muestra el div de la especialidad propuesta 4
            divEspecialidadPropuesta4.Visible = true;
        }

        /// <summary>
        /// Maneja el evento de clic en el botón "Quitar Especialidad Propuesta 4".
        /// </summary>
        /// <param name="sender">Objeto que provocó el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        protected void QuitarEspPropuesta4_Click(object sender, EventArgs e)
        {
            // Muestra el botón de agregar de la especialidad propuesta 5 (nota: este podría ser un error tipográfico)
            btnAgregarEspPropuesta5.Visible = true;

            // Oculta el div de la especialidad propuesta 4
            divEspecialidadPropuesta4.Visible = false;

            // Vacía el contenido del cuadro de texto
            txtEspecialidadPropuesta4.Text = "";
        }

        /// <summary>
        /// Maneja el evento de clic en el botón "Agregar Especialidad Propuesta 5".
        /// </summary>
        /// <param name="sender">Objeto que provocó el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        protected void btnAgregarEspPropuesta5_Click(object sender, EventArgs e)
        {
            // Oculta el botón de agregar
            btnAgregarEspPropuesta5.Visible = false;

            // Muestra el div de la especialidad propuesta 5
            divEspecialidadPropuesta5.Visible = true;
        }

        /// <summary>
        /// Maneja el evento de clic en el botón "Quitar Especialidad Propuesta 5".
        /// </summary>
        /// <param name="sender">Objeto que provocó el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        protected void QuitarEspPropuesta5_Click(object sender, EventArgs e)
        {
            // Muestra el botón de agregar
            btnAgregarEspPropuesta5.Visible = true;

            // Oculta el div de la especialidad propuesta 5
            divEspecialidadPropuesta5.Visible = false;

            // Vacía el contenido del cuadro de texto
            txtEspecialidadPropuesta5.Text = "";
        }

    }
}