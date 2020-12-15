using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProductosLogicaNegocio
{
    public class Validador
    {
        public string EsNumeroEntero(string cadena)
        {
            Regex patron = new Regex("[^0-9]");
            if (patron.IsMatch(cadena))
            {
                throw new Exception();
            }
            return cadena.Trim();
        }

        public string EsAlfabetico(String cadena)
        {
            Regex patron = new Regex("[^a-zA-Z]");
            if (patron.IsMatch(cadena))
            {
                throw new Exception();
            }
            return cadena.Trim();
        }

        public string EsDecimal(String cadena)
        {
            Regex patron = new Regex( "[^\\d,\\d]");
            if (patron.IsMatch(cadena))
            {
                throw new Exception();
            }
            return cadena;
        }

        
    }
}
