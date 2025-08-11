using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;

namespace Assignment_6._1._1
{
    internal class Program
    {
        public enum HouseType
        {
            None = 0,
            RANCH = 1,
            COLONIAL = 2,
            VICTORIAN = 3
        }
        class Node
        {
            public int Number { get; }
            public string Address { get; }
            public HouseType Data {  get; set; }
            public Node? Next { get; set; }

            public Node(int number, string address, HouseType house)
            {
                Number = number;
                Address = address;
                Data = house;
                Next = null;
            }

            public override string ToString() => $"#{Number} | {Address} | {Data}";

        }

        class LinkedNode
        {
            private Node? head;
            private Node? tail;
            private int size;
            public int Size { get { return size; } }

            public LinkedNode()
            {
                head = tail = null;
                size = 0;
            }

            public bool IsEmpty()
            {
                return size == 0;
            }

            public void AddFirst(int number, string address, HouseType type)
            {
                Node? newNode = new Node(number, address, type);
                if (IsEmpty())
                {
                    head = tail = newNode;
                }
                else
                {
                    newNode.Next = head;
                    head = newNode;
                }
                size++;
            }

            public void Display()
            {
                if (IsEmpty())
                {
                    throw new ArgumentException("Linked List is empty");
                }

                Node curr = head;
                while (curr != null)
                {
                    Console.Write(curr.Data);
                    if (curr.Next != null) Console.Write(" --> ");
                    curr = curr.Next;
                }
            }

            public void AddLast(int number, string address, HouseType type)
            {
                Node newNode = new Node(number, address, type);
                if (IsEmpty())
                {
                    head = tail = newNode;
                }
                else
                {
                    tail.Next = newNode;
                    tail = newNode;
                }
                size++;
            }

            public void RemoveLast()
            {
                if (IsEmpty())
                {
                    throw new InvalidOperationException("List is empty");
                }
                if (head == tail)  // One node
                {
                    head = tail = null;
                    size--;
                    return;
                }

                // Accounts for nodes of at least two.
                Node? prev = head;
                Node? curr = head.Next;
                while (curr.Next != null)
                {
                    prev = curr;
                    curr = curr.Next;
                }

                // curr is now the last node
                prev.Next = null;
                tail = prev;
                size--;
            }

            public Node? SearchHouse(int houseNumber)
            {
                Node? curr = head;
                while (curr != null)
                {
                    if (curr.Number == houseNumber) return curr;
                    curr = curr.Next;
                }
                return null;
            }


        }
        static void Main(string[] args)
        {
            LinkedNode list = new();
            list.AddFirst(101, "Num st.", HouseType.COLONIAL);
            list.AddLast(204, "Beach drive.", HouseType.RANCH);
            list.AddFirst(305, "Mariners Way.", HouseType.VICTORIAN);
            list.AddLast(456, "Liverpool Way.", HouseType.None);
            list.Display();
            Console.WriteLine($"\nSize of the array is: {list.Size}");
            list.RemoveLast();
            list.Display();

            Console.Write("\nEnter house number to search: ");
            if (int.TryParse(Console.ReadLine(), out int num))
            {
                Node? node = list.SearchHouse(num);
                Console.WriteLine(node is not null ? $"Found: {node}" : "House not found.");
            }
            else
            {
                Console.WriteLine("Please enter a valid integer house number.");
            }
        }
    }
}

