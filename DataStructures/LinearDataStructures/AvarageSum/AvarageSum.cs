using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvarageSum
{
    class Test
    {
        static void Main()
        {
            string numbers = Console.ReadLine();
            List<int> list = new List<int>();
            int i=0;
            
            while (i < numbers.Length)
            {
                if ((numbers[i] >= '0') && (numbers[i] <= '9'))
                {
                    int number = 0;

                    while ((i<numbers.Length) && (numbers[i] != ' '))
                    {
                        number = number * 10 + (numbers[i] - 48);
                        i++;
                    }

                    list.Add(number);
                    number = 0;
                
                }
                else
                {
                    i++;
                }
            }

            int sum = 0;
            double avarage = 0;

            for (int k = 0; k < list.Count; k++)
            {
                sum=sum+list[k];
            }

            avarage =sum/ list.Count;

            Console.WriteLine("Sum: {0}", sum);
            Console.WriteLine("Avarage: {0}", avarage);
        }
    }
}
