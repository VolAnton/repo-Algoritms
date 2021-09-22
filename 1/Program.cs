using System;
using System.Collections.Generic;

namespace Algoritms
{
    class Program
    {
        public class ShortestPathFinder
        {
            private int[,] Matrix { get; }
            private int MatrixSize { get; }

            public ShortestPathFinder(int[,] matrix, int matrixSize)
            {
                Matrix = matrix;
                MatrixSize = matrixSize;
            }

            public void MatrixPrint()
            {
                Console.WriteLine("Исходная матрица смежности: ");
                Console.WriteLine();

                for (int i = 0; i < Matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < Matrix.GetLength(1); j++)
                    {
                        Console.Write("{0,3}", Matrix[i, j] + " ");
                    }
                    Console.WriteLine();
                }

                Console.WriteLine();
            }

            private int MinDistance(int[] distance, bool[] stepSet)
            {
                int min = int.MaxValue;
                int minIndex = -1;

                for (int i = 0; i < MatrixSize; i++)
                {
                    if (stepSet[i] == false && distance[i] <= min)
                    {
                        min = distance[i];
                        minIndex = i;
                    }
                }

                return minIndex;
            }

            public void Dijkstra(int[,] matrix, int root)
            {
                int[] distance = new int[MatrixSize];
                int[] path = new int[MatrixSize];
                bool[] checkPoint = new bool[MatrixSize];

                for (int i = 0; i < MatrixSize; i++)
                {
                    distance[i] = int.MaxValue;
                    checkPoint[i] = false;
                }

                distance[root] = 0;

                for (int i = 0; i < MatrixSize; i++)
                {
                    int minDistance = MinDistance(distance, checkPoint);
                    checkPoint[minDistance] = true;

                    for (int j = 0; j < MatrixSize; j++)
                    {
                        if (!checkPoint[j] && matrix[minDistance, j] != 0 && distance[minDistance] != int.MaxValue && distance[minDistance] + matrix[minDistance, j] < distance[j])
                        {
                            distance[j] = distance[minDistance] + matrix[minDistance, j];
                            path[j] = minDistance;
                        }
                    }
                }

                Console.WriteLine("Данные о путях: ");
                Console.WriteLine("");
                Console.WriteLine($"Начальная точка 1");

                for (int i = 1; i < MatrixSize; i++)
                {
                    if (path[i] == 0)
                    {
                        Console.WriteLine($"Самый кратчайший путь из 1 ---> {i + 1} прямой  |  Минимальное расстояние: {distance[i]}");
                    }
                    else
                    {
                        Stack<int> stack = new Stack<int>();
                        stack.Push(path[i] + 1);
                        Console.Write($"Самый кратчайший путь из 1 ---> ");

                        for (int j = path[i]; j != 0; j = path[j])
                        {
                            if (path[j] == 0)
                            {
                                break;
                            }
                            else
                            {
                                stack.Push(path[j]);
                                j = path[j];
                            }
                        }

                        for (int j = 0; j <= stack.Count; j++)
                        {
                            if (j == stack.Count)
                            {
                                Console.Write($"{i + 1}  |  Минимальное расстояние: {distance[i]}");
                            }
                            else
                            {
                                Console.Write(stack.Pop() + " ---> ");
                                j = -1;
                            }
                        }

                        Console.WriteLine();
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            int[,] matrix =
            {
                {0,10,0,5,0,25,35},
                {0,0,10,5,10,0,0},
                {0,0,0,0,0,5,0},
                {0,0,0,0,5,0,0},
                {0,0,5,0,0,0,5},
                {0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0}
            };

            ShortestPathFinder findPath = new ShortestPathFinder(matrix, matrix.GetLength(0));
            findPath.MatrixPrint();
            findPath.Dijkstra(matrix, 0);

            Console.ReadKey();
        }
    }
}