using System;
using System.Collections.Generic;

namespace Algoritms_Works
{
    class Program
    {
        public class TestCase
        {
            public int[] InputArray { get; set; }
            public int[] Expected { get; set; }
            public Exception ExpectedException { get; set; }
        }

        static void TestCheckBucketSort(TestCase testCase)
        {
            try
            {
                bool passTest = false;
                int[] actual = testCase.Expected;
                BucketSort(testCase.InputArray);

                if (testCase.InputArray.Length != testCase.Expected.Length)
                {
                    throw new ArgumentException("Массивы должны быть одинаковой длины");
                }

                for (int i = 0; i < testCase.InputArray.Length; i++)
                {
                    if (testCase.Expected[i] != testCase.InputArray[i])
                    {
                        Console.WriteLine("INVALID TEST");
                        passTest = false;
                        break;
                    }
                    else
                    {
                        passTest = true;
                    }
                }
                if (passTest)
                {
                    Console.WriteLine("VALID TEST");
                }
            }
            catch (Exception ex)
            {
                if (testCase.ExpectedException != null)
                {
                    Console.WriteLine("VALID TEST");
                }
                else
                {
                    Console.WriteLine("INVALID TEST");
                }
            }
        }
        
        static void RandomItem(int[] array)
        {
            Random rnd = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rnd.Next(10, 100);
            }
        }

        static void QuickSort(int[] array, int first, int last)
        {
            int i = first;
            int j = last;
            int x = array[(first + last) / 2];

            do
            {
                while (array[i] < x)
                {
                    i++;
                }

                while (array[j] > x)
                {
                    j--;
                }

                if (i <= j)
                {
                    if (array[i] > array[j])
                    {
                        int temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                    i++;
                    j--;
                }
            }
            while (i <= j);

            if (i < last)
            {
                QuickSort(array, i, last);
            }

            if (first < j)
            {
                QuickSort(array, first, j);
            }

        }

        static void BucketSort(int[] array)
        {
            List<int>[] basket = new List<int>[array.Length];

            for (int i = 0; i < basket.Length; i++)
            {
                basket[i] = new List<int>();
            }

            int minValue = array[0];
            int maxValue = array[0];

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < minValue)
                {
                    minValue = array[i];
                }
                else if (array[i] > maxValue)
                {
                    maxValue = array[i];
                }
            }

            double numRange = maxValue - minValue;

            for (int i = 0; i < array.Length; i++)
            {
                int basketIndex = (int)Math.Floor((array[i] - minValue) / numRange * (basket.Length - 1));
                basket[basketIndex].Add(array[i]);
            }

            for (int i = 0; i < basket.Length; i++)
            {
                basket[i].Sort();
            }

            int index = 0;

            for (int i = 0; i < basket.Length; i++)
            {
                for (int j = 0; j < basket[i].Count; j++)
                {
                    array[index++] = basket[i][j];
                }
            }
        }

        static void CopyArrayItem(int[] fromArray, int[] toArray)
        {
            if (fromArray.Length != toArray.Length)
            {
                return;
            }
            for (int i = 0; i < fromArray.Length; i++)
            {
                toArray[i] = fromArray[i];
            }
        }

        static void Main(string[] args)
        {
            int[] test_1 = new int[] { 32, 12, 14, 15, 69, 87, 23, 6, 1, 56 };
            int[] test_1_sort = new int[] { 1, 6, 12, 14, 15, 23, 32, 56, 69, 87 };

            TestCase testCase1 = new TestCase()
            {
                InputArray = test_1,
                Expected = test_1_sort,
                ExpectedException = null
            };

            int[] test_2 = new int[15];
            RandomItem(test_2);
            int[] test_2_sort = new int[test_2.Length];
            CopyArrayItem(test_2, test_2_sort);
            QuickSort(test_2_sort, 0, test_2_sort.Length - 1);
            TestCase testCase2 = new TestCase()
            {
                InputArray = test_2,
                Expected = test_2_sort,
                ExpectedException = null
            };

            int[] test_3 = new int[20];
            RandomItem(test_3);
            int[] test_3_sort = new int[test_3.Length];
            CopyArrayItem(test_3, test_3_sort);
            QuickSort(test_3_sort, 0, test_3_sort.Length - 1);
            TestCase testCase3 = new TestCase()
            {
                InputArray = test_3,
                Expected = test_3_sort,
                ExpectedException = null
            };

            int[] test_4 = new int[10];
            RandomItem(test_4);
            int[] test_4_sort = new int[test_4.Length - 1];
            CopyArrayItem(test_4, test_4_sort);
            QuickSort(test_4_sort, 0, test_4_sort.Length - 1);

            TestCase testCase4 = new TestCase()
            {
                InputArray = test_4,
                Expected = test_4_sort,
                ExpectedException = new Exception()
            };

            int[] test_5 = new int[30];
            RandomItem(test_5);
            int[] test_5_sort = new int[test_5.Length + 1];
            CopyArrayItem(test_5, test_5_sort);
            QuickSort(test_5_sort, 0, test_5_sort.Length - 1);

            TestCase testCase5 = new TestCase()
            {
                InputArray = test_5,
                Expected = test_5_sort,
                ExpectedException = new Exception()
            };

            TestCheckBucketSort(testCase1);
            TestCheckBucketSort(testCase2);
            TestCheckBucketSort(testCase3);
            TestCheckBucketSort(testCase4);
            TestCheckBucketSort(testCase5);

            Console.ReadKey();
        }
    }
}
