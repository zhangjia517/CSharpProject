using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    public class BitOperation
    {
        public static void TDebug()
        {
            //int i = 1 << 2;
            //Console.WriteLine(i);
            //i = 1 << 4;
            //Console.WriteLine(i);


            int value = 4;
            bool b = (value & 4) != 0;
            Console.WriteLine(b);

            Console.ReadKey();
        }
    }
}
