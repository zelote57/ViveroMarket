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
    /// Producto:
    /// Proid, Cateid, Nombre, Precio,
    /// Stock, Descripcion, Url, Size, Image, Provid, Fechar
    /// </summary>
    public class Producto
    {
#region atributos

        private int proid;

        public int Proid
        {
            get { return proid; }
            set { proid = value; }
        }

        private int cateid;

        public int Cateid
        {
            get { return cateid; }
            set { cateid = value; }
        }

        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        private decimal precio;

        public decimal Precio
        {
            get { return precio; }
            set { precio = value; }
        }

        private int stock;

        public int Stock
        {
            get { return stock; }
            set { stock = value; }
        }

        private string descripcion;

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        private string url;

        public string Url
        {
            get { return url; }
            set { url = value; }
        }

        private string size;

        public string Size
        {
            get { return size; }
            set { size = value; }
        }

        private string image;

        public string Image
        {
            get { return image; }
            set { image = value; }
        }

        private int provid;

        public int Provid
        {
            get { return provid; }
            set { provid = value; }
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