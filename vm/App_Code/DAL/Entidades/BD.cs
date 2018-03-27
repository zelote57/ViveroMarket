using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using System.Collections.Generic;
using System.Text;

namespace DAL.Entidades
{
    /// <summary>
    /// Clase DAL (Capa de Acceso a Datos)
    /// </summary>
    public class BD
    {
        /// <summary>
        /// BD Contiene la cadena de conexión
        /// </summary>
        /// 

        public string Cadena
        {
            get
            {
                return System.Configuration.ConfigurationManager.ConnectionStrings
                   ["ViveroDBConnectionString"].ConnectionString;
            }            
        }
    }
}
