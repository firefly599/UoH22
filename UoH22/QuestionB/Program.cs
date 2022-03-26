using System;
using System.Collections.Generic;

namespace Question2
{
    class Program
    {
        private static int[,] grid;
        private static int gridRows;
        private static int gridColumns;

        private static int GetGridSlot(int x, int y)
        {
            if (x < 0 || x >= gridColumns || y < 0 || y >= gridRows) return -1;
            return grid[y, x];
        }

        struct coords
        {
            public int x;
            public int y;
        }

        private static int travelStartX;
        private static int travelStartY;
        private static List<coords> traveledCoords;

        private static bool TravelDirection(int x, int y, int oldDirection)
        {
            traveledCoords.Add(new coords() {
                x = x,
                y = y
            });

            if (x == travelStartX && y == travelStartY && oldDirection != -1) return true;

            int left = GetGridSlot(x - 1, y); // 0
            int top = GetGridSlot(x, y - 1); // 1
            int right = GetGridSlot(x + 1, y); // 2
            int bottom = GetGridSlot(x, y + 1); // 3

            if (left == -1 || top == -1 || right == -1 || bottom == -1) return false;

            int newDirection = -1;
            if(top == 0 && oldDirection != 1)
            {
                newDirection = 1;
            }
            else if (right == 0 && oldDirection != 2)
            {
                newDirection = 2;
            }            
            else if (bottom == 0 && oldDirection != 3)
            {
                newDirection = 3;
            }            
            else if (left == 0 && oldDirection != 0)
            {
                newDirection = 0;
            }

            if (newDirection == -1) return false;

            int newX = 0;
            int newY = 0;
            switch(newDirection)
            {
                case 0:
                    newX = x - 1;
                    newY = y;
                    break;                
                case 1:
                    newX = x;
                    newY = y - 1;
                    break;                
                case 2:
                    newX = x + 1;
                    newY = y;
                    break;                
                case 3:
                    newX = x;
                    newY = y + 1;
                    break;
            }

            return TravelDirection(newX, newY, newDirection);
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

            // Checking for holes
            for (int row = 0; row < gridRows; row++)
            {
                for (int col = 0; col < gridColumns; col++)
                {
                    if (grid[row, col] != 0) continue;

                    traveledCoords = new List<coords>();
                    travelStartX = col;
                    travelStartY = row;

                    if (!TravelDirection(col, row, -1)) continue;

                    Console.WriteLine(col + "," + row);
                }
            }

            // Checking coast
            int[,] gridTest = new int[5, 6];

            int coastLine = 0;
            for (int row = 0; row < gridRows; row++)
            {
                for (int col = 0; col < gridColumns; col++)
                {
                    if (grid[row, col] == 0) continue;

                    int coastToAdd = 4;
                    if (GetGridSlot(col - 1, row) == 1)
                        coastToAdd -= 1;

                    if (GetGridSlot(col + 1, row) == 1)
                        coastToAdd -= 1;

                    if (GetGridSlot(col, row - 1) == 1)
                        coastToAdd -= 1;

                    if (GetGridSlot(col, row + 1) == 1)
                        coastToAdd -= 1;

                    gridTest[row, col] = coastToAdd;

                    coastLine += coastToAdd;
                }
            }

            for (int row = 0; row < gridRows; row++)
            {
                for (int col = 0; col < gridColumns; col++)
                {
                    Console.Write(gridTest[row, col] + " ");
                }

                Console.WriteLine();
            }

            Console.WriteLine(coastLine);
        }
    }
}