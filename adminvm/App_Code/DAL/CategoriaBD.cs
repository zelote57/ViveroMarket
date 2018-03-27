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
    /// CategoriaBD: Consultar
    /// </summary>
    public class CategoriaBD
    {
        public List<Categoria> Consultar()
        {
            Funciones f = new Funciones();
            BD bd = new BD();
            string cadena = bd.Cadena;
            SqlConnection cn = new SqlConnection(cadena);
            string sql = "SELECT * FROM SWVMMCATEGORIA03";
            SqlCommand cm = new SqlCommand(sql, cn);
            List<Categoria> lista = new List<Categoria>();
            cn.Open();
            SqlDataReader reader = cm.ExecuteReader();            
            while (reader.Read())
            {
                Categoria cate = new Categoria();
                cate.Cateid = reader.GetInt32(0);
                cate.Nombre = f.Mayus(reader.GetString(1).ToLower());
                lista.Add(cate);
            }
            reader.Close();
            cn.Close();
            return lista;
        }        
    }
}