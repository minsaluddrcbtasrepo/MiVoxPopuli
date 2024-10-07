using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace NegocioInscripcionMinSalud
{
    public class clsWebUtils
    {

        public bool enviarEmail(string asunto, string cuerpo, string direccionDestino)
        {
            System.Configuration.AppSettingsReader ar = new System.Configuration.AppSettingsReader();
            string cuentaFrom = ar.GetValue("cuentaFrom", typeof(string)).ToString();
            string nombreCuentaFrom = ar.GetValue("nombreCuentaFrom", typeof(string)).ToString();
            string servidor = ar.GetValue("servidor", typeof(string)).ToString();
            string puerto = ar.GetValue("puerto", typeof(string)).ToString();
            string pass = ar.GetValue("pass", typeof(string)).ToString();

            string usuario = ar.GetValue("usuario", typeof(string)).ToString();
            bool ssl = (bool)ar.GetValue("ssl", typeof(bool));
            bool autentificacion = (bool)ar.GetValue("autentificacion", typeof(bool));

            return enviarEmail(asunto, cuerpo, cuentaFrom, nombreCuentaFrom, ssl, servidor,
             puerto, autentificacion, usuario, pass, direccionDestino);
        }

        public bool enviarEmailHuerfanas(string asunto, string cuerpo, string direccionDestino)
        {
            System.Configuration.AppSettingsReader ar = new System.Configuration.AppSettingsReader();
            string cuentaFrom = ar.GetValue("cuentaFrom", typeof(string)).ToString();
            string nombreCuentaFrom = ar.GetValue("nombreCuentaFrom", typeof(string)).ToString();
            string servidor = ar.GetValue("servidor", typeof(string)).ToString();
            string puerto = ar.GetValue("puerto", typeof(string)).ToString();
            string pass = ar.GetValue("pass", typeof(string)).ToString();

            string usuario = ar.GetValue("usuario", typeof(string)).ToString();
            bool ssl = (bool)ar.GetValue("ssl", typeof(bool));
            bool autentificacion = (bool)ar.GetValue("autentificacion", typeof(bool));
            string direccionCopia = ar.GetValue("CuentaCorreoHuerfanas", typeof(string)).ToString();



            return enviarEmail(asunto, cuerpo, cuentaFrom, nombreCuentaFrom, ssl, servidor,
             puerto, autentificacion, usuario, pass, direccionDestino, null, direccionCopia);
        }


        public bool enviarEmailPostulacionTecnologiasExcluidas(string asunto, string cuerpo, string direccionDestino)
        {
            System.Configuration.AppSettingsReader ar = new System.Configuration.AppSettingsReader();
            string cuentaFrom = ar.GetValue("cuentaFrom", typeof(string)).ToString();
            string nombreCuentaFrom = ar.GetValue("nombreCuentaFrom", typeof(string)).ToString();
            string servidor = ar.GetValue("servidor", typeof(string)).ToString();
            string puerto = ar.GetValue("puerto", typeof(string)).ToString();
            string pass = ar.GetValue("pass", typeof(string)).ToString();

            string usuario = ar.GetValue("usuario", typeof(string)).ToString();
            bool ssl = (bool)ar.GetValue("ssl", typeof(bool));
            bool autentificacion = (bool)ar.GetValue("autentificacion", typeof(bool));
            string direccionCopia = ar.GetValue("CuentaCorreoPostulacionTecExcluida", typeof(string)).ToString();



            return enviarEmail(asunto, cuerpo, cuentaFrom, nombreCuentaFrom, ssl, servidor,
             puerto, autentificacion, usuario, pass, direccionDestino, null, direccionCopia);
        }

        public bool enviarEmail(string asunto, string cuerpo, string direccionDestino, List<string> adjuntos)
        {
            System.Configuration.AppSettingsReader ar = new System.Configuration.AppSettingsReader();
            string cuentaFrom = ar.GetValue("cuentaFrom", typeof(string)).ToString();
            string nombreCuentaFrom = ar.GetValue("nombreCuentaFrom", typeof(string)).ToString();
            string servidor = ar.GetValue("servidor", typeof(string)).ToString();
            string puerto = ar.GetValue("puerto", typeof(string)).ToString();
            string pass = ar.GetValue("pass", typeof(string)).ToString();

            string usuario = ar.GetValue("usuario", typeof(string)).ToString();
            bool ssl = (bool)ar.GetValue("ssl", typeof(bool));
            bool autentificacion = (bool)ar.GetValue("autentificacion", typeof(bool));

            return enviarEmail(asunto, cuerpo, cuentaFrom, nombreCuentaFrom, ssl, servidor,
             puerto, autentificacion, usuario, pass, direccionDestino, adjuntos);
        }

        public static int cantidademailEnviados = 0;

        public bool enviarEmail(string asunto, string cuerpo, string cuentaFrom, string nombreCuentaFrom,
        bool sslHabilitado, string servidor, string puerto, bool conAutentificacion, string usuario, string password,
        string direccionDestino)
        {
            return enviarEmail(
        asunto, cuerpo, cuentaFrom, nombreCuentaFrom, sslHabilitado, servidor, puerto, conAutentificacion, usuario, password,
        direccionDestino, null);
        }

        public bool enviarEmail(string asunto, string cuerpo, string cuentaFrom, string nombreCuentaFrom,
        bool sslHabilitado, string servidor, string puerto, bool conAutentificacion, string usuario, string password,
        string direccionDestino, List<string> adjuntos, string direccionCopia = "")
        {
            //Version anterior
            /* System.Net.Mail.MailMessage email = new System.Net.Mail.MailMessage();
             System.Net.Mail.SmtpClient smtp;
             System.Configuration.AppSettingsReader ar = new System.Configuration.AppSettingsReader();
             string cuentaCopy = ar.GetValue("cuentaCopy", typeof(string)).ToString();

             cantidademailEnviados++;
             if (cantidademailEnviados >= 30)
             {
                 cantidademailEnviados = 0;
                 //  System.Threading.Thread.Sleep(2500);
             }
             email.Subject = asunto;
             string firma = @"<br><br>Cordialmente,
                             <br>
                             <div>
                             <img width='240' src='https://www.minsalud.gov.co/LogosInstitucionales/logo-gobierno-Ministerio-de-salud-y-proteccion-social-minsalud.png'>
                             </div>
                             <font color='darkblue'>
                             <strong>Participación Ciudadana en Salud</strong><br>

                             Tel: 3305000 Ext. 1977 - 1925 - 1983 </font> 
                             </br>
                             <div>
                             <a href='https://www.minsalud.gov.co'>www.minsalud.gov.co</a>
                             </div>
                             <div>
                             </br>
                             </br>
                             <font color='darkgreen'>Antes de imprimir este mensaje piense bien si es necesario hacerlo.</font></div>";
             email.Body = cuerpo + firma;


             email.From = new System.Net.Mail.MailAddress(cuentaFrom, nombreCuentaFrom);
             email.Priority = System.Net.Mail.MailPriority.Normal;
             email.ReplyTo = new System.Net.Mail.MailAddress(cuentaFrom);

             email.IsBodyHtml = true;
             email.DeliveryNotificationOptions = System.Net.Mail.DeliveryNotificationOptions.OnSuccess;

             smtp = new System.Net.Mail.SmtpClient(servidor, int.Parse(puerto));
             smtp.EnableSsl = sslHabilitado;
             if (cuentaCopy != null && cuentaCopy.Trim() != string.Empty)
             {
                 email.CC.Add(cuentaCopy);
             }
             //smtp.Port = int.Parse(puerto);
             //smtp.Host = servidor;
             if (conAutentificacion)
             {
                 smtp.Credentials = new System.Net.NetworkCredential(usuario, password);
             }

             //string rutatmp = System.IO.Path.GetTempFileName().Replace(".", "");
             //System.IO.Directory.CreateDirectory(rutatmp);
             try
             {
                 if (adjuntos != null)
                 {
                     for (int k = 0; k < adjuntos.Count; k++)
                     {
                         email.Attachments.Add(new System.Net.Mail.Attachment(adjuntos[k]));
                     }
                 }
             }
             catch (Exception) { }
             // Agregamos Destinos.
             System.Net.Mail.MailAddress dir = new System.Net.Mail.MailAddress(direccionDestino);
             email.To.Add(dir);


             email.BodyEncoding = System.Text.Encoding.UTF8;
             try
             {
                 smtp.Send(email);
                 return true;
             }
             catch (Exception ex)
             {
                 return true;
             }*/


            ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Ssl3 | System.Net.SecurityProtocolType.Tls12 | System.Net.SecurityProtocolType.Tls11 | System.Net.SecurityProtocolType.Tls;
            SmtpClient objSmtpClient;
            System.Net.NetworkCredential objNetworkCredential;
            objSmtpClient = new SmtpClient(servidor, int.Parse(puerto));
            objSmtpClient.EnableSsl = sslHabilitado;
            objNetworkCredential = new System.Net.NetworkCredential(usuario, password);
            try
            {

                MailMessage objMailMessage = new MailMessage();
                objMailMessage.From = new MailAddress(cuentaFrom, "Mi Vox Populi");
                objMailMessage.To.Add(new MailAddress(direccionDestino));
                objMailMessage.CC.Add(new MailAddress("participacion@minsalud.gov.co"));
                if (direccionCopia != "")
                {
                    objMailMessage.CC.Add(new MailAddress(direccionCopia));
                }

                objMailMessage.Subject = asunto;
                objSmtpClient.UseDefaultCredentials = false;
                objSmtpClient.Credentials = objNetworkCredential;
                objMailMessage.IsBodyHtml = true;

                string firma = @"<br><br>Cordialmente,
                             <br>
                             <div>
                             <img width='240' src='https://www.minsalud.gov.co/LogosInstitucionales/logo-gobierno-Ministerio-de-salud-y-proteccion-social-minsalud.png'>
                             </div>
                             <font color='darkblue'>
                             <strong>Participación Ciudadana en Salud</strong><br>

                             Tel: 3305000 Ext. 1977 - 1925 - 1983 </font> 
                             </br>
                             <div>
                             <a href='https://www.minsalud.gov.co'>www.minsalud.gov.co</a>
                             </div>
                             <div>
                             </br>
                             </br>
                             <font color='darkgreen'>Antes de imprimir este mensaje piense bien si es necesario hacerlo.</font></div>";
                objMailMessage.Body = cuerpo + firma;


                try
                {
                    if (adjuntos != null)
                    {
                        for (int k = 0; k < adjuntos.Count; k++)
                        {
                            objMailMessage.Attachments.Add(new System.Net.Mail.Attachment(adjuntos[k]));
                        }
                    }
                }
                catch (Exception e)
                {
                    return false;
                }

                if (direccionDestino == null || direccionDestino == string.Empty)
                {
                    return false;
                }

                objSmtpClient.Send(objMailMessage);
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }

        }



        public bool enviarEmailHuerfanas(string asunto, string cuerpo, string cuentaFrom, string nombreCuentaFrom,
       bool sslHabilitado, string servidor, string puerto, bool conAutentificacion, string usuario, string password,
       string direccionDestino)
        {
            return enviarEmailHuerfanas(
        asunto, cuerpo, cuentaFrom, nombreCuentaFrom, sslHabilitado, servidor, puerto, conAutentificacion, usuario, password,
        direccionDestino, null);
        }

        public bool enviarEmailHuerfanas(string asunto, string cuerpo, string cuentaFrom, string nombreCuentaFrom,
        bool sslHabilitado, string servidor, string puerto, bool conAutentificacion, string usuario, string password,
        string direccionDestino, List<string> adjuntos)
        {
            ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Ssl3 | System.Net.SecurityProtocolType.Tls12 | System.Net.SecurityProtocolType.Tls11 | System.Net.SecurityProtocolType.Tls;
            SmtpClient objSmtpClient;
            System.Net.NetworkCredential objNetworkCredential;
            objSmtpClient = new SmtpClient(servidor, int.Parse(puerto));
            objSmtpClient.EnableSsl = sslHabilitado;
            objNetworkCredential = new System.Net.NetworkCredential(usuario, password);
            try
            {

                MailMessage objMailMessage = new MailMessage();
                objMailMessage.From = new MailAddress(cuentaFrom, "Mi Vox Populi");
                objMailMessage.To.Add(new MailAddress(direccionDestino));
                ///objMailMessage.To.Add(new MailAddress("yprada@minsalud.gov.co"));
                objMailMessage.CC.Add(new MailAddress("participacion@minsalud.gov.co"));
                // objMailMessage.CC.Add(new MailAddress("pvera2303@gmail.com"));
                objMailMessage.Subject = asunto;
                objSmtpClient.UseDefaultCredentials = false;
                objSmtpClient.Credentials = objNetworkCredential;
                objMailMessage.IsBodyHtml = true;

                string firma = @"<br><br>Cordialmente,
                             <br>
                             <div>
                             <img width='240' src='https://www.minsalud.gov.co/LogosInstitucionales/logo-gobierno-Ministerio-de-salud-y-proteccion-social-minsalud.png'>
                             </div>
                             <font color='darkblue'>
                             <strong>Participación Ciudadana en Salud</strong><br>

                             Tel: 3305000 Ext. 1977 - 1925 - 1983 </font> 
                             </br>
                             <div>
                             <a href='https://www.minsalud.gov.co'>www.minsalud.gov.co</a>
                             </div>
                             <div>
                             </br>
                             </br>
                             <font color='darkgreen'>Antes de imprimir este mensaje piense bien si es necesario hacerlo.</font></div>";
                objMailMessage.Body = cuerpo + firma;


                try
                {
                    if (adjuntos != null)
                    {
                        for (int k = 0; k < adjuntos.Count; k++)
                        {
                            objMailMessage.Attachments.Add(new System.Net.Mail.Attachment(adjuntos[k]));
                        }
                    }
                }
                catch (Exception e)
                {
                    return false;
                }

                if (direccionDestino == null || direccionDestino == string.Empty)
                {
                    return false;
                }

                objSmtpClient.Send(objMailMessage);
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }


        }




    }
}