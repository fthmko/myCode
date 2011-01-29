using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace FancySCM
{
    public partial class FancySCM : Form
    {
        string strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=stdb.accdb";
        OleDbConnection dbcon;
        string saa = "select 姓名,性别,学院,专业,班级,学号,身份证号 from stdnfo";
        NRCD nrcd;
        TreeNode root;
        public static Image nowview;
        public static string directory;
        string[] data = new string[8];
        string stat = "制作：计算机053 27张争，22宋惊涛，04陈君超";

        public FancySCM()
        {
            InitializeComponent();
            directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetModules()[0].FullyQualifiedName);
        }

        private void FancySCM_Load(object sender, EventArgs e)
        {
            dbcon = new OleDbConnection(strConn);
            dbcon.Open();
            setgrid(0,"","");
            readdata();
            nrcd = new NRCD(root);
            dtGrid.Rows[0].Selected = true;
            refimg((string)dtGrid.Rows[0].Cells[5].Value);
            statlb.Text = stat;
        }

        private void setgrid(int idx,string stnm,string par)
        {
            string fls = saa;
            switch (idx)
            {
                case 0: break;
                case 1: fls = saa + " where 学院 = '" + stnm + "' order by 学号 ASC"; break;
                case 2: fls = saa + " where 专业 = '" + stnm + "' and 学院 = '" + par + "' order by 学号 ASC"; break;
                case 3: fls = saa + " where 班级 = '" + stnm + "' and 专业 = '" + par + "' order by 学号 ASC"; break;
            }
            DataSet dbset = selectq(fls, "stdnfo");
            dtGrid.DataSource = dbset;
            dtGrid.DataMember = "stdnfo";
            dtGrid.ColumnHeadersVisible = true;
            if (dbset.Tables[0].Rows.Count == 0)
            {
                tsb_del.Enabled = false;
                tsb_edit.Enabled = false;
                tsb_Make1.Enabled = false;
            }
            else
            {
                tsb_Make1.Enabled = true;
                tsb_edit.Enabled = true;
                tsb_del.Enabled = true;
            }
        }

        private void refgrid()
        {
            if (trStruct.SelectedNode != null)
                setgrid(trStruct.SelectedNode.Level, trStruct.SelectedNode.Text, trStruct.SelectedNode.Level == 0 ? "" : trStruct.SelectedNode.Parent.Text);
            else setgrid(0, "", "");
        }

        private void readdata()
        {
            string strxt = "select 学院 from colnfo order by 编号 ASC";
            trStruct.Nodes.Clear();
            DataSet dset = selectq(strxt, "colnfo");
            root = new TreeNode("大连工业大学");
            trStruct.Nodes.Add(root);
            foreach (DataRow rrrw in dset.Tables[0].Rows)
            {
                string nds = (string)rrrw[0];
                TreeNode nd = new TreeNode(nds);
                root.Nodes.Add(nd);
                
                string sb = "select 专业 from mjrnfo where 所属学院 = '" + nds + "' order by 编号 ASC";
                DataSet iset = selectq(sb, "mjrnfo");
                foreach (DataRow irrw in iset.Tables[0].Rows)
                {
                    string ids = (string)irrw[0];
                    TreeNode idd = new TreeNode(ids);
                    nd.Nodes.Add(idd);

                    string sc = "select 班级 from lsnfo where 所属专业 = '" + ids + "' order by 班级 ASC";
                    DataSet cset = selectq(sc, "lsnfo");
                    foreach (DataRow crrw in cset.Tables[0].Rows)
                    {
                        TreeNode cdd = new TreeNode((string)crrw[0]);
                        idd.Nodes.Add(cdd);
                    }
                }
            }
        }

        private DataSet selectq(string sql,string tabn)
        {
            OleDbCommand dbcmd = new OleDbCommand(sql, dbcon);
            OleDbDataAdapter dbadp = new OleDbDataAdapter();
            dbadp.SelectCommand = dbcmd;
            OleDbCommandBuilder dbbcb = new OleDbCommandBuilder(dbadp);
            DataSet dbset = new DataSet();
            dbadp.Fill(dbset,tabn);
            return dbset;
        }

        public void excsql(string sql)
        {
            OleDbCommand cmd = new OleDbCommand(sql, dbcon);
            cmd.ExecuteNonQuery();
        }

        private bool chk_exist(string tl, string tb, string data)
        {
            string strchk = "select * from " + tb + " where " + tl + "='" + data + "'";
            DataSet chk = selectq(strchk, tb);
            if (chk.Tables[0].Rows.Count != 0)
                return true;
            return false;
        }

        public void rmcol(string xh)
        {
            string dlsql = "delete from stdnfo where 学号='" + xh + "'";
            File.Delete(buildimg(xh));
            excsql(dlsql);
            dtGrid.Rows[0].Selected = true;
        }

        public bool adcol()
        {
            if (nrcd.ShowDialog() == DialogResult.Yes)
            {
                string fxh = buildxh();
                if (chk_exist("学号","stdnfo",fxh)||chk_exist("身份证号","stdnfo",nrcd.get_uf()))
                {
                    MessageBox.Show("学号或身份证号重复", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                string insq = "insert into stdnfo(姓名,性别,学院,专业,班级,学号,身份证号) values('"
                     + nrcd.get_nm() + "','" + nrcd.get_sx() + "','" + nrcd.get_xt() + "','" + nrcd.get_vr()
                      + "','" + nrcd.get_bj() + "','" + fxh + "','" + nrcd.get_uf() + "')";
                string fulpath = buildimg(fxh);
                if (File.Exists(fulpath))
                    if (filebusy(fulpath))
                    {
                        MessageBox.Show("无法生成照片文件" + fulpath, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                File.Copy(nrcd.get_img(), fulpath, true);
                excsql(insq);
                refgrid();
                dtGrid.Rows[0].Selected = true;
                nrcd.disp();
            }
            return true;
        }

        public bool edcol()
        {
            DataGridViewRow rw = dtGrid.SelectedRows[0];
            string oldxh = (string)rw.Cells[5].Value;
            nrcd.set_nm((string)rw.Cells[0].Value);
            nrcd.set_sx((string)rw.Cells[1].Value);
            nrcd.set_xt((string)rw.Cells[2].Value);
            nrcd.set_vr((string)rw.Cells[3].Value);
            nrcd.set_bj((string)rw.Cells[4].Value);
            nrcd.set_xh(oldxh.Substring(8, 2));
            nrcd.set_uf((string)rw.Cells[6].Value);
            nrcd.set_img(buildimg((string)rw.Cells[5].Value));

            if (nrcd.ShowDialog() == DialogResult.Yes)
            {
                string fxh = buildxh();
                if (nrcd.get_uf() != (string)rw.Cells[6].Value)
                    if (chk_exist("身份证号", "stdnfo", nrcd.get_uf()))
                    {
                        MessageBox.Show("身份证号重复", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;

                    }
                if(fxh != oldxh)
                    if (chk_exist("学号", "stdnfo", fxh))
                    {
                        MessageBox.Show("学号重复", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                string editstr =
                    string.Format("update stdnfo set 姓名 = '{0}',性别 = '{1}',学院 = '{2}',专业 = '{3}',班级 = '{4}',学号 = '{5}',身份证号 = '{6}' where 学号 = '{7}'",
                    nrcd.get_nm(), nrcd.get_sx(), nrcd.get_xt(), nrcd.get_vr(), nrcd.get_bj(), fxh, nrcd.get_uf(), (string)rw.Cells[5].Value);

                string fulpath = buildimg(fxh);
                if(File.Exists(fulpath))
                    if(filebusy(fulpath))
                    {
                        MessageBox.Show("无法生成照片文件" + fulpath, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                if(fulpath != nrcd.get_img())
                    File.Copy(nrcd.get_img(), fulpath, true);
                excsql(editstr);
                nrcd.disp();
                refgrid();
                dtGrid.Rows[0].Selected = true;
            }
            return true;
        }

        public static string buildimg(string xh)
        {
            string fulsrc = directory + "\\ImageData\\" + xh + ".bmp";
            return fulsrc;
        }

        private void trStruct_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            trStruct.SelectedNode = e.Node;
            string par = "";
            if (e.Node.Level != 0) par = e.Node.Parent.Text; 
            setgrid(e.Node.Level, e.Node.Text,par);
            switch (e.Node.Level)
            {
                case 3:
                case 2:
                    btn_nl.Enabled = true;
                    btn_nv.Enabled = true;
                    cm_NC.Enabled = true;
                    cm_NV.Enabled = true;
                    break;
                case 1:
                    btn_nl.Enabled = false;
                    btn_nv.Enabled = true;
                    cm_NV.Enabled = true;
                    cm_NC.Enabled = false;
                    break;
                case 0:
                    btn_nl.Enabled = false;
                    btn_nv.Enabled = false;
                    cm_NC.Enabled = false;
                    cm_NV.Enabled = false;
                    break;
                default: break;
            }

            imgVkpm.Image = null;
            if (dtGrid.Rows.Count != 0)
            {
                dtGrid.Rows[0].Selected = true;
                refimg((string)dtGrid.Rows[0].Cells[5].Value);
            }
            if (e.Button == MouseButtons.Right)
            {
                cmNode.Show(trStruct,e.X,e.Y);
            }
        }

        private string buildxh()
        {
            string bb = nrcd.get_bj();
            string fxh = bb.Substring(0, 2);
            string sel = "select 编号 from colnfo where 学院 = '" + nrcd.get_xt() + "'";
            DataSet tmp = selectq(sel, "colnfo");
            fxh += (string)tmp.Tables[0].Rows[0][0];
            sel = "select 编号 from mjrnfo where 专业 = '" + nrcd.get_vr() + "'";
            tmp = selectq(sel, "mjrnfo");
            fxh += (string)tmp.Tables[0].Rows[0][0];
            fxh = fxh + 0 + bb.Substring(2, 1) + nrcd.get_xh();
            return fxh;
        }

        private void btn_ns_Click(object sender, EventArgs e)
        {
            while(!adcol());
        }

        private void del_select()
        {
            if (MessageBox.Show("确定删除选中的记录？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                foreach (DataGridViewRow wld in dtGrid.SelectedRows)
                    rmcol((string)wld.Cells["学号"].Value);
            trStruct.SelectedNode = trStruct.Nodes[0];
            refgrid();
        }

        private void tsb_del_Click(object sender, EventArgs e)
        {
            del_select();   
        }

        private void dtGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            dtGrid.Rows[e.RowIndex].Selected = true;
            refimg((string)dtGrid.Rows[e.RowIndex].Cells[5].Value);
            tsb_del.Enabled = true;
            tsb_edit.Enabled = true;
            tsb_Make1.Enabled = true;
        }

        private void refimg(string xh)
        {
            string path = buildimg(xh);
            FileStream view;
            try
            {
                view = new FileStream(path, FileMode.Open);

            }
            catch (FileNotFoundException f)
            {
                view = new FileStream(buildimg("default"), FileMode.Open);
            }
            catch (DirectoryNotFoundException ff)
            {
                view = new FileStream(buildimg("default"), FileMode.Open);
            }
            nowview = Image.FromStream(view);
            view.Close();
            imgVkpm.Image = nowview;
        }

        private void tsb_edit_Click(object sender, EventArgs e)
        {
            nrcd.Text = "修改记录";
            string now = (string)dtGrid.SelectedRows[0].Cells[5].Value;
            while (!edcol()) ;
            refimg(now);
            nrcd.Text = "添加记录";
            tsb_edit.Enabled = false;
            tsb_del.Enabled = false;
            tsb_Make1.Enabled = false;
        }

        private void btn_ny_Click(object sender, EventArgs e)
        {
            add_xy();
        }

        private void btn_nv_Click(object sender, EventArgs e)
        {
            add_vy();
        }

        private void btn_nl_Click(object sender, EventArgs e)
        {
            add_bj();
        }

        private void add_xy()
        {
            NewOT ny = new NewOT("新学院");
            if (ny.ShowDialog() == DialogResult.OK)
            {
                if (chk_exist("学院", "colnfo", ny.getname()) || chk_exist("编号", "colnfo", ny.getbh()))
                {
                    MessageBox.Show("重复的学院名或编号", "错误", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                string sny = "insert into colnfo(学院,编号) values('" + ny.getname() + "','" + ny.getbh() + "')";

                excsql(sny);
                root.Nodes.Add(ny.getname());
                nrcd = new NRCD(root);
            }
        }

        private void add_vy()
        {
            NewOT ny = new NewOT("新专业");
            if (ny.ShowDialog() == DialogResult.OK)
            {
                string whr = string.Format(" = '{0}' and 所属学院 = '{1}'", ny.getname(), now2des(1).Text);
                if (chk_exist2("mjrnfo","专业"+whr) || chk_exist2("mjrnfo", "编号"+whr))
                {
                    MessageBox.Show("重复的专业名或编号", "错误", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                string sny = "insert into mjrnfo(专业,编号,所属学院) values('" + ny.getname() + "','" + ny.getbh() + "','" + now2des(1).Text + "')";
                excsql(sny);
                now2des(1).Nodes.Add(ny.getname());
            }
        }

        private void add_bj()
        {
            NewOT ny = new NewOT("新班级");
            if (ny.ShowDialog() == DialogResult.OK)
            {
                string whr = string.Format("班级 = '{0}' and 所属专业 = '{1}'", ny.getname(), now2des(2).Text);
                if (chk_exist2("lsnfo", whr))
                {
                    MessageBox.Show("重复的班级名", "错误", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                
                string sny = "insert into lsnfo(班级,所属专业) values('" + ny.getname() + "','" + now2des(2).Text + "')";
                excsql(sny);
                now2des(2).Nodes.Add(ny.getname());
            }
        }

        private bool chk_exist2(string tb, string wh)
        {
            string strchk = "select * from " + tb + " where " + wh;
            DataSet chk = selectq(strchk, tb);
            if (chk.Tables[0].Rows.Count != 0)
                return true;
            return false;
        }

        private TreeNode now2des(int d)
        {
            TreeNode now = trStruct.SelectedNode;
            while (now.Level > d)
                now = now.Parent;
            return now;
        }

        public static bool filebusy(string fileName)
        {
            bool inUse = true;
            FileStream fs = null;
            try
            {
                fs = new FileStream(fileName, FileMode.Open, FileAccess.Read,FileShare.None);
                inUse = false;
            }
            catch
            {
            }
            finally
            {
                if (fs != null)
                    fs.Close();
            }
            return inUse;
        }

        private void tsb_Make1_Click(object sender, EventArgs e)
        {
            buildmk();
            ShowCard mk = new ShowCard(MakeCard.kkuivg(data,nowview),"考试证");
            mk.ShowDialog();
        }

        private void buildmk()
        {
            data[0] = (string)dtGrid.SelectedRows[0].Cells[0].Value;
            data[1] = (string)dtGrid.SelectedRows[0].Cells[1].Value;
            data[2] = (string)dtGrid.SelectedRows[0].Cells[2].Value;
            data[3] = (string)dtGrid.SelectedRows[0].Cells[3].Value;
            data[4] = (string)dtGrid.SelectedRows[0].Cells[4].Value;
            data[5] = (string)dtGrid.SelectedRows[0].Cells[5].Value;
            data[6] = (string)dtGrid.SelectedRows[0].Cells[6].Value;
            data[7] = directory;
        }

        private void cm_NC_Click(object sender, EventArgs e)
        {
            add_bj();
        }

        private void cm_NV_Click(object sender, EventArgs e)
        {
            add_vy();
        }

        private void cm_NX_Click(object sender, EventArgs e)
        {
            add_xy();
        }

        private void dtGrid_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left&&dtGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected == true)
                dtGrid.Rows[e.RowIndex].Selected = true;
        }
    }
}
