using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreesAndGraphsTraversalHomework
{
    public class Tree
    {
        public int Value { get; set; }
        public Tree HasParent { get; set; }
        public List<Tree> Children { get; set; }

        public Tree(int value)
        {
            this.Value = value;
            this.Children = new List<Tree>();
        }
    }
}
