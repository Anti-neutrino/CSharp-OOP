using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindTheShortestPath
{
    class ShortestPath
    {
        private class Node
        {
            public int Number { get; set; }
            public Node Previous { get; set; }

            public Node(int number)
            {
                this.Number = number;
                this.Previous = null;
            }

            public Node(int number,Node previous)
            {
                this.Number = number;
                this.Previous = previous;
            }
        }
        static void Main()
        {
            string input = Console.ReadLine();
            var inputSplit = input.Split(' ');
            int firstNumber = int.Parse(inputSplit[0]);
            int lastNumber = int.Parse(inputSplit[1]);

            Queue<Node> queueOfNodes = new Queue<Node>();
            queueOfNodes.Enqueue(new Node(firstNumber));

            while(queueOfNodes.Count>0)
            {
                Node currentNode = queueOfNodes.Dequeue();

                if(currentNode.Number<lastNumber)
                {
                    queueOfNodes.Enqueue(new Node(currentNode.Number + 1, currentNode));
                    queueOfNodes.Enqueue(new Node(currentNode.Number + 2, currentNode));
                    queueOfNodes.Equals(new Node(currentNode.Number * 2, currentNode));
                }

                if(currentNode.Number==lastNumber)
                {
                    while(currentNode!=null)
                    {
                        Console.Write(currentNode.Number + " ");
                        currentNode = currentNode.Previous;
                    }
                }
            }            
        }
    }
}
