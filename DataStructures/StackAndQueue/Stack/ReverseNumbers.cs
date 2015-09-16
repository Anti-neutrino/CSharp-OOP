using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    class ReverseNumbers
    {
        static void Main()
        {
            int n = 5;
            int[] arr = new int[n];

            for(int i=0;i<5;i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }

            Stack<int> numbers = new Stack<int>();

            for(int i=0;i<arr.Length;i++)
            {
                numbers.Push(arr[i]);
            }

            while(numbers.Count>0)
            {
                int num = numbers.Pop();
                Console.WriteLine(num);
            }
        }
    }
}
