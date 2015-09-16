using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.FindWordsInFile
{
    public class WordsCounter
    {
        static void Main()
        {
            Console.Write("Enter rows: ");
            int rows = int.Parse(Console.ReadLine());
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            for (int i = 0; i < rows; i++)
            {
                Console.Write("Enter words: ");
                string inputSentance = Console.ReadLine();
                var stringList = inputSentance.Split(new char[] { ' ', '.' });
                foreach (var word in stringList)
                {
                    if (dictionary.Keys.Contains(word))
                    {
                        dictionary[word] = dictionary[word] + 1;
                    }
                    else
                    {
                        dictionary.Add(word, 1);
                    }
                }
            }

            Console.Write("Enter number of words: ");
            int numberOfWord = int.Parse(Console.ReadLine());
            string[] listOfWords = new string[numberOfWord];
            for (int i = 0; i < listOfWords.Length; i++)
            {
                listOfWords[i] = Console.ReadLine();
            }

            for (int i = 0; i < numberOfWord; i++)
            {
                if (dictionary.Keys.Contains(listOfWords[i]))
                {
                    Console.WriteLine("{0} -> {1}", listOfWords[i], dictionary[listOfWords[i]]);
                }
            }
        }
    }
}
