using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_1Trim_Pablo_Miguel_del_Castillo_Barba_2DAM.Ejercicio1
{
    internal static class ExtensionInt
    {
        internal static void imprimirConRango(this int comienzo, int final)
        {
            int[] lista = Enumerable.Range(comienzo, final - comienzo + 1).ToArray();

            foreach (var num in lista)
            {
                Console.WriteLine(num);
            }

        }
    }
}
