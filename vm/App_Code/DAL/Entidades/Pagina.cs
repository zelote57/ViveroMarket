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
    /// Pagina: Pagid, Content, Nombre, Descripcion,
    /// Fechar, Fechau, Userid
    /// </summary>
    public class Pagina
    {
        private int pagid;

        public int Pagid
        {
            get { return pagid; }
            set { pagid = value; }
        }

        private string content;

        public string Content
        {
            get { return content; }
            set { content = value; }
        }

        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        private string descripcion;

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        private DateTime fechar;

        public DateTime Fechar
        {
            get { return fechar; }
            set { fechar = value; }
        }

        private DateTime fechau;

        public DateTime Fechau
        {
            get { return fechau; }
            set { fechau = value; }
        }

        private int userid;

        public int Userid
        {
            get { return userid; }
            set { userid = value; }
        }
    }
}