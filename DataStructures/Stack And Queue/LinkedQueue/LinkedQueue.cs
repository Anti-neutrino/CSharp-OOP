using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedQueue
{
    public class LinkedQueue<T>
    {
        public class QueueNode<P>
        {
            public P Value { get; set; }
            public QueueNode<P> Next { get; set; }
            public QueueNode<P> Prev { get; set; }

            public QueueNode(P val)
            {
                this.Value = val;
            }
        }

        public QueueNode<T> Head { get;private set; }
        public QueueNode<T> Tail { get;private set; }
        public int Count { get; private set; }

        public LinkedQueue()
        {
            this.Head = null;
            this.Tail = null;
            this.Count = 0;
        }

        public void Enqueue(T element)
        {
            if(this.Head==null)
            {
                this.Head=this.Tail = new QueueNode<T>(element);
            }
            else
            {
                QueueNode<T> newNode = new QueueNode<T>(element);
                newNode.Next = this.Head;
                this.Head.Prev = newNode;
                this.Head = newNode;
            }
            this.Count++;
        }
        
        public T Dequeue()
        {
            if(this.Count<=0)
            {
                throw new ArgumentException("Queue is empty!");
            }

            T element = this.Tail.Value;
            this.Tail = this.Tail.Prev;

            if(this.Tail!=null)
            {
                this.Tail.Next = null;
            }
            else
            {
                this.Head = null;
            }


            this.Count--;
            return element;

        }

        public void Print()
        {
            QueueNode<T> newNode = this.Tail;

            while(newNode!=null)
            {
                Console.WriteLine(newNode.Value);
                newNode = newNode.Prev;
            }
        }

        public T Peek()
        {
            return this.Tail.Value;
        }

        public T[] ToArray()
        {
            T[] arr = new T[this.Count];

            QueueNode<T> newNode = this.Tail;

            for(int i=0;i<this.Count;i++)
            {
                arr[i] = newNode.Value;
                newNode = newNode.Prev;
            }

            return arr;
        }
    }
}
