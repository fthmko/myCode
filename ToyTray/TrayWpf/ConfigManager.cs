using System;
using System.IO;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Text;

namespace TrayWpf
{
    public class ConfigManager<T>
    {
        public String FileName
        {
            get { return nm; }
        }
        public T Config
        {
            get { return real; }
            set { real = value; }
        }
        private T real;
        private String nm;

        public ConfigManager(String fileName)
        {
            nm = fileName;
        }

        public bool Save()
        {
            try
            {
                if (File.Exists(nm)) File.Delete(nm);
                FileStream fs = new FileStream(nm, FileMode.CreateNew);
                IFormatter saver = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                saver.Serialize(fs, real);
                fs.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Load()
        {
            try
            {
                if (!File.Exists(nm)) return false;
                FileStream fs = new FileStream(nm, FileMode.Open);
                IFormatter loader = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                real = (T)loader.Deserialize(fs);
                fs.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
