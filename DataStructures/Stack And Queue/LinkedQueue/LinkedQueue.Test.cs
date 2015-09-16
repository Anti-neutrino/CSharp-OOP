using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedQueue
{
    public class LinkedQueue
    {
        public static void Main()
        {
            LinkedQueue<int> queue = new LinkedQueue<int>();

            queue.Enqueue(12);
            queue.Enqueue(123);
            queue.Enqueue(981);

            queue.Dequeue();

            queue.Print();

            int[] arr = queue.ToArray();
            Console.WriteLine(arr[1]);
        }
    }
}
