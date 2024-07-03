using System;
using System.Collections.Generic;
using System.Data.Objects.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NegocioInscripcionMinSalud.data
{
    public class clsNegocio
    {
        private data.ParticipacionCiudadanaEntities model = null;

        public string generarCadenaConexion()
        {
            string res = model.Database.Connection.ConnectionString;
            res = res.Replace("MultipleActiveResultSets=True;", "");
            res = res.Replace("App=EntityFramework", "");
            res = "Provider=SQLOLEDB.1;" + res;
            return res;
        }

        public clsNegocio()
        {
            model = new ParticipacionCiudadanaEntities();
        }



        public TipoUsuario obtenerTipousuario(int codTipousuario)
        {
            return model.TipoUsuario.Find(codTipousuario);
        }

        public List<GRUPO_PARAMETRO_VALIDACION> obtenerGRUPO_PARAMETRO_VALIDACION()
        {
            return model.GRUPO_PARAMETRO_VALIDACION.ToList();
        }

        public List<PARAMETRO_VALIDACION> obtenerPARAMETRO_VALIDACION()
        {
            return model.PARAMETRO_VALIDACION.ToList();
        }


        public PARAMETRO_VALIDACION obtenerPARAMETRO_VALIDACION(int codPARAMETRO_VALIDACION)
        {
            return model.PARAMETRO_VALIDACION.Find(codPARAMETRO_VALIDACION);
        }


        public VALIDACION_PROCESO obtenerVALIDACION_PROCESO(int codNominacion)
        {
            return model.VALIDACION_PROCESO.Where(x => x.COD_NOMINACION_PROCESO == codNominacion).OrderByDescending(x => x.FECHA_VALIDACION).FirstOrDefault();
        }

        public OBJECION_PROCESO obtenerOBJECION_PROCESO(int codNominacion)
        {
            return model.OBJECION_PROCESO.Where(x => x.COD_NOMINACION_PROCESO == codNominacion).OrderByDescending(x => x.FECHA_OBJECION).FirstOrDefault();
        }

        public OBJECION_PROCESO obtenerOBJECION_PROCESOxCodigo(int codObjecion)
        {
            return model.OBJECION_PROCESO.Find(codObjecion);
        }

        public void crearRegistro(REGISTRO r, REGISTRO hijo)
        {
            try
            {
                var ultimaVAlidacion = model.REGISTRO.Where(x => x.DOCUMENTO == r.DOCUMENTO && x.COD_REGISTRO_PADRE.HasValue == false).FirstOrDefault();
                if (ultimaVAlidacion != null)
                {
                    //si el objeto es diferente de null, siginifcia que ya existe en la base de datos un registro con este documento.
                    return;
                }
                model.REGISTRO.Add(r);
                model.SaveChanges();
                if (hijo != null)
                {
                    hijo.COD_REGISTRO_PADRE = r.COD_REGISTRO;
                    model.REGISTRO.Add(hijo);
                    model.SaveChanges();
                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex2)
            {
                string a = ex2.Message;
            }
            catch (Exception ex)
            {

            }
        }

        public void updateRegistroAclaraciones(REGISTRO r, REGISTRO hijo, bool actualizaEstado)
        {
            try
            {
                //var registro = model.REGISTRO.Where(x=> x.USUARIO == r.USUARIO ).FirstOrDefault();
                //registro.APELLIDOS = r.APELLIDOS;
                //registro.AUTORIZO = r.AUTORIZO;
                //registro.CELULAR = r.CELULAR;
                //registro.CERTIFICO = r.CERTIFICO;
                if (actualizaEstado)
                {
                    r.COD_ESTADO_REGISTRO = 4;
                    hijo.COD_ESTADO_REGISTRO = 4;
                    r.FECHA_ENVIO_ACLARACIONES = DateTime.Now;
                    hijo.FECHA_ENVIO_ACLARACIONES = DateTime.Now;
                }

                model.SaveChanges();

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex2)
            {
                string a = ex2.Message;
            }
            catch (Exception ex)
            {

            }
        }


        //public void guardarParticipacionEvento(List<int> encuestas=  ;nm.string documento=  ;nm.string nombreAcompanante=  ;nm.string apellidoAcompanante=  ;nm.string emailAcompanante)
        //{
        //    var originales = model.participante_evento.Where(x=> x.numero_identificacion == documento.Trim()).ToArray();

        //    foreach (int item in encuestas) {
        //        participante_evento nuevo = model.participante_evento.Where(x => x.cod_evento.Value == item && x.numero_identificacion == documento).FirstOrDefault();

        //        if (nuevo == null)
        //        {
        //            nuevo = new participante_evento();
        //            nuevo.cod_evento = item;
        //            model.participante_evento.Add(nuevo);
        //        }

        //        nuevo.apellido_acompanante = apellidoAcompanante;
        //        nuevo.email_acompanante = emailAcompanante;
        //        nuevo.nombre_acompanante = nombreAcompanante;
        //        nuevo.numero_identificacion = documento;
        //        nuevo.fecha_confirmacion = DateTime.Now;
        //    }
        //    //ahora quitamos los que ya no selecciono
        //    for (int k = 0; k < originales.Length; k++)
        //    {
        //        if (!encuestas.Contains(originales[k].cod_evento.Value))
        //        {
        //            model.participante_evento.Remove(originales[k]);
        //        }
        //    }
        //    model.SaveChanges();
        //}

        //public List<participante_evento> obtenerParticipacionEvento( string documento)
        //{
        //    return model.participante_evento.Where(x=> x.numero_identificacion == documento).ToList();
        //}

        //public List<participante_evento> obtenerParticipacionEvento(string documento=  ;nm.int codEvento=  ;nm.string num)
        //{
        //    return model.participante_evento.Where(x => x.numero_identificacion == documento && x.cod_evento == codEvento && x.numero == num ).ToList();
        //}

        //public void guardarParticipacionEvento(List<int> encuestas=  ;nm. string documento=  ;nm. string nombreAcompanante=  ;nm. string apellidoAcompanante=  ;nm. string emailAcompanante=  ;nm.string num)
        //{
        //    var originales = model.participante_evento.Where(x => x.numero_identificacion == documento.Trim() && x.numero == num).ToArray();

        //    foreach (int item in encuestas)
        //    {
        //        participante_evento nuevo = model.participante_evento.Where(x => 
        //        x.cod_evento.Value == item && x.numero_identificacion == documento && x.numero == num
        //        ).FirstOrDefault();

        //        if (nuevo == null)
        //        {
        //            nuevo = new participante_evento();
        //            nuevo.cod_evento = item;
        //            model.participante_evento.Add(nuevo);
        //        }

        //        nuevo.apellido_acompanante = apellidoAcompanante;
        //        nuevo.email_acompanante = emailAcompanante;
        //        nuevo.nombre_acompanante = nombreAcompanante;
        //        nuevo.numero_identificacion = documento;
        //        nuevo.numero = num;
        //        nuevo.fecha_confirmacion = DateTime.Now;
        //    }
        //    //ahora quitamos los que ya no selecciono
        //    for (int k = 0; k < originales.Length; k++)
        //    {
        //        if (!encuestas.Contains(originales[k].cod_evento.Value))
        //        {
        //            model.participante_evento.Remove(originales[k]);
        //        }
        //    }
        //    model.SaveChanges();
        //}

        public NOMINACION_PROCESO obtenerNOMINACION_PROCESO(int Cod_NOMINACION_PROCESO)
        {
            var res = model.NOMINACION_PROCESO.Find(Cod_NOMINACION_PROCESO);
            return res;
        }

        public NOMINACION_HUERFANA obtenerNOMINACION_HUERFANA(int Cod_NOMINACION_PROCESO)
        {
            var res = model.NOMINACION_HUERFANA.Find(Cod_NOMINACION_PROCESO);
            return res;
        }


        public List<ARCHIVOXNOMINACION_HUERFANA> obtenerARCHIVOXNOMINACION_HUERFANA(int? Cod_NOMINACION_PROCESO)
        {
            var res = model.ARCHIVOXNOMINACION_HUERFANA.Where(x => x.COD_NOMINACION_PROCESO == Cod_NOMINACION_PROCESO).ToList();
            return res;
        }


        public VALIDACION_PROCESO_RUPS obtenerValidacionNOMINACION_PROCESORups(int Cod_NOMINACION_PROCESO)
        {
            var res = model.VALIDACION_PROCESO_RUPS.Where(x => x.COD_NOMINACION_PROCESO_RUPS == Cod_NOMINACION_PROCESO).OrderByDescending(x => x.COD_VALIDACION_PROESO_RUPS).Take(1).FirstOrDefault();
            return res;
        }

        public NOMINACION_PROCESO_RUPS obtenerNOMINACION_PROCESORups(int Cod_NOMINACION_PROCESO)
        {


            var res = model.NOMINACION_PROCESO_RUPS.Where(x => x.COD_NOMINACION_PROCESO_RUPS == Cod_NOMINACION_PROCESO).FirstOrDefault();
            //var res = model.NOMINACION_PROCESO_RUPS.Find(Cod_NOMINACION_PROCESO);
            return res;
        }


        public UPC_FORMULARIO3 obtenerUPC_FORMULARIO3(int Cod_NOMINACION_PROCESO)
        {
            var res = model.UPC_FORMULARIO3.Where(x => x.COD_NOMINACION_PROCESO_UPC == Cod_NOMINACION_PROCESO).FirstOrDefault();
            return res;
        }

        public NOMINACION_PROCESO_UPC obtenerNOMINACION_PROCESOUPC(int Cod_NOMINACION_PROCESO)
        {
            var res = model.NOMINACION_PROCESO_UPC.Find(Cod_NOMINACION_PROCESO);
            return res;
        }

        public List<TIPO_JURIDICO> obtenerPerfil(int? padre)
        {
            var res = model.TIPO_JURIDICO.Where(x => x.PADRE == padre);
            return res.ToList();
        }

        public List<TIPO_JURIDICO> obtenerPerfil()
        {
            var res = model.TIPO_JURIDICO.ToList();
            return res.ToList();
        }

        public List<TipoIdentificacion> obtenerTipoDocumento(bool esNatural, bool esJuridico)
        {
            var res = model.TipoIdentificacion.Where(x => x.EsPersona == esNatural || !x.EsPersona == esJuridico)
                .OrderBy(x => x.Nombre).ToList();
            return res;
        }

        public List<TipoIdentificacion> obtenerTipoDocumentoJuridico(bool esActa)
        {
            var res = model.TipoIdentificacion.Where(x => x.EsPersona == false && x.EsActa == esActa)
                    .OrderBy(x => x.Nombre).ToList();
            return res;
        }


        public void actualizarTipoUsuarioxDocumento(string documentoParticipante, short tipoUsario)
        {
            var p = model.Participante.Find(documentoParticipante);
            p.IdTipoUsuario = tipoUsario;
            model.SaveChanges();
        }

        public Participante obtenerParticipantexdocumento(string documentoParticipante)
        {
            return model.Participante.Find(documentoParticipante);
        }

        public REGISTRO obtenerRegistroxdocumento(string documento)
        {
            return model.REGISTRO.Where(x => x.DOCUMENTO.Trim() == documento.Trim()).FirstOrDefault();
        }

        public REGISTRO obtenerRegistroxdocumentoNatural(string documento)
        {
            return model.REGISTRO.Where(x => x.DOCUMENTO.Trim() == documento.Trim() && x.ES_PERSONA_NATURAL == true).FirstOrDefault();
        }

        public REGISTRO obtenerRegistroxhijo(int COD_REGISTRO_PADRE)
        {
            return model.REGISTRO.Where(x => x.COD_REGISTRO_PADRE == COD_REGISTRO_PADRE).FirstOrDefault();
        }

        public REGISTRO obtenerRegistroPadrexdocumento(string documento)
        {
            return model.REGISTRO.Where(x => x.DOCUMENTO.Trim() == documento.Trim() && x.COD_REGISTRO_PADRE.HasValue == false).FirstOrDefault();
        }

        public REGISTRO obtenerRegistroxUsuario(string usuario)
        {
            return model.REGISTRO.Where(x => x.NOMBRE_USUARIO.Trim() == usuario.Trim()).FirstOrDefault();
        }

        public REGISTRO obtenerRegistroxCorreValidar(string correo)
        {

            var r = model.REGISTRO.Where(x =>
            x.CORREO.Trim() == correo.Trim() &&
            x.COD_REGISTRO_PADRE.HasValue == false
            ).OrderBy(x => x.FECHA_REGISTRO).FirstOrDefault();
            if (r == null)
            {
                model.REGISTRO.Where(x =>
                correo.Trim().Contains(x.CORREO.Trim())
                &&
            x.COD_REGISTRO_PADRE.HasValue == false).OrderBy(x => x.FECHA_REGISTRO).FirstOrDefault();
            }
            return r;
        }


        public REGISTRO obtenerRegistroxCorreo(string correo, int idRegistro)
        {
            if (idRegistro == 0)
            {
                var r = model.REGISTRO.Where(x =>
                x.CORREO.Trim() == correo.Trim()

                ).OrderBy(x => x.FECHA_REGISTRO).FirstOrDefault();
                if (r == null)
                {
                    model.REGISTRO.Where(x => correo.Trim().Contains(x.CORREO.Trim())).OrderBy(x => x.FECHA_REGISTRO).FirstOrDefault();
                }
                return r;
            }
            else
            {
                return model.REGISTRO.Where(reg => reg.CORREO.Trim() == correo.Trim() && reg.COD_REGISTRO == idRegistro).FirstOrDefault();
            }
        }

        public REGISTRO obtenerRegistroxCodigo(int cod)
        {
            return model.REGISTRO.Find(cod);
        }

        public string obtenerTipoJuridicoxCodigo(int cod)
        {
            return model.TIPO_JURIDICO.Find(cod).NOMBRE_TIPO_JURIDICO;
        }

        public CONFIRMACION_EVENTO obtenerCONFIRMACION_EVENTOValidar(int codTematica, int codRegistro)
        {
            return model.CONFIRMACION_EVENTO.Where(x =>
            x.COD_REGISTRO == codRegistro &&
            x.FECHA_CANCELACION.HasValue == false
            && x.EVENTO.COD_TEMATICA_EVENTO == codTematica
            ).FirstOrDefault();
        }

        public TIPO_JURIDICO obtenerTipoJuridico(int codTipoJuridico)
        {
            return model.TIPO_JURIDICO.Find(codTipoJuridico);
        }

        public List<REGISTRO> obtenerRegistroRaizxCorreo(string correo)
        {
            return model.REGISTRO.Where(x => x.CORREO.Trim() == correo.Trim() && x.COD_REGISTRO_PADRE.HasValue == false).ToList();
        }

        public void validarCorreoElectronico(REGISTRO r, int? usuarioValidador, out bool enviarCorreo)
        {
            enviarCorreo = false;
            if (r.TIPO_JURIDICO == null)
            {
                r.COD_ESTADO_REGISTRO = 5;
                r.FECHA_VERIFICACION_CORREO = DateTime.Now;
                r.FECHA_VALIDACION = DateTime.Now;
                r.VALIDADO_POR = usuarioValidador;

                enviarCorreo = true;
            }
            else
            {
                //las personas naturales se validan automaticamente.
                r.FECHA_VERIFICACION_CORREO = DateTime.Now;
                r.COD_ESTADO_REGISTRO = 2;
            }
            model.SaveChanges();
        }

        public void actualizarContrasena(int codREgistro, string contrasena)
        {
            var r = model.REGISTRO.Find(codREgistro);
            r.CONTRASENA = contrasena;
            model.SaveChanges();


        }

        public int vincularConfirmacion(int codRegistro, int codEvento, bool completo)
        {
            //eliminamos si tiene algun registro para este evento con cancelado
            CONFIRMACION_EVENTO delete = model.CONFIRMACION_EVENTO.Where(x => x.COD_REGISTRO == codRegistro && x.COD_EVENTO == codEvento).FirstOrDefault();
            if (delete != null)
            {
                var arr = delete.TECNOLOGIAXCONFIRMACION_EVENTO.ToArray();
                for (int k = 0; k < arr.Length; k++)
                {
                    model.TECNOLOGIAXCONFIRMACION_EVENTO.Remove(arr[k]);
                }

                var arr2 = delete.FORMATOEVENTOXCONFIRMACION.ToArray();
                for (int k = 0; k < arr2.Length; k++)
                {
                    model.FORMATOEVENTOXCONFIRMACION.Remove(arr2[k]);
                }

                model.CONFIRMACION_EVENTO.Remove(delete);
            }

            CONFIRMACION_EVENTO c = new data.CONFIRMACION_EVENTO();
            c.COMPLETO = completo;
            c.FECHA_CONFIRMACION = DateTime.Now;
            if (completo == true)
                c.FECHA_COMPLETO = DateTime.Now;
            c.COD_REGISTRO = codRegistro;
            c.COD_EVENTO = codEvento;
            model.CONFIRMACION_EVENTO.Add(c);
            model.SaveChanges();
            return c.COD_CONFIRMACION_EVENTO;
        }

        public CONFIRMACION_EVENTO obtenerCONFIRMACION_EVENTO(int codRegistro, int codEvento)
        {
            CONFIRMACION_EVENTO c = model.CONFIRMACION_EVENTO.Where(x => x.COD_REGISTRO == codRegistro && x.COD_EVENTO == codEvento).FirstOrDefault();
            return c;
        }

        public void eliminarConfirmacion(int cod)
        {
            CONFIRMACION_EVENTO c = model.CONFIRMACION_EVENTO.Find(cod);
            model.CONFIRMACION_EVENTO.Remove(c);
            model.SaveChanges();
        }

        public void cancelarConfirmacion(int codRegistro, int codEvento)
        {
            CONFIRMACION_EVENTO c = model.CONFIRMACION_EVENTO.Where(x => x.COD_REGISTRO == codRegistro && x.COD_EVENTO == codEvento).FirstOrDefault();
            c.CANCELADO = true;
            c.FECHA_CANCELACION = DateTime.Now;
            model.SaveChanges();
        }


        public void agregarDelegadoConfirmacion(int codRegistroPadre, int codEvento, int codREgistroDelegado)
        {
            CONFIRMACION_EVENTO c = model.CONFIRMACION_EVENTO.Where(x => x.COD_REGISTRO == codRegistroPadre && x.COD_EVENTO == codEvento).FirstOrDefault();

            CONFIRMACION_EVENTO hijo = new CONFIRMACION_EVENTO();
            hijo.COD_REGISTRO = codREgistroDelegado;
            hijo.COD_EVENTO = codEvento;
            hijo.COMPLETO = false;
            hijo.COD_CONFIRMACION_EVENTO_PADRE = c.COD_CONFIRMACION_EVENTO;

            model.SaveChanges();
        }

        public void completarConfirmacion(int codRegistro, int codEvento)
        {
            CONFIRMACION_EVENTO c = model.CONFIRMACION_EVENTO.Where(x => x.COD_REGISTRO == codRegistro && x.COD_EVENTO == codEvento).FirstOrDefault();
            c.COMPLETO = true;
            c.FECHA_COMPLETO = DateTime.Now;
            model.SaveChanges();
        }

        public void actualizarArchivosConfirmacion(int codRegistro, int codEvento, List<FORMATOEVENTOXCONFIRMACION> archivos)
        {
            CONFIRMACION_EVENTO c = model.CONFIRMACION_EVENTO.Where(x => x.COD_REGISTRO == codRegistro && x.COD_EVENTO == codEvento).FirstOrDefault();
            var arr = c.FORMATOEVENTOXCONFIRMACION.ToArray();
            for (int k = 0; k < arr.Length; k++)
            {
                model.FORMATOEVENTOXCONFIRMACION.Remove(arr[k]);
            }

            for (int j = 0; j < archivos.Count; j++)
            {
                if (archivos[j].URL_ARCHIVO != string.Empty)
                {
                    FORMATOEVENTOXCONFIRMACION fr = new data.FORMATOEVENTOXCONFIRMACION();
                    fr.COD_FORMATO_EVENTO = archivos[j].COD_FORMATO_EVENTO;
                    fr.URL_ARCHIVO = archivos[j].URL_ARCHIVO;
                    c.FORMATOEVENTOXCONFIRMACION.Add(fr);
                }
            }

            model.SaveChanges();
        }

        public void agregarTecnologiasConfirmacion(int cod, List<int> tecnologias)
        {
            CONFIRMACION_EVENTO c = model.CONFIRMACION_EVENTO.Find(cod);
            for (int k = 0; k < tecnologias.Count; k++)
            {
                TECNOLOGIAXCONFIRMACION_EVENTO tec = new data.TECNOLOGIAXCONFIRMACION_EVENTO();
                tec.COD_TECNOLOGIA = tecnologias[k];
                c.TECNOLOGIAXCONFIRMACION_EVENTO.Add(tec);
            }
            model.SaveChanges();
        }





        public List<MEDICAMENTOS> obtenerMedicamentos(string criterio)
        {
            return model.MEDICAMENTOS.Where(x => x.NOMBRE_MEDICAMENTOS.Contains(criterio) || x.COD_MEDICAMENTOS.Contains(criterio)).Take(20).ToList();
        }

        public List<PROCEDIMIENTO> obtenerPROCEDIMIENTO(string criterio)
        {
            return model.PROCEDIMIENTO.Where(x => x.NOMBRE_PROCEDIMIENTO.Contains(criterio) || x.COD_PROCEDIMIENTO.Contains(criterio)).Take(20).ToList();
        }

        public PROCESO obtenerProceso(int codProceso)
        {
            return model.PROCESO.Find(codProceso);
        }

        public TEMATICA_EVENTO obtenerTematica(int codTematica)
        {
            return model.TEMATICA_EVENTO.Find(codTematica);
        }

        public EVENTO obtenerEvento(int codEVENTO)
        {
            return model.EVENTO.Find(codEVENTO);
        }

        public List<OBJECION_PROCESO> obtenerObjecionxNominacion(int codNominacion)
        {
            return model.OBJECION_PROCESO.Where(x => x.COD_NOMINACION_PROCESO == codNominacion && x.VISIBLE == true).ToList();
        }

        public List<OBJECION_HUERFANA> obtenerObjecionxNominacionHuerfana(int codNominacionHuerfana)
        {
            return model.OBJECION_HUERFANA.Where(x => x.COD_NOMINACION_HUERFANA == codNominacionHuerfana).ToList();
        }

        public List<TEMATICA_EVENTO> obtenerTematicaProceso(int codProceso, DateTime fecha)
        {
            var valG3 = model.TEMATICA_EVENTO
                .Join(model.EVENTO, x => x.COD_TEMATICA_EVENTO, x2 => x2.COD_TEMATICA_EVENTO, (x, x2)
=> new { tematica = x, evento = x2 })
.Where(x3 => x3.evento.COD_PROCESO == codProceso
&& x3.evento.VISIBLE_DESDE <= fecha
&& x3.evento.VISIBLE_HASTA >= fecha
)
.Select(x3 => x3.tematica).Distinct().ToList();

            return valG3;
        }

        public List<CIE10> obtenerCIE(string criterio)
        {
            return model.CIE10.Where(x => (x.NOMBRE_CIE10 + x.COD_CIE10).Contains(criterio)).Take(20).ToList();
        }


        public List<LISTADO_HEF> obtenerNombreListado(string criterio)
        {
            return model.LISTADO_HEF.Where(x => x.Enfermedad.Contains(criterio)).OrderBy(x => x.ID).Take(20).ToList();
        }


        public List<LISTADO_HEF> obtenerCodigoListado(string criterio)
        {
            //return model.LISTADO_HEF.Where(x => x.ID.Contains(@"/criterio/")).Take(20).ToList();
            //return model.LISTADO_HEF.Where(x => x.ID.ToString().StartsWith(criterio)).OrderBy(x => x.ID).Take(20).ToList();
            return model.LISTADO_HEF.Where(x => SqlFunctions.StringConvert((double)x.ID).TrimStart().StartsWith(criterio)).OrderBy(x => x.ID).Take(20).ToList();

        }

        public List<LISTADO_HEF> obtenerCIEListado(string criterio)
        {
            return model.LISTADO_HEF.Where(x => x.CIE.Contains(criterio)).OrderBy(x => x.ID).Take(20).ToList();
        }



        public List<ESPECIALIDAD> obtenerEspecialidad(string criterio)
        {
            return model.ESPECIALIDAD.Where(x => x.NOMBRE_ESPECIALIDAD.Contains(criterio)).Take(20).ToList();
        }


        public List<CUPS> obtenerCups(string criterio)
        {
            return model.CUPS.Where(x => x.CUPS1.Contains(criterio)).Take(20).ToList();
        }

        public List<CUPS> obtenerCupsEHF(string criterio)
        {
            return model.CUPS.Where(x => (x.CUPS1 + x.COD_CUPS).Contains(criterio)).Take(20).ToList();
        }

        public List<DCI> obtenerDCI(string criterio)
        {
            return model.DCI.Where(x => x.MEDICAMENTO.Contains(criterio)).Take(20).ToList();
        }

        public int guardarNominacion2017(
            int? COD_NOMINACION_PROCESO, int COD_PROCESO, int COD_REGISTRO, bool ES_MEDICAMENTO, bool ES_PROCEDIMIENTO,
            bool ES_DISPOSITIVO_MEDICO, bool ES_OTRO, string NOMBRE_TECNOLOGIA,
            string MEDICAMENTOS, string PROCEDIMIENTO, string dispositivo, string DESCRIPCION_OTRO,
            bool CRITERIO_A, bool CRITERIO_B, bool CRITERIO_C, bool CRITERIO_D, bool CRITERIO_E, bool CRITERIO_F,
            string OBS_CRITERIO_A, string OBS_CRITERIO_B, string OBS_CRITERIO_C, string OBS_CRITERIO_D, string OBS_CRITERIO_E, string OBS_CRITERIO_F,
            bool? ADJUNTA_EVIDENCIA, string OBSERVACIONES_EVIDENCIA, string RUTA_EVIDENCIA,
            bool? CONFLICTO_INTERES, string OBSERVACIONES_CONFLICTO, List<ARCHIVOXNOMINACION> ARCHIVOS)
        {
            NOMINACION_PROCESO nm = null;
            if (COD_NOMINACION_PROCESO.HasValue)
            {
                nm = model.NOMINACION_PROCESO.Find(COD_NOMINACION_PROCESO);
            }
            else
            {
                nm = new NOMINACION_PROCESO();
                model.NOMINACION_PROCESO.Add(nm);
                nm.COD_ESTADO_NOMINACION = 1;
            }
            for (int K = 0; K < ARCHIVOS.Count; K++)
            {
                if (nm.ARCHIVOXNOMINACION.Where(X => X.URL_ARCHIVO == ARCHIVOS[K].URL_ARCHIVO).Count() <= 0)
                {
                    ARCHIVOXNOMINACION AR = new ARCHIVOXNOMINACION();
                    AR.URL_ARCHIVO = ARCHIVOS[K].URL_ARCHIVO;
                    AR.DESCRIPCION_ARCHIVO = ARCHIVOS[K].DESCRIPCION_ARCHIVO;
                    nm.ARCHIVOXNOMINACION.Add(AR);
                }
                else
                {
                    var F = nm.ARCHIVOXNOMINACION.Where(X => X.URL_ARCHIVO == ARCHIVOS[K].URL_ARCHIVO).FirstOrDefault();
                    F.DESCRIPCION_ARCHIVO = ARCHIVOS[K].DESCRIPCION_ARCHIVO;
                }
            }
            //quitamos los que ya no van
            var ARREGLO = nm.ARCHIVOXNOMINACION.ToArray();
            for (int k = 0; k < ARREGLO.Length; k++)
            {
                if (ARCHIVOS.Where(X => X.URL_ARCHIVO == ARREGLO[k].URL_ARCHIVO).Count() <= 0)
                {
                    model.ARCHIVOXNOMINACION.Remove(model.ARCHIVOXNOMINACION.Find(ARREGLO[k].COD_ARCHIVOXNOMINACION));
                }
            }


            nm.COD_PROCESO = COD_PROCESO;
            nm.COD_REGISTRO = COD_REGISTRO;
            nm.ES_MEDICAMENTO = ES_MEDICAMENTO;
            nm.ES_PROCEDIMIENTO = ES_PROCEDIMIENTO;
            nm.ES_DISPOSITIVO_MEDICO = ES_DISPOSITIVO_MEDICO;
            nm.ES_OTRO = ES_OTRO;
            nm.ES_SERVICIO_SALUD =
            //nm.NOMBRE_TECNOLOGIA = NOMBRE_TECNOLOGIA;
            //nm.CIE10 = CIE10;
            //nm.CIE10_2 = CIE10_2;
            //nm.CIE10_INDICACION = CIE10_INDICACION;
            //nm.MEDICAMENTOS = MEDICAMENTOS;
            //nm.PROCEDIMIENTO = PROCEDIMIENTO;
            //nm.DISPOSITIVO = dispositivo;
            //nm.DESCRIPCION_OTRO = DESCRIPCION_OTRO;
            //nm.CRITERIO_A = CRITERIO_A;
            //nm.CRITERIO_B = CRITERIO_B;
            //nm.CRITERIO_C = CRITERIO_C;
            //nm.CRITERIO_D = CRITERIO_D;
            //nm.CRITERIO_E = CRITERIO_E;
            //nm.CRITERIO_F = CRITERIO_F;
            //nm.OBS_CRITERIO_A = OBS_CRITERIO_A;
            //nm.OBS_CRITERIO_B = OBS_CRITERIO_B;
            //nm.OBS_CRITERIO_C = OBS_CRITERIO_C;
            //nm.OBS_CRITERIO_D = OBS_CRITERIO_D;
            //nm.OBS_CRITERIO_E = OBS_CRITERIO_E;
            //nm.OBS_CRITERIO_F = OBS_CRITERIO_F;
            nm.ADJUNTA_EVIDENCIA = ADJUNTA_EVIDENCIA;
            nm.OBSERVACIONES_EVIDENCIA = OBSERVACIONES_EVIDENCIA;
            nm.RUTA_EVIDENCIA = RUTA_EVIDENCIA;
            nm.CONFLICTO_INTERES = CONFLICTO_INTERES;
            nm.OBSERVACIONES_CONFLICTO = OBSERVACIONES_CONFLICTO;
            model.SaveChanges();
            if (COD_NOMINACION_PROCESO.HasValue == false)
            {
                nm.ID_MANUAL = nm.COD_NOMINACION_PROCESO.ToString();
                model.SaveChanges();
            }
            return nm.COD_NOMINACION_PROCESO;
        }

        public void cambiarEstadoNominacionUPC(int COD_NOMINACION_PROCESO_UPC, int estado)
        {
            NOMINACION_PROCESO_UPC nm = null;
            nm = model.NOMINACION_PROCESO_UPC.Find(COD_NOMINACION_PROCESO_UPC);

            nm.COD_ESTADO_NOMINACION_UPC = estado;
            model.SaveChanges();
        }

        public void cambiarEstadoNominacionRups(int COD_NOMINACION_PROCESO_RUPS, int estado)
        {
            NOMINACION_PROCESO_RUPS nm = null;
            nm = model.NOMINACION_PROCESO_RUPS.Find(COD_NOMINACION_PROCESO_RUPS);

            nm.COD_ESTADO_NOMINACION_RUPS = estado;
            model.SaveChanges();
        }

        public int guardarUPC_FORMULARIO3(
            int COD_NOMINACION_PROCESO_UPC, int? COD_TIPO_NOMINACION_MEDICAMENTO, string OBS_TIPO_NOMINACION_MEDICAMENTO,
            string NumCasasFarmaceuticas,
                string NumAnosMedicamento, string CodCumMedicamento, string DosisPediatraMedicamentos,
                string DosisAdultosMedicamentos, string IndicacionMedicamento,
                string PrecioPorFormaFarma, string PrecioPorConcentracion, string PrecioPorPresentacion,
                string ValorCOPMedicamento, string UnidadMedidaMedicamento,
                bool ReaccionesAdversasSI, string OBSReaccionesAdversas, bool Contraindicaciones,
                string OBSContraindicaciones, bool AdvertenciasPrecauciones,
                string OSBAdvertenciasPrecauciones, bool Interacciones, string OBSInteracciones,
                bool Interrupcion, string OSBInterrupcion, bool ListadoEscencialesSi,
                string ObservacionesListadoEscencial, string NombreGPCMedicamento,
                string RecomendacionMedicamentoGPC, string GradoRecomendacionMedicamentoGPC,
                bool NuevoProcedimientoSi, string ObservacionesNuevoProcedimiento,
                string IpsREalizanProcedimiento, string NumAnosProcedimento, string FrecuenciaProcedimiento,
                string FrecuenciaAplicacionProcedimiento, string DuracionProcedimiento,
                string PrecioDuracionProcedimiento,
                string NombreGPCProcedimiento, string RecomendacionProcedimientoGPC,
                string GradoRecomendacionProcedimientoGPC, string desenlacesProcedimiento,
                string ResultadosSeguridadProcedimiento,
                string TamanoPoblacion, string TamanoPoblacionColombiana, string RElacionTsnCArgaEnfermedad,
                string Beneficios, bool TSNReduceMortalidadSi, string OBSTSNReduceMortalidad,
                bool TSNMejoraDiscapacidadSi, string OBSTSNMejoraDiscapacidadSi)
        {
            UPC_FORMULARIO3 nm = null;
            nm = model.UPC_FORMULARIO3.Where(x => x.COD_NOMINACION_PROCESO_UPC == COD_NOMINACION_PROCESO_UPC).FirstOrDefault();
            if (nm == null)
            {
                nm = new UPC_FORMULARIO3();
                nm.COD_NOMINACION_PROCESO_UPC = COD_NOMINACION_PROCESO_UPC;
                model.UPC_FORMULARIO3.Add(nm);
                model.SaveChanges();
            }
            //inicio
            nm.COD_TIPO_NOMINACION_MEDICAMENTO = COD_TIPO_NOMINACION_MEDICAMENTO;
            nm.OBS_TIPO_NOMINACION_MEDICAMENTO = OBS_TIPO_NOMINACION_MEDICAMENTO;
            nm.NumCasasFarmaceuticas = NumCasasFarmaceuticas;
            nm.NumAnosMedicamento = NumAnosMedicamento;
            nm.CodCumMedicamento = CodCumMedicamento;
            nm.DosisPediatraMedicamentos = DosisPediatraMedicamentos;
            nm.DosisAdultosMedicamentos = DosisAdultosMedicamentos;
            nm.IndicacionMedicamento = IndicacionMedicamento;
            nm.PrecioPorFormaFarma = PrecioPorFormaFarma;
            nm.PrecioPorConcentracion = PrecioPorConcentracion;
            nm.PrecioPorPresentacion = PrecioPorPresentacion;
            nm.ValorCOPMedicamento = ValorCOPMedicamento;
            nm.UnidadMedidaMedicamento = UnidadMedidaMedicamento;
            nm.ReaccionesAdversasSI = ReaccionesAdversasSI;
            nm.OBSReaccionesAdversas = OBSReaccionesAdversas;
            nm.Contraindicaciones = Contraindicaciones;
            nm.OBSContraindicaciones = OBSContraindicaciones;
            nm.AdvertenciasPrecauciones = AdvertenciasPrecauciones;
            nm.OSBAdvertenciasPrecauciones = OSBAdvertenciasPrecauciones;
            nm.Interacciones = Interacciones;
            nm.OBSInteracciones = OBSInteracciones;
            nm.Interrupcion = Interrupcion;
            nm.OSBInterrupcion = OSBInterrupcion;
            nm.ListadoEscencialesSi = ListadoEscencialesSi;
            nm.ObservacionesListadoEscencial = ObservacionesListadoEscencial;
            nm.NombreGPCMedicamento = NombreGPCMedicamento;
            nm.RecomendacionMedicamentoGPC = RecomendacionMedicamentoGPC;
            nm.GradoRecomendacionMedicamentoGPC = GradoRecomendacionMedicamentoGPC;
            nm.NuevoProcedimientoSi = NuevoProcedimientoSi;
            nm.ObservacionesNuevoProcedimiento = ObservacionesNuevoProcedimiento;
            nm.IpsREalizanProcedimiento = IpsREalizanProcedimiento;
            nm.NumAnosProcedimento = NumAnosProcedimento;
            nm.FrecuenciaProcedimiento = FrecuenciaProcedimiento;
            nm.FrecuenciaAplicacionProcedimiento = FrecuenciaAplicacionProcedimiento;
            nm.DuracionProcedimiento = DuracionProcedimiento;
            nm.PrecioDuracionProcedimiento = PrecioDuracionProcedimiento;
            nm.NombreGPCProcedimiento = NombreGPCProcedimiento;
            nm.RecomendacionProcedimientoGPC = RecomendacionProcedimientoGPC;
            nm.GradoRecomendacionProcedimientoGPC = GradoRecomendacionProcedimientoGPC;
            nm.desenlacesProcedimiento = desenlacesProcedimiento;
            nm.ResultadosSeguridadProcedimiento = ResultadosSeguridadProcedimiento;
            nm.TamanoPoblacion = TamanoPoblacion;
            nm.TamanoPoblacionColombiana = TamanoPoblacionColombiana;
            nm.RElacionTsnCArgaEnfermedad = RElacionTsnCArgaEnfermedad;
            nm.Beneficios = Beneficios;
            nm.TSNReduceMortalidadSi = TSNReduceMortalidadSi;
            nm.OBSTSNReduceMortalidad = OBSTSNReduceMortalidad;
            nm.TSNMejoraDiscapacidadSi = TSNMejoraDiscapacidadSi;
            nm.OBSTSNMejoraDiscapacidadSi = OBSTSNMejoraDiscapacidadSi;
            //fin
            model.SaveChanges();
            return nm.COD_NOMINACION_PROCESO_UPC;
        }

        public int guardarNominacionUPC(
   int? COD_NOMINACION_PROCESO_UPC,
   int COD_PROCESO, DateTime FECHA_NOMINACION, int COD_REGISTRO,
   string CARTA_PRESENTACION, string NOMBRE_TECNOLOGIA, string NOMBRE_COMERCIAL,
   string INDICACION_USO, string JUSTIFICACION, string _CIE10, string CIE102, string CIE103,
   bool ES_MEDICAMENTO, bool ES_PROCEDIMIENTO, bool ES_DISPOSITIVO, bool ES_OTRO,
   bool ES_TITULAR_REGISTRO_TSN, string OBS_TITULAR_REGISTRO_TSN, bool ES_FABRICANTE_TSN, string OBS_FABRICANTE_TSN,
   bool ES_IMPORTADOR_TSN, string OBS_IMPORTADOR, bool ES_ACONDICIONADOR_TSN, string OBS_ACONDICIONDOR_TSN,
   bool ES_PRESTADOR_TSN, string OBS_PRESTADOR_TSN, bool ES_USUARIO_TSN, string OBS_USUARIO_TSN,
   bool ES_OTRO_TSN, string OBS_OTRO_TSN, string PRINCIPIO_ACTIVO, string CODIGO_ATC, string FORMA_FARMACEUTICA,
   string CONCENTRACION, string VIA_ADMINSITRACION, string OTRAS_INDICACIONES_MEDICAMENTO,
   string REGISTRO_SANITARIO, string OBSERVACIONES_MEDICAMENTO, string CODIGO_CUPS, string INDICACION_PROCEDIMIENTO,
   int? COD_TIPO_PROCEDIMIENTO_UPC, string OBSERVACIONES_PROCEDIMIENTO, string REGISTRO_SANITARIO_DISPOSITIVO,
   int? COD_TIPO_DISPOSITIVO, int? COD_CLASIFICACION_RIESGO, string INDICACIONES_DISPOSITIVO,
   string OBSERVACIONES_DISPOSITIVO, bool ES_PRIMERA, string OBS_ES_PRIMERA, bool ES_SEGUNDA, string OBS_ES_SEGUNDA,
   bool ES_TERCERA, string OBS_ES_TERCERA, bool ES_COTIDIANO, string OBS_ES_COTIDIANO, bool ES_OTRA_IMPORTANCIA,
   string OBS_OTRA_IMPORTANCIA, bool ES_O1_MUJER, bool ES_O1_HOMBRE, string OBS_ES_01,
   bool ES_1_4MUJER, bool ES_1_4HOMBRE, string OBS_ES_1_4, bool ES_5_14_MUJER, bool ES_5_14_HOMBRE, string ES_5_14_OBS,
   bool ES_15_18_MUJER, bool ES_15_18_HOMBRE, string ES_15_18_OBS, bool ES_19_29_MUJER, bool ES_19_29_HOMBRE, string ES_19_29_OBS,
   bool ES_30_44_MUJER, bool ES_30_44_HOMBRE, string ES_30_44_OBS, bool ES_45_59_MUJER, bool ES_45_59_HOMBRE, string ES_45_59_OBS,
   bool ES_60_69_MUJER, bool ES_60_69_HOMBRE, string ES_60_69_OBS, bool ES_70_79_MUJER, bool ES_70_79_HOMBRE, string ES_70_79_OBS,
   bool ES_80_100_MUJER, bool ES_80_100_HOMBRE, string ES_80_100_OBS, bool ES_PROMOCION_SALUD, string OBS_ES_PROMOCION_SALUD,
   bool ES_PREVENCION_ENFERMEDAD, string OBS_ES_PREVENCION_ENFERMEDAD, bool ES_DIAGNOSTICO, string OBS_ES_DIAGNOSTICO, bool ES_TRATAMIENTO,
   string OBS_ES_TRATAMIENTO, bool ES_REHABILITACION, string OBS_ES_REHABILITACION, bool ES_PALIACION, string OBS_ES_PALIACION,
   bool ES_COSMETICO, string OBS_ES_COSEMTICO, int? COD_AMBITO_UPC, bool ES_REDUCCION_MORTALIDAD, string OBS_ES_REDUCCION_MORTALIDAD,
   bool ES_REDUCCION_MORBILIDAD, string OBS_ES_REDUCCION_MORBILIDAD, bool ES_DISMINUCION_INSTANCIA, string OBS_ES_DISMINUCION_INSTANCIA,
   bool ES_MEJORA_CALIDAD_VIDA, string OBS_ES_MEJORA_CALIDAD_VIDA, bool ES_OTRO_USO_TENOCLOGIA, string OBS_ES_OTRO_USO_TECNOLOGIA,
   bool TIENE_EFECTIVIDAD, string ARCHIVO_EFECTIVIDAD, bool TIENE_SEGURIDAD, string ARCHIVO_SEGURIDAD, bool TIENE_EFICACIA, string ARCHIVO_EFICACIA,
   bool OTRA_EVIDENCIA, string OBS_OTRA_EVIDENCIA, bool ES_EXTERIOR, string OBS_ES_EXTERIOR, string NOMBRE_GPC, string RECOMENDACION_GPC,
   bool PRIMERA_INFANCIA, string OBS_PRIMERA_INFANACIA, bool EMBARAZO, string OBS_EMBARAZO, bool DESPLAZADOS, string OBS_DESPLAZADOS,
   bool VICTIMAS_ARMADAS, string OBS_VICTIMAS_ARMADAS, bool ADULTOS_MAYORES, string OBS_ADULTOS_MAYORES, bool DISCAPACIDAD, string OBS_DISCAPACIDAD,
   bool ENF_HUERFANADAS, string OBS_ENF_HUERFANAS, bool ES_SALUD_PUBLICA, string OBS_SALUD_PUBLICA, bool ES_RECURSO_MEDICAMENTO,
   string OBS_ES_RECURSO_MEDICAMENTO, bool ES_RECURSO_DISPOSITIVO, string OBS_ES_RECURSO_DISPOSITIVO, bool ES_RECURSO_INVITRO,
   string OBS_ES_RECURSO_INVITRO, bool ES_AGENTE_BIOLOGICO, string OBS_ES_AGENTE_BIOLOGICO, bool ES_PRODCUTO_BIOLOGICO, string OBS_ES_PRODCUTO_BIOLOGICO,
   bool ES_OTRO_RECURSO_ADICIONAL, string OBS_ES_OTRO_RECURSO_ADICIONAL, string NOMBRE_COMPARADOR, string CODIGO_ATC_COMPARADOR, string COBERTURA,
   bool ADJUNTA_EVIDENCIA, string OBS_EVIDENCIA, string ARCHIVO_EVIDENCIA, bool CONFLICTO_SI, string OBS_CONFLICTO,
   string URL_FORMATO3, string ULR_FORMATO4, string URL_FORMATO5
)
        {
            NOMINACION_PROCESO_UPC nm = null;
            if (COD_NOMINACION_PROCESO_UPC.HasValue)
            {
                nm = model.NOMINACION_PROCESO_UPC.Find(COD_NOMINACION_PROCESO_UPC);
            }
            else
            {
                nm = new NOMINACION_PROCESO_UPC();
                model.NOMINACION_PROCESO_UPC.Add(nm);
                nm.COD_ESTADO_NOMINACION_UPC = 2;
            }

            nm.COD_PROCESO = COD_PROCESO;
            nm.FECHA_NOMINACION = FECHA_NOMINACION;
            nm.COD_REGISTRO = COD_REGISTRO;
            nm.CARTA_PRESENTACION = CARTA_PRESENTACION;
            nm.NOMBRE_TECNOLOGIA = NOMBRE_TECNOLOGIA;
            nm.NOMBRE_COMERCIAL = NOMBRE_COMERCIAL;
            nm.INDICACION_USO = INDICACION_USO;
            nm.JUSTIFICACION = JUSTIFICACION;
            nm.CIE10 = _CIE10;
            nm.CIE102 = CIE102;
            nm.CIE103 = CIE103;
            nm.ES_MEDICAMENTO = ES_MEDICAMENTO;
            nm.ES_PROCEDIMIENTO = ES_PROCEDIMIENTO;
            nm.ES_DISPOSITIVO = ES_DISPOSITIVO;
            nm.ES_OTRO = ES_OTRO;
            nm.ES_TITULAR_REGISTRO_TSN = ES_TITULAR_REGISTRO_TSN;
            nm.OBS_TITULAR_REGISTRO_TSN = OBS_TITULAR_REGISTRO_TSN;
            nm.ES_FABRICANTE_TSN = ES_FABRICANTE_TSN;
            nm.OBS_FABRICANTE_TSN = OBS_FABRICANTE_TSN;
            nm.ES_IMPORTADOR_TSN = ES_IMPORTADOR_TSN;
            nm.OBS_IMPORTADOR = OBS_IMPORTADOR;
            nm.ES_ACONDICIONADOR_TSN = ES_ACONDICIONADOR_TSN;
            nm.OBS_ACONDICIONDOR_TSN = OBS_ACONDICIONDOR_TSN;
            nm.ES_PRESTADOR_TSN = ES_PRESTADOR_TSN;
            nm.OBS_PRESTADOR_TSN = OBS_PRESTADOR_TSN;
            nm.ES_USUARIO_TSN = ES_USUARIO_TSN;
            nm.OBS_USUARIO_TSN = OBS_USUARIO_TSN;
            nm.ES_OTRO_TSN = ES_OTRO_TSN;
            nm.OBS_OTRO_TSN = OBS_OTRO_TSN;
            nm.PRINCIPIO_ACTIVO = PRINCIPIO_ACTIVO;
            nm.CODIGO_ATC = CODIGO_ATC;
            nm.FORMA_FARMACEUTICA = FORMA_FARMACEUTICA;
            nm.CONCENTRACION = CONCENTRACION;
            nm.VIA_ADMINSITRACION = VIA_ADMINSITRACION;
            nm.OTRAS_INDICACIONES_MEDICAMENTO = OTRAS_INDICACIONES_MEDICAMENTO;
            nm.REGISTRO_SANITARIO = REGISTRO_SANITARIO;
            nm.OBSERVACIONES_MEDICAMENTO = OBSERVACIONES_MEDICAMENTO;
            nm.CODIGO_CUPS = CODIGO_CUPS;
            nm.INDICACION_PROCEDIMIENTO = INDICACION_PROCEDIMIENTO;
            nm.COD_TIPO_PROCEDIMIENTO_UPC = COD_TIPO_PROCEDIMIENTO_UPC;
            nm.OBSERVACIONES_PROCEDIMIENTO = OBSERVACIONES_PROCEDIMIENTO;
            nm.REGISTRO_SANITARIO_DISPOSITIVO = REGISTRO_SANITARIO_DISPOSITIVO;
            nm.COD_TIPO_DISPOSITIVO = COD_TIPO_DISPOSITIVO;
            nm.COD_CLASIFICACION_RIESGO = COD_CLASIFICACION_RIESGO;
            nm.INDICACIONES_DISPOSITIVO = INDICACIONES_DISPOSITIVO;
            nm.OBSERVACIONES_DISPOSITIVO = OBSERVACIONES_DISPOSITIVO;
            nm.ES_PRIMERA = ES_PRIMERA;
            nm.OBS_ES_PRIMERA = OBS_ES_PRIMERA;
            nm.ES_SEGUNDA = ES_SEGUNDA;
            nm.OBS_ES_SEGUNDA = OBS_ES_SEGUNDA;
            nm.ES_TERCERA = ES_TERCERA;
            nm.OBS_ES_TERCERA = OBS_ES_TERCERA;
            nm.ES_COTIDIANO = ES_COTIDIANO;
            nm.OBS_ES_COTIDIANO = OBS_ES_COTIDIANO;
            nm.ES_OTRA_IMPORTANCIA = ES_OTRA_IMPORTANCIA;
            nm.OBS_OTRA_IMPORTANCIA = OBS_OTRA_IMPORTANCIA;
            nm.ES_O1_MUJER = ES_O1_MUJER;
            nm.ES_O1_HOMBRE = ES_O1_HOMBRE;
            nm.OBS_ES_01 = OBS_ES_01;
            nm.ES_1_4MUJER = ES_1_4MUJER;
            nm.ES_1_4HOMBRE = ES_1_4HOMBRE;
            nm.OBS_ES_1_4 = OBS_ES_1_4;
            nm.ES_5_14_MUJER = ES_5_14_MUJER;
            nm.ES_5_14_HOMBRE = ES_5_14_HOMBRE;
            nm.ES_5_14_OBS = ES_5_14_OBS;
            nm.ES_15_18_MUJER = ES_15_18_MUJER;
            nm.ES_15_18_HOMBRE = ES_15_18_HOMBRE;
            nm.ES_15_18_OBS = ES_15_18_OBS;
            nm.ES_19_29_MUJER = ES_19_29_MUJER;
            nm.ES_19_29_HOMBRE = ES_19_29_HOMBRE;
            nm.ES_19_29_OBS = ES_19_29_OBS;
            nm.ES_30_44_MUJER = ES_30_44_MUJER;
            nm.ES_30_44_HOMBRE = ES_30_44_HOMBRE;
            nm.ES_30_44_OBS = ES_30_44_OBS;
            nm.ES_45_59_MUJER = ES_45_59_MUJER;
            nm.ES_45_59_HOMBRE = ES_45_59_HOMBRE;
            nm.ES_45_59_OBS = ES_45_59_OBS;
            nm.ES_60_69_MUJER = ES_60_69_MUJER;
            nm.ES_60_69_HOMBRE = ES_60_69_HOMBRE;
            nm.ES_60_69_OBS = ES_60_69_OBS;
            nm.ES_70_79_MUJER = ES_70_79_MUJER;
            nm.ES_70_79_HOMBRE = ES_70_79_HOMBRE;
            nm.ES_70_79_OBS = ES_70_79_OBS;
            nm.ES_80_100_MUJER = ES_80_100_MUJER;
            nm.ES_80_100_HOMBRE = ES_80_100_HOMBRE;
            nm.ES_80_100_OBS = ES_80_100_OBS;
            nm.ES_PROMOCION_SALUD = ES_PROMOCION_SALUD;
            nm.OBS_ES_PROMOCION_SALUD = OBS_ES_PROMOCION_SALUD;
            nm.ES_PREVENCION_ENFERMEDAD = ES_PREVENCION_ENFERMEDAD;
            nm.OBS_ES_PREVENCION_ENFERMEDAD = OBS_ES_PREVENCION_ENFERMEDAD;
            nm.ES_DIAGNOSTICO = ES_DIAGNOSTICO;
            nm.OBS_ES_DIAGNOSTICO = OBS_ES_DIAGNOSTICO;
            nm.ES_TRATAMIENTO = ES_TRATAMIENTO;
            nm.OBS_ES_TRATAMIENTO = OBS_ES_TRATAMIENTO;
            nm.ES_REHABILITACION = ES_REHABILITACION;
            nm.OBS_ES_REHABILITACION = OBS_ES_REHABILITACION;
            nm.ES_PALIACION = ES_PALIACION;
            nm.OBS_ES_PALIACION = OBS_ES_PALIACION;
            nm.ES_COSMETICO = ES_COSMETICO;
            nm.OBS_ES_COSEMTICO = OBS_ES_COSEMTICO;
            nm.COD_AMBITO_UPC = COD_AMBITO_UPC;
            nm.ES_REDUCCION_MORTALIDAD = ES_REDUCCION_MORTALIDAD;
            nm.OBS_ES_REDUCCION_MORTALIDAD = OBS_ES_REDUCCION_MORTALIDAD;
            nm.ES_REDUCCION_MORBILIDAD = ES_REDUCCION_MORBILIDAD;
            nm.OBS_ES_REDUCCION_MORBILIDAD = OBS_ES_REDUCCION_MORBILIDAD;
            nm.ES_DISMINUCION_INSTANCIA = ES_DISMINUCION_INSTANCIA;
            nm.OBS_ES_DISMINUCION_INSTANCIA = OBS_ES_DISMINUCION_INSTANCIA;
            nm.ES_MEJORA_CALIDAD_VIDA = ES_MEJORA_CALIDAD_VIDA;
            nm.OBS_ES_MEJORA_CALIDAD_VIDA = OBS_ES_MEJORA_CALIDAD_VIDA;
            nm.ES_OTRO_USO_TENOCLOGIA = ES_OTRO_USO_TENOCLOGIA;
            nm.OBS_ES_OTRO_USO_TECNOLOGIA = OBS_ES_OTRO_USO_TECNOLOGIA;
            nm.TIENE_EFECTIVIDAD = TIENE_EFECTIVIDAD;
            nm.ARCHIVO_EFECTIVIDAD = ARCHIVO_EFECTIVIDAD;
            nm.TIENE_SEGURIDAD = TIENE_SEGURIDAD;
            nm.ARCHIVO_SEGURIDAD = ARCHIVO_SEGURIDAD;
            nm.TIENE_EFICACIA = TIENE_EFICACIA;
            nm.ARCHIVO_EFICACIA = ARCHIVO_EFICACIA;
            nm.OTRA_EVIDENCIA = OTRA_EVIDENCIA;
            nm.OBS_OTRA_EVIDENCIA = OBS_OTRA_EVIDENCIA;
            nm.ES_EXTERIOR = ES_EXTERIOR;
            nm.OBS_ES_EXTERIOR = OBS_ES_EXTERIOR;
            nm.NOMBRE_GPC = NOMBRE_GPC;
            nm.RECOMENDACION_GPC = RECOMENDACION_GPC;
            nm.PRIMERA_INFANCIA = PRIMERA_INFANCIA;
            nm.OBS_PRIMERA_INFANACIA = OBS_PRIMERA_INFANACIA;
            nm.EMBARAZO = EMBARAZO;
            nm.OBS_EMBARAZO = OBS_EMBARAZO;
            nm.DESPLAZADOS = DESPLAZADOS;
            nm.OBS_DESPLAZADOS = OBS_DESPLAZADOS;
            nm.VICTIMAS_ARMADAS = VICTIMAS_ARMADAS;
            nm.OBS_VICTIMAS_ARMADAS = OBS_VICTIMAS_ARMADAS;
            nm.ADULTOS_MAYORES = ADULTOS_MAYORES;
            nm.OBS_ADULTOS_MAYORES = OBS_ADULTOS_MAYORES;
            nm.DISCAPACIDAD = DISCAPACIDAD;
            nm.OBS_DISCAPACIDAD = OBS_DISCAPACIDAD;
            nm.ENF_HUERFANADAS = ENF_HUERFANADAS;
            nm.OBS_ENF_HUERFANAS = OBS_ENF_HUERFANAS;
            nm.ES_SALUD_PUBLICA = ES_SALUD_PUBLICA;
            nm.OBS_SALUD_PUBLICA = OBS_SALUD_PUBLICA;
            nm.ES_RECURSO_MEDICAMENTO = ES_RECURSO_MEDICAMENTO;
            nm.OBS_ES_RECURSO_MEDICAMENTO = OBS_ES_RECURSO_MEDICAMENTO;
            nm.ES_RECURSO_DISPOSITIVO = ES_RECURSO_DISPOSITIVO;
            nm.OBS_ES_RECURSO_DISPOSITIVO = OBS_ES_RECURSO_DISPOSITIVO;
            nm.ES_RECURSO_INVITRO = ES_RECURSO_INVITRO;
            nm.OBS_ES_RECURSO_INVITRO = OBS_ES_RECURSO_INVITRO;
            nm.ES_AGENTE_BIOLOGICO = ES_AGENTE_BIOLOGICO;
            nm.OBS_ES_AGENTE_BIOLOGICO = OBS_ES_AGENTE_BIOLOGICO;
            nm.ES_PRODCUTO_BIOLOGICO = ES_PRODCUTO_BIOLOGICO;
            nm.OBS_ES_PRODCUTO_BIOLOGICO = OBS_ES_PRODCUTO_BIOLOGICO;
            nm.ES_OTRO_RECURSO_ADICIONAL = ES_OTRO_RECURSO_ADICIONAL;
            nm.OBS_ES_OTRO_RECURSO_ADICIONAL = OBS_ES_OTRO_RECURSO_ADICIONAL;
            nm.NOMBRE_COMPARADOR = NOMBRE_COMPARADOR;
            nm.CODIGO_ATC_COMPARADOR = CODIGO_ATC_COMPARADOR;
            nm.COBERTURA = COBERTURA;
            nm.ADJUNTA_EVIDENCIA = ADJUNTA_EVIDENCIA;
            nm.OBS_EVIDENCIA = OBS_EVIDENCIA;
            nm.ARCHIVO_EVIDENCIA = ARCHIVO_EVIDENCIA;
            nm.CONFLICTO_SI = CONFLICTO_SI;
            nm.OBS_CONFLICTO = OBS_CONFLICTO;
            nm.URL_FORMATO3 = URL_FORMATO3;
            nm.ULR_FORMATO4 = ULR_FORMATO4;
            nm.URL_FORMATO5 = URL_FORMATO5;
            model.SaveChanges();

            return nm.COD_NOMINACION_PROCESO_UPC;
        }


        public int guardarNominacionRups(
            int? COD_NOMINACION_PROCESO_RUPS, int COD_PROCESO, int COD_REGISTRO, DateTime FECHA_REGISTRO, //string NOMBRE_PROCEDIMIENTO,
            int COD_TIPO_PROCEDIMIENTO, int COD_AMBITO_PROCEDIMIENTO, string DESCRIPCION, string CIE10, string CIE102, string CIE103,
            bool ES_PROMOCION_SALUD, bool ES_PREVENCION_ENFERMEDAD, bool ES_DIAGNOSTICO, bool ES_TRATAMIENTO, bool ES_REHABILITACION,
            bool ES_PALIACION, bool ES_COSMETICO, string CUPS_MODIFICAR1, string CUPS_MODIFICAR2, string CUPS_MODIFICAR3,
            string ESTRUCTURA_CUPS, string CODIGOCUPS1, string CODIGOCUPS2, string CODIGOCUPS3, string CALIFICACION_AJUSTE, string CODIGO_PROPUESTO,


            string DESCRIPCION_PROPUESTO, string JUSTIFICACION, bool SE_REALIZA_ACTUALMENTE_COLOMBIA, bool ES_REDUCCION_MORTALIDAD,
            string DESCCRIPCION_REDUCCION_MORTALIDAD, bool ES_REDUCCION_MORBILIDAD, string DESCRIPCION_REDUCCION_MORBILIDAD,
            bool ES_REDUCCION_DISCAPCIDAD, string DESCRIPCION_REDUCCION_DISCAPACIDAD, bool ES_REDUCCION_INSTANCIA, string DESCRIPCION_REDUCCION_INSTANCIA,
            bool ES_DISMINUCION_COMPLICACION, string DESCRIPCION_DISMINUCION_COMPLICACION, bool ES_MEJORA_VIDA, string DESCRIPCION_MEJORA_VIDA,
            bool ES_OTRO, string DESCRIPCION_OTRO, bool CUENTA_ESTUDIOS_EFECTIVIDAD, string ARCHIVO_EFECTIVIDAD, bool CUENTA_ESTUDIOS_SEGURIDAD,
            string ARCHIVO_SEGURIDAD, bool TIENE_EFECTOS_ADVERSOS, string DESCRIPCION_EFECTOS_ADVERSOS, bool ES__INTERES_SALUD,
            string DESCRIPCION_INTERES_SALUD, string NOMBRE_GPC, string RECOMENDACION_GPC, bool ADJUNTA_ADICIONAL, string OBSERVACIONES_ADICIONAL,
            string ARCHIVO_ADICIONAL,
            bool RECURSO_ADICIONAL_MEDICAMENTO, string NOMBRE_RECURSO_MEDICAMENTO, string ESTADO_RECURSO_MEDICAMENTO, string REGISTRO_INVIMA_RECURSO_MEDICAMENTO,
            bool RECURSO_ADICIONAL_DISPOSITIVO, string NOMBRE_RECURSO_DISPOSITIVO, string ESTADO_RECURSO_DISPOSITIVO, string REGISTRO_INVIMA_DISPOSITIVO,
            bool RECURSO_ADICIONAL_INVITRO, string NOMBRE_RECURSO_ADICIONAL_INVITRO, string ESTADO_RECURSO_ADICIONAL_INVITRO, string REGISTRO_INVIMA_INVITRO,
            bool RECURSO_ADICIONAL_AGEBIOLOGICO, string NOMBRE_RECURSO_ADICIONAL_AGEBIOLOGICO, string ESTADO_RECURSO_ADICIONAL_AGEBIOLOGICO,
            string REGISTRO_INVIMA_AGEBIOLOGICO, bool RECURSO_ADICIONAL_BIOLOGICO, string NOMBRE_RECURSO_ADICIONAL_BIOLOGICO, string ESTADO_RECURSO_ADICIONAL_BIOLOGICO,
            string REGISTRO_INVIMA_BIOLOGICO, bool RECURSO_ADICIONAL_OTRO, string NOMBRE_RECURSO_ADICIONAL_OTRO, bool VULNERABLE_INFANCIA, string OBS_VULNERABLE_INFANCIA,
            bool VULNERABLE_EMBARAZO, string OBS_VULNERABLE_EMBARAZO, bool VULNERABLE_DESPLAZADOS, string OBS_VULNERABLE_DESPLAZADOS, bool VULNERABLE_ARMADO,
            string OBS_VULNERABLE_ARMADO, bool VULNERABLE_ADULTOS, string OBS_VULNERABLE_ADULTOS, bool VULNERABLE_DISCAPACIDAD, string OBS_VULNERABLE_DISPACAIDAD,
            bool VULNERABLE_HUERFANOS, string OBS_VULNERABLE_HUERFANOS, bool CONFLICTO_INTERES, string OBS_CONFLICTO_INTERES,
            bool AVALA, string OBS_AVALA, int? COD_TIPO_JURIDICO_PROPONENTE, bool PROPONENTE_NATURAL, bool PROPONENTE_JURIDICO,
            string NOMBRE_PROPONENTE, string DOCUMENTO_PROPONENTE, bool es_nombre_propio, int VIGENCIA
)
        {
            NOMINACION_PROCESO_RUPS nm = null;
            if (COD_NOMINACION_PROCESO_RUPS.HasValue)
            {
                nm = model.NOMINACION_PROCESO_RUPS.Find(COD_NOMINACION_PROCESO_RUPS);
            }
            else
            {
                nm = new NOMINACION_PROCESO_RUPS();
                model.NOMINACION_PROCESO_RUPS.Add(nm);
                nm.COD_ESTADO_NOMINACION_RUPS = 2;
            }

            nm.ES_NOMBRE_PROPIO = es_nombre_propio;
            nm.COD_PROCESO = COD_PROCESO;
            nm.COD_REGISTRO = COD_REGISTRO;
            nm.FECHA_REGISTRO = FECHA_REGISTRO;
            //nm.NOMBRE_PROCEDIMIENTO = NOMBRE_PROCEDIMIENTO;
            nm.COD_TIPO_PROCEDIMIENTO = COD_TIPO_PROCEDIMIENTO;
            nm.COD_AMBITO_PROCEDIMIENTO = COD_AMBITO_PROCEDIMIENTO;
            nm.DESCRIPCION = DESCRIPCION;
            nm.CIE10 = CIE10;
            nm.CIE102 = CIE102;
            nm.CIE103 = CIE103;
            nm.ES_PROMOCION_SALUD = ES_PROMOCION_SALUD;
            nm.ES_PREVENCION_ENFERMEDAD = ES_PREVENCION_ENFERMEDAD;
            nm.ES_DIAGNOSTICO = ES_DIAGNOSTICO;
            nm.ES_TRATAMIENTO = ES_TRATAMIENTO;
            nm.ES_REHABILITACION = ES_REHABILITACION;
            nm.ES_PALIACION = ES_PALIACION;
            nm.ES_COSMETICO = ES_COSMETICO;
            nm.CUPS_MODIFICAR1 = CUPS_MODIFICAR1;
            nm.CUPS_MODIFICAR2 = CUPS_MODIFICAR2;
            nm.CUPS_MODIFICAR3 = CUPS_MODIFICAR3;
            nm.ESTRUCTURA_CUPS = ESTRUCTURA_CUPS;
            nm.CODIGOCUPS1 = CODIGOCUPS1;
            nm.CODIGOCUPS2 = CODIGOCUPS2;
            nm.CODIGOCUPS3 = CODIGOCUPS3;
            nm.CALIFICACION_AJUSTE = CALIFICACION_AJUSTE;
            nm.CODIGO_PROPUESTO = CODIGO_PROPUESTO;
            nm.DESCRIPCION_PROPUESTO = DESCRIPCION_PROPUESTO;
            nm.JUSTIFICACION = JUSTIFICACION;
            nm.SE_REALIZA_ACTUALMENTE_COLOMBIA = SE_REALIZA_ACTUALMENTE_COLOMBIA;
            nm.ES_REDUCCION_MORTALIDAD = ES_REDUCCION_MORTALIDAD;
            nm.DESCCRIPCION_REDUCCION_MORTALIDAD = DESCCRIPCION_REDUCCION_MORTALIDAD;
            nm.ES_REDUCCION_MORBILIDAD = ES_REDUCCION_MORBILIDAD;
            nm.DESCRIPCION_REDUCCION_MORBILIDAD = DESCRIPCION_REDUCCION_MORBILIDAD;
            nm.ES_REDUCCION_DISCAPCIDAD = ES_REDUCCION_DISCAPCIDAD;
            nm.DESCRIPCION_REDUCCION_DISCAPACIDAD = DESCRIPCION_REDUCCION_DISCAPACIDAD;
            nm.ES_REDUCCION_INSTANCIA = ES_REDUCCION_INSTANCIA;
            nm.DESCRIPCION_REDUCCION_INSTANCIA = DESCRIPCION_REDUCCION_INSTANCIA;
            nm.ES_DISMINUCION_COMPLICACION = ES_DISMINUCION_COMPLICACION;
            nm.DESCRIPCION_DISMINUCION_COMPLICACION = DESCRIPCION_DISMINUCION_COMPLICACION;
            nm.ES_MEJORA_VIDA = ES_MEJORA_VIDA;
            nm.DESCRIPCION_MEJORA_VIDA = DESCRIPCION_MEJORA_VIDA;
            nm.ES_OTRO = ES_OTRO;
            nm.DESCRIPCION_OTRO = DESCRIPCION_OTRO;
            nm.CUENTA_ESTUDIOS_EFECTIVIDAD = CUENTA_ESTUDIOS_EFECTIVIDAD;
            nm.ARCHIVO_EFECTIVIDAD = ARCHIVO_EFECTIVIDAD;
            nm.CUENTA_ESTUDIOS_SEGURIDAD = CUENTA_ESTUDIOS_SEGURIDAD;
            nm.ARCHIVO_SEGURIDAD = ARCHIVO_SEGURIDAD;
            nm.TIENE_EFECTOS_ADVERSOS = TIENE_EFECTOS_ADVERSOS;
            nm.DESCRIPCION_EFECTOS_ADVERSOS = DESCRIPCION_EFECTOS_ADVERSOS;
            nm.ES__INTERES_SALUD = ES__INTERES_SALUD;
            nm.DESCRIPCION_INTERES_SALUD = DESCRIPCION_INTERES_SALUD;
            nm.NOMBRE_GPC = NOMBRE_GPC;
            nm.RECOMENDACION_GPC = RECOMENDACION_GPC;
            nm.ADJUNTA_ADICIONAL = ADJUNTA_ADICIONAL;
            nm.OBSERVACIONES_ADICIONAL = OBSERVACIONES_ADICIONAL;
            nm.ARCHIVO_ADICIONAL = ARCHIVO_ADICIONAL;
            nm.RECURSO_ADICIONAL_MEDICAMENTO = RECURSO_ADICIONAL_MEDICAMENTO;
            nm.NOMBRE_RECURSO_MEDICAMENTO = NOMBRE_RECURSO_MEDICAMENTO;
            nm.ESTADO_RECURSO_MEDICAMENTO = ESTADO_RECURSO_MEDICAMENTO;
            nm.REGISTRO_INVIMA_RECURSO_MEDICAMENTO = REGISTRO_INVIMA_RECURSO_MEDICAMENTO;
            nm.RECURSO_ADICIONAL_DISPOSITIVO = RECURSO_ADICIONAL_DISPOSITIVO;
            nm.NOMBRE_RECURSO_DISPOSITIVO = NOMBRE_RECURSO_DISPOSITIVO;
            nm.ESTADO_RECURSO_DISPOSITIVO = ESTADO_RECURSO_DISPOSITIVO;
            nm.REGISTRO_INVIMA_DISPOSITIVO = REGISTRO_INVIMA_DISPOSITIVO;
            nm.RECURSO_ADICIONAL_INVITRO = RECURSO_ADICIONAL_INVITRO;
            nm.NOMBRE_RECURSO_ADICIONAL_INVITRO = NOMBRE_RECURSO_ADICIONAL_INVITRO;
            nm.ESTADO_RECURSO_ADICIONAL_INVITRO = ESTADO_RECURSO_ADICIONAL_INVITRO;
            nm.REGISTRO_INVIMA_INVITRO = REGISTRO_INVIMA_INVITRO;
            nm.RECURSO_ADICIONAL_AGEBIOLOGICO = RECURSO_ADICIONAL_AGEBIOLOGICO;
            nm.NOMBRE_RECURSO_ADICIONAL_AGEBIOLOGICO = NOMBRE_RECURSO_ADICIONAL_AGEBIOLOGICO;
            nm.ESTADO_RECURSO_ADICIONAL_AGEBIOLOGICO = ESTADO_RECURSO_ADICIONAL_AGEBIOLOGICO;
            nm.REGISTRO_INVIMA_AGEBIOLOGICO = REGISTRO_INVIMA_AGEBIOLOGICO;
            nm.RECURSO_ADICIONAL_BIOLOGICO = RECURSO_ADICIONAL_BIOLOGICO;
            nm.NOMBRE_RECURSO_ADICIONAL_BIOLOGICO = NOMBRE_RECURSO_ADICIONAL_BIOLOGICO;
            nm.ESTADO_RECURSO_ADICIONAL_BIOLOGICO = ESTADO_RECURSO_ADICIONAL_BIOLOGICO;
            nm.REGISTRO_INVIMA_BIOLOGICO = REGISTRO_INVIMA_BIOLOGICO;
            nm.RECURSO_ADICIONAL_OTRO = RECURSO_ADICIONAL_OTRO;
            nm.NOMBRE_RECURSO_ADICIONAL_OTRO = NOMBRE_RECURSO_ADICIONAL_OTRO;
            nm.VULNERABLE_INFANCIA = VULNERABLE_INFANCIA;
            nm.OBS_VULNERABLE_INFANCIA = OBS_VULNERABLE_INFANCIA;
            nm.VULNERABLE_EMBARAZO = VULNERABLE_EMBARAZO;
            nm.OBS_VULNERABLE_EMBARAZO = OBS_VULNERABLE_EMBARAZO;
            nm.VULNERABLE_DESPLAZADOS = VULNERABLE_DESPLAZADOS;
            nm.OBS_VULNERABLE_DESPLAZADOS = OBS_VULNERABLE_DESPLAZADOS;
            nm.VULNERABLE_ARMADO = VULNERABLE_ARMADO;
            nm.OBS_VULNERABLE_ARMADO = OBS_VULNERABLE_ARMADO;
            nm.VULNERABLE_ADULTOS = VULNERABLE_ADULTOS;
            nm.OBS_VULNERABLE_ADULTOS = OBS_VULNERABLE_ADULTOS;
            nm.VULNERABLE_DISCAPACIDAD = VULNERABLE_DISCAPACIDAD;
            nm.OBS_VULNERABLE_DISPACAIDAD = OBS_VULNERABLE_DISPACAIDAD;
            nm.VULNERABLE_HUERFANOS = VULNERABLE_HUERFANOS;
            nm.OBS_VULNERABLE_HUERFANOS = OBS_VULNERABLE_HUERFANOS;
            nm.CONFLICTO_INTERES = CONFLICTO_INTERES;
            nm.OBS_CONFLICTO_INTERES = OBS_CONFLICTO_INTERES;
            nm.AVALA = AVALA;
            nm.OBS_AVALA = OBS_AVALA;
            nm.COD_TIPO_JURIDICO_PROPONENTE = COD_TIPO_JURIDICO_PROPONENTE;
            nm.PROPONENTE_NATURAL = PROPONENTE_NATURAL;
            nm.PROPONENTE_JURIDICO = PROPONENTE_JURIDICO;
            nm.NOMBRE_PROPONENTE = NOMBRE_PROPONENTE;
            nm.DOCUMENTO_PROPONENTE = DOCUMENTO_PROPONENTE;
            nm.VIGENCIA = VIGENCIA;
            model.SaveChanges();

            return nm.COD_NOMINACION_PROCESO_RUPS;
        }

        public int guardarNominacionRupsInclusion(
          int? COD_NOMINACION_PROCESO_RUPS,
          int COD_PROCESO,
          int COD_REGISTRO,
          DateTime FECHA_REGISTRO,
          int VIGENCIA,
          bool NOMBRE_PROPIO,
          bool TERECERO_NATURAL,
          bool TERCERO_JURIDICO,
          int? COD_TIPO_JURIDICO_PROPONENTE,
          string NOMBRE_NOMINADOR,
          string NIT_NOMINADOR,
          string CLASIFICACION_CUPS,
          bool EXPERIMENTACON,
          string ESTRUCTURA_CUPS,
          string CODIGO_PROPUESTO,
          string DESCRIPCION_PROPUESTO,
          string JUSTIFICACION,
          string DES_PROC_NUEVO,
          string DES_CRITERIO_NUEVO,
          bool ES_PROMOCION_SALUD,
          bool ES_PREVENCION_ENFERMEDAD,
          bool ES_DIAGNOSTICO,
          bool ES_TRATAMIENTO,
          bool ES_REHABILITACION,
          bool ES_PALIACION,
          bool ES_COSMETICO,
          int COD_TIPO_PROCEDIMIENTO,
          int COD_AMBITO_PROCEDIMIENTO,
          string CIE10,
          string CIE102,
          string CIE103,
          string DES_GRUPO_POBLACIONAL,
          int NUM_PACIENTES,
          bool REMPLAZA_PROCEDIMIENTO,
          string PROCEDIMIENTO_REMPLAZO,
          bool RIESGO,
          string DES_RIESGO,
          string DES_RESULTADOS,
          string DES_OTRAS_INTERVENCIONES,
          string DES_TECNOLOGIAS_EJECUCION,
          bool INVIMA1,
          string DES_INVIMA1,
          string NUM_INVIMA,
          string ESTADO_INVIMA1,
          bool INVIMA2,
          string DES_INVIMA2,
          string NUM_INVIMA2,
          string ESTADO_INVIMA2,
          bool INVIMA3,
          string DES_INVIMA3,
          string NUM_INVIMA3,
          string ESTADO_INVIMA3,
          bool CUENTA_ESTUDIOS_EFECTIVIDAD,
          string ARCHIVO_EFECTIVIDAD,
          bool CUENTA_ESTUDIOS_SEGURIDAD,
          string ARCHIVO_SEGURIDAD,
          bool IMPLEMENTACION_TERRITORIO,
          string DES_IMPLEMENTACION_TERRITORIO,
          bool REALIZACION_EN_TERRITORIO,
          string DES_REALIZACION_EN_TERRITORIO,
          string CUPS_REALIZACION_EN_TERRITORIO,
          string AÑO_REALIZACION_EN_TERRITORIO,
          bool OTRO_SISTEMA_CODIFICACION,
          string DES_OTRO_SISTEMA_CODIFICACION,
          bool ADJUNTA_ADICIONAL,
          string OBSERVACIONES_ADICIONAL,
          string ARCHIVO_ADICIONAL,
          bool CONFLICTO_INTERES,
          string OBS_CONFLICTO_INTERES,
          bool AVALA,
          string OBS_AVALA,
          string NOMBRE_GPC,
          string RECOMENDACION_GPC
        )
        {
            NOMINACION_PROCESO_RUPS nm = null;
            if (COD_NOMINACION_PROCESO_RUPS.HasValue)
            {
                nm = model.NOMINACION_PROCESO_RUPS.Find(COD_NOMINACION_PROCESO_RUPS);
            }
            else
            {
                nm = new NOMINACION_PROCESO_RUPS();
                model.NOMINACION_PROCESO_RUPS.Add(nm);
                nm.COD_ESTADO_NOMINACION_RUPS = 2;
            }


            nm.COD_PROCESO = COD_PROCESO;
            nm.COD_REGISTRO = COD_REGISTRO;
            nm.FECHA_REGISTRO = FECHA_REGISTRO;
            nm.VIGENCIA = VIGENCIA;
            nm.ES_NOMBRE_PROPIO = NOMBRE_PROPIO;
            nm.PROPONENTE_NATURAL = TERECERO_NATURAL;
            nm.PROPONENTE_JURIDICO = TERCERO_JURIDICO;
            nm.COD_TIPO_JURIDICO_PROPONENTE = COD_TIPO_JURIDICO_PROPONENTE;
            nm.NOMBRE_PROPONENTE = NOMBRE_NOMINADOR;
            nm.DOCUMENTO_PROPONENTE = NIT_NOMINADOR;
            nm.CALIFICACION_AJUSTE = CLASIFICACION_CUPS;
            nm.FASE_EXPERIMENTACION = EXPERIMENTACON;
            nm.ESTRUCTURA_CUPS = ESTRUCTURA_CUPS;
            nm.CODIGO_PROPUESTO = CODIGO_PROPUESTO;
            nm.DESCRIPCION_PROPUESTO = DESCRIPCION_PROPUESTO;
            nm.JUSTIFICACION = JUSTIFICACION;
            nm.DES_PROC_NUEVO = DES_PROC_NUEVO;
            nm.DES_CRITERIO_NUEVO = DES_CRITERIO_NUEVO;
            nm.ES_PROMOCION_SALUD = ES_PROMOCION_SALUD;
            nm.ES_PREVENCION_ENFERMEDAD = ES_PREVENCION_ENFERMEDAD;
            nm.ES_DIAGNOSTICO = ES_DIAGNOSTICO;
            nm.ES_TRATAMIENTO = ES_TRATAMIENTO;
            nm.ES_REHABILITACION = ES_REHABILITACION;
            nm.ES_PALIACION = ES_PALIACION;
            nm.ES_COSMETICO = ES_COSMETICO;
            nm.COD_TIPO_PROCEDIMIENTO = COD_TIPO_PROCEDIMIENTO;
            nm.COD_AMBITO_PROCEDIMIENTO = COD_AMBITO_PROCEDIMIENTO;
            nm.CIE10 = CIE10;
            nm.CIE102 = CIE102;
            nm.CIE103 = CIE103;
            nm.DES_GRUPO_POBLACIONAL = DES_GRUPO_POBLACIONAL;
            nm.NUM_PACIENTES = NUM_PACIENTES;
            nm.REMPLAZA_PROCEDIMIENTO = REMPLAZA_PROCEDIMIENTO;
            nm.PROCEDIMIENTO_REMPLAZO = PROCEDIMIENTO_REMPLAZO;
            nm.RIESGO = RIESGO;
            nm.DES_RIESGO = DES_RIESGO;
            nm.DES_RESULTADOS = DES_RESULTADOS;
            nm.DES_OTRAS_INTERVENCIONES = DES_OTRAS_INTERVENCIONES;
            nm.DES_TECNOLOGIAS_EJECUCION = DES_TECNOLOGIAS_EJECUCION;
            nm.INVIMA1 = INVIMA1;
            nm.DES_INVIMA1 = DES_INVIMA1;
            nm.NUM_INVIMA = NUM_INVIMA;
            nm.ESTADO_INVIMA1 = ESTADO_INVIMA1;
            nm.INVIMA2 = INVIMA2;
            nm.DES_INVIMA2 = NUM_INVIMA2;
            nm.ESTADO_INVIMA2 = ESTADO_INVIMA2;
            nm.INVIMA3 = INVIMA3;
            nm.DES_INVIMA3 = DES_INVIMA3;
            nm.NUM_INVIMA3 = NUM_INVIMA3;
            nm.ESTADO_INVIMA3 = ESTADO_INVIMA3;
            nm.CUENTA_ESTUDIOS_EFECTIVIDAD = CUENTA_ESTUDIOS_EFECTIVIDAD;
            nm.ARCHIVO_EFECTIVIDAD = ARCHIVO_EFECTIVIDAD;
            nm.CUENTA_ESTUDIOS_SEGURIDAD = CUENTA_ESTUDIOS_SEGURIDAD;
            nm.ARCHIVO_SEGURIDAD = ARCHIVO_SEGURIDAD;
            nm.IMPLEMENTACION_TERRITORIO = IMPLEMENTACION_TERRITORIO;
            nm.DES_IMPLEMENTACION_TERRITORIO = DES_IMPLEMENTACION_TERRITORIO;
            nm.REALIZACION_EN_TERRITORIO = REALIZACION_EN_TERRITORIO;
            nm.DES_REALIZACION_EN_TERRITORIO = DES_REALIZACION_EN_TERRITORIO;
            nm.CUPS_REALIZACION_EN_TERRITORIO = CUPS_REALIZACION_EN_TERRITORIO;
            nm.YEAR_REALIZACION_EN_TERRITORIO = AÑO_REALIZACION_EN_TERRITORIO;
            nm.OTRO_SISTEMA_CODIFICACION = OTRO_SISTEMA_CODIFICACION;
            nm.DES_OTRO_SISTEMA_CODIFICACION = DES_OTRO_SISTEMA_CODIFICACION;
            nm.ADJUNTA_ADICIONAL = ADJUNTA_ADICIONAL;
            nm.OBSERVACIONES_ADICIONAL = OBSERVACIONES_ADICIONAL;
            nm.ARCHIVO_ADICIONAL = ARCHIVO_ADICIONAL;
            nm.CONFLICTO_INTERES = CONFLICTO_INTERES;
            nm.OBS_CONFLICTO_INTERES = OBS_CONFLICTO_INTERES;
            nm.AVALA = AVALA;
            nm.OBS_AVALA = OBS_AVALA;
            nm.NOMBRE_GPC = NOMBRE_GPC;
            nm.RECOMENDACION_GPC = RECOMENDACION_GPC;



            model.SaveChanges();

            return nm.COD_NOMINACION_PROCESO_RUPS;
        }


        public int guardarNominacion(
            int? COD_NOMINACION_PROCESO, int COD_PROCESO, int vigencia, int COD_REGISTRO, bool ES_MEDICAMENTO, bool ES_PROCEDIMIENTO,
            bool ES_DISPOSITIVO_MEDICO, bool ES_OTRO, bool ES_SERVICIO_SALUD, string NOMBRE_TECNOLOGIA,
            string NOMBRE_ENFERMEDAD_CONDICION_SALUD, string OBSERVACION_TECNOLOGIA,

            bool CRITERIO_A, bool CRITERIO_B, bool CRITERIO_C, bool CRITERIO_D, bool CRITERIO_E, bool CRITERIO_F,
            string OBS_CRITERIO_A, string OBS_CRITERIO_B, string OBS_CRITERIO_C, string OBS_CRITERIO_D, string OBS_CRITERIO_E, string OBS_CRITERIO_F,
            bool? ADJUNTA_EVIDENCIA, string OBSERVACIONES_EVIDENCIA, string RUTA_EVIDENCIA,
            bool? CONFLICTO_INTERES, string OBSERVACIONES_CONFLICTO, List<ARCHIVOXNOMINACION> ARCHIVOS)
        {
            NOMINACION_PROCESO nm = null;

            if (COD_NOMINACION_PROCESO.HasValue)
            {
                nm = model.NOMINACION_PROCESO.Find(COD_NOMINACION_PROCESO);
            }
            else
            {
                nm = new NOMINACION_PROCESO();
                model.NOMINACION_PROCESO.Add(nm);
                nm.COD_ESTADO_NOMINACION = 1;
            }
            for (int K = 0; K < ARCHIVOS.Count; K++)
            {
                if (nm.ARCHIVOXNOMINACION.Where(X => X.URL_ARCHIVO == ARCHIVOS[K].URL_ARCHIVO).Count() <= 0)
                {
                    ARCHIVOXNOMINACION AR = new ARCHIVOXNOMINACION();
                    AR.URL_ARCHIVO = ARCHIVOS[K].URL_ARCHIVO;
                    AR.DESCRIPCION_ARCHIVO = ARCHIVOS[K].DESCRIPCION_ARCHIVO;
                    nm.ARCHIVOXNOMINACION.Add(AR);
                }
                else
                {
                    var F = nm.ARCHIVOXNOMINACION.Where(X => X.URL_ARCHIVO == ARCHIVOS[K].URL_ARCHIVO).FirstOrDefault();
                    F.DESCRIPCION_ARCHIVO = ARCHIVOS[K].DESCRIPCION_ARCHIVO;
                }
            }
            //quitamos los que ya no van
            var ARREGLO = nm.ARCHIVOXNOMINACION.ToArray();
            for (int k = 0; k < ARREGLO.Length; k++)
            {
                if (ARCHIVOS.Where(X => X.URL_ARCHIVO == ARREGLO[k].URL_ARCHIVO).Count() <= 0)
                {
                    model.ARCHIVOXNOMINACION.Remove(model.ARCHIVOXNOMINACION.Find(ARREGLO[k].COD_ARCHIVOXNOMINACION));
                }
            }
            if (vigencia != 0)
            {
                nm.VIGENCIA = Convert.ToInt16(vigencia);
            }
            nm.COD_PROCESO = COD_PROCESO;
            nm.COD_REGISTRO = COD_REGISTRO;
            nm.ES_MEDICAMENTO = ES_MEDICAMENTO;
            nm.ES_PROCEDIMIENTO = ES_PROCEDIMIENTO;
            nm.ES_DISPOSITIVO_MEDICO = ES_DISPOSITIVO_MEDICO;
            nm.ES_OTRO = ES_OTRO;
            nm.ES_SERVICIO_SALUD = ES_SERVICIO_SALUD;
            nm.NOMBRE_TECNOLOGIA = NOMBRE_TECNOLOGIA;
            nm.NOMBRE_ENFERMEDAD_CONDICION_SALUD = NOMBRE_ENFERMEDAD_CONDICION_SALUD;
            nm.OBSERVACION_TECNOLOGIA = OBSERVACION_TECNOLOGIA;
            nm.CRITERIO_A = CRITERIO_A;
            nm.CRITERIO_B = CRITERIO_B;
            nm.CRITERIO_C = CRITERIO_C;
            nm.CRITERIO_D = CRITERIO_D;
            nm.CRITERIO_E = CRITERIO_E;
            nm.CRITERIO_F = CRITERIO_F;
            nm.OBS_CRITERIO_A = OBS_CRITERIO_A;
            nm.OBS_CRITERIO_B = OBS_CRITERIO_B;
            nm.OBS_CRITERIO_C = OBS_CRITERIO_C;
            nm.OBS_CRITERIO_D = OBS_CRITERIO_D;
            nm.OBS_CRITERIO_E = OBS_CRITERIO_E;
            nm.OBS_CRITERIO_F = OBS_CRITERIO_F;
            nm.ADJUNTA_EVIDENCIA = ADJUNTA_EVIDENCIA;
            nm.OBSERVACIONES_EVIDENCIA = OBSERVACIONES_EVIDENCIA;
            nm.RUTA_EVIDENCIA = RUTA_EVIDENCIA;
            nm.CONFLICTO_INTERES = CONFLICTO_INTERES;
            nm.OBSERVACIONES_CONFLICTO = OBSERVACIONES_CONFLICTO;
            model.SaveChanges();
            if (COD_NOMINACION_PROCESO.HasValue == false)
            {
                nm.ID_MANUAL = nm.COD_NOMINACION_PROCESO.ToString();
                model.SaveChanges();
            }
            return nm.COD_NOMINACION_PROCESO;
        }


        public int guardarNominacionHuerfana(
           int? COD_NOMINACION_PROCESO, int COD_PROCESO, int vigencia, int COD_REGISTRO,
           bool ES_INCLUIR, bool ES_EXCLUIR, bool ES_CAMBIO, bool ES_CODIGO, bool ES_PRUEBA, bool ES_DICIPLINA,
           int? consecutivo_ehf,
           string NOMBRE,
           string CIE_NOMINACION,
           string TIPO_CONFIRMACION,
           string ESPECIALIDAD,
           string ESPECIALIDAD2,
           string ESPECIALIDAD3,
           string ESPECIALIDAD4,
           string ESPECIALIDAD5,
           // string ESPECIALIDADES_PROPUESTAS,
           string CONFIRMATORIA_PROPUESTA,
           string CUPS_CONFIRMATORIA_PROPUESTA,
           string NUEVO_NOMBRE,
           string CIE_NUEVO_NOMBRE,
           string CODIGO_MODIFICAR,
           string CODIGO_NUEVO,
           string CONFIRMATORIA_ACTUAL,
           string CUPS_CONFIRMATORIA_ACTUAL,
           string CONFIRMATORIA_PROPUESTA_CAMBIO,
           string CUPS_CONFIRMATORIA_PROPUESTA_CAMBIO,
           string PRUEBA_ALTERNA,
           string CUPS_PRUEBA_ALTERNA,
           string ESP_ACTUAL,
           string ESP_ACTUAL2,
           string ESP_ACTUAL3,
           string ESP_ACTUAL4,
           string ESP_ACTUAL5,
           string ESP_PROPUESTA,
           string ESP_PROPUESTA2,
           string ESP_PROPUESTA3,
           string ESP_PROPUESTA4,
           string ESP_PROPUESTA5,
           //string ESPECIALIDADES_ACTUALES,
           //string ESPECIALIDADES_PROPUESTAS,
           string JUSTIFICACION,
           bool ADJUNTA_EVIDENCIA,
           string OBSERVACIONES_EVIDENCIA,
           string RUTA_EVIDENCIA,
           bool CONFLICTO_INTERES,
           string CONFLICTO,
           List<ARCHIVOXNOMINACION_HUERFANA> ARCHIVOS)
        {
            NOMINACION_HUERFANA nm = null;
            if (COD_NOMINACION_PROCESO.HasValue)
            {
                nm = model.NOMINACION_HUERFANA.Find(COD_NOMINACION_PROCESO);
            }
            else
            {
                nm = new NOMINACION_HUERFANA();
                model.NOMINACION_HUERFANA.Add(nm);
                nm.COD_ESTADO_NOMINACION = 1;
            }


            for (int K = 0; K < ARCHIVOS.Count; K++)
            {
                if (nm.ARCHIVOXNOMINACION_HUERFANA.Where(X => X.URL_ARCHIVO == ARCHIVOS[K].URL_ARCHIVO).Count() <= 0)
                {
                    ARCHIVOXNOMINACION_HUERFANA AR = new ARCHIVOXNOMINACION_HUERFANA();
                    AR.URL_ARCHIVO = ARCHIVOS[K].URL_ARCHIVO;
                    AR.DESCRIPCION_ARCHIVO = ARCHIVOS[K].DESCRIPCION_ARCHIVO;
                    nm.ARCHIVOXNOMINACION_HUERFANA.Add(AR);
                }
                else
                {
                    var F = nm.ARCHIVOXNOMINACION_HUERFANA.Where(X => X.URL_ARCHIVO == ARCHIVOS[K].URL_ARCHIVO).FirstOrDefault();
                    F.DESCRIPCION_ARCHIVO = ARCHIVOS[K].DESCRIPCION_ARCHIVO;
                }
            }
            //quitamos los que ya no van
            var ARREGLO = nm.ARCHIVOXNOMINACION_HUERFANA.ToArray();
            for (int k = 0; k < ARREGLO.Length; k++)
            {
                if (ARCHIVOS.Where(X => X.URL_ARCHIVO == ARREGLO[k].URL_ARCHIVO).Count() <= 0)
                {
                    model.ARCHIVOXNOMINACION_HUERFANA.Remove(model.ARCHIVOXNOMINACION_HUERFANA.Find(ARREGLO[k].COD_ARCHIVOXNOMINACION_HUERFANA));
                }
            }
            if (vigencia != 0)
            {
                nm.VIGENCIA = Convert.ToInt16(vigencia);
            }
            nm.COD_PROCESO = COD_PROCESO;
            nm.COD_REGISTRO = COD_REGISTRO;
            nm.ES_INCLUIR = ES_INCLUIR;
            nm.ES_EXCLUIR = ES_EXCLUIR;
            nm.ES_CAMBIO = ES_CAMBIO;
            nm.ES_CODIGO = ES_CODIGO;
            nm.ES_PRUEBA = ES_PRUEBA;
            nm.ES_DICIPLINA = ES_DICIPLINA;
            nm.CONSECUTIVO_LISTADO_EFH = consecutivo_ehf;
            nm.NOMBRE = NOMBRE;
            nm.CIE = CIE_NOMINACION;
            nm.TIPO_CONFIRMACION = TIPO_CONFIRMACION;
            nm.CONFIRMATORIA_PROPUESTA = CONFIRMATORIA_PROPUESTA;
            nm.CUPS_CONFIRMATORIA_PROPUESTA = CUPS_CONFIRMATORIA_PROPUESTA;
            nm.NUEVO_NOMBRE = NUEVO_NOMBRE;
            nm.CIE_NUEVO_NOMBRE = CIE_NUEVO_NOMBRE;
            nm.CODIGO_MODIFICAR = CODIGO_MODIFICAR;
            nm.CODIGO_NUEVO = CODIGO_NUEVO;
            nm.CONFIRMATORIA_ACTUAL = CONFIRMATORIA_ACTUAL;
            nm.CUPS_CONFIRMATORIA_ACTUAL = CUPS_CONFIRMATORIA_ACTUAL;
            nm.CONFIRMATORIA_CAMBIO_PROPUESTO = CONFIRMATORIA_PROPUESTA_CAMBIO;
            nm.CUPS_CONFIRMATORIA_CAMBIO_PROPUESTO = CUPS_CONFIRMATORIA_PROPUESTA_CAMBIO;
            nm.ALTERNA = PRUEBA_ALTERNA;
            nm.CUPS_ALTERNA = CUPS_PRUEBA_ALTERNA;
            //nm.ESPECIALIDAD_PROPUESTA = ESPECIALIDADES_PROPUESTAS;
            //nm.OTRAS_ESPECIALIDAD_PROPUESTAS = OTRAS_ESPECIALIDADES;
            //nm.ESPECIALIDADES_ACTUALES = ESPECIALIDADES_ACTUALES;
            nm.ESP_ACTUAL = ESP_ACTUAL;
            nm.ESP_ACTUAL2 = ESP_ACTUAL2;
            nm.ESP_ACTUAL3 = ESP_ACTUAL3;
            nm.ESP_ACTUAL4 = ESP_ACTUAL4;
            nm.ESP_ACTUAL5 = ESP_ACTUAL5;
            nm.ESP_PROPUESTA = ESP_PROPUESTA;
            nm.ESP_PROPUESTA2 = ESP_PROPUESTA2;
            nm.ESP_PROPUESTA3 = ESP_PROPUESTA3;
            nm.ESP_PROPUESTA4 = ESP_PROPUESTA4;
            nm.ESP_PROPUESTA5 = ESP_PROPUESTA5;
            nm.ESPECIALIDAD = ESPECIALIDAD;
            nm.ESPECIALIDAD2 = ESPECIALIDAD2;
            nm.ESPECIALIDAD3 = ESPECIALIDAD3;
            nm.ESPECIALIDAD4 = ESPECIALIDAD4;
            nm.ESPECIALIDAD5 = ESPECIALIDAD5;
            // nm.ESPECIALIDADES_PROPUESTAS_CAMBIO = ESPECIALIDADES_PROPUESTAS;
            nm.JUSTIFICACION = JUSTIFICACION;
            nm.ADJUNTA_EVIDENCIA = ADJUNTA_EVIDENCIA;
            nm.OBSERVACIONES_EVIDENCIA = OBSERVACIONES_EVIDENCIA;
            nm.CONFLICTO_INTERES = CONFLICTO_INTERES;
            nm.INTERES_CONFLICTO = CONFLICTO;
            nm.COD_ESTADO_NOMINACION = 2;
            nm.FECHA_NOMINACION = DateTime.Now;
            nm.RUTA_EVIDENCIA = RUTA_EVIDENCIA;

            model.SaveChanges();

            if (COD_NOMINACION_PROCESO.HasValue == false)
            {
                nm.ID_MANUAL = nm.COD_NOMINACION_HUERFANAS.ToString();
                model.SaveChanges();
            }
            return nm.COD_NOMINACION_HUERFANAS;
        }

        public int GuardarObjecionHuerfanas(OBJECION_HUERFANA objecion)
        {

            model.OBJECION_HUERFANA.Add(objecion);
            model.SaveChanges();

            return objecion.COD_OBJECION_HUERFANA;

        }

        public int GuardarArchivoObjecionHuerfanas(ARCHIVOXOBJECION_HUERFANA archivoObjecion)
        {
            model.ARCHIVOXOBJECION_HUERFANA.Add(archivoObjecion);
            model.SaveChanges();

            return archivoObjecion.COD_ARCHIVOXOBJECION_HUERFANA;
        }


        public int GuardarResultadoValidacionNominacion(int? COD_OBJECION_PROCESO, int COD_NOMINACION_PROCESO,
     DateTime FECHA_OBJECION, int OBJETADO_POR, string OBSERVACIONES_GENERALES,
     string OBS_NOMBRE_TECNOLOGIA, string OBS_CIE10, string OBS_CIE10_2, string OBS_INDICACION_CIE10,
     string OBS_MEDICAMENTO, string OBS_PROCEDIMIENTO, string OBS_DISPOSITIVO_MEDICO, string OBS_OTRO,
     string OBS_CREITERIO_A, string OBS_CREITERIO_B, string OBS_CREITERIO_C, string OBS_CREITERIO_D,
     string OBS_CREITERIO_E, string OBS_CREITERIO_F, string OBS_EVIDENCIA, string OBS_CONFLICTO_INTERES,
     string OBS_CONCEPTO
     , List<ARCHIVOXOBJECION> listaArchivos)
        {
            OBJECION_PROCESO p = null;
            if (COD_OBJECION_PROCESO.HasValue)
            {
                p = model.OBJECION_PROCESO.Find(COD_OBJECION_PROCESO.Value);
            }
            else
            {
                p = new OBJECION_PROCESO();
                p.FECHA_OBJECION = DateTime.Now;
                p.OBJETADO_POR = OBJETADO_POR;
                model.OBJECION_PROCESO.Add(p);
            }
            p.COD_NOMINACION_PROCESO = COD_NOMINACION_PROCESO;
            p.OBSERVACIONES_GENERALES = OBSERVACIONES_GENERALES;
            p.OBS_NOMBRE_TECNOLOGIA = OBS_NOMBRE_TECNOLOGIA;
            p.OBS_CIE10 = OBS_CIE10;
            p.OBS_CIE10_2 = OBS_CIE10_2;
            p.OBS_CONCEPTO = OBS_CONCEPTO;
            p.OBS_INDICACION_CIE10 = OBS_INDICACION_CIE10;
            p.OBS_MEDICAMENTO = OBS_MEDICAMENTO;
            p.OBS_PROCEDIMIENTO = OBS_PROCEDIMIENTO;
            p.OBS_DISPOSITIVO_MEDICO = OBS_DISPOSITIVO_MEDICO;
            p.OBS_OTRO = OBS_OTRO;
            p.OBS_CREITERIO_A = OBS_CREITERIO_A;
            p.OBS_CREITERIO_B = OBS_CREITERIO_B;
            p.OBS_CREITERIO_C = OBS_CREITERIO_C;
            p.OBS_CREITERIO_D = OBS_CREITERIO_D;
            p.OBS_CREITERIO_E = OBS_CREITERIO_E;
            p.OBS_CREITERIO_F = OBS_CREITERIO_F;
            p.OBS_EVIDENCIA = OBS_EVIDENCIA;
            p.OBS_CONFLICTO_INTERES = OBS_CONFLICTO_INTERES;
            p.VISIBLE = true;
            //zona de archivos
            for (int K = 0; listaArchivos != null && K < listaArchivos.Count; K++)
            {
                if (p.ARCHIVOXOBJECION.Where(X => X.URL_ARCHIVO == listaArchivos[K].URL_ARCHIVO).Count() <= 0)
                {
                    ARCHIVOXOBJECION AR = new ARCHIVOXOBJECION();
                    AR.URL_ARCHIVO = listaArchivos[K].URL_ARCHIVO;
                    AR.DESCRIPCION_ARCHIVO = listaArchivos[K].DESCRIPCION_ARCHIVO;
                    p.ARCHIVOXOBJECION.Add(AR);
                }
                else
                {
                    var F = p.ARCHIVOXOBJECION.Where(X => X.URL_ARCHIVO == listaArchivos[K].URL_ARCHIVO).FirstOrDefault();
                    F.DESCRIPCION_ARCHIVO = listaArchivos[K].DESCRIPCION_ARCHIVO;
                }
            }
            //quitamos los que ya no van
            var ARREGLO = p.ARCHIVOXOBJECION.ToArray();
            for (int k = 0; k < ARREGLO.Length; k++)
            {
                if (listaArchivos.Where(X => X.URL_ARCHIVO == ARREGLO[k].URL_ARCHIVO).Count() <= 0)
                {
                    model.ARCHIVOXOBJECION.Remove(model.ARCHIVOXOBJECION.Find(ARREGLO[k].COD_ARCHIVOXOBJECION));
                }
            }


            model.SaveChanges();
            return p.COD_OBJECION_PROCESO;
        }







        public void enviarNominacionExlcusiones(int COD_NOMINACION_PROCESO, int COD_ESTADO_NOMINACION)
        {
            NOMINACION_PROCESO nm = null;
            nm = model.NOMINACION_PROCESO.Find(COD_NOMINACION_PROCESO);
            if (nm != null)
            {
                nm.COD_ESTADO_NOMINACION = COD_ESTADO_NOMINACION;
                nm.FECHA_NOMINACION = DateTime.Now;
            }
            model.SaveChanges();
        }
        public void enviarNominacion(int COD_NOMINACION_PROCESO, int COD_ESTADO_NOMINACION)
        {
            NOMINACION_PROCESO_RUPS nm = null;
            nm = model.NOMINACION_PROCESO_RUPS.Find(COD_NOMINACION_PROCESO);
            if (nm != null)
            {
                nm.COD_ESTADO_NOMINACION_RUPS = COD_ESTADO_NOMINACION;
                nm.FECHA_REGISTRO = DateTime.Now;
            }
            model.SaveChanges();
        }

        public void enviarNominacionHuerfana(int COD_NOMINACION_HUERFANA, int COD_ESTADO_NOMINACION)
        {
            NOMINACION_HUERFANA nm = null;
            nm = model.NOMINACION_HUERFANA.Find(COD_NOMINACION_HUERFANA);
            if (nm != null)
            {
                nm.COD_ESTADO_NOMINACION = COD_ESTADO_NOMINACION;
                nm.FECHA_NOMINACION = DateTime.Now;
            }
            model.SaveChanges();
        }

        public void enviarNominacionUPC(int COD_NOMINACION_PROCESO, int COD_ESTADO_NOMINACION)
        {
            NOMINACION_PROCESO_UPC nm = null;
            nm = model.NOMINACION_PROCESO_UPC.Find(COD_NOMINACION_PROCESO);
            nm.COD_ESTADO_NOMINACION_UPC = COD_ESTADO_NOMINACION;
            nm.FECHA_NOMINACION = DateTime.Now;

            model.SaveChanges();
        }

        public int GuardarNominacionCriteriosExcluyentes(NOMINACION_CRITERIO_EXCLUYENTE nominacion, List<ARCHIVOXNOMINACIONXCRITERIO> ARCHIVOS)
        {
            model.NOMINACION_CRITERIO_EXCLUYENTE.Add(nominacion);
            model.SaveChanges();
            int cod_nominacion_excluyentes = nominacion.COD_NOMINACION_EXCLUYENTE;
            for (int K = 0; K < ARCHIVOS.Count; K++)
            {

                ARCHIVOXNOMINACIONXCRITERIO AR = new ARCHIVOXNOMINACIONXCRITERIO();
                AR.URL_ARCHIVO = ARCHIVOS[K].URL_ARCHIVO;
                AR.DESCRIPCION_ARCHIVO = ARCHIVOS[K].DESCRIPCION_ARCHIVO;
                AR.COD_NOMINACION_CRITERIO_EXCLUYENTE = cod_nominacion_excluyentes;
                model.ARCHIVOXNOMINACIONXCRITERIO.Add(AR);
                model.SaveChanges();
            }

            return cod_nominacion_excluyentes;
        }


        public void enviarNominacionCriteriosExcluyentes(int COD_NOMINACION_EXCLUYENTE, int COD_ESTADO_NOMINACION)
        {
            NOMINACION_CRITERIO_EXCLUYENTE nm = null;
            nm = model.NOMINACION_CRITERIO_EXCLUYENTE.Find(COD_NOMINACION_EXCLUYENTE);
            if (nm != null)
            {
                nm.COD_ESTADO_NOMINACION = COD_ESTADO_NOMINACION;
            }
            model.SaveChanges();
        }

    }
}
