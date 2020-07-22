namespace TCommon
{
    internal class TOutMax
    {
        public static void MaxandMin(int[] a, out int max, out int max2)
        {
            if (a[0] > a[1])
            {
                max = a[0];
                max2 = a[1];
            }
            else
            {
                max = a[1];
                max2 = a[0];
            }

            for (int i = 2; i < a.Length; i++)
            {
                if (a[i] > max)
                {
                    max2 = max;
                    max = a[i];
                }
                else if (a[i] > max2)
                {
                    max2 = a[i];
                }
            }
        }

        public static void OutInt(int i)
        {
            i = 5;
        }
    }
}