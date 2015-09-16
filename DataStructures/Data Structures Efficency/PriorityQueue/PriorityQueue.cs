using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueue
{
    public class PriorityQueue<T>where T:IComparable
    {
        private BinaryHeap<T> heap;

        public PriorityQueue()
        {
            this.heap = new BinaryHeap<T>();
        }

        public void Enqueue(T element)
        {
            this.heap.Insert(element);
        }

        public T Peek()
        {
            return heap.Peek();
        }

        public T Dequeue()
        {
            return this.heap.ExtractMax();
        }

    }
}
