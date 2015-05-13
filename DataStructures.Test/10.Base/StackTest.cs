using DataStructures.Implements;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Test._10.Base
{
    [TestClass]
    public class StackTest
    {
        [TestMethod]
        public void Stack_Can_Correct_Foreach()
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(0);
            stack.Push(1);
            stack.Push(2);

            var items = new System.Collections.Generic.List<int>();
            foreach (var item in stack)
            {
                items.Add(item);
            }

            Assert.AreEqual(items.Count, stack.Count);
            Assert.AreEqual(items[0], 2);
            Assert.AreEqual(items[1], 1);
            Assert.AreEqual(items[2], 0);
        }

        [TestMethod]
        public void Stack_Last_In_First_Out()
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(0);
            stack.Push(1);

            int item1 = stack.Pop();
            Assert.AreEqual(item1, 1);

            stack.Push(99);
            int item2 = stack.Pop();
            Assert.AreEqual(item2, 99);

            int item3 = stack.Pop();
            Assert.AreEqual(item3, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Throw_Invalid_Operate_Exception_When_Pop_Empty_Stack()
        {
            Stack<int> stack = new Stack<int>();
            stack.Pop();
        }
    }
}
