using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLongestPath
{
    class Test
    {
        static List<Node> newNodes = new List<Node>();

        static void DFS(Node node,int currentSum)
        {
            currentSum += node.Value;
            newNodes.Add(node);

            foreach(var child in node.Children)
            {
                if(newNodes.Contains(child))
                {
                    continue;
                }

                DFS(child,currentSum);
            }

            if(node.NumberOfChildren==1&&currentSum>maxSum)
            {
                maxSum = currentSum;
            }
        }

        static int maxSum = 0;

        static void Main()
        {
            Console.Write("Enter number of nodes:");
            int n = int.Parse(Console.ReadLine());
            Dictionary<int, Node> nodes = new Dictionary<int, Node>();

            for(int i=1; i<n; i++)
            {
                Console.Write("{0} edge couple: ", i);
                string connection = Console.ReadLine();
                var connectionSplit = connection.Split(' ');

                int parent = int.Parse(connectionSplit[0]);
                int child = int.Parse(connectionSplit[1]);

                Node parentNode;
                if(nodes.ContainsKey(parent))
                {
                    parentNode = nodes[parent];
                }
                else
                {
                    parentNode = new Node(parent);
                    nodes.Add(parent, parentNode);
                }

                Node childNode;

                if(nodes.ContainsKey(child))
                {
                    childNode = nodes[child];
                }
                else
                {
                    childNode = new Node(child);
                    nodes.Add(child, childNode);
                }

                parentNode.AddChild(childNode);
                childNode.AddChild(parentNode);
            }

            foreach(var node in nodes)
            {
                if(node.Value.NumberOfChildren==1)
                {
                    newNodes.Clear();
                    DFS(node.Value,0);
                }
            }

            Console.WriteLine(maxSum);
        }
    }
}
