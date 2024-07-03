using NegocioInscripcionMinSalud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InscripcionMinSalud.frm.procesos
{
    public partial class frmEventosTematica : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["cod"] == null )
            {
                Response.Redirect("~/default.aspx");
                return;
            }

            if (!IsPostBack)
            {
               NegocioInscripcionMinSalud.data.clsNegocio obj = new NegocioInscripcionMinSalud.data.clsNegocio();
               var c = obj.obtenerTematica(int.Parse(Request.QueryString["cod"]));
               lblNombreProceso.Text = c.EVENTO.FirstOrDefault().PROCESO.NOMBRE_PROCESO;
               lblTitulo.Text = c.NOMBRE_TEMATICA;
            }
        }

        /// <summary>
        /// Obtiene el tipo de restricción para la inscripción de personas jurídicas en un evento.
        /// </summary>
        /// <param name="CodEvento">El código del evento.</param>
        /// <returns>El tipo de restricción o un mensaje indicando que no hay restricciones.</returns>
        public string verTipo(object CodEvento)
        {
            // Verificar si el código del evento es nulo o DBNull.Value
            if (CodEvento == null || CodEvento == System.DBNull.Value)
            {
                // En caso de nulo, retornar una cadena vacía
                return "";
            }

            // Convertir el código del evento a entero
            int codEvento = int.Parse(CodEvento.ToString());

            // Obtener una instancia de la capa de negocios
            NegocioInscripcionMinSalud.data.clsNegocio obj = new NegocioInscripcionMinSalud.data.clsNegocio();

            // Obtener el evento correspondiente al código de evento
            var c = obj.obtenerEvento(codEvento);

            // Obtener la lista de perfiles
            var l = obj.obtenerPerfil();

            // Verificar si hay restricciones para la inscripción de personas jurídicas
            if (l.Count == c.TIPO_JURIDICOXEVENTO.Count)
            {
                return "Sin restricción para persona jurídica";
            }
            else
            {
                string res = "";

                // Iterar sobre los tipos de jurídicos permitidos en el evento y construir la cadena de restricciones
                foreach (var i in c.TIPO_JURIDICOXEVENTO)
                {
                    if (i.TIPO_JURIDICO.NOMBRE_TIPO_JURIDICO.ToLower().Contains("otro ")) continue;
                    res += i.TIPO_JURIDICO.NOMBRE_TIPO_JURIDICO + ",";
                }

                // Retornar la cadena de restricciones
                return res;
            }
        }


        /// <summary>
        /// Obtiene el estado de confirmación de un usuario para un evento específico.
        /// </summary>
        /// <param name="CodEvento">El código del evento.</param>
        /// <returns>El estado de confirmación.</returns>
        public string verEstado(object CodEvento)
        {
            // Verificar si el código del evento es nulo o DBNull.Value
            if (CodEvento == null || CodEvento == System.DBNull.Value)
            {
                // En caso de nulo, retornar una cadena vacía
                return "";
            }

            // Verificar si el código de registro en sesión es nulo o cadena vacía
            if (Session["SS_COD_REGISTRO"] == null || Session["SS_COD_REGISTRO"].ToString() == string.Empty)
            {
                // En caso de nulo o cadena vacía, retornar una cadena vacía
                return "";
            }

            // Convertir el código del evento y de registro en sesión a enteros
            int codEvento = int.Parse(CodEvento.ToString());
            int codRegistro = int.Parse(Session["SS_COD_REGISTRO"].ToString());

            // Obtener una instancia de la capa de negocios
            NegocioInscripcionMinSalud.data.clsNegocio obj = new NegocioInscripcionMinSalud.data.clsNegocio();

            // Obtener la confirmación de evento correspondiente al código de registro y código de evento
            var c = obj.obtenerCONFIRMACION_EVENTO(codRegistro, codEvento);

            // Verificar el estado de confirmación y retornar el resultado correspondiente
            if (c != null && c.CANCELADO.HasValue && c.CANCELADO.Value)
            {
                return "Canceló confirmación";
            }
            else if (c != null && c.COMPLETO.HasValue && c.COMPLETO.Value)
            {
                return "Confirmado";
            }
            else
            {
                if (c != null)
                    return "Pendiente diligenciar confirmación";
                else
                    return "Sin Confirmar";
            }
        }


        /// <summary>
        /// Obtiene la cantidad de cupos libres para un evento específico.
        /// </summary>
        /// <param name="CodEvento">El código del evento.</param>
        /// <returns>La cantidad de cupos libres.</returns>
        public int verCuposLibres(object CodEvento)
        {
            // Verificar si el código del evento es nulo o DBNull.Value
            if (CodEvento == null || CodEvento == System.DBNull.Value)
            {
                // En caso de nulo, retornar 0 (cero)
                return 0;
            }

            // Convertir el código del evento a entero
            int codEvento = int.Parse(CodEvento.ToString());

            // Obtener una instancia de la capa de negocios
            NegocioInscripcionMinSalud.data.clsNegocio obj = new NegocioInscripcionMinSalud.data.clsNegocio();

            // Obtener el evento correspondiente al código
            var c = obj.obtenerEvento(codEvento);

            // Calcular la cantidad de cupos libres
            int cuposLibres = c.CAPACIDAD_MAXIMA.Value - (c.CONFIRMACION_EVENTO.Where(x => x.FECHA_CANCELACION.HasValue == false && x.COMPLETO.Value == true)).Count();

            // Retornar la cantidad de cupos libres
            return cuposLibres;
        }


        /// <summary>
        /// Determina si el control para confirmar la asistencia a un evento debe ser visible.
        /// </summary>
        /// <param name="codEvento">El código del evento.</param>
        /// <returns>True si el control debe ser visible; de lo contrario, false.</returns>
        public bool verVisibleConfirmar(object codEvento)
        {
            // Verificar si el usuario no ha iniciado sesión
            if (Session["SS_NOMBRE_USUARIO"] == null || Session["SS_NOMBRE_USUARIO"].ToString() == string.Empty)
            {
                // Si no ha iniciado sesión, el control debe ser visible
                return true;
            }

            // Obtener una instancia de la capa de negocios
            NegocioInscripcionMinSalud.data.clsNegocio obj = new NegocioInscripcionMinSalud.data.clsNegocio();

            // Obtener la confirmación del evento para el usuario actual
            var evento = obj.obtenerCONFIRMACION_EVENTO(int.Parse(Session["SS_COD_REGISTRO"].ToString()), int.Parse(codEvento.ToString()));

            // Verificar si el evento no existe o ya fue cancelado
            if (evento == null || evento.FECHA_CANCELACION.HasValue)
            {
                // El control debe ser visible
                return true;
            }
            else
            {
                // El control no debe ser visible
                return false;
            }
        }

        /// <summary>
        /// Determina si el control para cancelar un evento debe ser visible.
        /// </summary>
        /// <param name="codEvento">El código del evento.</param>
        /// <returns>True si el control debe ser visible; de lo contrario, false.</returns>
        public bool verVisibleCancelar(object codEvento)
        {
            // Verificar si el usuario ha iniciado sesión
            if (Session["SS_NOMBRE_USUARIO"] == null || Session["SS_NOMBRE_USUARIO"].ToString() == string.Empty)
            {
                // Si no ha iniciado sesión, el control no debe ser visible
                return false;
            }

            // Obtener una instancia de la capa de negocios
            NegocioInscripcionMinSalud.data.clsNegocio obj = new NegocioInscripcionMinSalud.data.clsNegocio();

            // Obtener la confirmación del evento para el usuario actual
            var evento = obj.obtenerCONFIRMACION_EVENTO(int.Parse(Session["SS_COD_REGISTRO"].ToString()), int.Parse(codEvento.ToString()));

            // Verificar si el evento no existe o ya fue cancelado
            if (evento == null || evento.FECHA_CANCELACION.HasValue)
            {
                // El control no debe ser visible
                return false;
            }
            else
            {
                // El control debe ser visible
                return true;
            }
        }


        /// <summary>
        /// Determina si el control para completar un evento debe ser visible.
        /// </summary>
        /// <param name="codEvento">El código del evento.</param>
        /// <returns>True si el control debe ser visible; de lo contrario, false.</returns>
        public bool verVisibleCompletar(object codEvento)
        {
            // Verificar si el usuario ha iniciado sesión
            if (Session["SS_NOMBRE_USUARIO"] == null || Session["SS_NOMBRE_USUARIO"].ToString() == string.Empty)
            {
                // Si no ha iniciado sesión, el control no debe ser visible
                return false;
            }

            // Obtener una instancia de la capa de negocios
            NegocioInscripcionMinSalud.data.clsNegocio obj = new NegocioInscripcionMinSalud.data.clsNegocio();

            // Obtener la confirmación del evento para el usuario actual
            var evento = obj.obtenerCONFIRMACION_EVENTO(int.Parse(Session["SS_COD_REGISTRO"].ToString()), int.Parse(codEvento.ToString()));

            // Verificar si el evento no existe, si ya se completó o si fue cancelado
            if (evento == null || evento.FECHA_COMPLETO.HasValue || evento.FECHA_CANCELACION.HasValue)
            {
                // El control no debe ser visible
                return false;
            }
            else
            {
                // El control debe ser visible
                return true;
            }
        }

        /// <summary>
        /// Maneja el evento Click del botón btnconfirmarEvento.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        protected void btnconfirmarEvento_Click(object sender, EventArgs e)
        {
            if (Session["SS_NOMBRE_USUARIO"] == null || Session["SS_NOMBRE_USUARIO"].ToString() == string.Empty)
            {
                popupIngresar.Show();
                return;
            }
            Button B = (Button)sender;
            NegocioInscripcionMinSalud.data.clsNegocio obj = new NegocioInscripcionMinSalud.data.clsNegocio();
            int codRegistro = int.Parse(Session["SS_COD_REGISTRO"].ToString());
            var reg = obj.obtenerRegistroxCodigo(codRegistro);

            bool tramiteadicional = false;
            var c = obj.obtenerEvento(int.Parse(B.CommandArgument));
            lblMensaje.Text = "";
            #region validacion
            //1 validamos si tiene restriccion de perfiles, si es asi de una no lo deja inscribir
            if (DateTime.Now > c.FECHA)
            {
                lblMensaje.Text = "No se puede confirmar un evento que ya inició.";
                popupMensaje.Show();
                return;
            }

            //if (reg.ES_PERSONA_NATURAL && c.PERMITE_PERSONAS_NATURALES == false)
            //{
            //    lblMensaje.Text = "Este evento no está dirigido a personas naturales.";
            //    popupMensaje.Show();
            //    return;
            //}
            //validamos si no deja repetir asistencia
            if (c.PERMITE_REPETIR_ASISTENCIA == false)
            {
                if (obj.obtenerCONFIRMACION_EVENTOValidar(c.COD_TEMATICA_EVENTO.Value, codRegistro) != null) {
                    lblMensaje.Text = "Ya se encuentra inscrito en otro evento. Usted puede participar en un solo evento a la vez.";
                    popupMensaje.Show();
                    return;
                }
            }
            //validamos si el perfil del juridico esta en el grupo de los perfiles agregados
            if (reg.ES_PERSONA_JURIDICA == true)
            {
                if (c.TIPO_JURIDICOXEVENTO.Where(x => x.COD_TIPO_JURIDICO == reg.COD_TIPO_JURIDICO).Count() <= 0)
                {
                    lblMensaje.Text = "El evento no permite la inscripción para personas jurídicas por este medio.";
                    popupMensaje.Show();
                    return;
                }
            }else {
                //validamos si fue asignado como delegado de lo contrario no lo de ja inscribir
                if (c.PERMITE_PERSONAS_NATURALES.HasValue && c.PERMITE_PERSONAS_NATURALES.Value == false)
                {
                    bool esdelegado = false;
                    var d=obj.obtenerCONFIRMACION_EVENTO(reg.COD_REGISTRO, c.COD_EVENTO);
                    if (d != null)
                    {
                        esdelegado = true;
                    }
                    if (esdelegado == false)
                    {
                        lblMensaje.Text = "El evento no permite la inscripción para personas naturales por este medio.";
                        popupMensaje.Show();
                    }
                    return;
                }
            }
            #endregion

            //si tiene tecnologias debe seleccionarlas
            if (c.TECNOLOGIASXEVENTO.Count() > 0)
            {
                tramiteadicional = true;
              //  lblCodigoConfirmacion.Text = obj.vincularConfirmacion(int.Parse(Session["SS_COD_REGISTRO"].ToString()), c.COD_EVENTO, !tramiteadicional).ToString();
                lblCodigoEvento.Text = c.COD_EVENTO.ToString();
                popupTecnologias.Show();
                return;
            }else {
                // si es persona juridica debe agregar los delegados
                if (reg.ES_PERSONA_JURIDICA)
                {
                    if (c.DELEGADOS > 0   || c.FORMATO_EVENTOXEVENTO.Where(x => x.APLICA_JURIDICO == true).Count() > 0)
                    {
                        tramiteadicional = true;   
                    }
                    // Cambio para confirmar asistencia desde esta pantalla sin ir a los formularios de coflictos 

                    obj.vincularConfirmacion(int.Parse(Session["SS_COD_REGISTRO"].ToString()), c.COD_EVENTO, true).ToString();
                    //obj.vincularConfirmacion(int.Parse(Session["SS_COD_REGISTRO"].ToString()), c.COD_EVENTO, !tramiteadicional).ToString();
                    //mensajeFin(tramiteadicional, c.NOMBRE_EVENTO, c.FECHA.Value, c.COD_EVENTO);
                }
                else
                {
                    if (c.FORMATO_EVENTOXEVENTO.Where(x => x.APLICA_NATURAL == true).Count() > 0)
                    {
                        tramiteadicional = true;
                    }
                    // Cambio para confirmar asistencia desde esta pantalla sin ir a los formularios de coflictos 

                    obj.vincularConfirmacion(int.Parse(Session["SS_COD_REGISTRO"].ToString()), c.COD_EVENTO, true).ToString();
                    //obj.vincularConfirmacion(int.Parse(Session["SS_COD_REGISTRO"].ToString()), c.COD_EVENTO, !tramiteadicional).ToString();
                    mensajeFin(tramiteadicional, c.NOMBRE_EVENTO, c.FECHA.Value, c.COD_EVENTO);
                }
            }
        }

        /// <summary>
        /// Método privado que maneja la generación del mensaje final y realiza acciones específicas según la situación.
        /// </summary>
        /// <param name="tramiteadicional">Indica si hay trámites adicionales.</param>
        /// <param name="NOMBRE_EVENTO">El nombre del evento.</param>
        /// <param name="FECHA">La fecha del evento.</param>
        /// <param name="COD_EVENTO">El código único del evento.</param>
        private void mensajeFin(bool tramiteadicional, string NOMBRE_EVENTO, DateTime FECHA, int COD_EVENTO)
        {
            // Obtener la URL local desde la configuración de la aplicación
            System.Configuration.AppSettingsReader ar = new System.Configuration.AppSettingsReader();
            string url = ar.GetValue("urllocal", typeof(string)).ToString();

            // Inicializar cadenas de mensajes
            string strTramiteAdicional = "";
            string strMensajeCupos = "";

            // Acceder a la capa de datos para interactuar con la base de datos
            NegocioInscripcionMinSalud.data.clsNegocio obj = new NegocioInscripcionMinSalud.data.clsNegocio();

            // Obtener información sobre el evento
            var evento = obj.obtenerEvento(COD_EVENTO);

            // Construir un token para encriptar información de sesión
            if (tramiteadicional)
            {
                var c = $"{Session["SS_CORREO"]}|{Session["SS_COD_REGISTRO"]}".ToCharArray();
                string token = string.Empty;
                for (int k = 0; k < c.Length; k++)
                {
                    c[k] = (char)(c[k] + 4);
                    token = token + c[k];
                }

                strTramiteAdicional = $"<br>  <a class='buttoncta' href='{url}/frm/procesos/frmEventosFinal.aspx?codr={Session["SS_COD_REGISTRO"]}&cod={COD_EVENTO}&token={token}' > continuar </a>";
            }

            // Verificar la disponibilidad de cupos y generar mensaje correspondiente
            if (evento.CONFIRMACION_EVENTO.Where(x => x.FECHA_CANCELACION.HasValue == false && x.REGISTRO.ES_PERSONA_NATURAL == true).Count() > evento.CAPACIDAD_MAXIMA)
            {
                strMensajeCupos = " No hay más disponibilidad para este evento. Sin embargo, su inscripción estará en lista de espera y será notificado una vez se habiliten cupos.";
            }

            // Configurar mensajes según el evento
            Session["msgtitulo"] = "Gracias por participar";
            Session["msgmsg"] = $@"<p>Su participación es muy importante para el desarrollo de los procesos que adelanta la Dirección de Regulación de Beneficios, Costos y Tarifas del Aseguramiento en Salud</p></br>
                           <p>Su asistencia al evento de socialización en el enlace {evento.LUGAR} programado para el día {FECHA.ToLongDateString()} a las {FECHA.ToLongTimeString()} queda confirmada!</p>";

            // Enviar correo electrónico de notificación al usuario
            clsWebUtils email = new clsWebUtils();
            string asunto = Session["msgtitulo"].ToString();
            string cuerpo = Session["msgmsg"].ToString();
            email.enviarEmail(asunto, cuerpo, Session["SS_CORREO"].ToString());

            // Redirigir a la página de mensajes
            Response.Redirect("~/frm/logica/frmMensaje.aspx");
        }

        /// <summary>
        /// Maneja el evento Click del botón btnCancelar.
        /// Cuando se hace clic en el botón, se cancela la participación del usuario en el evento correspondiente.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento (botón).</param>
        /// <param name="e">Los datos del evento.</param>
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            // Obtener el botón que desencadenó el evento
            Button B = (Button)sender;

            // Acceder a la capa de datos para interactuar con la base de datos
            NegocioInscripcionMinSalud.data.clsNegocio obj = new NegocioInscripcionMinSalud.data.clsNegocio();

            // Obtener información sobre el evento
            var c = obj.obtenerEvento(int.Parse(B.CommandArgument));

            // Cancelar la confirmación de participación del usuario en el evento
            obj.cancelarConfirmacion(int.Parse(Session["SS_COD_REGISTRO"].ToString()), c.COD_EVENTO);

            // Configurar mensajes para el usuario
            Session["msgtitulo"] = "Se canceló su participación al evento.";
            Session["msgmsg"] = $"Se canceló su participación al evento {c.NOMBRE_EVENTO}.";

            // Enviar un correo electrónico de notificación al usuario
            clsWebUtils email = new clsWebUtils();
            string asunto = Session["msgtitulo"].ToString();
            string cuerpo = Session["msgmsg"].ToString();
            email.enviarEmail(asunto, cuerpo, Session["SS_CORREO"].ToString());

            // Redirigir a la página de mensajes
            Response.Redirect("~/frm/logica/frmMensaje.aspx");
        }


        /// <summary>
        /// Maneja el evento Click del botón btnCancelarRegstro.
        /// Cuando se hace clic en el botón, se oculta el popup de ingreso.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        protected void btnCancelarRegstro_Click1(object sender, EventArgs e)
        {
            // Ocultar el popup de ingreso
            popupIngresar.Hide();
        }


        /// <summary>
        /// Maneja el evento Click del botón btnCerrarMensaje.
        /// Cuando se hace clic en el botón, se oculta el popup de mensaje.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        protected void btnCerrarMensaje_Click(object sender, EventArgs e)
        {
            // Ocultar el popup de mensaje
            popupMensaje.Hide();
        }

        /// <summary>
        /// Maneja el evento Click del botón btnCancelarTecnologias.
        /// Cuando se hace clic en el botón, se oculta el popup de tecnologías.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        protected void btnCancelarTecnologias_Click(object sender, EventArgs e)
        {
            // Crear una instancia de la clase de negocios (NegocioInscripcionMinSalud.data.clsNegocio)
            NegocioInscripcionMinSalud.data.clsNegocio obj = new NegocioInscripcionMinSalud.data.clsNegocio();

            // Ocultar el popup de tecnologías
            popupTecnologias.Hide();
        }

        /// <summary>
        /// Maneja el evento Click del botón btnAceptarTecnologias.
        /// Cuando se hace clic en el botón, se obtienen las tecnologías seleccionadas del GridView grdTecnologias
        /// y se agregan a la inscripción. Se verifica si es necesario realizar un trámite adicional para personas jurídicas.
        /// Luego, se vincula la confirmación y se muestra un mensaje de finalización.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        protected void btnAceptarTecnologias_Click(object sender, EventArgs e)
        {
            // Inicializar el texto de error en el control lblErrorTEcnologias
            lblErrorTEcnologias.Text = "";

            // Lista para almacenar las tecnologías seleccionadas
            List<int> listaTecnologias = new List<int>();

            // Iterar a través de los elementos del GridView grdTecnologias
            for (int k = 0; k < grdTecnologias.Items.Count; k++)
            {
                // Obtener el control CheckBox "chkSeleccionar" de cada fila
                var chk = (CheckBox)grdTecnologias.Items[k].FindControl("chkSeleccionar");

                // Verificar si el CheckBox está marcado
                if (chk.Checked)
                {
                    // Obtener el valor del atributo "ValidationGroup" y convertirlo a entero, luego agregarlo a la lista
                    listaTecnologias.Add(int.Parse(chk.ValidationGroup));
                }
            }

            // Verificar si se seleccionó al menos una tecnología
            if (listaTecnologias.Count == 0)
            {
                lblErrorTEcnologias.Text = "Debe seleccionar por lo menos una tecnología";
                return;
            }

            // Crear una instancia de la clase de negocios (NegocioInscripcionMinSalud.data.clsNegocio)
            NegocioInscripcionMinSalud.data.clsNegocio obj = new NegocioInscripcionMinSalud.data.clsNegocio();

            // Bandera para indicar si se requiere un trámite adicional para personas jurídicas
            bool tramiteAdicional = false;

            // Obtener el evento correspondiente al código del evento en lblCodigoEvento
            var evento = obj.obtenerEvento(int.Parse(lblCodigoEvento.Text));

            // Obtener el registro correspondiente al código de registro en Session["SS_COD_REGISTRO"]
            var reg = obj.obtenerRegistroxCodigo(int.Parse(Session["SS_COD_REGISTRO"].ToString()));

            // Verificar si es persona jurídica y si hay delegados y formato de evento aplicable
            if (reg.ES_PERSONA_JURIDICA)
            {
                if (evento.DELEGADOS > 0 && evento.FORMATO_EVENTOXEVENTO.Where(x => x.APLICA_JURIDICO == true).Count() > 0)
                {
                    tramiteAdicional = true;
                }

                // Vincular la confirmación y obtener el código de confirmación
                lblCodigoConfirmacion.Text = obj.vincularConfirmacion(int.Parse(Session["SS_COD_REGISTRO"].ToString()), evento.COD_EVENTO, !tramiteAdicional).ToString();
            }
            else
            {
                // Verificar si hay formato de evento aplicable para personas naturales
                if (evento.FORMATO_EVENTOXEVENTO.Where(x => x.APLICA_NATURAL == true).Count() > 0)
                {
                    tramiteAdicional = true;
                }

                // Vincular la confirmación y obtener el código de confirmación
                lblCodigoConfirmacion.Text = obj.vincularConfirmacion(int.Parse(Session["SS_COD_REGISTRO"].ToString()), evento.COD_EVENTO, !tramiteAdicional).ToString();
            }

            // Agregar las tecnologías a la confirmación
            obj.agregarTecnologiasConfirmacion(int.Parse(lblCodigoConfirmacion.Text), listaTecnologias);

            // Mostrar mensaje de finalización
            mensajeFin(tramiteAdicional, evento.NOMBRE_EVENTO, evento.FECHA.Value, evento.COD_EVENTO);
        }


        /// <summary>
        /// Maneja el evento Click del botón btncompletarInscripcion.
        /// Cuando se hace clic en el botón, se redirige a la página "frmEventosFinal.aspx"
        /// pasando el valor del CommandArgument como parte de la URL.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        protected void btncompletarInscripcion_Click(object sender, EventArgs e)
        {
            // Obtener el botón que disparó el evento
            Button B = (Button)sender;

            // Crear una instancia de la clase de negocios (NegocioInscripcionMinSalud.data.clsNegocio)
            NegocioInscripcionMinSalud.data.clsNegocio obj = new NegocioInscripcionMinSalud.data.clsNegocio();

            // Redirigir a la página "frmEventosFinal.aspx" pasando el valor del CommandArgument como parte de la URL
            Response.Redirect("frmEventosFinal.aspx?cod=" + B.CommandArgument);
        }


        /// <summary>
        /// Maneja el evento Click del botón btnSeleccionarTodasTEcnologias.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        protected void btnSeleccionarTodasTEcnologias_Click(object sender, EventArgs e)
        {
            // Recorre todas las filas en el control grdTecnologias
            for (int K = 0; K < grdTecnologias.Items.Count; K++)
            {
                // Busca el control CheckBox llamado "chkSeleccionar" en la fila actual
                CheckBox ch = (CheckBox)grdTecnologias.Items[K].FindControl("chkSeleccionar");

                // Marca el CheckBox como seleccionado
                ch.Checked = true;
            }
        }


    }
}