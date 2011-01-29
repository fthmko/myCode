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
    public partial class c_yrgsxnxi : Form
    {
        public c_yrgsxnxi()
        {
            InitializeComponent();
        }

        private void yrgsgrli_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“mMangerDataSet1.员工信息”中。您可以根据需要移动或移除它。
            this.员工信息TableAdapter.Fill(this.mMangerDataSet1.员工信息);

        }
    }
}
