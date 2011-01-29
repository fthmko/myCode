using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace VolSet
{
    class Program
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, uint wParam, uint lParam);

        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", EntryPoint = "FindWindowEx")]
        private static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        [DllImport("User32.dll", EntryPoint = "ShowWindow")]
        private static extern bool ShowWindow(IntPtr hWnd, int type);

        const uint WM_APPCOMMAND = 0x319;
        const uint APPCOMMAND_VOLUME_MUTE = 0x08;
        const uint APPCOMMAND_VOLUME_UP = 0x0a;  
        const uint APPCOMMAND_VOLUME_DOWN = 0x09; 

        static IntPtr Self;
        static int volnow;

        static void Main(string[] args)
        {
            Console.Title = "VolSet";
            Self = new IntPtr(0);
            Self = FindWindow(null, "VolSet");
            if (Self.Equals(IntPtr.Zero))
            {
                Console.WriteLine("Error!");
            }
            else
            {
                if (args.Length == 0) Console.WriteLine("请查看使用说明。");
                else
                {
                    if (args[0] == "mode1")
                    {
                        ShowWindow(Self, 0);
                        if (args.Length == 3)
                            MuteFun(Convert.ToInt32(args[1]), Convert.ToInt32(args[2]));
                        else MuteFun(0, 24);
                    }
                    else if (args[0] == "mode2")
                    {
                        ShowWindow(Self, 0);
                        if (args.Length == 5)
                            VolFun(Convert.ToInt32(args[1]), Convert.ToInt32(args[2]), Convert.ToInt32(args[3]), Convert.ToInt32(args[4]));
                        else VolFun(0, 24, 0, 25);
                    }
                    else if (args[0] == "up")
                    {
                        if (args.Length == 2)
                            VolUp(Convert.ToInt32(args[1]));
                        else VolUp();
                    }
                    else if (args[0] == "down")
                    {
                        if (args.Length == 2)
                            VolDown(Convert.ToInt32(args[1]));
                        else VolDown();
                    }
                    else if (args[0] == "mute") Mute();
                    else if (args[0] == "set" && args.Length == 2)
                        VolValue(Convert.ToInt32(args[1]));
                    else if (args[0] == "lock" && args.Length == 2)
                    {
                        ShowWindow(Self, 0);
                        VolLock(Convert.ToInt32(args[1]));
                    }
                }
            }
        }
        static void Useage()
        {
            Console.WriteLine("参数错误。");
        }
        static void MuteFun(int a,int b)
        {
            if (a < 0) a = 0;
            if (b > 24) b = 24;
            if (b <= a) return;

            Random rd = new Random();
            while (true)
            {
                while (DateTime.Now.Hour >= a && DateTime.Now.Hour <= b)
                {
                    System.Threading.Thread.Sleep(rd.Next(100, 5000));
                    Mute();
                }
                System.Threading.Thread.Sleep(60000);
            }
        }
        static void VolFun(int c,int d,int a,int b)
        {
            if (a < 0) a = 0;
            if (b > 25) b = 25;
            if (c < 0) c = 0;
            if (d > 24) d = 24;
            if (d <= c) return;
            if (b <= a) return;

            Random rd = new Random();

            VolValue((a + b) / 2);
            volnow = (a + b) / 2;

            while (true)
            {
                while (DateTime.Now.Hour >= c && DateTime.Now.Hour <= d)
                {
                    if (rd.Next(0, 31) < 16)
                    {
                        VolDown();
                        volnow--;
                    }
                    else
                    {
                        VolUp();
                        volnow++;
                    }
                    if (volnow < a)
                    {
                        VolUp();
                        volnow++;
                    }
                    if (volnow > b)
                    {
                        VolDown();
                        volnow--;
                    }
                    System.Threading.Thread.Sleep(100);
                }
                System.Threading.Thread.Sleep(60000);
            }
        }
        static void VolValue(int c)
        {
            VolDown(25);
            VolUp(c);
        }
        static void VolLock(int c)
        {
            if (c < 0 || c > 25) return;
            while(true)
            {
                System.Threading.Thread.Sleep(10000);
                VolDown(25);
                VolUp(c);
            }
        }
        static void Mute()
        {
            SendMessage(Self, WM_APPCOMMAND, 0x200eb0, APPCOMMAND_VOLUME_MUTE * 0x10000);
        }
        static void VolDown()
        {
            SendMessage(Self, WM_APPCOMMAND, 0x30292, APPCOMMAND_VOLUME_DOWN * 0x10000);
        }
        static void VolDown(int ct)
        {
            if (ct > 25) ct = 25;
            while(ct-->0)
                SendMessage(Self, WM_APPCOMMAND, 0x30292, APPCOMMAND_VOLUME_DOWN * 0x10000);
        }
        static void VolUp()
        {
            SendMessage(Self, WM_APPCOMMAND, 0x30292, APPCOMMAND_VOLUME_UP * 0x10000);
        }
        static void VolUp(int ct)
        {
            if (ct > 25) ct = 25;
            while (ct-- > 0)
            SendMessage(Self, WM_APPCOMMAND, 0x30292, APPCOMMAND_VOLUME_UP * 0x10000);
        }
    }
}

/*
 * VB6中的代码
    Private Declare Sub keybd_event Lib "user32.dll" (ByVal bVk As Byte, ByVal bScan As Byte, ByVal dwFlags As Long, ByVal dwExtraInfo As Long)
    Const KEYEVENTF_KEYUP = &H2 '松开按键


    '用模拟按键来控制音量
    const jia =175 '增加音量的EVENT码
    const jian =174 '减低音量的EVENT码
    const jingyin =173 '静音

    private sub command1_click()

    keybd_event jian, 0, 0, 0
    keybd_event jian, 0, KEYEVENTF_KEYUP, 0 '模拟键按下和松开按键``这个是降低系统音量的代码`

    end sub 
 * 
 * VB6命令行参数
 *  比如   c:\a\a.exe   lksjfdksf  
    则：command$="lksjfdksf"
*/