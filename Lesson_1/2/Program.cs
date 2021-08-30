using System;

namespace Algoritms
{
    class Program
    {
        public static int StrangeSum(int[] inputArray)
        {
            int sum = 0;                                            // O(1)
            for (int i = 0; i < inputArray.Length; i++)             // O(n)
            {
                for (int j = 0; j < inputArray.Length; j++)         // O(n)
                {
                    for (int k = 0; k < inputArray.Length; k++)     // O(n)
                    {
                        int y = 0;

                        if (j != 0)
                        {
                            y = k / j;
                        }

                        sum += inputArray[i] + i + k + j + y;
                    }
                }
            }

            return sum;                                             // O(1)
        }

        // Асимптотическая сложность =  1 + n * n * n + 1 = n^3 + 2.

        // С учетом допущений Асимптотическая сложность = n^3.



        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

}
