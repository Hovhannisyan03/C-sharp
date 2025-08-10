using System;
using System.Collections.Generic;

namespace MyStructure
{
    class MyStack<T>
    {

        private List<T> m_arr;
        private int m_size;
        private readonly int _capacity;

        public MyStack(int capacity = 100)
        {
            m_arr = new List<T>();
            m_size = 0;
            _capacity = capacity;

        }

        public MyStack(MyStack<T> other)
        {
            m_arr = new List<T>(other.m_arr);
            m_size = other.m_size;
            _capacity = other._capacity;
        }

        public MyStack(IEnumerable<T> range, int capacity = 100)
        {
            _capacity = capacity;
            m_arr = new List<T>(_capacity);
            foreach (var item in range)
            {
                if (m_size >= _capacity)
                {
                    throw new InvalidOperationException("MyStack capacity exceeded.");
                }
                m_arr.Add(item);
                m_size++;
            }
        }

        public T Top()
        {
            if (Empty())
            {
                throw new InvalidOperationException("MyStack is empty.");
            }
            return m_arr[m_size - 1];
        }

        public bool Empty()
        {
            return m_size == 0;
        }

        public int Size()
        {
            return m_size;
        }

        public void Push(T value)
        {
            if (m_size >= _capacity)
            {
                throw new InvalidOperationException("MyStack capacity exceeded.");
            }
            m_arr.Add(value);
            ++m_size;
        }

        public void PushRange(params T[] values)
        {
            foreach (var value in values)
            {
                Push(value);
            }
        }

        public void Pop()
        {
            if (Empty())
            {
                throw new InvalidOperationException("MyStack is empty.");
            }
            m_arr.RemoveAt(m_size - 1);
            m_size--;
        }

        public static bool operator ==(MyStack<T>? a, MyStack<T>? b)
        {
            if (ReferenceEquals(a, b))
            {
                return true;
            }
            if (a is null || b is null)
            {
                return false;
            }
            if (a.m_size != b.m_size)
            {
                return false;
            }

            for (int i = 0; i < a.m_size; i++)
            {
                if (!EqualityComparer<T>.Default.Equals(a.m_arr[i], b.m_arr[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool operator !=(MyStack<T> a, MyStack<T> b)
        {
            return !(a == b);
        }

        public static bool operator <(MyStack<T> a, MyStack<T> b)
        {
            int minSize = Math.Min(a.m_size, b.m_size);
            for (int i = 0; i < minSize; i++)
            {
                int cmp = Comparer<T>.Default.Compare(a.m_arr[i], b.m_arr[i]);
                if (cmp < 0)
                {
                    return true;
                }
                if (cmp > 0)
                {
                    return false;
                }
            }
            return a.m_size < b.m_size;
        }

        public static bool operator >(MyStack<T> a, MyStack<T> b)
        {
            return b < a;
        }

        public static bool operator <=(MyStack<T> a, MyStack<T> b)
        {
            return !(a > b);
        }

        public static bool operator >=(MyStack<T> a, MyStack<T> b)
        {
            return !(a < b);
        }
        
        public override bool Equals(object? obj)
        {
            return this == obj as MyStack<T>;
        }

        public override int GetHashCode()
        {
            int hash = 17;
            foreach (var item in m_arr)
            {
                hash = hash * 31 + (item == null ? 0 : item.GetHashCode());
            }
            return hash;
        }
        
    }
};