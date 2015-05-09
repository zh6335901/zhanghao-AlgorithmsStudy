using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Implements._10.Base
{
    public class Queue<T> : IEnumerable<T>
    {
        private T[] array;
        private int count;
        private const int defaultCapacity = 4;
        private int startPos;
        private int endPos;

        public int Count
        {
            get
            {
                return count;
            }
        }

        public Queue()
        {
            array = new T[defaultCapacity];
        }

        public Queue(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException("队列的初始容量必须大于等于0");
            }

            array = new T[capacity];
        }

        public void Enqueue(T item)
        {
            if (array.Length == count)
            {
                var newArray = new T[count == 0 ? defaultCapacity : count * 2];
                if (startPos >= endPos)
                {
                    Array.Copy(array, startPos, newArray, 0, count - startPos);
                    Array.Copy(array, 0, newArray, count - startPos, endPos);
                }
                else
                {
                    Array.Copy(array, startPos, newArray, 0, count);
                }
                
                array = newArray;
                startPos = 0;
                endPos = count;
            }

            count++;
            array[(startPos + count) % array.Length] = item;
            endPos = ((startPos + count) % array.Length) + 1;
        }

        public T Dequeue()
        {
            if (count == 0)
            {
                throw new InvalidOperationException("当前队列为空");
            }

            T item = array[startPos];
            array[startPos] = default(T);
            count--;
            startPos = (startPos + 1) % array.Length;
            return item;
        }

        public T Peek()
        {
            if (count == 0)
            {
                throw new InvalidOperationException("当前队列为空");
            }

            return array[startPos];
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new Enumerator(this);
        }

        public struct Enumerator : IEnumerator<T>, IEnumerator
        {
            private Queue<T> queue;
            private int index;
            private T currentItem;

            public T Current
            {
                get
                {
                    if (index == -2)
                    {
                        throw new InvalidOperationException("迭代未开始");
                    }

                    if (index == -1)
                    {
                        throw new InvalidOperationException("迭代已结束");
                    }

                    return currentItem;
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    return Current;
                }
            }

            internal Enumerator(Queue<T> queue)
            {
                this.queue = queue;
                index = -2;
                currentItem = default(T);
            }

            public void Dispose()
            {
                index = -1;
            }

            public bool MoveNext()
            {
                bool hasElement;

                //首次调用
                if (index == -2)
                {
                    index = queue.startPos;
                    hasElement = queue.Count > 0;
                    if (hasElement)
                    {
                        currentItem = queue.array[index];
                    }

                    return hasElement;
                }

                if (index == queue.endPos)
                {
                    return false;
                }

                index = (index + 1) % queue.array.Length;
                hasElement = index != queue.endPos;
                if (hasElement)
                {
                    currentItem = queue.array[index];
                }
                else
                {
                    currentItem = default(T);
                }

                return hasElement;
            }

            public void Reset()
            {
                index = -2;
                currentItem = default(T);
            }
        }
    }
}
