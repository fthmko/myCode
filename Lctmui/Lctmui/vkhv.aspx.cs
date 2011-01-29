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

public partial class vkhv : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["vkhvchk"] = "0";
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Label1.Text = "";
        Label2.Text = "";

        string nm = TextBox1.Text.Trim().ToLowerInvariant();
        if (!dbop.checkstr(nm))
        {
            Label1.Text = "无效的用户名";
            return;
        }
        if (!dbop.check2("usr", "usr_nm", nm))
        {
            Label1.Text = "不存在的用户";
            return;
        }
        string mail = TextBox2.Text.Trim();
        string whr = "usr_nm='" + nm + "' and usr_mail='" + mail + "'";
        if (!dbop.check("usr", whr))
        {
            Label2.Text = "错误的邮箱";
            return;
        }
        Session["vkhvchk"] = "1";
        Session["vkhvnm"] = nm;
        Response.Redirect("reset.aspx");
    }
}
