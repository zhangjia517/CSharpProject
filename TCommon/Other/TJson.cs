using LitJson;
using System;
using System.Collections;
using System.Collections.Generic;

namespace TCommon.Other
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

            //string str1 = "{\"_start.mp4\":{\"url\":\"_start.mp4\",\"list\":{\"a1.mp4\":{\"url\":\"a1.mp4\",\"list\":{\"b1.mp4\":{\"url\":\"b1.mp4\"},\"b2.mp4\":{\"url\":\"b2.mp4\"},\"b3.mp4\":{\"url\":\"b3.mp4\",\"list\":{\"c1.mp4\":{\"url\":\"c1.mp4\"},\"c2.mp4\":{\"url\":\"c2.mp4\"},\"c3.mp4\":{\"url\":\"c3.mp4\"}}}}},\"a2.mp4\":{\"url\":\"a2.mp4\",\"list\":{\"b2.mp4\":{\"url\":\"b2.mp4\"},\"b3.mp4\":{\"url\":\"b3.mp4\",\"list\":{\"c1.mp4\":{\"url\":\"c1.mp4\"},\"c2.mp4\":{\"url\":\"c2.mp4\"},\"c3.mp4\":{\"url\":\"c3.mp4\"}}},\"b4.mp4\":{\"url\":\"b4.mp4\",\"list\":{\"c2.mp4\":{\"url\":\"c2.mp4\"},\"c3.mp4\":{\"url\":\"c3.mp4\"},\"c4.mp4\":{\"url\":\"c4.mp4\"}}}}},\"a3.mp4\":{\"url\":\"a3.mp4\",\"list\":{\"b3.mp4\":{\"url\":\"b3.mp4\",\"list\":{\"c1.mp4\":{\"url\":\"c1.mp4\"},\"c2.mp4\":{\"url\":\"c2.mp4\"},\"c3.mp4\":{\"url\":\"c3.mp4\"}}},\"b4.mp4\":{\"url\":\"b4.mp4\",\"list\":{\"c2.mp4\":{\"url\":\"c2.mp4\"},\"c3.mp4\":{\"url\":\"c3.mp4\"},\"c4.mp4\":{\"url\":\"c4.mp4\"}}},\"b5.mp4\":{\"url\":\"b5.mp4\",\"list\":{\"c3.mp4\":{\"url\":\"c3.mp4\"},\"c4.mp4\":{\"url\":\"c4.mp4\"},\"c5.mp4\":{\"url\":\"c5.mp4\",\"list\":{\"end.mpt\":{\"url\":\"end.mp4\"}}}}}}}}}}";
            //string str2 = "{\"_start.mp4\":{\"url\":\"/storage/emulated/0/mj_market/data/_start.mp4\",\"startTipTime\":31,\"endTipTime\":47,\"listCount\":3,\"list\":{\"a1.mp4\":{\"url\":\"/storage/emulated/0/mj_market/data/a1.mp4\",\"listCount\":0},\"a2.mp4\":{\"url\":\"/storage/emulated/0/mj_market/data/a2.mp4\",\"listCount\":0},\"a3.mp4\":{\"url\":\"/storage/emulated/0/mj_market/data/a3.mp4\",\"listCount\":0}}},\"a1.mp4\":{\"url\":\"/storage/emulated/0/mj_market/data/a1.mp4\",\"startTipTime\":28,\"endTipTime\":48,\"listCount\":3,\"list\":{\"b1.mp4\":{\"url\":\"/storage/emulated/0/mj_market/data/b1.mp4\",\"listCount\":0},\"b2.mp4\":{\"url\":\"/storage/emulated/0/mj_market/data/b2.mp4\",\"listCount\":0},\"b3.mp4\":{\"url\":\"/storage/emulated/0/mj_market/data/b3.mp4\",\"listCount\":0}}},\"a2.mp4\":{\"url\":\"/storage/emulated/0/mj_market/data/a2.mp4\",\"startTipTime\":32,\"endTipTime\":51,\"listCount\":3,\"list\":{\"b2.mp4\":{\"url\":\"/storage/emulated/0/mj_market/data/b2.mp4\",\"listCount\":0},\"b3.mp4\":{\"url\":\"/storage/emulated/0/mj_market/data/b3.mp4\",\"listCount\":0},\"b4.mp4\":{\"url\":\"/storage/emulated/0/mj_market/data/b4.mp4\",\"listCount\":0}}},\"a3.mp4\":{\"url\":\"/storage/emulated/0/mj_market/data/a3.mp4\",\"startTipTime\":25,\"endTipTime\":45,\"listCount\":3,\"list\":{\"b3.mp4\":{\"url\":\"/storage/emulated/0/mj_market/data/b3.mp4\",\"listCount\":0},\"b4.mp4\":{\"url\":\"/storage/emulated/0/mj_market/data/b4.mp4\",\"listCount\":0},\"b5.mp4\":{\"url\":\"/storage/emulated/0/mj_market/data/b5.mp4\",\"listCount\":0}}},\"b1.mp4\":{\"url\":\"/storage/emulated/0/mj_market/data/b1.mp4\",\"listCount\":0},\"b2.mp4\":{\"url\":\"/storage/emulated/0/mj_market/data/b2.mp4\",\"listCount\":0},\"b3.mp4\":{\"url\":\"/storage/emulated/0/mj_market/data/b3.mp4\",\"startTipTime\":25,\"endTipTime\":52,\"listCount\":3,\"list\":{\"c1.mp4\":{\"url\":\"/storage/emulated/0/mj_market/data/c1.mp4\",\"listCount\":0},\"c2.mp4\":{\"url\":\"/storage/emulated/0/mj_market/data/c2.mp4\",\"listCount\":0},\"c3.mp4\":{\"url\":\"/storage/emulated/0/mj_market/data/c3.mp4\",\"listCount\":0}}},\"b4.mp4\":{\"url\":\"/storage/emulated/0/mj_market/data/b4.mp4\",\"startTipTime\":23,\"endTipTime\":41,\"listCount\":3,\"list\":{\"c2.mp4\":{\"url\":\"/storage/emulated/0/mj_market/data/c2.mp4\",\"listCount\":0},\"c3.mp4\":{\"url\":\"/storage/emulated/0/mj_market/data/c3.mp4\",\"listCount\":0},\"c4.mp4\":{\"url\":\"/storage/emulated/0/mj_market/data/c4.mp4\",\"listCount\":0}}},\"b5.mp4\":{\"url\":\"/storage/emulated/0/mj_market/data/b5.mp4\",\"startTipTime\":25,\"endTipTime\":44,\"listCount\":3,\"list\":{\"c3.mp4\":{\"url\":\"/storage/emulated/0/mj_market/data/c3.mp4\",\"listCount\":0},\"c4.mp4\":{\"url\":\"/storage/emulated/0/mj_market/data/c4.mp4\",\"listCount\":0},\"c5.mp4\":{\"url\":\"/storage/emulated/0/mj_market/data/c5.mp4\",\"listCount\":0}}},\"c1.mp4\":{\"url\":\"/storage/emulated/0/mj_market/data/c1.mp4\",\"listCount\":0},\"c2.mp4\":{\"url\":\"/storage/emulated/0/mj_market/data/c2.mp4\",\"listCount\":0},\"c3.mp4\":{\"url\":\"/storage/emulated/0/mj_market/data/c3.mp4\",\"listCount\":0},\"c4.mp4\":{\"url\":\"/storage/emulated/0/mj_market/data/c4.mp4\",\"listCount\":0},\"c5.mp4\":{\"url\":\"/storage/emulated/0/mj_market/data/c5.mp4\",\"startTipTime\":-1,\"endTipTime\":-1,\"listCount\":1,\"list\":{\"end.mp4\":{\"url\":\"/storage/emulated/0/mj_market/data/end.mp4\",\"listCount\":0}}},\"end.mp4\":{\"url\":\"/storage/emulated/0/mj_market/data/end.mp4\",\"listCount\":0}}";

            //string videoName = "a3.mp4";
            //JsonData jsonData2 = JsonMapper.ToObject(str2);

            //IDictionary dict = jsonData2 as IDictionary;
            //foreach (string key in dict.Keys)
            //{
            //    if (key == videoName)
            //    {
            //        Console.WriteLine(key + "\n");
            //        if ((int)jsonData2[videoName]["listCount"] > 0)
            //        {
            //            IDictionary dict2 = jsonData2[videoName]["list"] as IDictionary;
            //            Console.WriteLine(dict2[1]);
            //            foreach (string key2 in dict2.Keys)
            //            {
            //                Console.WriteLine(jsonData2[videoName]["list"][key2]["url"]);
            //            }
            //        }
            //        break;
            //    }
            //}

            string jsonStr = "{\"Start\":{\"url\":\"/storage/emulated/0/mj_market/data/VRInteraction_B/1.mp4\",\"listCount\":2,\"list\":{\"A\":{\"url\":\"/storage/emulated/0/mj_market/data/VRInteraction_B/2.mp4\",\"listCount\":2,\"list\":{\"A\":{\"url\":\"/storage/emulated/0/mj_market/data/VRInteraction_B/4.mp4\",\"listCount\":2,\"list\":{\"A\":{\"url\":\"/storage/emulated/0/mj_market/data/VRInteraction_B/A.mp4\",\"listCount\":0},\"B\":{\"url\":\"/storage/emulated/0/mj_market/data/VRInteraction_B/B.mp4\",\"listCount\":0}}},\"B\":{\"url\":\"/storage/emulated/0/mj_market/data/VRInteraction_B/5.mp4\",\"listCount\":2,\"list\":{\"A\":{\"url\":\"/storage/emulated/0/mj_market/data/VRInteraction_B/6.mp4\",\"listCount\":2,\"list\":{\"A\":{\"url\":\"/storage/emulated/0/mj_market/data/VRInteraction_B/A.mp4\",\"listCount\":0},\"B\":{\"url\":\"/storage/emulated/0/mj_market/data/VRInteraction_B/C.mp4\",\"listCount\":0}}},\"B\":{\"url\":\"/storage/emulated/0/mj_market/data/VRInteraction_B/7.mp4\",\"listCount\":2,\"list\":{\"A\":{\"url\":\"/storage/emulated/0/mj_market/data/VRInteraction_B/B.mp4\",\"listCount\":0},\"B\":{\"url\":\"/storage/emulated/0/mj_market/data/VRInteraction_B/C.mp4\",\"listCount\":0}}}}}}},\"B\":{\"url\":\"/storage/emulated/0/mj_market/data/VRInteraction_B/3.mp4\",\"listCount\":2,\"list\":{\"A\":{\"url\":\"/storage/emulated/0/mj_market/data/VRInteraction_B/5.mp4\",\"listCount\":2,\"list\":{\"A\":{\"url\":\"/storage/emulated/0/mj_market/data/VRInteraction_B/6.mp4\",\"listCount\":2,\"list\":{\"A\":{\"url\":\"/storage/emulated/0/mj_market/data/VRInteraction_B/B.mp4\",\"listCount\":0},\"B\":{\"url\":\"/storage/emulated/0/mj_market/data/VRInteraction_B/D.mp4\",\"listCount\":0}}},\"B\":{\"url\":\"/storage/emulated/0/mj_market/data/VRInteraction_B/4.mp4\",\"listCount\":2,\"list\":{\"A\":{\"url\":\"/storage/emulated/0/mj_market/data/VRInteraction_B/C.mp4\",\"listCount\":0},\"B\":{\"url\":\"/storage/emulated/0/mj_market/data/VRInteraction_B/D.mp4\",\"listCount\":0}}}}},\"B\":{\"url\":\"/storage/emulated/0/mj_market/data/VRInteraction_B/7.mp4\",\"listCount\":2,\"list\":{\"A\":{\"url\":\"/storage/emulated/0/mj_market/data/VRInteraction_B/C.mp4\",\"listCount\":0},\"B\":{\"url\":\"/storage/emulated/0/mj_market/data/VRInteraction_B/D.mp4\",\"listCount\":0}}}}}}}}";
            JsonData jsonData = JsonMapper.ToObject(jsonStr);

            IDictionary dict1 = jsonData as IDictionary;
            JsonData jsonData2 = (JsonData)dict1["Start"];

            Node node;
            node = Node.Parse(jsonData2);
            Console.WriteLine(node.Chidren[1].Chidren[1].Url);
        }
    }

    public class Node
    {
        public string Url { get; set; }
        public List<Node> Chidren { get; set; }

        public static Node Parse(JsonData data)
        {
            IDictionary dict = data as IDictionary;
            var node = new Node();

            if (dict["url"] == null)
                return node;
            node.Url = dict["url"].ToString();
            node.Chidren = new List<Node>();

            for (int i = 0; i < int.Parse(dict["listCount"].ToString()); i++)
            {
                node.Chidren.Add(Parse(((JsonData)dict["list"])[i]));
            }
            return node;
        }
    }
}