using System;
using System.Collections.Generic;

namespace Algoritms
{
    class Program
    {
        static Graph GRAPH = new Graph();
        static Dijkstra DIJKSTRA = new Dijkstra(GRAPH);

        public struct NodeEdge
        {
            public char Node;
            public int Weight;

            public NodeEdge(char node, int weight)
            {
                this.Node = node;
                this.Weight = weight;
            }
        }

        public struct GraphNode
        {
            public char Node;

            public Stack<NodeEdge> Edges;

            public GraphNode(char node)
            {
                this.Node = node;
                Edges = new Stack<NodeEdge>();
            }
        }

        public class Graph
        {
            Stack<GraphNode> Nodes;

            public Graph()
            {
                Nodes = new Stack<GraphNode>();
            }

            public void AddNode(char node)
            {
                GraphNode graphNode = new GraphNode(node);
                Nodes.Push(graphNode);
            }

            public void AddEdge(char node_1, char node_2, int weight)
            {
                GetNode(node_1).Edges.Push(new NodeEdge(node_2, weight));
                GetNode(node_2).Edges.Push(new NodeEdge(node_1, weight));

                Console.WriteLine($"Вершина - {node_1}; Ребро - {weight}; Вершина - {node_2}");
            }

            public IEnumerable<char> GetNodes()
            {
                foreach (GraphNode graphNode in Nodes.List())
                {
                    yield return graphNode.Node;
                }
            }

            public GraphNode GetNode(char node)
            {
                foreach (GraphNode graphNode in Nodes.List())
                {
                    if (graphNode.Node == node)
                    {
                        return graphNode;
                    }
                }

                throw new Exception("Node not found, or not exist!");
            }
        }

        public class NodeInfo
        {
            public char Node;
            public bool Used;
            public int Sum;
            public char Prev;

            public NodeInfo(char node)
            {
                this.Node = node;
                Used = false;
                Sum = int.MaxValue;
                Prev = node;
            }
        }

        class Dijkstra
        {
            private Graph Graph;
            private Stack<NodeInfo> Info;

            public Dijkstra(Graph graph)
            {
                this.Graph = graph;
            }

            private void Init()
            {
                Info = new Stack<NodeInfo>();
                foreach (Char node in Graph.GetNodes())
                {
                    Info.Push(new NodeInfo(node));
                }
            }

            private NodeInfo GetNodeInfo(char node)
            {
                foreach (NodeInfo info in Info.List())
                {
                    if (info.Node == node)
                    {
                        return info;
                    }
                }

                throw new Exception("Node not found, or not exist!");
            }

            private char FindUnusedMinimalNode()
            {
                int minSum = int.MaxValue;
                char minNode = '0';
                Console.Write("Из пункта " + 'A' + " -> ");
                foreach (char node in Graph.GetNodes())
                {
                    NodeInfo info = GetNodeInfo(node);
                    Console.Write($"{node} ");
                    if (info.Used)
                    {
                        continue;
                    }

                    if (info.Sum < minSum)
                    {
                        minSum = info.Sum;
                        minNode = node;
                        Console.Write($"[в {minNode}={minSum}] ");
                    }
                }
                Console.WriteLine();
                return minNode;
            }

            private void SetSumToNextNodes(char current)
            {
                NodeInfo currentInfo = GetNodeInfo(current);
                currentInfo.Used = true;
                foreach (NodeEdge next in Graph.GetNode(current).Edges.List())
                {
                    int newSum = currentInfo.Sum + next.Weight;
                    NodeInfo nextInfo = GetNodeInfo(next.Node);
                    if (newSum < nextInfo.Sum)
                    {
                        nextInfo.Sum = newSum;
                        nextInfo.Prev = current;
                    }
                }
            }

            private string RestorePath(char node_1, char node_2)
            {
                string path = node_2.ToString();
                while (node_2 != node_1)
                {
                    node_2 = GetNodeInfo(node_2).Prev;
                    path = node_2.ToString() + path;
                }
                return path;
            }

            public string GetShortestPath(char node_1, char node_2)
            {
                Init();
                GetNodeInfo(node_1).Sum = 0;
                char current;
                while ((current = FindUnusedMinimalNode()) != '0')
                {
                    SetSumToNextNodes(current);
                }

                Console.WriteLine();
                Console.Write($"Самый быстрый маршрут из '{node_1.ToString()}' в '{node_2.ToString()}' = ");

                return RestorePath(node_1, node_2);
            }
        }

        public class Node<T>
        {
            public T Item { get; private set; }
            public Node<T> Next { get; private set; }

            public Node(T item, Node<T> next)
            {
                Item = item;
                Next = next;
            }

            public override string ToString()
            {
                return Item.ToString() + " " + Next?.ToString();
            }
        }

        public class Stack<T>
        {
            Node<T> Head;

            public Stack()
            {
                Head = null;
            }

            public void Push(T item)
            {
                Head = new Node<T>(item, Head);
            }

            public T Pop()
            {
                if (Head == null)
                {
                    throw new Exception("Stack is empty.");
                }

                T item = Head.Item;
                Head = Head.Next;
                return item;
            }

            public IEnumerable<T> List()
            {
                Node<T> node = Head;
                while (node != null)
                {
                    yield return node.Item;
                    node = node.Next;
                }
            }
        }

        static void Main(string[] args)
        {
            GRAPH.AddNode('A');
            GRAPH.AddNode('B');
            GRAPH.AddNode('C');
            GRAPH.AddNode('D');
            GRAPH.AddNode('E');
            GRAPH.AddNode('F');
            GRAPH.AddNode('G');

            GRAPH.AddEdge('A', 'B', 10);
            GRAPH.AddEdge('A', 'D', 5);
            GRAPH.AddEdge('A', 'F', 25);
            GRAPH.AddEdge('A', 'G', 35);
            GRAPH.AddEdge('B', 'C', 10);
            GRAPH.AddEdge('B', 'D', 5);
            GRAPH.AddEdge('B', 'E', 10);
            GRAPH.AddEdge('D', 'E', 5);
            GRAPH.AddEdge('E', 'C', 5);
            GRAPH.AddEdge('C', 'F', 5);
            GRAPH.AddEdge('E', 'G', 15);

            Console.WriteLine();
            Console.WriteLine(DIJKSTRA.GetShortestPath('A', 'G'));
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
