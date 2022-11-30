using System;
using System.Xml.Linq;

namespace ConsoleApp14
{


    internal class Program
    {
        class Node
        {
            public double Name { get; set; }
            //public string Salary { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }
        }
        static void Traverse(Node originNod)// метод обхода
        {
           
            if (originNod.Left != null)
            {
                Traverse(originNod.Left);
            }

            Console.WriteLine(originNod.Name);
            //Console.WriteLine(originNod.Salary);

            if (originNod.Right != null)
            {
                Traverse(originNod.Right);
            }
        }

        static void AddNode(Node root, Node toadd) // метод добавления 
        {
            if (toadd.Name < root.Name)
            {
                if (root.Left != null)
                {
                    AddNode(root.Left, toadd);
                }
                else
                {
                    root.Left = toadd;
                }
            }
            else
            {
                if (root.Right != null)
                {
                    AddNode(root.Right, toadd);
                }
                else
                {
                    root.Right = toadd;
                }
            }

        }
        static Node FindNode(Node root,double name)
        {
            if(name < root.Name)
            {
                if(root.Left != null)
                {
                    return FindNode(root.Left,name);
                }
                return null;
            }
            if(name > root.Name)
            {
                if (root.Right != null)
                {
                    return FindNode(root.Right,name);
                }
                return null;
            }
            return root;
        }
        static void Main(string[] args)
        {

            Console.WriteLine("Введите зарплату");
            Node root = null;
            while (true)
            {
                var s = Console.ReadLine();
                var d =double.Parse(s);
                if (d == 0)
                {
                    break;
                }
                if (root == null)
                {
                    root = new Node()
                    {
                        Name = d
                    };
                }
                else
                {
                    AddNode(root, new Node
                    {
                        Name = d
                    });
                             
                }
            }
            Console.ReadKey();
            Console.WriteLine("Отсортерованный метод");
            Traverse(root);
            Console.WriteLine("Введите искому зарплату");
            while (true)
            {
                var s=Console.ReadLine();
                var d=double.Parse(s);
                if(d == 0)
                {
                    break;
                }
                var node = FindNode(root,d);
                if(node == null)
                {
                    Console.WriteLine(" Данная зарплата не найдена ");
                }
                else
                {
                    Console.WriteLine($"Искомая зарплата :" +node.Name);
                }
            }
           
        }

    }
}

