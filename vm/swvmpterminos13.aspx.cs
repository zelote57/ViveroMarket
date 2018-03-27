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
using DAL;
using DAL.Entidades;

public partial class swvmpterminos13 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["page"] = "terminos";
        loadContent();
    }

    #region Funciones

    private void loadContent()
    {
        PaginaBD pBD = new PaginaBD();
        Pagina page = pBD.ConsultarP(4);//numero de pagina a mostar pgaid = 4 terminos
        lblContent.Text = page.Content;
    }

    #endregion
}
