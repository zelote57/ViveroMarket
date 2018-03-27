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

public partial class swvmicart05 : System.Web.UI.Page
{
#region variables
    int pid;
    int cid;
    int prov;
    int quantity;
    string rutaimg = string.Empty;
    bool fparam = false;
#endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["mycart"] == null)
        {
            vaciarGrid();
        }
        if (!Page.IsPostBack)
        {
            Session["page"] = "cart";
            getParametros();
            cartState();
            llenarGrid();            
            if (fparam == true)
            {
                addProducto();
                llenarGrid();
                cartState();
            }
        }
    }

    protected void gvCart_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        if (Session["mycart"] != null)
        {
            ArrayList items = (ArrayList)Session["mycart"];
            //For para barrer el arreglo y eliminar
            for (int i = 0; i < items.Count; i++)
            {
                string[] codigo = (gvCart.Rows[(Convert.ToInt32(e.RowIndex))].Cells[1].Text).ToString().Split('C');
                string[] codigo2 = codigo[1].Split('V');
                int gpid, gcid, gprov;
                gpid = Convert.ToInt32(codigo[0].Substring(1));
                gcid = Convert.ToInt32(codigo2[0]);
                gprov = Convert.ToInt32(codigo2[1]);
                if (((ItemCart)items[i]).Pid == gpid && ((ItemCart)items[i]).Cid == gcid && ((ItemCart)items[i]).Prov == gprov)
                {
                    items.RemoveAt(i);
                    break;
                }
            }
            //si carrito esta vacio(arreglo items)
            if (items.Count == 0)
            {
                Session["mycart"] = null;
                cartState();
                //recargamos pagina actual para activar panelComprar
                Response.Redirect("swvmicart05.aspx");
            }
            llenarGrid();
        }
        else
        {
            Response.Redirect("swvmicart05.aspx");
        }
    }

    protected void lknActualizar_Click(object sender, EventArgs e)
    {
        if (Session["mycart"] != null)
        {
            ProductoBD pBD = new ProductoBD();
            //foreach para recorrer el grid por filas
            foreach (GridViewRow dgc in gvCart.Rows)
            {
                //vector codigo que toma el productoid y codigoid combinado
                //funcion split para posteriormente guardar en variables int
                string[] codigo = dgc.Cells[1].Text.ToString().Split('C');
                string[] codigo2 = codigo[1].Split('V');
                int gpid, gcid, gprov;
                //variable para evaluar el arreglo carrito
                gpid = Convert.ToInt32(codigo[0].Substring(1));
                gcid = Convert.ToInt32(codigo2[0]);
                gprov = Convert.ToInt32(codigo2[1]);
                //llenado en variable de nueva cantidad especificada por el usuario
                TextBox t = (TextBox)dgc.Cells[3].Controls[1];
                //valida que el textbox cantidad no este vacio y no sea cero
                if (t.Text != "" && int.Parse(t.Text) != 0)
                {
                    int newqty = int.Parse(t.Text);            
                    //instancia de arreglo de carrito de compras
                    ArrayList arr = (ArrayList)Session["mycart"];
                    //For para barrer el arreglo y obtener calculos actualizando el carrito
                    for (int i = 0; i < arr.Count; i++)
                    {
                        if (((ItemCart)arr[i]).Pid == gpid && ((ItemCart)arr[i]).Cid == gcid && ((ItemCart)arr[i]).Prov == gprov)
                        {
                            Producto prod = pBD.Consultar(gcid, gcid, gprov);
                            //valida stock
                            if (newqty > prod.Stock)
                            {
                                ((ItemCart)arr[i]).MsgStock = "No tenemos suficiente stock para su pedido";
                            }
                            else
                            {
                                ((ItemCart)arr[i]).MsgStock = "";
                                //actualiza la cantidad con la nueva especificada por el usuario
                                ((ItemCart)arr[i]).Cantidad = newqty;
                                //actualiza subtotal
                                ((ItemCart)arr[i]).SubTotal = ((ItemCart)arr[i]).PrecioUni * ((ItemCart)arr[i]).Cantidad;
                            }
                        }
                    }
                }
            }
            //llenado del gvcart
            llenarGrid();
            Response.Redirect("swvmicart05.aspx");
        }
        else
        {
            Response.Redirect("swvmicart05.aspx");
        }
    }
    
    protected void lknCotizar_Click(object sender, EventArgs e)
    {
        if (Session["mycart"] != null)
        {
            string sesion = Convert.ToString(Session["login"]);
            if (sesion != "true")
            {
                pCartstate.Visible = true;
                imgCartstate.ImageUrl = "images/info.png";
                lblCartstatetitle.Text = "¡Información!";
                lblCartstate.Text = "Para Cotizar debe Iniciar Sesión.&nbsp;&nbsp;&nbsp;"
                + "¿Nuevo Usuario? Regístrese <a href='regcli.aspx'; class='reg';>aquí</a>";
            }
            else
            {
                Response.Redirect("swvmpcotizacion06.aspx");
            }
        }
        else
        {
            Response.Redirect("swvmicart05.aspx");
        }
    }    

    #region Funciones

    private void llenarGrid()
    {
        ArrayList items = (ArrayList)Session["mycart"];
        gvCart.DataSource = items;
        gvCart.DataBind();
        Calculo();
    }

    private void vaciarGrid()
    {
        gvCart.DataSource = null;
        gvCart.DataBind();
        cartState();
    }

    private void addProducto()
    {
        //Instancia Funcion Mayuscula
        Funciones f = new Funciones();
        getParametros();
        ArrayList arr;
        //bandera que indica si el producto no es nuevo,
        //entonces se enciende para reemplazar el item dentro arreglo con la nueva cantidad
        int flag=0;
        if (Session["mycart"] != null)
        {
            arr = (ArrayList)Session["mycart"];
            //For para barrer el arreglo y en caso que el producto se repita solo incremente la cantidad
            for (int i = 0; i < arr.Count; i++)
            {
                if (((ItemCart)arr[i]).Pid == pid && ((ItemCart)arr[i]).Cid == cid && ((ItemCart)arr[i]).Prov == prov)
                {
                    ((ItemCart)arr[i]).Cantidad = ((ItemCart)arr[i]).Cantidad + quantity;
                    ((ItemCart)arr[i]).SubTotal = ((ItemCart)arr[i]).PrecioUni * ((ItemCart)arr[i]).Cantidad;
                    //enciende item repetido
                    flag = 1;
                    break;
                }
            }            
        }
        else
        {            
            arr = new ArrayList();
            Session["mycart"] = arr;
        }
        //instanciamos producto & items para recibir datos
        Producto producto = new Producto();
        producto = getDatos();
        ItemCart item = new ItemCart();
        item.Pid = pid;
        item.Cid = cid;
        item.Prov = prov;
        item.Codigo = "P" + Convert.ToString(item.Pid) + "C" + Convert.ToString(item.Cid) + 'V' + Convert.ToString(item.Prov);
        item.NombreProd = f.Mayus(producto.Nombre);
        item.PrecioUni = Math.Round(producto.Precio,2);        
        item.Cantidad = quantity;
        item.Image = rutaimg + "/" + producto.Image;
        item.SubTotal = item.PrecioUni * item.Cantidad;
        item.lnkDetails = "swvmigalerydetails04.aspx?PID=" + item.Pid.ToString() + "&CID=" + item.Cid.ToString();        
        //solo insertamos si el item es nuevo en el arreglo
        if (flag == 0)
        {
            arr.Add(item);
        }
    }

    private Producto getDatos()
    {
        //getParametros();
        //instanciamos productobd para accedere a sus metodos
        ProductoBD productobd = new ProductoBD();
        //instanciamos producto para recibir datos
        Producto producto = new Producto();
        producto = productobd.Consultar(pid, cid, prov);
        return producto;
    }

    private void getParametros()
    {
        if (Request.QueryString["PID"] != null && Request.QueryString["CID"] != null && Request.QueryString["PROV"] != null)
        {
            pid = Convert.ToInt32(Request.QueryString["PID"]);
            cid = Convert.ToInt32(Request.QueryString["CID"]);
            prov = Convert.ToInt32(Request.QueryString["PROV"]);

            //permite almacenar la ultima categoria visitada por el cliente en variable de sesion para funcion back()
            Session["cid"] = cid.ToString();

            //obtenemos segun categoria ruta de la imagen
            rutaimg = "";
            switch (cid)
            {
                case 1:
                    rutaimg = "flores";
                    Session["rutaimg"] = rutaimg;//sesion para funcion back()
                    break;
                case 2:
                    rutaimg = "medicinales";
                    Session["rutaimg"] = rutaimg;//sesion para funcion back()
                    break;
                case 3:
                    rutaimg = "frutales";
                    Session["rutaimg"] = rutaimg;//sesion para funcion back()
                    break;
                case 4:
                    rutaimg = "bonsai";
                    Session["rutaimg"] = rutaimg;//sesion para funcion back()
                    break;
                case 5:
                    rutaimg = "tropicales";
                    Session["rutaimg"] = rutaimg;//sesion para funcion back()
                    break;
                case 6:
                    rutaimg = "semillas";
                    Session["rutaimg"] = rutaimg;//sesion para funcion back()
                    break;
                default:
                    rutaimg = "flores";
                    Session["rutaimg"] = rutaimg;//sesion para funcion back()
                    break;
            }
            fparam = true;
        }
        else
        {
            fparam = false;
        }
        
        if (Request.QueryString["Q"] != null)
        {
            quantity = Convert.ToInt32(Request.QueryString["Q"]);
        }
        else
        {
            quantity = 1;
        }        
    }

    private void cartState()
    {
        if (Session["mycart"] != null)
        {
            ArrayList items = (ArrayList)Session["mycart"];            
            if (items.Count < 3)
            {
                pCartstate.Visible = true;
                imgCartstate.ImageUrl = "images/good.png";
                lblCartstatetitle.Text = "¡Ha agregado productos a su carrito de compras!";
                lblCartstate.Text = "Ha agregado productos a su carrito de compras. <br/>"
                + "Puede aumentar o eliminar la cantidad de productos de su carrito de compras y actualizar el valor final a pagar.";
                lblWords.Visible = true;
            }
            pCuenta.Visible = true;            
            this.imgBack.Visible = true;
            this.lknRegresar.Visible = true;
            this.lblCategoria.Visible = true;
        }
        else
        {
            pCartstate.Visible = true;
            imgCartstate.ImageUrl = "images/info.png";
            lblCartstatetitle.Text = "¡Carrito de Compras Vacío!";
            lblCartstate.Text = "No tiene productos seleccionados para comprar. <br/>"
            + "Navegue por el catálogo y escoja productos para incluírlos en el carrito de Compras.";
            lblWords.Visible = false;
            pCuenta.Visible = false;
            this.imgBack.Visible = false;
            this.lknRegresar.Visible = false;
            this.lblCategoria.Visible = false;
        }
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
            Back();
        }
    }

    private void Back()
    {
        //obtiene los ultimas categorias visitadas 
        //por el cliente desde variables de sesion definidas y
        //cargadas desde  funcion parametros
        Funciones f = new Funciones();
        string back = "";
        back = "swvmpgalery03.aspx?IGP=" + Convert.ToString(Session["cid"]);
        lknRegresar.PostBackUrl = back;
        lblCategoria.Text = f.Mayus(Convert.ToString(Session["rutaimg"]));
    }
    #endregion    
}
