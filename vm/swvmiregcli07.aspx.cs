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

using System.Collections.Generic;
using System.Text;
using DAL;
using DAL.Entidades;

using System.Data.SqlClient;
using System.Security.Cryptography;



public partial class swvmiregcli07 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["page"] = "regcli";
    }

   
protected void  ButtonLimpiar_Click(object sender, EventArgs e)
{    
    this.lblMensaje.Text = "";
    Limpiar();
}
    protected void ButtonEnviar_Click(object sender, EventArgs e)
    {
        if (cvRClave.IsValid == true && cvCiruc.IsValid == true)
        {
            string msg = "";
            this.lblMensaje.Text = "";
            /*capturamos datos en objeto cliente*/
            Cliente cliente = creaUI();
            /*Instanciamos clienteBD para acceder a sus metodos*/
            ClienteBD clienteBD = new ClienteBD();
            /*Flag respuesta*/
            string flag;
            flag = clienteBD.ExisteCliente(cliente);
            if (flag == "0")//no existe
            {
                clienteBD.Insertar(cliente);
                msg = "Registro exitoso. <br/> &nbsp Por favor inicie sesion.";
            }
            else
            {
                msg = "Cliente ya existe";
            }
            //Clear
            Limpiar();
            this.lblMensaje.Text = msg;
        }
    }

    protected void cvCiruc_ServerValidate(object source, ServerValidateEventArgs args)
    {
        /*Instanciamos clase Valida para entrar a funcion*/
        Valida valida = new Valida();        
        //valida 10 o 13 digitos
        if ((this.txtCiruc.Text.Length) > 10 && (this.txtCiruc.Text.Length) < 13){
            args.IsValid = false;
            cvCiruc.ErrorMessage ="Error Ci/Ruc solo acepta 10 o 13 dígitos respectivamente"; }
            else
            {//valida cedula
                string msg = "";
                msg = valida.Cedula(this.txtCiruc.Text);
                if (msg != "true")
                { args.IsValid = false; cvCiruc.ErrorMessage = msg; }
                else
                { args.IsValid = true; }
            }
        }

        #region Funciones

        private Cliente creaUI()
        {
            Cliente cliente = new Cliente();            
            cliente.Nombre = txtNombre.Text;
            cliente.Dir = txtDir.Text;
            cliente.Ciruc = txtCiruc.Text;
            cliente.Provincia = ddlProvincia.SelectedItem.Text;
            cliente.Ciudad = txtCiudad.Text;
            cliente.Fono1 = txtFono1.Text;
            cliente.Fono2 = txtFono2.Text;
            cliente.Email = txtEmail.Text;            
            Funciones f = new Funciones();
            string clave = f.encriptar(txtClave.Text);
            cliente.Clave = clave;
            return cliente;
        }

        private void Limpiar()
        {
            txtCiruc.Text = "";
            txtNombre.Text = "";
            txtCiudad.Text = "";
            txtDir.Text = "";
            txtFono1.Text = "";
            txtFono2.Text = "";
            txtEmail.Text = "";
            txtClave.Text = "";
            txtRClave.Text = "";
            ddlProvincia.SelectedIndex = 0;
        }

        #endregion

        
}
