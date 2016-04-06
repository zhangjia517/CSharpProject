using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBubbleSort
{
    class Program
    {
        static int[] array = new int[] { 5, 2, 2, 4, 5, 7, 8 };

        static void Main(string[] args)
        {
            BubbleSort();
            foreach (int i in array)
            {
                Console.WriteLine(i);
            }
            Console.ReadKey();
        }

        public static void BubbleSort()
        {
            int temp = 0;
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[i])
                    {
                        temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }
        }
    }
}
