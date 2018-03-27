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
    /// ProductoBD: Consultar, ConsultarP
    /// </summary>
    public class ProductoBD
    {

        public List<Producto> Consultar(int cateid)
        {
            BD bd = new BD();
            string cadena = bd.Cadena;
            SqlConnection cn = new SqlConnection(cadena);

            string sql = "SELECT * FROM SWVMMPRODUCTO04 WHERE SWVM04CATE_ID = @SWVM04CATE_ID";
            SqlCommand cm = new SqlCommand(sql, cn);
            // Añadimos el valor del parámetro de la consulta
            cm.Parameters.AddWithValue("@SWVM04CATE_ID", cateid);
            List<Producto> lista = new List<Producto>();
            cn.Open();
            SqlDataReader reader = cm.ExecuteReader();
            while (reader.Read())
            {
                Producto prod = new Producto();
                prod.Proid = reader.GetInt32(0);
                prod.Nombre = reader.GetString(2);
                prod.Precio = Math.Round(reader.GetDecimal(3),2);
                prod.Stock = reader.GetInt32(4);                
                prod.Size = reader.GetString(7);
                prod.Provid = reader.GetInt32(9);
                prod.Fechar = reader.GetDateTime(10);

                lista.Add(prod);
            }
            reader.Close();
            cn.Close();
            return lista;
        }

        public List<Producto> ConsultarListProv(int cateid, int proveid)
        {
            BD bd = new BD();
            string cadena = bd.Cadena;
            SqlConnection cn = new SqlConnection(cadena);
            string sql = "SELECT * FROM SWVMMPRODUCTO04 WHERE SWVM04CATE_ID = @SWVM04CATE_ID"
                + " AND SWVM04PROV_ID=@SWVM04PROV_ID";
            SqlCommand cm = new SqlCommand(sql, cn);
            // Añadimos el valor del parámetro de la consulta
            cm.Parameters.AddWithValue("@SWVM04CATE_ID", cateid);
            cm.Parameters.AddWithValue("@SWVM04PROV_ID", proveid);
            List<Producto> lista = new List<Producto>();
            cn.Open();
            SqlDataReader reader = cm.ExecuteReader();
            while (reader.Read())
            {
                Producto prod = new Producto();
                prod.Proid = reader.GetInt32(0);
                prod.Nombre = reader.GetString(2);
                prod.Precio = Math.Round(reader.GetDecimal(3), 2);
                prod.Stock = reader.GetInt32(4);
                prod.Size = reader.GetString(7);
                prod.Provid = reader.GetInt32(9);
                prod.Fechar = reader.GetDateTime(10);

                lista.Add(prod);
            }
            reader.Close();
            cn.Close();
            return lista;
        }

        public Producto ConsultarP(int proid, int cateid, int provid)
        {
            BD bd = new BD();
            string cadena = bd.Cadena;
            SqlConnection cn = new SqlConnection(cadena);
            string sql = "SELECT * FROM SWVMMPRODUCTO04"
            + " WHERE (SWVM04PROD_ID = @SWVM04PROD_ID AND SWVM04CATE_ID = @SWVM04CATE_ID AND SWVM04PROV_ID = @SWVM04PROV_ID)";
            SqlCommand cmd = new SqlCommand(sql, cn);
            // Añadimos el valor del parámetro de la consulta
            cmd.Parameters.AddWithValue("@SWVM04PROD_ID", proid);
            cmd.Parameters.AddWithValue("@SWVM04CATE_ID", cateid);
            cmd.Parameters.AddWithValue("@SWVM04PROV_ID", provid);
            /* Instanciamos producto para devolver datos*/
            Producto producto = new Producto();            
            cn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                producto.Proid = reader.GetInt32(0);
                producto.Nombre = reader.GetString(2);
                producto.Precio = Math.Round(reader.GetDecimal(3),2);
                producto.Stock = reader.GetInt32(4);
                producto.Descripcion = reader.GetString(5);
                if (reader.IsDBNull(6)) { producto.Url = ""; }
                else { producto.Url = reader.GetString(6).ToLower(); }                
                producto.Size = reader.GetString(7);
                //producto.Image = reader.GetString(8);
                producto.Provid = reader.GetInt32(9);
            }
            reader.Close();
            cn.Close();
            return producto;
        }        
        
        public string ExisteProd(Producto prod)
        {
            //Existe flag=1 else flag=0
            string flag;
            BD bd = new BD();
            string cadena = bd.Cadena;
            SqlConnection cn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand
            ("SELECT COUNT(*) FROM SWVMMPRODUCTO04 WHERE " +
            "(SWVM04PROD_ID = @SWVM04PROD_ID AND SWVM04CATE_ID = @SWVM04CATE_ID AND SWVM04PROV_ID = @SWVM04PROV_ID)", cn);
            cmd.Parameters.AddWithValue("@SWVM04PROD_ID", prod.Proid);
            cmd.Parameters.AddWithValue("@SWVM04CATE_ID", prod.Cateid);
            cmd.Parameters.AddWithValue("@SWVM04PROV_ID", prod.Provid);
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
            return flag;
            cn.Close();
        }
        
        public void Insertar(Producto producto)
        {
            Grabar(producto, "SP_INSERT_PRODUCTO");
        }

        public void Actualizar(Producto producto)
        {
            Grabar(producto, "SP_UPDATE_PRODUCTO");
        }

        public string Eliminar(int proid, int cateid, int provid)
        {
            string msg;
            BD bd = new BD();
            string cadena = bd.Cadena;
            SqlConnection cn = new SqlConnection(cadena);
            SqlCommand cm = new SqlCommand("SP_DELETE_PRODUCTO", cn);
            cm.CommandType = CommandType.StoredProcedure;
            SqlParameter param = cm.Parameters.Add("@ERROR", SqlDbType.VarChar, 5);
            param.Direction = ParameterDirection.Output;
            cm.Parameters.AddWithValue("@SWVM04PROD_ID", proid);
            cm.Parameters.AddWithValue("@SWVM04CATE_ID", cateid);
            cm.Parameters.AddWithValue("@SWVM04PROV_ID", provid);
            try
            {
                cn.Open();
                cm.ExecuteNonQuery();
                msg = "Producto Eliminado";
            }
            catch
            {
                msg = param.Value.ToString();
                if (msg == "ERROR")
                {
                    msg = "Error, existen cotizaciones con este producto.";
                }
            }
            cn.Close();
            return msg;
        }

        #region Funciones

        private void Grabar(Producto producto, string spTipo)
        {
            BD bd = new BD();
            string cadena = bd.Cadena;
            SqlConnection cn = new SqlConnection(cadena);
            SqlCommand cm = new SqlCommand(spTipo, cn);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@SWVM04PROD_ID", producto.Proid);
            cm.Parameters.AddWithValue("@SWVM04CATE_ID", producto.Cateid);
            cm.Parameters.AddWithValue("@SWVM04PROD_NOMBRE", producto.Nombre);
            cm.Parameters.AddWithValue("@SWVM04PRECIO", producto.Precio);
            cm.Parameters.AddWithValue("@SWVM04STOCK", producto.Stock);
            cm.Parameters.AddWithValue("@SWVM04DESCRIPCION", producto.Descripcion);
            cm.Parameters.AddWithValue("@SWVM04URL", producto.Url);
            cm.Parameters.AddWithValue("@SWVM04SIZE", producto.Size);
            cm.Parameters.AddWithValue("@SWVM04IMAGENAME", producto.Proid.ToString()+".JPG");
            cm.Parameters.AddWithValue("@SWVM04PROV_ID", producto.Provid);
            if (spTipo == "SP_INSERT_PRODUCTO") { cm.Parameters.AddWithValue("@SWVM04FECHA_REGPRO", DateTime.Now); }
            cm.Parameters.AddWithValue("@SWVM04FECHA_UPDATE", DateTime.Now);
            cn.Open();
            cm.ExecuteNonQuery();
            cn.Close();
        }
        #endregion
    }
}