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
    /// ReporteDetalleCotiza: Codigo, NombreProd, PrecioUni,
    /// Cantidad, SubTotal
    /// </summary>
    public class ReporteDetalleCotiza
    {        
        private string codigo;

        public string Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
        
        private string nombreprod;

        public string NombreProd
        {
            get { return nombreprod; }
            set { nombreprod = value; }
        }

        private decimal preciouni;

        public decimal PrecioUni
        {
            get { return preciouni; }
            set { preciouni = value; }
        }

        private int cantidad;

        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        private decimal subtotal;

        public decimal SubTotal
        {
            get { return subtotal; }
            set { subtotal = value; }
        }
    }
}