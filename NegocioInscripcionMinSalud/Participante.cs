using DatosInscripcionMinSalud;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegocioInscripcionMinSalud
{
    /// <summary>
    /// 
    /// </summary>
    public class Participante
    {

        public string digitoVerificacion { get; set; }

        public string digitoVerificacionRepresentante { get; set; }

        public string NumeroIdentificacion { get; set; }
        public Int16 IdTipoUsuario { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string NombreRepresentanteLegal { get; set; }
        public Int16 IdTipoIdentificacion { get; set; }
        public Int16 IdTipoIdentificacionRepresentante { get; set; }
        public string NumeroIdentificacionRepresentante { get; set; }
        public string PathNumeroIdentificacion { get; set; }
        public string PathConstitucionGrupo { get; set; }        
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public int NumeroAsociados { get; set; }
        public string Direccion { get; set; }
        public string Genero { get; set; }
        public bool Certifico { get; set; }
        public bool Autorizo { get; set; }
        public bool AutorizoEmail { get; set; }
        public string ContrasenaEncriptada { get; set; }
        public string ContrasenaValor { get; set; }
        public DateTime FechaRetiro { get; set; }
        public Int16 IdPreguntaSecreta { get; set; }
        public string RespuestaPregunta { get; set; }
        public Int16 IdEstadoUsuario { get; set; }
        public Int16 IdDepartamento { get; set; }
        public Int16 IdMunicipio { get; set; }

        public static Participante ValidarIngresoParticipante(string usuario)
        {
            DatosParticipante datos = new DatosParticipante();
            
            DataRow registro = datos.BuscarParticipantePorNumeroIdentificacion(usuario);

            if (registro != null)
            {
                Participante participante = new Participante();
                participante.Nombres = registro["Nombres"].ToString();
                participante.Apellidos = registro["Apellidos"].ToString();
                participante.NumeroIdentificacion = registro["NumeroIdentificacion"].ToString();
                participante.IdEstadoUsuario = Convert.ToInt16(registro["IdEstadoUsuario"]);
                participante.ContrasenaValor = registro["valorContrasena"].ToString();

                participante.Email = registro["Email"].ToString();
                return participante;
            }
            else
            {
                return null;
            }
        }

        public static Participante ValidarIngresoParticipante(string usuario, string contrasena)
        {
            DatosParticipante datos = new DatosParticipante();

            string contrasenaEncriptada = Encriptar.ObtenerPasswordEncriptado(contrasena);
            DataRow registro = datos.BuscarParticipante(usuario, contrasenaEncriptada);

            if (registro != null)
            {
                Participante participante = new Participante();
                participante.Nombres = registro["Nombres"].ToString();
                participante.Apellidos = registro["Apellidos"].ToString();
                participante.NumeroIdentificacion = registro["NumeroIdentificacion"].ToString();
                participante.IdEstadoUsuario = Convert.ToInt16(registro["IdEstadoUsuario"]);

                return participante;
            }
            else
            {
                return null;
            }
        }

        public static bool ValidarRegistroCorreo(string correo)
        {
            DatosParticipante datos = new DatosParticipante();

            
            DataRow registro = datos.BuscarParticipantePorCorreo(correo);

            if (registro != null)
            {
                datos.ActualizarEstadoValidacion(registro["NumeroIdentificacion"].ToString());

                return true;
            }
            
                return false;
            
        }

        public static string generateString(int length = 8)
        {
          string cadena= "";
          string possible = "0123456789bcdfghjkmnpqrstvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
          int i = 0;
          Random rnd = new Random((int)DateTime.Now.Ticks); 
          while (i < length) 
          {            
            int num_aleatorio = rnd.Next(1, possible.Length);
            char caracter = char.Parse(possible.Substring(num_aleatorio, 1));
            cadena += caracter;
            i++;
          }
          return cadena;
        }

        public static string EmailRegistroSatisfactorio(string numeroIdentificacion)
        {
            DatosParticipante datos = new DatosParticipante();

            Participante participanteIdentificacion = ObtenerParticipanteNumeroIdentificacion(numeroIdentificacion);
            if (participanteIdentificacion != null)
            {
                clsWebUtils email = new clsWebUtils();
                System.Configuration.AppSettingsReader ar = new System.Configuration.AppSettingsReader();
                string MensajeEnvioContrasena = ar.GetValue("MensajeInscripcionCorrecta", typeof(string)).ToString();

                MensajeEnvioContrasena = MensajeEnvioContrasena.Replace("[FECHA]", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"));
                MensajeEnvioContrasena = MensajeEnvioContrasena.Replace("[Participante]", participanteIdentificacion.Nombres + " " + participanteIdentificacion.Apellidos);
                MensajeEnvioContrasena = MensajeEnvioContrasena.Replace("[DOCUMENTO]", numeroIdentificacion);
                MensajeEnvioContrasena = MensajeEnvioContrasena.Replace("[n]", "<br />");

                if (email.enviarEmail("Inscripción participación ciudadana", MensajeEnvioContrasena, participanteIdentificacion.Email))
                {
                    return participanteIdentificacion.Email;
                }
                else
                {
                    return "Error";
                }

            }
            else
            {
                return null;
            }
        }

        public static string CambioContrasenaParticipante(string numeroIdentificacion, int idPregunta, string valorRespuesta)
        {
            DatosParticipante datos = new DatosParticipante();

            Participante participanteIdentificacion = ObtenerParticipanteNumeroIdentificacion(numeroIdentificacion);

            if (participanteIdentificacion != null)
            {
                if (participanteIdentificacion.IdPreguntaSecreta == (short)idPregunta && participanteIdentificacion.RespuestaPregunta == valorRespuesta)
                {
                    string nuevo_password = generateString(8);
                    participanteIdentificacion.ContrasenaValor = nuevo_password;
                    participanteIdentificacion.IdEstadoUsuario = participanteIdentificacion.IdEstadoUsuario;
                    ActualizarParticipanteBD(participanteIdentificacion);

                    clsWebUtils email = new clsWebUtils();
                    System.Configuration.AppSettingsReader ar = new System.Configuration.AppSettingsReader();
                    string MensajeEnvioContrasena = ar.GetValue("MensajeEnvioContrasena", typeof(string)).ToString();

                    MensajeEnvioContrasena = MensajeEnvioContrasena.Replace("[FECHA]", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"));
                    MensajeEnvioContrasena = MensajeEnvioContrasena.Replace("[Participante]", participanteIdentificacion.Nombres + " " + participanteIdentificacion.Apellidos);
                    MensajeEnvioContrasena = MensajeEnvioContrasena.Replace("[DOCUMENTO]", numeroIdentificacion);
                    MensajeEnvioContrasena = MensajeEnvioContrasena.Replace("[CONTRASEÑA]", nuevo_password);
                    MensajeEnvioContrasena = MensajeEnvioContrasena.Replace("[n]", "<br>");

                    if (email.enviarEmail("Recordatorio Contraseña Carnet Participantes", MensajeEnvioContrasena, participanteIdentificacion.Email))
                    {
                        return participanteIdentificacion.Email;
                    }
                    else
                    {
                        return "Error";
                    }
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }            
        }

        public static string CambioContrasenaParticipante(string numeroIdentificacion)
        {
            DatosParticipante datos = new DatosParticipante();

            Participante participanteIdentificacion = ObtenerParticipanteNumeroIdentificacion(numeroIdentificacion);

            if (participanteIdentificacion != null)
            {
                
                    string nuevo_password = generateString(8);
                    participanteIdentificacion.ContrasenaValor = nuevo_password;
                    participanteIdentificacion.IdEstadoUsuario = participanteIdentificacion.IdEstadoUsuario;
                    ActualizarParticipanteBD(participanteIdentificacion);

                    clsWebUtils email = new clsWebUtils();
                    System.Configuration.AppSettingsReader ar = new System.Configuration.AppSettingsReader();
                    string MensajeEnvioContrasena = ar.GetValue("MensajeEnvioContrasena", typeof(string)).ToString();

                    MensajeEnvioContrasena = MensajeEnvioContrasena.Replace("[FECHA]", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"));
                    MensajeEnvioContrasena = MensajeEnvioContrasena.Replace("[Participante]", participanteIdentificacion.Nombres + " " + participanteIdentificacion.Apellidos);
                    MensajeEnvioContrasena = MensajeEnvioContrasena.Replace("[DOCUMENTO]", numeroIdentificacion);
                    MensajeEnvioContrasena = MensajeEnvioContrasena.Replace("[CONTRASEÑA]", nuevo_password);
                    MensajeEnvioContrasena = MensajeEnvioContrasena.Replace("[n]", "<br>");

                    if (email.enviarEmail("Recordatorio Contraseña Carnet Participantes", MensajeEnvioContrasena, participanteIdentificacion.Email))
                    {
                        return participanteIdentificacion.Email;
                    }
                    else
                    {
                        return "Error";
                    }
                
            }
            else
            {
                return null;
            }
        }


        public static void EliminarParticipanteNumeroIdentificacion(string numeroIdentificacion)
        {
            DatosParticipante datos = new DatosParticipante();
            datos.deleteParticipantePorNumeroIdentificacion(numeroIdentificacion);
        }


        public static Participante ObtenerParticipanteNumeroIdentificacion(string numeroIdentificacion)
        {
            DatosParticipante datos = new DatosParticipante();
            DataRow registro = datos.BuscarParticipantePorNumeroIdentificacion(numeroIdentificacion);

            if (registro != null)
            {
                Participante participante = new Participante();

                participante.NumeroIdentificacion = registro["NumeroIdentificacion"].ToString();
                participante.IdTipoUsuario = Convert.ToInt16(registro["IdTipoUsuario"].ToString());
                participante.digitoVerificacion =registro["digitoVerificacion"].ToString();
                participante.digitoVerificacionRepresentante = registro["digitoVerificacionRepresentante"].ToString();
                participante.Nombres = registro["Nombres"].ToString();
                participante.Apellidos = registro["Apellidos"].ToString();
                participante.NombreRepresentanteLegal = registro["NombreRepresentanteLegal"].ToString();
                participante.IdTipoIdentificacion = Convert.ToInt16(registro["IdTipoIdentificacion"].ToString());
                participante.IdTipoIdentificacionRepresentante = Convert.ToInt16(registro["IdTipoIdentificacionRepresentante"].ToString());
                participante.NumeroIdentificacionRepresentante = registro["NumeroIdentificacionRepresentante"].ToString();
                participante.PathNumeroIdentificacion = registro["PathNumeroIdentificacion"].ToString();
                participante.PathConstitucionGrupo = registro["PathConstitucionGrupo"].ToString();                
                participante.Genero = registro["Genero"].ToString();
                participante.NumeroAsociados = Convert.ToInt32(registro["NumeroAsociados"].ToString());
                participante.Email = registro["Email"].ToString();
                participante.Telefono = registro["Telefono"].ToString();
                participante.Celular = registro["Celular"].ToString();
                participante.Direccion = registro["Direccion"].ToString();
                participante.Certifico = Convert.ToBoolean(registro["Certifico"].ToString());
                participante.Autorizo = Convert.ToBoolean(registro["Autorizo"].ToString());
                participante.ContrasenaEncriptada = registro["Contrasena"].ToString();
                participante.ContrasenaValor = registro["ValorContrasena"].ToString();
                participante.IdPreguntaSecreta = Convert.ToInt16(registro["IdPreguntaSecreta"].ToString());
                participante.RespuestaPregunta = registro["RespuestaPregunta"].ToString();
                participante.IdEstadoUsuario = Convert.ToInt16(registro["IdEstadoUsuario"].ToString());
                participante.IdMunicipio = Convert.ToInt16(registro["IdMunicipio"].ToString());
                participante.AutorizoEmail = Convert.ToBoolean(registro["AutorizoEmail"].ToString());
                participante.IdDepartamento = Convert.ToInt16(registro["IdDepartamento"].ToString());               

                return participante;
            }
            else
            {
                return null;
            }
        }

        public static void GuardarParticipanteBD(Participante participante)
        {
            participante.ContrasenaEncriptada = Encriptar.ObtenerPasswordEncriptado(participante.ContrasenaValor);

            DatosParticipante guardarDatos = new DatosParticipante();
            guardarDatos.InsertarParticipanteBD(participante.NumeroIdentificacion,participante.IdTipoUsuario, participante.Nombres.ToUpper(), participante.Apellidos.ToUpper(), participante.NombreRepresentanteLegal.ToUpper(),
            participante.IdTipoIdentificacion, participante.IdTipoIdentificacionRepresentante, participante.NumeroIdentificacionRepresentante, participante.PathNumeroIdentificacion,
            participante.PathConstitucionGrupo, participante.Email.ToLower(), participante.Telefono, participante.Celular,
            participante.NumeroAsociados, participante.Direccion.ToUpper(), Convert.ToChar(participante.Genero), participante.Certifico, participante.Autorizo, participante.ContrasenaEncriptada, participante.IdPreguntaSecreta,
            participante.RespuestaPregunta, participante.IdEstadoUsuario, participante.IdMunicipio, participante.AutorizoEmail, participante.ContrasenaValor,participante.digitoVerificacion,participante.digitoVerificacionRepresentante);

        }

        public static void ActualizarParticipanteBD(Participante participante)
        {
            if (participante.ContrasenaValor == "INS_p")
            {
                participante.ContrasenaEncriptada = null;
            }
            else
            {
                participante.ContrasenaEncriptada = Encriptar.ObtenerPasswordEncriptado(participante.ContrasenaValor);
            }

            char c = ' ';
            if (participante.Genero.Trim().Length == 1)
            {
                c = Convert.ToChar(participante.Genero.Trim());
            }
            DatosParticipante guardarDatos = new DatosParticipante();
            guardarDatos.ActualizarDatos(participante.NumeroIdentificacion, participante.IdTipoUsuario, participante.Nombres, participante.Apellidos, participante.NombreRepresentanteLegal,
            participante.IdTipoIdentificacion, participante.IdTipoIdentificacionRepresentante, participante.NumeroIdentificacionRepresentante, participante.PathNumeroIdentificacion,
            participante.PathConstitucionGrupo, participante.Email, participante.Telefono, participante.Celular,
            participante.NumeroAsociados, participante.Direccion, c, participante.Certifico, participante.Autorizo, participante.ContrasenaEncriptada, participante.IdPreguntaSecreta,
            participante.RespuestaPregunta, participante.IdMunicipio, participante.AutorizoEmail, participante.ContrasenaValor,participante.digitoVerificacion,participante.digitoVerificacionRepresentante);

        }

        public static void ActualizarClaveCorreoParticipanteBD(Participante Participante)
        {
            DatosParticipante guardarDatos = new DatosParticipante();
            guardarDatos.ActualizarDatosClaveCorreo(Participante.NumeroIdentificacion, Participante.Email, Participante.ContrasenaEncriptada, Participante.ContrasenaValor);

        }
    }

}