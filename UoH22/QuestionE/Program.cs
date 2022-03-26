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

            allDays = new List<int>(filmDays1.filmDays);
            foreach (int day in filmDays2.filmDays)
            {
                if (!allDays.Contains(day))
                {
                    allDays.Add(day);
                }
            }

            allDays.Sort();

            int totalFilmsThatCanBeWatched = 0;
            bool person1cooldown = false;
            bool person2cooldown = false;
            foreach (int day in allDays)
            {
                bool person1Watched = false;
                bool person2Watched = false;
                if (filmDays1.filmDays.Contains(day) && filmDays2.filmDays.Contains(day))
                {
                    totalFilmsThatCanBeWatched++;
                    person1Watched = true;
                    person2Watched = true;
                }

                else if (filmDays1.filmDays.Contains(day) && person1cooldown == false && filmDays1.likedFilms != 0)
                {
                    totalFilmsThatCanBeWatched++;
                    filmDays1.likedFilms -= 1;
                    person1Watched = true;
                }

                else if (filmDays2.filmDays.Contains(day) && person2cooldown == false && filmDays2.likedFilms != 0)
                {
                    totalFilmsThatCanBeWatched++;
                    filmDays2.likedFilms -= 1;
                    person2Watched = true;
                }

                if (person1Watched && person2Watched)
                {
                    person1cooldown = false;
                    person2cooldown = false;
                }
                else if(person1Watched == true)
                {
                    person1cooldown = true;
                    person2cooldown = false;
                }
                else if(person2Watched == true)
                {
                    person1cooldown = false;
                    person2cooldown = true;
                }

            }

            Console.WriteLine(totalFilmsThatCanBeWatched);
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
