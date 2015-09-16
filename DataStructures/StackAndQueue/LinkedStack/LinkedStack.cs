using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedStack
{
    public class LinkedStack<T>
    {
        private class Node<T>
        {
            public T value;
            public Node<T> NextNode { get; set; }
            public Node(T val, Node<T> nextNode = null)
            {
                this.value = val;
                this.NextNode = nextNode;
            }
        }

        private Node<T> firstNode;
        public int Count { get; private set; }

        public LinkedStack()
        {
            this.firstNode = null;
            this.Count = 0;
        }

        public void Push(T element)
        {
            firstNode = new Node<T>(element, firstNode);
            this.Count++;
        }

        public T Peek()
        {
            return firstNode.value;
        }

        public T Pop()
        {
            if (this.Count > 0)
            {
                T element = firstNode.value;

                firstNode = firstNode.NextNode;
                this.Count--;
                return element;
            }
            else
            {
                throw new IndexOutOfRangeException("The stack is empty!");
            }

        }

        public T[] ToArray()
        {
            T[] newArr = new T[this.Count];
            Node<T> newNode = firstNode;
            int index = 0;

            while (newNode != null)
            {
                newArr[index] = newNode.value;
                newNode = newNode.NextNode;
                index++;
            }

            return newArr;
        }

        public void Print()
        {
            Node<T> newNode = firstNode;

            while (newNode != null)
            {
                Console.Write("{0} ", newNode.value);
                newNode = newNode.NextNode;
            }

            Console.WriteLine();
        }
    }
}
