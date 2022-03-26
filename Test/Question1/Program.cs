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
            // Input is sorted with smallest value first
            int[] values = Array.ConvertAll(Console.ReadLine().Split("/"), int.Parse);
            Array.Sort(values);

            // Gets the date and sorts it
            //foreach (int item in values)
            //{
            //    Console.WriteLine(item);
            //}

            // COuld check each combinations of the date and see if valid

            if (YMD(values))
            {
                // A day input of just 4 needs to be formated to 04
                Console.WriteLine("{0}-{1}-{2}", 2000 + values[0], values[1], values[2]);
            }
            

            // If none are valid output illegal
        }
    }
}
