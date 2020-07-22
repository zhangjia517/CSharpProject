using System;
using System.Text;

namespace ConsoleApplication
{
    internal class Program
    {
        #region 全局变量

        public static int s_Variable = 0;

        #endregion 全局变量

        #region 公共成员变量

        public int m_Variable = 0;

        #endregion 公共成员变量

        #region 属性

        public int Variable
        {
            get
            {
                return m_variable;
            }

            set
            {
                m_variable = value;
            }
        }

        #endregion 属性

        #region 私有成员变量

        private int m_variable = 0;

        #endregion 私有成员变量

        private static void Main(string[] args)
        {
            var phrase = "lalala";
            var manyPhrases = new StringBuilder();
            for (var i = 0; i < 10; i++)
            {
                manyPhrases.Append(phrase);
            }

            string str = manyPhrases.ToString();
            Console.WriteLine(str);
        }
    }
}