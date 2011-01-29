using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DotNetSpeech;

namespace JReader
{
    public partial class Hiden : Form
    {
        SpVoice sp;
        SpeechVoiceSpeakFlags spFlags = SpeechVoiceSpeakFlags.SVSFlagsAsync;
        CallBack finish;
        bool reading;
        string txt;
        int ct;

        public string Content
        {
            set { this.txt = value; }
            get { return this.txt; }
        }
        public int Count
        {
            set { this.ct = value; }
            get { return this.ct; }
        }
        public bool Status
        {
            set { this.reading = value; }
            get { return this.reading; }
        }

        public Hiden(CallBack fsh)
        {
            InitializeComponent();

            finish = fsh;
            reading = false;
            sp = new SpVoice();
        }

        private void Hiden_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            SetVisibleCore(false);
        }
        protected override void SetVisibleCore(bool value)
        {
            base.SetVisibleCore(value);
        }

        public void Read()
        {
            while (reading)
            {
                if (ct > 0) sp.Speak(txt, spFlags);
                else break;
                //sp.WaitUntilDone(-1);
                ct--;
            }
        }
        public void Read(bool cb)
        {
            Read();
            if (cb) finish();
        }

        public void setRate(int rate)
        {
            sp.Rate = rate;
        }

        public void stop()
        {
            int t = sp.Rate;
            sp.Volume = 0;
            sp = null; 
            sp = new SpVoice();
            sp.Rate = t;
            reading = false;
        }

        public void Save2File()
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "All files (*.*)|*.*|wav files (*.wav)|*.wav";
            dialog.Title = "保存到文件...";
            dialog.FilterIndex = 2;
            dialog.RestoreDirectory = true;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                SpeechStreamFileMode spFileMode = SpeechStreamFileMode.SSFMCreateForWrite;
                SpFileStream spFileStream = new SpFileStream();
                spFileStream.Open(dialog.FileName, spFileMode, false);
                sp.AudioOutputStream = spFileStream;
                sp.Speak(txt, spFlags);
                sp.WaitUntilDone(-1);
                spFileStream.Close();
            }
        }
        public void setVolume(int vol)
        {
            sp.Volume = vol;
        }

        public delegate void CallBack();
    }
}
