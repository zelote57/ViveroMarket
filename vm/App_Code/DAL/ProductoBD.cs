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
    /// ProductoBD: Consultar
    /// </summary>
    public class ProductoBD
    {

        public Producto Consultar(int proid, int cateid, int prov)
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
            cmd.Parameters.AddWithValue("@SWVM04PROV_ID", prov);
            /* Instanciamos producto para devolver datos*/
            Producto producto = new Producto();            
            cn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                producto.Nombre = reader.GetString(2).ToLower();
                producto.Precio = reader.GetDecimal(3);
                producto.Stock = reader.GetInt32(4);
                producto.Descripcion = reader.GetString(5).ToLower();
                producto.Size = reader.GetString(7);
                producto.Image = reader.GetString(8);
                producto.Provid = reader.GetInt32(9);
            }
            reader.Close();
            cn.Close();
            return producto;
        }

        public void ActualizaStock(int proid, int cateid, int prov, int newstock)
        {
            BD bd = new BD();
            string cadena = bd.Cadena;
            SqlConnection cn = new SqlConnection(cadena);
            string sql = "UPDATE SWVMMPRODUCTO04 "
			             + "SET SWVM04STOCK=@SWVM04STOCK "
                         + "WHERE (SWVM04PROD_ID=@SWVM04PROD_ID "
                         +"AND SWVM04CATE_ID=@SWVM04CATE_ID AND "
                         +"SWVM04PROV_ID=@SWVM04PROV_ID)";
            SqlCommand cmd = new SqlCommand(sql, cn);
            // Añadimos el valor del parámetro de la consulta
            cmd.Parameters.AddWithValue("@SWVM04PROD_ID", proid);
            cmd.Parameters.AddWithValue("@SWVM04CATE_ID", cateid);
            cmd.Parameters.AddWithValue("@SWVM04PROV_ID", prov);
            cmd.Parameters.AddWithValue("@SWVM04STOCK", newstock);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();  
        }
    }
}