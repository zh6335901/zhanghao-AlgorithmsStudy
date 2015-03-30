using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort.Implements
{
    public static class HeapSorter
    {
        public static T[] Sort<T>(T[] array, Func<T, T, bool> comparer)
        {
            if (array == null || array.Length <= 1)
            {
                return array;
            }

            var priorityQueue = new PriorityQueue<T>(array, comparer);
            T[] sortedArray = new T[array.Length];

            sortedArray[0] = priorityQueue.Dequeue();

            for (int i = 1; i <= sortedArray.Length - 2; i++)
            {
                sortedArray[i] = priorityQueue.Dequeue();
            }

            sortedArray[sortedArray.Length - 1] = priorityQueue.Dequeue();
            return sortedArray;
        } 
    }
}
