﻿using System;
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


            while (true)
            {

                //要素番号取り出し
                int x = q_x.Dequeue();
                int y = q_y.Dequeue();

                /*****************************************
                 *上下左右で「.」のマスをキューに格納する 
                 *****************************************/
                //上
                var up_pos = maze[x - 1, y + 0];
                if (up_pos.Equals('.') && move_count[x - 1, y + 0] == 0) //既に移動済みのマスには移動しない
                {
                    //スタート地点のマスなのか判定(スタート地点のマスは0であるため別途判定)
                    if (x - 1 == 1 && y + 0 == 1)
                    {
                        ;
                    }
                    else
                    {
                        q_x.Enqueue(x - 1);
                        q_y.Enqueue(y + 0);

                        //Console.WriteLine("元のマス" + move_count[x, y]);

                        //基準のマスの移動数+1
                        move_count[x - 1, y + 0] = move_count[x, y] + 1;

                        //Console.WriteLine("上移動数" + move_count[x - 1, y + 0]);
                    }
                }
                //下
                var down_pos = maze[x + 0, y + 1];
                if (down_pos.Equals('.') && move_count[x + 0, y + 1] == 0) //既に移動済みのマスには移動しない
                {
                    //スタート地点のマスなのか判定(スタート地点のマスは0であるため別途判定)
                    if (x + 0 == 1 && y + 1 == 1)
                    {
                        ;
                    }
                    else
                    {
                        q_x.Enqueue(x + 0);
                        q_y.Enqueue(y + 1);

                        //Console.WriteLine("元のマス" + move_count[x, y]);
                        //基準のマスの移動数+1
                        move_count[x + 0, y + 1] = move_count[x, y] + 1;
                        //Console.WriteLine("下移動数" + move_count[x + 0, y + 1]);
                    }
                }
                //左
                var left_pos = maze[x + 1, y + 0];
                if (left_pos.Equals('.') && move_count[x + 1, y + 0] == 0) //既に移動済みのマスには移動しない
                {
                    //スタート地点のマスなのか判定(スタート地点のマスは0であるため別途判定)
                    if (x + 1 == 1 && y + 0 == 1)
                    {
                        ;
                    }
                    else
                    {
                        q_x.Enqueue(x + 1);
                        q_y.Enqueue(y + 0);


                        //Console.WriteLine("元のマス" + move_count[x, y]);
                        //基準のマスの移動数+1
                        move_count[x + 1, y + 0] = move_count[x, y] + 1;
                        //Console.WriteLine("左移動数" + move_count[x + 1, y + 0]);
                    }
                }
                //右
                var right_pos = maze[x + 0, y - 1];
                if (right_pos.Equals('.') && move_count[x + 0, y - 1] == 0) //既に移動済みのマスには移動しない
                {
                    //スタート地点のマスなのか判定(スタート地点のマスは0であるため別途判定)
                    if (x + 0 == 1 && y - 1 == 1)
                    {
                        ;
                    }
                    else
                    {
                        q_x.Enqueue(x + 0);
                        q_y.Enqueue(y - 1);

                        //Console.WriteLine("元のマス" + move_count[x, y]);
                        //基準のマスの移動数+1
                        move_count[x + 0, y - 1] = move_count[x, y] + 1;
                        //Console.WriteLine("右移動数" + move_count[x + 0, y - 1]);
                    }
                }

                //ゴール地点のマスなのかを判定
                if (x == g[0] - 1 && y == g[1] - 1)
                {
                    break;
                }
            }

            //結果表示
            Console.WriteLine("最短距離：" + move_count[g[0] - 1, g[1] - 1]);
        }
    }
}
