using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Net;

namespace SICAP.Utelirias
{
    public class Correo
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="destinatarios"></param>
        /// <param name="asunto"></param>
        /// <param name="mensaje"></param>
        /// <returns></returns>
        public static bool EnviarCorreo(string destinatarios, string asunto, string mensaje)
        {
            try
            {
                // se registra el correo del destino y su estructura, contenido y asunto
                MailMessage correo = new MailMessage();
                correo.To.Add(new MailAddress(destinatarios));
                correo.From = new MailAddress("noreply@loheli.com.mx");
                correo.Subject = asunto;
                correo.Body = mensaje;
                correo.IsBodyHtml = true;
                correo.Priority = MailPriority.Normal;
                // se define las credenciales y le pasamos el correo a quien se le envia 
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.ionos.mx";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("noreply@loheli.com.mx", "123456@1");

                smtp.Send(correo); // se le pasa el objeto definido.
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}