using System;

namespace TCommon.DataStructure
{
    public class TBubbleSort
    {
        private static int[] array = new int[] { 5, 2, 2, 4, 5, 7, 8 };

        public static void Execute()
        {
            BubbleSort();
        }

        private static void BubbleSort()
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[i])
                    {
                        int temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }

            foreach (int i in array)
            {
                Console.WriteLine(i);
            }
        }
    }
}