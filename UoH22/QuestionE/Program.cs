using System;
using System.Collections.Generic;

namespace QuestionE
{
    class Program
    {
        private static Film ReadFilms()
        {

            List<int> filmDays = new List<int>();
            string[] numbers = Console.ReadLine().Split(" ");
            int likedNumber = int.Parse(numbers[0]);
            for (int i = 0; i < int.Parse(numbers[0]); i++)
            {
                filmDays.Add(int.Parse(numbers[i + 1]));
            }

            return new Film(filmDays, likedNumber);
        }

        static void Main(string[] args)
        {
            Film filmDays1 = ReadFilms();
            Film filmDays2 = ReadFilms();

            List<int> allDays = new List<int>();

            allDays = filmDays1.filmDays;
            foreach (int day in filmDays2.filmDays)
            {
                if (!allDays.Contains(day))
                {
                    allDays.Add(day);
                }
            }

            allDays.Sort();

        }
    }

    class Film
    {
        public List<int> filmDays = new List<int>();
        public int likedFilms;

        public Film(List<int> days, int likedFilms)
        {
            this.likedFilms = likedFilms;
            this.filmDays = days;
        }

    }

}
