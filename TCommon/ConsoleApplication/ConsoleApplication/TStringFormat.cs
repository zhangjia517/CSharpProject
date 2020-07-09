using System;

namespace ConsoleApplication
{
    internal static class TStringFormat
    {
        public static void DoIt()
        {
            var reason = "%s与%s等预算科目的内容存在重复，核减%d万元";
            var results1 = "本科目镍铁中多元素样品前处理";
            var results2 = "本科目ICP测定法";
            var resultd = "2.50";

            //reason = ReplaceFirst(reason, "%s", results1);
            //reason = ReplaceFirst(reason, "%s", results2);
            //reason = ReplaceFirst(reason, "%d", resultd);

            var final = reason.ReplaceFirstThis("%s", results1).ReplaceFirstThis("%s", results2).ReplaceFirstThis("%d", resultd);

            Console.Write(final);
            Console.ReadKey();
        }

        private static string ReplaceFirst(string text, string search, string replace)
        {
            int pos = text.IndexOf(search);
            if (pos < 0)
            {
                return text;
            }
            return $"{text.Substring(0, pos)}{replace}{text.Substring(pos + search.Length)}";
        }

        public static string ReplaceFirstThis(this string text, string search, string replace)
        {
            int pos = text.IndexOf(search);
            if (pos < 0)
            {
                return text;
            }
            return $"{text.Substring(0, pos)}{replace}{text.Substring(pos + search.Length)}";
        }
    }
}