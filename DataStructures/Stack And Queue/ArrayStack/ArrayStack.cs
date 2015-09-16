using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayStack
{
    public class ArrayStack<T>
    {
        private T[] elements;

        public int Count { get; private set; }

        public int Capacity { get; private set; }

        private const int InitialCapacity = 16;

        public ArrayStack(int capacity = InitialCapacity)
        {
            this.elements = new T[InitialCapacity];
            this.Count = 0;
            this.Capacity = capacity;
        }

        public void Grow()
        {
            if (this.Count >= this.Capacity - 1)
            {
                this.Capacity = this.Capacity * 2;

                T[] newArr = new T[this.Capacity];

                for (int i = 0; i < this.Count; i++)
                {
                    newArr[i] = this.elements[i];
                }

                this.elements = newArr;
            }
        }

        public void Push(T element)
        {
            Grow();

            T[] newArr = new T[this.Capacity];

            newArr[0] = element;
            this.Count++;

            for (int i = 0; i < this.Count; i++)
            {
                newArr[i + 1] = this.elements[i];
            }


            this.elements = newArr;
        }

        public T Pop()
        {
            if (isEmpty())
            {
                throw new ArgumentException("Stack is empty!");
            }

            T element = this.elements[0];
            T[] newArr = new T[this.Capacity];

            for (int i = 1; i < this.Count; i++)
            {
                newArr[i - 1] = this.elements[i];
            }

            this.Count--;
            this.elements = newArr;

            return element;
        }

        public T Peek()
        {
            return this.elements[0];
        }

        public bool isEmpty()
        {
            return this.Count == 0;
        }

        public T[] ToArray()
        {
            T[] newArr = new T[this.Count];

            for (int i = 0; i < this.Count; i++)
            {
                newArr[i] = this.elements[i];
            }

            return elements;
        }
    }
}

