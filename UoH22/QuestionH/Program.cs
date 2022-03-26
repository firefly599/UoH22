using System;

namespace QuestionH
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] first = Array.ConvertAll(Console.ReadLine().Split(" "), int.Parse);
            int[] second = Array.ConvertAll(Console.ReadLine().Split(" "), int.Parse);

            int k = first[1];
            int q = first[0] / k;

            
            for (int i = 0; i < q; i++)
            {
                if (i != q - 1)
                {
                    Console.Write(second[k * (i + 1) - 1] + " ");
                }
                else
                {
                    Console.Write(second[k * (i + 1) - 1]);
                }    
            }
        }
    }
}
