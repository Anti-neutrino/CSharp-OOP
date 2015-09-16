using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoundDance
{
    class Test
    {
        static Dictionary<int, Person> friends = new Dictionary<int, Person>();

        static int maxDepth = 0;


        public static Person GetNodeByValue(int num)
        {
            if (!friends.ContainsKey(num))
            {
                friends[num] = new Person(num);
            }

            return friends[num];
        }

        static int FindDepth(Person leader,int depth=0)
        {
            if(maxDepth<depth)
            {
                maxDepth = depth;
            }

            foreach(var child in leader.Friend)
            {
                FindDepth(child, depth + 1);
            }

            return maxDepth+1;
        }

        static void Main()
        {
            Console.Write("Enter number of the friendships: ");
            int friendshipNumber = int.Parse(Console.ReadLine());
            Console.Write("Enter dance leader: ");
            int danceLeader = int.Parse(Console.ReadLine());

            for(int i=0;i<friendshipNumber;i++)
            {
                Console.Write("{0} frindship couple :",i+1);
                string relationShip = Console.ReadLine();
                string[] relationShipSplit = relationShip.Split(' ');

                int first =int.Parse(relationShipSplit[0]);
                Person personNum = GetNodeByValue(first);
                int friend =int.Parse(relationShipSplit[1]);
                Person friendNum = GetNodeByValue(friend);

                personNum.Friend.Add(friendNum);
                friendNum.HasParent = personNum;

               
            } 

            int depth = FindDepth(friends[danceLeader]);
            Console.WriteLine("The longest sequence is: {0}", depth);
        }
    }
}
