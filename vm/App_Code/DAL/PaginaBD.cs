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
    /// PaginaBD: 
    /// </summary>
    public class PaginaBD
    {
        public List<Pagina> Consultar()
        {
            BD bd = new BD();
            string cadena = bd.Cadena;
            SqlConnection cn = new SqlConnection(cadena);
            string sql = "SELECT * FROM SWVMHPAGINA10";
            SqlCommand cm = new SqlCommand(sql, cn);
            List<Pagina> lista = new List<Pagina>();
            cn.Open();
            SqlDataReader reader = cm.ExecuteReader();
            Pagina pv = new Pagina();
            pv.Pagid = 0;
            pv.Nombre = "NINGUNA";
            lista.Add(pv);
            while (reader.Read())
            {
                Pagina p = new Pagina();
                p.Pagid = reader.GetInt32(0);                
                p.Nombre = reader.GetString(2);                
                lista.Add(p);
            }
            reader.Close();
            cn.Close();
            return lista;
        }

        public Pagina ConsultarP(int pagid)
        {
            BD bd = new BD();
            string cadena = bd.Cadena;
            SqlConnection cn = new SqlConnection(cadena);
            string sql = "SELECT * FROM SWVMHPAGINA10 "
                        + "WHERE SWVM10PAG_ID = @SWVM10PAG_ID";
            SqlCommand cmd = new SqlCommand(sql, cn);
            // Añadimos el valor del parámetro de la consulta            
            cmd.Parameters.AddWithValue("@SWVM10PAG_ID", pagid);
            /* Instanciamos el pagina para devolver datos*/
            Pagina p = new Pagina();
            cn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                p.Content = reader.GetString(1);   
            }
            reader.Close();
            cn.Close();
            return p;
        }

        public void Actualizar(Pagina page)
        {
            BD bd = new BD();
            string cadena = bd.Cadena;
            SqlConnection cn = new SqlConnection(cadena);
            //construimos cadena para el update
            string sql = "UPDATE SWVMHPAGINA10 "
                        + "SET SWVM10CONTENT=@SWVM10CONTENT, "
                        +"SWVM10FECHAU=@SWVM10FECHAU, "
                        + "SWVM10USER_ID=@SWVM10USER_ID "
                        + "WHERE SWVM10PAG_ID = @SWVM10PAG_ID";
            SqlCommand cmd = new SqlCommand(sql, cn);
            // Añadimos valores a parámetros para el update            
            cmd.Parameters.AddWithValue("@SWVM10PAG_ID", page.Pagid);
            cmd.Parameters.AddWithValue("@SWVM10CONTENT", page.Content);
            cmd.Parameters.AddWithValue("@SWVM10FECHAU", DateTime.Now);
            cmd.Parameters.AddWithValue("@SWVM10USER_ID", page.Userid);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }
    }
}