using System;
using System.Collections.Generic;


namespace AtCoder01



{
    /// <summary>
    /// 幅優先探索
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            /*************************************
             * 標準入力の受け取り、切り出し、変換
             *************************************/
            var R = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);  //行列数
            var s = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);  //スタート位置
            var g = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);  //ゴール位置

            //迷路(2次元配列)
            char[,] maze = new char[R[0], R[1]];
            //移動数管理
            int[,] moveCount = new int[R[0], R[1]];

            //迷路情報の取得(行数分だけループ)
            for (int i = 0; i <= R[0]; i++)
            { 
                var mazeTmp = Console.ReadLine().ToCharArray(); //一文字ずつ代入
                int count = 0;
                foreach (var j in mazeTmp)
                {
                    maze[i, count] = j;
                    count++;
                }
            }

            //キュー(x,y)
            var qY = new Queue<int>();
            var qX = new Queue<int>();

            //スタート位置の要素番号を格納
            qX.Enqueue(s[1] - 1);
            qY.Enqueue(s[0] - 1);

            //デキュー
            int x;
            int y;

            //上右下左の順
            int[] moveX = {-1,0,1,0};
            int[] moveY = {0,1,0,-1};

            while (true)
            {
                //要素番号取り出し
                x = qX.Dequeue();
                y = qY.Dequeue();

                //基準のマスの上右下左を順に確認し、各マスに"."が格納されている場合は、そのマスをキューに追加し、移動数を「moveCount」に格納する
                for (int i=0;i<4;i++) {
                    var pos = maze[x + moveX[i], y + moveY[i]];
                    if (pos.Equals('.') && moveCount[x + moveX[i], y + moveY[i]] == 0) //既に移動済みのマスには移動しない
                    {
                        //スタート地点のマスなのか判定(スタート地点のマスは0であるため別途判定)
                        if (x + moveX[i] == 1 && y + moveY[i] == 1)
                        {
                            ;
                        }
                        else
                        {
                            qX.Enqueue(x + moveX[i]);
                            qY.Enqueue(y + moveY[i]);

                            //基準のマスの移動数+1
                            moveCount[x + moveX[i], y + moveY[i]] = moveCount[x, y] + 1;
                        }
                    }
                }
                    //ゴール地点のマスなのかを判定
                    if (x == g[0] - 1 && y == g[1] - 1) break;
            }

            //結果表示
            Console.WriteLine("最短距離：" + moveCount[g[0] - 1, g[1] - 1]);
        }
    }
}
