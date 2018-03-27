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
    /// Proveedor: Provid, Empresa, Contacto, Cargo, Ruc, Dir, Fono1, Fono2, Pais,
    /// Provincia, Ciudad, Email, Clave, Estado.
    /// </summary>
    public class Proveedor
    {
# region atributos

        private int provid;

	public int Provid
	{
		get { return provid;}
		set { provid = value;}
	}

        private string empresa;

	public string Empresa
	{
		get { return empresa;}
		set { empresa = value;}
	}
        private string contacto;

	public string Contacto
	{
		get { return contacto;}
		set { contacto = value;}
	}

    private string cargo;

    public string Cargo
    {
        get { return cargo; }
        set { cargo = value; }
    }

        private string ruc;

	public string Ruc
	{
		get { return ruc;}
		set { ruc = value;}
	}

        private string dir;

	public string Dir
	{
		get { return dir;}
		set { dir = value;}
	}

        private string fono1;

	public string Fono1
	{
		get { return fono1;}
		set { fono1 = value;}
	}
        private string fono2;

	public string Fono2
	{
		get { return fono2;}
		set { fono2 = value;}
	}
        private string pais;

	public string Pais
	{
		get { return pais;}
		set { pais = value;}
	}

        private string provincia;

	public string Provincia
	{
		get { return provincia;}
		set { provincia = value;}
	}

     private string ciudad;

	public string Ciudad
	{
		get { return ciudad;}
		set { ciudad = value;}
	}

        private string email;

	public string Email
	{
		get { return email;}
		set { email = value;}
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
		get { return estado;}
		set { estado = value;}
	}
#endregion
    }
}