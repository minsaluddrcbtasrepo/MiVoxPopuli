using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InscripcionMinSalud.Lib
{
    public static class clsValidarTipo
    {

        public static bool isInt(string numString) 
        { 
            long number1 = 0;
            return long.TryParse(numString, out number1);                    
        }
        
        public static bool isDate(string dateString)
        {
            DateTime dateValue;
            return DateTime.TryParse(dateString, out dateValue);
        }
    }
}