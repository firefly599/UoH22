using System;
using System.Linq;

namespace QuestionG
{
    class Program
    {
        static bool CheckOverflow(int no1, int no2, int carried)
        {

            if (no1 + no2 + carried > 9)
            {
                return true;
            }
            return false;
        }

        static void Main(string[] args)
        {
            int carry;
            int previous;
            int size;
            int size1;
            int size2;
            int num1;
            int num2;
            while (true)
            {
                carry = 0;
                string[] input = Console.ReadLine().Split(" ");
                long[] values = Array.ConvertAll(input, long.Parse);
                if (values[0] == 0 && values[1] == 0)
                {
                    break;
                }

                size1 = input[0].Length - 1;
                size2 = input[1].Length - 1;
                previous = 0;

                size = Math.Max(size1, size2);
                for (int i = size; i >= 0; i--)
                {
                    num1 = 0;
                    num2 = 0;

                    if (size1 >= 0)
                    {
                        num1 = int.Parse(input[0][size1].ToString());
                    }
                    if (size2 >= 0)
                    {
                        num2 = int.Parse(input[1][size2].ToString());
                    }

                    if (CheckOverflow(num1, num2, previous))
                    {
                        carry++;
                        previous = 1;
                    }
                    else    
                    {
                        previous = 0;
                    }

                    size1--;
                    size2--;
                }

                if (carry == 0)
                {
                    Console.WriteLine("No carry operation.");
                }
                else if (carry == 1)
                {
                    Console.WriteLine("1 carry operation.");
                }
                else
                {
                    Console.WriteLine("{0} carry operations.", carry);
                }
            }
        }
    }
}
