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
    public partial class frmObjetarHuerfanas : System.Web.UI.Page
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
        /// Valida si al menos un archivo cargado tiene un nombre que comienza con el prefijo "3-".
        /// </summary>
        /// <returns>
        /// true si al menos un archivo cargado tiene un nombre que comienza con "3-", de lo contrario, false.
        /// </returns>
        private bool ValidarArchivoCargado()
        {
            // Itera a través de cada archivo cargado en la lista ArchivosCargados.
            foreach (var archivoCargado in ArchivosCargados)
            {
                // Obtiene el nombre del archivo utilizando la ruta del archivo y la función GetFileName de la clase Path.
                string nombreArchivo = System.IO.Path.GetFileName(archivoCargado.url);

                // Verifica si el nombre del archivo comienza con el prefijo "3-".
                if (nombreArchivo.StartsWith("3-"))
                {
                    // Devuelve true si encuentra al menos un archivo con el prefijo "3-".
                    return true;
                }
            }

            // Devuelve false si no se encuentra ningún archivo con el prefijo "3-".
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
          
            
            if (Session["SS_NOMBRE_USUARIO"] == null || Session["SS_NOMBRE_USUARIO"].ToString() == string.Empty)
            {
                btnGuardar.Visible = false;         
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

            
            pnlValidacionEvidencia.Visible = false;
            #endregion
            bool editaAclaraciones = false;
            if (!IsPostBack)
            {
                lblTic.Text = DateTime.Now.Ticks.ToString().Substring(10);
                Session["ticsfile"] = lblTic.Text;
                Session["ArchivosCargadosN"] = null;

                int codR = 0;
                if (Session["SS_COD_REGISTRO"] != null) {
                    codR = int.Parse(Session["SS_COD_REGISTRO"].ToString());
                }

                //cargamos la infomracion del registro
                clsNegocio obj = new clsNegocio();
                if (codR != 0)
                {
                    var reg = obj.obtenerRegistroxCodigo(codR);              
                }


                 if (Request.QueryString["codN"] != null && Request.QueryString["codN"] != string.Empty)
                 {
                   // lnkPDF.Visible = true;
                   // lnkPDF.HRef = "../informes/frmReportViewer.aspx?cod=" + Request.QueryString["codN"];
                    var registro = obj.obtenerNOMINACION_HUERFANA(int.Parse(Request.QueryString["codN"]));
                    var reg = obj.obtenerRegistroxCodigo(registro.COD_REGISTRO);
                    List<ARCHIVOXNOMINACION_HUERFANA> arch = obj.obtenerARCHIVOXNOMINACION_HUERFANA(registro.COD_NOMINACION_HUERFANAS);

                    pnlNominador.Visible = true;
                    /*
                    foreach (var k in arch.ARCHIVOXNOMINACION)
                    {
                        archivos a = new archivos();
                        a.descripcion = k.DESCRIPCION_ARCHIVO;
                        a.url = k.URL_ARCHIVO;
                        ArchivosCargados.Add(a);
                    }*/

                    if (reg.ES_PERSONA_JURIDICA == true)
                    {

                        txtNombreNominador.Text = reg.NOMBRE.Trim();
                        txtTipoAator.Text = "Pesona Juridica";
                        txtIdentificacionNominador.Text = reg.DOCUMENTO;
                        txtEmailNominador.Text = reg.CORREO;
                    }
                    else
                    {

                        txtNombreNominador.Text = reg.NOMBRE.Trim() + " " + reg.APELLIDOS;
                        txtTipoAator.Text = "Persona natural";
                        txtIdentificacionNominador.Text = reg.DOCUMENTO;
                        txtEmailNominador.Text = reg.CORREO;
                    }
                    
                    System.Configuration.AppSettingsReader ar = new System.Configuration.AppSettingsReader();
                    string url = ar.GetValue("urlLocal", typeof(string)).ToString();

                    foreach (var k in arch)
                    {
                        archivos a = new archivos();
                        a.descripcion = k.DESCRIPCION_ARCHIVO;
                        string f = System.IO.Path.GetFileName(k.URL_ARCHIVO);
                        a.url = url + "/files/DocumentosHuerfanas/" + f;
                        //ArchivosCargados.Add(a);
                        urlEvidencia.Controls.Add(new LiteralControl(@"<a href="+a.url.Replace(" ","%20")+" target="+"_blank"+">"+ a.descripcion + "</a></br>"));
                    }

                    lblCodNominacionProceso.Text = registro.COD_NOMINACION_HUERFANAS.ToString();
                   
                    chkEsIncluir.Checked = Convert.ToBoolean(registro.ES_INCLUIR);
                    chkEsExcluir.Checked = Convert.ToBoolean(registro.ES_EXCLUIR);
                    chkEsCambio.Checked = Convert.ToBoolean(registro.ES_CAMBIO);
                    chkCodigo.Checked = Convert.ToBoolean(registro.ES_CODIGO);
                    chkPruebaDiagnostica.Checked = Convert.ToBoolean(registro.ES_PRUEBA);
                    chkDiciplina.Checked = Convert.ToBoolean(registro.ES_DICIPLINA);
                    txtNombreTecnologia.Text = registro.NOMBRE;
                    txtCie10.Text = registro.CIE;
                    cmbTipoConfirmacion.SelectedValue = registro.TIPO_CONFIRMACION;

                    //txtEspecialidad.Text = registro.ESPECIALIDAD_PROPUESTA;




                    txtConfirmatoria1.Text = registro.CONFIRMATORIA_PROPUESTA;
                    txtCups1.Text = registro.CUPS_CONFIRMATORIA_PROPUESTA;
                    txtNuevoNombre.Text = registro.NUEVO_NOMBRE;
                    txtCie10NuevoNombre.Text = registro.CIE_NUEVO_NOMBRE;
                    cmbCodigoModificar.SelectedValue = registro.CODIGO_MODIFICAR;
                    txtNuevoCodigo.Text = registro.CODIGO_NUEVO;
                    txtConfirmatoriaActual.Text = registro.CONFIRMATORIA_ACTUAL;
                    txtCupsConfirmatoriaActual.Text = registro.CUPS_CONFIRMATORIA_ACTUAL;
                    txtConformatoriaPropuesta.Text = registro.CONFIRMATORIA_CAMBIO_PROPUESTO;
                    txtCUPSPruebaAlterna.Text = registro.CUPS_ALTERNA;
                    txtCupsConformatoriaPropuesta.Text = registro.CUPS_CONFIRMATORIA_CAMBIO_PROPUESTO;
                    txtEspecialidadesActuales.Text = registro.ESPECIALIDADES_ACTUALES;
                    txtEspecialidadesPropuestas.Text = registro.ESPECIALIDADES_PROPUESTAS_CAMBIO;
                    txtDescriptJustifica.Text = registro.JUSTIFICACION;
                    txtConflicto.Text = registro.INTERES_CONFLICTO;


                    if (Convert.ToBoolean(registro.ADJUNTA_EVIDENCIA))
                    {
                        chkAdjuntaEvidencia.Checked = true;
                        chkNoAdjuntaEvidencia.Checked = false;
                        txtEvidencia.Text = registro.OBSERVACIONES_EVIDENCIA;

                    }
                    else
                    {

                        chkNoAdjuntaEvidencia.Checked = true;
                        chkAdjuntaEvidencia.Checked = false;
                    }

                    if (Convert.ToBoolean(registro.CONFLICTO_INTERES))
                    {
                        chkConflictoInteres.Checked = true;
                        chkNoConflictoInteres.Checked = false;
                    }
                    else
                    {
                        chkConflictoInteres.Checked = false;
                        chkNoConflictoInteres.Checked = true;
                    }
                    txtNombreTecnologia.ReadOnly = true;
                    chkEsIncluir.Enabled = false;
                    chkEsExcluir.Enabled = false;
                    chkEsCambio.Enabled = false;
                    chkCodigo.Enabled = false;
                    chkPruebaDiagnostica.Enabled = false;
                    chkDiciplina.Enabled = false;

                    txtCie10.ReadOnly=true;
                    cmbTipoConfirmacion.Enabled = false;
                    txtEspecialidad.ReadOnly = true;
                    txtEspecialidad2.ReadOnly = true;
                    txtEspecialidad3.ReadOnly = true;
                    txtConfirmatoria1.ReadOnly = true;
                    txtCups1.ReadOnly = true;
                    txtNuevoNombre.ReadOnly = true;
                    txtCie10NuevoNombre.ReadOnly = true;
                    cmbCodigoModificar.Enabled = false;
                    txtNuevoCodigo.ReadOnly = true;
                    txtConfirmatoriaActual.ReadOnly = true;
                    txtCupsConfirmatoriaActual.ReadOnly = true;
                    txtConformatoriaPropuesta.ReadOnly = true;
                    txtCupsConformatoriaPropuesta.ReadOnly = true;
                    txtEspecialidadesActuales.ReadOnly = true;
                    txtEspecialidadesPropuestas.ReadOnly = true;
                    txtDescriptJustifica.ReadOnly = true;
                    chkAdjuntaEvidencia.Enabled = false;
                    chkNoAdjuntaEvidencia.Enabled = false;
                    chkConflictoInteres.Enabled = false;
                    chkNoConflictoInteres.Enabled = false;
                    txtInteresEconomico.ReadOnly = true;
                    txtConflicto.ReadOnly = true;
                    txtEvidencia.ReadOnly = true;

                    ClientScript.RegisterStartupScript(GetType(), "hwa", "Ajustarcheck();", true);
                }


            }

            renderArchivos();
        }


        /// <summary>
        /// Este método se ejecuta cuando se hace clic en el botón de guardar.
        /// Realiza la validación de los campos antes de proceder con la acción de guardar.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            // Verifica si la validación es exitosa antes de realizar la acción de guardar.
            if (validar())
            {
                // Llama al método guardar() para ejecutar la acción de guardar.
                guardar();
            }
        }


        /// <summary>
        /// Este método realiza la validación de los campos antes de realizar una acción específica.
        /// </summary>
        /// <returns>
        /// Devuelve `true` si la validación es exitosa y no hay errores.
        /// Devuelve `false` si se encuentran errores durante la validación.
        /// </returns>
        private bool validar()
        {
            // Variable para rastrear si hay errores durante la validación.
            bool error = false;

            // Mensaje de validación que se mostrará en caso de errores.
            LblValidacionCampos.Text += "Verifique los Siguientes Campos: ";

            // Validación para el campo de observaciones generales de objeción.
            #region Observaciones Generales de Objeción
            txtObservacionesGenerales.CssClass = "";
            txtObservacionesGenerales.Attributes.Remove("placeholder");

            // Verifica si el campo de observaciones generales de objeción está vacío.
            if (string.IsNullOrWhiteSpace(txtObservacionesGenerales.Text))
            {
                error = true;
                LblValidacionCampos.Text += "Observaciones generales objeción, ";
                txtObservacionesGenerales.Attributes.Add("placeholder", "Debe ingresar Observaciones generales objeción ");
                txtObservacionesGenerales.CssClass = "form-control errormin";
            }
            else
            {
                // Restablece el estilo del campo si no hay error.
                txtObservacionesGenerales.CssClass = "form-control";
            }
            #endregion

            // Devuelve el resultado de la validación.
            return !error;
        }

        /// <summary>
        /// Este método se utiliza para enviar notificaciones y confirmar la recepción de una nominación o actualización de nominación.
        /// </summary>
        private void enviar()
        {
            clsNegocio cls = new clsNegocio();

            try
            {
                int id = int.Parse(lblCodNominacionProceso.Text);
            }
            catch
            {
                if (Request.QueryString["v"] == null || Session["SS_COD_REGISTRO"] == null)
                {
                    Response.Redirect("~/aspx/seguridad/frmLogin.aspx?page=aspx@@evento@@frmconfirmacionevento.aspx");
                    return;
                }
            }

            var obj = cls.obtenerNOMINACION_HUERFANA(int.Parse(lblCodNominacionProceso.Text));
            var proceso = cls.obtenerProceso(obj.COD_PROCESO);
            if (obj.COD_ESTADO_NOMINACION == 1)
            {
                string textoNuevo = "Queremos informarle que su nominación ha sido recibida";
                if (lblCodNominacionProceso.Text != string.Empty)
                {
                    textoNuevo = "Queremos informarle que los cambios de su nominación han sido recibidos";
                }
                cls.enviarNominacionExlcusiones(int.Parse(lblCodNominacionProceso.Text), 2);
                Session["msgtitulo"] = "Gracias por completar su nominación";
                Session["msgmsg"] = @"Muchas gracias por su participación en el  " + proceso.NOMBRE_PROCESO + @". " + textoNuevo + @"
                                    <br>
                                    <br>
                                    Le comunicaremos oportunamente cualquier tipo de novedad con respecto a su nominación.
                                    <br>
                                    <br>
                                    ";

                
                string asunto = Session["msgtitulo"].ToString();
                string cuerpo = Session["msgmsg"].ToString();
               

            }
            else
            {
                cls.enviarNominacionHuerfana(int.Parse(lblCodNominacionProceso.Text), 2);
                Session["msgtitulo"] = "Gracias por actualizadar su nominación ";
                Session["msgmsg"] = @"Muchas gracias por su participación en el  " + proceso.NOMBRE_PROCESO + @". Queremos informarle que los cambios de su nominación han sido recibidos.
                                        <br>
                                        <br>
                                        Le comunicaremos oportunamente cualquier tipo de novedad con respecto a su nominación.
                                        <br>
                                        <br>";
 
                string asunto = Session["msgtitulo"].ToString();
                string cuerpo = Session["msgmsg"].ToString();
                
            }

            Response.Redirect("~/frm/logica/frmMensajeIframe.aspx");
        }
        /// <summary>
        /// Este método se utiliza para realizar la acción de guardar una objeción de enfermedad huérfana.
        /// </summary>
        private void guardar()
        {

            if (Session["SS_COD_REGISTRO"] == null)
            {
                Response.Redirect("~/aspx/seguridad/frmLogin.aspx");
                return;
            }

            int vigencia = 0;
            if (Request.QueryString["codN"] == null)
            {
                if (Request.QueryString["v"] == null || Session["SS_COD_REGISTRO"] == null)
                {
                    Response.Redirect("~/aspx/seguridad/frmLogin.aspx?page=aspx@@evento@@frmconfirmacionevento.aspx");
                    return;
                }
                else
                {
                    vigencia = int.Parse(Request.QueryString["v"]);
                }
            }


            clsNegocio cls = new clsNegocio();
            int? codN = null;
            if (lblCodNominacionProceso.Text.Trim() != string.Empty)
            {
                codN = int.Parse(lblCodNominacionProceso.Text);
            }

            // Guardado objecion de nominacion Enfermedad Huérfana
            OBJECION_HUERFANA objecion = new OBJECION_HUERFANA();
            objecion.COD_NOMINACION_HUERFANA = codN.Value;
            objecion.COD_REGISTRO = int.Parse(Session["SS_COD_REGISTRO"].ToString());
            objecion.OBSERVACIONES_OBJECION = txtObservacionesGenerales.Text;
            objecion.FECHA_OBJECION = DateTime.Now;

            int i = cls.GuardarObjecionHuerfanas(objecion);
            
            var obj = cls.obtenerNOMINACION_PROCESO(int.Parse(lblCodNominacionProceso.Text));
           
            //Guardamos los archivos de la objecion
            for (int k = 0; k < ArchivosCargados.Count; k++)
            {
                ARCHIVOXOBJECION_HUERFANA ar = new ARCHIVOXOBJECION_HUERFANA();
                ar.DESCRIPCION_ARCHIVO = ArchivosCargados[k].descripcion;
                ar.URL_ARCHIVO = ArchivosCargados[k].url;
                ar.COD_OBJECION_PROCESO = i;
                int y = cls.GuardarArchivoObjecionHuerfanas(ar);
            }

            Session["msgtitulo"] = "Gracias por completar su objeción";
            Session["msgmsg"] = @"Muchas gracias por su participación en el proceso de nominaciones en el listado oficial de las enfermedades huérfanas del país . Queremos informarle que su objeción ha sido recibida.
                                <br>
                                <br>
                                Le comunicaremos oportunamente cualquier tipo de novedad con respecto a su objeción.
                                <br>
                                <br>
                                    ";

            clsWebUtils email = new clsWebUtils();
            string asunto = Session["msgtitulo"].ToString();

            string cuerpo = Session["msgmsg"].ToString();
            email.enviarEmailHuerfanas(asunto, cuerpo, Session["SS_CORREO"].ToString());


            Response.Redirect("~/frm/logica/frmMensaje.aspx");

        }

        /// <summary>
        /// Este método se ejecuta cuando se hace clic en el botón para adjuntar un nuevo archivo.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Los argumentos del evento.</param>
        protected void btnArchivo_Click(object sender, EventArgs e)
        {
            // Limpia la variable de sesión que contiene la información del archivo adjunto.
            Session["archivoPuente"] = null;

            // Muestra el formulario emergente para adjuntar un nuevo archivo.
            popupNuevo.Show();

            // Restablece los campos de descripción y mensajes de error en el formulario emergente.
            txtDescripcionArchivo.Text = "";
            lblErrorDetalle.Text = "";
        }


        /// <summary>
        /// Este método se ejecuta cuando se hace clic en el botón para cancelar y cerrar el formulario emergente de detalles.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Los argumentos del evento.</param>
        protected void btnCancelarDetalle_Click(object sender, EventArgs e)
        {
            // Oculta el formulario emergente de detalles.
            popupNuevo.Hide();
        }

        /// <summary>
        /// Este método se ejecuta cuando se hace clic en el botón para aceptar y agregar un archivo en el formulario.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Los argumentos del evento.</param>
        protected void btnAceptarDetalle_Click(object sender, EventArgs e)
        {
            // Verifica si el campo de descripción del archivo está vacío.
            if (txtDescripcionArchivo.Text == string.Empty)
            {
                lblErrorDetalle.Text = "Debe ingresar la descripción del archivo";
                return;
            }

            // Verifica si no se ha adjuntado ningún archivo.
            if (Session["archivoPuente"] == null || Session["archivoPuente"].ToString() == string.Empty)
            {
                lblErrorDetalle.Text = "Debe adjuntar el archivo";
                return;
            }

            // Crea un nuevo objeto 'archivos' con la descripción y la URL del archivo adjunto.
            archivos ar = new archivos();
            ar.descripcion = txtDescripcionArchivo.Text;
            ar.url = Session["archivoPuente"].ToString();

            // Agrega el nuevo objeto 'archivos' a la lista 'ArchivosCargados'.
            ArchivosCargados.Add(ar);

            // Oculta el formulario emergente después de agregar el archivo.
            popupNuevo.Hide();

            // Actualiza la presentación de la lista de archivos cargados.
            renderArchivos();
        }

        /// <summary>
        /// Actualiza la presentación de la lista de archivos cargados en el control GridView y actualiza el panel correspondiente.
        /// </summary>
        private void renderArchivos()
        {
            // Establece la fuente de datos del control GridView con la lista de archivos cargados.
            grdArchivos2.DataSource = ArchivosCargados;

            // Enlaza los datos y actualiza la presentación del control GridView.
            grdArchivos2.DataBind();

            // Actualiza el panel que contiene el control GridView para reflejar los cambios.
            pnlGrillaArchivos2.Update();
        }


        /// <summary>
        /// Maneja el evento de clic en el botón para eliminar un archivo cargado.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento (debe ser un ImageButton).</param>
        /// <param name="e">Los argumentos del evento (debe ser de tipo ImageClickEventArgs).</param>
        protected void btnelimnarARchivo_Click(object sender, ImageClickEventArgs e)
        {
            // Obtener el botón que desencadenó el evento (debe ser un ImageButton).
            ImageButton botonEliminar = (ImageButton)sender;

            // Recorrer la lista de archivos cargados.
            for (int i = 0; i < ArchivosCargados.Count; i++)
            {
                // Verificar si el URL del archivo actual coincide con el ValidationGroup del botón.
                if (ArchivosCargados[i].url == botonEliminar.ValidationGroup)
                {
                    // Eliminar el archivo de la lista.
                    ArchivosCargados.RemoveAt(i);

                    // Salir del bucle, ya que se ha eliminado el archivo.
                    break;
                }
            }

            // Renderizar la lista actualizada de archivos.
            renderArchivos();
        }


        /// <summary>
        /// Redirige al usuario a la página "frmObjetarHuerfanas.aspx" con los parámetros específicos para objetar una nominación.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Los argumentos del evento.</param>
        protected void btnObjetar_Click(object sender, EventArgs e)
        {
            // Construye la URL de redirección con los parámetros específicos para objetar una nominación.
            string redireccion = "frmObjetarHuerfanas.aspx?codN=" + Request.QueryString["codN"] + "&codProceso=" + Request.QueryString["codProceso"];

            // Redirige al usuario a la página especificada.
            Response.Redirect(redireccion);
        }


        /// <summary>
        /// Redirige al usuario a la página "frmObjetarHuerfanas.aspx" con los parámetros del proceso y una indicación de cancelación.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Los argumentos del evento.</param>
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            // Construye la URL de redirección con los parámetros del proceso y una indicación de cancelación.
            string redireccion = "~/frm/procesos/frmObjetarHuerfanas.aspx?cod=" + Request.QueryString["codProceso"] + "&v=" + Request.QueryString["v"] + "$r=1";

            // Redirige al usuario a la página especificada.
            Response.Redirect(redireccion);
        }

    }
}