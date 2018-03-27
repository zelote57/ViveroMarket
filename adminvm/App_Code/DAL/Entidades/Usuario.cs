using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace DAL.Entidades
{
    /// <summary>
    /// Usuario contiene:
    /// Userid, Nombre, Departamento, Cargo,Email, Clave, Estado, Fechar 
    /// </summary>
    public class Usuario
    {
        #region atributos
        private int userid;

        public int Userid
        {
            get { return userid; }
            set { userid = value; }
        }

        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        private string departamento;

        public string Departamento
        {
            get { return departamento; }
            set { departamento = value; }
        }

        private string cargo;

        public string Cargo
        {
            get { return cargo; }
            set { cargo = value; }
        }

        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private string clave;

        public string Clave
        {
            get { return clave; }
            set { clave = value; }
        }


        private string estado;

        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }
        
        private DateTime fechar;

        public DateTime Fechar
        {
            get { return fechar; }
            set { fechar = value; }
        }
        
        /*
        private DateTime fechau;
        
        public DateTime Fechau
        {
            get { return fechau; }
            set { fechau = value; }
        }*/
        #endregion       
    }
}