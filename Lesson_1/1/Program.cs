using System;

namespace Algoritms
{
    class Program
    {
        public class TestCase
        {
            public int Number { get; set; }
            public string Expected { get; set; }
            public Exception ExpectedException { get; set; }
        }

        static string CheckNumberIsSimple(int number)
        {
            if (number < 1)
            {
                throw new ArgumentException("Input number must be integer and more than 1");
            }
            int d = 0;
            int i = 2;

            while (i < number)
            {
                if (number % i == 0)
                {
                    d++;
                }
                i++;
            }
            if (d == 0)
            {
                return "Простое";
            }
            else
            {
                return "Не простое";
            }
        }
        static void TestCheck(TestCase testCase)
        {
            try
            {
                string actual = CheckNumberIsSimple(testCase.Number);
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
                Number = 2,
                Expected = "Простое",
                ExpectedException = null
            };

            TestCase testCase2 = new TestCase()
            {
                Number = 122,
                Expected = "Не простое",
                ExpectedException = null
            };

            TestCase testCase3 = new TestCase()
            {
                Number = 313,
                Expected = "Простое",
                ExpectedException = null
            };

            TestCase testCase4 = new TestCase()
            {
                Number = 0,
                ExpectedException = new Exception()

            };

            TestCase testCase5 = new TestCase()
            {
                Number = -1,
                ExpectedException = new Exception()
            };

            TestCheck(testCase1);
            TestCheck(testCase2);
            TestCheck(testCase3);
            TestCheck(testCase4);
            TestCheck(testCase5);

            Console.ReadKey();
        }
    }
}
