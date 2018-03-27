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


public partial class index : System.Web.UI.MasterPage
{
    string page = string.Empty;
    protected override void AddedControl(Control control, int index)
    {
        // This is necessary because Safari and Chrome browsers don't display the Menu control correctly.
        // Add this to the code in your master page.
        if (Request.ServerVariables["http_user_agent"].IndexOf("Safari", StringComparison.CurrentCultureIgnoreCase) != -1)
            this.Page.ClientTarget = "uplevel";

        base.AddedControl(control, index);
    }


    protected void Page_Load(object sender, EventArgs e)
    {        
        Funciones funciones = new Funciones();
        LabelFecha.Text = DateTime.Now.ToLongDateString();
            if (!Page.IsPostBack)
            {
                string sesion = Convert.ToString(Session["login"]);
                if (sesion == "true")
                {
                    this.pLogin.Visible = false;
                    this.lblMensaje.Text = "Bienvenido " + funciones.Mayus(Convert.ToString(Session["nombres"]));
                    Status.Visible = true;
                }                
            }
    }

    protected void btnAcceder_Click(object sender, EventArgs e)
    {
        Funciones funciones = new Funciones();

        /*capturamos datos en objeto cliente*/
        Cliente cliente = creaUI();
        /*Objeto cliente devuelve datos de la base*/
        Cliente customer = new Cliente();
        /*Instanciamos clienteBD para acceder a sus metodos*/
        ClienteBD clienteBD = new ClienteBD();
        customer = clienteBD.Sesion(cliente);

        if (customer.Cliid != 0 )
        {
            Session["login"] = "true";//bandera que controla sesion activa
            Session["nombres"] = customer.Nombre;
            Session["cliid"] = customer.Cliid;
            this.lblError.Visible = false;
            this.lblMensaje.Text = "";//limpia label
            this.lblMensaje.Visible = true;//mostrar label nombre del usuario activo
            this.lblMensaje.Text = "Bienvenido " 
                + funciones.Mayus(Convert.ToString(Session["nombres"]));//asigna nombre
            this.pLogin.Visible = false;//ocultar panel de inicio de sesion
            Status.Visible = true;//mostar boton cerrar sesion
            //Response.Redirect(Request.Url.ToString());
            page = Session["page"].ToString();
            if (page == "cart")
            {
                Response.Redirect("swvmicart05.aspx");
            }
        }

        else
        {
            Session["login"] = "false";
            this.lblError.Visible = true;
            this.lblError.Text = "";//limpia label            
            this.lblError.Text ="Email o Contraseña invalida"
                + "<br/><a class='recovery' href='swvmmrecoverypass12.aspx' target='_blank'> Recuperar Contraseña</a>";
            this.lblError.Visible = true;//mostrar label nombre del usuario activo            
        }
    }

    protected void Status_Click(object sender, EventArgs e)
    {
        Session["login"] = "false"; //establece valor false en la bandera sesion del login
        this.pLogin.Visible = true; //muestra panel de inicio de sesion
        this.lblMensaje.Text = ""; //limpia label con nombre del usuario
        this.lblMensaje.Visible = false; //oculta label del nombre del usuario
        Status.Visible = false;
        Session["mycart"] = null;        
        page = Session["page"].ToString();
        if (page == "cart")
        {
            Response.Redirect("swvmicart05.aspx");
        }        
    }

    #region Funciones

    private Cliente creaUI()
    {
        Cliente cliente = new Cliente();
        cliente.Email = txtUser.Text;
        //Clave encriptada        
        Funciones f = new Funciones();
        string clave = f.encriptar(txtClave.Text);
        cliente.Clave = clave;
        return cliente;
    }


    #endregion
}
