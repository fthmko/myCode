using System;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Text;

namespace Sence
{
    class Cfg
    {
        public static int Max
        {
            get { return real.max; }
            set { real.max = value; }
        }
        public static int Size
        {
            get { return real.size; }
            set { real.size = value; }
        }
        public static int MinSpeed
        {
            get { return real.minSpd; }
            set { real.minSpd = value; }
        }
        public static int MaxSpeed
        {
            get { return real.maxSpd; }
            set { real.maxSpd = value; }
        }
        public static int MinWind
        {
            get { return real.minWnd; }
            set { real.minWnd = value; }
        }
        public static int MaxWind
        {
            get { return real.maxWnd; }
            set { real.maxWnd = value; }
        }
        public static int Chance
        {
            get { return real.chance; }
            set { real.chance = value; }
        }
        public static int Level
        {
            get { return real.level; }
            set { real.level = value; }
        }
        public static int Time
        {
            get { return real.time; }
            set { real.time = value; }
        }
        public static int RefreshTime
        {
            get { return real.reftime; }
            set { real.reftime = value; }
        }
        public static int Type
        {
            get { return real.type; }
            set { real.type = value; }
        }
        public static int Keep
        {
            get { return real.keep; }
            set { real.keep = value; }
        }
        public static int Color
        {
            get { return real.color; }
            set { real.color = value; }
        }
        public static bool Auto
        {
            get { return real.auto; }
            set { real.auto = value; }
        }
        public static bool Memory
        {
            get { return real.mem; }
            set { real.mem = value; }
        }
        private static CfgReal real;
        public static String cfgName = "SenceCfg.xml";

        public static void Save()
        {
            if (File.Exists(cfgName)) File.Delete(cfgName);
            FileStream fs = new FileStream(cfgName,FileMode.CreateNew);
            XmlSerializer saver = new XmlSerializer(typeof(CfgReal));
            saver.Serialize(fs, real);
            fs.Close();
        }

        public static void Load()
        {
            real = new CfgReal();
            if (File.Exists(cfgName))
            {
                FileStream fs = new FileStream(cfgName, FileMode.Open );
                XmlSerializer loader = new XmlSerializer(typeof(CfgReal));
                try
                {
                    real = loader.Deserialize(fs) as CfgReal;
                }
                catch
                {
                }
                fs.Close();
            }
        }
    }

    public class CfgReal
    {
        public int max, size, minSpd, maxSpd, minWnd, maxWnd, chance,keep, level, time, reftime, type, color;
        public bool auto,mem;
        public CfgReal()
        {
            max = 1500;
            size = 2;
            minSpd = 5;
            maxSpd = 15;
            minWnd = -1;
            maxWnd = 3;
            chance = 5;
            level = 30;
            time = 100;
            reftime = 10000;
            type = 0;
            keep = 500;
            auto = true;
            mem = false;
            color = System.Drawing.Color.Cyan.ToArgb();
        }
    }
}