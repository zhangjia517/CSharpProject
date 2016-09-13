using LitJson;
using System;
using System.Collections;

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
            //string path = @"C:\Users\zhangjia\Desktop\MJ4.0-669-MJ4_0\assets\ttt.mp4";
            //int index = path.LastIndexOf(@"\");
            //string result = "";
            //if (index > 0)
            //{
            //    result = path.Substring(index + 1, path.Length - index - 1);
            //    Console.WriteLine(result);
            //}

            string str1 = "{\"_start.mp4\":{\"url\":\"_start.mp4\",\"list\":{\"a1.mp4\":{\"url\":\"a1.mp4\",\"list\":{\"b1.mp4\":{\"url\":\"b1.mp4\"},\"b2.mp4\":{\"url\":\"b2.mp4\"},\"b3.mp4\":{\"url\":\"b3.mp4\",\"list\":{\"c1.mp4\":{\"url\":\"c1.mp4\"},\"c2.mp4\":{\"url\":\"c2.mp4\"},\"c3.mp4\":{\"url\":\"c3.mp4\"}}}}},\"a2.mp4\":{\"url\":\"a2.mp4\",\"list\":{\"b2.mp4\":{\"url\":\"b2.mp4\"},\"b3.mp4\":{\"url\":\"b3.mp4\",\"list\":{\"c1.mp4\":{\"url\":\"c1.mp4\"},\"c2.mp4\":{\"url\":\"c2.mp4\"},\"c3.mp4\":{\"url\":\"c3.mp4\"}}},\"b4.mp4\":{\"url\":\"b4.mp4\",\"list\":{\"c2.mp4\":{\"url\":\"c2.mp4\"},\"c3.mp4\":{\"url\":\"c3.mp4\"},\"c4.mp4\":{\"url\":\"c4.mp4\"}}}}},\"a3.mp4\":{\"url\":\"a3.mp4\",\"list\":{\"b3.mp4\":{\"url\":\"b3.mp4\",\"list\":{\"c1.mp4\":{\"url\":\"c1.mp4\"},\"c2.mp4\":{\"url\":\"c2.mp4\"},\"c3.mp4\":{\"url\":\"c3.mp4\"}}},\"b4.mp4\":{\"url\":\"b4.mp4\",\"list\":{\"c2.mp4\":{\"url\":\"c2.mp4\"},\"c3.mp4\":{\"url\":\"c3.mp4\"},\"c4.mp4\":{\"url\":\"c4.mp4\"}}},\"b5.mp4\":{\"url\":\"b5.mp4\",\"list\":{\"c3.mp4\":{\"url\":\"c3.mp4\"},\"c4.mp4\":{\"url\":\"c4.mp4\"},\"c5.mp4\":{\"url\":\"c5.mp4\",\"list\":{\"end.mpt\":{\"url\":\"end.mp4\"}}}}}}}}}}";

            string str2 = "{\"_start.mp4\":{\"url\":\"/storage/emulated/0/mj_market/data/_start.mp4\",\"listCount\":3,\"list\":{\"a1.mp4\":{\"url\":\"/storage/emulated/0/mj_market/data/a1.mp4\",\"listCount\":0},\"a2.mp4\":{\"url\":\"/storage/emulated/0/mj_market/data/a2.mp4\",\"listCount\":0},\"a3.mp4\":{\"url\":\"/storage/emulated/0/mj_market/data/a3.mp4\",\"listCount\":0}}},\"a1.mp4\":{\"url\":\"/storage/emulated/0/mj_market/data/a1.mp4\",\"listCount\":3,\"list\":{\"b1.mp4\":{\"url\":\"/storage/emulated/0/mj_market/data/b1.mp4\",\"listCount\":0},\"b2.mp4\":{\"url\":\"/storage/emulated/0/mj_market/data/b2.mp4\",\"listCount\":0},\"b3.mp4\":{\"url\":\"/storage/emulated/0/mj_market/data/b3.mp4\",\"listCount\":0}}},\"a2.mp4\":{\"url\":\"/storage/emulated/0/mj_market/data/a2.mp4\",\"listCount\":3,\"list\":{\"b2.mp4\":{\"url\":\"/storage/emulated/0/mj_market/data/b2.mp4\",\"listCount\":0},\"b3.mp4\":{\"url\":\"/storage/emulated/0/mj_market/data/b3.mp4\",\"listCount\":0},\"b4.mp4\":{\"url\":\"/storage/emulated/0/mj_market/data/b4.mp4\",\"listCount\":0}}},\"a3.mp4\":{\"url\":\"/storage/emulated/0/mj_market/data/a3.mp4\",\"listCount\":3,\"list\":{\"b3.mp4\":{\"url\":\"/storage/emulated/0/mj_market/data/b3.mp4\",\"listCount\":0},\"b4.mp4\":{\"url\":\"/storage/emulated/0/mj_market/data/b4.mp4\",\"listCount\":0},\"b5.mp4\":{\"url\":\"/storage/emulated/0/mj_market/data/b5.mp4\",\"listCount\":0}}},\"b1.mp4\":{\"url\":\"/storage/emulated/0/mj_market/data/b1.mp4\",\"listCount\":0},\"b2.mp4\":{\"url\":\"/storage/emulated/0/mj_market/data/b2.mp4\",\"listCount\":0},\"b3.mp4\":{\"url\":\"/storage/emulated/0/mj_market/data/b3.mp4\",\"listCount\":3,\"list\":{\"c1.mp4\":{\"url\":\"/storage/emulated/0/mj_market/data/c1.mp4\",\"listCount\":0},\"c2.mp4\":{\"url\":\"/storage/emulated/0/mj_market/data/c2.mp4\",\"listCount\":0},\"c3.mp4\":{\"url\":\"/storage/emulated/0/mj_market/data/c3.mp4\",\"listCount\":0}}},\"b4.mp4\":{\"url\":\"/storage/emulated/0/mj_market/data/b4.mp4\",\"listCount\":3,\"list\":{\"c2.mp4\":{\"url\":\"/storage/emulated/0/mj_market/data/c2.mp4\",\"listCount\":0},\"c3.mp4\":{\"url\":\"/storage/emulated/0/mj_market/data/c3.mp4\",\"listCount\":0},\"c4.mp4\":{\"url\":\"/storage/emulated/0/mj_market/data/c4.mp4\",\"listCount\":0}}},\"b5.mp4\":{\"url\":\"/storage/emulated/0/mj_market/data/b5.mp4\",\"listCount\":3,\"list\":{\"c3.mp4\":{\"url\":\"/storage/emulated/0/mj_market/data/c3.mp4\",\"listCount\":0},\"c4.mp4\":{\"url\":\"/storage/emulated/0/mj_market/data/c4.mp4\",\"listCount\":0},\"c5.mp4\":{\"url\":\"/storage/emulated/0/mj_market/data/c5.mp4\",\"listCount\":0}}},\"c1.mp4\":{\"url\":\"/storage/emulated/0/mj_market/data/c1.mp4\",\"listCount\":0},\"c2.mp4\":{\"url\":\"/storage/emulated/0/mj_market/data/c2.mp4\",\"listCount\":0},\"c3.mp4\":{\"url\":\"/storage/emulated/0/mj_market/data/c3.mp4\",\"listCount\":0},\"c4.mp4\":{\"url\":\"/storage/emulated/0/mj_market/data/c4.mp4\",\"listCount\":0},\"c5.mp4\":{\"url\":\"/storage/emulated/0/mj_market/data/c5.mp4\",\"listCount\":3,\"list\":{\"end.mp4\":{\"url\":\"/storage/emulated/0/mj_market/data/end.mp4\",\"listCount\":0}}}}";

            string videoName = "_start.mp4";
            JsonData jsonData2 = JsonMapper.ToObject(str2);

            IDictionary dict = jsonData2 as IDictionary;
            foreach (string key in dict.Keys)
            {
                if (key == videoName)
                {
                    Console.WriteLine(key + "\n");
                    if ((int)jsonData2[videoName]["listCount"] > 0)
                    {
                        IDictionary dict2 = jsonData2[videoName]["list"] as IDictionary;
                        Console.WriteLine(dict2[1]);
                        foreach (string key2 in dict2.Keys)
                        {
                            Console.WriteLine(jsonData2[videoName]["list"][key2]["url"]);
                        }
                    }
                    break;
                }
            }
        }
    }
}