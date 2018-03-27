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
    /// CotizaBD: LastCotiza, InsertCab, InsertDet,
    /// ConsultarCab, ConsultarDet
    /// </summary>
    public class CotizaBD
    {
        public int LastCotiza()
        {
            //int cotiid devolverá la última cotización
            int cotiid=0;
            BD bd = new BD();
            string cadena = bd.Cadena;
            SqlConnection cn = new SqlConnection(cadena);
            string sql = "SELECT SWVM06COTI_ID FROM SWVMCCAB_COTI06 ORDER BY SWVM06COTI_ID ASC";
            SqlCommand cmd = new SqlCommand(sql, cn);            
            cn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                cotiid = reader.GetInt32(0);
            }
            reader.Close();
            cn.Close();
            return cotiid;
        }

        public void InsertCab(CotizaCab cabecera)
        {
            BD bd = new BD();
            string cadena = bd.Cadena;
            SqlConnection cn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand("SP_INSERT_CABCOTI", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            //insertamos según parametros
            cmd.Parameters.AddWithValue("@SWVM06COTI_ID", cabecera.Cotiid);
            cmd.Parameters.AddWithValue("@SWVM06FECHA", DateTime.Now);
            cmd.Parameters.AddWithValue("@SWVM06CLI_ID", cabecera.Cliid);
            cmd.Parameters.AddWithValue("@SWVM06TOTAL", cabecera.Total);
            cmd.Parameters.AddWithValue("@SWVM06ESTADO", cabecera.Estado);
            cmd.Parameters.AddWithValue("@SWVM06FECHA_UPDATE", DateTime.Now);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();  
        }

        public void InsertDet(CotizaDet detalle)
        {
            BD bd = new BD();
            string cadena = bd.Cadena;
            SqlConnection cn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand("SP_INSERT_DETCOTI", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            //inserts según parametros
            cmd.Parameters.AddWithValue("@SWVM07COTI_ID", detalle.Cotiid);
            cmd.Parameters.AddWithValue("@SWVM07PROD_ID", detalle.Prodid);
            cmd.Parameters.AddWithValue("@SWVM07CATE_ID", detalle.Cateid);
            cmd.Parameters.AddWithValue("@SWVM07CANTIDAD", detalle.Cantidad);
            cmd.Parameters.AddWithValue("@SWVM07PRECIO", detalle.Precio);
            cmd.Parameters.AddWithValue("@SWVM07SUBTOTAL", detalle.Subtotal);
            cmd.Parameters.AddWithValue("@SWVM07IVA", detalle.Iva);
            cmd.Parameters.AddWithValue("@SWVM07PROV_ID", detalle.Prov);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }        

        public CotizaCab ConsultarCab(int cotiid)
        {
            BD bd = new BD();
            string cadena = bd.Cadena;
            SqlConnection cn = new SqlConnection(cadena);

            string sql = "SELECT * FROM SWVMCCAB_COTI06 "
                        + "WHERE SWVM06COTI_ID=@SWVM06COTI_ID";
            SqlCommand cmd = new SqlCommand(sql, cn);
            // Añadimos el valor del parámetro de la consulta            
            cmd.Parameters.AddWithValue("@SWVM06COTI_ID", cotiid);
            /* Instanciamos el proveedor para devolver datos*/
            CotizaCab ccab = new CotizaCab();
            cn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ccab.Fecha = reader.GetDateTime(1);
                ccab.Cliid = reader.GetInt32(2);
                ccab.Total = reader.GetDecimal(3);
            }
            reader.Close();
            cn.Close();
            return ccab;

        }

        public List<CotizaDet> ConsultarDet(int cotiid)
        {
            BD bd = new BD();
            string cadena = bd.Cadena;
            SqlConnection cn = new SqlConnection(cadena);
            string sql = "SELECT * FROM SWVMDDET_COTI07 "
                         + "WHERE SWVM07COTI_ID=@SWVM07COTI_ID";
            SqlCommand cm = new SqlCommand(sql, cn);
            cm.Parameters.AddWithValue("@SWVM07COTI_ID", cotiid);
            List<CotizaDet> lista = new List<CotizaDet>();
            cn.Open();
            SqlDataReader reader = cm.ExecuteReader();
            while (reader.Read())
            {
                CotizaDet cdet = new CotizaDet();
                cdet.Prodid = reader.GetInt32(1);
                cdet.Cateid = reader.GetInt32(2);
                cdet.Cantidad = reader.GetInt32(3);
                cdet.Precio = reader.GetDecimal(4);
                cdet.Subtotal = reader.GetDecimal(5);
                cdet.Prov = reader.GetInt32(7);
                lista.Add(cdet);
            }
            reader.Close();
            cn.Close();
            return lista;
        }
    }
}
