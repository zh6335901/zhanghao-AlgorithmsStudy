using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sort.Implements._8.LinearTimeSort;

namespace Sort.Test._8.LinearTimeSort
{
    [TestClass]
    public class LinearTimeSortTest
    {
        [TestMethod]
        public void Counting_Sort_Array_More_Than_One_Element_ASC()
        {
            int[] array = new int[] { 6, 8, 1, 22, 5 };
            int[] sortedArray = LinearTimeSorter.CountingSort(array, 25);

            Assert.AreEqual(1, sortedArray[0]);
            Assert.AreEqual(5, sortedArray[1]);
            Assert.AreEqual(6, sortedArray[2]);
            Assert.AreEqual(8, sortedArray[3]);
            Assert.AreEqual(22, sortedArray[4]);
        }

        [TestMethod]
        public void Counting_Sort_Array_More_Than_One_Element_DESC()
        {
            int[] array = new int[] { 6, 8, 1, 22, 5 };
            int[] sortedArray = LinearTimeSorter.CountingSort(array, 25, false);

            Assert.AreEqual(22, sortedArray[0]);
            Assert.AreEqual(8, sortedArray[1]);
            Assert.AreEqual(6, sortedArray[2]);
            Assert.AreEqual(5, sortedArray[3]);
            Assert.AreEqual(1, sortedArray[4]);
        }
    }
}
