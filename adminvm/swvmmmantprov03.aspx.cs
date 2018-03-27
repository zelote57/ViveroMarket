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

public partial class swvmmmantprov03 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
         if (!Page.IsPostBack)
        {
            string tipo = "";
            tipo = Convert.ToString(Session["tipo"]);
            if (tipo == "AG")
            {
                llenarProveedores();
                ultimoId();
            }                
            else
            {
                Response.Redirect("default.aspx");
            }
        }
    }

    /*Boton editar del Grid*/
    protected void gvProveedor_RowEditing(object sender, GridViewEditEventArgs e)
    {
        lblMensaje.Text = "";
        ddlEstado.Enabled = true;
        //cargamos datos segun fila seleccionada del gridProveedor
        cargarDatos(e.NewEditIndex);
        //activar
        habilitaControles();        
        //mostrar opcion de acción
        btnGuardar.Enabled = true;
        btnNuevo.Enabled = false;
    }

    protected void btnNuevo_Click(object sender, EventArgs e)
    {
        lblMensaje.Text = "";
        ultimoId();
        habilitaControles();
    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        lblMensaje.Text = "";
        Limpiar();
        ultimoId();
        noControles();
    }

    /*Boton Guardar*/
    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        Proveedor prov = creaUI();
        ProveedorBD proveedorBD = new ProveedorBD();
        //validamos repetición contraseña y ruc
        if (cvRClave.IsValid == true && cvRuc.IsValid== true )
        {
            /*Flag respuesta*/
             string flag;
             flag = proveedorBD.ExisteProveedor(prov);
             if (flag == "0")//no existe
             {
                 //por v= Insercion; por f= actualizacion           
                if (txtId.Text == lastId().ToString())
                {
                    proveedorBD.Insertar(prov);
                    lblMensaje.Text = "Registro Exitoso";
                }
       
      else
                {
                    proveedorBD.Actualizar(prov);
                    lblMensaje.Text = "Actualización Exitosa";
                }
                llenarProveedores();
                Limpiar();
                ultimoId();
                noControles();
            }
            else
            {
                lblMensaje.Text = "Cliente ya existe";
            }            
        }
    }
    /*Boton eliminar del Grid*/
  

    protected void gvProveedor_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string msg;
        lblMensaje.Text = "";        
        //eliminamos datos segun fila seleccionada del gridProveedor
        int provid = Convert.ToInt32(gvProveedor.Rows[(Convert.ToInt32(e.RowIndex))].Cells[2].Text);
        //instanciamos ProveedorBD para acceder al metodo eliminar
        ProveedorBD proveedorBD = new ProveedorBD();
        msg = proveedorBD.Eliminar(provid);
        lblMensaje.Text = msg;
        //recargar pagina
        llenarProveedores();
        Limpiar();
        ultimoId();
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
        Proveedor prov = new Proveedor();
        prov.Provid = Convert.ToInt32(txtId.Text);
        prov.Empresa = txtEmpresa.Text;
        prov.Contacto = txtNomContac.Text;
        prov.Cargo = txtCargoContac.Text;
        prov.Ruc = txtRuc.Text;
        prov.Dir = txtDir.Text;
        prov.Fono1 = txtFono1.Text;
        prov.Fono2 = txtFono2.Text;
        prov.Pais = txtPais.Text;
        prov.Provincia = txtProvincia.Text;
        prov.Ciudad = txtCiudad.Text;
        prov.Email = txtEmail.Text;
        if (ddlEstado.SelectedIndex == 0) { prov.Estado = "A"; } else { prov.Estado = "I"; }
        //Clave encriptada
        Funciones f = new Funciones();
        string clave = f.encriptar(txtClave.Text);
        prov.Clave = clave;       
        return prov;
    }

    private void llenarProveedores()
    {
        ProveedorBD proveedorBD = new ProveedorBD();
        List<Proveedor> listaProveedor = proveedorBD.Consultar();
        this.gvProveedor.DataSource = listaProveedor;
        gvProveedor.DataBind();               
    }

    private void cargarDatos(int itemrow)
    {

        ProveedorBD proveedorBD = new ProveedorBD();
        Proveedor proveedor = new Proveedor();
        int provid = Convert.ToInt32(gvProveedor.Rows[itemrow].Cells[2].Text);
        proveedor = proveedorBD.ConsultarP(provid);
        //texts
        this.txtId.Text = proveedor.Provid.ToString();
        this.txtEmpresa.Text = proveedor.Empresa;
        this.txtNomContac.Text = proveedor.Contacto;
        this.txtCargoContac.Text = proveedor.Cargo;
        this.txtRuc.Text = proveedor.Ruc;
        this.txtDir.Text = proveedor.Dir;
        this.txtFono1.Text = proveedor.Fono1;
        this.txtFono2.Text = proveedor.Fono2;
        this.txtPais.Text = proveedor.Pais;
        this.txtProvincia.Text = proveedor.Provincia;
        this.txtCiudad.Text = proveedor.Ciudad;
        this.txtEmail.Text = proveedor.Email;

        //ddlEstado
        if ((gvProveedor.Rows[itemrow].Cells[7].Text) == "Activo")
        { this.ddlEstado.SelectedIndex = 0; }
        else
        { this.ddlEstado.SelectedIndex = 1; }
    }

    private void ultimoId()
    {
        txtId.Text = lastId().ToString();
    }
    
    private int lastId()
    {
        int lastid;
        if (gvProveedor.Rows.Count != 0)
        {
            //devuelve ultimo proveedor y le suma 1
            lastid = ((Convert.ToInt32(gvProveedor.Rows[gvProveedor.Rows.Count - 1].Cells[2].Text))
                               + 1);
        }
        else
        {
            lastid = 100;
        }
        return lastid;
    }
    private void habilitaControles()
    {
        //activamos campos
        txtEmpresa.Enabled = true;
        txtNomContac.Enabled = true;
        txtCargoContac.Enabled = true;
        txtEmail.Enabled = true;
        txtPais.Enabled = true;
        txtRuc.Enabled = true;
        txtDir.Enabled = true;
        txtFono1.Enabled = true;
        txtFono2.Enabled = true;
        txtProvincia.Enabled = true;
        txtCiudad.Enabled = true;
        //mostrar campos contraseña
        lblClave.Visible = true;
        lblRClave.Visible = true;
        txtClave.Visible = true;
        txtRClave.Visible = true;
        //mostrar opcion de acción
        btnGuardar.Enabled = true;
        btnCancelar.Enabled = true;
        btnNuevo.Enabled = false;
        //focus
        this.txtEmpresa.Focus();
    }

    private void noControles()
    {
        //desactivamos campos
        txtEmpresa.Enabled = false;
        txtNomContac.Enabled = false;
        txtCargoContac.Enabled = false;
        txtEmail.Enabled = false;
        txtPais.Enabled = false;
        txtRuc.Enabled = false;
        txtDir.Enabled = false;
        txtFono1.Enabled = false;
        txtFono2.Enabled = false;
        txtProvincia.Enabled = false;
        txtCiudad.Enabled = false;
        txtEmail.Enabled = false;
        
        ddlEstado.Enabled = false;


        //ocultar campos contraseña
        lblClave.Visible = false;
        lblRClave.Visible = false;
        txtClave.Visible = false;
        txtRClave.Visible = false;
        //mostrar opcion de acción
        btnGuardar.Enabled = false;
        btnCancelar.Enabled = false;
        btnNuevo.Enabled = true;
        //focus
        btnNuevo.Focus();
    }

    private void Limpiar()

    {
        txtId.Text = "";
        txtEmpresa.Text = "";
        txtNomContac.Text = "";
        txtCargoContac.Text = "";
        txtEmail.Text = "";
        txtPais.Text = "";
        txtRuc.Text = "";
        txtDir.Text = "";
        txtFono1.Text = "";
        txtFono2.Text = "";
        txtProvincia.Text = "";
        txtCiudad.Text = "";
        txtClave.Text = "";
        txtRClave.Text = "";
        ddlEstado.SelectedIndex=0;        
    }   


#endregion    
  
}