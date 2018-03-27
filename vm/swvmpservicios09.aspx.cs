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

public partial class swvmpservicios09 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["page"] = "servicios";
        loadContent();
    }

    #region Funciones

    private void loadContent()
    {        
        PaginaBD pBD = new PaginaBD();
        Pagina page = pBD.ConsultarP(3);//numero de pagina a mostar pgaid = 3 servicios
        lblContent.Text = page.Content;
    }

    #endregion
}
