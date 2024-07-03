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
    public partial class SolicitarRevision : System.Web.UI.Page
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
        /// Valida si hay algún archivo cargado con un nombre que comienza con el prefijo "3-".
        /// </summary>
        /// <returns>
        /// True si hay al menos un archivo cargado con el prefijo "3-", de lo contrario, False.
        /// </returns>
        private bool ValidarArchivoCargado()
        {
            // Recorre todos los archivos cargados.
            foreach (var archivoCargado in ArchivosCargados)
            {
                // Obtiene el nombre del archivo sin la ruta.
                string nombreArchivo = System.IO.Path.GetFileName(archivoCargado.url);

                // Verifica si el nombre del archivo comienza con el prefijo "3-".
                if (nombreArchivo.StartsWith("3-"))
                {
                    return true; // Hay al menos un archivo con el prefijo "3-".
                }
            }

            // No se encontró ningún archivo con el prefijo "3-".
            return false;
        }


        /// <summary>
        /// Descarga el documento cargado y guarda la ruta del archivo en la sesión.
        /// </summary>
        private void DescargarDocumentos()
        {
            string archivo = "";

            // Se construye el nombre del archivo utilizando el identificador de sesión y el nombre original del archivo cargado.
            archivo = "3-" + Session["ticsfile"] + uploadDocumentoNatural.UploadedFiles[0].FileName;

            // Se obtiene la ruta del directorio temporal en el servidor.
            string pathArchivo = Server.MapPath("~/files/Temporal");

            // Se verifica si el directorio temporal existe; de lo contrario, se crea.
            if (!System.IO.Directory.Exists(pathArchivo))
            {
                System.IO.Directory.CreateDirectory(pathArchivo);
            }

            // Se combina la ruta del directorio temporal con el nombre del archivo para obtener la ruta completa del archivo.
            pathArchivo = System.IO.Path.Combine(pathArchivo, archivo);

            // Se guarda el archivo cargado en la ruta especificada.
            uploadDocumentoNatural.UploadedFiles.First().SaveAs(pathArchivo);

            // Se almacena la ruta del archivo en la sesión para su posterior uso.
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

            if ((Session["SS_NOMBRE_USUARIO"] == null || Session["SS_NOMBRE_USUARIO"].ToString() == string.Empty))
            {
                if (Request.QueryString["codN"] == null)
                {
                    Response.Redirect("~/frm/procesos/frmInscripcionProceso.aspx");
                }
                string pagina = this.Request.RawUrl;
                pagina = pagina.Substring(pagina.IndexOf("frm/"));
                Response.Redirect("~/frm/seguridad/frmLogin.aspx?page=" + pagina.Replace("/", "@@").Replace("=", "**")
                    .Replace("&", "$$"));

            }

            if (!IsPostBack)
            {
                lnkInicioPosible.NavigateUrl = lnkInicioPosible.NavigateUrl + "?page=" + Request.RawUrl.Replace("InscripcionParticipacionCiudadana", "").Replace("/", "@@").Replace("=", "**").Replace("&", "$$");
            }

            if (Session["SS_NOMBRE_USUARIO"] == null || Session["SS_NOMBRE_USUARIO"].ToString() == string.Empty || Request.QueryString["codN"] == null)
            {
                btnGuardar.Visible = false;
                btnGuardarContinuar.Visible = false;
                posibleAclaracioes.Visible = true;
            }
            else
            {
                posibleAclaracioes.Visible = false;
            }

            if (!IsPostBack)
            {
                lblTic.Text = DateTime.Now.Ticks.ToString().Substring(10);
                Session["ticsfile"] = lblTic.Text;
                Session["ArchivosCargadosN"] = null;
                int codR = 0;

                if (Session["SS_COD_REGISTRO"] != null) codR = int.Parse(Session["SS_COD_REGISTRO"].ToString());

                if (Request.QueryString["codN"] != null && Request.QueryString["codN"] != string.Empty)
                {
                    //lnkPDF.Visible = true;
                    //lnkPDF.HRef = "../informes/frmReportViewer.aspx?cod=" + Request.QueryString["codN"];
                    clsNegocio obj = new clsNegocio();
                    var registro = obj.obtenerNOMINACION_PROCESO(int.Parse(Request.QueryString["codN"]));
                    var registroUsuario = obj.obtenerRegistroxCodigo(codR);
                    pnlNominador.Visible = false;

                    if (registroUsuario.ES_PERSONA_NATURAL)
                    {
                        txtNombreNominador.Text = registroUsuario.NOMBRE.Trim() + " " + registroUsuario.APELLIDOS;
                        txtTipoAator.Text = "Persona natural";
                    }
                    else
                    {
                        txtNombreNominador.Text = registroUsuario.NOMBRE.Trim();
                        txtTipoAator.Text = registroUsuario.TIPO_JURIDICO.NOMBRE_TIPO_JURIDICO;
                    }


                    foreach (var k in registro.ARCHIVOXNOMINACION)
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
                    txtNombreTecnologia.Text = registro.NOMBRE_TECNOLOGIA;
                    txtEnfermedad.Text = registro.NOMBRE_ENFERMEDAD_CONDICION_SALUD;

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

                    //if (registro.RUTA_EVIDENCIA != string.Empty)
                    //{
                    //    ArchivosCargados.Add(registro.RUTA_EVIDENCIA);
                    //}

                    if (registro.COD_ESTADO_NOMINACION > 2 && Session["SS_COD_REGISTRO"] != null )
                       // && (registro.COD_REGISTRO.ToString() == Session["SS_COD_REGISTRO"].ToString()))
                    {

                        criterioB.Visible = false;
                        criterioC.Visible = false;
                        criterioD.Visible = false;
                        criterioE.Visible = false;
                       
                        if (registro.CRITERIO_B.Value)
                            criterioB.Visible = true;
                        if (registro.CRITERIO_C.Value)
                            criterioC.Visible = true;
                        if (registro.CRITERIO_D.Value)
                            criterioD.Visible = true;
                        if (registro.CRITERIO_E.Value)
                            criterioE.Visible = true;

                        pnlValidacionConflicto.Visible = true;                    
                        pnlValidacionEvidencia.Visible = true;

                        var nominacion = obj.obtenerVALIDACION_PROCESO(registro.COD_NOMINACION_PROCESO);
                        var parametros = obj.obtenerPARAMETRO_VALIDACION();

                    }

                }
            }

            renderArchivos();
        }

        /// <summary>
        /// Maneja el evento de clic en el botón de guardar y continuar.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        protected void btnGuardarContinuar_Click(object sender, EventArgs e)
        {
            // Verifica si los campos son válidos antes de realizar el guardado.
            if (validar())
            {
                // Realiza el guardado de la información.
                guardar();
            }
        }

        /// <summary>
        /// Maneja el evento de clic en el botón de guardar.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            guardar();
        }


        private bool validar()
        {
            bool error = false;
            LblValidacionCampos.Text = "";
            LblValidacionCampos.Text += "Verifique los Siguientes Campos: ";

            // Crear una lista de CheckBox para almacenar los checkboxes a verificar
            List<CheckBox> checkboxes = new List<CheckBox>
                {
                    chkExclusionB,chkExclusionC,chkExclusionD,chkExclusionE
                };

            // Variable para rastrear si al menos un checkbox ha sido seleccionado
            bool alMenosUnCheckBoxSeleccionado = false;

            // Recorrer la lista de checkboxes y verificar si alguno está seleccionado
            foreach (CheckBox checkbox in checkboxes)
            {
                if (checkbox.Checked)
                {
                    alMenosUnCheckBoxSeleccionado = true;
                    break; // Detener el bucle si se encuentra al menos un checkbox seleccionado
                }
            }

            // Validar si al menos un checkbox ha sido seleccionado
            if (!alMenosUnCheckBoxSeleccionado)
            {
                error = true;
                LblValidacionCampos.Text += "Debe seleccionar al menos un criterio para nominar la tecnología, ";
            }

            if (txtObservacionesNotivanNominacion.Text.Trim() == string.Empty)
            {
                error = true;
                txtObservacionesNotivanNominacion.CssClass = "";
                txtObservacionesNotivanNominacion.Attributes.Remove("placeholder");
                LblValidacionCampos.Text += "Observaciones que motivan la nominación,  ";
                txtObservacionesNotivanNominacion.Attributes.Add("placeholder", "Debe ingresar la descripción del motivo de la nominación");
                txtObservacionesNotivanNominacion.CssClass = "form-control errormin";
            }
            if (chkExclusionB.Checked && txtJustificacionB.Text.Trim() == string.Empty)
            {
                error = true;
                txtJustificacionB.CssClass = "";
                txtJustificacionB.Attributes.Remove("placeholder");
                LblValidacionCampos.Text += "criterios de exclusión B,  ";
                txtJustificacionB.Attributes.Add("placeholder", "Debe ingresar la descripción del criterios de exclusión");
                txtJustificacionB.CssClass = "form-control errormin";
            }
            if (chkExclusionC.Checked && txtJustificacionC.Text.Trim() == string.Empty)
            {
                error = true;
                txtJustificacionC.CssClass = "";
                txtJustificacionC.Attributes.Remove("placeholder");
                LblValidacionCampos.Text += "criterios de exclusión C,  ";
                txtJustificacionC.Attributes.Add("placeholder", "Debe ingresar la descripción del criterios de exclusión");
                txtJustificacionC.CssClass = "form-control errormin";
            }
            if (chkExclusionD.Checked && txtJustificacionD.Text.Trim() == string.Empty)
            {
                error = true;
                txtJustificacionD.CssClass = "";
                txtJustificacionD.Attributes.Remove("placeholder");
                LblValidacionCampos.Text += "criterios de exclusión D,  ";
                txtJustificacionD.Attributes.Add("placeholder", "Debe ingresar la descripción del criterios de exclusión");
                txtJustificacionD.CssClass = "form-control errormin";
            }
            if (chkExclusionE.Checked && txtJustificacionE.Text.Trim() == string.Empty)
            {
                error = true;
                txtJustificacionE.CssClass = "";
                txtJustificacionE.Attributes.Remove("placeholder");
                LblValidacionCampos.Text += "criterios de exclusión E,  ";
                txtJustificacionE.Attributes.Add("placeholder", "Debe ingresar la descripción del criterios de exclusión");
                txtJustificacionE.CssClass = "form-control errormin";
            }
            if (!chkAdjuntaEvidencia.Checked && !chkNoAdjuntaEvidencia.Checked)
            {
                error = true;
                LblValidacionCampos.Text += "Debe seleccionar si adjunta evidencia,  ";
            }
            if (!chkConflictoInteres.Checked && !chkNoConflictoInteres.Checked)
            {
                error = true;
                LblValidacionCampos.Text += "Debe seleccionar si tiene conflicto de intereses,  ";
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

            return !error;
        }

        /// <summary>
        /// Este método se utiliza para enviar información relacionada con la nominación de criterios excluyentes.
        /// </summary>
        /// <param name="COD_NOMINACION_EXCLUYENTE">El código de la nominación excluyente.</param>
        private void enviar(int COD_NOMINACION_EXCLUYENTE)
        {
            // Crea una instancia de la clase clsNegocio.
            clsNegocio cls = new clsNegocio();

            // Texto informativo para la nominación recibida.
            string textoNuevo = "Queremos informarle que su nominación ha sido recibida";

            // Llama al método de la clase de negocios para enviar información sobre la nominación excluyente.
            cls.enviarNominacionCriteriosExcluyentes(COD_NOMINACION_EXCLUYENTE, 2);

            // Configura mensajes para la sesión.
            Session["msgtitulo"] = "Gracias por realizar su nominación";
            Session["msgmsg"] =
                @"Muchas gracias por su participación en el proceso de revisión de una exclusión por no aplicación de criterio(s) excluyente(s). " +
                textoNuevo +
                @"<br><br>Le comunicaremos oportunamente cualquier tipo de novedad con respecto a su nominación.<br><br>";

            // Crea una instancia de la clase clsWebUtils para enviar un correo electrónico.
            clsWebUtils email = new clsWebUtils();

            // Obtiene el asunto y cuerpo del correo electrónico desde la sesión.
            string asunto = Session["msgtitulo"].ToString();
            string cuerpo = Session["msgmsg"].ToString();

            // Envia el correo electrónico al destinatario (correo registrado en la sesión).
            email.enviarEmail(asunto, cuerpo, Session["SS_CORREO"].ToString());

            // Redirecciona a la página de mensajes.
            Response.Redirect("~/frm/logica/frmMensajeIframe.aspx");
        }


        /// <summary>
        /// Este método se utiliza para guardar la nominación de criterios excluyentes.
        /// </summary>
        private void guardar()
        {
            // Verifica si no hay un código de registro en la sesión.
            if (Session["SS_COD_REGISTRO"] == null)
            {
                // Redirecciona a la página de inicio de sesión.
                Response.Redirect("~/aspx/seguridad/frmLogin.aspx");
                return;
            }

            int vigencia = 0;

            // Verifica si no hay un código de nominación en la consulta.
            if (Request.QueryString["codN"] == null)
            {
                // Verifica si no hay una vigencia en la consulta o si no hay un código de registro en la sesión.
                if (Request.QueryString["v"] == null || Session["SS_COD_REGISTRO"] == null)
                {
                    // Redirecciona a la página de inicio de sesión con una página de destino específica.
                    Response.Redirect("~/aspx/seguridad/frmLogin.aspx?page=aspx@@evento@@frmconfirmacionevento.aspx");
                    return;
                }
                else
                {
                    vigencia = int.Parse(Request.QueryString["v"]);
                }
            }

            // Crea una nueva instancia de NOMINACION_CRITERIO_EXCLUYENTE.
            NOMINACION_CRITERIO_EXCLUYENTE nominacion = new NOMINACION_CRITERIO_EXCLUYENTE();

            // Crea una instancia de la clase clsNegocio.
            clsNegocio cls = new clsNegocio();

            // Verifica si hay un código de nominación en la etiqueta lblCodNominacionProceso.
            if (lblCodNominacionProceso.Text.Trim() != string.Empty)
            {
                nominacion.COD_EXCLUSION = int.Parse(lblCodNominacionProceso.Text);
            }

            // Crea una lista de ARCHIVOXNOMINACIONXCRITERIO para almacenar archivos adjuntos.
            List<ARCHIVOXNOMINACIONXCRITERIO> lista = new List<ARCHIVOXNOMINACIONXCRITERIO>();

            // Itera sobre los archivos cargados y los agrega a la lista.
            for (int k = 0; k < ArchivosCargados.Count; k++)
            {
                ARCHIVOXNOMINACIONXCRITERIO ar = new ARCHIVOXNOMINACIONXCRITERIO();
                ar.DESCRIPCION_ARCHIVO = ArchivosCargados[k].descripcion;
                ar.URL_ARCHIVO = ArchivosCargados[k].url;
                lista.Add(ar);
            }

            // Configura los atributos de la nominación.
            nominacion.COD_REGISTRO = int.Parse(Session["SS_COD_REGISTRO"].ToString());
            nominacion.FECHA_NOMINACION = DateTime.Now;
            nominacion.OBSERVACIONES_NOMINACION = txtObservacionesNotivanNominacion.Text.Trim();
            nominacion.EXCLUIDA_CRITERIO_B = chkExclusionB.Checked;
            nominacion.DESC_EXCLUIDA_CRITERIO_B = txtJustificacionB.Text.Trim();
            nominacion.EXCLUIDA_CRITERIO_C = chkExclusionC.Checked;
            nominacion.DESC_EXCLUIDA_CRITERIO_C = txtJustificacionC.Text.Trim();
            nominacion.EXCLUIDA_CRITERIO_D = chkExclusionD.Checked;
            nominacion.DESC_EXCLUIDA_CRITERIO_D = txtJustificacionD.Text.Trim();
            nominacion.EXCLUIDA_CRITERIO_E = chkExclusionE.Checked;
            nominacion.DESC_EXCLUIDA_CRITERIO_E = txtJustificacionE.Text.Trim();
            nominacion.ADJUNTA_EVIDENCIA = chkAdjuntaEvidencia.Checked;
            nominacion.CONFLICTO_INTERES = chkConflictoInteres.Checked;
            nominacion.OBSERVACIONES_EVIDENCIA = txtEvidencia.Text.Trim();
            nominacion.OBSERVACIONES_CONFLICTO = txtConflicto.Text.Trim();
            nominacion.COD_ESTADO_NOMINACION = 1;

            // Llama al método de la clase de negocios para guardar la nominación y archivos adjuntos.
            int i = cls.GuardarNominacionCriteriosExcluyentes(nominacion, lista);

            // Llama al método para enviar alguna acción dependiendo del resultado de guardar.
            enviar(i);
            // lblArchivoView.HRef
        }

        /// <summary>
        /// Este método se ejecuta cuando se hace clic en el botón "Adjuntar Archivo".
        /// Inicializa el valor de la sesión "archivoPuente" como nulo, muestra el formulario emergente y restablece los campos del formulario de detalles de archivo.
        /// </summary>
        protected void btnArchivo_Click(object sender, EventArgs e)
        {
            // Inicializa el valor de la sesión "archivoPuente" como nulo.
            Session["archivoPuente"] = null;

            // Muestra el formulario emergente.
            popupNuevo.Show();

            // Restablece los campos del formulario de detalles de archivo.
            txtDescripcionArchivo.Text = "";
            lblErrorDetalle.Text = "";
        }

        /// <summary>
        /// Este método se ejecuta cuando se hace clic en el botón "Cancelar" en el formulario emergente de detalles de archivo.
        /// Oculta el formulario emergente sin realizar ninguna operación adicional.
        /// </summary>
        protected void btnCancelarDetalle_Click(object sender, EventArgs e)
        {
            // Oculta el formulario emergente.
            popupNuevo.Hide();
        }

        /// <summary>
        /// Este método se ejecuta cuando se hace clic en el botón "Aceptar" en el formulario emergente de detalles de archivo.
        /// Verifica si se ha ingresado una descripción y se ha adjuntado un archivo. Si ambos requisitos se cumplen,
        /// crea un nuevo objeto 'archivos', lo agrega a la lista 'ArchivosCargados' y actualiza la interfaz de usuario.
        /// Cierra el formulario emergente después de realizar la operación.
        /// </summary>
        protected void btnAceptarDetalle_Click(object sender, EventArgs e)
        {
            // Verifica si se ha ingresado una descripción.
            if (txtDescripcionArchivo.Text == string.Empty)
            {
                lblErrorDetalle.Text = "Debe ingresar la descripción del archivo";
                return;
            }

            // Verifica si se ha adjuntado un archivo.
            if ((Session["archivoPuente"] == null || Session["archivoPuente"].ToString() == string.Empty))
            {
                lblErrorDetalle.Text = "Debe adjuntar el archivo";
                return;
            }

            // Crea un nuevo objeto 'archivos' con la descripción y la URL del archivo adjunto.
            archivos ar = new archivos
            {
                descripcion = txtDescripcionArchivo.Text,
                url = Session["archivoPuente"].ToString()
            };

            // Agrega el nuevo objeto 'archivos' a la lista 'ArchivosCargados'.
            ArchivosCargados.Add(ar);

            // Cierra el formulario emergente.
            popupNuevo.Hide();

            // Actualiza la interfaz de usuario con la lista actualizada de archivos cargados.
            renderArchivos();
        }


        /// <summary>
        /// Este método actualiza la interfaz de usuario con la lista actualizada de archivos cargados.
        /// Actualiza el origen de datos y vuelve a enlazar los datos a la cuadrícula de archivos (grdArchivos).
        /// También actualiza la región de actualización (pnlGrillaArchivos) para reflejar los cambios en la interfaz de usuario.
        /// </summary>
        private void renderArchivos()
        {
            // Establece la lista de archivos como origen de datos para la cuadrícula de archivos.
            grdArchivos.DataSource = ArchivosCargados;

            // Vuelve a enlazar los datos a la cuadrícula de archivos.
            grdArchivos.DataBind();

            // Actualiza la región de actualización para reflejar los cambios en la interfaz de usuario.
            pnlGrillaArchivos.Update();
        }


        /// <summary>
        /// Este método se ejecuta al hacer clic en el botón de eliminación de archivos.
        /// Elimina el archivo correspondiente de la lista de archivos cargados y actualiza la interfaz de usuario.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento (ImageButton).</param>
        /// <param name="e">Los argumentos del evento.</param>
        protected void btnelimnarARchivo_Click(object sender, ImageClickEventArgs e)
        {
            // Convierte el objeto sender a un ImageButton para acceder a sus propiedades y eventos.
            ImageButton b = (ImageButton)sender;

            // Itera a través de la lista de archivos cargados para encontrar y eliminar el archivo correspondiente.
            for (int k = 0; k < ArchivosCargados.Count; k++)
            {
                if (ArchivosCargados[k].url == b.ValidationGroup)
                {
                    // Elimina el archivo de la lista.
                    ArchivosCargados.RemoveAt(k);
                    break;
                }
            }

            // Actualiza la interfaz de usuario para reflejar los cambios en la lista de archivos cargados.
            renderArchivos();
        }

    }
}