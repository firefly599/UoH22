using System;
using System.Collections.Generic;

namespace QuestionE
{
    class Program
    {
        public static List<int> allDays = new List<int>();
        private static Film ReadFilms()
        {
            Dictionary<int, int> filmDaysDic = new Dictionary<int, int>();
            string[] numbers = Console.ReadLine().Split(" ");
            int likedNumber = int.Parse(numbers[0]);


            for (int i = 0; i < int.Parse(numbers[0]); i++)
            {
                int day = int.Parse(numbers[i + 1]);
                filmDaysDic.Add(day, day);
                if (!allDays.Contains(day))
                {
                    allDays.Add(day);
                }
            }

            return new Film(filmDaysDic, likedNumber);
        }

        static void Main(string[] args)
        {
            Film filmDays1 = ReadFilms();
            Film filmDays2 = ReadFilms();

            int totalFilmsThatCanBeWatched = 0;
            bool person1cooldown = false;
            bool person2cooldown = false;
            foreach (int day in allDays)
            {
                bool person1Watched = false;
                bool person2Watched = false;

                bool person1Contains = filmDays1.filmDays.ContainsKey(day);
                bool person2Contains = filmDays1.filmDays.ContainsKey(day);



                if (person1Contains && person2Contains)
                {
                    totalFilmsThatCanBeWatched++;
                    person1Watched = true;
                    person2Watched = true;
                    filmDays1.likedFilms -= 1;
                    filmDays2.likedFilms -= 1;

                }

                else if (person1Contains && person1cooldown == false && filmDays1.likedFilms != 0)
                {
                    totalFilmsThatCanBeWatched++;
                    filmDays1.likedFilms -= 1;
                    person1Watched = true;
                }

                else if (person2Contains && person2cooldown == false && filmDays2.likedFilms != 0)
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
        public Dictionary<int, int> filmDays = new Dictionary<int, int>();
        public int likedFilms;

        public Film(Dictionary<int, int> days, int likedFilms)
        {
            this.likedFilms = likedFilms;
            this.filmDays = days;
        }

    }

}
