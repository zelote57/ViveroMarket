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

using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using System.IO;

using System.Collections.Generic;
using System.Text;
using DAL;
using DAL.Entidades;

using System.Data.SqlClient;
using System.Security.Cryptography;

public partial class swvmpcotizacion06 : System.Web.UI.Page
{    
    protected void Page_Load(object sender, EventArgs e)
    {
        string sesion = Convert.ToString(Session["login"]);
        if (sesion == "true")
        {
            if (!Page.IsPostBack)
            {
                Session["page"] = "cotizacion";
                loadCliente();
                llenarGrid();
            }
        }
        else
        {
            Response.Redirect("swvmphome01.aspx");
        }
    }

    protected void lknAceptar_Click(object sender, EventArgs e)
    {
        ActualizaStock();
        bool flag;        
        Grabar();
        //instacias para consultar metodos
        Pdf pdf = new Pdf();
        SendEmail secot = new SendEmail();
        int cliid = int.Parse(Session["cliid"].ToString());
        ClienteBD cBD = new ClienteBD();
        //consultar cliente para encontrar email
        Cliente cliente= cBD.ConsultarC(cliid);
        //crear pdf de la cotizacion
        pdf.Makepdf(int.Parse(lblLastcotiza.Text.Substring(13)), Server.MapPath("temp/"));
        //enviar archivo pdf de la cotizacion por correo
        flag = secot.EnviarCot(int.Parse(lblLastcotiza.Text.Substring(13)), cliente.Email, Server.MapPath("temp/"));
        //eliminar el pdf de la carpeta temporal
        //File.Delete(Server.MapPath("temp/") + lblLastcotiza.Text.Substring(13)+".pdf");
        //vaciar sesion carrito de compras
        Session["mycart"] = null;
        Mensaje(flag);
    }

#region Funciones    

    private void loadCliente()
    {
        int cliid = int.Parse(Session["cliid"].ToString());
        ClienteBD cBD = new ClienteBD();
        Cliente cliente= cBD.ConsultarC(cliid);

        lblCliente.Text = cliente.Nombre;
        lblFecha.Text = DateTime.Now.ToShortDateString().ToString();
        lblCiruc.Text = cliente.Ciruc;
        lblFono.Text = cliente.Fono1;
        lblDir.Text = cliente.Dir;
    }

    private void llenarGrid()
    {
        lastCotiza();
        ArrayList items = (ArrayList)Session["mycart"];
        gvDetalle.DataSource = items;
        gvDetalle.DataBind();
        Calculo();        
    }  

    private void Calculo()
    {
        if (Session["mycart"] != null)
        {
            ArrayList arr = (ArrayList)Session["mycart"];
            decimal st, iva, total;
            st = 0;
            //For para barrer el arreglo y obtener calculos
            for (int i = 0; i < arr.Count; i++)
            {
                st = st + ((ItemCart)arr[i]).SubTotal;
            }
            iva = st * Convert.ToDecimal(0.12);
            total = st + iva;

            lblSt.Text = st.ToString();

            lblIva.Text = Math.Round(iva, 2).ToString();
            lblTotal.Text = Math.Round(total, 2).ToString();            
        }
    }

    private void lastCotiza()
    {
        CotizaBD cBD = new CotizaBD();
        int cotiid = cBD.LastCotiza();
        lblLastcotiza.Text = "Cotización # "+Convert.ToString(cotiid + 1);
    }

    private void Grabar()
    {
        int cliid = int.Parse(Session["cliid"].ToString());
        CotizaBD cBD = new CotizaBD();
        int cotiid = cBD.LastCotiza()+1;
        CotizaCab cCab = new CotizaCab();
        CotizaDet cDet = new CotizaDet();
        //llenamos cabecera con datos de formulario        
        cCab.Cotiid = cotiid;
        cCab.Cliid = cliid;
        cCab.Total = decimal.Parse(lblTotal.Text);
        cCab.Estado = "A";        
        //insertamos cabecera en tabla
        cBD.InsertCab(cCab);
        //foreach para recorrer el grid por filas para posterior insercion del detalle
        foreach (GridViewRow gvd in gvDetalle.Rows)
        {
            //vector codigo que toma el productoid y codigoid combinado
            //funcion split para posteriormente guardar en variables int
            string[] codigo = gvd.Cells[0].Text.ToString().Split('C');
            string[] codigo2 = codigo[1].Split('V');
            int gpid, gcid, gprov;
            //variable para evaluar el arreglo carrito
            gpid = Convert.ToInt32(codigo[0].Substring(1));
            gcid = Convert.ToInt32(codigo2[0]);
            gprov = Convert.ToInt32(codigo2[1]);
            cDet.Cotiid = cotiid;
            cDet.Prodid = gpid;
            cDet.Cateid = gcid;
            cDet.Cantidad = int.Parse(gvd.Cells[2].Text.ToString());
            cDet.Precio = decimal.Parse(gvd.Cells[3].Text.ToString());
            cDet.Subtotal = cDet.Precio * cDet.Cantidad;
            cDet.Iva = cDet.Subtotal * Convert.ToDecimal(0.12);
            cDet.Prov = gprov;
            //insertar detalle en tabla
            cBD.InsertDet(cDet);
        }
    }

    private void ActualizaStock()
    {
        foreach (GridViewRow gvd in gvDetalle.Rows)
        {
            //instanciamos productoBD para acceder a sus metodos
            ProductoBD pBD = new ProductoBD();
            
            //vector codigo que toma el productoid y codigoid combinado
            //funcion split para posteriormente guardar en variables int
            string[] codigo = gvd.Cells[0].Text.ToString().Split('C');
            string[] codigo2 = codigo[1].Split('V');
            int gpid, gcid, gprov;
            //variable para evaluar el arreglo carrito
            gpid = Convert.ToInt32(codigo[0].Substring(1));
            gcid = Convert.ToInt32(codigo2[0]);
            gprov = Convert.ToInt32(codigo2[1]);
            //consultamos stock del producto para luego actualizar
            Producto prod = pBD.Consultar(gpid, gcid, gprov);
            int stock = prod.Stock;
            //tomamos la cantidad que el cliente desea comprar para luego restar y actulizar producto
            int cantidad = int.Parse(gvd.Cells[2].Text.ToString());
            int newstock = stock - cantidad;
            //actualizamos stock en la base a cada producto
            pBD.ActualizaStock(gpid, gcid, gprov, newstock);
        }
    }

    private void Mensaje(bool flag)
    {
        if (flag == true)
        {
            lblTitulo.Text = "¡Felicidades!";
            lblP.Text = "Su cotización a sido procesada correctamente, y a sido enviada " +
                      "a su cuenta de correo electronico con los pasos a seguir para concretar la compra." +
                      "<br />Por favor revise su bandeja de entrada.";
        }
        else
        {
            lblTitulo.Text = "Información";
            lblP.Text = "Su cotización a sido procesada correctamente, pero ha " +
                      "ocurrido un Error en el envío del correo. Nos contactaremos con usted por sus datos";
        }

        pMensaje.Visible = true;
        lblMsgtop.Visible = false;
        lblMsgbottom.Visible = false;
        lknAceptar.Visible = false;
    }

#endregion    
}
