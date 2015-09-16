using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{ 
    class Test
    {
        static void Main()
        {
            LinkedList<int> arr = new LinkedList<int>();

            arr.Add(12);
            arr.Add(123);
            arr.Add(-1);
            arr.Add(65);
            arr.Add(123);
            arr.Add(98);

            arr.Remove(4);

            Console.WriteLine(arr.FirstIndexOf(123));
            Console.WriteLine(arr.LastIndexOf(123));
            foreach(int item in arr)
            {
                Console.WriteLine(item);
            }
        }
    }
}
