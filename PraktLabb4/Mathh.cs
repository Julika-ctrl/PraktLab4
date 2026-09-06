using lababa3;
using lababa4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lababa3
{
    internal class Mathh
    {

        const int HUNDRED = 100;


        public static void ReadDouble(out double value)
        {
            while (!double.TryParse(Console.ReadLine(), out value))
            {
                Console.WriteLine("Введите число!!!");
            }

        }

    }
}
