using LitJson;
using System;

namespace ConsoleApplication
{
    public class Video
    {
        public string URL { get; set; }
    }

    internal class TJson
    {
        public static void ToJ()
        {
            string str1 = "{\"test.mp4\":{\"url\":\"test.mp4\",\"talk\":\"是否要进行选择\",\"select\":2,\"list\":{\"test0.mp4\":{\"url\":\"test0.mp4\",\"talk\":\"选择A\",\"select\":1,\"list\":{\"test00.mp4\":{\"select\":0}}},\"test1.mp4\":{\"url\":\"test1.mp4\",\"talk\":\"选择B\",\"select\":1,\"list\":{\"test10.mp4\":{\"select\":0}}}}}}";

            JsonData jsonData2 = JsonMapper.ToObject(str1);

            Console.WriteLine(jsonData2["test.mp4"]["list"]["test0.mp4"]["talk"]);
            JsonData jsonData3 = (jsonData2["test.mp4"]);

            JsonData pa = JsonMapper.ToObject(JsonMapper.ToJson(jsonData3));
            Console.WriteLine(jsonData3["url"]);
            Console.WriteLine(pa["url"]);
        }
    }
}