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
    /// Cliente:
    /// Cliid, Nombre, Dir, Ciruc, Provincia, Ciudad, Fono1,
    /// Fono2, Email, Clave, Estado, Fechar
    /// </summary>
    public class Cliente
    {
        #region atributos
        private int cliid;

        public int Cliid
        {
            get { return cliid; }
            set { cliid = value; }
        }

        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        private string dir;

        public string Dir
        {
            get { return dir; }
            set { dir = value; }
        }

        private string ciruc;

        public string Ciruc
        {
            get { return ciruc; }
            set { ciruc = value; }
        }

        private string provincia;

        public string Provincia
        {
            get { return provincia; }
            set { provincia = value; }
        }

        private string ciudad;

        public string Ciudad
        {
            get { return ciudad; }
            set { ciudad = value; }
        }

        private string fono1;

        public string Fono1
        {
            get { return fono1; }
            set { fono1 = value; }
        }

        private string fono2;

        public string Fono2
        {
            get { return fono2; }
            set { fono2 = value; }
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
        
        #endregion       
    }
}