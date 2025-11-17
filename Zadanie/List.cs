using System;
using System.Collections;
using System.Collections.Generic;

namespace Zadanie
{
    public class List<T> : IEnumerable<T>
    {
        private T[] items = new T[0];
        public int Capacity => items.Length;
        public int Count { get; private set; }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                    throw new IndexOutOfRangeException();
                return items[index];
            }
            set
            {
                if (index < 0 || index >= Count)
                    throw new IndexOutOfRangeException();
                items[index] = value;
            }
        }

        public void Add(T number)
        {
            if (Count == Capacity)
            {
                int num = ((items.Length == 0) ? 4 : (items.Length * 2));
                T[] newArray = new T[num];

                if (Count > 0)
                {
                    Array.Copy(items, newArray, Count);
                }
                items = newArray;
            }
            items[Count] = number;
            Count++;
        }

        public void Remove(T number)
        {
            for (int i = 0; i < Count; i++)
            {
                if (items[i] == null ? number == null : items[i].Equals(number))
                {
                    Count--;

                    if (i < Count)
                    {
                        Array.Copy(items, i + 1, items, i, Count - i);
                    }
                    items[Count] = default(T);
                    break;
                }
            }
        }

        public int IndexOf(T element)
        {
            for (int i = 0; i < Count; i++)
            {
                if (items[i].Equals(element) == true)
                    return i;
            }
            return -1;
        }

        public void Insert(int index, T item)
        {
            if (index >= Count)
            {
                if (index >= Capacity)
                {
                    int newCapacity = Capacity;

                    while (index >= newCapacity)
                    {
                        newCapacity *= 2;
                    }
                    T[] newArray = new T[newCapacity];
                    Enlargement(newArray);
                    items = newArray;
                }
                Count = index + 1;
                items[index] = item;
            }
            else
            {
                if (Count == Capacity)
                {
                    int num = ((items.Length == 0) ? 4 : (items.Length * 2));
                    T[] newArray = new T[num];

                    Array.Copy(items, newArray, Count);
                    items = newArray;
                }
                for (int i = Count; i > index; i--)
                {
                    items[i] = items[i - 1];
                }
                items[index] = item;
                Count++;
            }
        }

        public void Enlargement(T[] newArray)
        {
            if (Count > 0)
            {
                Array.Copy(items, newArray, Count);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public static class ListExtension
    {
        public static void Shuffle<T>(this List<T> list)
        {
            Random random = new Random();
            int n = list.Count;

            for (int i = n - 1; i > 0; i--)
            {
                int randomIndex = random.Next(i + 1);

                T temp = list[i];
                list[i] = list[randomIndex];
                list[randomIndex] = temp;
            }
        }
    }
}