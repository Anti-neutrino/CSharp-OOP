using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseRefactory
{
    class DumpClass
    {
        class Output
        {
            public void OutputSomeString(bool isWord)
            {
                string someWord = isWord.ToString();
                Console.WriteLine(someWord);
            }
        }

        public static void Input()
        {
            DumpClass.Output element = new DumpClass.Output();
            element.OutputSomeString(true);
        }
    }
}
