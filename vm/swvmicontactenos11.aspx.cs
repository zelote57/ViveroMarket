using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Net.Mail;
using System.Drawing;
using System.Collections.Generic;
using System.Text;
using DAL;
using DAL.Entidades;

using System.Data.SqlClient;
using System.Security.Cryptography;


public partial class swvmicontactenos11 : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        Session["page"] = "contactenos";
        showDatos();
    }
    
    protected void SendButton_Click(object sender, EventArgs e)
    {
        string msg= string.Empty;
        //Creamos un nuevo Objeto de Mensaje
		MailMessage oMsg = new MailMessage();
		//Desde (correo electronico desde la que enviamos)
        oMsg.From = new MailAddress("info@viveromarket.com");//txtEmail.Text, txtNombre.Text);
		//Hasta (direccion de correo electronico a la que queremos enviar)
        oMsg.To.Add("info@viveromarket.com");// info@viveromarket.com
		//Copia Carbon (direccion de correo electronico que queremos que reciba una copia)
		if (ckbCopiaemail.Checked == true)
        {
            MailMessage oMsg2 = new MailMessage();
            oMsg2.From = new MailAddress("info@viveromarket.com");
            oMsg2.To.Add(txtEmail.Text);
            oMsg2.Subject = "Copia de su mensaje: "+txtTitulo.Text;
            oMsg2.Body = "Esta es una copia del correo enviado por usted desde nuestro "
                +"Sitio Web <a href='http://www.viveromarket.com/'>ViveroMarket</a><br/>"
                +"Le responderemos lo más pronto posible gracias por escribirnos."
                +"<br/><br/><hr width='100%' size='2'><br/>"+txtMensaje.Text;
            oMsg2.IsBodyHtml = true;
            SmtpClient smtp2 = new SmtpClient("mail.viveromarket.com");
            smtp2.Credentials = new System.Net.NetworkCredential("info@viveromarket.com","1234");
            smtp2.Send(oMsg2);
        }
        //Asunto
		oMsg.Subject = txtTitulo.Text;
		//Cuerpo del Mensaje
        oMsg.Body = "Mensaje enviado desde página contáctenos de ViveroMarket <br/>"
                    + "<hr width='100%' size='2'> <br/>"
                    + "Enviado por: " + txtNombre.Text + "<br/>"
                    + "Responder a: " + txtEmail.Text + "<br/>"
                    + "<hr width='100%' size='2'> <br/>"
                    + "Mensaje: <br/>"
                    + txtMensaje.Text;
        oMsg.IsBodyHtml = true;
		//Creamos una instancia de cliente SMTP para el envio del mensaje
		//Nombre del servidor SMTP de envio.
		//Normalmente es “mail.[tu dominio]”
		SmtpClient smtp = new SmtpClient("mail.viveromarket.com");            
		//Como nuestro servidor requiere autenticación, tenemos que especificar las credenciales
		//Para ello tenemos que autenticarnos con nuestra cuenta de correo y contraseña
		smtp.Credentials = new System.Net.NetworkCredential("info@viveromarket.com","1234");        
		//Y Enviamos el mensaje!!!
        try
        {
            smtp.Send(oMsg);
            msg = "Mensaje enviado correctamente";
            Limpiar();
        }
        catch (Exception ex)
        {
            msg = "Error al enviar, favor contactar al administrador webmaster@viveromarket.com";
        }
        lblMensajeError.Text = msg;
    }

  #region Funciones

    private void showDatos() 
    {
        Funciones f = new Funciones();
        ProveedorBD pBD = new ProveedorBD();
        Proveedor prov = pBD.ConsultarP(1);
        lblDir.Text = f.Mayus(prov.Dir.ToLower());
        lblCiudad.Text = f.Mayus(prov.Ciudad.ToLower());
        lblProvincia.Text = f.Mayus(prov.Provincia.ToLower());
        lblPais.Text = f.Mayus(prov.Pais.ToLower());
        lblTelefono.Text = prov.Fono1;
        lblEmail.Text = prov.Email;    
    }

    private void Limpiar()
    {
        txtNombre.Text = "";
        txtEmail.Text = "";
        txtTitulo.Text = "";
        txtMensaje.Text = "";
    }
  
  #endregion





}
