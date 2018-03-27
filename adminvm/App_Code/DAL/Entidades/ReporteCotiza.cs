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
    /// ReporteCotiza: Fecha, Cid, Cliente,
    /// Subtotal, Iva, Total
    /// </summary>
    public class ReporteCotiza
    {
        private DateTime fecha;

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        private int cid;

        public int Cid
        {
            get { return cid; }
            set { cid = value; }
        }

        private string cliente;

        public string Cliente
        {
            get { return cliente; }
            set { cliente = value; }
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

        private decimal total;

        public decimal Total
        {
            get { return total; }
            set { total = value; }
        }

    }
}