using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArrayStack
{
    [TestClass]
    public class ArrayStackTests
    {
        static ArrayStack<int> stack;
        static ArrayStack<string> stringStack;
        static ArrayStack<int> firstStack;
        static ArrayStack<int> secondStack;
        static ArrayStack<DateTime> dateStack;

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            stack = new ArrayStack<int>();
            stringStack = new ArrayStack<string>();
            firstStack = new ArrayStack<int>();
            secondStack = new ArrayStack<int>();
            dateStack = new ArrayStack<DateTime>();
        }

        [TestMethod]
        public void Push_ElementsInStackIs0()
        {
            Assert.AreEqual(0, stack.Count);
        }

        [TestMethod]
        public void Push_ElementsInStackIs1()
        {
            stack.Push(23);

            Assert.AreEqual(1, stack.Count);
        }

        [TestMethod]
        public void Pop_PushAndPopElementIsTheSame()
        {
            int pushNumber = stack.Peek();
            int popNumber = stack.Pop();

            Assert.AreEqual(pushNumber,popNumber);
            Assert.AreEqual(0, stack.Count);
        }

        [TestMethod]
        public void Push_CountIs1000()
        {
            for(int i=0;i<1000;i++)
            {
                stringStack.Push("CSKA Sofia");
            }

            Assert.AreEqual(1000,stringStack.Count);
        }

        [TestMethod]
        public void Pop_CountIs0()
        {
            for(int i=0;i<1000;i++)
            {
                stringStack.Pop();
            }

            Assert.AreEqual(0, stringStack.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Pop_EmptyStack()
        {
            ArrayStack<int> arr = new ArrayStack<int>();

            arr.Pop();
        }

        [TestMethod]
        public void Push_TwoElements()
        {
            firstStack.Push(12);
            Assert.AreEqual(1, firstStack.Count);

            firstStack.Push(32);
            Assert.AreEqual(2, firstStack.Count);
        }

        [TestMethod]
        public void Pop_AssertIsCorrect()
        {
            firstStack.Pop();
            Assert.AreEqual(1,firstStack.Count);

            firstStack.Pop();
            Assert.AreEqual(0, firstStack.Count);
        }

        [TestMethod]
        public void ToArray_Test()
        {
            secondStack.Push(3);
            secondStack.Push(-2);
            secondStack.Push(5);
            secondStack.Push(7);

            int[] numbers = secondStack.ToArray();

            for(int i=0;i<secondStack.Count;i++)
            {
                Assert.AreEqual(secondStack.Pop(), numbers[i]);
            }
        }

        [TestMethod]
        public void EmptyStack()
        {
            DateTime[] arr = dateStack.ToArray();

            Assert.AreEqual(0, dateStack.Count);
        }
    }
}
