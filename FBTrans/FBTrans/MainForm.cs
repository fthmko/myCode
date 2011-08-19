using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using System.Text.RegularExpressions;
using System.ComponentModel;
using System.Linq;
using System.Threading;

namespace FBTrans
{
    /// <summary>
    /// Description of MainForm.
    /// </summary>
    public partial class MainForm : Form
    {
        const string insMsg = "insert into message(lang,version,translator,encode) values({0},{1},{2},{3});";
        const string insTag = "insert into tag(key,seq,name,value,parent,type) values({0},{1},{2},{3},{4},{5});";
        const string sltMsg = "select * from message order by lang,version desc";
        const string sltGrd = "select a.key,a.seq,a.name,(case when a.name in ('Plugin','BugCategory','Detector','BugPattern') then b.value when a.name='BugCode' then a.value else a.value end) value,a.parent,a.type from tag a left outer join (select value, parent from tag where name in('ShortDescription', 'Description', 'class')) b on b.parent = a.key where a.parent = (select key from tag where name='MessageCollection' and parent=(select key from tag where name={0})) and a.type in(1, -1) order by a.seq;";
        const string delMsg = "delete from message where lang={0} and version={1}";
        const string delTag = "delete from Tag where key={0}";
        const string sltTag_Name = "select * from tag where name={0}";
        const string sltTag_Prnt = "select * from tag where parent={0}";
        const string compact = "VACUUM";

        BindingList<MessageBean> msgList;
        MsgInfo msgForm;

        public MainForm()
        {
            InitializeComponent();
            this.Icon = global::FBTrans.Properties.Resources.cha;
            msgForm = new MsgInfo();
            Conn.Init();
            InitMsgList();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        #region procedure
        private void InitMsgList()
        {
            msgList = Conn.QueryB<MessageBean>(sltMsg);
            cbWork.DataSource = null;
            cbWork.DataSource = msgList;
            cbWork.DisplayMember = "Display";
        }

        private void ImportXML()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(msgForm.Path);
            XmlNode nd;
            TagBean root = new TagBean(getKey(), -1, msgForm.Lang + "%" + msgForm.Version, "", "1", TagType.ROOT);
            for (int i = 0; i < xmlDoc.ChildNodes.Count; i++)
            {
                nd = xmlDoc.ChildNodes[i];
                AddNode(root, nd);
            }

            int preV = prgBar.Value;
            int preM = prgBar.Maximum;
            string preT = lblPrg.Text;
            prgBar.Value = 0;
            prgBar.Maximum = root.GetCount() + 1;
            lblPrg.Text = "Import";
            this.Enabled = false;
            new Thread(delegate()
            {
                try
                {
                    InsertMessage(root);
                    InitMsgList();
                    msg("Success!");
                    this.Enabled = true;
                    prgBar.Maximum = preM;
                    prgBar.Value = preV;
                    lblPrg.Text = preT;
                }
                catch (Exception ex)
                {
                    msg("Failed!\n" + ex.Message);
                }
                finally
                {
                    this.Enabled = true;
                    prgBar.Maximum = preM;
                    prgBar.Value = preV;
                    lblPrg.Text = preT;
                }
            }).Start();

            //dbg(root.GenHead() + root.Subtags[0].GenXml());
        }

        private void AddNode(TagBean parent, XmlNode sub)
        {
            if (sub.Name == "xml")
            {
                parent.Value = sub.Value;
                return;
            }
            TagBean bean = new TagBean(getKey(), parent.Subtags.Count, sub.Name, sub.Value, parent.Key, TagType.TAG);
            if (sub.Attributes != null)
            {
                for (int i = 0; i < sub.Attributes.Count; i++)
                {
                    XmlAttribute xa = sub.Attributes[i];
                    TagBean attr = new TagBean(getKey(), bean.Attributes.Count, xa.Name, xa.Value, bean.Key, TagType.ATTRIBUTE);
                    bean.Attributes.Add(attr);
                }
            }
            if (sub.ChildNodes != null)
            {
                for (int i = 0; i < sub.ChildNodes.Count; i++)
                {
                    XmlNode nd = sub.ChildNodes[i];
                    if (nd.Name == "#text" || nd.Name == "#cdata-section")
                    {
                        bean.Value = sub.InnerXml;
                    }
                    else
                    {
                        AddNode(bean, nd);
                    }
                }
            }
            parent.Subtags.Add(bean);
        }

        private void InsertMessage(TagBean root)
        {
            prgBar.Value++;
            if (!Conn.Execute(insMsg, root.Name.Split('%')[0], root.Name.Split('%')[1], "findbugs", findText(root.Value, "(?<=encoding=\").+?(?=\")")))
            {
                throw new Exception("Exist lang & version!");
            }
            InsertTag(root);
        }

        private void InsertTag(TagBean tag)
        {
            prgBar.Value++;
            if (!Conn.Execute(insTag, tag.Key, tag.Seq, tag.Name, tag.Value, tag.Parent, tag.Type))
            {
                throw new Exception("FAIL INSERT TAG:" + tag.Name + "\n" + tag.GenHead());
            }
            foreach (TagBean attr in tag.Attributes)
            {
                prgBar.Value++;
                if (!Conn.Execute(insTag, attr.Key, attr.Seq, attr.Name, attr.Value, attr.Parent, attr.Type))
                {
                    throw new Exception("FAIL INSERT ATTRIBUTE:" + attr.Name + "\n" + tag.GenHead());
                }
            }
            foreach (TagBean sub in tag.Subtags)
            {
                InsertTag(sub);
            }
        }

        private void DeleteTag(TagBean tag)
        {
            List<TagBean> childs = Conn.Query<TagBean>(sltTag_Prnt, tag.Key);
            Conn.Execute(delTag, tag.Key);
            foreach (TagBean child in childs)
            {
                Conn.Execute(delTag, child.Key);
                DeleteTag(child);
            }
        }
        #endregion

        #region assistant
        public string findText(string src, string reg)
        {
            MatchCollection mc = Regex.Matches(src, reg, RegexOptions.IgnoreCase);
            if (mc.Count < 1) return "";
            return mc[0].Value;
        }

        private string getKey()
        {
            return Guid.NewGuid().ToString();
        }

        private void dbg(string txt)
        {
            System.IO.File.WriteAllText(Environment.CurrentDirectory + "\\xdebug.log", txt);
        }

        private void msg(string txt)
        {
            MessageBox.Show(txt);
        }
        #endregion

        void BtnWorkClick(object sender, EventArgs e)
        {
            if (cbWork.SelectedIndex < 0)
            {
                return;
            }
            MessageBean msgBean = (MessageBean)cbWork.SelectedItem;
            BindingList<TagBean> gridData = Conn.QueryB<TagBean>(sltGrd, msgBean.Lang + "%" + msgBean.Version);
            dataView.DataSource = gridData;
            prgBar.Maximum = gridData.Count;
            prgBar.Value = (from t in gridData where t.Type > 0 select t).Count();
            if (prgBar.Value == prgBar.Maximum)
            {
                lblPrg.Text = "Finish";
                lblPrg.ForeColor = Color.Green;
            }
            else
            {
                lblPrg.Text = "Working";
                lblPrg.ForeColor = Color.Blue;
            }
        }

        void BtnNewButtonClick(object sender, EventArgs e)
        {
            MnuNewClick(sender, e);
        }

        void MnuNewClick(object sender, EventArgs e)
        {
            msgForm.Path = "";
            msgForm.Lang = "";
            msgForm.Version = "";
            if (msgForm.ShowEdit("New Message") == DialogResult.OK)
            {
                // TODO
            }
        }

        void MnuEditClick(object sender, EventArgs e)
        {
            if (cbWork.SelectedIndex < 0)
            {
                return;
            }
            MessageBean msgBean = (MessageBean)cbWork.SelectedItem;
            msgForm.Path = "";
            msgForm.Lang = msgBean.Lang;
            msgForm.Version = msgBean.Version;
            if (msgForm.ShowEdit("Edit Message") == DialogResult.OK)
            {
                // TODO UPDATE
            }
        }

        void MnuRemoveClick(object sender, EventArgs e)
        {
            if (cbWork.SelectedIndex < 0)
            {
                return;
            }
            MessageBean msgBean = (MessageBean)cbWork.SelectedItem;
            if (MessageBox.Show("Are you sure to delete message [" + msgBean.Display + "]?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Enabled = false;
                Conn.Execute(delMsg, msgBean.Lang, msgBean.Version);
                List<TagBean> lb = Conn.Query<TagBean>(sltTag_Name, msgBean.Lang + "%" + msgBean.Version);
                if (lb.Count > 0)
                {
                    DeleteTag(lb[0]);
                    Conn.Execute(compact);
                    InitMsgList();
                }
                this.Enabled = true;
            }
        }

        void MnuImportClick(object sender, EventArgs e)
        {
            msgForm.Path = "";
            msgForm.Lang = "";
            msgForm.Version = "";
            if (msgForm.ShowNew("Import Message") == DialogResult.OK)
            {
                ImportXML();
            }
        }

        void MnuExportClick(object sender, EventArgs e)
        {
            if (cbWork.SelectedIndex < 0)
            {
                return;
            }
            MessageBean msgBean = (MessageBean)cbWork.SelectedItem;
        }
    }
}
