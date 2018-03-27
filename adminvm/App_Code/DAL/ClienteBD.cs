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
       /// ClientesBD: ConsultarC, Sesion
       /// </summary>
    public class ClienteBD
    { 
        public Cliente ConsultarC (int cliid)
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
                cliente.Ciruc= reader.GetString(3);
                cliente.Provincia = reader.GetString(4);
                cliente.Ciudad = reader.GetString(5);
                cliente.Fono1 = reader.GetString(6);
                if (reader.IsDBNull(7))
                { cliente.Fono2 = ""; }
                else { cliente.Fono2 = reader.GetString(7);}
                cliente.Email = reader.GetString(8);                
             }

            reader.Close();
            cn.Close();
            return cliente;
        }

        public string ExisteCliente(Cliente cliente)
        {
           /*Existe flag=1 else flag=0*/
            string flag;
            BD bd = new BD();
            string cadena = bd.Cadena;
            SqlConnection cn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand
            ("SELECT COUNT(*) FROM SWVMMCLIENTE02 WHERE ((SWVM02CIRUC = @CIRUC"
            + " OR (SUBSTRING(SWVM02CIRUC, 1, 10) = @CI) OR SWVM02EMAIL =@SWVM02EMAIL)"
            + " AND SWVM02CLI_ID !=  @CLIID)", cn);//omite del resultado el registro actual
            cmd.Parameters.AddWithValue("@CIRUC", cliente.Ciruc);
            cmd.Parameters.AddWithValue("@CLIID", cliente.Cliid);
            cmd.Parameters.AddWithValue("@SWVM02EMAIL", cliente.Email);
            //Declara parametro que determina si un ruc ya fue ingresado antes como cedula, o viceversa
            if ((cliente.Ciruc.Length) == 13)
            { cmd.Parameters.AddWithValue("@CI", cliente.Ciruc.Substring(0, 10)); }
            else
            { cmd.Parameters.AddWithValue("@CI", cliente.Ciruc); }
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

        public void Insertar(Cliente cliente)
        {
            Grabar(cliente, "SP_INSERT_CLIENTE");
        }

        public void Actualizar(Cliente cliente)
        {
            Grabar(cliente, "SP_UPDATE_CLIENTE");
        }

        public string Eliminar(int cliid)
        {
            string msg;
            BD bd = new BD();    
            string cadena = bd.Cadena;
            SqlConnection cn = new SqlConnection(cadena);
            SqlCommand cm = new SqlCommand("SP_DELETE_CLIENTE", cn);
            cm.CommandType = CommandType.StoredProcedure;
            SqlParameter param = cm.Parameters.Add("@ERROR", SqlDbType.VarChar,5);
            param.Direction = ParameterDirection.Output;
            cm.Parameters.AddWithValue("@SWVM02CLI_ID", cliid);
            try
            {
                cn.Open();
                cm.ExecuteNonQuery();
                msg = "Cliente Eliminado";
            }
            catch
            {
                msg = param.Value.ToString();
                if (msg == "ERROR")
                {
                    msg = "Error, Existe una cotización para este Cliente.";
                }
            }
            cn.Close();
            return msg;
        }
            

        public List<Cliente> Consultar()
        {
            BD bd = new BD();
            string cadena = bd.Cadena;
            SqlConnection cn = new SqlConnection(cadena);

            string sql = "SELECT * FROM SWVMMCLIENTE02";
            SqlCommand cm = new SqlCommand(sql, cn);
            List<Cliente> lista = new List<Cliente>();
            cn.Open();
            SqlDataReader reader = cm.ExecuteReader();
            while (reader.Read())
            {
                Cliente clie = new Cliente();

                clie.Cliid = reader.GetInt32(0);
                clie.Nombre = reader.GetString(1);
                clie.Dir = reader.GetString(2);
                clie.Ciruc = reader.GetString(3);
                clie.Provincia = reader.GetString(4);
                clie.Ciudad = reader.GetString(5);
                clie.Fono1 = reader.GetString(6);
                if (reader.IsDBNull(7))
                { clie.Fono2 = ""; }
                else { clie.Fono2 = reader.GetString(7); }
                clie.Email = reader.GetString(8);
                if (reader.GetString(10) == "A") { clie.Estado = "Activo"; } else { clie.Estado = "Inactivo"; }
                clie.Fechar = reader.GetDateTime(11);
                lista.Add(clie);
            }
            reader.Close();
            cn.Close();
            return lista;
        }
       
        public Cliente Sesion (Cliente cliente)
        {
            BD bd = new BD();
            string cadena = bd.Cadena;
            SqlConnection cn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand // devuelve cliente si email y contraseña son correctas
               ("SELECT * FROM SWVMMCLIENTE02 WHERE SWVM02EMAIL = @SWVM02EMAIL"
               + " AND SWVM02CLAVE = @SWVM02CLAVE", cn);
            // Añadimos el valor del parámetro de la consulta
            cmd.Parameters.AddWithValue("@SWVM02EMAIL", cliente.Email);
            cmd.Parameters.AddWithValue("@SWVM02CLAVE", cliente.Clave);
            /* Instanciamos al cliente para devolver datos*/
            Cliente custumer = new Cliente();
            cn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                custumer.Nombre = reader.GetString(1).ToLower();
            }
            reader.Close();
            cn.Close();
            return custumer;
        }

        #region Funciones

        private void Grabar(Cliente cliente, string spTipo)
        {
            BD bd = new BD();
            string cadena = bd.Cadena;
            SqlConnection cn = new SqlConnection(cadena);
            SqlCommand cm = new SqlCommand(spTipo, cn);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@SWVM02CLI_ID", cliente.Cliid);
            cm.Parameters.AddWithValue("@SWVM02NOMBRE", cliente.Nombre);
            cm.Parameters.AddWithValue("@SWVM02DIRECCION", cliente.Dir);
            cm.Parameters.AddWithValue("@SWVM02CIRUC", cliente.Ciruc);
            cm.Parameters.AddWithValue("@SWVM02PROVINCIA", cliente.Provincia);
            cm.Parameters.AddWithValue("@SWVM02CIUDAD", cliente.Ciudad);
            cm.Parameters.AddWithValue("@SWVM02TELEFONO1", cliente.Fono1);
            cm.Parameters.AddWithValue("@SWVM02TELEFONO2", cliente.Fono2);
            cm.Parameters.AddWithValue("@SWVM02EMAIL", cliente.Email);
            cm.Parameters.AddWithValue("@SWVM02CLAVE", cliente.Clave);
            cm.Parameters.AddWithValue("@SWVM02ESTADO", cliente.Estado);
            if (spTipo == "SP_INSERT_CLIENTE") { cm.Parameters.AddWithValue("@SWVM02FECHA_REGC", DateTime.Now); }
            cm.Parameters.AddWithValue("@SWVM02FECHA_UPDATE", DateTime.Now);
            cn.Open();
            cm.ExecuteNonQuery();
            cn.Close();
        }
        #endregion

	 }
}
