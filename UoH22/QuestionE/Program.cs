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

        struct filmInfo
        {
            public bool person1Liked;
            public bool person2Liked;
        }

        static void Main(string[] args)
        {
            List<int> filmDays1 = ReadFilms();
            List<int> filmDays2 = ReadFilms();

            Dictionary<int, filmInfo> films = new Dictionary<int, filmInfo>();
            for (int i = 0; i < filmDays1.Count; i++)
            {
                films[filmDays1[i]] = new filmInfo()
                {
                    person1Liked = true
                };
            }            
            
            for (int i = 0; i < filmDays2.Count; i++)
            {
                int day = filmDays2[i];
                films[day] = new filmInfo()
                {
                    person1Liked = films.ContainsKey(day),
                    person2Liked = true
                };
            }

            List<int> days = new List<int>();
            foreach(var kvp in films)
            {
                days.Add(kvp.Key);
            }

            days.Sort();

            int totalFilms = 0;
            bool person1LikedLast = true;
            bool person2LikedLast = true;
            for(int i = 0; i < days.Count; i++)
            {
                filmInfo info = films[days[i]];

                if(info.person1Liked && info.person2Liked)
                {
                    totalFilms++;
                    person1LikedLast = true;
                    person2LikedLast = true;
                    continue;
                }

                if ((!info.person1Liked && !person1LikedLast) || (!info.person2Liked && !person2LikedLast)) break; // I'm an idiot

                person1LikedLast = info.person1Liked;
                person2LikedLast = info.person2Liked;

                totalFilms++;
            }

            Console.WriteLine(totalFilms);
        }
    }
}
