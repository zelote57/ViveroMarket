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
    protected void Page_Load(object sender, EventArgs e)
    {
        Funciones funciones = new Funciones();
        if (!Page.IsPostBack)
        {
            string login = Convert.ToString(Session["login"]);
            if (login == "true")
            {

                lblFecha.Text = DateTime.Now.ToLongDateString();
                this.lblUsuario.Text = "Bienvenido " + funciones.Mayus(Convert.ToString(Session["usuario"]))
                    + " | Empresa: " + funciones.Mayus(Convert.ToString(Session["empresa"])) + " | ";//asigna nombre

                /*Agignación de opciones de menú según tipo de administrador (tabla[usuario/proveedor])*/
                string tipo = "";
                tipo = Convert.ToString(Session["tipo"]);
                if (tipo == "AG")
                {
                    pMenuAdministrador.Visible = true;
                }
                else
                {
                    pMenuProveedor.Visible = true;
                }
            }
            else
            {
                Response.Redirect("swvmilogin01.aspx");
            }
        }

    }
    protected void btnCerrarSesion_Click(object sender, EventArgs e)
    {
        Session["login"] = "false";
        FormsAuthentication.SignOut();
        Response.Redirect("swvmilogin01.aspx");
    }
}
