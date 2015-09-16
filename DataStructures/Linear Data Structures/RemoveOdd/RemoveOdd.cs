using System;
using System.Collections.Generic;

namespace RemoveOdd
{
    class RemoveOdd
    {
        static void Main()
        {
            List<int> list = new List<int>() { 1, 1, 2, 1, 3, 5, 1, 4, 4, 5 };
            List<int> numbers=new List<int>();

            for (int i = 0; i < list.Count; i++)
            {
                if(list[i]%2==1)
                {
                    numbers.Add(list[i]);
                }
            }

            for (int i = 0; i < numbers.Count;i++ )
            {
                for(int j=0;j<list.Count;j++)
                {
                    if(numbers[i]==list[j])
                    {
                        list.Remove(numbers[i]);
                    }
                }
            }

                for (int i = 0; i < list.Count; i++)
                {
                    Console.Write("{0} ", list[i]);
                }

            Console.WriteLine();
        }
    }
}
