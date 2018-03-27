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

public partial class swvmmcuentaprov01 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string tipo = Convert.ToString(Session["tipo"]);
            if (tipo == "P")
            {
                cargarDatos();               
            }
            else
            {
                Response.Redirect("default.aspx");
            }
        }
    }

    protected void btnModificar_Click(object sender, EventArgs e)
    {
        this.lblMensaje.Text = "";
        habilitaControles();
    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        Proveedor proveedor = creaUI();
        //instanciamos proveedorBD para acceder a sus metodos
        ProveedorBD proveedorBD = new ProveedorBD();
        if (cvRClave.IsValid == true && cvRuc.IsValid == true)
        {
            /*Flag respuesta*/
            string flag;
            flag = proveedorBD.ExisteProveedor(proveedor);
            if (flag == "0")
            {
                proveedorBD.Actualizar(proveedor);
                //Actualizamos variables de Sesion
                Session["empresa"] = proveedor.Empresa.ToLower();
                Session["usuario"] = proveedor.Contacto.ToLower();
                //Clear
                this.lblMensaje.Text = "Datos Actualizados Correctamente";
                noControles();
            }
            else
            {
                this.lblMensaje.Text = "Datos ya existen en otro Proveedor";            
            }          
        }
    }

    protected void bntCancelar_Click(object sender, EventArgs e)
    {
        this.lblMensaje.Text = "";
        noControles();
    }

    protected void cvRuc_ServerValidate(object source, ServerValidateEventArgs args)
    {
        Valida valida = new Valida();
        //valida 13 digitos
        if ((this.txtRuc.Text.Length) != 13)
        {
            args.IsValid = false;
            cvRuc.ErrorMessage = "Error Ruc debe tener 13 dígitos";
        }
        else
        {//valida cedula implicita en el ruc
            string msg = "";
            msg = valida.Cedula(this.txtRuc.Text);
            if (msg != "true") { args.IsValid = false; cvRuc.ErrorMessage = msg; } else { args.IsValid = true; }
        }
    }

    #region Funciones

    private Proveedor creaUI()
    {
        int provid = Convert.ToInt32(Session["userid"]);
        Proveedor proveedor = new Proveedor();
        proveedor.Provid = provid;
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
        proveedor.Estado = "A";
        return proveedor;
    }

    private void cargarDatos()
    {
        int provid = Convert.ToInt32(Session["userid"]);        
        //instanciamos proveedorBD para acceder a sus metodos
        ProveedorBD proveedorBD = new ProveedorBD();
        //instanciamos proveedor para traer los datos de la base
        Proveedor proveedor = proveedorBD.ConsultarP(provid);
        this.txtEmpresa.Text = proveedor.Empresa;        
        this.txtNombre.Text = proveedor.Contacto;
        this.txtCargo.Text = proveedor.Cargo;
        this.txtRuc.Text = proveedor.Ruc;
        this.txtDir.Text = proveedor.Dir;
        this.txtFono1.Text = proveedor.Fono1;
        this.txtFono2.Text = proveedor.Fono2;
        this.txtPais.Text = proveedor.Pais;
        this.txtProvincia.Text = proveedor.Provincia;
        this.txtCiudad.Text = proveedor.Ciudad;
        this.txtEmail.Text = proveedor.Email;
    }

    private void habilitaControles()
    {        
        btnModificar.Enabled = false;
        btnGuardar.Enabled = true;
        btnCancelar.Enabled = true;
        txtCargo.ReadOnly = false;
        txtCiudad.ReadOnly = false;
        txtDir.ReadOnly = false;
        txtEmail.ReadOnly = false;
        txtEmpresa.ReadOnly = false;
        txtFono1.ReadOnly = false;
        txtFono2.ReadOnly = false;
        txtNombre.ReadOnly = false;
        txtPais.ReadOnly = false;
        txtProvincia.ReadOnly = false;
        txtRuc.ReadOnly = false;

        lblClave.Visible = true;
        lblRClave.Visible = true;
        txtClave.Visible = true;
        txtRClave.Visible = true;        
    }

    private void noControles()
    {
        btnModificar.Enabled = true;
        btnGuardar.Enabled = false;
        btnCancelar.Enabled = false;
        txtCargo.ReadOnly = true;
        txtCiudad.ReadOnly = true;
        txtDir.ReadOnly = true;
        txtEmail.ReadOnly = true;
        txtEmpresa.ReadOnly = true;
        txtFono1.ReadOnly = true;
        txtFono2.ReadOnly = true;
        txtNombre.ReadOnly = true;
        txtPais.ReadOnly = true;
        txtProvincia.ReadOnly = true;
        txtRuc.ReadOnly = true;

        lblClave.Visible = false;
        lblRClave.Visible = false;
        txtClave.Visible = false;
        txtRClave.Visible = false;
    }

    #endregion

}
