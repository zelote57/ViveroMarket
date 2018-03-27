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

public partial class swvmmrecoverypass12 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void bntEnviar_Click(object sender, EventArgs e)
    {
        SendEmail semail = new SendEmail();
        lblMsg.Text = semail.EnviarPass(txtEmail.Text);
    }
}
