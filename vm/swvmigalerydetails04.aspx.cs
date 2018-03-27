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

public partial class swvmigalerydetails04 : System.Web.UI.Page
{
    int pid;
    int cid;
    int prov;
    string rutaimg = string.Empty;    

    protected void Page_Load(object sender, EventArgs e)
    {        
        if (!Page.IsPostBack)
        {
            Session["page"] = "galerydetails";
            loadDetalle();
        }
    }

    protected void btnAgregar_Click(object sender, ImageClickEventArgs e)
    {
        loadParametros();
        //valida que el texbox cantidad no este vacio y no sea cero
        if (txtCantidad.Text != "" && int.Parse(txtCantidad.Text) != 0)
        {
            int qty = int.Parse(txtCantidad.Text);

            bool resp = checkStock(qty);
            if (resp == true)
            {
                lblNoStock.Visible = false;
                Response.Redirect("swvmicart05.aspx?PID=" + pid.ToString() +
                    "&CID=" + cid.ToString() +"&PROV=" + prov.ToString()+ "&Q=" + qty.ToString());
            }
            else
            {
                lblNoStock.Visible = true;
            }
        }
        else
        {
            Response.Redirect(Request.Url.ToString());
        }


    }

    #region Funciones

    private void loadDetalle() 
    {        
        
        //instanciamos funciones para utilizar las Mayusculas
        Funciones funciones = new Funciones();
        loadParametros();
        //instanciamos productobd para accedere a sus metodos
        ProductoBD productobd = new ProductoBD();
        //instanciamos producto para recibir datos
        Producto producto = new Producto();
        producto = productobd.Consultar(pid, cid, prov);

        this.lblNombre.Text = funciones.Mayus(producto.Nombre);
        this.lblPrecio.Text = producto.Precio.ToString().Substring(0,(producto.Precio.ToString().Length)-2);
        this.lblSize.Text = producto.Size;
        this.lblStock.Text = producto.Stock.ToString();
        this.lblDetalle.Text = producto.Descripcion;
        this.lblProveedor.Text = funciones.Mayus(nameProv(producto.Provid));
        this.imgProducto.ImageUrl = "images/" + rutaimg + "/big"+producto.Image;
    }

    private void loadParametros()
    {        
        if (Request.QueryString["PID"] != null && Request.QueryString["CID"] != null && Request.QueryString["PROV"] != null)
        {
            pid = Convert.ToInt32(Request.QueryString["PID"]);
            cid = Convert.ToInt32(Request.QueryString["CID"]);
            prov = Convert.ToInt32(Request.QueryString["PROV"]);
        }
        else
        {
            pid = 1;
            cid = 1;
            prov = 1;
        }

        //obtenemos segun categoria ruta de la imagen
        rutaimg = "";
        switch (cid)
        {
            case 1:
                rutaimg = "flores";
                break;
            case 2:
                rutaimg = "medicinales";
                break;
            case 3:
                rutaimg = "frutales";
                break;
            case 4:
                rutaimg = "bonsai";
                break;
            case 5:
                rutaimg = "tropicales";
                break;
            case 6:
                rutaimg = "semillas";
                break;
            default:
                rutaimg = "flores";
                break;
        }
    }

    private string nameProv(int provid)
    {
        string empresa="";
        BD bd = new BD();
        string cadena = bd.Cadena;
        SqlConnection cn = new SqlConnection(cadena);
        SqlCommand cmd = new SqlCommand("SELECT SWVM01NOM_EMPRESA FROM SWVMMPROVEEDOR01"
            + " WHERE (SWVM01PROV_ID = @SWVM01PROV_ID )", cn);
        cmd.Parameters.AddWithValue("@SWVM01PROV_ID", provid);
        cn.Open();
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            empresa = reader.GetString(0).ToLower();
        }
        reader.Close();
        cn.Close();
        return empresa;
    }

    private bool checkStock(int qty)
    {
        //validamos si carro de compras esta vacio
        if (Session["mycart"] != null)
        {
            ArrayList arr = (ArrayList)Session["mycart"];
            //For para barrer carrito si existe producto,
            //pregunte por cantidad + lo que ya existe en cantidad del carrito
            for (int i = 0; i < arr.Count; i++)
            {
                if (((ItemCart)arr[i]).Pid == pid && ((ItemCart)arr[i]).Cid == cid)
                {
                    qty = qty + ((ItemCart)arr[i]).Cantidad;
                }
            }
        }
        //true si es que hay stock disponible
        bool resp = true;
        ProductoBD pBD = new ProductoBD();
        Producto prod = pBD.Consultar(pid, cid, prov);
        //si la cantidad es mayor al stock disponoble, return false
        if (qty > prod.Stock)
        {
            resp = false;
        }
        return resp;
    }

    #endregion    
}
