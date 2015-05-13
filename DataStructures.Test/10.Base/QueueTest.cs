using DataStructures.Implements;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Test._10.Base
{
    [TestClass]
    public class QueueTest
    {
        [TestMethod]
        public void Queue_Can_Correct_Foreach()
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(0);
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(2);
            queue.Enqueue(3);

            var items = new System.Collections.Generic.List<int>();
            foreach (var item in queue)
            {
                items.Add(item);
            }

            Assert.AreEqual(items.Count, queue.Count);
            Assert.AreEqual(items[0], 0);
            Assert.AreEqual(items[1], 1);
            Assert.AreEqual(items[2], 2);
            Assert.AreEqual(items[3], 2);
            Assert.AreEqual(items[4], 3);
        }

        [TestMethod]
        public void Queue_First_In_First_Out()
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(0);
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(2);
            queue.Enqueue(3);

            int item1 = queue.Dequeue();
            int item2 = queue.Dequeue();

            Assert.AreEqual(item1, 0);
            Assert.AreEqual(item2, 1);

            queue.Enqueue(99);
            queue.Enqueue(100);

            int item3 = queue.Dequeue();
            int item4 = queue.Dequeue();
            int item5 = queue.Dequeue();
            int item6 = queue.Dequeue();
            int item7 = queue.Dequeue();

            Assert.AreEqual(item3, 2);
            Assert.AreEqual(item4, 2);
            Assert.AreEqual(item5, 3);
            Assert.AreEqual(item6, 99);
            Assert.AreEqual(item7, 100);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Throw_Invalid_Operate_Exception_When_Dequeue_Empty_Queue()
        {
            Queue<int> queue = new Queue<int>();
            queue.Dequeue();
        }
    }
}
