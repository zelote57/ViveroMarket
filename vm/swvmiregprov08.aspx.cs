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


public partial class swvmiregprov08 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["page"] = "regprov";
    }

   
protected void  ButtonLimpiar_Click(object sender, EventArgs e)
{
    Limpiar();     
    this.lblMensaje.Text = "";
}
    protected void ButtonEnviar_Click(object sender, EventArgs e)
    {
        if (cvRClave.IsValid == true && cvRuc.IsValid == true)
        {
            string msg = "";
            this.lblMensaje.Text = "";
            /*capturamos datos en objeto proveedor*/
            Proveedor proveedor = creaUI();
            /*Instanciamos proveedorBD para acceder a sus metodos*/
            ProveedorBD proveedorBD = new ProveedorBD();
            /*Flag respuesta*/
            string flag;
            flag = proveedorBD.ExisteProveedor(proveedor);                
            if (flag == "0")//no existe
            {
                proveedorBD.Insertar(proveedor);
                msg = "Registro exitoso. <br/> &nbsp Ya puede iniciar sesion de Administración";
            }
            else
            {
                msg = "Proveedor ya existe";
            }
            //Clear
            Limpiar();
            this.lblMensaje.Text = msg;
        }
    }

    protected void cvRuc_ServerValidate(object source, ServerValidateEventArgs args)
    {
        /*Instanciamos clase Valida para entrar a funcion*/
        Valida valida = new Valida();
        //13 digitos
        if ((this.txtRuc.Text.Length) != 13){
            args.IsValid = false;
            cvRuc.ErrorMessage ="Error Ruc debe tener 13 dígitos"; }   
            else
            {//valida ruc
                string msg = "";
                msg = valida.Cedula(this.txtRuc.Text);
                if (msg != "true") 
                { args.IsValid = false; cvRuc.ErrorMessage = msg; } 
                else 
                { args.IsValid = true; }
            }
    }

    #region Funciones

    private Proveedor creaUI()
    {
        Proveedor proveedor = new Proveedor();
        proveedor.Empresa = txtEmpresa.Text;
        proveedor.Contacto = txtNombre.Text;
        proveedor.Cargo = txtCargo.Text;
        proveedor.Ruc = txtRuc.Text;
        proveedor.Dir = txtDir.Text;
        proveedor.Fono1 = txtFono1.Text;
        proveedor.Fono2 = txtFono2.Text;
        proveedor.Pais = txtPais.Text;
        proveedor.Provincia = txtProvincia.Text;
        proveedor.Ciudad = txtCiudad.Text;
        proveedor.Email = txtEmail.Text;
        //Clave encriptada        
        Funciones f = new Funciones();
        string clave = f.encriptar(txtClave.Text);
        proveedor.Clave = clave;
        return proveedor;
    }

    private void Limpiar()
    {
        txtRuc.Text = "";
        txtEmpresa.Text = "";
        txtNombre.Text = "";
        txtCargo.Text = "";
        txtPais.Text = "";
        txtProvincia.Text = "";
        txtCiudad.Text = "";
        txtDir.Text = "";
        txtFono1.Text = "";
        txtFono2.Text = "";
        txtEmail.Text = "";
        txtClave.Text = "";
        txtRClave.Text = "";   
    }

    #endregion

}
