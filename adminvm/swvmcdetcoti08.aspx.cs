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

public partial class swvmcdetcoti08 : System.Web.UI.Page
{    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string tipo = "";
            tipo = Convert.ToString(Session["tipo"]);
            if (tipo == "AG")
            {
                loadNumero();
                loadCliente();
                llenarGrid();
            }
            else
            {
                Response.Redirect("default.aspx");
            }
        }
    } 
    
#region Funciones    

    private void loadCliente()
    {
        //coizacion id (cid)
        int cid = loadParametros();
        //obtenemos cabecera de cotizacion, para usar clienteid
        CotizaBD ctzaBD = new CotizaBD();
        CotizaCab cabecera = ctzaBD.ConsultarCab(cid);
        //consultamos cliente
        ClienteBD cBD = new ClienteBD();
        Cliente cliente= cBD.ConsultarC(cabecera.Cliid);

        lblCliente.Text = cliente.Nombre;
        lblFecha.Text = cabecera.Fecha.ToShortDateString().ToString();
        lblCiruc.Text = cliente.Ciruc;
        lblFono.Text = cliente.Fono1;
        lblDir.Text = cliente.Dir;
    }

    private void llenarGrid()
    {
        int cid=loadParametros();
        CotizaBD cBD = new CotizaBD();
        List<ReporteDetalleCotiza> detalle = cBD.ReporteDetCotiza(cid);
        gvDetalle.DataSource = detalle;
        gvDetalle.DataBind();
        Calculo();
    }

    private int loadParametros()
    {
        int cid = 0;
        //obtenemos parametro que nos devuelve el numero de cotizacion a consultar
        if (Request.QueryString["CID"] != null)
        {
            cid = Convert.ToInt32(Request.QueryString["CID"]);
        }
        else
        {
            Response.Redirect("swvmcreportcoti07.aspx");
        }
        return cid;
    }

    private void Calculo()
    {
        //coizacion id (cid)
        int cid = loadParametros();
        //obtenemos cabecera de cotizacion, para usar total y formar el calculo
        CotizaBD ctzaBD = new CotizaBD();
        CotizaCab cabecera = ctzaBD.ConsultarCab(cid);
        //llenamos resultados
        lblTotal.Text = Convert.ToString(Math.Round(cabecera.Total, 2));
        lblSt.Text = Convert.ToString(Math.Round(cabecera.Total / Convert.ToDecimal(1.12), 2));
        lblIva.Text = Convert.ToString(Math.Round(decimal.Parse(lblSt.Text) * Convert.ToDecimal(0.12), 2));
    }
    
    private void loadNumero()
    {
        int cid = loadParametros();
        lblLastcotiza.Text = "Cotización # "+Convert.ToString(cid);
    }
#endregion    
}
