using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SICAP.Utelirias
{
    public class Validacion
    {
        public bool hasAnumber(string texto)
        {
            try
            {
                bool resultado = false;
                foreach(char letra in texto)
                {
                    if (char.IsNumber(letra))
                    {
                        resultado = true;
                    }
                }
                return resultado;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}