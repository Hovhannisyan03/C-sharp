using System;
using System.Collections.Generic;


namespace MyStructure
{
    class MyQueue<T>
    {
        private readonly T[] m_arr;
        private int m_front;
        private int m_rear;
        private int m_size;
        private readonly int m_capacity;

        public MyQueue(int capacity)
        {
            m_capacity = capacity;
            m_arr = new T[m_capacity];
            m_front = 0;
            m_size = 0;
            m_rear = 0;
        }

        public MyQueue(MyQueue<T> other)
        {
            m_capacity = other.m_capacity;
            m_arr = new T[m_capacity];
            Array.Copy(other.m_arr, m_arr, m_capacity);
            m_front = other.m_front;
            m_rear = other.m_rear;
            m_size = other.m_size;
        }

        public MyQueue(IEnumerable<T> range, int capacity = 100)
        {
            m_capacity = capacity;
            m_arr = new T[m_capacity];
            m_front = 0;
            m_rear = 0;
            m_size = 0;

            foreach (var val in range)
            {
                Enqueue(val);
            }
        }

        public void Print()
        {
            if (Empty())
            {
                Console.WriteLine("Queue is empty.");
                return;
            }

            int count = m_size;
            int index = m_front;
            while (count-- > 0)
            {
                Console.Write(m_arr[index] + " ");
                index = (index + 1) % m_capacity;
            }
            Console.WriteLine();
        }

        public T Front()
        {
            if (Empty())
            {
                throw new InvalidOperationException("Queue is empty.");
            }
            return m_arr[m_front];
        }

        public bool Empty()
        {
            return m_size == 0;
        }

        public int Size()
        {
            return m_size;
        }

        public void Enqueue(T val)
        {
            if (m_size == m_capacity)
            {
                throw new InvalidOperationException("Queue is full.");
            }

            m_arr[m_rear] = val;
            m_rear = (m_rear + 1) % m_capacity;
            ++m_size;
        }

        public void Dequeue()
        {
            if (Empty())
            {
                throw new InvalidOperationException("Queue is empty.");
            }

            m_front = (m_front + 1) % m_capacity;
            --m_size;   
        }

        public static bool operator ==(MyQueue<T>? a, MyQueue<T>? b)
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
                var aIndex = (a.m_front + i) % a.m_capacity;
                var bIndex = (b.m_front + i) % b.m_capacity;
                if (!EqualityComparer<T>.Default.Equals(a.m_arr[aIndex], b.m_arr[bIndex]))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool operator !=(MyQueue<T>? a, MyQueue<T>? b) => !(a == b);

        public static bool operator <(MyQueue<T> a, MyQueue<T> b)
        {
            int minSize = Math.Min(a.m_size, b.m_size);
            for (int i = 0; i < minSize; i++)
            {
                var aIndex = (a.m_front + i) % a.m_capacity;
                var bIndex = (b.m_front + i) % b.m_capacity;
                int cmp = Comparer<T>.Default.Compare(a.m_arr[aIndex], b.m_arr[bIndex]);
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
        public static bool operator >(MyQueue<T> a, MyQueue<T> b) => b < a;

        public static bool operator <=(MyQueue<T> a, MyQueue<T> b) => !(a > b);

        public static bool operator >=(MyQueue<T> a, MyQueue<T> b) => !(a < b);

        public override bool Equals(object? obj) => this == obj as MyQueue<T>;

        public override int GetHashCode()
        {
            int hash = 17;
            int count = m_size;
            int index = m_front;
            while (count-- > 0)
            {
                hash = hash * 31 + (m_arr[index] == null ? 0 : m_arr[index]!.GetHashCode());
                index = (index + 1) % m_capacity;
            }
            return hash;
        }
    }

}