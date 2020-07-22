using System;

namespace TCommon.LeetCode
{
    public class RescueThePrincess
    {
        /* [编程]解救公主I
           分值：400

           程序执行时限: 500 ms

           最近阿宅迷上了一款二次元游戏叫<<解救公主>>。

           其中有一关的规则是这样的

           公主被困在梦境里，梦境里的空间无限大，公主靠自己是走不出来的。

           系统会随机很多条行动指令，玩家必须帮公主选出正确的指令，公主按照玩家选择的指令，重复执行若干次后就能走出困境。

           指令有三个字符组成 S,R,L

           S: 前进一步
           R: 向右转
           L: 向左转
           如果公主重复执行错误的指令，她就会一直在绕圈子，走不出梦境。

           所谓“绕圈子”是指：无论公主重复执行多少次指令，她始终都在一个以出发点为圆心，以R为半径的圆里，永远走不出这个圆，更走不出梦境。

           阿宅已经卡在这一关很久了。他很痛苦不能早日拯救公主脱离苦海，于是向聪明的你求助，让你写段代码判断哪些指令是正确的，哪些指令是错误的。

           输入：

           第一行 一个整数n

           之后共有n行，每行为一个指令串

           输入约束：

           n位于区间[1,50]

           从第二行开始，每行指令串长度为1-50，且仅包含字母 S,L,R

           输出：

           仅有一个单词。

           指令串错误 打印 no

           指令串正确 打印 yes

           举例1：

           输入

           1
           SLSR
           输出

           yes
           解释：假设公主初始状态向北，公主的行动序列依次为前进，左转，前进，右转，此时公主仍然向北，但位置已经移动了。只要时间足够长，公主会一直向这个方向前进，所以公主没有在绕圈子。她能走出梦境，指令是正确的

           举例2：

           输入

           2
           SSSS
           R
           输出

           no
           解释： 公主一直在沿着一个边长为4步的小正方形绕圈子，指令是错误的 */

        public static void Execute()
        {
            string line = Console.ReadLine();
            string canGoKeyVal = "";

            for (int i = 0; i < int.Parse(line); i++)
            {
                string keyVal = Console.ReadLine();
                canGoKeyVal += keyVal;
            }

            canGoKeyVal = canGoKeyVal.Replace("\n", "").Replace(" ", "").Replace("\t", "").Replace("\r", "");
            bool canGoOut = IsGoZero(canGoKeyVal);

            Console.Write(canGoOut == false ? "yes" : "no");
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="keyVal"></param>
        /// <returns></returns>
        public static bool IsGoZero(string keyVal)
        {
            //if (!(keyVal.Length >= 1 && keyVal.Length <= 2500)) return false;
            int d = 0;// 四个方向 0上1右2下3左  这样定是为了满足 d+1就是向左转 d+3就是向右转
            int[] dx = { 0, 1, 0, -1 };// 索引和方向对应
            int[] dy = { 1, 0, -1, 0 };
            int x = 0;
            int y = 0;
            for (int i = 0; i < keyVal.Length; i++)
            {
                switch (keyVal[i])
                {
                    case 'R':
                        d += 1;
                        break;

                    case 'L':
                        d += 3;// 不用d-=1 是因为当d变成负数的时候，取mod会出错
                        break;

                    case 'S':
                        d = d % 4;
                        x = x + dx[d];
                        y = y + dy[d];
                        break;
                }
            }
            return ((x == 0 && y == 0) || d % 4 != 0);
        }
    }
}