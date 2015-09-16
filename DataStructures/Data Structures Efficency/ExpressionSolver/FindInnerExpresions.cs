using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionSolver
{
    class FindInnerExpresions
    {
        static void Main()
        {
            string expression = Console.ReadLine();
            var stack = new Stack<int>();

            for (int i = 0; i < expression.Length; i++)
            {
                char ch = expression[i];
                if(ch=='(')
                {
                    stack.Push(i);
                }
                else if(ch==')')
                {
                    int startIndex = stack.Pop();
                    int length = i - startIndex + 1;
                    string content = expression.Substring(startIndex, length);
                    Console.WriteLine(content);
                }
            }
        }
    }
}
