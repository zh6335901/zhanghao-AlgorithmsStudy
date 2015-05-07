using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Implements
{
    public class Stack<T> : IEnumerable<T>
    {
        private T[] array;
        private int count;
        private const int defaultCapacity = 4;

        public int Count
        {
            get
            {
                return count;
            }
        }

        public Stack()
        {
            array = new T[defaultCapacity];
        }

        public Stack(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException("栈的初始容量必须大于等于0");
            }

            array = new T[capacity];
        }

        public void Push(T item)
        {
            if (array.Length == count)
            {
                var newArray = new T[count == 0 ? defaultCapacity : count * 2];
                Array.Copy(array, newArray, array.Length);
                array = newArray;
            }

            array[count++] = item;
        }

        public T Pop()
        {
            if (count == 0)
            {
                throw new InvalidOperationException("当前栈为空");
            }

            T item = array[--count];
            array[count] = default(T);
            return item;
        }

        public T Peek()
        {
            if (count == 0)
            {
                throw new InvalidOperationException("当前栈为空");
            }

            return array[count - 1];
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
            private Stack<T> stack;
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

            internal Enumerator(Stack<T> stack)
            {
                this.stack = stack;
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
                    index = stack.count - 1;
                    hasElement = index >= 0;
                    if (hasElement)
                    {
                        currentItem = stack.array[index];
                    }

                    return hasElement;
                }

                if (index == -1)
                {
                    return false;
                }

                hasElement = (--index) >= 0;
                if (hasElement)
                {
                    currentItem = stack.array[index];
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
