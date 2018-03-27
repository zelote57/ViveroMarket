using System;
using System.Data;
using System.Configuration;
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

public partial class swvmilogin01 : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {        
        lblError.Text = "";
        lblError.Visible = false;        
            //Evita que usuario logado vuelva a ver la pagina login
            string login = "";
            login = Convert.ToString(Session["login"]);
            if (login == "true")
            {
                //Redireccionamos a area de administración
                Response.Redirect("default.aspx");
            }
            if (!Page.IsPostBack)
            {
                Session["login"] = "false";
            }
    }
    protected void LoginButton_Click(object sender, EventArgs e)
    {
        lblError.Text = "";
        lblError.Visible = false;
        //capturamos datos en objeto genericuser para verificar si es usuario
        Usuario genericuser = creauUI();
        //Instaciamos un usuario para recibir datos
        Usuario user = new Usuario();
        //Instanciamos primero a usuarioBD para acceder a sus metodos
        UsuarioBD usuarioBD = new UsuarioBD();
        user = usuarioBD.Sesion(genericuser);
        if (user.Userid != 0)
        {
            Session["login"] = "true";//bandera que controla sesion activa
            FormsAuthentication.RedirectFromLoginPage(txtUser.Text, false);
            Session["userid"] = user.Userid.ToString();
            Session["usuario"] = user.Nombre;
            Session["empresa"] = "vivero market | " + user.Cargo + " departamento: "
                                + user.Departamento;
            Session["tipo"] = "AG";//especifica que es aministrador general
        }
        else
        {
            //capturamos datos en objeto genericprov para verificar si es proveedor
            Proveedor genericprov = creapUI();
            //Instaciamos un proveedor para recibir datos
            Proveedor provider = new Proveedor();
            //Instanciamos luego a proveedorBD para acceder a sus metodos
            ProveedorBD proveedorBD = new ProveedorBD();
            provider = proveedorBD.Sesion(genericprov);
            if (provider.Provid != 0)
            {
                Session["login"] = "true";//bandera que controla sesion activa
                FormsAuthentication.RedirectFromLoginPage(txtUser.Text, false);

                Session["userid"] = provider.Provid.ToString();
                Session["empresa"] = provider.Empresa;
                Session["usuario"] = provider.Contacto;
                Session["tipo"] = "P";//esticifica que es aministrador de tipo proveedor
            }
            else
            {
                Session["login"] = "false"; // sino.. a la de error de login
                lblError.Visible = true;
                lblError.Text = "Acceso no autorizado"
                    + "<br/><a class='cerrarsesion' href='swvmmrecoverypass00.aspx' target='_blank'> ¿Recuperar Contraseña?</a>";
            }
        }
    }

    #region Funciones

    private Usuario creauUI()
    {
        Usuario genericuser = new Usuario();
        genericuser.Email = txtUser.Text;
        //Clave encriptada        
        Funciones f = new Funciones();
        string clave = f.encriptar(txtClave.Text);
        genericuser.Clave = clave;
        return genericuser;
    }

    private Proveedor creapUI()
    {
        Proveedor genericprov = new Proveedor();
        genericprov.Email = txtUser.Text;
        //Clave encriptada
        Funciones f = new Funciones();
        string clave = f.encriptar(txtClave.Text);
        genericprov.Clave = clave;
        return genericprov;
    }
    #endregion

}
