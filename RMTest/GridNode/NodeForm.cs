using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GridLib;

namespace GridNode
{
    public partial class NodeForm : Form
    {
        string myAddr;
        List<string> cfg;

        public NodeForm()
        {
            InitializeComponent();
            this.Icon = GridNode.Properties.Resources.Grid;
        }

        private void NodeForm_Load(object sender, EventArgs e)
        {
            try
            {
                myAddr = GridTool.GetIp();

                GridTool.RegistPort(GridTool.NodePort);
                GridTool.RegistSingleCall(typeof(NodeService), "NodeService");
            }
            catch (Exception ex)
            {
                ShowError("Port is used by another program.", "Error!");
                Application.Exit();
            }

            cfg = (List<string>)tryLoad(Application.StartupPath + "/Server.dat");
            if (cfg == null)
            {
                cfg = new List<string>();
            }
            this.txtServer.AutoCompleteCustomSource = new AutoCompleteStringCollection();
            this.txtServer.AutoCompleteCustomSource.AddRange(cfg.ToArray());

            if (Directory.Exists(Environment.CurrentDirectory + "\\tasks"))
            {
                Directory.Delete(Environment.CurrentDirectory + "\\tasks", true);
            }
            Directory.CreateDirectory(Environment.CurrentDirectory + "\\tasks");

            AppDomain curDom = AppDomain.CurrentDomain;
            curDom.AssemblyResolve += new ResolveEventHandler(Domain_AssemblyResolve);
        }

        System.Reflection.Assembly Domain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            string fileName = args.Name.Split(',')[0];
            if (NodeService.asmLib.ContainsKey(fileName))
            {
                return System.Reflection.Assembly.Load(NodeService.asmLib[fileName]);
            }
            else
            {
                return System.Reflection.Assembly.LoadFile(Application.StartupPath + "\\tasks\\" + fileName + ".dll");
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (lstSrv.Items.Contains(txtServer.Text)) return;
            try
            {
                var ls = (ILoginService)GridTool.GetRemoteObj(typeof(ILoginService), txtServer.Text, GridTool.ServerPort, "LoginService");
                ls.Login(myAddr);

                lstSrv.Items.Add(txtServer.Text);
                if (!cfg.Contains(txtServer.Text))
                {
                    this.txtServer.AutoCompleteCustomSource.Add(txtServer.Text);
                    cfg.Add(txtServer.Text);
                    trySave(cfg, Application.StartupPath + "/Server.dat");
                }
            }
            catch (Exception ex)
            {
                ShowError(ex.Message, "Login Fail!");
            }
        }

        private void ShowError(String txt, String title)
        {
            MessageBox.Show(txt, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #region SAVE&LOAD
        private void trySave(object o, string path)
        {
            var sr = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            System.IO.Stream ss = null;
            try
            {
                ss = new System.IO.FileStream(path, System.IO.FileMode.Create);
                sr.Serialize(ss, o);
                ss.Flush();
            }
            catch
            {
            }
            finally
            {
                if (ss != null)
                    ss.Close();
            }
        }

        private object tryLoad(string path)
        {
            object obj = null;
            var sr = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            System.IO.Stream ss = null;
            try
            {
                ss = new System.IO.FileStream(path, System.IO.FileMode.Open);
                obj = sr.Deserialize(ss);
            }
            catch
            {
            }
            finally
            {
                if (ss != null)
                    ss.Close();
            }
            return obj;
        }
        #endregion
    }
}
