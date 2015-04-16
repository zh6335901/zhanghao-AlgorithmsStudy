using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort.Implements
{
    public static class QuickSorter
    {
        public static void Sort<T>(T[] array, Func<T, T, bool> comparer)
        {
            Sort(array, 0, array.Length - 1, comparer);
        }

        private static void Sort<T>(T[] array, int start, int end, Func<T, T, bool> comparer)
        {
            if (array == null)
            {
                return;
            }

            if (start < end)
            {
                int baseIndex = Partition(array, start, end, comparer);
                Sort(array, start, baseIndex - 1, comparer);
                Sort(array, baseIndex + 1, end, comparer);
            }

            //while (start < end)
            //{
            //    int baseIndex = Partition(array, start, end, comparer);
            //    Sort(array, start, baseIndex - 1, comparer);
            //    start = baseIndex + 1;
            //}
        }

        internal static int Partition<T>(T[] array, int start, int end, Func<T, T, bool> comparer)
        {
            //随机选取划分序列的基准值
            Random random = new Random(Guid.NewGuid().GetHashCode());
            var randomNumber = random.Next(start, end);

            Swap(ref array[randomNumber], ref array[end]);
            T baseValue = array[end];
            int baseIndex = start;

            for (int i = start; i < end; i++)
            {
                if (comparer(array[i], baseValue))
                {
                    Swap(ref array[baseIndex], ref array[i]);
                    baseIndex++;
                }
            }

            Swap(ref array[end], ref array[baseIndex]);

            return baseIndex;
        }

        private static void Swap<T>(ref T value1, ref T value2)
        {
            T temp = value1;
            value1 = value2;
            value2 = temp;
        }
    }
}
