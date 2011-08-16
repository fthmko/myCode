using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;
using AeroForm;

namespace Simd
{
    public partial class Main : AeroForm.AeroForm
    {
        // 单元格大小
        public const int SIZE = 45;
        // 部分动画帧数
        public const int FRAME = 9;
        // 部分动画延迟
        private const int DELAY = 100;
        // 各种颜色
        public Color[] STYLES = { Color.White, Color.SkyBlue, Color.OrangeRed, Color.LawnGreen, Color.Gold, Color.SeaGreen, Color.Fuchsia, Color.Purple, Color.RoyalBlue };
        // 游戏对象
        private Game gm;
        // 最后单击的单元格
        private Button lastClick;
        // 是否暂停
        public bool Pause;
        // 所有单元格
        private List<Button> blocks;
        // 上次数据
        private int[,] otable;


        public Main()
        {
            InitializeComponent();
            base.InitAero();
            base.SetMesure(label5);
            this.Icon = global::Simd.Properties.Resources.regedit;
            Control.CheckForIllegalCrossThreadCalls = false;
            Pause = true;
            STYLES[0] = bg.BackColor;//btnStart.BackColor;
            blocks = new List<Button>();
            for (int i = 0; i < Game.ARRAY_SIZE; i++)
            {
                for (int j = 0; j < Game.ARRAY_SIZE; j++)
                {
                    Button btn = new Button();
                    btn.Height = SIZE;
                    btn.Width = SIZE;
                    btn.Top = i * SIZE;
                    btn.Left = j * SIZE;
                    btn.TabStop = false;
                    btn.Click += new EventHandler(btn_Click);
                    btn.Tag = new Point(i, j);
                    btn.BackColor = STYLES[0];
                    btn.FlatAppearance.BorderSize = 0;
                    bg.Controls.Add(btn);
                    blocks.Add(btn);
                }
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            bg.Visible = false;
            foreach (Button btn in blocks)
            {
                btn.Top = 0;
            }
            bg.Visible = true;

            // 开始游戏
            gm = new Game(20, perform);
            refreshValue();
            Pause = false;
            btnStart.Enabled = false;
            //gm.run();
        }

        /// <summary>
        /// 画面刷新回调
        /// </summary>
        /// <param name="DataTable">数据</param>
        /// <param name="tp">类型</param>
        private void perform(int[,] DataTable, int tp)
        {
            Pause = true;

            // 交换动作
            if (tp == 3)
            {
                swap(blocks[DataTable[0, 0] * Game.ARRAY_SIZE + DataTable[0, 1]], blocks[DataTable[0, 2] * Game.ARRAY_SIZE + DataTable[0, 3]]);
                Thread.Sleep(DELAY / 2);
                return;
            }
            Button btn;
            List<Button> eff = new List<Button>();
            List<int> val = new List<int>();

            // 第一帧
            for (int i = 0; i < Game.ARRAY_SIZE; i++)
            {
                for (int j = 0; j < Game.ARRAY_SIZE; j++)
                {
                    btn = blocks[i * Game.ARRAY_SIZE + j];
                    // 消除动作
                    if (tp == 2)
                    {
                        if (DataTable[i, j] == 0)
                        {
                            btn.FlatStyle = FlatStyle.Flat;
                            eff.Add(btn);
                        }
                    }
                    // 新增动作
                    else if (tp <= 0)
                    {
                        if (tp < 0 || btn.BackColor == STYLES[0])
                        {
                            btn.Top = i * SIZE / 3;
                            btn.FlatStyle = FlatStyle.Standard;
                            btn.BackColor = STYLES[DataTable[i, j]];
                            eff.Add(btn);
                        }
                    }
                    // 其他
                    else if (tp == 1)
                    {
                        if (DataTable[i, j] != otable[i, j])
                        {
                            if (DataTable[i, j] == 0)
                            {
                                btn.FlatStyle = FlatStyle.Flat;
                            }
                            else
                            {
                                btn.FlatStyle = FlatStyle.Standard;
                            }
                            btn.BackColor = STYLES[DataTable[i, j]];
                        }
                    }
                }
            }
            Update();
            Thread.Sleep(DELAY);
            // 第二帧
            for (int i = 0; i < eff.Count; i++)
            {
                if (tp == 2)
                {
                    //eff[i].BackColor = STYLES[0];
                }
                else if (tp <= 0)
                {
                    eff[i].Top *= 2;
                }
                else if (tp == 1)
                {

                }
            }
            Update();
            Thread.Sleep(DELAY);
            // 第三帧
            for (int i = 0; i < eff.Count; i++)
            {
                if (tp == 2)
                {
                    eff[i].BackColor = STYLES[0];
                }
                else if (tp <= 0)
                {
                    eff[i].Top = (eff[i].Top / 2) * 3;
                }
                else if (tp == 1)
                {

                }
            }
            otable = (int[,])DataTable.Clone();
            Update();
            Thread.Sleep(10);
        }

        private void btn_Click(object sender, EventArgs e)
        {
            if (Pause) return;
            Button btn = (Button)sender;
            if (lastClick == null)
            {
                lastClick = btn;
                lastClick.FlatStyle = FlatStyle.Flat;
            }
            else
            {
                lastClick.FlatStyle = FlatStyle.Standard;
                // 判断两次单击是否相邻
                if (isNext(lastClick, btn))
                {
                    Pause = true;
                    // 交换位置
                    swap(lastClick, btn);
                    Button t = lastClick;
                    new Thread(delegate()
                    {
                        Thread.Sleep(10);
                        // 判断交换是否有效
                        if (gm.tryAct((Point)t.Tag, (Point)btn.Tag) > 0)
                        {
                            Pause = true;
                            // 消除处理
                            gm.action((Point)t.Tag, (Point)btn.Tag);
                            refreshValue();
                            lastClick = null;
                        }
                        else
                        {
                            swap(lastClick, btn);
                            Pause = false;
                        }
                    }).Start();
                    return;
                }
                else
                {
                    lastClick = btn;
                    lastClick.FlatStyle = FlatStyle.Flat;
                }
            }
        }

        private bool isNext(Button a, Button b)
        {
            if (a.Left == b.Left && Math.Abs(a.Top - b.Top) == SIZE) return true;
            if (a.Top == b.Top && Math.Abs(a.Left - b.Left) == SIZE) return true;
            return false;
        }

        private void swap(Button a, Button b)
        {
            int offset1 = (a.Top - b.Top) / FRAME;
            int offset2 = (a.Left - b.Left) / FRAME;
            int cnt = 0;

            while (cnt++ < FRAME)
            {
                a.Top -= offset1;
                a.Left -= offset2;
                b.Top += offset1;
                b.Left += offset2;
                Update();
                Thread.Sleep(DELAY / 5);
            }
            Point tag = (Point)a.Tag;
            a.Tag = b.Tag;
            b.Tag = tag;
            blocks[tag.X * Game.ARRAY_SIZE + tag.Y] = b;
            tag = (Point)a.Tag;
            blocks[tag.X * Game.ARRAY_SIZE + tag.Y] = a;
        }

        private void btnRun1_Click(object sender, EventArgs e)
        {
            if (Pause || gm == null) return;
            new Thread(delegate()
            {
                while (refreshValue())
                {
                    if (!gm.run())
                    {
                        if (refreshValue()) gm.refill();
                    }
                }
            }).Start();
        }

        private void btnRun2_Click(object sender, EventArgs e)
        {
            if (Pause || gm == null) return;
            new Thread(delegate()
            {
                while (refreshValue())
                {
                    if (!gm.run2())
                    {
                        if (refreshValue()) gm.refill();
                    }
                }
            }).Start();
        }

        private bool refreshValue()
        {
            lblScore.Text = gm.TotalScore + "";
            lblStep.Text = gm.NowStep + "/" + gm.MaxStep;
            lblCombo.Text = gm.Combo + "";
            lblRefill.Text = gm.Refill + "";
            Pause = false;
            if (gm.NowStep >= gm.MaxStep)
            {
                btnStart.Enabled = true;
                Pause = true;
                return false;
            }
            return true;
        }
    }
}
