using System;

namespace Algoritms
{
    class Program
    {
        public class TestCase
        {
            public int N { get; set; }
            public int Expected { get; set; }
            public Exception ExpectedException { get; set; }
        }
        //Число Фиббоначчи через рекурсию.
        static int GetFebRecursive(int n)
        {
            if (n < 0)
            {
                throw new ArgumentException("Input number must be integer and more than 0");
            }
            if (n >= 2)
            {
                return (GetFebRecursive(n - 1) + GetFebRecursive(n - 2));
            }
            else if (n == 1)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        //Число Фиббоначчи через цикл.
        static int GetFebCycle(int n)
        {
            if (n < 0)
            {
                throw new ArgumentException("Input number must be integer and more than 0");
            }

            int a = 0;
            int b = 1;
            int temp;

            for (int i = 0; i < n; i++)
            {
                temp = a;
                a = b;
                b += temp;
            }

            return a;
        }

        // Тест валидности рекурсии
        static void TestCheckRecursive(TestCase testCase)
        {
            try
            {
                int actual = GetFebRecursive(testCase.N);
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
        // Тест валидности цикла
        static void TestCheckCycle(TestCase testCase)
        {
            try
            {
                int actual = GetFebCycle(testCase.N);
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
            TestCase testCase1 = new TestCase()
            {
                N = 0,
                Expected = 0,
                ExpectedException = null
            };

            TestCase testCase2 = new TestCase()
            {
                N = 3,
                Expected = 2,
                ExpectedException = null
            };

            TestCase testCase3 = new TestCase()
            {
                N = 9,
                Expected = 34,
                ExpectedException = null
            };

            TestCase testCase4 = new TestCase()
            {
                N = -1,
                ExpectedException = new Exception()

            };

            TestCase testCase5 = new TestCase()
            {
                N = -100,
                ExpectedException = new Exception()
            };

            Console.WriteLine("Проверка рекурсии");
            TestCheckRecursive(testCase1);
            TestCheckRecursive(testCase2);
            TestCheckRecursive(testCase3);
            TestCheckRecursive(testCase4);
            TestCheckRecursive(testCase5);

            Console.WriteLine();

            Console.WriteLine("Проверка цикла");
            TestCheckCycle(testCase1);
            TestCheckCycle(testCase2);
            TestCheckCycle(testCase3);
            TestCheckCycle(testCase4);
            TestCheckCycle(testCase5);

            Console.ReadKey();
        }

    }
}
