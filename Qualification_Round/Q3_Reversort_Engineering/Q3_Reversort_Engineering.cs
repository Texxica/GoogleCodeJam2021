using System;
using System.Linq;
using System.Collections.Generic;

namespace Q3_Reversort_Engineering
{
    class Q3_Reversort_Engineering
    {
        static void Main(string[] args)
        {
            int T = ReadInt();

            for (int i = 0; i < T; i++)
            {
                var pair = ReadIntList();
                int N = pair[0];
                int C = pair[1];

                List<int> costs = FindCosts(N, C);
                List<int> result = FindUnsortedList(costs, N, C);

                Console.Write($"Case #{i + 1}:");
                foreach (var num in result)
                {
                    Console.Write(num > 0 ? " " + num : " IMPOSSIBLE");
                }

                Console.WriteLine();
            }
        }

        private static List<int> FindUnsortedList(List<int> costs, int n, int c)
        {
            if (costs[0] == -1)
                return costs;

            List<int> sorted = new List<int>(n);

            for (int i = 0; i < n; i++)
            {
                sorted.Add(i + 1);
            }

            for (int i = costs.Count - 1; i >= 0; i--)
            {
                int j = costs[i] + i - 1;

                Reverse(sorted, i, j);
            }

            return sorted;
        }

        private static List<int> FindCosts(int N, int C)
        {
            var retVal = new List<int>() { -1 };

            if (C < MinCost(N) || C > MaxCost(N))
            {
                return retVal;
            }

            int[] costs = new int[N - 1];
            int totalCost = 0;

            for (int i = 0; i < costs.Length; i++)
            {
                costs[i] = 1;  // [1,1,1,1,1,1] = cost is 6 // [7,6,5,4,3,2] = 27
                totalCost += 1; // 6
            }

            int index = 0;

            while (totalCost != C && index < costs.Length)
            {
                if (totalCost < C)
                {
                    costs[index] = N - index;   // [7,6,1,4,1,1]
                    totalCost += N - index - 1;
                }

                if (totalCost > C)
                {
                    if (costs[index] > 1)
                    {
                        costs[index]--;
                        totalCost--;
                    }
                }

                if (costs[index] == 1 || totalCost < C)
                {
                    index++;
                }
            }

            return costs.ToList();
        }

        private static int MinCost(int N)
        {
            return N - 1;
        }

        private static int MaxCost(int N)
        {
            int cost = 0;

            for (int i = 2; i <= N; i++)
            {
                cost += i;
            }

            return cost;
        }

        private static void Reverse(List<int> list, int i, int j)
        {
            if (i == j || j < i)
            {
                return;
            }

            Swap(list, i, j);
            Reverse(list, i + 1, j - 1);
        }

        private static void Swap(List<int> list, int i, int j)
        {
            int temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }

        public static List<int> ReadIntList()
        {
            List<int> list = new List<int>();
            String[] inputNums = (Console.ReadLine()).Split(' ');

            foreach (string num in inputNums)
            {
                list.Add(Convert.ToInt32(num));
            }
            return list;
        }

        public static int ReadInt()
        {
            return Convert.ToInt32(Console.ReadLine());
        }
    }
}
