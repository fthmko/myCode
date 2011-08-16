/*
 * Created by SharpDevelop.
 * User: ZHANGZHENG419
 * Date: 2011-07-20
 * Time: 13:42
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace NoSleep
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		[DllImport("kernel32.dll")]
		static extern uint SetThreadExecutionState(uint esFlags);
		const uint ES_SYSTEM_REQUIRED = 0x00000001;
		const uint ES_DISPLAY_REQUIRED = 0x00000002;
		const uint ES_CONTINUOUS = 0x80000000;

		int count = 0;
		int max = 1000000;
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			label1.Text = "" + count;
		}
		
		void Timer1Tick(object sender, EventArgs e)
		{
			this.TopMost = true;
			if(count >= max){
				count = 0;
			} else {
				count++;
			}
			label1.Text = "" + count;
			this.Activate();
			SendKeys.Send("1");
			SetThreadExecutionState(ES_DISPLAY_REQUIRED | ES_SYSTEM_REQUIRED);
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			timer1.Enabled = !timer1.Enabled;
			button1.Text = timer1.Enabled?"●":"○";
		}
	}
}
