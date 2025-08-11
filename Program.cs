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

            public Node? SearchHouse(int number)
            {
                if(IsEmpty())
                {
                    throw new ArgumentException("Linked List is empty");
                }
                if(number <= 0 || number > size)
                {
                    throw new ArgumentException("number is not valid.");
                }
                if (number == 1) return head;
                if (number == size) return tail;

                Node curr = head;
                int i = 1;
                while (curr != null)
                {
                    if (i == number)
                    {
                        return curr;
                    }
                    curr = curr.Next;
                    i++;
                }
                Console.WriteLine("No house found");
                return null;
            }


        }
        static void Main(string[] args)
        {
            LinkedNode list = new();
            list.AddFirst(101, "123 Num st.", HouseType.COLONIAL);
            list.AddLast(204, "345 Beach drive.", HouseType.RANCH);
            list.AddFirst(305, "789 Mariners Way.", HouseType.VICTORIAN);
            list.AddLast(456, "123 Liverpool Way.", HouseType.None);
            list.Display();
            Console.WriteLine($"\nSize of the array is: {list.Size}");
            list.RemoveLast();
            list.Display();

            Console.Write("\nEnter house number to search: ");
            if (int.TryParse(Console.ReadLine(), out int num))
            {
                Node node = list.SearchHouse(num);
                Console.WriteLine(node != null ? $"Found: {node.Data}" : "House not found.");
            }
        }
    }
}

