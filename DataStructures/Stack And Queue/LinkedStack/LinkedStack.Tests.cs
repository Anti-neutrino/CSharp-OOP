using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedStack
{
    public class LinkedStackTest
    {
        static void Main()
        {
            LinkedStack<int> stack = new LinkedStack<int>();
            stack.Push(14);
            stack.Push(88);

            Console.WriteLine(stack.Peek());

            stack.Pop();
            Console.WriteLine(stack.Peek());
        }
    }
}
