using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ShopingCenter
{
    public class ShopingCenterMarketing
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

            var center = new ShopingCenter();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string command = Console.ReadLine();
                string processCommand = center.ProccessComand(command);
                Console.WriteLine(processCommand);
            }
        }
    }
}
