using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Q2_Moons_and_Umbrellas
{
    class Q2_Moons_and_Umbrellas
    {
        static void Main(string[] args)
        {
            Run();
        }

        public static void Run()
        {
            // CJ pay X
            // JC pay Y

            // CJ?CC?

            // Given X and Y and a string representing the mural
            // how much does Cody Jamal need to pay if he finishes his mural with min cost? 

            // T = # Test Cases
            // X Y S   * T lines

            // find min cost

            int T = ReadInt();

            for (int i = 0; i < T; i++)
            {
                var line = ReadStringList();
                int X = Convert.ToInt32(line[0]);
                int Y = Convert.ToInt32(line[1]);
                string S = line[2];

                int cost = GetMinCost(X, Y, S);

                Console.WriteLine($"Case #{i + 1}: {cost}");
            }
        }

        private static int GetMinCost(int x, int y, string s)
        {
            // eliminate ? and just count CJs and JCs

            string noQs = s.Replace("?", "");

            int countX = Regex.Matches(noQs, "CJ").Count;
            int countY = Regex.Matches(noQs, "JC").Count;

            return countX * x + countY * y;
        }

        public static List<string> ReadStringList()
        {
            return (Console.ReadLine()).Split(' ').ToList();
        }
        public static int ReadInt()
        {
            return Convert.ToInt32(Console.ReadLine());
        }
    }
}
