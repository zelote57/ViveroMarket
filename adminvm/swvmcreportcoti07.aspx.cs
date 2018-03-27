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

public partial class swvmcreportcoti07 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string tipo = "";
            tipo = Convert.ToString(Session["tipo"]);
            if (tipo == "AG")
            {
                llenarCotizaciones();
            }
            else
            {
                Response.Redirect("default.aspx");
            }
        }
    }

    protected void gvCotiza_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvCotiza.PageIndex = e.NewPageIndex;
        llenarCotizaciones();
    }
    protected void rblVer_SelectedIndexChanged(object sender, EventArgs e)
    {
        llenarCotizaciones();
    }


    #region Funciones

    private void llenarCotizaciones()
    {
        int tipo= int.Parse(rblVer.SelectedValue.ToString());
        CotizaBD ctzaBD = new CotizaBD();
        List<ReporteCotiza> listaCotizaciones = ctzaBD.ReporteCotiza(tipo);

        if (listaCotizaciones.Count != 0)
        {
            vaciarGrid();
            lblMensaje.Text = "";
            this.gvCotiza.DataSource = listaCotizaciones;
            gvCotiza.DataBind();
        }
        else
        {
            vaciarGrid();
            lblMensaje.Text = "No hay Cotizaciones";
        }
    }

    private void vaciarGrid()
    {
        gvCotiza.DataSource = null;
        gvCotiza.DataBind();
    }

    #endregion
}
