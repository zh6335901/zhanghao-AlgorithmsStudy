using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sort.Implements;

namespace Sort.Test._6.HeapSort
{
    [TestClass]
    public class HeapSortTest
    {
        [TestMethod]
        public void Heap_Sort_Array_More_Than_One_Element_ASC()
        {
            int[] array = new int[] { 4, 2, 1, 5, 3 };
            int[] sortedArray = HeapSorter.Sort(array, (a, b) => { return a < b; });

            Assert.AreEqual(1, sortedArray[0]);
            Assert.AreEqual(3, sortedArray[2]);
            Assert.AreEqual(5, sortedArray[4]);
        }

        [TestMethod]
        public void Heap_Sort_Array_More_Than_One_Element_DESC()
        {
            int[] array = new int[] { 4, 2, 1, 5, 3 };
            int[] sortedArray = HeapSorter.Sort(array, (a, b) => { return a > b; });

            Assert.AreEqual(5, sortedArray[0]);
            Assert.AreEqual(3, sortedArray[2]);
            Assert.AreEqual(1, sortedArray[4]);
        }

        [TestMethod]
        public void Heap_Sort_Array_Only_One_Element()
        {
            int[] array = new int[] { 4 };
            int[] sortedArray = HeapSorter.Sort(array, (a, b) => { return a < b; });

            Assert.AreEqual(1, sortedArray.Length);
            Assert.AreEqual(4, sortedArray[0]);
        }
    }
}
