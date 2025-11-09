using System;
using System.Xml.Linq;

namespace Zadanie
{
    public class List<T> 
    {
        private T[] items = new T[0];
        public int Capacity => items.Length;
        public int Count { get; private set; }

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
                if (items[i].Equals(number) == true)
                {
                    for (int j = i; j < Count - 1; j++)
                    {
                        items[j] = items[j + 1];
                    }
                    Count--;
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
                    Extension(newArray);
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
        void Extension(T[] newArray)
        {
            if (Count > 0)
            {
                Array.Copy(items, newArray, Count);
            }
        }

        public void Show()
        {
            for (int i = 0; i < Count; i++)
            {
                Console.Write(items[i] + " ");
            }
            Console.WriteLine();
        }
    }
}