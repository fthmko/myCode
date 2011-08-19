using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Text;

namespace FBTrans
{
    [Table(Name = "message")]
    public class MessageBean
    {
        private string _lang;
        private string _version;
        private string _translator;
        private string _encode;
        [Column(IsPrimaryKey = true, Storage = "_lang")]
        public string Lang
        {
            get { return _lang; }
            set { _lang = value; }
        }
        [Column(IsPrimaryKey = true, Storage = "_version")]
        public string Version
        {
            get { return _version; }
            set { _version = value; }
        }
        [Column(Storage = "_translator")]
        public string Translator
        {
            get { return _translator; }
            set { _translator = value; }
        }
        [Column(Storage = "_encode")]
        public string Encode
        {
            get { return _encode; }
            set { _encode = value; }
        }
        public string Display
        {
        	get { return Lang + "_" + Version;}
        }
        public List<TagBean> Contents
        {
            get;
            set;
        }
        public MessageBean()
        {
            Contents = new List<TagBean>();
        }
        public string GenHead()
        {
            return "<?xml version=\"1.0\" encoding=\"" + Encode + "\"?>";
        }
    }

    [Table(Name = "tag")]
    public class TagBean
    {
        private string _key;
        private int _seq;
        private string _name;
        private string _value;
        private string _parent;
        private int _type;
        [Column(IsPrimaryKey = true, Storage = "_key")]
        public string Key
        {
            get { return _key; }
            set { _key = value; }
        }
        [Column(Storage = "_seq")]
        public int Seq
        {
            get { return _seq; }
            set { _seq = value; }
        }
        [Column(Storage = "_name")]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        [Column(Storage = "_value")]
        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }
        [Column(Storage = "_parent")]
        public string Parent
        {
            get { return _parent; }
            set { _parent = value; }
        }
        [Column(Storage = "_type")]
        public int Type
        {
            get { return _type; }
            set { _type = value; }
        }
        public List<TagBean> Subtags
        {
            get;
            set;
        }

        public List<TagBean> Attributes
        {
            get;
            set;
        }

        public TagBean()
        {
            Subtags = new List<TagBean>();
            Attributes = new List<TagBean>();
            Seq = -1;
        }

        public TagBean(string key, int seq, string name, string value, string parent, int type)
        {
            this.Subtags = new List<TagBean>();
            this.Attributes = new List<TagBean>();
            this.Type = type;
            this.Key = key;
            this.Seq = seq;
            this.Name = name;
            this.Value = value ?? "";
            this.Parent = parent;
        }

        public string GenHead()
        {
            if (Type == TagType.ROOT)
            {
                return "<?xml " + Value + "?>\n";
            }
            string head = "";
            head = "<" + Name;
            foreach (TagBean attr in Attributes)
            {
                head += " " + attr.Name + "=\"" + attr.Value + "\"";
            }
            head += ">";

            return head;
        }

        public string GenXml()
        {
            return GenXml("");
        }
        public string GenXml(string idt)
        {
            string INDENT = "  ";
            string thisidt = idt + INDENT;
            if (Name == "#comment")
            {
                string con = Value;
                if (con.Contains('\n'))
                {
                    string[] lns = Value.Split('\n');
                    for (int i = 0; i < lns.Length; i++)
                    {
                        lns[i] = (lns[i].Trim().Length > 0 ? idt : "") + lns[i];
                    }
                    con = String.Join("\n", lns).Trim(' ');
                    if (con.EndsWith("\n")) con += idt;
                }
                return idt + "<!--" + con + "-->";
            }
            string head = GenHead();
            if (Subtags.Count == 0)
            {
                if (Value == null || Value.Length == 0)
                {
                    return idt + head.Replace(">", "/>");
                }
                else
                {
                    return idt + head + Value + "</" + Name + ">";
                }
            }
            else
            {
                string subs = "";
                foreach (TagBean tag in Subtags)
                {
                    subs += "\n" + tag.GenXml(thisidt);
                }
                subs = subs.Trim('\n');
                return idt + head + "\n" + subs + "\n" + idt + "</" + Name + ">";
            }
        }
        
        public int GetCount(){
        	int c = 1;
        	foreach (TagBean tag in Subtags)
            {
        		c += tag.GetCount();
            }
        	foreach (TagBean attr in Attributes)
            {
        		c += attr.GetCount();
            }
        	return c;
        }
    }
    public class TagType
    {
        public const int TAG = 1;
        public const int ATTRIBUTE = 2;
        public const int ROOT = 9;
    }
}
