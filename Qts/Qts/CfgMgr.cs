using System;
using System.IO;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Text;

namespace Qts
{
    public class CfgMgr<T>
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
        public bool Status{
        	get ; set;
        }
        private T real;
        private String nm;


        public CfgMgr(String fileName)
        {
            nm = fileName;
        }

        public bool Save()
        {
        	Status = false;
            try
            {
                if (File.Exists(nm)) File.Delete(nm);
                FileStream fs = new FileStream(nm, FileMode.CreateNew);
                IFormatter saver = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                saver.Serialize(fs, real);
                fs.Close();
                Status = true;
            }
            catch
            {
            }
            return Status;
        }

        public bool Load()
        {
        	Status = false;
            try
            {
                if (!File.Exists(nm)) return false;
                FileStream fs = new FileStream(nm, FileMode.Open);
                IFormatter loader = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                real = (T)loader.Deserialize(fs);
                fs.Close();
                Status = true;
            }
            catch
            {
            }
        	return Status;
        }
    }
}