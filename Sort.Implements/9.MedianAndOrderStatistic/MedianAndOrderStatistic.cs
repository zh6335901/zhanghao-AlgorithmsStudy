using System;

namespace Sort.Implements
{
    public static class MedianAndOrderStatistic
    {
        /// <summary>
        /// 获取最值(最大值或最小值)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <param name="selector"></param>
        /// <returns></returns>
        public static T GetMostValue<T>(T[] array, Func<T, T, bool> comparer)
        {
            if (array == null || array.Length == 0)
            {
                throw new InvalidOperationException("数组不能为空且长度大于0");
            }

            T mostValue = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (comparer(array[i], mostValue))
                {
                    mostValue = array[i];
                }
            }

            return mostValue;
        }

        public static T GetSpecifiedPositionValue<T>(T[] array, int position, Func<T, T, bool> comparer)
        {
            return GetSpecifiedPositionValue(array, 0, array.Length - 1, position, comparer);    
        }

        private static T GetSpecifiedPositionValue<T>(T[] array, int start, int end, int position, Func<T, T, bool> comparer)
        {
            if (array == null || array.Length == 0)
            {
                throw new InvalidOperationException("数组不能为空且长度大于0");
            }

            if (start == end)
            {
                return array[start];
            }

            int pivot = QuickSorter.Partition(array, start, end, comparer);
            int relativePosition = pivot - start;
            if (relativePosition == position)
            {
                return array[pivot];
            }
            else if (relativePosition > position)
            {
                return GetSpecifiedPositionValue(array, start, pivot - 1, relativePosition, comparer);
            }
            else
            {
                return GetSpecifiedPositionValue(array, pivot + 1, end, relativePosition - pivot - 1, comparer);
            }
        }
    }
}
