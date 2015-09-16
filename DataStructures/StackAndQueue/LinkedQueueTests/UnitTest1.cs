using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinkedQueue.Test
{
    [TestClass]
    public class LinkedQueueTest
    {
        static LinkedQueue<int> firstQueue;
        static LinkedQueue<string> secondQueue;
        static LinkedQueue<int> emptyQueue;
        static LinkedQueue<int> thirdQueue;
        static LinkedQueue<int> toArrayQueue;
        static LinkedQueue<DateTime> dateQueue;

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            firstQueue = new LinkedQueue<int>();
            secondQueue = new LinkedQueue<string>();
            emptyQueue = new LinkedQueue<int>();
            thirdQueue = new LinkedQueue<int>();
            toArrayQueue = new LinkedQueue<int>();
            dateQueue = new LinkedQueue<DateTime>();
        }

        [TestMethod]
        public void IsCountZero()
        {
            Assert.AreEqual(0, firstQueue.Count);
        }

        [TestMethod]
        public void Enqueueu_IsCountOne()
        {
            firstQueue.Enqueue(1948);

            Assert.AreEqual(1, firstQueue.Count);
        }

        [TestMethod]
        public void Dequeue_EnqueueAndDequeueElementsAreTheSame()
        {
            int pushElement = firstQueue.Peek();
            int popElement = firstQueue.Dequeue();

            Assert.AreEqual(pushElement, popElement);
        }

        [TestMethod]
        public void Enqueue_CountIs1000()
        {
            for(int i=0;i<1000;i++)
            {
                secondQueue.Enqueue("CSKA Sofia");
            }

            Assert.AreEqual(1000, secondQueue.Count);
        }

        [TestMethod]
        public void Dequeue_CountIsZero()
        {
            for(int i=0;i<1000;i++)
            {
                secondQueue.Dequeue();
            }

            Assert.AreEqual(0, secondQueue.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DequeueElementsFromEmptyQueue()
        {
            emptyQueue.Dequeue();
        }

        [TestMethod]
        public void Enqueue_2Elements()
        {
            thirdQueue.Enqueue(12);
            thirdQueue.Enqueue(123);

            Assert.AreEqual(2, thirdQueue.Count);
        }

        [TestMethod]
        public void Dequeue_ZeroElements()
        {
            thirdQueue.Dequeue();
            thirdQueue.Dequeue();

            Assert.AreEqual(0, thirdQueue.Count);
        }

        [TestMethod]
        public void ToArray()
        {
            toArrayQueue.Enqueue(12231);
            toArrayQueue.Enqueue(32);
            toArrayQueue.Enqueue(54);
            toArrayQueue.Enqueue(51);

            int[] arr = toArrayQueue.ToArray();

            for(int i=0;i<toArrayQueue.Count;i++)
            {
                Assert.AreEqual(arr[i], toArrayQueue.Dequeue());
            }           
        }

        [TestMethod]
        public void EmptyArray()
        {
            DateTime[] arr = dateQueue.ToArray();

            Assert.AreEqual(0, dateQueue.Count);
        }
    }
}
