using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Text;

namespace TrayWpf
{
    [Table(Name = "CONFIG")]
    public class AConfig
    {
        private string _id;
        [Column(IsPrimaryKey = true, Storage = "_id")]
        public string id
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _aname;
        [Column(Storage = "_aname")]
        public string aname
        {
            get { return _aname; }
            set { _aname = value; }
        }
        private string _title;
        [Column(Storage = "_title")]
        public string title
        {
            get { return _title; }
            set { _title = value; }
        }
        private string _tip;
        [Column(Storage = "_tip")]
        public string tip
        {
            get { return _tip; }
            set { _tip = value; }
        }
        private string _icotray;
        [Column(Storage = "_icotray")]
        public string icotray
        {
            get { return _icotray; }
            set { _icotray = value; }
        }
        private string _icomain;
        [Column(Storage = "_icomain")]
        public string icomain
        {
            get { return _icomain; }
            set { _icomain = value; }
        }
        private string _image;
        [Column(Storage = "_image")]
        public string image
        {
            get { return _image; }
            set { _image = value; }
        }
        private bool _border;
        [Column(Storage = "_border")]
        public bool border
        {
            get { return _border; }
            set { _border = value; }
        }

        public System.Windows.Forms.NotifyIcon Tray;
        public System.Windows.Window Wnd;
    }

    [Table(Name = "MENU")]
    public class AMenu
    {
        private string _id;
        [Column(IsPrimaryKey = true, Storage = "_id")]
        public string id
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _config;
        [Column(Storage = "_config")]
        public string config
        {
            get { return _config; }
            set { _config = value; }
        }
        private string _content;
        [Column(Storage = "_content")]
        public string content
        {
            get { return _content; }
            set { _content = value; }
        }
        private string _parent;
        [Column(Storage = "_parent")]
        public string parent
        {
            get { return _parent; }
            set { _parent = value; }
        }
        private bool _bold;
        [Column(Storage = "_bold")]
        public bool bold
        {
            get { return _bold; }
            set { _bold = value; }
        }
        private bool _disable;
        [Column(Storage = "_disable")]
        public bool disable
        {
            get { return _disable; }
            set { _disable = value; }
        }
        private bool _chk;
        [Column(Storage = "_chk")]
        public bool chk
        {
            get { return _chk; }
            set { _chk = value; }
        }
        private bool _sep;
        [Column(Storage = "_sep")]
        public bool sep
        {
            get { return _sep; }
            set { _sep = value; }
        }
        private int _operate;
        [Column(Storage = "_operate")]
        public int operate
        {
            get { return _operate; }
            set { _operate = value; }
        }
    }
}
