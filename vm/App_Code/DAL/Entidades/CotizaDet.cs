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
    /// CotizaDet: Cotiid, Prodid, Cateid,
    /// Cantidad, Precio, Subtotal, Iva, Prov
    /// </summary>
    public class CotizaDet
    {
        private int cotiid;

        public int Cotiid
        {
            get { return cotiid; }
            set { cotiid = value; }
        }

        private int prodid;

        public int Prodid
        {
            get { return prodid; }
            set { prodid = value; }
        }

        private int cateid;

        public int Cateid
        {
            get { return cateid; }
            set { cateid = value; }
        }

        private int cantidad;

        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        private decimal precio;

        public decimal Precio
        {
            get { return precio; }
            set { precio = value; }
        }

        private decimal subtotal;

        public decimal Subtotal
        {
            get { return subtotal; }
            set { subtotal = value; }
        }

        private decimal iva;

        public decimal Iva
        {
            get { return iva; }
            set { iva = value; }
        }

        private int prov;

        public int Prov
        {
            get { return prov; }
            set { prov = value; }
        }

    }
}
