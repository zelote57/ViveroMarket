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
    /// ClienteBD: Insertar, ExisteCliente
    /// </summary>
    public class ClienteBD
    {
        public Cliente ConsultarC(int cliid)
        {
            BD bd = new BD();
            string cadena = bd.Cadena;
            SqlConnection cn = new SqlConnection(cadena);
            string sql = "SELECT * FROM SWVMMCLIENTE02 "
                        + "WHERE SWVM02CLI_ID = @SWVM02CLI_ID";
            SqlCommand cmd = new SqlCommand(sql, cn);
            // Añadimos el valor del parámetro de la consulta            
            cmd.Parameters.AddWithValue("@SWVM02CLI_ID", cliid);
            /* Instanciamos el cliente para devolver datos*/
            Cliente cliente = new Cliente();
            cn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                cliente.Cliid = reader.GetInt32(0);
                cliente.Nombre = reader.GetString(1);
                cliente.Dir = reader.GetString(2);
                cliente.Ciruc = reader.GetString(3);                
                cliente.Ciudad = reader.GetString(5);
                cliente.Fono1 = reader.GetString(6);
                cliente.Email = reader.GetString(8);
            }

            reader.Close();
            cn.Close();
            return cliente;
        }

        public void Insertar(Cliente cliente)
        {
            BD bd = new BD();
            string cadena = bd.Cadena;
            SqlConnection cn = new SqlConnection(cadena);
            SqlCommand cm = new SqlCommand("SP_INSERT_CLIENTE", cn);
            cm.CommandType = CommandType.StoredProcedure;
            /*obtenemos serie de cliid*/
            int cliid;
            cliid = SerieCliid();
            cm.Parameters.AddWithValue("@SWVM02CLI_ID", cliid);
            cm.Parameters.AddWithValue("@SWVM02NOMBRE", cliente.Nombre);
            cm.Parameters.AddWithValue("@SWVM02DIRECCION", cliente.Dir);
            cm.Parameters.AddWithValue("@SWVM02CIRUC", cliente.Ciruc);
            cm.Parameters.AddWithValue("@SWVM02PROVINCIA", cliente.Provincia);
            cm.Parameters.AddWithValue("@SWVM02CIUDAD", cliente.Ciudad);
            cm.Parameters.AddWithValue("@SWVM02TELEFONO1", cliente.Fono1);
            cm.Parameters.AddWithValue("@SWVM02TELEFONO2", cliente.Fono2);
            cm.Parameters.AddWithValue("@SWVM02EMAIL", cliente.Email);
            cm.Parameters.AddWithValue("@SWVM02CLAVE", cliente.Clave);
            cm.Parameters.AddWithValue("@SWVM02ESTADO", "A");
            cm.Parameters.AddWithValue("@SWVM02FECHA_REGC", DateTime.Now);
            cm.Parameters.AddWithValue("@SWVM02FECHA_UPDATE", DateTime.Now);
            cn.Open();
            cm.ExecuteNonQuery();
            cn.Close();
        }

        public string ExisteCliente(Cliente cliente) 
        {
            /*Existe flag=1 else flag=0*/
            string flag;            
            BD bd = new BD();
            string cadena = bd.Cadena;
            SqlConnection cn = new SqlConnection(cadena);
            /*SqlCommand cmd = new SqlCommand
                ("SELECT COUNT(*) FROM SWVMMCLIENTE02 WHERE (SWVM02CIRUC = @CIRUC)"
                +"OR (SUBSTRING(SWVM02CIRUC, 1, 10) = @CI)", cn);*/
            SqlCommand cmd = new SqlCommand
                ("SELECT COUNT(*) FROM SWVMMCLIENTE02"
                + " WHERE (SWVM02CIRUC = @CIRUC OR (SUBSTRING(SWVM02CIRUC, 1, 10)) = @CI)"
                + " OR SWVM02EMAIL = @SWVM02EMAIL", cn);
            cmd.Parameters.AddWithValue("@CIRUC", cliente.Ciruc);
            //Declara parametro que determina si un ruc ya fue ingresado antes como cedula, o viceversa
            if ((cliente.Ciruc.Length) == 13)            
            {cmd.Parameters.AddWithValue("@CI", cliente.Ciruc.Substring(0, 10));}
            else
            {cmd.Parameters.AddWithValue("@CI", cliente.Ciruc);}
            cmd.Parameters.AddWithValue("@SWVM02EMAIL", cliente.Email);
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

        public Cliente Sesion(Cliente cliente)
        {
            BD bd = new BD();
            string cadena = bd.Cadena;
            SqlConnection cn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand // devuelve cliente si email y contraseña son correctas
               ("SELECT * FROM SWVMMCLIENTE02 WHERE SWVM02EMAIL = @SWVM02EMAIL"
               +" AND SWVM02CLAVE = @SWVM02CLAVE", cn);
            // Añadimos el valor del parámetro de la consulta
            cmd.Parameters.AddWithValue("@SWVM02EMAIL", cliente.Email);
            cmd.Parameters.AddWithValue("@SWVM02CLAVE", cliente.Clave);
            /* Instanciamos el cliente para devolver datos*/
            Cliente customer = new Cliente();
            cn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                customer.Cliid = reader.GetInt32(0);
                customer.Nombre = reader.GetString(1).ToLower();
            }
            reader.Close();
            cn.Close();
            return customer;
        }

        public string SuClave(string emailcli)
        {            
            BD bd = new BD();
            string cadena = bd.Cadena;
            SqlConnection cn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand
                ("SELECT SWVM02CLAVE FROM SWVMMCLIENTE02 "
                + "WHERE (SWVM02EMAIL = @SWVM02EMAIL)", cn);
            cmd.Parameters.AddWithValue("@SWVM02EMAIL", emailcli);
            cn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            string clavencriptada=string.Empty;
            while (reader.Read())
            {
                clavencriptada = reader.GetString(0);
            }
            Funciones f = new Funciones();
            string suclave = f.desencriptar(clavencriptada);
            return suclave;
        }
      
        #region Funciones
        private int SerieCliid()
        {                        
            BD bd = new BD();
            string cadena = bd.Cadena;
            SqlConnection cn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand
                ("SELECT SWVM02CLI_ID FROM SWVMMCLIENTE02 ORDER BY SWVM02CLI_ID DESC ", cn);
            // Abrimos la conexion
            cn.Open();
            // Obtenemos valor de cli_i
            int cliid = Convert.ToInt32(cmd.ExecuteScalar());
            //Preguntamos si existe registro
            if (cliid >= 1000)
            {
                // ++1
                cliid = cliid + 1;
            }
            else
            {
                //Asignamos valor inicial al registro
                cliid = 1000;
            }
            return cliid;
        }
        #endregion
    }
}