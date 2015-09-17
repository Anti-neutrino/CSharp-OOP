using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefeatorIf_Statements
{
    class Program
    {
        static void Main()
        {
            Potato potato=new Potato();
            //... 
            if (potato != null)
            {
                bool isForCook=potato.HasBeenPeeled && !potato.IsRotten;

                if (isForCook)
                {
                    Cook(potato);
                }
                else
                {
                    Console.WriteLine("Potatoes are not for eat.");
                }
            }
        }

        private static void Cook(Potato potato)
        {
            Console.WriteLine("Potatoes is boiling...");
        }
    }
}
