//#define dbg

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Diagnostics;
using System.Threading;

namespace Simd
{
    class Game
    {
        // 矩阵大小
        public const int ARRAY_SIZE = 8;
        // 最少相连数量：KEY+2
        private const int KEY = 1;
        // 颜色数
        private int MAX_TYPES = 7;
        // 最大连击
        private int MAX_COMBO = 20;
        // 最大填充重试
        private int MAX_REFILL = 30;

        // 文字样式
        private String[] SYMBOL1 = { "   ", " 1 ", " 2 ", " 3 ", " 4 ", " 5 ", " 6 ", " 7 ", " 8 " };
        private String[] SYMBOL2 = { " ! ", "[1]", "[2]", "[3]", "[4]", "[5]", "[6]", "[7]", "[8]" };

        // 总分
        public int TotalScore { get; set; }
        // 最大步数
        public int MaxStep { get; set; }
        // 当前步数
        public int NowStep { get; set; }
        // 最高连击
        public int Combo { get; set; }
        // 重填充次数
        public int Refill { get; set; }
        // 游戏数据
        public int[,] DataTable { get; set; }
        // 处理回调
        private Perform perform;

        public delegate void Perform(int[,] DataTable, int tp);
        public Game(int step, Perform pf)
        {
            perform = pf;
            MaxStep = step;
            NowStep = 0;
            TotalScore = 0;
            Combo = 0;
            Refill = 0;
            DataTable = new int[ARRAY_SIZE, ARRAY_SIZE];
            fillMap(DataTable, true);
            perform(DataTable, -1);
            dbg("=======================================================================", true);
        }

        /// <summary>
        /// 重填充
        /// </summary>
        public void refill()
        {
            bool fl = fillMap(DataTable, true);
            Refill++;
            perform(DataTable, -1);
            // 重填充干净数据失败，进行自动削除
            if (!fl)
            {
                List<int> clns;
                int val = 0;
                clns = clean(DataTable, true);
                val = evalVal(clns);
                Combo = clns.Count > Combo ? clns.Count : Combo;
                NowStep++;
                TotalScore += val;
            }
        }

        /// <summary>
        /// 交换处理
        /// </summary>
        /// <param name="p1">点1</param>
        /// <param name="p2">点2</param>
        /// <returns>得分</returns>
        public int action(Point p1, Point p2)
        {
            int tmp;
            int val = 0;
            List<int> clns;
            if (NowStep >= MaxStep)
                return -1;
            tmp = DataTable[p1.X, p1.Y];
            DataTable[p1.X, p1.Y] = DataTable[p2.X, p2.Y];
            DataTable[p2.X, p2.Y] = tmp;
            // 清理处理
            clns = clean(DataTable, true);
            // 计算得分
            val = evalVal(clns);
            dbg("ACT: [" + val + "] Score Total", true);

            Combo = clns.Count > Combo ? clns.Count : Combo;
            NowStep++;
            TotalScore += val;
            return val;
        }

        /// <summary>
        /// 交换评估
        /// </summary>
        /// <param name="p1">点1</param>
        /// <param name="p2">点2</param>
        /// <returns>得分</returns>
        public int tryAct(Point p1, Point p2)
        {
            int tmp;
            int val;

            tmp = DataTable[p1.X, p1.Y];
            DataTable[p1.X, p1.Y] = DataTable[p2.X, p2.Y];
            DataTable[p2.X, p2.Y] = tmp;

            val = evalVal(clean(DataTable, false));
            dbg("TRY: [" + val + "] Score", true);

            tmp = DataTable[p1.X, p1.Y];
            DataTable[p1.X, p1.Y] = DataTable[p2.X, p2.Y];
            DataTable[p2.X, p2.Y] = tmp;
            return val;
        }

        /// <summary>
        /// 计算得分
        /// </summary>
        /// <param name="clns">削除数据</param>
        /// <returns>得分</returns>
        private int evalVal(List<int> clns)
        {
            int val = 0;
            for (int i = 0; i < clns.Count; i++)
            {
                if (clns[i] == 0)
                {
                    break;
                }
                val += calcVal(clns[i] + i);

                dbg("EVAL: [" + clns[i] + "] Block", true);
                dbg("EVAL: [" + calcVal(clns[i] + i) + "] Score(Combo " + (i + 1) + ")", true);
            }
            return val;
        }

        /// <summary>
        /// 填充处理
        /// </summary>
        /// <param name="table">数据对象</param>
        /// <param name="force">是否强制</param>
        /// <returns>是否干净</returns>
        private bool fillMap(int[,] table, bool force)
        {
            int[,] nMap = new int[ARRAY_SIZE, ARRAY_SIZE];
            Random rd = new Random();
            int limit = 0;
            while (true)
            {
                dbg("--[FILLMAP]---------------------------\n");
                for (int i = 0; i < ARRAY_SIZE; i++)
                {
                    for (int j = 0; j < ARRAY_SIZE; j++)
                    {
                        // 选择可填充位置
                        if (force || table[i, j] == 0)
                        {
                            nMap[i, j] = rd.Next(MAX_TYPES) + 1;
                            dbg(SYMBOL2[nMap[i, j]]);
                        }
                        else
                        {
                            nMap[i, j] = 0;
                            dbg(SYMBOL1[table[i, j]]);
                        }
                    }
                    dbg("\n");
                }
                // 判断是否干净
                if (++limit == MAX_REFILL || evalVal(clean(nMap, false)) == 0)
                {
                    break;
                }
            }
            dbg("Fill Map End, Try:" + limit, true);
            // 写回填充数据
            for (int i = 0; i < ARRAY_SIZE; i++)
            {
                for (int j = 0; j < ARRAY_SIZE; j++)
                {
                    table[i, j] = nMap[i, j] == 0 ? table[i, j] : nMap[i, j];
                }
            }
            if (limit >= MAX_REFILL) return false;
            return true;
        }

        /// <summary>
        /// 清理数据
        /// </summary>
        /// <param name="rtable">数据对象</param>
        /// <param name="act">是否真实</param>
        /// <returns></returns>
        private List<int> clean(int[,] rtable, bool act)
        {
            List<int> clns = new List<int>();
            int[,] table = (int[,])rtable.Clone();
            int limit = 0;
            int sCnt;
            do
            {
                // 标记需要清理的数据
                sCnt = rush(table, true);
                if (sCnt > 0)
                {
                    clns.Add(sCnt);
                    if (act)
                    {
                        perform(table, 2);
                    }
                    // 悬空单元格掉落
                    fall(table);
                    if (act)
                    {
                        perform(table, 1);
                    }
                }
                if (act)
                {
                    // 填充空白位置
                    fillMap(table, false);
                    perform(table, 0);
                }
            } while (sCnt > 0 && act && ++limit < MAX_COMBO);

            if (act)
                dbg("Combo:" + limit, true);
            if (act)
            {
                for (int i = 0; i < ARRAY_SIZE; i++)
                {
                    for (int j = 0; j < ARRAY_SIZE; j++)
                    {
                        // 写回真实数据
                        rtable[i, j] = table[i, j];
                    }
                }
            }
            return clns;
        }

        /// <summary>
        /// 标记可清理数据
        /// </summary>
        /// <param name="table">数据对象</param>
        /// <param name="act">是否真实</param>
        /// <returns>清理数量</returns>
        private int rush(int[,] table, bool act)
        {
            int sCnt = 0;
            int[,] clMap = new int[ARRAY_SIZE, ARRAY_SIZE];
            for (int i = 0; i < ARRAY_SIZE; i++)
            {
                for (int j = 0; j < ARRAY_SIZE; j++)
                {
                    clMap[i, j] = 0;
                }
            }
            for (int i = 0; i < ARRAY_SIZE; i++)
            {
                for (int j = 0; j < ARRAY_SIZE; j++)
                {
                    if (table[i, j] == 0)
                    {
                        continue;
                    }
                    // 从指定点开始标记相连的可清理数据
                    markCleanMap(table, clMap, i, j);
                }
            }

            dbg("--[CLNMAP]----------------------------", true);
            for (int i = 0; i < ARRAY_SIZE; i++)
            {
                for (int j = 0; j < ARRAY_SIZE; j++)
                {
                    if (clMap[i, j] == 1)
                    {
                        dbg(SYMBOL2[table[i, j]]);
                        sCnt++;
                        if (act)
                            table[i, j] = 0;
                    }
                    else
                    {
                        dbg(SYMBOL1[table[i, j]]);
                    }
                }
                dbg("\n");
            }
            return sCnt;
        }

        /// <summary>
        /// 从指定点开始查找标记可清理数据
        /// </summary>
        /// <param name="table">数据对象</param>
        /// <param name="clMap">标记对象</param>
        /// <param name="x">坐标X</param>
        /// <param name="y">坐标Y</param>
        private void markCleanMap(int[,] table, int[,] clMap, int x, int y)
        {
            // 向右查找同色数量
            int lr = analyze(table, x, y, Dir.R);
            // 向左查找同色数量
            int ld = analyze(table, x, y, Dir.D);
            KeyLine kl = new KeyLine();
            kl.cx = x;
            kl.cy = y;
            kl.x1 = x;
            kl.y1 = y;
            if (lr > KEY)
            {
                kl.dir = Dir.R;
                kl.x2 = x + lr;
                kl.y2 = y;
                clMap[x, y] = 1;
                // 递归标记相连单元格
                markKeyLine(table, clMap, kl);
            }
            if (ld > KEY)
            {
                kl.dir = Dir.D;
                kl.x2 = x;
                kl.y2 = y + ld;
                clMap[x, y] = 1;
                // 递归标记相连单元格
                markKeyLine(table, clMap, kl);
            }
        }
        /// <summary>
        /// 递归标记相连单元格
        /// </summary>
        /// <param name="table">数据对象</param>
        /// <param name="clMap">标记对象</param>
        /// <param name="kx">标记链</param>
        /// <returns>标记个数</returns>
        private int markKeyLine(int[,] table, int[,] clMap, KeyLine kx)
        {
            List<Point> pts = kx.getPoints();
            int marks = 0;
            foreach (Point pt in pts)
            {
                if (clMap[pt.X, pt.Y] == 0)
                {
                    clMap[pt.X, pt.Y] = 1;
                    int cn1 = analyze(table, pt.X, pt.Y, turn(kx.dir));
                    int cn2 = analyze(table, pt.X, pt.Y, back(turn(kx.dir)));
                    if (cn1 + cn2 > KEY)
                    {
                        KeyLine kl = new KeyLine();
                        kl.cx = pt.X;
                        kl.cy = pt.Y;
                        kl.dir = turn(kx.dir);
                        if (kx.dir == Dir.R)
                        {
                            kl.x1 = kl.cx;
                            kl.x2 = kl.cx;
                            kl.y1 = pt.Y - cn2;
                            kl.y2 = pt.Y + cn1;
                        }
                        if (kx.dir == Dir.D)
                        {
                            kl.y1 = kl.cy;
                            kl.y2 = kl.cy;
                            kl.x1 = pt.X - cn2;
                            kl.x2 = pt.X + cn1;
                        }
                        markKeyLine(table, clMap, kl);
                        marks++;
                    }
                }
            }

            return marks;
        }

        /// <summary>
        /// 查找直线上同色个数
        /// </summary>
        /// <param name="table">数据对象</param>
        /// <param name="x">坐标X</param>
        /// <param name="y">坐标Y</param>
        /// <param name="dir">方向</param>
        /// <returns>同色个数(不含自身)</returns>
        private int analyze(int[,] table, int x, int y, Dir dir)
        {
            int kCnt = 0;
            int ptr = -1;
            if (dir == Dir.R)
            {
                ptr = x + 1;
                while (ptr < ARRAY_SIZE && table[x, y] == table[ptr, y])
                {
                    ptr++;
                    kCnt++;
                }
            }
            if (dir == Dir.D)
            {
                ptr = y + 1;
                while (ptr < ARRAY_SIZE && table[x, y] == table[x, ptr])
                {
                    ptr++;
                    kCnt++;
                }
            }
            if (dir == Dir.L)
            {
                ptr = x - 1;
                while (ptr > -1 && table[x, y] == table[ptr, y])
                {
                    ptr--;
                    kCnt++;
                }
            }
            if (dir == Dir.T)
            {
                ptr = y - 1;
                while (ptr > -1 && table[x, y] == table[x, ptr])
                {
                    ptr--;
                    kCnt++;
                }
            }

            return kCnt;
        }

        /// <summary>
        /// 掉落处理
        /// </summary>
        /// <param name="table">数据对象</param>
        private void fall(int[,] table)
        {
            for (int i = 0; i < ARRAY_SIZE; i++)
            {
                for (int j = ARRAY_SIZE - 1; j > -1; j--)
                {
                    int c = j;
                    while (table[j, i] == 0 && c-- > 0)
                    {
                        for (int k = j; k > 0; k--)
                        {
                            table[k, i] = table[k - 1, i];
                        }
                        table[0, i] = 0;
                    }
                }
            }
            dbg("--[FALLED]----------------------------", true);
            for (int i = 0; i < ARRAY_SIZE; i++)
            {
                for (int j = 0; j < ARRAY_SIZE; j++)
                {
                    dbg(SYMBOL1[table[i, j]]);
                }
                dbg("\n");
            }
        }

        /// <summary>
        /// 得分算法
        /// </summary>
        /// <param name="num">数量</param>
        /// <returns>分数</returns>
        private int calcVal(int num)
        {
            return num > 0 ? (num + 2) * (num + 2) : 0;
        }

        /// <summary>
        /// 转向
        /// </summary>
        /// <param name="dir">方向</param>
        /// <returns>转向后的方向</returns>
        private Dir turn(Dir dir)
        {
            if (dir == Dir.D)
                return Dir.R;
            if (dir == Dir.R)
                return Dir.D;
            return Dir.N;
        }

        /// <summary>
        /// 反向
        /// </summary>
        /// <param name="dir">方向</param>
        /// <returns>反向</returns>
        private Dir back(Dir dir)
        {
            if (dir == Dir.R)
                return Dir.L;
            if (dir == Dir.L)
                return Dir.R;
            if (dir == Dir.T)
                return Dir.D;
            if (dir == Dir.D)
                return Dir.T;
            return Dir.N;
        }

        [Conditional("dbg")]
        private void dbg(String msg)
        {
            Console.Write(msg);
        }
        private void dbg(String msg, bool ret)
        {
            dbg(msg + "\n");
        }

        /// <summary>
        /// 自动查找(最优)
        /// </summary>
        /// <returns>是否成功</returns>
        public bool run()
        {
            List<KeyLine> srs = new List<KeyLine>();
            int score;
            for (int i = 0; i < ARRAY_SIZE; i++)
            {
                for (int j = 0; j < ARRAY_SIZE - 1; j++)
                {
                    score = tryAct(new Point(i, j), new Point(i, j + 1));
                    if (score > 0)
                    {
                        KeyLine kl = new KeyLine();
                        kl.x1 = i;
                        kl.x2 = i;
                        kl.y1 = j;
                        kl.y2 = j + 1;
                        kl.cx = score;
                        srs.Add(kl);
                    }
                    score = tryAct(new Point(j, i), new Point(j + 1, i));
                    if (score > 0)
                    {
                        KeyLine kl = new KeyLine();
                        kl.x1 = j;
                        kl.x2 = j + 1;
                        kl.y1 = i;
                        kl.y2 = i;
                        kl.cx = score;
                        srs.Add(kl);
                    }
                }
            }
            srs.Sort();

            if (srs.Count > 0)
            {
                KeyLine kl = srs[srs.Count - 1];
                int[,] p = new int[1, 4];
                p[0, 0] = kl.getPoint1().X;
                p[0, 1] = kl.getPoint1().Y;
                p[0, 2] = kl.getPoint2().X;
                p[0, 3] = kl.getPoint2().Y;
                perform(p, 3);
                score = action(kl.getPoint1(), kl.getPoint2());
                if (score > 0)
                {
                    dbg("==[RESULT]=======================", true);
                    dbg("Point:" + kl.x1 + "," + kl.y1 + "<=>" + kl.x2 + "," + kl.y2 + "  " + score, true);
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 自动查找(最快)
        /// </summary>
        /// <returns>是否成功</returns>
        public bool run2()
        {
            int score;
            for (int i = ARRAY_SIZE - 1; i >= 0; i--)
            {
                for (int j = ARRAY_SIZE - 2; j >= 0; j--)
                {
                    score = tryAct(new Point(i, j), new Point(i, j + 1));
                    if (score > 0)
                    {
                        int[,] p = new int[1, 4];
                        p[0, 0] = i;
                        p[0, 1] = j;
                        p[0, 2] = i;
                        p[0, 3] = j + 1;
                        perform(p, 3);
                        score = action(new Point(i, j), new Point(i, j + 1));
                        if (score > 0)
                        {
                            dbg("==[RESULT]=======================", true);
                            dbg("Point:" + i + "," + i + "<=>" + i + "," + (j + 1) + "  " + score, true);
                            return true;
                        }
                    }
                    score = tryAct(new Point(j, i), new Point(j + 1, i));
                    if (score > 0)
                    {
                        int[,] p = new int[1, 4];
                        p[0, 0] = j;
                        p[0, 1] = i;
                        p[0, 2] = j + 1;
                        p[0, 3] = i;
                        perform(p, 3);
                        score = action(new Point(j, i), new Point(j + 1, i));
                        if (score > 0)
                        {
                            dbg("==[RESULT]=======================");
                            dbg("Point:" + j + "," + i + "<=>" + (j + 1) + "," + i + "  " + score, true);
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
    enum Dir
    {
        T, D, L, R, N
    }

    class KeyLine : IComparable<KeyLine>
    {
        public int x1;
        public int x2;
        public int y1;
        public int y2;
        public int cx;
        public int cy;
        public Dir dir;

        /// <summary>
        /// 消除链中个单元格(不含原点)
        /// </summary>
        /// <returns></returns>
        public List<Point> getPoints()
        {
            List<Point> pts = new List<Point>();
            if (dir == Dir.D)
            {
                for (int i = y1; i <= y2; i++)
                {
                    if (i != cy)
                    {
                        pts.Add(new Point(cx, i));
                    }
                }
            }
            if (dir == Dir.R)
            {
                for (int i = x1; i <= x2; i++)
                {
                    if (i != cx)
                    {
                        pts.Add(new Point(i, cy));
                    }
                }
            }
            return pts;
        }

        public Point getPoint1()
        {
            return new Point(x1, y1);
        }

        public Point getPoint2()
        {
            return new Point(x2, y2);
        }

        public int CompareTo(KeyLine arg0)
        {
            if (cx.Equals(arg0.cx))
            {
                if (x1.Equals(x2))
                {
                    return y2.CompareTo(arg0.y2);
                }
                return x2.CompareTo(arg0.x2);
            }
            return cx.CompareTo(arg0.cx);
        }
    }
}
