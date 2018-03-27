using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DAL.Entidades;
using System.Net.Mail;

namespace DAL
{
    /// <summary>
    /// SendEmail: Enviar, EnviarPass
    /// </summary>
    public class SendEmail
    {
        public bool EnviarCot(int cotiid, string emailcli, string ruta)
        {
            bool flag = false;
            //Creamos un nuevo Objeto de Mensaje
            MailMessage oMsg = new MailMessage();
            //Desde (correo electronico desde la que enviamos)
            oMsg.From = new MailAddress("ventas@viveromarket.com", "Dpto. Ventas ViveroMarket");
            //Hasta (direccion de correo electronico a la que queremos enviar)
            oMsg.To.Add(emailcli);
            //Asunto
            oMsg.Subject = "Cotizacion de Plantas ViveroMarket";
            //Cuerpo del Mensaje
            oMsg.Body = "Gracias por Cotizar en "
                + "<a href='http://www.viveromarket.com/'>ViveroMarket</a><br/>"
                + "Adjuntamos su cotización, por favor imprimala y acuda a nuestras oficinas para concretar su compra"
                + "<br/>Gracias por Preferirnos<br/><br/><hr width='100%' size='2'><br/>";
            oMsg.IsBodyHtml = true;

            string sFile = @ruta+cotiid.ToString() + ".pdf";
            Attachment attachFile = new Attachment(sFile);
            oMsg.Attachments.Add(attachFile);            
            //Creamos una instancia de cliente SMTP para el envio del mensaje
            //Nombre del servidor SMTP de envio.
            //Normalmente es “mail.[tu dominio]”
            SmtpClient smtp = new SmtpClient("mail.viveromarket.com");
            //Como nuestro servidor requiere autenticación, tenemos que especificar las credenciales
            //Para ello tenemos que autenticarnos con nuestra cuenta de correo y contraseña
            smtp.Credentials = new System.Net.NetworkCredential("ventas@viveromarket.com", "1234");
            //Y Enviamos el mensaje!!!
            try
            {
                smtp.Send(oMsg);
                flag = true;
            }
            catch (Exception ex)
            {
                flag = false;
            }
            return flag;
        }

        public string EnviarPass(string email)
        {
            //obtenemos la clave desencriptada
            ClienteBD cBD = new ClienteBD();
            string clave = cBD.SuClave(email);
            //Creamos un nuevo Objeto de Mensaje
            MailMessage oMsg = new MailMessage();
            //Desde (correo electronico desde la que enviamos)
            oMsg.From = new MailAddress("webmaster@viveromarket.com", "Administrador ViveroMarket");
            //Hasta (direccion de correo electronico a la que queremos enviar)
            oMsg.To.Add(email);
            //Asunto
            oMsg.Subject = "Sus datos de Registro";
            //Cuerpo del Mensaje
            oMsg.Body = "<font face='Arial' size='2'>Sus datos de registro son:<br><br>email: "
                +email
                +"<br>contraseña: "
                +clave
                +"</font><br><div align='center'><img src='http://viveromarket.com/images/logo.png'></div>";
            oMsg.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("mail.viveromarket.com");
            //Como nuestro servidor requiere autenticación, tenemos que especificar las credenciales
            //Para ello tenemos que autenticarnos con nuestra cuenta de correo y contraseña
            smtp.Credentials = new System.Net.NetworkCredential("webmaster@viveromarket.com", "zelote");
            //Y Enviamos el mensaje!!!
            string msg = string.Empty;
            try
            {
                smtp.Send(oMsg);
                msg = "Sus datos se enviaron correctamente";
            }
            catch (Exception ex)
            {
                msg = "Error, favor contacte al administrador webmaster@viveromarket.com </br>"
                    +ex.Message;
            }
            return msg;
        }

        #region Funciones
        #endregion
    }
}