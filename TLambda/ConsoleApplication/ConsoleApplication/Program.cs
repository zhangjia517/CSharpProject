using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            List<int> m_list = new List<int> { 1, 2, 3, 4, 5 };

            Console.WriteLine(m_list.FirstOrDefault(p => p == 10 / 2));
            Console.ReadKey();
        }
    }
}