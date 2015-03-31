using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sort.Implements;

namespace Sort.Test._7.QucikSort
{
    [TestClass]
    public class QucikSortTest
    {
        [TestMethod]
        public void Quick_Sort_Array_More_Than_One_Element_ASC()
        {
            int[] array = new int[] { 4, 2, 1, 5, 3 };
            QuickSorter.Sort(array, (a, b) => { return a < b; });

            Assert.AreEqual(1, array[0]);
            Assert.AreEqual(3, array[2]);
            Assert.AreEqual(5, array[4]);
        }

        [TestMethod]
        public void Quick_Sort_Array_More_Than_One_Element_DESC()
        {
            int[] array = new int[] { 4, 2, 1, 5, 3 };
            QuickSorter.Sort(array, (a, b) => { return a > b; });

            Assert.AreEqual(5, array[0]);
            Assert.AreEqual(4, array[1]);
            Assert.AreEqual(1, array[4]);
        }

        [TestMethod]
        public void Quick_Sort_Array_Only_One_Element()
        {
            int[] array = new int[] { 4 };
            QuickSorter.Sort(array, (a, b) => { return a < b; });

            Assert.AreEqual(1, array.Length);
            Assert.AreEqual(4, array[0]);
        }
    }
}
