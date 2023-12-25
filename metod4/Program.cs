class Metod1
{
    public class dek<T>
    {
        private DoublyNode<T> head;
        private DoublyNode<T> tail;

        public void AddToFront(T data)
        {
            DoublyNode<T> new_node = new DoublyNode<T>(data);

            if (head == null)
            {
                head = new_node;
                tail = new_node;
            }
            else
            {
                new_node.Next = head;
                head.Previous = new_node;
                head = new_node;
            }
        }

        public void AddToBack(T data)
        {
            DoublyNode<T> new_node = new DoublyNode<T>(data);

            if (tail == null)
            {
                tail = new_node;
                head = new_node;
            }
            else
            {
                new_node.Previous = tail;
                tail.Next = new_node;
                tail = new_node;
            }
        }

        public void Remove(T data)
        {
            DoublyNode<T> current_node = head;

            while (current_node != null)
            {
                if (current_node.Data.Equals(data))
                {
                    if (current_node == head && current_node == tail)
                    {
                        head = null;
                        tail = null;
                    }
                    else if (current_node == head)
                    {
                        head = current_node.Next;
                        head.Previous = null;
                    }
                    else if (current_node == tail)
                    {
                        tail = current_node.Previous;
                        tail.Next = null;
                    }
                    else
                    {
                        current_node.Previous.Next = current_node.Next;
                        current_node.Next.Previous = current_node.Previous;
                    }

                    return;
                }
                current_node = current_node.Next;
            }
        }

        public void RemoveFromFront()
        {
            if (head == null)
            {
                return;
            }

            if (head == tail)
            {
                head = null;
                tail = null;
            }
            else
            {
                head = head.Next;
                head.Previous = null;
            }
        }

        public void RemoveFromBack()
        {
            if (tail == null)
            {
                return;
            }

            if (head == tail)
            {
                head = null;
                tail = null;
            }
            else
            {
                tail = tail.Previous;
                tail.Next = null;
            }
        }

        public void Print()
        {
            DoublyNode<T> current_node = head;

            while (current_node != null)
            {
                Console.Write($"{current_node.Data} ");
                current_node = current_node.Next;
            }
            Console.WriteLine();
        }

        public List<int> Search(T data)
        {
            DoublyNode<T> current_node = head;
            List<int> positions = new List<int>();

            int index = 0;
            while (current_node != null)
            {
                if (current_node.Data.Equals(data))
                {
                    positions.Add(index);
                }

                current_node = current_node.Next;
                index++;
            }

            return positions;
        }
    }

    public class DoublyNode<T>
    {
        public DoublyNode(T data)
        {
            Data = data;
        }

        public T Data { get; set; }
        public DoublyNode<T> Previous { get; set; }
        public DoublyNode<T> Next { get; set; }
    }

    static void Main()
    {
        dek<int> dek = new dek<int>();
        dek.AddToBack(382);
        dek.AddToFront(1);
        dek.AddToBack(4);
        dek.AddToFront(3);
        dek.AddToBack(2777);

        dek.Print(); // 3 1 382 4 2777

        dek.RemoveFromBack();
        dek.Print(); // 3 1 382 4

        dek.RemoveFromFront();
        dek.Print(); // 1 382 4

        dek.Remove(4);
        dek.Print(); // 1 382 

        int x = 382;
        List<int> positions = dek.Search(x);
        Console.WriteLine($"Позиции элемента {x}: " + string.Join(", ", positions)); // Позиции элемента 382: 1
    }
}