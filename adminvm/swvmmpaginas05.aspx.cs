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

public partial class swvmmpaginas05 : System.Web.UI.Page
{
    int pagid;
    protected void Page_Load(object sender, EventArgs e)
    {        
        if (!Page.IsPostBack)
        {            
            loadPaginas();            
        }
    }

    protected void btnEditar_Click(object sender, EventArgs e)
    {
        getPagid();
        if (pagid != 0)//sino es NINGUNA
        {
            loadContent();
            habilitaControles();            
        }
        else
        {
            ftbEditor.Text = "Debe seleccionar una página para editar.";
        }
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        getPagid();        
        loadContent();
        noControles();        
    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        Pagina page = creaUI();
        PaginaBD pBD = new PaginaBD();
        pBD.Actualizar(page);
        noControles();        
    }

    protected void ddlPaginas_SelectedIndexChanged(object sender, EventArgs e)
    {
        getPagid();        
        loadContent();
    }

    #region Funciones

    private void loadPaginas()
    {
        PaginaBD pBD = new PaginaBD();
        List<Pagina> listpag = pBD.Consultar();
        ddlPaginas.DataSource = listpag;        
        DataBind();
    }

    private Pagina creaUI()
    {
        getPagid();
        int userid = int.Parse(Convert.ToString(Session["userid"]));
        Pagina page = new Pagina();
        page.Pagid = pagid;
        page.Content = ftbEditor.Text;
        page.Userid = userid;     
        return page;
    }

    private void loadContent()
    {        
        if (pagid != 0)//sino es NINGUNA
        {
            PaginaBD pBD = new PaginaBD();
            Pagina p = pBD.ConsultarP(pagid);
            ftbEditor.Text = p.Content;
            lblDescripcion.Visible = true;
            lblDescripcion.Text = p.Descripcion;
        }
        else
        {
            lblDescripcion.Visible = false;
            lblDescripcion.Text = "";
            ftbEditor.Text = "";
        }
    }

    private void habilitaControles()
    {
        ftbEditor.ReadOnly = false;
        btnEditar.Enabled = false;
        btnGuardar.Enabled = true;
        btnCancelar.Enabled = true;
        ddlPaginas.Enabled = false;
    }

    private void noControles()
    {
        ftbEditor.ReadOnly = true;
        btnEditar.Enabled = true;
        btnGuardar.Enabled = false;
        btnCancelar.Enabled = false;
        ddlPaginas.Enabled = true;
    }

    private void getPagid()
    {
        pagid = int.Parse(ddlPaginas.SelectedValue.ToString());
    }

    #endregion 
}
