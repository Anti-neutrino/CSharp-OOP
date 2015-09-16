using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLongestPath
{
    public class Node
    {
        public int Value { get; private set; }
        public List<Node> Children { get; set; }

        public Node(int value)
        {
            this.Value = value;
            this.Children = new List<Node>();
        }

        public void AddChild(Node child)
        {
            Children.Add(child);
        }

        public int NumberOfChildren
        {
            get
            {
                return this.Children.Count;
            }
        }

        public Node GetNode(int index)
        {
            return this.Children[index];
        }
    }
}
