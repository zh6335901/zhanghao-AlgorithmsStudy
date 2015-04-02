using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort.Implements._8.LinearTimeSort
{
    public static class LinearTimeSorter
    {
        /// <summary>
        /// 计数排序,输入序列的元素element必须满足: 0 <= element <= max
        /// </summary>
        /// <param name="array">参与排序的数组</param>
        /// <param name="max">数组的元素可以到达的最大值</param>
        /// <returns></returns>
        public static int[] CountingSort(int[] array, int max, bool asc = true)
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
                if (array[i] < 0 || array[i] > max)
                {
                    throw new ArgumentOutOfRangeException("array", "数组元素必须大于等于0并小于等于max");
                }

                countingArray[array[i]] += 1;
            }

            for (int i = 1; i <= max; i++)
            {
                countingArray[i] += countingArray[i - 1];
            }

            int[] sortedArray = new int[array.Length];
            //倒序是为了确保计数排序的稳定性
            for (int i = array.Length - 1; i >= 0; i--)
            {
                int index = asc ? countingArray[array[i]] - 1 : sortedArray.Length - countingArray[array[i]];
                sortedArray[index] = array[i];
                countingArray[array[i]] -= 1;
            }

            return sortedArray;
        }


    }
}
