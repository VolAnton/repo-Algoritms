using System;

namespace Algoritms
{
    class Program
    {
        //Создаем класс для тестирования метода"Двоичный (бинарный) поиск".
        public class TestCase
        {
            public int[] N { get; set; }
            public int SearchValue { get; set; }
            public int Expected { get; set; }
            public Exception ExpectedException { get; set; }
        }

        //Метод "Двоичный (бинарный) поиск".                                       // Асимптотическая сложность будет равна: (1 + (1 + N + (1 + N * N + 1) + N + 1) + 1 + 1 + (log(N) по основанию 2) + 1 + 1) = (N^2 + (log(N) по основанию 2) + 2N + 9)
        //                                                                         // Упростим: (N^2+(log(N) по основанию 2)
        public static int BinarySearch(int[] inputArray, int searchValue)
        {
            int result;                                                            // O(1)
            if (!IsArraySort(inputArray))                                          // O(1 + N + (1 + N * N + 1) + N + 1)
            {
                throw new ArgumentException("Массив должен быть отсортирован");
            }
            int min = 0;                                                           // O(1)
            int max = inputArray.Length - 1;                                       // O(1)
            while (min <= max)                                                     // log(N) по основанию 2
            {
                int mid = (min + max) / 2;
                if (searchValue == inputArray[mid])
                {
                    return mid;
                }
                else if (searchValue < inputArray[mid])
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }
            result = -1;                                                            // O(1)
            if (result == -1)                                                       // O(1)
            {
                throw new ArgumentException("Массив не содержит искомое число");
            }
            return result;
        }

        // Сортировка массива.
        public static int[] SortArray(int[] array)                  // сумма для этого алгоритма O(1 + N*N + 1)
        {

            int temp;                                               // O(1)
            for (int k = 0; k < array.Length; k++)                  // O(N)
            {
                int j = 0;
                for (int i = array.Length - 1 - k; i > 0; i--)      // O(N)
                {
                    if (array[j] > array[j + 1])
                    {
                        temp = array[j + 1];
                        array[j + 1] = array[j];
                        array[j] = temp;
                    }
                    j++;
                }
            }
            return array;                                           // O(1)
        }

        // Проверка отсортирован ли массива.
        public static bool IsArraySort(int[] array)                     // сумма для этого алгоритма O(1 + N + (1 + N*N + 1) + N + 1)
        {
            int[] newSortArray = new int[array.Length];                 // O(1)
            for (int i = 0; i < array.Length; i++)                      // O(N)
            {
                newSortArray[i] = array[i];
            }
            newSortArray = SortArray(newSortArray);                     // O(1 + N*N + 1)

            for (int i = 0; i < array.Length; i++)                      // O(N)
            {
                if (array[i] != newSortArray[i])
                {
                    return false;
                }
            }
            return true;                                                // O(1)
        }

        // Заполняет массив целыми числами по порядку (массив отсортирован).
        public static int[] MakeIntSortArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = i + 1;
            }
            return array;
        }

        // Заполняет массив целыми случайными числами от 1 до 99 в разнобой (массив не отсортирован).
        public static int[] MakeIntUnsortArray(int[] array)
        {
            Random rnd = new Random();
            int count = 0;
            bool isRepeat = false;
            for (int i = 0; i < array.Length; i++)
            {
                do
                {
                    array[i] = rnd.Next(1, 99);
                    for (int j = 0; j <= count; j++)
                    {
                        if (array[j] == array[i])
                        {
                            isRepeat = true;
                        }
                        else
                        {
                            isRepeat = false;
                        }
                    }
                }
                while (!isRepeat);
                count++;
            }
            return array;
        }

        // Тест валидности "Двоичный (бинарный) поиск"
        static void TestCheckBinarySearch(TestCase testCase)
        {
            try
            {
                int actual = BinarySearch(testCase.N, testCase.SearchValue);
                if (actual == testCase.Expected)
                {
                    Console.WriteLine("VALID TEST");
                }
                else
                {
                    Console.WriteLine("INVALID TEST");
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

        static void Main(string[] args)
        {
            int[] testArray_1 = new int[10];
            testArray_1 = MakeIntSortArray(testArray_1);
            TestCase testCase1 = new TestCase()
            {
                N = testArray_1,
                SearchValue = 7,
                Expected = 6,
                ExpectedException = null
            };

            int[] testArray_2 = new int[100];
            testArray_2 = MakeIntSortArray(testArray_2);
            TestCase testCase2 = new TestCase()
            {
                N = testArray_2,
                SearchValue = 85,
                Expected = 84,
                ExpectedException = null
            };

            int[] testArray_3 = new int[1000];
            testArray_3 = MakeIntSortArray(testArray_3);
            TestCase testCase3 = new TestCase()
            {
                N = testArray_3,
                SearchValue = 523,
                Expected = 522,
                ExpectedException = null
            };

            int[] testArray_4 = new int[25];
            testArray_4 = MakeIntSortArray(testArray_4);
            TestCase testCase4 = new TestCase()
            {
                N = testArray_4,
                SearchValue = 37,
                ExpectedException = new Exception()
            };

            int[] testArray_5 = new int[50];
            testArray_5 = MakeIntUnsortArray(testArray_5);
            TestCase testCase5 = new TestCase()
            {
                N = testArray_5,
                ExpectedException = new Exception()
            };

            Console.WriteLine("Проверка работы метода \"Двоичный (бинарный) поиск\"");
            TestCheckBinarySearch(testCase1);
            TestCheckBinarySearch(testCase2);
            TestCheckBinarySearch(testCase3);
            TestCheckBinarySearch(testCase4);
            TestCheckBinarySearch(testCase5);

            Console.ReadKey();
        }
    }
}
