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
    /// ProveedorBD: Insertar, ExisteProveedor
    /// </summary>
    public class ProveedorBD
    {
        public void Insertar(Proveedor proveedor)
        {
            BD bd = new BD();
            string cadena = bd.Cadena;
            SqlConnection cn = new SqlConnection(cadena);
            SqlCommand cm = new SqlCommand("SP_INSERT_PROVEEDOR", cn);
            cm.CommandType = CommandType.StoredProcedure;
            /*obtenemos serie de cliid*/
            int provid;
            provid = SerieProvid();
            cm.Parameters.AddWithValue("@SWVM01PROV_ID", provid);
            cm.Parameters.AddWithValue("@SWVM01NOM_EMPRESA",proveedor.Empresa);
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
            cm.Parameters.AddWithValue("@SWVM01ESTADO", "A");
            cm.Parameters.AddWithValue("@SWVM01FECHA_REGP", DateTime.Now);
            cm.Parameters.AddWithValue("@SWVM01FECHA_UPDATE", DateTime.Now);
            cn.Open();
            cm.ExecuteNonQuery();
            cn.Close();
        }

        public string ExisteProveedor(Proveedor proveedor)
        {
            /*Existe flag=1 else flag=0*/
            string flag;
            BD bd = new BD();
            string cadena = bd.Cadena;
            SqlConnection cn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand
                ("SELECT COUNT(*) FROM SWVMMPROVEEDOR01 WHERE (SWVM01RUC = @SWVM01RUC)"
                + " OR SWVM01EMAIL=@SWVM01EMAIL", cn);
            cmd.Parameters.AddWithValue("@SWVM01RUC", proveedor.Ruc);
            cmd.Parameters.AddWithValue("@SWVM01EMAIL", proveedor.Email);
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
                else { proveedor.Fono2 = reader.GetString(7); }
                proveedor.Pais = reader.GetString(8);
                proveedor.Provincia = reader.GetString(9);
                proveedor.Ciudad = reader.GetString(10);
                proveedor.Email = reader.GetString(11);
            }
            reader.Close();
            cn.Close();
            return proveedor;

        }

        #region Funciones
        private int SerieProvid()
        {
            BD bd = new BD();
            string cadena = bd.Cadena;
            SqlConnection cn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand
                ("SELECT SWVM01PROV_ID FROM SWVMMPROVEEDOR01 ORDER BY SWVM01PROV_ID DESC ", cn);
            // Abrimos la conexion
            cn.Open();
            // Obtenemos valor de cli_i
            int provid = Convert.ToInt32(cmd.ExecuteScalar());
            //Preguntamos si existe registro
            if (provid >= 1)
            {
                // ++1
                provid = provid + 1;
            }
            else
            {
                //Asignamos valor inicial al registro
                provid = 1;
            }
            return provid;
        }
        #endregion
    }
}