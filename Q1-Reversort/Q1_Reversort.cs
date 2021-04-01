using System;

namespace Q1_Reversort
{
    class Q1_Reversort
    {

        /**
         * Read input and perform Reversort on given test cases.
        */
        static void Main(string[] args)
        {
            int T = ReadInt(); // Read in the number of trials in this test

            for (int i = 0; i < T; i++)
            {
                int N = ReadInt(); // Read in the number of ints in the incoming array (not used)

                var list = ReadIntList(); // Read in the list of distinct integers to be sorted

                int cost = Reversort(list);
                
                PrintResults(i + 1, cost);
            }
        }

        /**
        * Perform the Reversort operation to sort a list of distinct numbers 
        * by finding the next minimum number in the unsorted portion of the array and reversing 
        * all the numbers between the current index and the minimum number index.
        * 
        * Find the cost of the sort, which is the count of integers accessed per round of the algorithm.
        * 
        * On each pass of the algortihm...
        * If it sorts one number, cost is one, nothing happens.
        * If it sorts two number, cost is two, swaps them.
        * If it sorts n numbers, cost is n, reverses whole list.
        */
        public static int Reversort(int[] list)
        {
            int cost = 0;

            for (int i = 0; i < list.Length - 1; i++)
            {
                int j = MinIndex(list, i, list.Length - 1);
                cost += (j - i + 1);

                Reverse(list, i, j);
            }

            return cost;
        }

        /**
         * Recursively reverse all the values in a list from i to j by swapping outer values of the list.
         */
        private static void Reverse(int[] list, int i, int j)
        {
            if (i == j || j < i)
            {
                return;
            }

            Swap(list, i, j);
            Reverse(list, i + 1, j - 1);
        }

        /**
         * Swap values in the list at indices i and j.
         */
        private static void Swap(int[] list, int i, int j)
        {
            // if i and j are within the bounds of an array, swap their values
            if (WithinArrayBounds(list.Length, i, j))
            {
                int temp = list[i];
                list[i] = list[j];
                list[j] = temp;
            }
        }

        /**
         * Confirm i and j are within the bounds of an array
         */
        private static bool WithinArrayBounds(int length, int i, int j)
        {
            return (i >= 0 && j >= 0 && i < length && j < length);
        }

        /**
         * Find the minimum integer in a list between indices i and j inclusive.
         */
        private static int MinIndex(int[] list, int i, int j)
        {
            // if i and j point to the same int, return it as the min
            if (i == j)
            {
                return i;
            }

            // if j is less than i swap them to still find the min between
            if (j < i)
            {
                int temp = j;
                j = i;
                i = temp;
            }

            // set i and j to be bounded by the size of the array
            i = (i < 0) ? 0 : i;
            j = (j >= list.Length) ? list.Length - 1 : j;

            // set the minimum entry to be at index i
            int minIndex = i;
            int min = list[minIndex];

            // find any other entry smaller than current minimum
            for (int m = i + 1; m <= j; m++)
            {
                if (list[m] < min)
                {
                    min = list[m];
                    minIndex = m;
                }
            }

            return minIndex;
        }

        /**
         * Read input from stdin (console) and convert it to an integer.
         */
        private static int ReadInt()
        {
            return Convert.ToInt32(Console.ReadLine().Trim());
        }

        /**
        * Read a list of numbers, separated by spaces, from stdin (console) and convert it to an array of integers.
        */
        private static int[] ReadIntList()
        {
            string[] inputNums = Console.ReadLine().Trim().Split(' ');
            int[] nums = new int[inputNums.Length];

            for (int i = 0; i < inputNums.Length; i++)
            {
                Int32.TryParse(inputNums[i], out nums[i]);
            }

            return nums;
        }

        /**
         * Print results result of Reversort => "Case #x: y"
         * x is the test case number (starting from 1) and y is the cost of executing Reversort on the list of input
        */
        private static void PrintResults(int x, int y)
        {
            Console.WriteLine($"Case #{x}: {y}");
        }
    }
}
