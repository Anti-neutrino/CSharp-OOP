using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rope
{
    class Test
    {
        static void Main()
        {
            StringEditior editor = new StringEditior();

            while (true)
            {
                string input = Console.ReadLine();
                var inputSplit = input.Split(' ');

                string command = inputSplit[0];
               // string str = inputSplit[1];

                switch (command)
                {
                    case "INSERT":
                        editor.Add(inputSplit[1],int.Parse(inputSplit[2])); break;
                    case "APPEND": editor.Append(inputSplit[1]); break;
                    case "DELETE":                      
                        editor.Delete(int.Parse(inputSplit[1]),int.Parse(inputSplit[2]));
                        break;
                    case "PRINT": editor.Print(); break;
                    case "REPLACE": editor.Replace(int.Parse(inputSplit[1]), int.Parse(inputSplit[2]), inputSplit[3]); break;
                    default: Console.WriteLine("Enter correct command."); break;
                }
            }
        }
    }
}