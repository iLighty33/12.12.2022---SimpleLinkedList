using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12._12._2022___SimpleLinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var myList = new NodeList("0");
            myList.AddLast("2");
            myList.AddLast("5");
            myList.AddLast("9");
            myList.AddLast("16");

            Console.WriteLine("MyList: ");
            myList.PrintLoop();

            myList.DelLast("16");

            Console.WriteLine("MyList After Deleting Item: ");
            myList.PrintLoop();

            Console.WriteLine("Вывод чётных чисел:\n");
            myList.Loop(x =>
            {
                try
                {
                    if (int.Parse(x.ToString()) % 2 == 0)
                    {
                        Console.WriteLine(x + " - чётное число");
                    }
                }
                catch
                {
                }
            });
            Console.WriteLine("\nВывод всего списка:\n");
            myList.Loop(x => Console.Write(" " + x));
            Console.WriteLine("\n" + myList);
            Console.WriteLine("Работает foreach:");
            foreach (var item in myList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine($"В нашем списке {myList.ToString()}" +
                $" содержится {myList.Count} записей");

            Console.ReadKey();
        }
    }
    class Node // Звено односвязной цепочки
    {
        public string Data { get; set; }
        public Node(string data)
        {
            Data = data;
        }
        public Node Next { get; set; }
    }
    class NodeList : IEnumerable, IEnumerator // Односвязная цепочка
    {
        public int Count
        {
            get
            {
                int count = 0;
                Node current = Head;
                while (current.Next != null)
                {
                    count++;
                    current = current.Next;
                }
                return count + 1;
            }
            private set { }
        }
        int position = -1;
        public NodeList()
        {
            Head = null;
            Count = 0;
        }
        public bool MoveNext()
        {
            Node current = Head;
            while (current != null)
            {
                current = current.Next;
                return true;
            }
            return false;
        }
        public object Current
        {
            get
            {
                if (position == -1 || position >= Count)
                {
                    throw new Exception("Некорректный индекс элемента");
                }
                else
                {
                    return position;
                }
            }

        }
        public void Reset()
        {
            position = -1;
        }
        public IEnumerator GetEnumerator()
        {
            Node current = Head;
            while (current.Next != null)
            {
                yield return current.Data;
                current = current.Next;
            }
            yield return current.Data;
        }
        public int Length
        {
            get
            {
                int length = 0;
                Node current = Head;
                while (current != null)
                {
                    length++;
                    current = current.Next;
                }
                return length;
            }
        }
        public Node Head { get; private set; } // Ссылочной тип, Head - ссылка

        public NodeList(string headData)
        {
            Head = new Node(headData);
            position++;
        }
        public void AddLast(string data)
        {
            Node current = Head;
            while (current.Next != null)
            {
                current = current.Next;
                position++;
            }
            current.Next = new Node(data);
        }
        public void DelLast(string data)
        {
            if (Head != null)
            {
                if (Head.Data.Equals(data))
                {
                    Head = Head.Next;
                    Count--;
                    return;
                }
                var current = Head.Next;
                var previous = Head;


                while(current != null)
                {
                    if(current.Data.Equals(data))
                    {
                        previous.Next = current.Next;
                        Count--;
                        return;
                    }
                    previous = current;
                    current = current.Next;
                }
            }
        }
        public void PrintLoop()
        {
            Node current = Head;
            while (current != null)
            {
                Console.WriteLine(current.Data);
                current = current.Next;
            }
        }
        public void Loop(Action<object> action)
        {
            Node current = Head;
            while (current != null)
            {
                action(current.Data);
                current = current.Next;
            }
        }
    }

}
