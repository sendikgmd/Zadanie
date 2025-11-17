using System;

namespace Zadanie
{
    internal partial class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();

            list.Add(9);
            list.Add(2);
            list.Add(1);
            list.Add(4);
            list.Add(1);
            list.Extension();
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }    
            Console.WriteLine(list.Capacity);

            Console.WriteLine("----------------------------------");

            System.Collections.Generic.List<int> listOriginal = new System.Collections.Generic.List<int>();

            listOriginal.Add(1);

            foreach(int i in listOriginal)
            {
                Console.WriteLine(i);
            }
        }
    }
}
