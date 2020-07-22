using System;

namespace TCommon.DataStructure
{
    public class TFoo
    {
        public static void Execute()
        {
            Console.WriteLine(Foo1(10));
            Console.WriteLine(Foo2(100));
        }

        /// <summary>
        /// 1、1、2、3、5、8、13、21、34
        /// </summary>
        /// <param name="i">位</param>
        /// <returns></returns>
        private static int Foo1(int i)
        {
            if (i <= 0)
            {
                return 0;
            }
            else if (i > 0 && i <= 2)
            {
                return 1;
            }
            else
            {
                return Foo1(i - 1) + Foo1(i - 2);
            }
        }

        /// <summary>
        /// 1、2、3、4、5、6、7、8
        /// </summary>
        /// <param name="i">位</param>
        /// <returns></returns>
        private static int Foo2(int i)
        {
            if (i == 1) return 1;
            return i + Foo2(i - 1);
        }
    }
}