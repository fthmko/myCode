using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DotNetSpeech;

namespace AIbzdjc
{
    public partial class Reader : Form
    {
        SpVoice voice;
        public Reader()
        {
            InitializeComponent();
            voice = new SpVoice();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            voice.Speak(textBox1.Text, SpeechVoiceSpeakFlags.SVSFlagsAsync);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            voice.Rate = trackBar1.Value;
        }
    }
}
