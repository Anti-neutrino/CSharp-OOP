using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountOfOccurences
{
    class Program
    {
        static void Main()
        {
            List<int> numbers = new List<int>(){11,43,12,2,4,1,6,43,11,43,2,5,3,2};
            int[] counter = new int[numbers.Count];

            for(int i=0;i<counter.Length;i++)
            {
                counter[i] = 1;
            }

            for(int i=0;i<numbers.Count;i++)
            {
                for(int j=0;j<numbers.Count;j++)
                {
                    if((numbers[i]==numbers[j]) && (i!=j))
                    {
                        counter[i]++;
                    }
                }
            }

            for(int i=0;i<numbers.Count;i++)
            {
                Console.WriteLine("{0} ->{1} times.", numbers[i], counter[i]);
            }
        }
    }
}
