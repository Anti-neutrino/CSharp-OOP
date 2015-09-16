using System;
using System.Text;

namespace Battle
{
    class Warrior : Hero
    {
        public double Crit { get; private set; }
        public string Clan { get; private set; }
        public Warrior(string name = "Barbukov", int a = 5, int b = 100, double cr = 10, string cl = "CSKA")
            : base(name, a, b)
        {
            this.Crit = cr;
            this.Clan = cl;
        }
        public override int getAttack()
        {
            Random generator = new Random();
            int number = generator.Next(0, 101);
            if (Crit > number)
            {
                return BaseAttack * 2;
            }
            return BaseAttack;
        }
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("Name: " + Name + "\n");
            builder.Append("Attack: " + BaseAttack + '\n');
            builder.Append("Health: " + Health + '\n');
            builder.Append("Critical: " + Crit + '\n');
            builder.Append("Clan: " + Clan + '\n');
            return builder.ToString();
        }
    }
}
