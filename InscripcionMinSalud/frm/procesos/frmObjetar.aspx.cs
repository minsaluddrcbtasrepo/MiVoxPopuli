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
    public partial class frmObjetar : System.Web.UI.Page
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

        private List<archivos> ArchivosCargados2
        {
            get
            {
                if (Session["ArchivosCargadosN2"] == null)
                {
                    Session["ArchivosCargadosN2"] = new List<archivos>();
                }
                return (List<archivos>)Session["ArchivosCargadosN2"];
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


        protected void Page_Load(object sender, EventArgs e)
        {

            if ((Session["SS_NOMBRE_USUARIO"] == null || Session["SS_NOMBRE_USUARIO"].ToString() == string.Empty) &&
                Request.QueryString["codobjecion"] == null)
            {
                string pagina = this.Request.RawUrl;
                pagina = pagina.Substring(pagina.IndexOf("frm/"));
                Response.Redirect("~/frm/seguridad/frmLogin.aspx?page="+pagina.Replace("/","@@").Replace("=", "**")
                    .Replace("&", "$$"));

            }
            
            if (!IsPostBack)
            {
                lblTic.Text = DateTime.Now.Ticks.ToString().Substring(10);
                Session["ticsfile"] = lblTic.Text;
                Session["ArchivosCargadosN"] = null;

                if (Request.QueryString["codN"] != null && Request.QueryString["codN"] != string.Empty)
                {

                    clsNegocio negocio = new clsNegocio();


                    var registro = negocio.obtenerNOMINACION_PROCESO(int.Parse(Request.QueryString["codN"]));

                    if (registro.REGISTRO.ES_PERSONA_JURIDICA == true)
                    {
                        txttipoUsuario.Text = registro.REGISTRO.TIPO_JURIDICO.NOMBRE_TIPO_JURIDICO;
                        txtNombre.Text = registro.REGISTRO.NOMBRE;
                     

                    }
                    else {
                        txttipoUsuario.Text = "Persona natural";
                        txtNombre.Text = registro.REGISTRO.NOMBRE + " " + registro.REGISTRO.APELLIDOS;
                     
                    }

                    foreach (var k in registro.ARCHIVOXNOMINACION)
                    {
                        archivos a = new archivos();
                        a.descripcion = k.DESCRIPCION_ARCHIVO;
                        a.url = k.URL_ARCHIVO;
                        ArchivosCargados.Add(a);
                    }

                    lblCodNominacionProceso.Text = registro.COD_NOMINACION_PROCESO.ToString();
                    txtNombreProceso.Text = registro.PROCESO.NOMBRE_PROCESO;
                    txtNombreTecnologia.Text = registro.NOMBRE_TECNOLOGIA;
                    txtConflicto.Text = registro.OBSERVACIONES_CONFLICTO;
                    txtEnfermedad.Text = registro.CIE10;
                    txtEnfermedad2.Text = registro.CIE10_2;
                    txtEnfermedad.Text = registro.NOMBRE_ENFERMEDAD_CONDICION_SALUD;
                    txtEnfermedad2.Text = registro.OBSERVACION_TECNOLOGIA;
                    txtEvidencia.Text = registro.OBSERVACIONES_EVIDENCIA;
                    txtJustificacionA.Text = registro.OBS_CRITERIO_A;
                    txtJustificacionB.Text = registro.OBS_CRITERIO_B;
                    txtJustificacionC.Text = registro.OBS_CRITERIO_C;
                    txtJustificacionD.Text = registro.OBS_CRITERIO_D;
                    txtJustificacionE.Text = registro.OBS_CRITERIO_E;
                    txtJustificacionF.Text = registro.OBS_CRITERIO_F;
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
                    #region desahbilitamos los controles
                    txtConflicto.ReadOnly = true;
                    txtNombreProceso.ReadOnly = true;
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
                    chkExclusionA.Enabled = false;
                    chkExclusionB.Enabled = false;
                    chkExclusionC.Enabled = false;
                    chkExclusionD.Enabled = false;
                    chkExclusionE.Enabled = false;
                    chkExclusionF.Enabled = false;
                    chkNoAdjuntaEvidencia.Enabled = false;
                    chkNoConflictoInteres.Enabled = false;
                    #endregion
                    
                    if (Request.QueryString["codobjecion"] != null)
                    {
                        #region deshabilitamos los combos de validacion
                        cmbGrupoCie10.Enabled = false;
                        cmbGrupoCie10b.Enabled = false;
                       
                        cmbGrupoConcepto.Enabled = false;
                        cmbGrupoConflicto.Enabled = false;
                        cmbGrupoCriterioA.Enabled = false;
                        cmbGrupoCriterioB.Enabled = false;
                        cmbGrupoCriterioC.Enabled = false;
                        cmbGrupoCriterioD.Enabled = false;
                        cmbGrupoCriterioE.Enabled = false;
                        cmbGrupoCriterioF.Enabled = false;
                        cmbGrupoEvidencia.Enabled = false;
                        cmbGrupoNombreTecnologia.Enabled = false;
                        txtObservacionesGenerales.ReadOnly = true;
                        #endregion
                        btnCancelar.Visible = false;
                        btnGuardar.Visible = false;
                        btnArchivo.Visible = false;
                        lnkPDF.Visible = true;
                        lnkPDF.NavigateUrl = "~/frm/informes/frmReportViewer.aspx?cod="+ Request.QueryString["codobjecion"]+"&rpt=1";
                        lblAdjunteDocumento.Visible = false;
                        var nominacion = negocio.obtenerOBJECION_PROCESOxCodigo(int.Parse(Request.QueryString["codobjecion"]));
                        FieldsetNominador.Visible = true;
                        if (nominacion.REGISTRO.ES_PERSONA_JURIDICA == true)
                        {
                            txtTipoUsuarioObjetador.Text = nominacion.REGISTRO.TIPO_JURIDICO.NOMBRE_TIPO_JURIDICO;
                            txtNombreObjetador.Text = nominacion.REGISTRO.NOMBRE;
                          

                        }
                        else
                        {
                            txtTipoUsuarioObjetador.Text = "Persona natural";
                            txtNombreObjetador.Text = nominacion.REGISTRO.NOMBRE + " " + nominacion.REGISTRO.APELLIDOS;
                           

                        }


                        var parametros = negocio.obtenerPARAMETRO_VALIDACION();
                        txtObservacionesGenerales.Text = nominacion.OBSERVACIONES_GENERALES;

                        cmbGrupoNombreTecnologia.Text = nominacion.OBS_NOMBRE_TECNOLOGIA;
                        cmbGrupoCie10.Text = nominacion.OBS_CIE10;                      
                        cmbGrupoCie10b.Text = nominacion.OBS_CIE10_2;
                            cmbGrupoCriterioA.Text = nominacion.OBS_CREITERIO_A;
                            cmbGrupoCriterioB.Text = nominacion.OBS_CREITERIO_B;
                            cmbGrupoCriterioC.Text = nominacion.OBS_CREITERIO_C;
                            cmbGrupoCriterioD.Text = nominacion.OBS_CREITERIO_D;
                            cmbGrupoCriterioE.Text = nominacion.OBS_CREITERIO_E;
                            cmbGrupoCriterioF.Text = nominacion.OBS_CREITERIO_F;
                            cmbGrupoEvidencia.Text = nominacion.OBS_EVIDENCIA;
                            cmbGrupoConflicto.Text = nominacion.OBS_CONFLICTO_INTERES;
                            cmbGrupoConcepto.Text = nominacion.OBS_CONCEPTO;
                            
                    }

                }
            }

            renderArchivos();
        }

        /// <summary>
        /// Maneja el evento Click del botón "Guardar".
        /// Realiza la validación del formulario y, si es exitosa, guarda la información.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento (en este caso, el botón "Guardar").</param>
        /// <param name="e">Argumentos del evento.</param>
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                guardar();
            }
        }

        /// <summary>
        /// Realiza la validación de los campos antes de guardar el resultado de la objeción.
        /// </summary>
        /// <returns>Devuelve true si la validación es exitosa; de lo contrario, false.</returns>
        private bool validar()
        {
            clsNegocio cls = new clsNegocio();
            bool error = false;
            LblValidacionCampos.Text = "";
            LblValidacionCampos.Text += "Verifique los Siguientes Campos: ";
            int noOk = 0;

            if (cmbGrupoNombreTecnologia.Text == "")
            {
                cmbGrupoNombreTecnologia.CssClass = "";
                LblValidacionCampos.Text += "Objeción nombre de la tecnología,  ";
                cmbGrupoNombreTecnologia.CssClass = "form-control errormin";
            }
            

           

            if (cmbGrupoCie10.Text == "")
            {
                error = true;
                cmbGrupoCie10.CssClass = "";
                LblValidacionCampos.Text += "Objeción CIE10,  ";
                cmbGrupoCie10.Attributes.Add("placeholder", "Debe ingresar El resultado de Objeción de CIE10");
                cmbGrupoCie10.CssClass = "form-control errormin";
            }           

            if (cmbGrupoCie10b.Text == "")
            {
                cmbGrupoCie10b.CssClass = "";
                error = true;
                LblValidacionCampos.Text += "Objeción CIE10,  ";
                cmbGrupoCie10b.Attributes.Add("placeholder", "Debe ingresar El resultado de Objeción de CIE10");
                cmbGrupoCie10b.CssClass = "form-control errormin";
            }

           




            if (chkExclusionA.Checked)
            {
                if (cmbGrupoCriterioA.Text == "")
                {
                    cmbGrupoCriterioA.CssClass = "";
                    error = true;
                    LblValidacionCampos.Text += "Objeción criterio de exclusión A,  ";
                    cmbGrupoCriterioA.Attributes.Add("placeholder", "Debe ingresar El resultado de Objeción de criterio de exclusión A");
                    cmbGrupoCriterioA.CssClass = "form-control errormin";
                }
               
            }
            if (chkExclusionB.Checked)
            {
                if (cmbGrupoCriterioB.Text == "")
                {
                    cmbGrupoCriterioB.CssClass = "";
                    error = true;
                    LblValidacionCampos.Text += "Objeción criterio de exclusión B,  ";
                    cmbGrupoCriterioB.Attributes.Add("placeholder", "Debe ingresar El resultado de Objeción de criterio de exclusión B");
                    cmbGrupoCriterioB.CssClass = "form-control errormin";
                }
               
            }
            if (chkExclusionC.Checked)
            {
                if (cmbGrupoCriterioC.Text == "")
                {
                    cmbGrupoCriterioC.CssClass = "";
                    error = true;
                    LblValidacionCampos.Text += "Objeción criterio de exclusión C,  ";
                    cmbGrupoCriterioC.Attributes.Add("placeholder", "Debe ingresar El resultado de Objeción de criterio de exclusión C");
                    cmbGrupoCriterioC.CssClass = "form-control errormin";
                }
             
            }
            if (chkExclusionD.Checked)
            {
                if (cmbGrupoCriterioD.Text == "")
                {
                    cmbGrupoCriterioD.CssClass = "";
                    error = true;
                    LblValidacionCampos.Text += "Objeción  criterio de exclusión D,  ";
                    cmbGrupoCriterioD.Attributes.Add("placeholder", "Debe ingresar El resultado de Objeción de criterio de exclusión D");
                    cmbGrupoCriterioD.CssClass = "form-control errormin";
                }
              
            }

            if (chkExclusionE.Checked)
            {
                if (cmbGrupoCriterioE.Text == "")
                {
                    cmbGrupoCriterioE.CssClass = "";
                    error = true;
                    LblValidacionCampos.Text += "Objeción criterio de exclusión E,  ";
                    cmbGrupoCriterioE.Attributes.Add("placeholder", "Debe ingresar El resultado de Objeción de criterio de exclusión E");
                    cmbGrupoCriterioE.CssClass = "form-control errormin";
                }
              
            }
            if (chkExclusionF.Checked)
            {
                if (cmbGrupoCriterioF.Text == "")
                {
                    cmbGrupoCriterioF.CssClass = "";
                    error = true;
                    LblValidacionCampos.Text += "Objeción criterio de exclusión F,  ";
                    cmbGrupoCriterioF.Attributes.Add("placeholder", "Debe ingresar El resultado de Objeción de criterio de exclusión F");
                    cmbGrupoCriterioF.CssClass = "form-control errormin";
                }
               
            }



            if (chkAdjuntaEvidencia.Checked)
            {
                if (cmbGrupoEvidencia.Text == "")
                {
                    cmbGrupoEvidencia.CssClass = "";
                    error = true;
                    LblValidacionCampos.Text += "Objeción evidencia,  ";
                    cmbGrupoEvidencia.Attributes.Add("placeholder", "Debe ingresar El resultado de Objeción evidencia");
                    cmbGrupoEvidencia.CssClass = "form-control errormin";
                }
               
            }

            if (chkConflictoInteres.Checked)
            {
                if (cmbGrupoConflicto.Text == "")
                {
                    cmbGrupoConflicto.CssClass = "";
                    error = true;
                    LblValidacionCampos.Text += "Objeción criterio de conflicto de interes,  ";
                    cmbGrupoConflicto.Attributes.Add("placeholder", "Debe ingresar El resultado de Objeción de conflicto de interes");
                    cmbGrupoConflicto.CssClass = "form-control errormin";
                }
            }
            
            if (cmbGrupoConcepto.Text == "")
            {
                cmbGrupoConcepto.CssClass = "";
                error = true;
                LblValidacionCampos.Text += "Objeción concepto,  ";
                cmbGrupoConcepto.CssClass = "form-control errormin";
            }
            
            return !error;
        }

        /// <summary>
        /// Guarda el resultado de la validación de una nominación.
        /// </summary>
        private void guardar()
        {
            clsNegocio cls = new clsNegocio();
            int? codN = null;

            // Verifica si hay un código de nominación y lo asigna
            if (lblCodNominacionProceso.Text.Trim() != string.Empty)
            {
                codN = int.Parse(lblCodNominacionProceso.Text);
            }

            //siempre creamos un maestro nuevo
            List<ARCHIVOXOBJECION> lista = new List<ARCHIVOXOBJECION>();

            for (int k = 0; k < ArchivosCargados2.Count; k++)
            {
                ARCHIVOXOBJECION ar = new ARCHIVOXOBJECION();
                ar.DESCRIPCION_ARCHIVO = ArchivosCargados2[k].descripcion;
                ar.URL_ARCHIVO = ArchivosCargados2[k].url;
                lista.Add(ar);
            }
            // Llama al método de clsNegocio para guardar el resultado de la validación
            cls.GuardarResultadoValidacionNominacion(null, codN.Value,DateTime.Now,
                int.Parse(Session["SS_COD_REGISTRO"].ToString()),txtObservacionesGenerales.Text,
               cmbGrupoNombreTecnologia.Text , cmbGrupoCie10.Text,cmbGrupoCie10b.Text,
              "","","",
               "","",cmbGrupoCriterioA.Text,
               cmbGrupoCriterioB.Text, cmbGrupoCriterioC.Text, cmbGrupoCriterioD.Text,
               cmbGrupoCriterioE.Text, cmbGrupoCriterioF.Text,cmbGrupoEvidencia.Text,
               cmbGrupoConflicto.Text,cmbGrupoConcepto.Text
                               , lista);
            // Obtiene la nominación proceso
            var obj = cls.obtenerNOMINACION_PROCESO(int.Parse(lblCodNominacionProceso.Text));

            Session["msgtitulo"] = "Gracias por completar su objeción";
            Session["msgmsg"] = @"Muchas gracias por su participación en el  " + obj.PROCESO.NOMBRE_PROCESO + @". Queremos informarle que su objeción ha sido recibida.
<br>
<br>
Le comunicaremos oportunamente cualquier tipo de novedad con respecto a su objeción.
<br>
<br>
";
            // Envia un correo de notificación al usuario
            clsWebUtils email = new clsWebUtils();
            string asunto = Session["msgtitulo"].ToString();
            string cuerpo = Session["msgmsg"].ToString();
            email.enviarEmail(asunto, cuerpo, Session["SS_CORREO"].ToString());

            // Redirige a la página de mensajes
            Response.Redirect("~/frm/logica/frmMensaje.aspx");

        }

        /// <summary>
        /// Envía la nominación para su verificación.
        /// </summary>
        private void enviar()
        {
            // Descomentar las siguientes líneas si se tiene la clase clsNegocio y el método enviarNominacion
            // clsNegocio cls = new clsNegocio();
            // cls.enviarNominacion(int.Parse(lblCodNominacionProceso.Text), 2);

            // Configura mensajes para la sesión
            Session["msgtitulo"] = "Nominación creada satisfactoriamente";
            Session["msgmsg"] = "La información ha sido guardada y enviada para su verificación. Se le informará próximamente si ésta ha sido aceptada.";

            // Redirige a la página de mensajes
            Response.Redirect("~/frm/logica/frmMensaje.aspx");
        }


        /// <summary>
        /// Renderiza la lista de archivos cargados en el control GridView.
        /// </summary>
        private void renderArchivos()
        {
            // Configura la fuente de datos y enlaza con el control GridView
            grdArchivos.DataSource = ArchivosCargados;
            grdArchivos.DataBind();

            // Actualiza el panel que contiene el control GridView
            pnlGrillaArchivos.Update();
        }


        /// <summary>
        /// Evento que se ejecuta al hacer clic en el botón de cancelar.
        /// </summary>
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            // Redirige a la página de inscripción de proceso con los parámetros necesarios
            Response.Redirect("~/frm/procesos/frmInscripcionProceso.aspx?codN=" + Request.QueryString["codN"] + "&codProceso=" + Request.QueryString["codProceso"]);
        }


        /// <summary>
        /// Evento que se ejecuta al hacer clic en el botón de archivo.
        /// </summary>
        protected void btnArchivo_Click(object sender, EventArgs e)
        {
            // Reinicia la sesión de archivoPuente
            Session["archivoPuente"] = null;

            // Muestra el popup de nuevo archivo
            popupNuevo.Show();

            // Reinicia el campo de descripción del archivo
            txtDescripcionArchivo.Text = "";

            // Reinicia el mensaje de error en el detalle
            lblErrorDetalle.Text = "";
        }



        /// <summary>
        /// Evento que se ejecuta al hacer clic en el botón de cancelar en el detalle del archivo.
        /// </summary>
        protected void btnCancelarDetalle_Click(object sender, EventArgs e)
        {
            // Oculta el popup de detalle
            popupNuevo.Hide();
        }


        /// <summary>
        /// Evento que se ejecuta al hacer clic en el botón de aceptar en el detalle del archivo.
        /// </summary>
        protected void btnAceptarDetalle_Click(object sender, EventArgs e)
        {
            // Verifica si la descripción del archivo está vacía
            if (txtDescripcionArchivo.Text == string.Empty)
            {
                lblErrorDetalle.Text = "Debe ingresar la descripción del archivo";
                return;
            }

            // Verifica si no se ha adjuntado un archivo
            if (Session["archivoPuente"] == null || Session["archivoPuente"].ToString() == string.Empty)
            {
                lblErrorDetalle.Text = "Debe adjuntar el archivo";
                return;
            }

            // Crea una instancia de la clase archivos y asigna la descripción y la URL
            archivos ar = new archivos();
            ar.descripcion = txtDescripcionArchivo.Text;
            ar.url = Session["archivoPuente"].ToString();

            // Agrega la instancia a la lista de archivos cargados
            ArchivosCargados2.Add(ar);

            // Oculta el popup y actualiza la presentación de la lista de archivos
            popupNuevo.Hide();
            renderArchivos2();
        }


        /// <summary>
        /// Actualiza la presentación de la lista de archivos en el control GridView.
        /// </summary>
        private void renderArchivos2()
        {
            // Asigna la fuente de datos y vuelve a enlazar los datos al GridView
            grdArchivos2.DataSource = ArchivosCargados2;
            grdArchivos2.DataBind();

            // Actualiza el panel que contiene el GridView para reflejar los cambios
            pnlGrillaArchivos2.Update();
        }


        /// <summary>
        /// Maneja el evento de clic en el botón para eliminar un archivo.
        /// </summary>
        /// <param name="sender">El objeto que ha desencadenado el evento.</param>
        /// <param name="e">Los argumentos del evento.</param>
        protected void btnelimnarARchivo_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton b = (ImageButton)sender;

            // Itera sobre la lista de archivos cargados para encontrar y eliminar el archivo seleccionado
            for (int k = 0; k < ArchivosCargados2.Count; k++)
            {
                if (ArchivosCargados2[k].url == b.ValidationGroup)
                {
                    ArchivosCargados2.RemoveAt(k);
                    break;
                }
            }

            // Vuelve a renderizar la lista de archivos
            renderArchivos2();
        }

        /// <summary>
        /// Descarga los documentos cargados en el control de carga de archivos uploadDocumentoNatural.
        /// </summary>
        protected void DescargarDocumentos()
        {
            string archivo = "";
            archivo = "3-" + Session["ticsfile"] + uploadDocumentoNatural.UploadedFiles[0].FileName;
            string pathArchivo = Server.MapPath("~/files/Temporal");

            // Verifica si el directorio no existe y lo crea
            if (!System.IO.Directory.Exists(pathArchivo))
            {
                System.IO.Directory.CreateDirectory(pathArchivo);
            }

            // Combina la ruta del archivo con el nombre del mismo
            pathArchivo = System.IO.Path.Combine(pathArchivo, archivo);

            // Guarda el archivo en la ruta especificada
            uploadDocumentoNatural.UploadedFiles.First().SaveAs(pathArchivo);

            // Almacena la ruta del archivo en la sesión
            Session["archivoPuente"] = pathArchivo;
        }


        /// <summary>
        /// Maneja el evento FileUploadComplete del control de carga de archivos uploadDocumentoNatural.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los argumentos del evento.</param>
        protected void uploadDocumentoNatural_FileUploadComplete(object sender, DevExpress.Web.FileUploadCompleteEventArgs e)
        {
            // Verifica si se han cargado archivos
            if (uploadDocumentoNatural.UploadedFiles.Count() > 0)
            {
                // Ejecuta el método para procesar la descarga de documentos
                DescargarDocumentos();
            }
        }


        protected void btnGenerarPdf_Click(object sender, EventArgs e)
        {

        }
    }
}