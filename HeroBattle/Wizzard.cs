using System;
using System.Text;

namespace Battle
{
    class Wizzard : Hero
    {
        public double Drain { get; private set; }
        public string Rang { get; private set; }
        public Wizzard(string name = "Gonzo", int a = 2, int b = 100, double dr = 12, string ra = "Lesni")
            : base(name, a, b)
        {
            this.Drain = dr;
            this.Rang = ra;
        }
        public override int getAttack()
        {
            Random generator = new Random();
            int number = generator.Next(0, 101);
            if (number < Drain)
            {
                Health = Health + BaseAttack / 2;
            }
            return this.BaseAttack;
        }
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("Name: " + Name + "\n");
            builder.Append("Attack: " + BaseAttack + '\n');
            builder.Append("Health: " + Health + '\n');
            builder.Append("Drain: " + Drain + '\n');
            builder.Append("Rang: " + Rang + '\n');
            return builder.ToString();
        }
    }
}
