using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Diagnostics;
using Microsoft.Win32;

namespace GetHide
{
    public partial class GetHide : Form
    {
        string rc;

        public GetHide()
        {
            InitializeComponent();
            rc = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetModules()[0].FullyQualifiedName);
        }

        private void check()
        {
            DirectoryInfo rcd = new DirectoryInfo(rc);
            DirectoryInfo[] icd = rcd.GetDirectories(); 
            FileInfo[] fils = rcd.GetFiles();
            foreach (FileInfo fi in fils)
            {
                if(!IsFileInUse(fi.FullName))
                    fi.Attributes = FileAttributes.Normal;
            }
            foreach (DirectoryInfo di in icd)
            {
                if (di.Name != "System Volume Information" && di.Name != "autorun.inf")
                    di.Attributes = FileAttributes.Normal;
            }
        }

        private void ShowHide_Click(object sender, EventArgs e)
        {
            ShowHide.Text = "正在执行...";
            ShowHide.Enabled = false;
            check();
            ShowHide.Text = "显示隐藏文件";
            ShowHide.Enabled = true;
        }

        private bool IsFileInUse(string fileName)
        {
            bool inUse = true;
            if (File.Exists(fileName))
            {
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
            else
            {
                return true;
            }
        }

        private void fix_Click(object sender, EventArgs e)
        {
            string rcy = rc + "\\RECYCLER";
            if(Directory.Exists(rcy))
            {
                DirectoryInfo rcycler = new DirectoryInfo(rcy);
                rcycler.Attributes |= FileAttributes.System;
                rcycler.Attributes |= FileAttributes.Hidden;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegistryKey hklm = Registry.LocalMachine;
            RegistryKey rt1 = hklm.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced\Folder\Hidden",true);
            rt1.SetValue("Text", "@shell32.dll,-30499",RegistryValueKind.String);
            rt1.SetValue("Type", "group", RegistryValueKind.String);
            rt1.SetValue("Bitmap", @"%SystemRoot%\system32\SHELL32.dll,4",RegistryValueKind.ExpandString);
            rt1.SetValue("HelpID", "shell.hlp#51131", RegistryValueKind.String);

            RegistryKey rt2 = rt1.OpenSubKey("NOHIDDEN",true);
            rt2.SetValue("CheckedValue", 2,RegistryValueKind.DWord);
            rt2.SetValue("DefaultValue", 2, RegistryValueKind.DWord);
            rt2.SetValue("HelpID", "shell.hlp#51104", RegistryValueKind.String);
            rt2.SetValue("HKeyRoot", -2147483647, RegistryValueKind.DWord);
            rt2.SetValue("RegPath", @"Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", RegistryValueKind.String);
            rt2.SetValue("Text", "@shell32.dll,-30501", RegistryValueKind.String);
            rt2.SetValue("Type", "radio", RegistryValueKind.String);
            rt2.SetValue("ValueName", "Hidden", RegistryValueKind.String);

            RegistryKey rt3 = rt1.OpenSubKey("SHOWALL",true);
            rt3.SetValue("CheckedValue", 1, RegistryValueKind.DWord);
            rt3.SetValue("DefaultValue", 2, RegistryValueKind.DWord);
            rt3.SetValue("HelpID", "shell.hlp#51105", RegistryValueKind.String);
            rt3.SetValue("HKeyRoot", -2147483647, RegistryValueKind.DWord);
            rt3.SetValue("RegPath", @"Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", RegistryValueKind.String);
            rt3.SetValue("Text", "@shell32.dll,-30500", RegistryValueKind.String);
            rt3.SetValue("Type", "radio", RegistryValueKind.String);
            rt3.SetValue("ValueName", "Hidden", RegistryValueKind.String);
        }
    }
}
