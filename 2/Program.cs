using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Algoritms
{
    class Program
    {
        public enum BinSide
        {
            Left,
            Right
        }

        public class BinaryTree
        {
            public int? Data { get; set; }
            public BinaryTree Left { get; set; }
            public BinaryTree Right { get; set; }
            public BinaryTree Parent { get; set; }

            public void Insert(int data)
            {
                if (Data == null || Data == data)
                {
                    Data = data;
                    return;
                }

                if (Data > data)
                {
                    if (Left == null)
                    {
                        Left = new BinaryTree();
                    }

                    Insert(data, Left, this);
                }
                else
                {
                    if (Right == null)
                    {
                        Right = new BinaryTree();
                    }

                    Insert(data, Right, this);
                }
            }
            private void Insert(int data, BinaryTree node, BinaryTree parent)
            {
                if (node.Data == null || node.Data == data)
                {
                    node.Data = data;
                    node.Parent = parent;
                    return;
                }

                if (node.Data > data)
                {
                    if (node.Left == null)
                    {
                        node.Left = new BinaryTree();
                    }

                    Insert(data, node.Left, node);
                }
                else
                {
                    if (node.Right == null)
                    {
                        node.Right = new BinaryTree();
                    }

                    Insert(data, node.Right, node);
                }
            }

            private void Insert(BinaryTree data, BinaryTree node, BinaryTree parent)
            {
                if (node.Data == null || node.Data == data.Data)
                {
                    node.Data = data.Data;
                    node.Left = data.Left;
                    node.Right = data.Right;
                    node.Parent = parent;
                    return;
                }

                if (node.Data > data.Data)
                {
                    if (node.Left == null)
                    {
                        node.Left = new BinaryTree();
                    }

                    Insert(data, node.Left, node);
                }
                else
                {
                    if (node.Right == null)
                    {
                        node.Right = new BinaryTree();
                    }

                    Insert(data, node.Right, node);
                }
            }

            private BinSide? MeForParent(BinaryTree node)
            {
                if (node.Parent == null)
                {
                    return null;
                }

                if (node.Parent.Left == node)
                {
                    return BinSide.Left;
                }

                if (node.Parent.Right == node)
                {
                    return BinSide.Right;
                }

                return null;
            }

            public void Remove(BinaryTree node)
            {
                if (node == null)
                {
                    return;
                }

                //var me = MeForParent(node);
                Nullable<BinSide> me = MeForParent(node);

                if (node.Left == null && node.Right == null)
                {
                    if (me == BinSide.Left)
                    {
                        node.Parent.Left = null;
                    }
                    else
                    {
                        node.Parent.Right = null;
                    }
                    return;
                }

                if (node.Left == null)
                {
                    if (me == BinSide.Left)
                    {
                        node.Parent.Left = node.Right;
                    }
                    else
                    {
                        node.Parent.Right = node.Right;
                    }

                    node.Right.Parent = node.Parent;
                    return;
                }

                if (node.Right == null)
                {
                    if (me == BinSide.Left)
                    {
                        node.Parent.Left = node.Left;
                    }
                    else
                    {
                        node.Parent.Right = node.Left;
                    }
                    node.Left.Parent = node.Parent;
                    return;
                }

                if (me == BinSide.Left)
                {
                    node.Parent.Left = node.Right;
                }

                if (me == BinSide.Right)
                {
                    node.Parent.Right = node.Right;
                }

                if (me == null)
                {
                    BinaryTree tmpLeft = node.Left;
                    BinaryTree tmpRightLeft = node.Right.Left;
                    BinaryTree tmpRightRight = node.Right.Right;
                    node.Data = node.Right.Data;
                    node.Right = tmpRightRight;
                    node.Left = tmpRightLeft;
                    Insert(tmpLeft, node, node);
                }
                else
                {
                    node.Right.Parent = node.Parent;
                    Insert(node.Left, node.Right, node.Right);
                }
            }

            public void Remove(int data)
            {
                BinaryTree removeNode = Find(data);
                if (removeNode != null)
                {
                    Remove(removeNode);
                }
            }

            public BinaryTree Find(int data)
            {
                if (Data == data)
                {
                    return this;
                }
                if (Data > data)
                {
                    return Find(data, Left);
                }
                return Find(data, Right);
            }

            public BinaryTree Find(int data, BinaryTree node)
            {
                if (node == null)
                {
                    return null;
                }

                if (node.Data == data)
                {
                    return node;
                }

                if (node.Data > data)
                {
                    return Find(data, node.Left);
                }

                return Find(data, node.Right);
            }

            public int CountElements()
            {
                return CountElements(this);
            }

            public int CountElements(BinaryTree node)
            {
                int counter = 1;

                if (node.Right != null)
                {
                    counter += CountElements(node.Right);
                }
                if (node.Left != null)
                {
                    counter += CountElements(node.Left);
                }
                return counter;
            }
        }

        public static void PrintTree(BinaryTree node)
        {
            if (node != null)
            {
                if (node.Parent == null)
                {
                    Console.WriteLine($"ROOT: {node.Data}");
                }
                else
                {
                    if (node.Parent.Left == node)
                    {
                        Console.WriteLine($"Left for {node.Parent.Data}   ------>   {node.Data}");
                    }

                    if (node.Parent.Right == node)
                    {
                        Console.WriteLine($"Right for {node.Parent.Data}   ------>   {node.Data}");
                    }
                }

                if (node.Left != null)
                {
                    PrintTree(node.Left);
                }

                if (node.Right != null)
                {
                    PrintTree(node.Right);
                }
            }
        }




        static void Main(string[] args)
        {
            BinaryTree tree = new BinaryTree();
            tree.Insert(10);
            tree.Insert(20);
            tree.Insert(15);
            tree.Insert(40);
            tree.Insert(35);
            tree.Insert(60);
            tree.Insert(55);
            tree.Insert(80);
            tree.Insert(75);
            PrintTree(tree);
            tree.Remove(40);
            PrintTree(tree);
            tree.Remove(20);
            PrintTree(tree);

            Console.ReadKey();
        }
    }
}
