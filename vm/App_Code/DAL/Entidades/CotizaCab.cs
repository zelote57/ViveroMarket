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
    /// CotizaCab:
    /// Cotiid, Fecha, Cliid, Total, Estado, Fechau
    /// </summary>
    public class CotizaCab
    {
        private int cotiid;

        public int Cotiid
        {
            get { return cotiid; }
            set { cotiid = value; }
        }

        private DateTime fecha;

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }
        
        private int cliid;

        public int Cliid
        {
            get { return cliid; }
            set { cliid = value; }
        }

        private decimal total;

        public decimal Total
        {
            get { return total; }
            set { total = value; }
        }

        private string estado;

        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        private DateTime fechau;

        public DateTime Fechau
        {
            get { return fechau; }
            set { fechau = value; }
        }
    }
}
