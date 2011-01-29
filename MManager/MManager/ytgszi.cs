using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.IO;

namespace MManager
{
    public partial class ytgszi : Form
    {
        string stryrgs = "select 工号,姓名,职务,学历 from 员工信息";
        string strbase = "select 基本工资 from 职务信息 where 职务名称 = ''";
        string strfuli = "select 工资奖励 from 学历信息 where 学历名称 = ''";
        string striuqn = "select 出勤情况 from 出勤记录 where 工号 = '' and 日期 BETWEEN ## and ##";
        string strjwbj = "select 加班类型,加班时间 from 加班记录 where 工号 = '' and 日期 BETWEEN ## and ##";
        string strjdjn = "select 奖金名称 from 奖金记录 where 工号 = ''";
        string strkb = "select 扣款金额 from 扣款类型 where 扣款名称 = ''";
        string strjd = "select 奖金金额 from 奖金类型 where 奖金名称 = ''";
        string strjw = "select 加班奖金 from 加班信息 where 加班类型 = ''";
        string cleartb1 = "delete from 本月工资表";
        string cleartb2 = "delete from 年终奖表";

        string bf_clr = "delete from []";
        string bf_crt1 = "create table []([工号] string(5) primary key,[姓名] string(20),[基本工资] money,"
            + "加班费 money,全勤奖 money,福利 money,扣款 money,应发工资 money,税款 money,实发工资 money); ";
        string bf_crt2 = "Create Unique Index 工号 ON [](工号);";
        string bf_cp = "insert into [](工号,姓名,基本工资,加班费,全勤奖,福利,扣款,应发工资,税款,实发工资) "
            + "select 工号,姓名,基本工资,加班费,全勤奖,福利,扣款,应发工资,税款,实发工资 from 本月工资表";
        bool qrqn = false;

        DateTime fsd;
        DateTime lsd;
        int total = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month-1);

        bool yom;
        string nyr;
        string bf2_crt1 = "create table []([工号] string(5) primary key,[姓名] string(20),[年终奖] money); ";
        string bf2_cp = "insert into [](工号,姓名,年终奖) select 工号,姓名,年终奖 from 年终奖表";

        string directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetModules()[0].FullyQualifiedName);

        public ytgszi(bool ym)
        {
            InitializeComponent();
            tb_gshk.KeyPress += new KeyPressEventHandler(tb_KeyPress);
            yom = ym;
            cb_ytff.Enabled = ym;
            initdata();
            bzff();
        }
        private void tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar) || e.KeyChar == '\b'))
            {
                e.Handled = true;
            }
        }
        private void initdata()
        {
            if (yom)
            {
                fsd = Convert.ToDateTime(DateTime.Now.AddMonths(-1).ToString("yyyy-MM-01"));
                lsd = fsd.AddDays(total - 1);
                fcdb.excsql(cleartb1);
                ca();
                DataSet temp = fcdb.selectq("select * from 本月工资表", "本月工资表");
                temp.WriteXml("data.xml", XmlWriteMode.IgnoreSchema);
                wbr.Navigate(directory + "\\data.xml");
            }
            else
            {
                nyr = DateTime.Now.AddYears(-1).Year.ToString();
                fcdb.excsql(cleartb2);
                ca2();
                DataSet temp = fcdb.selectq("select * from 年终奖表", "年终奖表");
                temp.WriteXml("data.xml", XmlWriteMode.IgnoreSchema);
                wbr.Navigate(directory + "\\data.xml");
            }
        }
        private void bzff()
        {
            if (yom)
            {
                string tbn = DateTime.Now.AddMonths(-2).ToString("yyyy-MM");
                string ba = bf_crt1.Insert(14, tbn);
                string bb = bf_crt2.Insert(27, tbn);
                string bc = bf_cp.Insert(13, tbn);
                if (fcdb.excsql(ba))
                {
                    fcdb.excsql(bb);
                    fcdb.excsql(bc);
                    return;
                }
                else
                {
                    fcdb.excsql(bf_clr.Insert(13, tbn));
                    fcdb.excsql(bc);
                }
            }
            else
            {
                string tbnn = nyr + "年终奖";
                string baa = bf2_crt1.Insert(14, tbnn);
                string bbb = bf_crt2.Insert(27, tbnn);
                string bcc = bf2_cp.Insert(13, tbnn);
                if (fcdb.excsql(baa))
                {
                    fcdb.excsql(bbb);
                    fcdb.excsql(bcc);
                    return;
                }
                else
                {
                    fcdb.excsql(bf_clr.Insert(13, tbnn));
                    fcdb.excsql(bcc);
                }
            }
        }
        private void ca()
        {
            decimal m_base;
            decimal m_qrqn;
            decimal m_fuli;
            decimal m_jwbj;
            decimal m_kbkr;
            decimal m_shd;
            decimal m_fee;
            decimal m_real;

            string hid;
            string hnm;
            string hviwu;
            string hxtli;

            string inss;
            DataSet yrgs = fcdb.selectq(stryrgs, "员工信息");
            foreach (DataRow ayrgs in yrgs.Tables[0].Rows)
            {
                hid = (string)ayrgs[0];
                hnm = (string)ayrgs[1];
                hviwu = (string)ayrgs[2];
                hxtli = (string)ayrgs[3];

                m_base = getbase(hviwu);
                m_fuli = getfuli(hxtli);
                m_kbkr = getkbkr(hid);
                if(qrqn)m_qrqn = getjdm("全勤奖");
                else m_qrqn = 0;
                m_jwbj = getjwbj(hid);
                m_shd = m_base + m_qrqn + m_fuli + m_jwbj - m_kbkr;
                m_fee = srfee(m_shd);
                m_real = m_shd - m_fee;

                inss = string.Format(
                    "insert into 本月工资表(工号,姓名,基本工资,加班费,全勤奖,福利,扣款,应发工资,税款,实发工资) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}')",
                    hid,hnm,m_base,m_jwbj,m_qrqn,m_fuli,m_kbkr,m_shd,m_fee,m_real);
                fcdb.excsql(inss);
            }
        }
        private void ca2()
        {
            string hid;
            string hnm;
            string strgtnm = "select 实发工资 from [] where 工号 = ''";//18,32
            string strinsq;
            decimal summ = 0;
            decimal gol = 0;

            string tmp1;
            string tmp2;

            DataSet yrgs = fcdb.selectq(stryrgs, "员工信息");
            DataSet cache;
            foreach (DataRow ayrgs in yrgs.Tables[0].Rows)
            {
                hid = (string)ayrgs[0];
                hnm = (string)ayrgs[1];

                for (int a = 1; a <= 12; a++)
                {
                    tmp2 = nyr + "-" + a;
                    tmp1 = strgtnm.Insert(18, tmp2);
                    cache = fcdb.selectq(strgtnm,tmp2);
                    if (fcdb.lstsq)
                        summ += (decimal)cache.Tables[0].Rows[0][0];
                }
                gol = decimal.Divide(summ, 12);
                strinsq = string.Format(
                    "insert into 年终奖表(工号,姓名,年终奖) values('{0}','{1}','{2}')", hid, hnm, gol);
                fcdb.excsql(strinsq);
            }
        }

        private decimal srfee(decimal all)
        {
            decimal[] lv = {0,500,2000,5000,20000,40000,60000,80000,100000};
            decimal[] yn = {0.05M,0.10M,0.15M,0.20M,0.25M,0.30M,0.35M,0.40M,0.45M};
            decimal part;
            decimal fee = 0;
            int i;
            for(i = 8;i>=0;i--)
                if (all > lv[i])
                {
                    part = all - lv[i];
                    fee += decimal.Multiply(part, yn[i]);
                    all -= part;
                }
            return fee;
            
        }
        private decimal getbase(string viwu)
        {
            return (decimal)fcdb.selectq(strbase.Insert(36, viwu), "职务信息").Tables[0].Rows[0][0];
        }
        private decimal getfuli(string xtli)
        {
            return (decimal)fcdb.selectq(strfuli.Insert(36, xtli), "学历信息").Tables[0].Rows[0][0];
        }
        private decimal getkbm(string km)
        {
            return (decimal)fcdb.selectq(strkb.Insert(36, km), "扣款类型").Tables[0].Rows[0][0];
        }
        private decimal getjdm(string jm)
        {
            return (decimal)fcdb.selectq(strjd.Insert(36, jm), "奖金类型").Tables[0].Rows[0][0];
        }
        private decimal getjwm(string jw)
        {
            return (decimal)fcdb.selectq(strjw.Insert(36, jw), "加班信息").Tables[0].Rows[0][0];
        }
        private DataSet fjwziaxp(string tbnm, string sqlstrb,string id)
        {
            string sestr = sqlstrb.Insert(59, lsd.ToShortDateString());
            sestr = sestr.Insert(52, fsd.ToShortDateString());
            sestr = sestr.Insert(34, id);
            return fcdb.selectq(sestr, tbnm);
        }
        private decimal getkbkr(string id)
        {
            decimal nw = new decimal(0);
            string tp;
            string kn = "正常";
            string kl = "迟到";
            string kq = "请假";
            string kk = "旷工";
            int cn = 0;
            int cl = 0;
            int cq = 0;
            int ck = 0;
            decimal dn, dl, dq, dk;

            dn = getkbm(kn);
            dl = getkbm(kl);
            dq = getkbm(kq);
            dk = getkbm(kk);

            DataSet iujnjilu = fjwziaxp("出勤记录", striuqn, id);

            foreach (DataRow ajilu in iujnjilu.Tables[0].Rows)
            {
                tp = (string)ajilu[0];
                if (tp == kn)
                {
                    cn++;
                    nw += dn;
                }
                else if (tp == kl)
                {
                    cl++;
                    nw += dl;
                }
                else if (tp == kq)
                {
                    cq++;
                    if(cq>3)nw += dq;
                }
            }
            if (cn == total) qrqn = true;
            ck = total - cn - cl - cq;
            if (ck > 0) nw += Decimal.Multiply(dk, new decimal(ck));

            return nw;
        }
        private decimal getjwbj(string id)
        {
            decimal nw = new decimal(0);
            string tp;
            int tq;
            string kn = "夜晚";
            string kw = "周末";
            string kh = "假日";
            int cn = 0;
            int cw = 0;
            int ch = 0;

            decimal dn, dw, dh;
            dn = getjwm(kn);
            dw = getjwm(kw);
            dh = getjwm(kh);

            string sestr = strjwbj.Insert(64, lsd.ToShortDateString());
            sestr = sestr.Insert(57, fsd.ToShortDateString());
            sestr = sestr.Insert(39, id);
            DataSet jwbjjilu = fcdb.selectq(sestr, "加班记录");

            foreach (DataRow ajilu in jwbjjilu.Tables[0].Rows)
            {
                tp = (string)ajilu[0];
                tq = (int)ajilu[1];
                if (tp == kn)
                {
                    cn += tq;
                }
                else if (tp == kw)
                {
                    cw += tq;
                }
                else if (tp == kh)
                {
                    ch += tq;
                }
            }
            if (cn > 0) nw += decimal.Multiply(dn, new decimal(cn));
            if (cw > 0) nw += decimal.Multiply(dw, new decimal(cw));
            if (ch > 0) nw += decimal.Multiply(dh, new decimal(ch));
            return nw;
        }
        private decimal getjdjn2(string id)
        {
            string jj = "进步奖";
            string jt = "突出奖";
            string jc = "创新奖";
            string tp;
            decimal dj, dt, dc;
            decimal nw = new decimal(0);
            dj = getjdm(jj);
            dt = getjdm(jt);
            dc = getjdm(jc);

            DataSet jdjnjilu = fcdb.selectq(strjdjn.Insert(34,id),"奖金记录");

            foreach(DataRow ajilu in jdjnjilu.Tables[0].Rows)
            {
                tp = (string)ajilu[0];
                if(tp == jj)
                {
                    nw += dj;
                }
                else if(tp == jt)
                {
                    nw += dt;
                }
                else if(tp == jc)
                {
                    nw += dc;
                }
            }
            return nw;
        }

        private void btn_prt_Click(object sender, EventArgs e)
        {
            wbr.ShowPrintDialog();
        }

        private void tb_sch_Click(object sender, EventArgs e)
        {
            string selstr = "select * from  where 1 = 1";
            string mth;
            if (yom) mth = "本月工资表";
            else mth = "年终奖表";
            string bumf = "";
            string gshk = "";
            bool bf = false;
            bool gh = false;
            if (cb_ytff.Text.Length > 0)
                if (cb_ytff.SelectedIndex != 0)
                    mth = (new DateTime(DateTime.Now.Year, cb_ytff.SelectedIndex, 1)).ToString("yyyy-MM");
            if (cb_bumf.Text.Length > 0 && cb_bumf.SelectedIndex != 0)
            {
                bumf = cb_bumf.Text;
                bf = true;
            }
            if (tb_gshk.Text.Length != 0)
            {
                gshk = tb_gshk.Text;
                gh = true;
            }
            selstr = selstr.Insert(14,mth);
            if (bf)
            {
                bumf = bumf.Insert(0, " and 工号 in (select 工号 from 员工信息 where 部门 = '");
                bumf += "')";
                selstr += bumf;
            }
            if (gh)
            {
                gshk = gshk.Insert(0, " and 工号 = '");
                gshk += "'";
                selstr += gshk;
            }
            DataSet tep = fcdb.selectq(selstr,mth);
            tep.WriteXml("data.xml", XmlWriteMode.IgnoreSchema);
            wbr.Navigate(directory + "\\data.xml");
        }
    }
}
