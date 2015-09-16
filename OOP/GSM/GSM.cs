using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.GSMProperties
{
    class GSM
    {

        private string gsmModel;
        private string gsmManufacture;
        private double gsmPrice;
        private string gsmOwner;
        private static GSM iPhone4S;

        public GSM(string gsmModel, string gsmManufacture, double gsmPrice, string gsmOwner)
        {
            this.gsmModel = gsmModel;
            this.gsmManufacture = gsmManufacture;
            this.gsmPrice = gsmPrice;
            this.gsmOwner = gsmOwner;
        }

        static GSM()
        {
            iPhone4S = new GSM("LPhone", "Lemon", 2000.11, "Djena");
        }

        public string GSMModel
        {
            get { return gsmModel; }
            set { gsmModel = value; }
        }

        public string GSMManufacture
        {
            get { return gsmManufacture; }
            set { gsmManufacture = value; }
        }

        public double GSMPrise
        {
            get { return gsmPrice; }
            set { gsmPrice = value; }
        }

        public string GSMOwner
        {
            get { return gsmOwner; }
            set { gsmOwner = value; }
        }

        public static GSM IPhone4S
        {
            get { return iPhone4S; }
            set { iPhone4S = value; }
        }

        public List<Call> CallHistory = new List<Call>();

        public override string ToString()
        {
            Console.WriteLine("GSM model: " + this.gsmModel);
            Console.WriteLine("GSM manufacture: " + this.gsmManufacture);
            Console.WriteLine("GSM price: {0} ", this.gsmPrice);
            Console.WriteLine("GSM owner: " + this.gsmOwner);
            Console.WriteLine();
            return base.ToString();
        }

        public void AddCalls(DateTime dateAndTime, string dialedPhoneNumber, int duration)
        {
            Call call = new Call(dateAndTime, dialedPhoneNumber, duration);
            CallHistory.Add(call);
        }

        public void DeleteCalls(int duration)
        {
            for (int i = 0; i < CallHistory.Count; i++)
            {
                if (CallHistory[i].Duration == duration)
                {
                    CallHistory.RemoveAt(i);
                    i--;
                }
            }
        }

        public void ClearCalls()
        {
            CallHistory.Clear();
        }

        public void CalculateTotalPrice(double pricePerMinute)
        {
            double wholeTime = 0;
            for (int i = 0; i < CallHistory.Count; i++)
            {
                wholeTime += CallHistory[i].Duration;
            }

            double price = pricePerMinute * (Math.Ceiling(wholeTime / 60));
            Console.WriteLine("Total price: " + price);
            Console.WriteLine();
        }

        public void PrintCalls()
        {
            for (int i = 0; i < CallHistory.Count; i++)
            {
                Console.WriteLine("Date and Time: " + CallHistory[i].DateAndTime);
                Console.WriteLine("Dialed number: " + CallHistory[i].DialedPhoneNumber);
                Console.WriteLine("Duration: {0} ", CallHistory[i].Duration);
                Console.WriteLine();
            }
        }
    }
}
