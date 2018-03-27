using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using System.Collections.Generic;
using System.Text;

using System.Data.SqlClient;
using DAL.Entidades;
namespace DAL
{
    /// <summary>
    /// UsuarioBD: Consultar, Insertar, Actualizar
    /// </summary>
    public class UsuarioBD
    {
        public List<Usuario> Consultar()
        {
            BD bd = new BD();
            string cadena = bd.Cadena;
            SqlConnection cn = new SqlConnection(cadena);
            string sql = "SELECT * FROM SWVMMUSUARIO08";
            SqlCommand cm = new SqlCommand(sql, cn);
            List<Usuario> lista = new List<Usuario>();
            cn.Open();
            SqlDataReader reader = cm.ExecuteReader();
            while (reader.Read())
            {
                Usuario user = new Usuario();
                user.Userid = reader.GetInt32(0);
                user.Nombre = reader.GetString(1);
                user.Departamento = reader.GetString(2);
                user.Cargo = reader.GetString(3);
                user.Email = reader.GetString(4);
                if (reader.GetString(6) == "A") { user.Estado = "Activo"; } else { user.Estado = "Inactivo"; }
                user.Fechar = reader.GetDateTime(7).Date;  
                lista.Add(user);
            }
            reader.Close();
            cn.Close();
            return lista;
        }

        public void Insertar(Usuario usuario)
        {
            Grabar(usuario,"SP_INSERT_USUARIO");
        }

        public void Actualizar(Usuario usuario)
        {
            Grabar(usuario, "SP_UPDATE_USUARIO");
        }

        public void Eliminar(int userid)
        {
            BD bd = new BD();
            string cadena = bd.Cadena;
            SqlConnection cn = new SqlConnection(cadena);
            SqlCommand cm = new SqlCommand("SP_DELETE_USUARIO", cn);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@SWVM08USER_ID", userid);
            cn.Open();
            cm.ExecuteNonQuery();
            cn.Close();
        }

        public Usuario Sesion(Usuario usuario)
        {
            BD bd = new BD();
            string cadena = bd.Cadena;
            SqlConnection cn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand // devuelve usuario si email y contraseña son correctas
               ("SELECT * FROM SWVMMUSUARIO08 WHERE SWVM08EMAIL = @SWVM08EMAIL"//, cn);
               + " AND SWVM08CLAVE = @SWVM08CLAVE", cn);
            // Añadimos el valor del parámetro de la consulta
            cmd.Parameters.AddWithValue("@SWVM08EMAIL", usuario.Email);
            cmd.Parameters.AddWithValue("@SWVM08CLAVE", usuario.Clave);
            /* Instanciamos el Usuario para devolver datos*/
            Usuario user = new Usuario();
            cn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                user.Userid = reader.GetInt32(0);
                user.Nombre = reader.GetString(1).ToLower();
                user.Departamento = reader.GetString(2).ToLower();
                user.Cargo = reader.GetString(3).ToLower();
            }
            reader.Close();
            cn.Close();
            return user;
        }

        public string ExisteUsuario(Usuario usuario)
        {
            /*Existe flag=1 else flag=0*/
            string flag;
            BD bd = new BD();
            string cadena = bd.Cadena;
            SqlConnection cn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand
            ("SELECT COUNT(*) FROM SWVMMUSUARIO08"
            + " WHERE SWVM08EMAIL = @SWVM08EMAIL"
            + " AND SWVM08USER_ID != @SWVM08USER_ID", cn);
            cmd.Parameters.AddWithValue("@SWVM08USER_ID", usuario.Userid);
            cmd.Parameters.AddWithValue("@SWVM08EMAIL", usuario.Email);
            // Abrimos la conexión
            cn.Open();
            // Si devuelve algun valor, es que ya existe
            int i = (int)cmd.ExecuteScalar();
            if (i > 0)
            {
                // flag on
                flag = "1";
            }
            else
            {
                // flag off
                flag = "0";
            }
            cn.Close();
            return flag; 
        }
            

        public string SuClave(string email)
        {
            BD bd = new BD();
            string cadena = bd.Cadena;
            SqlConnection cn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand
                ("SELECT SWVM08CLAVE FROM SWVMMUSUARIO08 "
                + "WHERE (SWVM08EMAIL = @SWVM08EMAIL)", cn);
            cmd.Parameters.AddWithValue("@SWVM08EMAIL", email);
            cn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            string clavencriptada = string.Empty;
            while (reader.Read())
            {
                clavencriptada = reader.GetString(0);
            }
            Funciones f = new Funciones();
            string suclave = f.desencriptar(clavencriptada);
            return suclave;
        }


    #region Funciones

        private void Grabar(Usuario usuario, string spTipo)
        {
            BD bd = new BD();
            string cadena = bd.Cadena;
            SqlConnection cn = new SqlConnection(cadena);
            SqlCommand cm = new SqlCommand(spTipo, cn);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@SWVM08USER_ID", usuario.Userid);
            cm.Parameters.AddWithValue("@SWVM08NOMBRE", usuario.Nombre);
            cm.Parameters.AddWithValue("@SWVM08DEPARTAMENTO", usuario.Departamento);
            cm.Parameters.AddWithValue("@SWVM08CARGO", usuario.Cargo);
            cm.Parameters.AddWithValue("@SWVM08EMAIL", usuario.Email);
            cm.Parameters.AddWithValue("@SWVM08CLAVE", usuario.Clave);
            cm.Parameters.AddWithValue("@SWVM08ESTADO", usuario.Estado);
            if (spTipo == "SP_INSERT_USUARIO") { cm.Parameters.AddWithValue("@SWVM08FECHA_REGU", DateTime.Now); }
            cm.Parameters.AddWithValue("@SWVM08FECHA_UPDATE", DateTime.Now);
            cn.Open();
            cm.ExecuteNonQuery();
            cn.Close();
        }
    #endregion
    }
}