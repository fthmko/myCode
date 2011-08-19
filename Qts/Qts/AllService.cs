/*
 * Created by SharpDevelop.
 * User: ZHANGZHENG419
 * Date: 2011-08-05
 * Time: 13:28
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Qts
{
	/// <summary>
	/// Description of AllService.
	/// </summary>
	public partial class AllService : Form
	{
		NType slc;
		
		public AllService(List<NType> baseData)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			buildTree(baseData);
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void buildTree(List<NType> baseData){
			Dictionary<string, TreeNode> map = new Dictionary<string, TreeNode>();
			string rootId = "";
			TreeNode me,par;
			foreach(NType nt in baseData){
				if(nt.parent == "-1"){
					me = new TreeNode(nt.name);
					me.Tag = nt;
					map[nt.id] = me;
					rootId = nt.id;
				} else {
					me = map.ContainsKey(nt.id)?map[nt.id]:new TreeNode(nt.name);
					me.Tag = nt;
					map[nt.id] = me;
					par = map.ContainsKey(nt.parent)?map[nt.parent]:new TreeNode();
					par.Nodes.Add(me);
					map[nt.parent] = par;
				}
			}
			treeView1.Nodes.Add(map[rootId]);
		}
				
		void TreeView1NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			NType nt = (NType)e.Node.Tag;
			if(nt.isNode()){
				slc = nt;
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
		}
		
		public NType getSelected(){
			return slc;
		}
	}
}
