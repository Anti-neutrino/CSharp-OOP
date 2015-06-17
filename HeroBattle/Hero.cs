using System;
using System.Text;

namespace Battle
{
    abstract class Hero
    {
        public string Name { get; private set; }
        public int BaseAttack { get; private set; }
        public int Health { get; protected set; }
        public Hero(string name = "Samuil", int att = 10, int health = 50)
        {
            this.Name = name;
            this.BaseAttack = att;
            this.Health = health;
        }
        public virtual void takeDemage(int damage)
        {
            Health = Health - damage;
        }
        public virtual int getAttack()
        {
            return this.BaseAttack;
        }
        public virtual void takeHealing(int health)
        {
            Health = Health + health;
        }
    }
}
