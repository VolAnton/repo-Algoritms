using System;

namespace Algoritms
{
    class Program
    {

        static (int m, int n) GetBoardSize()
        {
            Console.WriteLine("Укажите размер прямоугольного поля размера M на N клеток:");
            Console.Write("M = ");
            int m = int.Parse(Console.ReadLine());
            Console.Write("N = ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine();
            return (m, n);
        }

        static void PrintBoard(int m, int n, int[,] a)
        {
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"{ a[i, j],5}");
                }
                Console.Write("\r\n");
            }
        }

        static void Solve(int m, int n)
        {
            int[,] array = new int[m, n];

            for (int i = 0; i < n; i++)
            {
                array[0, i] = 1;
            }

            for (int i = 1; i < m; i++)
            {
                array[i, 0] = 1;
                for (int j = 1; j < n; j++)
                {
                    array[i, j] = array[i, j - 1] + array[i - 1, j];
                }
            }

            PrintBoard(m, n, array);
        }


        static void Main(string[] args)
        {
            int m, n;
            (m, n) = GetBoardSize();

            Solve(m, n);

            Console.ReadKey();
        }
    }
}