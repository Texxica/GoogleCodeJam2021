using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Q2_Moons_and_Umbrellas
{
    class Q2_Moons_and_Umbrellas
    {
        // Given X and Y and a string representing the mural
        // how much does Cody Jamal need to pay if he finishes his mural with min cost? 

        // T = # Test Cases
        // (X Y S) * T lines

        // find min cost
        static void Main(string[] args)
        {
            int T = ReadInt();

            for (int i = 0; i < T; i++) // for each test case
            {
                var line = ReadStringList();
                int X = Convert.ToInt32(line[0]);   // CJ costs X
                int Y = Convert.ToInt32(line[1]);   // JC costs Y
                string S = line[2];                 // string of Cs Js and ?s

                int cost = GetMinCost(X, Y, S);     // find minimum cost

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
            return Console.ReadLine().Split(' ').ToList(); // split the string on every space into a list
        }

        public static int ReadInt()
        {
            return Convert.ToInt32(Console.ReadLine());
        }
    }
}
