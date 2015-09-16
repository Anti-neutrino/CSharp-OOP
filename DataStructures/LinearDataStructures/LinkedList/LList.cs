using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    class LinkedList<T> : IEnumerable<T>
    {
        private ListNode<T> first;
        public int Count { get; private set; }

        public LinkedList()
        {
            first = null;
        }

        public void Add(T element)
        {
            if (first == null)
            {
                first = new ListNode<T>(element);
            }
            else
            {
                ListNode<T> newNode = new ListNode<T>(element);
                newNode.next = this.first;
                this.first = newNode;
            }

            this.Count++;
        }

        public void Remove(int index)
        {
            if ((index >= 0) && (index <= this.Count))
            {
                ListNode<T> newNode = first;
                int i = 0;

                while (i < index - 1)
                {
                    newNode = newNode.next;
                    i++;
                }

                newNode.next = newNode.next.next;
                this.Count--;
            }
        }

        public int FirstIndexOf(T item)
        {
            ListNode<T> newNode = first;
            int index = 0;

            while (!newNode.value.Equals(item))
            {
                newNode = newNode.next;
                index++;
                if (index == this.Count)
                {
                    Console.WriteLine("This element doesn't contain in this linked list!");
                    Environment.Exit(1);
                }
            }

            return index;
        }

        public int LastIndexOf(T item)
        {
            ListNode<T> newNode = first;
            int index = 0;
            bool check = false;

            for(int i=0;i<this.Count;i++)
            {
                if(newNode.value.Equals(item))
                {
                    index = i;
                    check = true;
                }
                newNode = newNode.next;
            }
            if (!check)
            {
                Console.WriteLine("This element doesn't exist in the list.");
                Environment.Exit(1);
            }
            return index;
        }

        public IEnumerator<T> GetEnumerator()
        {
            ListNode<T> p = first;
            while (p != null)
            {
                yield return p.value;
                p = p.next;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
