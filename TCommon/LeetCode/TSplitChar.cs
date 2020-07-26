using System;
using System.Collections.Generic;

namespace TCommon.LeetCode
{
    public class TSplitChar
    {
        public static void Execute()
        {
            List<string> strList = new List<string>();
            strList = SplitChar("a:bb:ccc", ':');
            for (int i = 0; i < strList.Count; i++)
            {
                Console.WriteLine(strList[i]);
            }
        }

        private static List<string> SplitChar(string str1, char c1)
        {
            List<string> strList = new List<string>();
            string tempStr = "";
            for (int i = 0; i < str1.Length; i++)
            {
                if (str1[i] == c1)
                {
                    strList.Add(tempStr);
                    tempStr = "";
                }
                else
                {
                    tempStr += str1[i];
                }
            }
            strList.Add(tempStr);
            return strList;
        }
    }
}