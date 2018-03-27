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
    /// ItemCart: Pid, Cid, Codigo, NombreProd, PrecioUni,
    /// Cantidad, SubTotal, Image, MsgStock, lnkDetails, Prov
    /// </summary>
    public class ItemCart
    {
        private int pid;

        public int Pid
        {
            get { return pid; }
            set { pid = value; }
        }

        private int cid;

        public int Cid
        {
            get { return cid; }
            set { cid = value; }
        }

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


        private string image;

        public string Image
        {
            get { return image; }
            set { image = value; }
        }

        private string msgstock;

        public string MsgStock
        {
            get { return msgstock; }
            set { msgstock = value; }
        }

        private string lnkdetails;

        public string lnkDetails
        {
            get { return lnkdetails; }
            set { lnkdetails = value; }
        }

        private int prov;

        public int Prov
        {
            get { return prov; }
            set { prov = value; }
        }

	
    }
}