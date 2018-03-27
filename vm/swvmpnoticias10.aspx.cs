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
using System.Xml;

public partial class swvmpnoticias10 : System.Web.UI.Page
{
    string strPaginacion = string.Empty;
    string strError = string.Empty;
    XmlTextReader rssReader;
    XmlDocument rssDoc;
    XmlNode nodeRss;
    XmlNode nodeChannel;
    XmlNode nodeItem;    

    protected void Page_Load(object sender, EventArgs e)
    {
        Session["page"] = "noticias";
        loadRss();
        if (strError == "")
        {
            showRss();
        }
        else
        {
            dlRss.Visible = false;//ocultar data list
            lblError.Visible = true;//mostrar label error
            lblError.Text = strError;
        }
    }

    protected string GetPaginacion()
    {
        return (strPaginacion);
    }

    #region Funciones

    private void loadRss()
    {
        rssReader = new XmlTextReader("http://www.plantas-flores.com/index.php?tempskin=_rss2");
        rssDoc = new XmlDocument();
        //validacion en caso de error en carga del xml
        try
        {
            // Load the XML content into a XmlDocument
            rssDoc.Load(rssReader);
        }
        catch (Exception ex)
        {
            strError = "Error de Sindicación por favor contactar "
                +"al administrador webmaster@viveromarket.com <br/> <br/>"
                        + ex.Message.ToString();
        }
    }

    private void showRss()
    {
        //recorremos el documento xml
        // Loop for the <rss> tag
        for (int i = 0; i < rssDoc.ChildNodes.Count; i++)
        {
            // If it is the rss tag
            if (rssDoc.ChildNodes[i].Name == "rss")
            {
                // <rss> tag found
                nodeRss = rssDoc.ChildNodes[i];
            }
        }

        // Loop for the <channel> tag
        for (int i = 0; i < nodeRss.ChildNodes.Count; i++)
        {
            // If it is the channel tag
            if (nodeRss.ChildNodes[i].Name == "channel")
            {
                // <channel> tag found
                nodeChannel = nodeRss.ChildNodes[i];
            }
        }

        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("titulo", typeof(string)));
        dt.Columns.Add(new DataColumn("link", typeof(string)));
        dt.Columns.Add(new DataColumn("fecha", typeof(string)));
        dt.Columns.Add(new DataColumn("detalle", typeof(string)));

        // Loop through all the nodes under <channel>
        for (int i = 0; i < nodeChannel.ChildNodes.Count; i++)
        {
            // Until you find the <item> node
            if (nodeChannel.ChildNodes[i].Name == "item")
            {
                // Store the item as a node
                nodeItem = nodeChannel.ChildNodes[i];
                // It's the item we were looking for, get the description
                dr = dt.NewRow();
                dr["titulo"] = nodeItem["title"].InnerText;                
                dr["link"] = nodeItem["link"].InnerText;                
                dr["fecha"] = Convert.ToDateTime(nodeItem["pubDate"].InnerText).ToLongDateString();
                dr["detalle"] = nodeItem["description"].InnerText;
                dt.Rows.Add(dr);
            }
        }

        //paginacion
        PagedDataSource objPds = new PagedDataSource();

        objPds.DataSource = dt.DefaultView;
        objPds.AllowPaging = true;
        objPds.PageSize = 3;

        int CurPage;

        if (Request.QueryString["IDP"] != null)
            CurPage = Convert.ToInt32(Request.QueryString["IDP"]);
        else
            CurPage = 1;

        objPds.CurrentPageIndex = CurPage - 1;
        strPaginacion = "";

        if (!objPds.IsFirstPage)
            strPaginacion = "<a href='swvmpnoticias10.aspx?IDP=" + Convert.ToString(CurPage - 1) + "' >&lt;&lt; anterior</a>";

        if (objPds.PageCount > 0)
            strPaginacion += "<span> (página " + CurPage.ToString() + " de " + objPds.PageCount.ToString() + ")</span> ";

        if (objPds.PageCount > 1)
            if (!objPds.IsLastPage)
                strPaginacion += "<a href='swvmpnoticias10.aspx?IDP=" + Convert.ToString(CurPage + 1) + "' >siguiente &gt;&gt;</a>";
               
        dlRss.DataSource = objPds;
        DataBind();
    }

    #endregion
}
