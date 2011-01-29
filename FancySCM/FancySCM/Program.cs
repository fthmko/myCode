using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Reflection;
using System.IO;
namespace FancySCM
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
            string directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetModules()[0].FullyQualifiedName);
            if (!OneInstance.IsFirst("fancy"))
            {
                MessageBox.Show("程序已运行！", "提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
            if (File.Exists(directory + "\\stdb.accdb"))
                if (Directory.Exists(directory + "\\CardImage"))
                    if (File.Exists(directory + "\\ImageData\\default.bmp"))
                    {
                        Application.Run(new FancySCM());
                        return;
                    }
            MessageBox.Show("文件丢失，请重新拷贝此程序及附属文件！", "无法运行", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }
    }
    public abstract class OneInstance
    {
        public static bool IsFirst(string appId)
        {
            bool ret = false;
            if (OpenMutex(0x1F0001, 0, appId) == IntPtr.Zero)
            {
                CreateMutex(IntPtr.Zero, 0, appId);
                ret = true;
            }
            return ret;
        }

        [DllImport("Kernel32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr OpenMutex(
        uint dwDesiredAccess,
        int bInheritHandle,
        string lpName
        );

        [DllImport("Kernel32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr CreateMutex(
        IntPtr lpMutexAttributes,
        int bInitialOwner,
        string lpName
        );
    } 
}
