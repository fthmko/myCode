using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MManager
{
    public partial class a_iuqnjilu : Form
    {
        public a_iuqnjilu()
        {
            InitializeComponent();
        }

        private void a_iuqnjilu_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“mMangerDataSet_iuqn.出勤记录”中。您可以根据需要移动或移除它。
            this.出勤记录TableAdapter.Fill(this.mMangerDataSet_iuqn.出勤记录);

        }

        private void btn_cal_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
