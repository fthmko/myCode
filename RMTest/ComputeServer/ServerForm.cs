using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Threading;
using GridLib;

namespace ComputeServer
{
    public partial class ServerForm : Form
    {
        String myAddr;
        Queue ips;
        Queue tasks;
        String taskName;

        public ServerForm()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            this.Icon = ComputeServer.Properties.Resources.Server;
        }

        private void ServerForm_Load(object sender, EventArgs e)
        {
            LoginService.CallBack = new LoginCallBack(RefreshList);
            GridTool.RegistPort(GridTool.ServerPort);
            GridTool.RegistSingleton(typeof(LoginService), "LoginService");
            myAddr = GridTool.GetIp();
            ips = Queue.Synchronized(new Queue());
            tasks = Queue.Synchronized(new Queue());

            taskName = "NumCompute";
        }

        private void RefreshList(string addr)
        {
            new Thread(new ThreadStart(_RefreshList)).Start();
        }

        private void _RefreshList()
        {
            lstClient.Items.Clear();
            lstClient.Items.AddRange(LoginService.Clients.ToArray());
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            tasks.Clear();
            if (btnRun.Text == "Run")
            {
                for (long a = 100000000000100; a < 100000000010100; a++)
                {
                    tasks.Enqueue(a);
                }
                Compute(taskName);
                if (LoginService.Clients.Count > 0)
                    btnRun.Text = "Stop";
            }
            else
            {
                btnRun.Text = "Run";
            }
        }

        private void Compute(String name)
        {
            if (File.Exists(Application.StartupPath + "\\" + name + ".mod"))
                File.Delete(Application.StartupPath + "\\" + name + ".mod");
            File.Copy(Application.StartupPath + "\\" + name + ".dll", Application.StartupPath + "\\" + name + ".mod");
            FileStream fs = new FileStream(Application.StartupPath + "\\" + name + ".mod", FileMode.Open);
            byte[] asmFile = new byte[fs.Length];
            fs.Read(asmFile, 0, (int)fs.Length);
            fs.Close();
            File.Delete(Application.StartupPath + "\\" + name + ".mod");
            ips.Clear();

            for (int i = LoginService.Clients.Count - 1; i >= 0; i--)
            {
                try
                {
                    INodeService node = (INodeService)GridTool.GetRemoteObj(typeof(INodeService), LoginService.Clients[i], GridTool.NodePort, "NodeService");
                    if (node.RegistTask(name, asmFile))
                    {
                        ips.Enqueue(LoginService.Clients[i]);
                        new Thread(new ThreadStart(RunCore)).Start();
                    }
                    else
                    {
                        LoginService.Clients.RemoveAt(i);
                    }
                }
                catch
                {
                    LoginService.Clients.RemoveAt(i);
                }
            }
            RefreshList("");
        }

        [MethodImplAttribute(MethodImplOptions.Synchronized)]
        private Object getTask()
        {
            if (tasks.Count == 0) return null;
            return tasks.Dequeue();
        }

        private void RunCore()
        {
            if (ips.Count == 0) return;
            string ip = (string)ips.Dequeue();
            log(ip + " Start!");
            var grid = (NumCompute.GridTask)GridTool.GetRemoteObj(typeof(NumCompute.GridTask), ip, GridTool.NodePort, taskName);
            Object task;
            try
            {
                while ((task = getTask()) != null)
                {
                    if (grid.Run((long)task))
                        log(ip + "  " + task);
                }
            }
            catch
            {
                log(ip + " Exit!");
            }
        }

        private void log(Object o)
        {
            Console.WriteLine(o);
        }
    }
}
