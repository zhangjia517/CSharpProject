using System;

namespace TCommon.LeetCode
{
    public class Node
    {
        public int value;
        public Node next;
    }

    public class TNodeReverse
    {
        public static void Execute()
        {
            Node list3 = new Node();
            list3.value = 2;

            Node list2 = new Node();
            list2.value = 1;
            list2.next = list3;

            Node list1 = new Node();
            list1.value = 0;
            list1.next = list2;

            NodePrint(list1);
            list1 = Reverse(list1, list1.next);
            NodePrint(list1);
        }

        private static void NodePrint(Node list1)
        {
            Node n = list1;
            while (n != null)
            {
                Console.WriteLine(n.value);
                n = n.next;
            }
        }

        private static Node Reverse(Node current, Node next)
        {
            Node tmp = next.next;
            next.next = current;
            if (current.value == 0)
            {
                current.next = null;
            }
            if (tmp == null)
            {
                return next;
            }
            else
            {
                return Reverse(next, tmp);
            }
        }
    }
}