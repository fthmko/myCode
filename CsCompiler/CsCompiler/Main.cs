using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Reflection;
using Microsoft.CSharp;

namespace CsCompiler
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IDictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("CompilerVersion", "v3.5");
            CSharpCodeProvider objCSharpCodePrivoder = new CSharpCodeProvider(dic);
            CompilerParameters paras = new CompilerParameters();

            // compile to dll
            paras.GenerateExecutable = false;

            // reference
            paras.ReferencedAssemblies.Add("System.dll");
            paras.ReferencedAssemblies.Add("System.Data.dll");
            paras.ReferencedAssemblies.Add("System.Windows.Forms.dll");
            paras.ReferencedAssemblies.Add(@"C:\WINDOWS\assembly\GAC_MSIL\System.Core\3.5.0.0__b77a5c561934e089\System.Core.dll");

            // write to memory
            paras.GenerateInMemory = true;

            // save path
            //paras.OutputAssembly = "d:\\test\\test.dll";

            string ns = "CsCompiler";
            string cls = "myClass";
            string md = "destMethod";
            string source = getSource(ns, cls, md);

            CompilerResults result = objCSharpCodePrivoder.CompileAssemblyFromSource(paras, source);
            if (result.Errors.HasErrors)
            {
                string ErrorMessage = "";
                foreach (CompilerError err in result.Errors)
                {
                    ErrorMessage += err.ErrorText;
                }
                addLog(ErrorMessage);
                return;
            }

            // get complied assembly
            Assembly assembly = result.CompiledAssembly;

            // get instance type
            Type AType = assembly.GetType(ns + "." + cls);

            // get method
            MethodInfo method = AType.GetMethod(md);

            // run method
            object reobj = method.Invoke(null, new object[] { getParams() });
            addLog("RESULT:" + reobj.ToString());

            GC.Collect();
        }

        private void addLog(string msg)
        {
            textBox2.Text += (msg + "\n");
        }

        private object[] getParams()
        {
            List<object> param = new List<object>();

            return param.ToArray();
        }
        private string getSource(string sNameSpace, string sClass, string sMethod)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("using System;");
            sb.AppendLine("using System.Windows.Forms;");
            sb.AppendLine("using System.Text;");
            sb.AppendLine("using System.Data;");
            sb.AppendLine("namespace " + sNameSpace);
            sb.AppendLine("{");
            sb.AppendLine("public class " + sClass);
            sb.AppendLine("{");
            sb.AppendLine("public static object " + sMethod + "(object[] param)");
            sb.AppendLine("{");

            var reg = new System.Text.RegularExpressions.Regex(@"\$(\d+)");
            sb.AppendLine(reg.Replace(textBox1.Text, @"param[\1]"));

            sb.AppendLine("}");
            sb.AppendLine("}");
            sb.AppendLine("}");
            
            return sb.ToString();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            textBox2.Text = "";
        }
    }
}
