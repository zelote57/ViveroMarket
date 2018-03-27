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
    /// SendEmail: EnviarPass
    /// </summary>
    public class SendEmail
    {
        public string EnviarPass(string email, int tipo)
        {
            //obtenemos la clave desencriptada
            string clave = string.Empty;
            //preguntamos tipo de usuario Administrador(0)/Proveedor(1)
            if (tipo == 0)
            {
                UsuarioBD uBD = new UsuarioBD();
                clave = uBD.SuClave(email);
            }
            else
            {
                ProveedorBD pBD = new ProveedorBD();
                clave = pBD.SuClave(email);
            }            
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