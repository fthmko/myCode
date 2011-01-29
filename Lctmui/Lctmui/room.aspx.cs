using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Specialized;

public partial class room : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["loged"].ToString() == "0") Response.Redirect("Default.aspx");
        StringCollection scl = (StringCollection)Application["usrlist"];
        ListBox1.Items.Clear();
        foreach (string nm in scl)
            ListBox1.Items.Add(nm);
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string convt = dbop.strenc(TextBox2.Text.Trim());
        string inss = string.Format("insert into log(usr_nm,txt,dat) values('{0}','{1}','{2}')",
            Session["usrnm"].ToString(), convt, DateTime.Now);
        dbop.excsql(inss);
        TextBox2.Text = "";
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Session["loged"] = "0";
        StringCollection scl = (StringCollection)Application["usrlist"];
        scl.Remove(Session["usrnm"].ToString());
        Session["usrnm"] = "";
        Response.Redirect("default.aspx");
    }
}
