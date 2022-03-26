using System;
using System.Collections.Generic;

namespace QuestionE
{
    class Program
    {
        private static List<int> ReadFilms()
        {
            List<int> films = new List<int>();
            string[] numbers = Console.ReadLine().Split(" ");
            for(int i = 0; i < int.Parse(numbers[0]); i++)
            {
                films.Add(int.Parse(numbers[i+1]));
            }

            return films;
        }

        static void Main(string[] args)
        {
            List<int> filmDays1 = ReadFilms();
            List<int> filmDays2 = ReadFilms();

            filmDays1.Sort();
            filmDays2.Sort();

            int totalFilms = 0;
            int lastWatchedFilm = -1;
            bool person1LikedLast = false;
            bool person2LikedLast = true;
            for(int i = 0; i < Math.Max(filmDays1.Count, filmDays2.Count); i++)
            {

            }
        }
    }
}
