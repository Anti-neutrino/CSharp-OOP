using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rope
{
    public class StringEditior
    {
        private string input;
        public StringEditior()
        {
            input = String.Empty;
        }

        public void Add(string addInput, int startPosition)
        {
            if (startPosition < 0 || startPosition > input.Length)
            {
                throw new IndexOutOfRangeException("Index out of range.");
            }

            string newString = string.Empty;
            for (int i = 0; i < startPosition; i++)
            {
                newString = newString + input[i];
            }

            newString = newString + addInput;
            for (int i = startPosition; i < input.Length; i++)
            {
                newString = newString + input[i];
            }

            input = newString;
        }

        public void Append(string appendInput)
        {
            string newString = input + appendInput;
            input = newString;
        }

        public void Replace(int startIndex, int Count, string replaceString)
        {
            if (startIndex < 0)
            {
                throw new IndexOutOfRangeException("Enter correct start position.");
            }

            if (Count < 0)
            {
                throw new IndexOutOfRangeException("Count should be a positive number.");
            }

            if (startIndex + Count > input.Length)
            {
                throw new IndexOutOfRangeException("Index out of range.");
            }

            string newString = String.Empty;

            for (int i = 0; i < startIndex; i++)
            {
                newString = newString + input[i];
            }

            newString = newString + replaceString;

            for (int i = startIndex + Count; i < input.Length; i++)
            {
                newString = newString + input[i];
            }

            input = newString;
        }

        public void Delete(int startIndex, int count)
        {
            if (startIndex < 0 || startIndex >= input.Length || startIndex + count >= input.Length)
            {
                throw new IndexOutOfRangeException("Invalid index.");
            }

            if (count < 0)
            {
                throw new IndexOutOfRangeException("Count should be negative number.");
            }

            string newString = String.Empty;
            for (int i = 0; i < startIndex; i++)
            {
                newString = newString + input[i];
            }

            for (int i = startIndex + count; i < input.Length; i++)
            {
                newString = newString + input[i];
            }

            input = newString;
        }

        public void Print()
        {
            Console.WriteLine(input);
        }
    }
}
