using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Text;

namespace FBTrans
{
	[Table(Name = "message")]
	public class MessageBean{
		private string _lang;
		private string _version;
		private string _translator;
		private string _encode;
		private string _xmls;
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
        [Column(Storage = "_xmls")]
        public string Xmlns
        {
            get { return _xmls; }
            set { _xmls = value; }
        }
		List<TagBean> Contents{
			get;set;
		}
		public MessageBean(){
			Contents = new List<TagBean>();
		}
	}
	
	[Table(Name = "tag")]
	public class TagBean{
		private int _key;
		private int _seq;
		private string _tagname;
		private string _propname;
		private string _propvalue;
		private string _textvalue;
		private int _parent;
		private string _msgkey;
		[Column(IsPrimaryKey = true, Storage = "_key")]
        public int Key
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
        [Column(Storage = "_tagname")]
        public string Tagname
        {
            get { return _tagname; }
            set { _tagname = value; }
        }
        [Column(Storage = "_propname")]
        public string Propname
        {
            get { return _propname; }
            set { _propname = value; }
        }
        [Column(Storage = "_propvalue")]
        public string Propvalue
        {
            get { return _propvalue; }
            set { _propvalue = value; }
        }
        [Column(Storage = "_textvalue")]
        public string Textvalue
        {
            get { return _textvalue; }
            set { _textvalue = value; }
        }
        [Column(Storage = "_parent")]
        public int Parent
        {
            get { return _parent; }
            set { _parent = value; }
        }
        [Column(Storage = "_msgkey")]
        public string Msgkey
        {
            get { return _msgkey; }
            set { _msgkey = value; }
        }

		List<TagBean> Subtags{
			get;set;
		}
		public TagBean(){
			Subtags = new List<TagBean>();
		}
	}
}
