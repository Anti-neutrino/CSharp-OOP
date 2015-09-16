using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinkedStack.Test
{
    [TestClass]
    public class LinkedStackTest
    {
        static LinkedStack<int> firstStack;
        static LinkedStack<string> stringStack;
        static LinkedStack<int> secondStack;
        static LinkedStack<int> thirdStack;
        static LinkedStack<DateTime> dateStack;

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            firstStack = new LinkedStack<int>();
            stringStack = new LinkedStack<string>();
            secondStack = new LinkedStack<int>();
            thirdStack = new LinkedStack<int>();
            dateStack = new LinkedStack<DateTime>();
        }

        [TestMethod]
        public void CountIsZero()
        {
            Assert.AreEqual(0, firstStack.Count);
        }

        [TestMethod]
        public void Push_CountIs1()
        {
            firstStack.Push(12);

            Assert.AreEqual(1, firstStack.Count);
        }

        [TestMethod]
        public void Pop_ElementsAreSame()
        {
            int pushElement = firstStack.Peek();
            int popElement = firstStack.Pop();

            Assert.AreEqual(pushElement, popElement);
            Assert.AreEqual(0, firstStack.Count);
        }

        [TestMethod]
        public void Push_CountIs1000()
        {
            for (int i = 0; i < 1000; i++)
            {
                stringStack.Push("CSKA Sofia");
            }

            Assert.AreEqual(1000, stringStack.Count);
        }

        [TestMethod]
        public void Pop_TestElements()
        {
            for (int i = 0; i < 1000; i++)
            {
                stringStack.Pop();
            }

            Assert.AreEqual(0, stringStack.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Pop_EmptyStack()
        {
            secondStack.Pop();
        }

        [TestMethod]
        public void Push_CountIs2()
        {
            secondStack.Push(1488);
            Assert.AreEqual(1, secondStack.Count);

            secondStack.Push(1312);
            Assert.AreEqual(2, secondStack.Count);
        }

        [TestMethod]
        public void Pop_Count1And0()
        {
            secondStack.Pop();
            Assert.AreEqual(1, secondStack.Count);

            secondStack.Pop();
            Assert.AreEqual(0, secondStack.Count);
        }

        [TestMethod]
        public void ToArray_Test()
        {
            thirdStack.Push(1488);
            thirdStack.Push(1914);
            thirdStack.Push(1948);
            thirdStack.Push(1312);

            int[] arr = thirdStack.ToArray();

            for (int i = 0; i < thirdStack.Count; i++)
            {
                Assert.AreEqual(thirdStack.Pop(), arr[i]);
            }
        }

        [TestMethod]
        public void EmptyArray_Test()
        {
            DateTime[] arr = dateStack.ToArray();

            Assert.AreEqual(0, dateStack.Count);
        }
    }
}
