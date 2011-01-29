using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FancySCM
{
    public partial class ShowCard : Form
    {
        public ShowCard(Image card,string title)
        {
            InitializeComponent();
            pbCard.Image = card;
            this.Text = title;
        }
    }
}
