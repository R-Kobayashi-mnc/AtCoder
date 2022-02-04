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
            int[,] move_count = new int[R[0], R[1]];

            //迷路情報の取得(行数分だけループ)
            for (int i = 0; i <= R[0]; i++)
            { 
                var maze_tmp = Console.ReadLine().ToCharArray(); //一文字ずつ代入
                int count = 0;
                foreach (char j in maze_tmp)
                {
                    maze[i, count] = j;
                    count++;
                }
            }

            //キュー(x,y)
            var q_y = new Queue<int>();
            var q_x = new Queue<int>();

            //スタート位置の要素番号を格納
            q_x.Enqueue(s[1] - 1);
            q_y.Enqueue(s[0] - 1);

            //デキュー
            int x;
            int y;

            //上右下左の順
            int[] move_x = {-1,0,1,0};
            int[] move_y = {0,1,0,-1};

            while (true)
            {
                //要素番号取り出し
                x = q_x.Dequeue();
                y = q_y.Dequeue();

                //基準のマスの上右下左を順に確認し、各マスに"."が格納されている場合は、そのマスをキューに追加し、移動数を「move_count」に格納する
                for (int i=0;i<4;i++) {
                    var pos = maze[x + move_x[i], y + move_y[i]];
                    if (pos.Equals('.') && move_count[x + move_x[i], y + move_y[i]] == 0) //既に移動済みのマスには移動しない
                    {
                        //スタート地点のマスなのか判定(スタート地点のマスは0であるため別途判定)
                        if (x + move_x[i] == 1 && y + move_y[i] == 1)
                        {
                            ;
                        }
                        else
                        {
                            q_x.Enqueue(x + move_x[i]);
                            q_y.Enqueue(y + move_y[i]);

                            //基準のマスの移動数+1
                            move_count[x + move_x[i], y + move_y[i]] = move_count[x, y] + 1;
                        }
                    }
                }
                    //ゴール地点のマスなのかを判定
                    if (x == g[0] - 1 && y == g[1] - 1) break;
            }

            //結果表示
            Console.WriteLine("最短距離：" + move_count[g[0] - 1, g[1] - 1]);
        }
    }
}
