using System;

namespace Question2
{
    class Program
    {
        private static int[,] grid;
        private static int gridRows;
        private static int gridColumns;

        private static bool CheckGridSlot(int x, int y)
        {
            if (x < 0 || x >= gridColumns || y < 0 || y >= gridRows) return false;
            return grid[y, x] == 1;
        }

        static void Main(string[] args)
        {
            //string[] gridSizes = Console.ReadLine().Split(" ");
            gridRows = 5;// int.Parse(gridSizes[0]);
            gridColumns = 6;// int.Parse(gridSizes[1]);

            grid = new int[5, 6]
            {
                { 0, 1, 1, 1, 1, 0 },
                { 0, 1, 0, 1, 1, 0 },
                { 1, 1, 1, 0, 0, 0 },
                { 0, 0, 0, 0, 1, 0 },
                { 0, 0, 0, 0, 0, 0 },
            };

            //grid = new int[gridRows, gridColumns];
            /*for (int i = 0; i < gridRows; i++)
            {
                string line = Console.ReadLine();
                for (int j = 0; j < gridColumns; j++)
                {
                    grid[i, j] = int.Parse("" + line[j]);
                }
            }*/

            int coastLine = 0;
            for (int row = 0; row < gridRows; row++)
            {
                for (int col = 0; col < gridColumns; col++)
                {
                    if (grid[row, col] == 0) continue;

                    int coastToAdd = 4;
                    if (CheckGridSlot(col - 1, row - 1))
                        coastToAdd -= 1;

                    if (CheckGridSlot(col - 1, row))
                        coastToAdd -= 1;

                    if (CheckGridSlot(col + 1, row + 1))
                        coastToAdd -= 1;

                    if (CheckGridSlot(col + 1, row))
                        coastToAdd -= 1;

                    grid[row, col] = coastToAdd;

                    coastLine += coastToAdd;
                }
            }

            for (int row = 0; row < gridRows; row++)
            {
                for (int col = 0; col < gridColumns; col++)
                {
                    Console.Write(grid[row, col] + " ");
                }

                Console.WriteLine();
            }

            Console.WriteLine(coastLine);
        }
    }
}