using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreesAndGraphsTraversalHomework
{

    public class FindTheRoot
    {
        static Dictionary<int, Tree> node = new Dictionary<int, Tree>();

        public static Tree FindRoot()
        {
            var rootNode = node.Values.FirstOrDefault(nodes => nodes.HasParent == null);
            return rootNode;
        }

        public static Tree GetNodeByValue(int num)
        {
            if (!node.ContainsKey(num))
            {
                node[num] = new Tree(num);
            }

            return node[num];
        }
        static void Main()
        {
            Console.Write("Enter number of edges: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Console.Write("{0} edge coupe:", i + 1);
                string input = Console.ReadLine();
                var inputSplit = input.Split(' ');
                int parent = int.Parse(inputSplit[0]);
                Tree predessor = GetNodeByValue(parent);
                int child = int.Parse(inputSplit[1]);
                Tree desendent = GetNodeByValue(child);

                predessor.Children.Add(desendent);
                desendent.HasParent = predessor;
            }

            Console.Write("Root: {0}", FindRoot().Value);
            Console.WriteLine();
        }
    }

}
