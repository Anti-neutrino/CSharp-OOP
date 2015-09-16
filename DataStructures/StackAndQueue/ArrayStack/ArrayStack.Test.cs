using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayStack
{
    class ArrayStack
    {
        static void Main()
        {
            ArrayStack<int> stack = new ArrayStack<int>();
            stack.Push(12);
            stack.Push(123);
            stack.Push(32);

            Console.WriteLine(stack.Peek());

            stack.Pop();

            Console.WriteLine(stack.Peek());
        }
    }
}
