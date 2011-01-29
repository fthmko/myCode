using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace FancySCM
{
    public partial class GetImg : Form
    {
        public MyVedioCapture vc = new MyVedioCapture();
        public IntPtr CaptureHandle;
        public IntPtr p;
        public Image vkpm;

        public GetImg()
        {
            InitializeComponent();

        }

        private void GetImg_Shown(object sender, EventArgs e)
        {
            p = this.pbCap.Handle;
            CaptureHandle = vc.CreateCaptureWindow(p, 0, 0, 320, 240, 0);
        }

        private void btCP_Click(object sender, EventArgs e)
        {
            vkpm = new Bitmap(300, 400);
            Graphics g = Graphics.FromImage(vkpm);
            g.DrawImage(vc.CapturePicture(CaptureHandle), new Rectangle(0, 0, 300, 400), new Rectangle(240, 80, 300, 400), GraphicsUnit.Pixel);
            pbFL.Image = vkpm;
            string tempf = FancySCM.buildimg("temp");
            if(File.Exists(tempf))
                if (FancySCM.filebusy(tempf))
                {
                    MessageBox.Show("无法生成临时文件" + tempf, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            vkpm.Save(tempf, System.Drawing.Imaging.ImageFormat.Bmp);
            btPS.Enabled = true;
        }

        public Image get_vkpm()
        {
            return vkpm;
        }

    }
}
