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

public partial class cotiza : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string sesion = Convert.ToString(Session["login"]);
        if (sesion == "true")
        {
            Funciones f = new Funciones();
            if (!Page.IsPostBack)
            {
                lblFecha.Text = DateTime.Now.ToLongDateString();
                this.lblUsuario.Text = "Bienvenido " 
                + f.Mayus(Convert.ToString(Session["nombres"]) + " | ");//asigna nombre
            }
        }
        else
        {
            Response.Redirect("swvmphome01.aspx");
        }

    }
    protected void btnCerrarSesion_Click(object sender, EventArgs e)
    {
        Session["login"] = "false";
        Session["mycart"] = null;
        //FormsAuthentication.SignOut();
        Response.Redirect("swvmphome01.aspx");
    }
}
