using System;

namespace Algoritms
{
    class Program
    {
        public sealed class Node
        {
            public int Value { get; set; }
            public Node NextNode { get; set; }
            public Node PrevNode { get; set; }
        }

        public class TwoLineked_list : ILinkedList
        {
            public Node Head;
            public Node Tail;
            int Counter;
            public void AddNode(int value)
            {
                Node node = new Node { Value = value };
                if (Head == null)
                {
                    Head = node;
                    Tail = node;
                    Counter = 1;
                    return;
                }
                else
                {
                    Tail.NextNode = node;
                    node.PrevNode = Tail;
                }
                Tail = node;
                Counter++;
            }

            public void AddNodeAfter(Node node, int value)
            {
                Node newNode = new Node { Value = value };

                if (node.NextNode == null)
                {
                    Tail.NextNode = newNode;
                    newNode.PrevNode = Tail;
                    Tail = newNode;
                    Counter++;
                    return;
                }
                Node nodeNextItem = node.NextNode;
                node.NextNode = newNode;
                newNode.PrevNode = node;
                newNode.NextNode = nodeNextItem;
                nodeNextItem.PrevNode = newNode;
                Counter++;
            }

            public Node FindNode(int searchValue)
            {
                Node currentNode = Head;
                while (currentNode != null)
                {
                    if (currentNode.Value == searchValue)
                    {
                        return currentNode;
                    }
                    currentNode = currentNode.NextNode;
                }
                return null;
            }

            public int GetCount()
            {
                return Counter;
            }

            public void RemoveNode(int index)
            {
                Node currentNode = new Node();
                if (index == 0)
                {
                    currentNode = Head.NextNode;
                    Head.NextNode = null;
                    currentNode.PrevNode = null;
                    Head = currentNode;
                    Counter--;
                    return;
                }
                if (index == Counter - 1)
                {
                    currentNode = Tail.PrevNode;
                    Tail.PrevNode = null;
                    currentNode.NextNode = null;
                    Tail = currentNode;
                    Counter--;
                    return;
                }
                int currentIndex = 0;
                currentNode = Head;
                while (currentNode != null)
                {
                    if (currentIndex == index - 1)
                    {
                        if (index > Counter - 1)
                        {
                            return;
                        }
                        if (currentNode.NextNode == null)
                        {
                            return;
                        }
                        Node nextNode = currentNode.NextNode.NextNode;
                        currentNode.NextNode.NextNode.PrevNode = currentNode;
                        currentNode.NextNode = nextNode;
                        Counter--;
                        return;
                    }
                    currentNode = currentNode.NextNode;
                    currentIndex++;
                }
                return;
            }

            public void RemoveNode(Node node)
            {
                if (node == null)
                {
                    return;
                }
                if (node.PrevNode == null)
                {
                    Node currentNodeHead = new Node();
                    currentNodeHead = Head.NextNode;
                    Head.NextNode = null;
                    currentNodeHead.PrevNode = null;
                    Head = currentNodeHead;
                    Counter--;
                    return;
                }
                if (node.NextNode == null)
                {
                    Node currentNodeTail = new Node();
                    currentNodeTail = Tail.PrevNode;
                    Tail.PrevNode = null;
                    currentNodeTail.NextNode = null;
                    Tail = currentNodeTail;
                    Counter--;
                    return;
                }
                Node currentNode = new Node();
                currentNode = Head;
                while (node != null)
                {
                    if (node == currentNode)
                    {
                        Node tempNode = currentNode;
                        currentNode.NextNode.PrevNode = currentNode.PrevNode;
                        currentNode.PrevNode.NextNode = currentNode.NextNode;
                        Counter--;
                        return;
                    }
                    currentNode = currentNode.NextNode;
                }
                return;
            }
        }

        public interface ILinkedList
        {
            int GetCount(); // возвращает количество элементов в списке
            void AddNode(int value); // добавляет новый элемент списка
            void AddNodeAfter(Node node, int value); // добавляет новый элемент списка после определённого элемента
            void RemoveNode(int index); // удаляет элемент по порядковому номеру
            void RemoveNode(Node node); // удаляет указанный элемент
            Node FindNode(int searchValue); // ищет элемент по его значению
        }

        public static void PrintList(TwoLineked_list list)
        {
            Node print = new Node();
            print = list.Head;
            for (int i = 0; i < list.GetCount(); i++)
            {
                Console.WriteLine($"{i} элемент двухсвязного списка равен: {print.Value}.");
                print = print.NextNode;
            }
            Console.WriteLine($"Всего список содержит {list.GetCount()} элементов.");
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            //Создаем тестовый двусвязный список
            TwoLineked_list testList = new TwoLineked_list();

            ////Проверяем метод AddNode(int value), добавляем в список значения
            testList.AddNode(9);
            testList.AddNode(55);
            testList.AddNode(37);
            testList.AddNode(4);
            testList.AddNode(81);
            testList.AddNode(1);
            testList.AddNode(10);
            testList.AddNode(51);
            testList.AddNode(14);
            testList.AddNode(33);

            //Проверяем метод AddNode(int value) что у нас получилось

            Console.WriteLine("Проверяем метод AddNode(int value)\nЭталонный список:");
            PrintList(testList);

            // Проверяем метод GetCount()
            Console.WriteLine($"Проверяем метод GetCount(), в списке имеется {testList.GetCount()} элементов.");
            Console.WriteLine();

            // Проверяем метод FindNode(int searchValue)
            Console.WriteLine("Проверяем метод FindNode(int searchValue):");
            Node testFindNode = new Node();
            testFindNode = testList.FindNode(81);
            Console.WriteLine("Проверили поиск элемента по значению 81, получили: " + testFindNode.Value);
            testFindNode = testList.FindNode(33);
            Console.WriteLine("Проверили поиск элемента по значению 33, получили: " + testFindNode.Value);
            testFindNode = testList.FindNode(1);
            Console.WriteLine("Проверили поиск элемента по значению 1, получили: " + testFindNode.Value);
            testFindNode = testList.FindNode(55);
            Console.WriteLine("Проверили поиск элемента по значению 55, получили: " + testFindNode.Value);
            testFindNode = testList.FindNode(9);
            Console.WriteLine("Проверили поиск элемента по значению 9, получили: " + testFindNode.Value);
            Console.WriteLine();

            // Проверяем метод AddNodeAfter(Node node, int value)
            Node testAddNodeAfter = new Node();
            testAddNodeAfter = testList.Head;
            testList.AddNodeAfter(testAddNodeAfter, 1000);
            testAddNodeAfter = testList.Tail;
            testList.AddNodeAfter(testAddNodeAfter, 2000);
            testAddNodeAfter = testList.FindNode(1000);
            testList.AddNodeAfter(testAddNodeAfter, 1001);
            testAddNodeAfter = testList.FindNode(10);
            testList.AddNodeAfter(testAddNodeAfter, 11);
            Console.WriteLine("Проверяем метод AddNodeAfter(Node node, int value):");
            PrintList(testList);

            // Проверяем метод RemoveNode(int index)
            Console.WriteLine("Проверяем метод RemoveNode(int index):");
            testList.RemoveNode(13);
            testList.RemoveNode(0);
            testList.RemoveNode(4);
            testList.RemoveNode(2);
            testList.RemoveNode(10);
            PrintList(testList);

            // Проверяем метод RemoveNode(Node node)
            Console.WriteLine("Проверяем метод RemoveNode(Node node):");
            Node testRemoveByNode = new Node();
            testRemoveByNode = testList.Head;
            testList.RemoveNode(testRemoveByNode);
            testRemoveByNode = testList.Tail;
            testList.RemoveNode(testRemoveByNode);
            testRemoveByNode = testList.FindNode(1001);
            testList.RemoveNode(testRemoveByNode);
            testRemoveByNode = testList.FindNode(1);
            testList.RemoveNode(testRemoveByNode);
            PrintList(testList);

            //Проверим как будет работать список, если доювать в него еще элементы
            testList.AddNode(9);
            testList.AddNode(2);
            testList.AddNode(3);
            testList.AddNode(4);
            testList.AddNode(5);
            testList.AddNode(1);
            Console.WriteLine("Проверим как будет работать список, если доювать в него еще элементы:");
            PrintList(testList);

            Console.WriteLine("Таки образом реализован класс двусвязного списка и операции вставки, \nудаления и поиска элемента в нём в соответствии с интерфейсом.");

            Console.ReadKey();
        }
    }
}
