using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

namespace AIbzdjc
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (File.Exists("DotNetSpeech.dll"))
                Application.Run(new Form1());
            else MessageBox.Show(".Net Speech Support Missing!","Error");
        }
    }
}
