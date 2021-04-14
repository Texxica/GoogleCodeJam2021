using System;

namespace Q1_AppendSort
{
    class AppendSort
    {
        // This solution is unfinished, I ran out of time, and went to bed. I intend to come back and finsih it.
        // I started thinking I could just append 0s and take care of other cases... this is somewhat correct.

        // I left myself a note on line 64.... I should be able to start by compare the starting (left most) digits of two numbers
        // then I can determine which digits I need to append and how many

        /**
         * Read input and perform AppendSort on given test cases.
         * 
         * For the sort, you cannot move numbers to different places in the array. You can only append digits 
         * to the end of the current number. (ie., adding 0-9 to the end).
         * The cost is the minimum total number of digits you have to append to "sort" a list of numbers.
        */
        static void Main(string[] args)
        {
            int T = ReadInt(); // Read in the number of trials in this test

            for (int i = 0; i < T; i++)
            {
                int N = ReadInt(); // Read in the length of the incoming array (not used)

                var list = ReadIntList(); // Read in the list of distinct integers to be sorted

                int minCost = Sort(list);

                PrintResults(i + 1, minCost);
                PrintList(list);
            }
        }

        private static int Sort(int[] list)
        {
            if (list == null || list.Length == 0 || list.Length == 1)
                return 0;

            int cost = 0;
            int num1 = list[0]; // 100
            int numDigits = CountDigits(num1); // 3

            for (int i=1; i<list.Length; i++)
            {
                int num2 = list[i]; // 7
                int num2Digits = CountDigits(num2); // 1

                // it's already sorted.

                if (num2 > num1)
                {
                    num1 = num2;
                    numDigits = num2Digits;
                    // you win!
                    // move on
                    continue;
                }

                // if they are equal....
                int increaseBy = 1;

                // YOU NEED TO COMPARE THE NUM2 WITH THE LEFT HAND SIDE OF NUM1 WITH THE SAME AMOUNT OF DIGITS
                // THEN YOU KNOW HOW TO RESPOND!!!!

                if (num2 == num1)
                {
                    num2 = PadRight(num2, increaseBy, 0);
                }
                else // num 2 is less than num 1
                {
                    increaseBy = numDigits - num2Digits; // 0
                    if (increaseBy == 0)
                    {
                        increaseBy++;
                        num2 = PadRight(num2, increaseBy, 0);
                    }
                    else
                    {

                        int firstDigit1 = num1 / (int)Math.Pow(10, numDigits - 1);
                        int firstDigit2 = num2 / (int)Math.Pow(10, num2Digits - 1);

                        // if there first digits are the same... 
                        // if it's less than 
                        // if it's greater than...

                        if (firstDigit1 < firstDigit2)
                        {
                            num2 = PadRight(num2, increaseBy, 0);
                        }
                        else if (firstDigit1 > firstDigit2)
                        {
                            num2 = PadRight(num2, ++increaseBy, 0);
                        }
                        else // digits are the same and padding needed.
                        {
                            int trailingDigits1 = num1 % 10 * (numDigits - 1);

                            num2 = PadRight(num2, increaseBy, 0);
                            num2 += trailingDigits1 + 1;

                            if (trailingDigits1 % 10 == 9)
                            {
                                increaseBy++;
                            }
                        }
                    }
                }

                cost += increaseBy;
                list[i] = num2;
                num1 = num2;
            }

            return cost;
        }
        
        private static int PadRight(int num, int numDigits, int pad) // 1, 2, 89
        {
            if (numDigits <= 0)
                return num;

            int numPadDigits = CountDigits(pad);

            for(int i=numDigits; i > 0; i--)
            {
                num *= 10;
                num += pad;

                if (i == numPadDigits && numPadDigits > 1)
                {
                    i -= i;
                }
            }

            return num;
        }

        private static int CountDigits(int num)
        {
            if(num == 0)
            {
                return 1;
            }

            int numDigits = 0;

            while (num > 0)
            {
                num /= 10;
                numDigits++;
            }

            return numDigits;
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

        private static void PrintList(int[] list)
        {
            for (int i = 0; i < list.Length; i++)
            {
                Console.Write(list[i] + ", ");
            }
            Console.WriteLine();
        }
    }
}
