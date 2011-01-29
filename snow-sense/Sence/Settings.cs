using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sence
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
            nMaxPic.Value  = Cfg.Max;
            nKeep.Value = Cfg.Keep;
            nLevel.Value = Cfg.Level;
            nMaxSpd.Value = Cfg.MaxSpeed;
            nMaxWnd.Value = Cfg.MaxWind;
            nMinSpd.Value = Cfg.MinSpeed;
            nMinWnd.Value = Cfg.MinWind;
            nChance.Value = Cfg.Chance;
            nDropTime.Value = Cfg.Time;
            nRefTime.Value = Cfg.RefreshTime;
            nSize.Value = Cfg.Size;
            cbAuto.Checked = Cfg.Auto;
            cbMemory.Checked = Cfg.Memory;
            pColor.BackColor = System.Drawing.Color.FromArgb(Cfg.Color);
            if (Cfg.Type == 0) rRoberts.Checked = true;
            else rSobel.Checked = true;
        }

        private void pColor_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.Color = pColor.BackColor;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (dlg.Color.Equals(Color.Black))
                {
                    MessageBox.Show("Black is Disabled.");
                    return;
                }
                pColor.BackColor = dlg.Color;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (nMinSpd.Value >= nMaxSpd.Value || nMinWnd.Value >= nMinSpd.Value)
            {
                MessageBox.Show("The Min is Bigger Than Max!");
                return;
            }
            Cfg.Max = (int)nMaxPic.Value;
            Cfg.Keep = (int)nKeep.Value;
            Cfg.Level = (int)nLevel.Value;
            Cfg.MaxSpeed = (int)nMaxSpd.Value;
            Cfg.MaxWind = (int)nMaxWnd.Value;
            Cfg.MinSpeed = (int)nMinSpd.Value;
            Cfg.MinWind = (int)nMinWnd.Value;
            Cfg.Chance = (int)nChance.Value;
            Cfg.Time = (int)nDropTime.Value;
            Cfg.RefreshTime = (int)nRefTime.Value;
            Cfg.Size = (int)nSize.Value;
            Cfg.Color = pColor.BackColor.ToArgb();
            Cfg.Auto = cbAuto.Checked;
            Cfg.Memory = cbMemory.Checked;
            if (rRoberts.Checked) Cfg.Type = 0;
            else Cfg.Type = 1;
            Cfg.Save();
            this.DialogResult = DialogResult.OK;
        }
    }
}