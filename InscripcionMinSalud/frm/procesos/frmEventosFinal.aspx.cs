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

    public class archivoLista {
        public archivoLista() { }
        public string url { set; get; }

        public string COD_FORMATO_EVENTO { set; get; }
        public string URL_ARCHIVO { set; get; }
        public string nombre { set; get; }
    }
    public class delegadoLista
    {
        public int codRegistro{ set; get; }
        public string Nombres { set; get; }
        public string Apellidos { set; get; }
        public string Documento { set; get; }
        public string Estado { set; get; }

        public bool esNuevo { set; get; }

        public delegadoLista() { }
    }

    public partial class frmEventosFinal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString["token"] != null)
            {
                string token = Request.QueryString["token"];
                var c = token.ToCharArray();
                token = string.Empty;
                string registro = string.Empty;
                string correo = string.Empty;
                for (int k = 0; k < c.Length; k++)
                {
                    c[k] = (char)(c[k] - 4);
                    token = token + c[k];
                }

                if (token.IndexOf("₨") > 0)
                {
                    correo = token.Split('₨')[0];
                    registro = token.Split('₨')[1];
                    
                }

                if (token.IndexOf("|") > 0)
                {
                    correo = token.Split('|')[0];
                    registro = token.Split('|')[1];
                }

                clsNegocio obj = new clsNegocio();
                var usuario = obj.obtenerRegistroxCodigo(int.Parse(registro));

                if(correo.Equals(usuario.CORREO))
                {
                    Session["SS_COD_REGISTRO"] = usuario.COD_REGISTRO;
                    Session["SS_NOMBRE_USUARIO"] = usuario.NOMBRE_USUARIO;
                    if (usuario.ES_PERSONA_NATURAL)
                        Session["SS_NOMBRE"] = usuario.NOMBRE.Trim() + " " + usuario.APELLIDOS;
                    else
                        Session["SS_NOMBRE"] = usuario.NOMBRE.Trim();
                    Session["SS_CORREO"] = usuario.CORREO;
                }
            }
            if (Request.QueryString["cod"] == null || (Session["SS_NOMBRE_USUARIO"] == null || Session["SS_NOMBRE_USUARIO"].ToString() == string.Empty))
            {
                Response.Redirect("~/default.aspx");
                return;
            }
            if (!IsPostBack)
            {
                Session["ss_lista_delegado_sesion"] = null;
                Session["ss_lista_archivo_sesion"] = null;
                //validamos que paneles deberia mostrar
                NegocioInscripcionMinSalud.data.clsNegocio obj = new NegocioInscripcionMinSalud.data.clsNegocio();
                var fer = obj.obtenerEvento(int.Parse(Request.QueryString["cod"]));

                lblCantidad.Text = fer.DELEGADOS.ToString();
                var reg = obj.obtenerRegistroxCodigo(int.Parse(Session["SS_COD_REGISTRO"].ToString()));
                var conf = obj.obtenerCONFIRMACION_EVENTO(int.Parse(Session["SS_COD_REGISTRO"].ToString()), int.Parse(Request.QueryString["cod"]));
                //si el registro es juridico y delegados es >0 muestra el panel de agregar delegados
                if (fer.DELEGADOS > 0 && reg.ES_PERSONA_JURIDICA)
                {
                    pnlDelegados.Visible = true;
                    List<delegadoLista> lista = (List<delegadoLista>)Session["ss_lista_delegado_sesion"];
                     if (lista == null)
                        {
                            lista = new List<delegadoLista>();
                        }
                    //cargamos los delegados que tenga cargados
                    foreach (var delegado in conf.CONFIRMACION_EVENTO1)
                    {
                        delegadoLista dl = new procesos.delegadoLista();
                        dl.Nombres =delegado.REGISTRO.NOMBRE;
                        dl.Apellidos = delegado.REGISTRO.APELLIDOS;
                        dl.Documento = delegado.REGISTRO.DOCUMENTO;
                        dl.codRegistro = delegado.REGISTRO.COD_REGISTRO;
                        dl.esNuevo = false;
                        dl.Estado = delegado.COMPLETO.Value?"Completo": "Pendiente confirmación";
                        lista.Add(dl);
                    }
                    grdDelegados.DataSource = lista;
                    grdDelegados.DataBind();
                    Session["ss_lista_delegado_sesion"] = lista;
                    validarNumeroDelegados();
                }
                else
                {
                    pnlDelegados.Visible = false;
                }
                //validamos si debe agregar archivos
                List<FORMATO_EVENTOXEVENTO> archivos = null;
                if (reg.ES_PERSONA_NATURAL)
                {
                    if (fer.FORMATO_EVENTOXEVENTO.Where(x => x.APLICA_NATURAL == true).Count() > 0)
                    {//muestra el panel
                        pnlArchivos.Visible = true;
                        archivos = fer.FORMATO_EVENTOXEVENTO.Where(x => x.APLICA_NATURAL == true).ToList();
                    }
                    else
                    {
                        pnlArchivos.Visible = true;
                    }
                }
                else
                {
                    if (fer.FORMATO_EVENTOXEVENTO.Where(x => x.APLICA_JURIDICO == true).Count() > 0)
                    {//muestra el panel
                        pnlArchivos.Visible = true;
                        archivos = fer.FORMATO_EVENTOXEVENTO.Where(x => x.APLICA_JURIDICO == true).ToList();
                    }
                    else
                    {
                        pnlArchivos.Visible = true;
                    }
                }
                List<archivoLista> listaAr = (List<archivoLista>)Session["ss_lista_archivo_sesion"];
                if (listaAr == null)
                {
                    listaAr = new List<archivoLista>();
                }

                for (int k = 0; archivos!= null && k < archivos.Count; k++)
                {
                    archivoLista al = new procesos.archivoLista();
                    al.nombre = archivos[k].FORMATO_EVENTO.NOMBRE_FORMATO_EVENTO;
                    al.url = "";
                    al.URL_ARCHIVO = archivos[k].FORMATO_EVENTO.URL_ARCHIVO;
                    al.COD_FORMATO_EVENTO = archivos[k].FORMATO_EVENTO.COD_FORMATO_EVENTO.ToString();

                    var tt = conf.FORMATOEVENTOXCONFIRMACION.Where(x => x.COD_FORMATO_EVENTO
                     == int.Parse(al.COD_FORMATO_EVENTO)).FirstOrDefault();
                    if(tt != null)
                    {
                        al.url = tt.URL_ARCHIVO;
                    }

                    listaAr.Add(al);
                }
                grdArchivos.DataSource = listaAr;
                grdArchivos.DataBind();
                Session["ss_lista_archivo_sesion"] = listaAr;

            }
        }

        /// <summary>
        /// Valida el número de delegados para determinar si se puede agregar más.
        /// </summary>
        private void validarNumeroDelegados()
        {
            // Creación de una instancia de la clase de negocios para acceder a la base de datos.
            NegocioInscripcionMinSalud.data.clsNegocio obj = new NegocioInscripcionMinSalud.data.clsNegocio();

            // Obtención de la información del evento.
            var fer = obj.obtenerEvento(int.Parse(Request.QueryString["cod"]));

            // Obtención y validación de la lista de delegados en sesión.
            List<delegadoLista> lista = (List<delegadoLista>)Session["ss_lista_delegado_sesion"];
            if (lista == null)
            {
                lista = new List<delegadoLista>();
            }

            // Verificación del límite de delegados para mostrar u ocultar el panel de agregar delegados.
            if (fer.DELEGADOS <= lista.Count)
            {
                pnlAgregarDelegados.Visible = false;
                lblDelegadosFull.Visible = true;
            }
            else
            {
                pnlAgregarDelegados.Visible = true;
                lblDelegadosFull.Visible = false;
            }
        }


        /// <summary>
        /// Maneja el evento Click del botón "btnAgregarDelegado".
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los argumentos del evento.</param>
        protected void btnAgregarDelegado_Click(object sender, EventArgs e)
        {
            lblErrorDelegado.Text = "";

            // Creación de una instancia de la clase de negocios para acceder a la base de datos.
            NegocioInscripcionMinSalud.data.clsNegocio cls = new NegocioInscripcionMinSalud.data.clsNegocio();

            // Obtención del registro asociado al documento ingresado.
            var r = cls.obtenerRegistroxdocumentoNatural(txtDocumentoDelegado.Text);

            // Verificación de si se encontró un registro asociado al documento.
            if (r == null)
            {
                lblErrorDelegado.Text = "No se encontró el documento en la base de datos de inscritos de Mi Vox-Populi.";
                return;
            }

            // Creación de un objeto delegadoLista con la información del registro.
            delegadoLista dl = new procesos.delegadoLista();
            dl.Nombres = r.NOMBRE;
            dl.Apellidos = r.APELLIDOS;
            dl.Documento = r.DOCUMENTO;
            dl.codRegistro = r.COD_REGISTRO;
            dl.esNuevo = true;
            dl.Estado = "Pendiente aceptación";

            // Obtención y validación de la lista de delegados en sesión.
            List<delegadoLista> lista = (List<delegadoLista>)Session["ss_lista_delegado_sesion"];
            if (lista == null)
            {
                lista = new List<delegadoLista>();
            }

            // Verificación de si el delegado ya fue ingresado previamente.
            for (int k = 0; k < lista.Count; k++)
            {
                if (lista[k].codRegistro == dl.codRegistro)
                {
                    lblErrorDelegado.Text = "Delegado ingresado previamente.";
                    return;
                }
            }

            // Agregación del nuevo delegado a la lista y actualización del control de interfaz y enlace de datos.
            lista.Add(dl);
            grdDelegados.DataSource = lista;
            grdDelegados.DataBind();

            // Almacenamiento de la lista actualizada en la sesión.
            Session["ss_lista_delegado_sesion"] = lista;

            // Validación del número de delegados.
            validarNumeroDelegados();
        }


        /// <summary>
        /// Maneja el evento Click del botón "btnEliminar".
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los argumentos del evento.</param>
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            int codr = int.Parse(b.CommandArgument);

            // Obtención de la lista de delegados de la sesión.
            List<delegadoLista> lista = (List<delegadoLista>)Session["ss_lista_delegado_sesion"];
            if (lista == null)
            {
                lista = new List<delegadoLista>();
            }

            // Iteración sobre la lista de delegados para eliminar el delegado correspondiente al código proporcionado.
            for (int k = 0; k < lista.Count; k++)
            {
                if (lista[k].codRegistro == codr)
                {
                    lista.RemoveAt(k);
                    break;
                }
            }

            // Actualización de la fuente de datos del control de la interfaz y enlace de datos.
            grdDelegados.DataSource = lista;
            grdDelegados.DataBind();

            // Almacenamiento de la lista actualizada en la sesión.
            Session["ss_lista_delegado_sesion"] = lista;

            // Validación del número de delegados.
            validarNumeroDelegados();
        }


        /// <summary>
        /// Maneja el evento Click del botón "btnGuardar".
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los argumentos del evento.</param>
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            bool pendientes = false;

            // Creación de una instancia de la clase de negocios para interactuar con la base de datos.
            NegocioInscripcionMinSalud.data.clsNegocio obj = new NegocioInscripcionMinSalud.data.clsNegocio();

            // Obtención de la información del evento correspondiente al código proporcionado en la consulta.
            var fer = obj.obtenerEvento(int.Parse(Request.QueryString["cod"]));

            // Obtención del código de registro de la sesión.
            int codr = int.Parse(Session["SS_COD_REGISTRO"].ToString());

            // Obtención de la información del registro correspondiente al código de registro de la sesión.
            var registro = obj.obtenerRegistroxCodigo(codr);

            // Obtención de la lista de delegados de la sesión.
            List<delegadoLista> lista = (List<delegadoLista>)Session["ss_lista_delegado_sesion"];
            if (lista == null)
            {
                lista = new List<delegadoLista>();
            }

            // Iteración sobre la lista de delegados para realizar acciones correspondientes.
            for (int k = 0; k < lista.Count; k++)
            {
                if (lista[k].esNuevo)
                {
                    pendientes = true;

                    // Agregamos el delegado y le enviamos el correo.
                    obj.agregarDelegadoConfirmacion(int.Parse(Session["SS_COD_REGISTRO"].ToString()),
                       fer.COD_EVENTO, lista[k].codRegistro);

                    // Enviamos el correo
                    System.Configuration.AppSettingsReader ar = new System.Configuration.AppSettingsReader();
                    string url = ar.GetValue("urllocal", typeof(string)).ToString();
                    clsWebUtils email = new clsWebUtils();
                    string asunto = "Ha sido seleccionado como delegado por " + Session["SS_NOMBRE_USUARIO"].ToString();
                    var reh = obj.obtenerRegistroxCodigo(lista[k].codRegistro);
                    string cuerpo = "Ha sido seleccionado como delegado por " + Session["SS_NOMBRE_USUARIO"].ToString() +
                        " para el evento " + fer.NOMBRE_EVENTO + " por favor ingrese a la plataforma y confirme su asistencia, en el siguiente " +
                        "<a href='" + url + "/frm/procesos/frmEventosTematica.aspx?cod=" + fer.COD_PROCESO + "' >link</a>";
                    email.enviarEmail(asunto, cuerpo, reh.CORREO);
                }
            }

            // Obtención de la lista de archivos de la sesión.
            List<archivoLista> listaAr = (List<archivoLista>)Session["ss_lista_archivo_sesion"];
            List<FORMATOEVENTOXCONFIRMACION> listaF = new List<FORMATOEVENTOXCONFIRMACION>();

            // Iteración sobre la lista de archivos para realizar acciones correspondientes.
            if (formatoDiligenciado.Checked)
            {
                pendientes = false;
            }
            else
            {
                pendientes = true;
            }

            // Actualizamos los archivos de confirmación.
            // obj.actualizarArchivosConfirmacion(codr, fer.COD_EVENTO, listaF);

            // Comprobamos si no hay pendientes y completamos la confirmación.
            if (!pendientes)
            {
                if (registro.ES_PERSONA_NATURAL)
                {
                    obj.completarConfirmacion(codr, fer.COD_EVENTO);

                    // Enviamos correos y mostramos mensaje.
                    clsWebUtils email = new clsWebUtils();
                    string asunto = "Gracias por confirmar su participación al evento";
                    string cuerpo = @"Muchas gracias por confirmar su participación al evento " + fer.NOMBRE_EVENTO +
                    " programado para el día " + fer.FECHA.Value.ToLongDateString() + " " + fer.FECHA.Value.ToLongTimeString() +
                    "<br> recuerde que puede cancelar su participación a este evento hasta 24 horas antes de inicio del mismo,";
                    email.enviarEmail(asunto, cuerpo, Session["SS_CORREO"].ToString());

                    var confirmacion = obj.obtenerCONFIRMACION_EVENTO(codr, fer.COD_EVENTO);

                    // Actualiza el estado de la jurídica en caso de que sea un delegado.
                    if (confirmacion.COD_CONFIRMACION_EVENTO_PADRE.HasValue)
                    {
                        // Realizar acciones correspondientes si es un delegado.
                    }
                }
                else
                {
                    // Si es jurídica y no hay delegados.
                    if (fer.DELEGADOS == 0)
                    {
                        obj.completarConfirmacion(codr, fer.COD_EVENTO);

                        // Enviamos correos y mostramos mensaje.
                        clsWebUtils email = new clsWebUtils();
                        string asunto = "Gracias por confirmar su participación al evento";
                        string cuerpo = @"Muchas gracias por confirmar su participación al evento " + fer.NOMBRE_EVENTO +
                        " programado para el día " + fer.FECHA.Value.ToLongDateString() + " " + fer.FECHA.Value.ToLongTimeString() +
                        "<br> recuerde que puede cancelar su participación a este evento hasta 24 horas antes de inicio del mismo,";
                        email.enviarEmail(asunto, cuerpo, Session["SS_CORREO"].ToString());
                    }
                }
            }

            // Redirección a la página "frmEventosTematica.aspx" con el código de temática del evento.
            Response.Redirect("frmEventosTematica.aspx?cod=" + fer.COD_TEMATICA_EVENTO);
        }


        /// <summary>
        /// Maneja el evento Click del botón "btnVolver".
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los argumentos del evento.</param>
        protected void btnVolver_Click(object sender, EventArgs e)
        {
            // Creación de una instancia de la clase de negocios para interactuar con la base de datos.
            NegocioInscripcionMinSalud.data.clsNegocio obj = new NegocioInscripcionMinSalud.data.clsNegocio();

            // Obtención de la información del evento correspondiente al código proporcionado en la consulta.
            var fer = obj.obtenerEvento(int.Parse(Request.QueryString["cod"]));

            // Redirección a la página "frmEventosTematica.aspx" con el código de temática del evento.
            Response.Redirect("frmEventosTematica.aspx?cod=" + fer.COD_TEMATICA_EVENTO);
        }


        /// <summary>
        /// Maneja el evento Click del botón "btnCancelarAsistencia".
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los argumentos del evento.</param>
        protected void btnCancelarAsistencia_Click(object sender, EventArgs e)
        {
            // Creación de una instancia de la clase de negocios para interactuar con la base de datos.
            NegocioInscripcionMinSalud.data.clsNegocio obj = new NegocioInscripcionMinSalud.data.clsNegocio();

            // Obtención de la información del evento correspondiente al código proporcionado en la consulta.
            var c = obj.obtenerEvento(int.Parse(Request.QueryString["cod"]));

            // Cancelación de la confirmación de asistencia del usuario actual al evento.
            obj.cancelarConfirmacion(int.Parse(Session["SS_COD_REGISTRO"].ToString()), c.COD_EVENTO);

            // Configuración de mensajes para mostrar al usuario.
            Session["msgtitulo"] = "Se canceló su participación al evento.";
            Session["msgmsg"] = @"Se canceló su participación al evento  " + c.NOMBRE_EVENTO + ".";

            // Envío de correo electrónico para notificar al usuario sobre la cancelación.
            clsWebUtils email = new clsWebUtils();
            string asunto = Session["msgtitulo"].ToString();
            string cuerpo = Session["msgmsg"].ToString();
            email.enviarEmail(asunto, cuerpo, Session["SS_CORREO"].ToString());

            // Verificación y notificación adicional si el usuario es un delegado (pendiente).

            // Redirección a la página de mensajes.
            Response.Redirect("~/frm/logica/frmMensaje.aspx");
        }


        /// <summary>
        /// Maneja el evento Click del botón "btnArchivo".
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los argumentos del evento.</param>
        protected void btnArchivo_Click(object sender, EventArgs e)
        {
            // Configuración de la aplicación para obtener la URL local.
            System.Configuration.AppSettingsReader ar = new System.Configuration.AppSettingsReader();
            string urlLocal = ar.GetValue("urllocal", typeof(string)).ToString();

            // Inicialización de mensajes de error y obtención del botón que generó el evento.
            lblErrorArchivo.Text = "";
            Button b = (Button)sender;

            Label lb;
            int codFormato = int.Parse(b.CommandArgument);

            // Buscamos el control Label y FileUpload en la fila correspondiente al botón clickeado.
            for (int k = 0; k < grdArchivos.Rows.Count; k++)
            {
                lb = (Label)grdArchivos.Rows[k].Cells[1].FindControl("formatoDiligenciado");
                FileUpload fp = (FileUpload)grdArchivos.Rows[k].Cells[1].FindControl("fileCargar");
                Button c = (Button)grdArchivos.Rows[k].Cells[1].FindControl("btnArchivo");

                // Si el botón actual coincide con el botón clickeado, realizamos las operaciones.
                if (c.CommandArgument == b.CommandArgument)
                {
                    // Se agrega el archivo si existe.
                    if (fp.HasFile)
                    {
                        string ruta = Server.MapPath("~/files/");
                        string archivo = System.IO.Path.GetFileNameWithoutExtension(System.IO.Path.GetTempFileName()).Substring(0, 4) + fp.FileName;
                        fp.SaveAs(ruta + archivo);

                        // Se actualiza la URL del archivo en la lista de archivos.
                        List<archivoLista> listaAr = (List<archivoLista>)Session["ss_lista_archivo_sesion"];
                        if (listaAr == null)
                        {
                            listaAr = new List<archivoLista>();
                        }

                        for (int j = 0; j < listaAr.Count; j++)
                        {
                            if (listaAr[j].COD_FORMATO_EVENTO == b.CommandArgument)
                            {
                                listaAr[j].url = urlLocal + "/files/" + archivo;
                                break;
                            }
                        }

                        // Se actualiza la fuente de datos y la sesión.
                        grdArchivos.DataSource = listaAr;
                        Session["ss_lista_archivo_sesion"] = listaAr;
                    }
                    else
                    {
                        // Si no se selecciona un archivo, se actualiza el Label y se muestra un mensaje de error.
                        lb.Text = "SI";
                        lb.ForeColor = System.Drawing.Color.Green;
                        //lblErrorArchivo.Text = "Seleccione un archivo";
                        return;
                    }

                    // Se actualiza la grilla.
                    grdArchivos.DataBind();
                }
            }
        }

    }
}