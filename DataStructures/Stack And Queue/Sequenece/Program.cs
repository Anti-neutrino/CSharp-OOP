using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sequenece
{
    class Program
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            Queue<int> sequence = new Queue<int>();

            sequence.Enqueue(number);

           
            int index = 0;
            while (sequence.Count < 50)
            {
                int currentNum = sequence.ElementAt(index);

                sequence.Enqueue(currentNum + 1);
                sequence.Enqueue(2 * currentNum + 1);
                sequence.Enqueue(currentNum + 2);

                index++;
            }

            for (int i = 0; i < 50; i++)
            {
                int a = sequence.Dequeue();

                Console.WriteLine(a);
            }
        }
    }
}
