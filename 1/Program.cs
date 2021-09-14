using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Algoritms
{
    class Program
    {
        static string[] arrayString;
        static HashSet<string> hashString = new HashSet<string>();
        static Stopwatch sw;

        static string GenerateString(int length)
        {
            StringBuilder sb = new StringBuilder(length);
            string charsInString = "!@#$%^&*()_/*-+=1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            Random rnd = new Random();
            for (int i = 0; i < length; i++)
            {
                sb.Append(charsInString[rnd.Next(charsInString.Length)]);
            }
            return sb.ToString();
        }

        static void RandomStringGenerator(int quantity, int length)
        {
            arrayString = new string[quantity];

            for (int i = 0; i < arrayString.Length; i++)
            {
                arrayString[i] = GenerateString(length);
                hashString.Add(arrayString[i]);
            }
            Console.WriteLine("Число сгенерированных строк в массиве равно = " + arrayString.Length);
            Console.WriteLine("Число сгенерированных уникальных строк в HashSet равно = " + hashString.Count);
            Console.WriteLine();
        }
        public static void ArrayFindStringTest(string[] arrayTest)
        {
            if (arrayTest.Length == 0)
            {
                return;
            }
            int length = arrayTest[0].Length;
            string testStringFind = GenerateString(length);
            for (int i = 0; i < arrayTest.Length; i++)
            {
                if (testStringFind == arrayTest[i])
                {
                    Console.WriteLine("Строка найдена");
                    return;
                }
            }
            Console.WriteLine("Строка не найдена");
        }
        public static void DisplaySet(HashSet<string> collection)
        {
            Console.Write("{ ");
            foreach (string str in collection)
            {
                Console.Write(str);
            }
            Console.WriteLine(" }");
        }
        public static int GetHashSetLength(HashSet<string> collection)
        {
            int length = 0;
            foreach (string str in collection)
            {
                length = str.Length;
                return length;
            }
            return length;
        }

        public static void HashFindStringTest(HashSet<string> hashTest)
        {
            int length = GetHashSetLength(hashTest);
            if (length == 0)
            {
                return;
            }
            string testStringFind = GenerateString(length);
            for (int i = 0; i < hashTest.Count; i++)
            {
                if (hashTest.Contains(testStringFind))
                {
                    Console.WriteLine("Строка найдена");
                    return;
                }
            }
            Console.WriteLine("Строка не найдена");
        }

        static void Main(string[] args)
        {
            RandomStringGenerator(10_000, 1_000);
            Console.WriteLine("Выполняем поиск случайно-сгенерированной строки в массиве");
            Console.Write("Результат поиска: ");
            sw = new Stopwatch();
            sw.Start();
            ArrayFindStringTest(arrayString);
            sw.Stop();
            Console.WriteLine("Время поиска случайно-сгенерированной строки в массиве равно " + sw.ElapsedMilliseconds + " мс");
            Console.WriteLine();
            Console.WriteLine("Выполняем поиск случайно-сгенерированной строки в в HashSet");
            Console.Write("Результат поиска: ");
            sw = new Stopwatch();
            sw.Start();
            HashFindStringTest(hashString);
            sw.Stop();
            Console.WriteLine("Время поиска случайно-сгенерированной строки в HashSet равно " + sw.ElapsedMilliseconds + " мс");

            Console.ReadKey();
        }
    }
}
