namespace Mines
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Player
    {
        private string name;
        private int points;

        public Player()
        {
        }

        public Player(string newName, int newPoints)
        {
            this.name = newName;
            this.points = newPoints;
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public int Points
        {
            get { return this.points; }
            set { this.points = value; }
        }
    }
}
