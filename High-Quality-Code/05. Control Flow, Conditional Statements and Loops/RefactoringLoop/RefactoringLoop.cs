using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactoringLoop
{
    class RefactoringLoop
    {
        static void ValueFound(int[] arr, int expectedValue,int index,bool isFound)
        {
            if (arr[index] == expectedValue)
            {
                isFound = true;
                Console.WriteLine("Value found!");
                return;
            }
        }
        static void Main()
        {
            int[] array = new int[100];
            int expectedValue = int.Parse(Console.ReadLine());
            bool isFound = false;

            for (int i=0; i < 100; i++)
            {
                if (i % 10 == 0)
                {
                    ValueFound(array, expectedValue, i,isFound);
                }
                Console.WriteLine(array[i]);  
            }

            if(!isFound)
            {
                throw new ArgumentException("This elements don't contain in this array!");
            }
            
        }
    }
}
