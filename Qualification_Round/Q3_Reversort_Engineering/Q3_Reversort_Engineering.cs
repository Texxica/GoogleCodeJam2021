using System;
using System.Linq;
using System.Collections.Generic;

namespace Q3_Reversort_Engineering
{
    class Q3_Reversort_Engineering
    {
        static void Main(string[] args)
        {
            int T = ReadInt();  // Number of Test Cases

            for (int i = 0; i < T; i++)
            {
                var pair = ReadIntList();
                int N = pair[0];    // Size of the list to unsort
                int C = pair[1];    // Cost associated with the reversort algorithm

                List<int> costs = FindCosts(N, C); // For the total cost given, find a list of costs associated with each pass of the algorithm
                List<int> result = FindUnsortedList(costs, N, C); // Apply the found costs per algoirthm pass to a sorted list to unsort it

                Console.Write($"Case #{i + 1}:");
                foreach (var num in result)
                {
                    Console.Write(num > 0 ? " " + num : " IMPOSSIBLE");
                }
                Console.WriteLine();

                //Console.Write("Cost List: ");
                //PrintList(costs);
            }
        }

        private static List<int> FindUnsortedList(List<int> costs, int n, int c)
        {
            if (costs[0] == -1)
                return costs;

            List<int> sorted = new List<int>(n);

            for (int i = 0; i < n; i++) // start with a sorted list from 1 to n-1
            {
                sorted.Add(i + 1);
            }

            for (int i = costs.Count - 1; i >= 0; i--) // apply algorithm backwards (in reverse)
            {
                int j = costs[i] + i - 1;

                Reverse(sorted, i, j);
            }

            return sorted; // which is actually now unsorted
        }

        private static List<int> FindCosts(int N, int C)
        {
            var retVal = new List<int>() { -1 };

            if (C < MinCost(N) || C > MaxCost(N)) 
            {
                return retVal; // if the cost is not possible, which can be found with a simple calculation, return list with -1
            }

            int[] costs = new int[N - 1]; // list to represent each pass of the algorithm, the largest cost possible is on the first pass, ie., if it reversed the whole list, cost would be n
            int totalCost = 0; // counter to keep track of current total cost

            // Set the minimum costs for the list and algorithm
            for (int i = 0; i < costs.Length; i++)
            {
                costs[i] = 1;  // For N=7... [1,1,1,1,1,1] = min cost is 6 // [7,6,5,4,3,2] = max cost possible is 27
                totalCost += 1; // 6
            }

            int index = 0;

            // iteratively find the costs list that would equal the given cost C
            // set the first value to be it's max, count the costs, and adjust as needed
            while (totalCost != C && index < costs.Length) 
            {
                if (totalCost < C)
                {
                    costs[index] = N - index;   // [7,6,1,4,1,1]
                    totalCost += N - index - 1;
                }

                if (totalCost > C) // we've gone to far, reduce the cost
                {
                    if (costs[index] > 1)
                    {
                        costs[index]--;
                        totalCost--;
                    }
                }

                if (costs[index] == 1 || totalCost < C) // move to next spot if you are at cost of 1, or are still under total cost
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

        private static List<int> ReadIntList()
        {
            List<int> list = new List<int>();
            String[] inputNums = (Console.ReadLine()).Split(' ');

            foreach (string num in inputNums)
            {
                list.Add(Convert.ToInt32(num));
            }

            return list;
        }

        private static int ReadInt()
        {
            return Convert.ToInt32(Console.ReadLine());
        }

        private static void PrintList(List<int> list)
        {
            foreach (int num in list)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
        }
    }
}
