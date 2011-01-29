using System;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.IO;

namespace pathTool
{
    class Program
    {
        static System.IO.StreamWriter fs;
        [STAThread]
        static void Main(string[] args)
        {
            Thread.Sleep(50);
            doing();
            /*
            ThreadLocker.GetInstance().CreateLock();
            fs = new StreamWriter(new FileStream("d:\\temp\\log.txt", FileMode.Append, FileAccess.Write));
            fs.WriteLine();
            if (!System.IO.File.Exists("pathTool"))
            {
                fs.WriteLine("First Run:" + args[0]);
                Clipboard.SetText(args[0]);
            }
            else
            {
                fs.WriteLine("Other Run:" + args[0]);
                String txt = Clipboard.GetText();
                fs.WriteLine("------before------");
                fs.WriteLine(txt);
                fs.WriteLine("------after------");
                txt = txt + "\n" + args[0];
                fs.WriteLine(txt);
                fs.WriteLine("-------end-------");
                Clipboard.SetText(txt);
            }
            sendMsg();
            fs.Flush();
            fs.Close();
            ThreadLocker.GetInstance().ReleaseLock();*/
        }
        static void doing()
        {
            Process current = Process.GetCurrentProcess();
            Process[] processes = Process.GetProcessesByName(current.ProcessName);
            fs = new StreamWriter(new FileStream("d:\\temp\\log.txt", FileMode.Append, FileAccess.Write));
            foreach (Process process in processes)
            {
                if (process.Id != current.Id)
                {
                    //fs.WriteLine("--Create Lock S");
                    //if (!System.IO.File.Exists("pathTool")) System.IO.File.Create("pathTool");
                    //fs.WriteLine("--Create Lock E");
                    return;
                }
            }
            //fs.WriteLine("--Delete Lock S");
            //if (System.IO.File.Exists("pathTool")) System.IO.File.Delete("pathTool");
            //fs.WriteLine("--Delete Lock E");
        }
    }
}
