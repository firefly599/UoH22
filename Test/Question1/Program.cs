using System;
using System.Linq;

namespace Question1
{
    class Program
    {

        static bool YMD(int[] values)
        {


            return true;
        }

        static void Main(string[] args)
        {
            int[] values = Array.ConvertAll(Console.ReadLine().Split("/"), int.Parse);
            Array.Sort(values);

            // Gets the date and sorts it
            foreach (int item in values)
            {
                Console.WriteLine(item);
            }
            if (YMD(values))
            {
                string outut =  
                Console.WriteLine("{0}-{1}-{2}", 2000 + values[0], valies[);
            }
            
        }
    }
}
