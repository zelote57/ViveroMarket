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

public partial class swvmmmantprods06 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
         if (!Page.IsPostBack)
        {
            string tipo = "";
            tipo = Convert.ToString(Session["tipo"]);
            if (tipo == "AG")
            {                
                loadCate();
                loadProv();
                llenarProductos(int.Parse(ddlGcateid.SelectedValue.ToString()));
                ultimoId();
            }                
            else
            {
                Response.Redirect("default.aspx");
            }
        }
    }

    /*Boton editar del Grid*/
    protected void gvProducto_RowEditing(object sender, GridViewEditEventArgs e)
    {
        lblMensaje.Text = "";        
        //activar
        habilitaControles();
        //controlador de verificacion
        chkActImage.Visible = true;
        chkActImage.Checked = true;
        flimage.Disabled = true;
        cvFlimage.Enabled = false;
        //cargamos datos segun fila seleccionada del gridProveedor
        cargarDatos(e.NewEditIndex);        
    }

    protected void btnNuevo_Click(object sender, EventArgs e)
    {
        ddlCateid.SelectedIndex = ddlGcateid.SelectedIndex;
        lblMensaje.Text = "";
        ultimoId();
        habilitaControles();
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        lblMensaje.Text = "";
        Limpiar();
        ultimoId();
        noControles();
    }

    //Boton Guardar
    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        Producto prod = creaUI();
        ProductoBD  proBD = new ProductoBD();
        //validamos cantidad de caracteres en descripción
        if (cvDescripcion.IsValid == true)
        {             
                 //por v= Insercion; por f= actualizacion
                 if (txtId.Text == lastId().ToString())
                 {
                     /*Flag respuesta*/
                     string flag;
                     flag = proBD.ExisteProd(prod);
                     if (flag == "0")//no existe
                     {
                         //validamos que control de subida de imagen
                         if (cvFlimage.IsValid == true)
                         {
                             proBD.Insertar(prod);
                             UploadImagen(0);
                             lblMensaje.Text = "Registro Exitoso";
                         }
                     }
                     else
                     {
                         lblMensaje.Text = "Cliente ya existe";
                     } 
                 }
                 else
                 {
                     proBD.Actualizar(prod);
                     if (chkActImage.Checked == false)
                     {
                         UploadImagen(1);
                     }
                     lblMensaje.Text = "Actualización Exitosa";
                 }
                 llenarProductos(int.Parse(ddlGcateid.SelectedValue.ToString()));
                 Limpiar();
                 ultimoId();
                 noControles();
        }
    }
    
    //Boton eliminar del Grid
    protected void gvProducto_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        String msg;
        lblMensaje.Text = "";
        int proid = Convert.ToInt32(gvProducto.Rows[(Convert.ToInt32(e.RowIndex))].Cells[2].Text);
        int provid = Convert.ToInt32(gvProducto.Rows[(Convert.ToInt32(e.RowIndex))].Cells[3].Text);
        int cateid = int.Parse(ddlGcateid.SelectedValue.ToString());
        //instanciamos ProdBD para acceder al metodo eliminar
        ProductoBD prodBD = new ProductoBD();
        msg = prodBD.Eliminar(proid, cateid, provid);
        eliminarImagen(proid.ToString(),category(cateid));
        lblMensaje.Text = msg;
        //recargar pagina
        llenarProductos(int.Parse(ddlGcateid.SelectedValue.ToString()));
        Limpiar();
        ultimoId();
        noControles(); 
    }

    //paginacion
    protected void gvProducto_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvProducto.PageIndex = e.NewPageIndex;
        llenarProductos(int.Parse(ddlGcateid.SelectedValue.ToString()));
    }

    protected void ddlGcateid_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ddlGcateid.SelectedIndex = 0;
        }
    }

    //cambiar datos cuando cambia de categoria el grid producto
    protected void ddlGcateid_SelectedIndexChanged(object sender, EventArgs e)
    {
        llenarProductos(int.Parse(ddlGcateid.SelectedValue.ToString()));        
        Limpiar();
        ultimoId();
        noControles();
    }

    //cambia id dependiendo de categoria para la incersion
    protected void ddlCateid_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlGcateid.SelectedIndex = ddlCateid.SelectedIndex;
        ultimoId();
    }

    protected void cvDescripcion_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (txtDescripcion.Text.Length < 35)
        {
            args.IsValid = false;
        }
        else
        {
            args.IsValid = true;
        }
    }

    protected void cvFlimage_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if ((flimage.PostedFile != null) && (flimage.PostedFile.ContentLength > 0))
        {
            if (flimage.Value.EndsWith(".JPG") || flimage.Value.EndsWith(".jpg"))
            {
                if (flimage.PostedFile.ContentLength <= 1000000)
                {
                    args.IsValid = true;
                }
                else
                    args.IsValid = false;
                    cvFlimage.ErrorMessage = "El tamaño del archivo debe ser menor a 1Mb";
            }
            else
                args.IsValid = false;
                cvFlimage.ErrorMessage = "No se pudo cargar el archivo seleccionado, por favor seleccione una imagen .jpg";
        }
        else
        {
            args.IsValid = false;
            cvFlimage.ErrorMessage = "Debe seleccionar la imagen del producto";
        }
    }

    protected void chkActImage_CheckedChanged(object sender, EventArgs e)
    {
        if (chkActImage.Checked == false)
        {
            flimage.Disabled = false;
            cvFlimage.Enabled = true;
        }
        else
        {
            flimage.Disabled = true;
            cvFlimage.Enabled = false;
        }
    }

#region Funciones

    private Producto creaUI()
    {
        Producto prod = new Producto();
        prod.Proid = int.Parse(txtId.Text);
        prod.Cateid = int.Parse(ddlCateid.SelectedValue.ToString());
        prod.Nombre = txtNombre.Text;
        prod.Stock = int.Parse(txtStock.Text);
        prod.Precio = decimal.Parse(txtPrecio.Text);
        prod.Size = txtSize.Text;
        prod.Url = txtUrl.Text;
        prod.Provid = int.Parse(ddlProvid.SelectedValue.ToString());
        prod.Descripcion = txtDescripcion.Text;

        return prod;
    }

    private void loadCate()
    {
        CategoriaBD cateBD = new CategoriaBD();
        List<Categoria> listaCate = cateBD.Consultar();
        ddlCateid.DataSource = listaCate;
        ddlGcateid.DataSource = listaCate;
        DataBind();
    }

    private void loadProv()
    {
        ProveedorBD pBD = new ProveedorBD();
        List<Proveedor> listaProv = pBD.Consultar();
        ddlProvid.DataSource = listaProv;
        DataBind();
    }

    private void llenarProductos(int cateid)
    {
        ProductoBD prodBD = new ProductoBD();
        List<Producto> lstProd = prodBD.Consultar(cateid);
        this.gvProducto.DataSource = lstProd;
        gvProducto.DataBind();        
    }

    private void ultimoId()
    {
        txtId.Text = lastId().ToString();
    }

    private int lastId()
    {
        //encuentra el ultimo id traido desde la lista segun categoria y le suma 1 para futura incersion
        int lastid = 0;
        ProductoBD prodBD = new ProductoBD();
        List<Producto> lstProd = prodBD.Consultar(int.Parse(ddlGcateid.SelectedValue.ToString()));
        lastid = lstProd[lstProd.Count - 1].Proid+1;
        return lastid;
    }

    private void cargarDatos(int itemrow)
    {
        Funciones f = new Funciones();
        ProductoBD prodBD = new ProductoBD();        

        int proid = Convert.ToInt32(gvProducto.Rows[itemrow].Cells[2].Text);
        int provid = Convert.ToInt32(gvProducto.Rows[itemrow].Cells[3].Text);
        int cateid = int.Parse(ddlGcateid.SelectedValue.ToString());

        Producto prod = prodBD.ConsultarP(proid, cateid,provid);
        //text
        txtId.Text = prod.Proid.ToString();
        txtNombre.Text = f.Mayus(prod.Nombre);
        txtStock.Text = prod.Stock.ToString();
        txtPrecio.Text = prod.Precio.ToString();
        txtSize.Text = prod.Size;
        txtUrl.Text = prod.Url;
        txtDescripcion.Text = prod.Descripcion;
        //dropdownlists
        ddlCateid.SelectedIndex = int.Parse(ddlGcateid.SelectedIndex.ToString());
        ddlCateid.Enabled = false;
        ddlProvid.SelectedIndex = prod.Provid - 1;
        ddlProvid.Enabled = false;
        //imagen        
        string fn = category(int.Parse(ddlCateid.SelectedValue.ToString()))
            + "/big" + txtId.Text + ".jpg";
        imgProducto.Visible = true;
        imgProducto.ImageUrl ="http://viveromarket.com/images/"+ fn;
    }

    private void habilitaControles()
    {
        //activamos campos
        ddlCateid.Enabled = true;
        txtNombre.Enabled = true;
        txtStock.Enabled = true;
        txtPrecio.Enabled = true;
        txtSize.Enabled = true;
        txtUrl.Enabled = true;
        ddlProvid.Enabled = true;
        txtDescripcion.Enabled = true;
        flimage.Disabled = false;
        //mostrar opcion de acción
        btnGuardar.Enabled = true;
        btnCancelar.Enabled = true;
        btnNuevo.Enabled = false;
        //focus
        this.txtNombre.Focus();
    }

    private void noControles()
    {
        //desactivamos campos
        ddlCateid.Enabled = false;
        txtNombre.Enabled = false;
        txtStock.Enabled = false;
        txtPrecio.Enabled = false;
        txtSize.Enabled = false;
        txtUrl.Enabled = false;
        ddlProvid.Enabled = false;
        txtDescripcion.Enabled = false;
        imgProducto.Visible = true;
        flimage.Disabled = true;
        imgProducto.Visible = false;
        //mostrar opcion de acción
        btnGuardar.Enabled = false;
        btnCancelar.Enabled = false;
        btnNuevo.Enabled = true;
        chkActImage.Visible = false;
        //focus
        btnNuevo.Focus();
    }

    private void Limpiar()
    {
        txtId.Text = "";
        ddlCateid.SelectedIndex = 0;
        txtNombre.Text = "";
        txtStock.Text = "";
        txtPrecio.Text = "";
        txtSize.Text = "";
        txtUrl.Text = "";
        txtDescripcion.Text = "";
        //lblmessage.Text = "";
        ddlProvid.SelectedIndex = 0;        
    }

    private void eliminarImagen(string nombre, string categoria)
    {
        //crear rutas
        string ruta = Server.MapPath(@"~\httpdocs").Substring(0, 34);
        string fn = @"\httpdocs\images\"
            + categoria
            + "\\" + nombre + ".jpg";

        string fn2 = @"\httpdocs\images\"
            + categoria
            + "\\big" + nombre + ".jpg";
        
        string imagen1 = ruta + fn;
        string imagen2 = ruta + fn2;

        try{System.IO.File.Delete(imagen2);}
        catch (Exception ex){lblmessage.Text = ex.Message.ToString();}

        try { System.IO.File.Delete(imagen1); }
        catch (Exception ex) { lblmessage.Text = ex.Message.ToString(); }
    }

    private void UploadImagen(int opcion)
    {
        //crear rutas
        string ruta = Server.MapPath(@"~\httpdocs").Substring(0, 34);
        string fn = @"\httpdocs\images\"
            + category(int.Parse(ddlCateid.SelectedValue.ToString()))
            + "\\" + txtId.Text + ".jpg";

        string fn2 = @"\httpdocs\images\"
            + category(int.Parse(ddlCateid.SelectedValue.ToString()))
            + "\\big" + txtId.Text + ".jpg";

        if (opcion == 1)//actualizar
        {
            eliminarImagen(txtId.Text, category(int.Parse(ddlCateid.SelectedValue.ToString())));
        }        
        //if ((flimage.PostedFile != null) && (flimage.PostedFile.ContentLength > 0))
        //{
            //if (flimage.Value.EndsWith(".JPG") || flimage.Value.EndsWith(".jpg"))
            //{
                //if (flimage.PostedFile.ContentLength <= 1000000)
                //{
                    string SaveLocation = ruta + fn;                    
                    try
                    {
                        flimage.PostedFile.SaveAs(SaveLocation);
                        //big
                        System.IO.File.Copy(SaveLocation, ruta + fn2);
                        //this.lblmessage.Text = "El archivo se ha cargado.";
                    }
                    catch (Exception ex)
                    {
                        cvFlimage.ErrorMessage = ex.Message.ToString();
                        //this.lblmessage.Text = ex.Message.ToString();
                    }
                //}
                //else
                  //  this.lblmessage.Text = "El tamaño del archivo debe ser menor a 1Mb";
            //}
            //else
                //this.lblmessage.Text = "No se pudo cargar el archivo seleccionado, por favor seleccione una imagen .jpg";        }
        //else
        //{
            //this.lblmessage.Text = "Seleccione un archivo que cargar.";
        //}
    }

    private string category(int cateid)
    {
        string rutaimg;
        switch (cateid)
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
        return rutaimg;
    }
#endregion        
}