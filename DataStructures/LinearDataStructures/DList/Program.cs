using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    class LinkedList<T>:IEnumerable<T>
    {
        class Node<T>
        {
            public T Value { get; set; }
            public Node<T> Next { get; set; }
            public Node<T> Prev { get; set; }

            public Node()
            {
                this.Next = null;
                this.Prev = null;
            }
            public Node(T elem)
            {
                this.Value = elem;

            }
        }

        private Node<T> First;
        private Node<T> Last;
        public int Count { get; set; }
        public LinkedList()
        {
            this.First = null;
            this.Last = null;
        }
        
        public void AddFirst(T value)
        {
            if(this.Count==0)
            {
                this.First = this.Last = new Node<T>(value);
            }
            else
            {
                var newNode = new Node<T>(value);

                newNode.Next = this.First;
                this.First.Prev = newNode;
                this.First = newNode;
            }
            this.Count++;
        }

        public void AddLast(T value)
        {
            if(this.Count==0)
            {
                this.First = this.Last = new Node<T>(value);
            }
            else
            {
                var newNode = new Node<T>(value);
                this.Last.Next = newNode;
                this.Last = newNode;
            }

            this.Count++;
        }

        public void RemoveFirst()
        {
            if (this.Count>0)
            {
                this.First = this.First.Next;
                this.Count--;
            }
        }

        public void RemoveLast()
        {
            if(this.Count>0)
            {
                Node<T> newNode = First;
                while(newNode.Next!=this.Last)
                {
                    newNode = newNode.Next;
                }
                newNode.Next = null;
                this.Count--;
            }
        }

        public void ForEach(Action<T> action)
        {
            var current = this.First;
            while(current!=null)
            {
                action(current.Value);
                current = current.Next;
            }
        }

        public T[] ToArray()
        {
            var arr = new T[this.Count];
            int index = 0;
            var newNode = this.First;
            while(newNode!=null)
            {
                arr[index] = newNode.Value;
                index++;
                newNode = newNode.Next;
            }
            return arr;
        }

        public void Print()
        {
            Node<T> p = this.First;

            while(p!=null)
            {
                Console.Write("{0} ",p.Value);
                p = p.Next;
            }
            Console.WriteLine();
        }


        public IEnumerator<T> GetEnumerator()
        {
            var current = this.First;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    class Test
    {
        static void Main()
        {
            LinkedList<int> arr=new LinkedList<int>();
            
            arr.AddFirst(2);
            arr.AddFirst(5);
            arr.AddFirst(5435);

            arr.AddLast(12);
            arr.AddLast(83);

            arr.RemoveLast();         

            arr.Print();

            arr.AddFirst(2);

            arr.Print();

            foreach(var items in arr)
            {
                Console.Write(items +" " );
            }
        }
    }
}
