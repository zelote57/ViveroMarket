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

public partial class swvmmmantusers02 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
         if (!Page.IsPostBack)
        {
            string tipo = "";
            tipo = Convert.ToString(Session["tipo"]);
            if (tipo == "AG")
            {
                llenarUsuarios();
                ultimoId();
            }                
            else
            {
                Response.Redirect("default.aspx");
            }
        }
    }

    //Boton editar del Grid
    protected void gvUsuario_RowEditing(object sender, GridViewEditEventArgs e)
    {
        lblMensaje.Text = "";
        ddlEstado.Enabled = true;
        //cargamos datos segun fila seleccionada del gridUsuario
        cargarDatos(e.NewEditIndex);
        //activar
        habilitaControles();        
        //mostrar opcion de acción
        btnGuardar.Enabled = true;
        btnNuevo.Enabled = false;
    }

    protected void btnNuevo_Click(object sender, EventArgs e)
    {
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
        Usuario user = creaUI();
        UsuarioBD usuarioBD = new UsuarioBD();
        //validamos repetición contraseña 
        if (cvRClave.IsValid == true)
        {
            /*Flag respuesta*/
            string flag;
            flag = usuarioBD.ExisteUsuario(user);
            if (flag == "0")//no existe
            {
                //por v= Insercion; por f= actualizacion
                if (txtId.Text == (((Convert.ToInt32(gvUsuario.Rows[gvUsuario.Rows.Count - 1].Cells[2].Text))
                                           + 1).ToString()))
                {

                    usuarioBD.Insertar(user);
                    lblMensaje.Text = "Registro Exitoso";
                }
                else
                {
                    usuarioBD.Actualizar(user);
                    lblMensaje.Text = "Actualización Exitosa";

                    #region actualizaSession

                    //obtiene userid de variable session
                    int userid;
                    userid = Convert.ToInt32(Session["userid"]);
                    //preguntamos si usuario modificado es de actual sesion
                    if (userid == user.Userid)
                    {
                        Session["empresa"] = "vivero market | " + (user.Cargo.ToLower())
                            + " departamento: " + (user.Departamento.ToLower());
                    }
                    #endregion
                }
                llenarUsuarios();
                Limpiar();
                ultimoId();
                noControles();
            }
            else
            {
                lblMensaje.Text = "Usuario ya existe, verifique email";
            }
        }
    }
    /*Boton eliminar del Grid*/
    protected void gvUsuario_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        lblMensaje.Text = "";        
        //eliminamos datos segun fila seleccionada del gridUsuario
        int userid = Convert.ToInt32(gvUsuario.Rows[(Convert.ToInt32(e.RowIndex))].Cells[2].Text);
        if (userid != (Convert.ToInt32(Convert.ToString(Session["userid"]))))
        {
            //instanciamos UsuarioBD para acceder al metodo eliminar
            UsuarioBD usuarioBD = new UsuarioBD();
            usuarioBD.Eliminar(userid);
            lblMensaje.Text = "Usuario Eliminado";
            //recargar pagina
            llenarUsuarios();
            Limpiar();
            ultimoId();
            noControles();
        }
        else
        {
            lblMensaje.Text = "No puede eliminar su propio Usuario";
        }
    }

#region Funciones

    private Usuario creaUI()
    {
        Usuario user = new Usuario();
        user.Userid = Convert.ToInt32(txtId.Text);
        user.Nombre = txtNombre.Text;
        user.Departamento = txtDepartamento.Text;
        user.Cargo = txtCargo.Text;
        if (ddlEstado.SelectedIndex == 0){user.Estado = "A";} else {user.Estado = "I";}
        //Clave encriptada
        Funciones f = new Funciones();
        string clave = f.encriptar(txtClave.Text);   
        user.Clave = clave;
        user.Email = txtEmail.Text;
        return user;
    }

    private void llenarUsuarios()
    {
        UsuarioBD usuarioBD = new UsuarioBD();
        List<Usuario> listaUsuario = usuarioBD.Consultar();
        this.gvUsuario.DataSource = listaUsuario;
        gvUsuario.DataBind();
    }

    private void cargarDatos(int itemrow)
    {
        //texts
        this.txtId.Text = gvUsuario.Rows[itemrow].Cells[2].Text;
        this.txtNombre.Text = gvUsuario.Rows[itemrow].Cells[3].Text;
        this.txtCargo.Text = gvUsuario.Rows[itemrow].Cells[4].Text;
        this.txtDepartamento.Text = gvUsuario.Rows[itemrow].Cells[5].Text;
        this.txtEmail.Text = gvUsuario.Rows[itemrow].Cells[6].Text;
        //ddlEstado
        if ((gvUsuario.Rows[itemrow].Cells[7].Text) == "Activo")
        { this.ddlEstado.SelectedIndex = 0; }
        else
        { this.ddlEstado.SelectedIndex = 1; }
    }

    private void ultimoId()
    {
        //devuelve ultimo usuario y le suma 1
        txtId.Text = ((Convert.ToInt32(gvUsuario.Rows[gvUsuario.Rows.Count - 1].Cells[2].Text))
                           + 1).ToString();
    }

    private void habilitaControles()
    {
        //activamos campos
        txtNombre.Enabled = true;
        txtCargo.Enabled = true;
        txtDepartamento.Enabled = true;
        txtEmail.Enabled = true;
        //mostrar campos contraseña
        lblClave.Visible = true;
        lblRClave.Visible = true;
        txtClave.Visible = true;
        txtRClave.Visible = true;
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
        txtNombre.Enabled = false;
        txtCargo.Enabled = false;
        txtDepartamento.Enabled = false;
        txtEmail.Enabled = false;
        ddlEstado.Enabled = false;
        //ocultar campos contraseña
        lblClave.Visible = false;
        lblRClave.Visible = false;
        txtClave.Visible = false;
        txtRClave.Visible = false;
        //mostrar opcion de acción
        btnGuardar.Enabled = false;
        btnCancelar.Enabled = false;
        btnNuevo.Enabled = true;
        //focus
        btnNuevo.Focus();
    }

    private void Limpiar()
    {
        txtId.Text = "";
        txtNombre.Text = "";
        txtCargo.Text = "";
        txtDepartamento.Text = "";
        txtEmail.Text = "";
        txtClave.Text = "";
        txtRClave.Text = "";
        ddlEstado.SelectedIndex=0;        
    }   


#endregion    
}