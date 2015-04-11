using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort.Implements
{
	public static class LinearTimeSorter
	{
		/// <summary>
		/// 计数排序,输入序列的元素element必须满足: 0 <= element <= max
		/// </summary>
		/// <param name="array">参与排序的数组</param>
		/// <param name="max">数组的元素可以到达的最大值</param>
		/// <param name="asc">是否顺序排序</param>
		/// <returns>计数排序后的数组</returns>
		public static int[] CountingSort(int[] array, int max, bool asc = true)
		{
			return CountingSort(array, n => n, max, asc);
		}

		/// <summary>
		/// 计数排序,输入序列的元素element必须满足: 0 <= element <= max
		/// </summary>
		/// <param name="array">参与排序的数组</param>
		/// <param name="getCompareValue">根据数组元素获取实际所要计数的值</param>
		/// <param name="max">数组的元素可以到达的最大值</param>
		/// <param name="asc">是否顺序排序</param>
		/// <returns>计数排序后的数组</returns>
		public static int[] CountingSort(int[] array, Func<int, int> getCompareValue, int max, bool asc = true)
		{
			if (array == null || array.Length == 0)
			{
				return new int[0];
			}

			if (max < 0)
			{
				throw new ArgumentOutOfRangeException("max", "max必须大于等于0");
			}

			int[] countingArray = new int[max + 1];
			for (int i = 0; i < array.Length; i++)
			{
				int value = getCompareValue(array[i]);
				if (value < 0 || value > max)
				{
					throw new ArgumentOutOfRangeException("array", "数组元素必须大于等于0并小于等于max");
				}

				countingArray[getCompareValue(array[i])] += 1;
			}

			for (int i = 1; i <= max; i++)
			{
				countingArray[i] += countingArray[i - 1];
			}

			int[] sortedArray = new int[array.Length];

			//这样是为了保持排序的稳定性
			if (asc)
			{
				for (int i = array.Length - 1; i >= 0; i--)
				{
					int value = getCompareValue(array[i]);
					int index = countingArray[value] - 1;
					sortedArray[index] = array[i];
					countingArray[value] -= 1;
				}
			}
			else
			{
				for (int i = 0; i < array.Length; i++)
				{
					int value = getCompareValue(array[i]);
					int index = array.Length - countingArray[value];
					sortedArray[index] = array[i];
					countingArray[value] -= 1;
				}
			}


			return sortedArray;
		}

		/// <summary>
		/// 基数排序
		/// </summary>
		/// <param name="array">排序的数组</param>
		/// <param name="maxPlaces">基数排序所排的最高位</param>
		/// <returns></returns>
		public static int[] RadixSort(int[] array, int maxPlaces, bool asc = true)
		{
			if (maxPlaces <= 0)
			{
				throw new ArgumentOutOfRangeException("maxPlaces", "最高位必须大于0");
			}

			int baseNum = 1;

			for (int i = 0; i < maxPlaces; i++)
			{
				array = CountingSort(array, n => (n / baseNum) % 10, 9, asc);
				baseNum *= 10;
			}

			return array;
		}
	}
}
