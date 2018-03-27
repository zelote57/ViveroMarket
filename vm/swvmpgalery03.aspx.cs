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


public partial class swvmpgalery03 : System.Web.UI.Page
{
#region variables

    string strPaginacion = string.Empty;
    string strQuery = string.Empty;
    string strQueryCount = string.Empty;
    string strTabla = string.Empty;
    string strUrl = string.Empty;
    string strOrder = string.Empty;
    string strOQuery = string.Empty;
#endregion


    protected void Page_Load(object sender, EventArgs e)
    {        
        if (!Page.IsPostBack)
        {
            Session["page"] = "galery";
            cargarProd();
        }        
    }

    protected void dlGalery_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Header)
        {
            Label lbl = (Label)e.Item.FindControl("lblCuenta");
            lbl.Text = Count().ToString();            
        }
    }

    #region Funciones

    private void cargarProd() 
    {
        getParametros();

        BD bd = new BD();
        string cadena = bd.Cadena;
        SqlConnection cn = new SqlConnection(cadena);
        SqlCommand cmd = new SqlCommand
            (strQuery, cn);
        SqlDataAdapter da = default(SqlDataAdapter);
        DataSet ds = default(DataSet);
        DataTable dt = default(DataTable);
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        dt = new DataTable(strTabla);
        ds.Tables.Add(dt);
        da.Fill(ds, 0, Count(), strTabla);
        dlGalery.DataSource = dt.DefaultView;        

        
        PagedDataSource objPds = new PagedDataSource();
        objPds.DataSource = ds.Tables[0].DefaultView;
        objPds.AllowPaging = true;
        objPds.PageSize = 10;        

        int CurPage;

        if (Request.QueryString["IDP"] != null)
        {
            CurPage = Convert.ToInt32(Request.QueryString["IDP"]);
        }
        else
        {
            CurPage = 1;
        }

        objPds.CurrentPageIndex = CurPage - 1;
        strPaginacion = "";

        int Order;

        if (Request.QueryString["O"] != null)
        {
            Order = Convert.ToInt32(Request.QueryString["O"]);
        }
        else
        {
            Order = 1;
        }

        if (!objPds.IsFirstPage)
        {
            strPaginacion = "<a href='swvmpgalery03.aspx?IGP="+strUrl+"&O="+Order.ToString()+"&IDP="
                + Convert.ToString(CurPage - 1) + "' >&lt;&lt; anterior</a>";
        }

        if (objPds.PageCount > 0)
        {
            strPaginacion += "<span> (pagina "
                + CurPage.ToString() + " de " + objPds.PageCount.ToString() + ")</span> ";
        }

        if (objPds.PageCount > 1)
        {
            if (!objPds.IsLastPage)
                strPaginacion += "<a href='swvmpgalery03.aspx?IGP=" + strUrl + "&O=" + Order.ToString() + "&IDP="
                    + Convert.ToString(CurPage + 1) + "' >siguiente &gt;&gt;</a>";
        }

        dlGalery.DataSource = objPds;

        dlGalery.DataBind();
    }

    protected string GetPaginacion()
    {
        return (strPaginacion);
    }

    protected string GetUrl()
    {
        return (strTabla);
    }

    protected string GetOrder()
    {
        strOrder = "";
        strOrder = "<a href='swvmpgalery03.aspx?IGP=" + strUrl + "&O=1' class='name'> Nombre <a/> · "
                    + "<a href='swvmpgalery03.aspx?IGP=" + strUrl + "&O=2'class='pmin'> Menor Precio <a/> · "
                    + "<a href='swvmpgalery03.aspx?IGP=" + strUrl + "&O=3'class='pmax'> Mayor Precio <a/>";
        return (strOrder);
    }

    private int Count()
    {
        BD bd = new BD();
        string cadena = bd.Cadena;
        SqlConnection cn = new SqlConnection(cadena);
        SqlCommand cmd = new SqlCommand
            (strQueryCount, cn);
        // Abrimos la conexión
        cn.Open();
        // Si devuelve algun valor, es que ya existe
        int i = (int)cmd.ExecuteScalar();
        return i;
    }    

    private void getParametros() 
    {
        int Order;

        if (Request.QueryString["O"] != null)
        {
           Order = Convert.ToInt32(Request.QueryString["O"]);
        }
        else
        {
            Order = 1;
        }

        strOQuery = "";
        switch (Order)
        {
            case 1:
                strOQuery = "SWVM04PROD_NOMBRE";
                break;
            case 2:
                strOQuery = "SWVM04PRECIO ASC";
                break;
            case 3:
                strOQuery = "SWVM04PRECIO DESC";
                break;
            default:
                strOQuery = "SWVM04PROD_NOMBRE";
                break;
        }

        strQuery = "";
        strQueryCount = "";
        strTabla = "";
        strUrl = "";

        /*Galery Page contiene segun Categoria las sgts paginas         
         * :1=Flores
         * :2=Medicinales
         * :3=Frutales
         * :4=Bonsai
         * :5=Tropicales
         * :6=Semillas
         */
        int galeryPage;

        if (Request.QueryString["IGP"] != null)
        {
            galeryPage = Convert.ToInt32(Request.QueryString["IGP"]);
        }
        else
        {
            galeryPage = 1;
        }

        switch (galeryPage)
        {
            case 1://Flores
                strQuery = "SELECT * FROM SWVMMPRODUCTO04 WHERE "
                    + "(SWVM04CATE_ID = " + galeryPage.ToString() + ") ORDER BY " + strOQuery;
                strQueryCount = "SELECT COUNT(*) FROM SWVMMPRODUCTO04 "
                    +"WHERE (SWVM04CATE_ID = " + galeryPage.ToString() + ")";
                strTabla = "flores";
                strUrl = galeryPage.ToString();
                break;
            case 2://Medicinales
                strQuery = "SELECT * FROM SWVMMPRODUCTO04 WHERE "
                    + "(SWVM04CATE_ID = " + galeryPage.ToString() + ") ORDER BY " + strOQuery;
                strQueryCount = "SELECT COUNT(*) FROM SWVMMPRODUCTO04 "
                    + "WHERE (SWVM04CATE_ID = " + galeryPage.ToString() + ")";
                strTabla = "medicinales";
                strUrl = galeryPage.ToString();
                break;
            case 3://Frutales
                strQuery = "SELECT * FROM SWVMMPRODUCTO04 WHERE "
                    + "(SWVM04CATE_ID = " + galeryPage.ToString() + ") ORDER BY " + strOQuery;
                strQueryCount = "SELECT COUNT(*) FROM SWVMMPRODUCTO04 "
                    + "WHERE (SWVM04CATE_ID = " + galeryPage.ToString() + ")";
                strTabla = "frutales";
                strUrl = galeryPage.ToString();
                break;
            case 4://Bonsai
                strQuery = "SELECT * FROM SWVMMPRODUCTO04 WHERE "
                    + "(SWVM04CATE_ID = " + galeryPage.ToString() + ") ORDER BY " + strOQuery;
                strQueryCount = "SELECT COUNT(*) FROM SWVMMPRODUCTO04 "
                    + "WHERE (SWVM04CATE_ID = " + galeryPage.ToString() + ")";
                strTabla = "bonsai";
                strUrl = galeryPage.ToString();
                break;
            case 5://Tropicales
                strQuery = "SELECT * FROM SWVMMPRODUCTO04 WHERE "
                    + "(SWVM04CATE_ID = " + galeryPage.ToString() + ") ORDER BY " + strOQuery;
                strQueryCount = "SELECT COUNT(*) FROM SWVMMPRODUCTO04 "
                    + "WHERE (SWVM04CATE_ID = " + galeryPage.ToString() + ")";
                strTabla = "tropicales";
                strUrl = galeryPage.ToString();
                break;
            case 6://Semillas
                strQuery = "SELECT * FROM SWVMMPRODUCTO04 WHERE "
                    + "(SWVM04CATE_ID = " + galeryPage.ToString() + ") ORDER BY " + strOQuery;
                strQueryCount = "SELECT COUNT(*) FROM SWVMMPRODUCTO04 "
                    + "WHERE (SWVM04CATE_ID = " + galeryPage.ToString() + ")";
                strTabla = "semillas";
                strUrl = galeryPage.ToString();
                break;
            default:
                strQuery = "SELECT * FROM SWVMMPRODUCTO04 WHERE "
                    + "(SWVM04CATE_ID = " + galeryPage.ToString() + ") ORDER BY " + strOQuery;
                strQueryCount = "SELECT COUNT(*) FROM SWVMMPRODUCTO04 "
                    + "WHERE (SWVM04CATE_ID = " + galeryPage.ToString() + ")";
                strTabla = "flores";
                strUrl = galeryPage.ToString();
                break;
        }

    }
    #endregion
}
