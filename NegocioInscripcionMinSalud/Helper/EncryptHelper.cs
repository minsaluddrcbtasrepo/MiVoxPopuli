using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace NegocioInscripcionMinSalud.Helper
{
    public static class EncryptHelper
    {
        public static string Deecrypt(string dato)
        {
            if (!string.IsNullOrEmpty(dato))
            {
                byte[] passByteData = Convert.FromBase64String(dato);
                string originalPassword = System.Text.Encoding.Unicode.GetString(passByteData);
                if (originalPassword.Length > 11)
                {
                    originalPassword = originalPassword.Substring(0, 5) +
                                       originalPassword.Substring(6, 5) +
                                       originalPassword.Substring(12);
                }
                else
                {
                    originalPassword = originalPassword.Substring(0, 5) +
                                       originalPassword.Substring(6);
                }
                return originalPassword;
            }
            return "";
        }

        public static string Encrypt(string dato)
        {
            if (!string.IsNullOrEmpty(dato))
            {
                if (dato.Length >= 11)
                {
                    dato = dato.Substring(0, 5) +
                           DateTime.Now.Minute.ToString()[0] +
                           dato.Substring(5, 5) +
                           DateTime.Now.Millisecond.ToString()[0] +
                           dato.Substring(10);
                }
                else
                {
                    dato = dato.Substring(0, 5) +
                           DateTime.Now.Minute.ToString()[0] +
                           dato.Substring(5);
                }

                byte[] passByte = System.Text.Encoding.Unicode.GetBytes(dato);
                string encryptPass = Convert.ToBase64String(passByte);
                return encryptPass;
            }
            return "";
        }
    }

  
}