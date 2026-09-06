using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lababa3
{
    internal class ForArray
    {
        public static double[] AddValueD(double value, double[] arr) //generic
        {
            int N = arr.Length;
            for (int i = 1; i < N; i++)
            {
                arr[i - 1] = arr[i];
            }
            arr[N - 1] = value;
            return arr;
        }

        public static string[] AddValueS(string value, string[] arr)
        {
            int N = arr.Length;
            for (int i = 1; i < N; i++)
            {
                arr[i - 1] = arr[i];
            }
            arr[N - 1] = value;
            return arr;
        }




        public static void WriteAr(double[] array)
        {
            int n = array.Length;
            Console.WriteLine();
            for (int x = 0; x < array.Length; x++)
            {
                Console.Write("|" + array[x] + "|");
            }
            Console.WriteLine();
        }
        public static void WriteArStr(string[] array)
        {
            int n = array.Length;
            Console.WriteLine();
            for (int x = 0; x < array.Length; x++)
            {
                Console.Write("|" + array[x] + "|");
            }
            Console.WriteLine();
        }
    }
}
