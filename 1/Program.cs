using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Algoritms
{
    class Program
    {
        public class Node
        {
            public int? Data { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }

            public Node(int data, Node left, Node right)
            {
                Data = data;
                Left = left;
                Right = right;
            }

            public Node() { }

            public Node(int data)
            {
                Data = data;
            }
        }

        public static void PreOrderTravers(Node root, string tr = " ")
        {
            if (root != null)
            {
                Console.WriteLine($"{tr} {root.Data}");
                PreOrderTravers(root.Left, $"{tr}{new string(' ', 3)}");
                PreOrderTravers(root.Right, $"{tr}{new string(' ', 3)}");
            }
        }

        public static Node Elements(int numbers)
        {
            Node newNode = new Node();

            if (numbers == 0)
            {
                return null;
            }
            else
            {
                int numbersLeft = numbers / 2;
                int numbersRight = numbers - numbersLeft - 1;
                newNode.Data = new Random().Next(0, 1000);
                newNode.Left = Elements(numbersLeft);
                newNode.Right = Elements(numbersRight);
            }

            return newNode;
        }

        private static void BFS(Node tree)
        {
            Queue<Node> bfs = new Queue<Node>();
            bfs.Enqueue(tree);
            while (bfs.Count > 0)
            {
                tree = bfs.Dequeue();
                Console.Write(tree.Data + " ");

                if (tree.Left != null)
                {
                    bfs.Enqueue(tree.Left);
                }

                if (tree.Right != null)
                {
                    bfs.Enqueue(tree.Right);
                }
            }
            Console.WriteLine();
        }

        public static void DFS(Node tree)
        {
            if (tree == null)
            {
                return;
            }

            Console.Write(tree.Data + " ");
            DFS(tree.Left);
            DFS(tree.Right);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Строим сбалансированное дерево:");
            Console.WriteLine();

            Node tree = Elements(15);

            PreOrderTravers(tree);

            Console.WriteLine();
            Console.WriteLine("Реализация BFS (breadth-first search)  — поиск в ширину:");
            Console.WriteLine();

            BFS(tree);

            Console.WriteLine();
            Console.WriteLine("Реализация DFS (deep-first search) — поиск в глубину:");
            Console.WriteLine();

            DFS(tree);

            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
