using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace DAL
{
    /// <summary>
    /// Valida: Cedula
    /// </summary>
    public class Valida
    {
        public string Cedula(string ci)
        {            
            string resp = "";
            //constante que indica numero de provincias en el Ecuador
            int nprov = 24;

            int prov = Convert.ToInt32(ci.Substring(0, 2));
            // si digitos de provincia no es mayor que 0 y menor que 24 Error en provincia
            if (!((prov > 0) && (prov <= nprov))) { resp = "Error en los 2 primeros dígitos de Ci/Ruc"; }
            else
            {
                int[] d = new int[10];
                //Asignamos el string a un array
                for (int i = 0; i < d.Length; i++)
                {
                    d[i] = Convert.ToInt32(ci[i] + "");
                }

                int imp = 0;
                int par = 0;

                //sumamos los duplos de posición impar
                for (int i = 0; i < d.Length; i += 2)
                {
                    d[i] = ((d[i] * 2) > 9) ? ((d[i] * 2) - 9) : (d[i] * 2);
                    imp += d[i];
                }

                //sumamos los digitos de posición par
                for (int i = 1; i < (d.Length - 1); i += 2)
                {
                    par += d[i];
                }

                //Sumamos los dos resultados
                int suma = imp + par;

                //Obtenemos residuo para verificar ultimo digito
                int residuo = suma % 10;
                // Si residuo=0, ultimodigito=0, caso contrario 10 - residuo
                int d10 = residuo == 0 ? 0 : 10 - residuo;

                //si el décimo dígito calculado es igual al digitado la cédula es correcta
                if (d10 == d[9]) { resp = "true"; } else { resp = "Error Cedula o Ruc inválido"; }
            }

            return resp;
        }    
    }
}