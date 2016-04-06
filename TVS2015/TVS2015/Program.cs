using System;

namespace TVS2015
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string str = "<cFF0000>干死策划</c>";
            Console.WriteLine(str);

            if (str.Contains("</c>"))
            {
                str = str.Substring(9, str.Length - 13);
            }
            Console.WriteLine(str);
        }
    }
}