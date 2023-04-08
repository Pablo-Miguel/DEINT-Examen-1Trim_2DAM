using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_1Trim_Pablo_Miguel_del_Castillo_Barba_2DAM.Ejercicio2.Excepcion
{
    internal class ExceptionFormatDNI: Exception
    {
        public ExceptionFormatDNI() : base("El DNI introducido no cumple con el formato [Ejemplo a seguir: 12345678F]")
        {

        }
    }
}
