using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sort.Implements;

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

		[TestMethod]
		public void Radix_Sort_Array_More_Than_One_Element_ASC()
		{
			int[] array = new int[] { 611, 833, 129, 645, 521 };
			int[] sortedArray = LinearTimeSorter.RadixSort(array, 3);

			Assert.AreEqual(129, sortedArray[0]);
			Assert.AreEqual(521, sortedArray[1]);
			Assert.AreEqual(611, sortedArray[2]);
			Assert.AreEqual(645, sortedArray[3]);
			Assert.AreEqual(833, sortedArray[4]);
		}

		[TestMethod]
		public void Radix_Sort_Array_More_Than_One_Element_DESC()
		{
			int[] array = new int[] { 611, 833, 129, 645, 521 };
			int[] sortedArray = LinearTimeSorter.RadixSort(array, 3, false);

			Assert.AreEqual(129, sortedArray[4]);
			Assert.AreEqual(521, sortedArray[3]);
			Assert.AreEqual(611, sortedArray[2]);
			Assert.AreEqual(645, sortedArray[1]);
			Assert.AreEqual(833, sortedArray[0]);
		}

		[TestMethod]
		public void Radix_Sort_Place_Less_Than_Element_Place()
		{
			int[] array = new int[] { 199, 931, 256, 412 };
			int[] sortedArray = LinearTimeSorter.RadixSort(array, 2);

			Assert.AreEqual(412, sortedArray[0]);
			Assert.AreEqual(931, sortedArray[1]);
			Assert.AreEqual(256, sortedArray[2]);
			Assert.AreEqual(199, sortedArray[3]);
		}

		[TestMethod]
		public void Radix_Sort_Place_More_Than_Element_Max_Place()
		{
			int[] array = new int[] { 611, 833, 49, 645, 81 };
			int[] sortedArray = LinearTimeSorter.RadixSort(array, 5);

			Assert.AreEqual(49, sortedArray[0]);
			Assert.AreEqual(81, sortedArray[1]);
			Assert.AreEqual(611, sortedArray[2]);
			Assert.AreEqual(645, sortedArray[3]);
			Assert.AreEqual(833, sortedArray[4]);
		}
	}
}
