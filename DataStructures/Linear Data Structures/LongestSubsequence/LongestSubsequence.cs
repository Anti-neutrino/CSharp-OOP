using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestSubsequence
{
    class LongestSubsequence
    {
        static List<int> LongSubs(List<int> a)
        {
            List<int> newList = new List<int>();
            int favNumber = a[0];
            int currentCounter = 1;
            int maxCounter = 1;

            for (int i = 0; i < a.Count - 1; i++)
            {
                if (a[i] == a[i + 1])
                {
                    currentCounter++;
                    if (currentCounter > maxCounter)
                    {
                        maxCounter = currentCounter;
                        favNumber = a[i];
                    }
                }
                else
                {
                    currentCounter = 1;
                }
            }

            for (int i = 0; i < maxCounter; i++)
            {
                newList.Add(favNumber);
            }

            return newList;
        }
        static void Main()
        {
            List<int> list = new List<int>(){1,2,2,2,2,3,4,4,4,4};
            List<int> result = LongSubs(list);

            for(int i=0;i<result.Count;i++)
            {
                Console.Write("{0} ", result[i]);
            }

            Console.WriteLine();
        }
    }
}
