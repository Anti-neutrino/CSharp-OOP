using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.GSMProperties
{

    class GSMTest
    {
        static void Main()
        {
            GSM[] arr = new GSM[3];

            GSM first = new GSM("Simens", "Mimens", 10, "Djena");
            arr[0] = first;

            GSM second = new GSM("3", "IPhone", 1200, "Alexandra ");
            arr[1] = second;

            GSM third = new GSM("Ace 2", "Samsung", 500, "Stancho");
            arr[2] = third;

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i].ToString();
            }

            GSM.IPhone4S.ToString();

            GSM fourthGSM = new GSM("OneS", "HTC", 891, "Mihaela");

            Console.WriteLine("Add");
            fourthGSM.AddCalls(DateTime.Now, "089867120", 55);
            fourthGSM.AddCalls(DateTime.Now, "088712315", 94);
            fourthGSM.AddCalls(DateTime.Now, "088888888", 33);
            fourthGSM.PrintCalls();

            Console.WriteLine("Delete  ");
            fourthGSM.DeleteCalls(11);
            fourthGSM.PrintCalls();

            fourthGSM.CalculateTotalPrice(13.12);


            fourthGSM.ClearCalls();
            fourthGSM.PrintCalls();
        }
    }
}