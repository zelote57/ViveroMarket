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

public partial class swvmmmantclie04 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
         if (!Page.IsPostBack)
        {
            string tipo = "";
            tipo = Convert.ToString(Session["tipo"]);
            if (tipo == "AG")
            {
                llenarClientes();
                ultimoId();
            }                
            else
            {
                Response.Redirect("default.aspx");
            }
        }
    }

    /*Boton editar del Grid*/
    protected void gvCliente_RowEditing(object sender, GridViewEditEventArgs e)
    {
        lblMensaje.Text = "";
        ddlEstado.Enabled = true;
        //cargamos datos segun fila seleccionada del gridCliente
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
        Cliente cliente = creaUI();
        ClienteBD clienteBD = new ClienteBD();
        //validamos repetición contraseña y ruc
        if (cvRClave.IsValid == true && cvCiruc.IsValid == true)
        {
            /*Flag respuesta*/
            string flag;
            flag = clienteBD.ExisteCliente(cliente);
            if (flag == "0")//no existe
            {
                //por v= Insercion; por f= actualizacion           
                if (txtId.Text == lastId().ToString())
                {
                    clienteBD.Insertar(cliente);
                    lblMensaje.Text = "Registro Exitoso";
                }
                else
                {
                    clienteBD.Actualizar(cliente);
                    lblMensaje.Text = "Actualización Exitosa";
                }
                llenarClientes();
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
    protected void gvCliente_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string msg;
        lblMensaje.Text = "";        
        //eliminamos datos segun fila seleccionada del gridCliente
        int cliid = Convert.ToInt32(gvCliente.Rows[(Convert.ToInt32(e.RowIndex))].Cells[2].Text);
        //instanciamos ClienteBD para acceder al metodo eliminar
        ClienteBD clienteBD = new ClienteBD();
        msg = clienteBD.Eliminar(cliid);
        lblMensaje.Text = msg;
        //recargar pagina
        llenarClientes();
        Limpiar();
        ultimoId();
        noControles();       
    }
    protected void cvRucC_ServerValidate(object source, ServerValidateEventArgs args)
    {
        Valida valida = new Valida();
        //valida de 10 a 13 digitos
        if ((this.txtCiruc.Text.Length) > 10 && (this.txtCiruc.Text.Length) < 13)
        {
            args.IsValid = false;
            cvCiruc.ErrorMessage = "Error Ci/Ruc solo acepta 10 o 13 dígitos respectivamente";
        }
        else
        {//valida cedula implicita en el ruc
            string msg = "";
            msg = valida.Cedula(this.txtCiruc.Text);
            if (msg != "true") { args.IsValid = false; cvCiruc.ErrorMessage = msg; } else { args.IsValid = true; }
        }
    }

#region Funciones

    
    private Cliente creaUI()
    {
        Cliente clie = new Cliente();
        clie.Cliid = Convert.ToInt32(txtId.Text);
        clie.Nombre = txtNombre.Text;
        clie.Dir = txtDir.Text;
        clie.Ciruc = txtCiruc.Text;
        clie.Provincia = txtProvincia.Text;
        clie.Ciudad = txtCiudad.Text;
        clie.Fono1 = txtFono1.Text;
        clie.Fono2 = txtFono2.Text;
        clie.Email = txtEmail.Text;
        if (ddlEstado.SelectedIndex == 0) { clie.Estado = "A"; } else { clie.Estado = "I"; }
        //Clave encriptada
        Funciones f = new Funciones();
        string clave = f.encriptar(txtClave.Text);
        clie.Clave = clave;       
        return clie;
    }

    
    private void llenarClientes()

    {
        ClienteBD clienteBD = new ClienteBD();
        List<Cliente> listacliente = clienteBD.Consultar();
        this.gvCliente.DataSource = listacliente;
        gvCliente.DataBind();               
    }

   
    private void cargarDatos(int itemrow)
    {

        ClienteBD clienteBD = new ClienteBD();
        Cliente cliente = new Cliente();
        int cliid = Convert.ToInt32(gvCliente.Rows[itemrow].Cells[2].Text);
        cliente = clienteBD.ConsultarC(cliid);
        //texts
        this.txtId.Text = cliente.Cliid.ToString();
        this.txtNombre.Text = cliente.Nombre;
        this.txtDir.Text = cliente.Dir;
        this.txtCiruc.Text = cliente.Ciruc;
        this.txtProvincia.Text = cliente.Provincia;
        this.txtCiudad.Text = cliente.Ciudad;
        this.txtFono1.Text = cliente.Fono1;
        this.txtFono2.Text = cliente.Fono2;
        this.txtEmail.Text = cliente.Email;
      
        //ddlEstado
        if ((gvCliente.Rows[itemrow].Cells[7].Text) == "Activo")
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
        if (gvCliente.Rows.Count != 0)
        {
            //devuelve ultimo cliente y le suma 1
            lastid = ((Convert.ToInt32(gvCliente.Rows[gvCliente.Rows.Count - 1].Cells[2].Text))
                               + 1);
        }
        else
        {
            lastid = 1000;
        }
        return lastid;
    }

    private void habilitaControles()
    {
        //activamos campos
        txtNombre.Enabled = true;
        txtDir.Enabled = true;
        txtCiruc.Enabled = true;
        txtProvincia.Enabled = true;
        txtCiudad.Enabled = true; 
        txtFono1.Enabled = true;
        txtFono2.Enabled = true;
        txtEmail.Enabled = true;
        
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
        this.txtNombre.Focus();
    }

    private void noControles()
    {
        //desactivamos campos
        txtNombre.Enabled = false;
        txtDir.Enabled = false;
        txtCiruc.Enabled = false;
        txtProvincia.Enabled = false;
        txtCiudad.Enabled = false;
        txtFono1.Enabled = false;
        txtFono2.Enabled = false;
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
        txtNombre.Text = "";
        txtDir.Text = "";
        txtCiruc.Text = "";
        txtProvincia.Text = "";
        txtCiudad.Text = "";
        txtFono1.Text = "";
        txtFono2.Text = "";
        txtEmail.Text = "";
        txtClave.Text = "";
        txtRClave.Text = "";
        ddlEstado.SelectedIndex=0;        
    }   


#endregion    
   
}