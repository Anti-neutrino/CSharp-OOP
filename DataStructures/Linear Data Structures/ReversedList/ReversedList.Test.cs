using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReversedList
{   
    class Test
    {
        static void Main()
        {
            List<int> list = new List<int>() { 1, 2, 3, 4, 5, 6 };
            RiversedList<int> rList = new RiversedList<int>(list);

            rList.Add(2);
            rList.Add(12);
            rList.Add(122);
            rList.Remove(3);

            foreach(int item in rList)
            {
                Console.WriteLine(item);
            }
        }
    }
}
