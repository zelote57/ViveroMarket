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
    /// ProveedorBD: ConsultarP, Sesion
    /// </summary>
    public class ProveedorBD
    {

        public Proveedor ConsultarP(int provid) 
        {
            BD bd = new BD();
            string cadena = bd.Cadena;
            SqlConnection cn = new SqlConnection(cadena);

            string sql = "SELECT * FROM SWVMMPROVEEDOR01 "
                        + "WHERE SWVM01PROV_ID = @SWVM01PROV_ID";
            SqlCommand cmd = new SqlCommand(sql, cn);
            // Añadimos el valor del parámetro de la consulta            
            cmd.Parameters.AddWithValue("@SWVM01PROV_ID", provid);
            /* Instanciamos el proveedor para devolver datos*/
            Proveedor proveedor = new Proveedor();
            cn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                proveedor.Provid = reader.GetInt32(0);
                proveedor.Empresa = reader.GetString(1);
                proveedor.Contacto = reader.GetString(2);
                proveedor.Cargo = reader.GetString(3);
                proveedor.Ruc = reader.GetString(4);
                proveedor.Dir = reader.GetString(5);
                proveedor.Fono1 = reader.GetString(6);
                if (reader.IsDBNull(7))
                { proveedor.Fono2 = ""; }
                else { proveedor.Fono2 = reader.GetString(7);}
                proveedor.Pais = reader.GetString(8);
                proveedor.Provincia = reader.GetString(9);
                proveedor.Ciudad = reader.GetString(10);
                proveedor.Email = reader.GetString(11);
            }
            reader.Close();
            cn.Close();
            return proveedor;

        }

        public string ExisteProveedor(Proveedor proveedor)
        {
            /*Existe flag=1 else flag=0*/
            string flag;
            BD bd = new BD();
            string cadena = bd.Cadena;
            SqlConnection cn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand
            ("SELECT COUNT(*) FROM SWVMMPROVEEDOR01"
            + " WHERE (SWVM01RUC = @SWVM01RUC OR SWVM01EMAIL =@SWVM01EMAIL)"
            + " AND SWVM01PROV_ID !=  @SWVM01PROV_ID", cn);
            cmd.Parameters.AddWithValue("@SWVM01RUC", proveedor.Ruc);
            cmd.Parameters.AddWithValue("@SWVM01EMAIL", proveedor.Email);
            cmd.Parameters.AddWithValue("@SWVM01PROV_ID", proveedor.Provid);
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

        public void Insertar(Proveedor proveedor)
        {
            Grabar(proveedor, "SP_INSERT_PROVEEDOR");
        }

        public void Actualizar(Proveedor proveedor) 
        {
            Grabar(proveedor, "SP_UPDATE_PROVEEDOR");
        }

        public string Eliminar(int provid)
        {
            string msg;
            BD bd = new BD();    
            string cadena = bd.Cadena;
            SqlConnection cn = new SqlConnection(cadena);
            SqlCommand cm = new SqlCommand("SP_DELETE_PROVEEDOR", cn);
            cm.CommandType = CommandType.StoredProcedure;
            SqlParameter param = cm.Parameters.Add("@ERROR", SqlDbType.VarChar,5);
            param.Direction = ParameterDirection.Output;
            cm.Parameters.AddWithValue("@SWVM01PROV_ID", provid);
            try
            {
                cn.Open();
                cm.ExecuteNonQuery();
                msg = "Proveedor Eliminado";
            }
            catch
            {
                msg = param.Value.ToString();
                if (msg == "ERROR")
                {
                    msg = "Error, elimine primero productos de este proveedor.";
                }
            }
            cn.Close();
            return msg;
        }


        public List<Proveedor> Consultar()
        {
            BD bd = new BD();
            string cadena = bd.Cadena;
            SqlConnection cn = new SqlConnection(cadena);

            string sql = "SELECT * FROM SWVMMPROVEEDOR01";
            SqlCommand cm = new SqlCommand(sql, cn);
            List<Proveedor> lista = new List<Proveedor>();
            cn.Open();
            SqlDataReader reader = cm.ExecuteReader();
            while (reader.Read())
            {
                Proveedor prov = new Proveedor();

                prov.Provid = reader.GetInt32(0);
                prov.Empresa = reader.GetString(1);
                prov.Contacto = reader.GetString(2);
                prov.Cargo = reader.GetString(3);
                prov.Ruc = reader.GetString(4);
                prov.Dir = reader.GetString(5);
                prov.Fono1 = reader.GetString(6);
                if (reader.IsDBNull(7))
                { prov.Fono2 = ""; }
                else { prov.Fono2 = reader.GetString(7); }
                prov.Pais = reader.GetString(8);
                prov.Provincia = reader.GetString(9);
                prov.Ciudad = reader.GetString(10);
                prov.Email = reader.GetString(11);
                if (reader.GetString(13) == "A") { prov.Estado = "Activo"; } else { prov.Estado = "Inactivo"; }
                prov.Fechar = reader.GetDateTime(14);
                lista.Add(prov);
            }
            reader.Close();
            cn.Close();
            return lista;
        }

        public Proveedor Sesion(Proveedor proveedor)
        {
            BD bd = new BD();
            string cadena = bd.Cadena;
            SqlConnection cn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand // devuelve proveedor si email y contraseña son correctas
               ("SELECT * FROM SWVMMPROVEEDOR01 WHERE SWVM01EMAIL = @SWVM01EMAIL"
               + " AND SWVM01CLAVE = @SWVM01CLAVE", cn);
            // Añadimos el valor del parámetro de la consulta
            cmd.Parameters.AddWithValue("@SWVM01EMAIL", proveedor.Email);
            cmd.Parameters.AddWithValue("@SWVM01CLAVE", proveedor.Clave);
            /* Instanciamos el proveedor para devolver datos*/
            Proveedor provider = new Proveedor();
            cn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                provider.Provid = reader.GetInt32(0);
                provider.Empresa = reader.GetString(1).ToLower();
                provider.Contacto = reader.GetString(2).ToLower();
            }
            reader.Close();
            cn.Close();
            return provider;
        }

        public string SuClave(string email)
        {
            BD bd = new BD();
            string cadena = bd.Cadena;
            SqlConnection cn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand
                ("SELECT SWVM01CLAVE FROM SWVMMPROVEEDOR01 "
                + "WHERE (SWVM01EMAIL = @SWVM01EMAIL)", cn);
            cmd.Parameters.AddWithValue("@SWVM01EMAIL", email);
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

        private void Grabar(Proveedor proveedor, string spTipo)
        {
            BD bd = new BD();
            string cadena = bd.Cadena;
            SqlConnection cn = new SqlConnection(cadena);
            SqlCommand cm = new SqlCommand(spTipo, cn);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@SWVM01PROV_ID", proveedor.Provid);
            cm.Parameters.AddWithValue("@SWVM01NOM_EMPRESA", proveedor.Empresa);
            cm.Parameters.AddWithValue("@SWVM01NOM_CONTACTO", proveedor.Contacto);
            cm.Parameters.AddWithValue("@SWVM01CARGO_CONTACTO", proveedor.Cargo);
            cm.Parameters.AddWithValue("@SWVM01RUC", proveedor.Ruc);
            cm.Parameters.AddWithValue("@SWVM01DIRECCION", proveedor.Dir);
            cm.Parameters.AddWithValue("@SWVM01TELEFONO1", proveedor.Fono1);
            cm.Parameters.AddWithValue("@SWVM01TELEFONO2", proveedor.Fono2);
            cm.Parameters.AddWithValue("@SWVM01PAIS", proveedor.Pais);
            cm.Parameters.AddWithValue("@SWVM01PROVINCIA", proveedor.Provincia);
            cm.Parameters.AddWithValue("@SWVM01CIUDAD", proveedor.Ciudad);
            cm.Parameters.AddWithValue("@SWVM01EMAIL", proveedor.Email);
            cm.Parameters.AddWithValue("@SWVM01CLAVE", proveedor.Clave);
            cm.Parameters.AddWithValue("@SWVM01ESTADO", proveedor.Estado);
            if (spTipo == "SP_INSERT_PROVEEDOR") { cm.Parameters.AddWithValue("@SWVM01FECHA_REGP", DateTime.Now); }
            cm.Parameters.AddWithValue("@SWVM01FECHA_UPDATE", DateTime.Now);
            cn.Open();
            cm.ExecuteNonQuery();
            cn.Close();
        }
        #endregion

    }
}