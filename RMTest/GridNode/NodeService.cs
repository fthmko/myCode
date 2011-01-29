using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using GridLib;

namespace GridNode
{
    public class NodeService : MarshalByRefObject, INodeService
    {
        public static string _level = "0";
        public static List<string> service = new List<string>();
        public static Dictionary<string, byte[]> asmLib = new Dictionary<string, byte[]>();

        public String Level
        {
            get
            {
                return _level;
            }
        }

        public bool WriteFile(String name, byte[] obj)
        {
            string path = Environment.CurrentDirectory + "\\tasks\\" + name + ".dll";
            try
            {
                if (File.Exists(path)) File.Delete(path);
                FileStream fs = new FileStream(path, FileMode.Create);
                fs.Write(obj, 0, obj.Length);
                fs.Flush();
                fs.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool RegistTask(String name)
        {
            if (service.Contains(name)) return true;
            try
            {
                Assembly asm = Assembly.LoadFile(Environment.CurrentDirectory + "\\tasks\\" + name + ".dll");
                Type task = asm.GetType(name + ".GridTask");
                GridTool.RegistSingleCall(task, name);
                service.Add(name);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool RegistTask(String name, byte[] obj)
        {
            if (service.Contains(name)) return true;
            try
            {
                asmLib.Add(name, obj);
                Assembly asm = Assembly.Load(obj);
                Type task = asm.GetType(name + ".GridTask");
                GridTool.RegistSingleCall(task, name);
                service.Add(name);
                return true;
            }
            catch
            {
                return false;
            }

            //if (service.Contains(name)) return true;
            //if (WriteFile(name, obj))
            //    return RegistTask(name);
            //else
            //    return false;
        }
    }
}
