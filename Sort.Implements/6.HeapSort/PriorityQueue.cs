using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort.Implements
{
    public sealed class PriorityQueue<T>
    {
        private T[] heap;
        public int Count { get; private set; }

        private Func<T, T, bool> comparer;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="capacity">优先队列的初始容量</param>
        /// <param name="comparer">队列元素的优先级比较器，当第一个元素的优先级高于第二个元素时返回true</param>
        public PriorityQueue(int capacity, Func<T, T, bool> comparer)
        {
            if (capacity < 0)
            {
                throw new InvalidOperationException("优先队列的初始容量必须大于等于0");
            }

            this.heap = new T[capacity];
            this.comparer = comparer;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="comparer">队列元素的优先级比较器，当第一个元素的优先级高于第二个元素时返回true</param>
        public PriorityQueue(Func<T, T, bool> comparer)
            : this(32, comparer)
        {
        }

        public PriorityQueue(T[] array, Func<T, T, bool> comparer)
        {
            this.Count = array.Length;
            this.heap = array;
            this.comparer = comparer;
            AdjustHeap(heap);
        }

        /// <summary>
        /// 获取优先级最高的元素
        /// </summary>
        /// <returns></returns>
        public T Peek()
        {
            ThrowExceptionIfPriorityQueueIsEmpty();

            return heap[0];
        }

        public T Dequeue()
        {
            ThrowExceptionIfPriorityQueueIsEmpty();

            T top = heap[0];
            heap[0] = heap[this.Count - 1];
            heap[this.Count - 1] = default(T);
            this.Count--;
            //保持堆的性质
            HeapifyDown(0);

            return top;
        }

        private void ThrowExceptionIfPriorityQueueIsEmpty()
        {
            if (Count <= 0)
                throw new InvalidOperationException("优先队列为空");
        }

        /// <summary>
        /// 从指定位置向下调整堆，保证堆的性质
        /// </summary>
        /// <param name="current"></param>
        private void HeapifyDown(int current)
        {
            //当前元素的左子元素的索引
            int left = (current + 1) * 2 - 1;
            //当前元素的右子元素的索引
            int right = left + 1;
            int largest;

            if (left < Count && comparer(heap[left], heap[current]))
            {
                largest = left;
            }
            else
            {
                largest = current;
            }

            if (right < Count && comparer(heap[right], heap[largest]))
            {
                largest = right;
            }

            //如果单前值的优先级不为最高，则继续向下调整
            if (largest != current)
            {
                Swap(ref heap[current], ref heap[largest]);
                HeapifyDown(largest);
            }
        }

        public void Enqueue(T key)
        {
            if (Count == heap.Length)
            {
                EnsureCapacity(Count == 0 ? 4 : Count);
            }

            heap[Count++] = key;
            HeapifyUp(Count - 1);
        }

        private void AdjustHeap(T[] array)
        {
            int count = array.Length / 2 - 1;
            for (; count >= 0; count--)
            {
                HeapifyDown(count);
            }
        }

        private void EnsureCapacity(int min)
        {
            int num = min * 2;
            T[] detisnationArray = new T[num];
            Array.Copy(this.heap, detisnationArray, heap.Length);
            heap = detisnationArray;
        }

        private static void Swap(ref T value1, ref T value2)
        {
            T temp = value1;
            value1 = value2;
            value2 = temp;
        }

        /// <summary>
        /// 从指定位置开始向上调整，保证堆的性质
        /// </summary>
        /// <param name="current"></param>
        private void HeapifyUp(int current)
        {
            //当前元素的父元素
            int parent = (current - 1) / 2;
            while (current > 0 && comparer(heap[current], heap[parent]))
            {
                Swap(ref heap[parent], ref heap[current]);
                current = (current - 1) / 2;
                parent = (parent - 1) / 2;
            }
        }
    }

}
