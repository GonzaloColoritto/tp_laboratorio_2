using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Validaciones
    {
        public static  bool ValidarCadena(string stringToVerify)
        {
            for (int i = 0; i < stringToVerify.Length; i++)
            {
                //A=65 Z=90 and a=97 z=122
                if ((int)stringToVerify[i] < 65 || ((int)stringToVerify[i] > 90
                    && (int)stringToVerify[i] < 97) || (int)stringToVerify[i] > 122)
                    return false;
            }
            return true;
        }

    }
}
