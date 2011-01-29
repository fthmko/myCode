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

public partial class dglu : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
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
        string pd = TextBox2.Text;

        if (dbop.fmd5(pd) == dbop.getpwd(nm).Trim())
        {
            Session["usrnm"] = nm;
            Session["loged"] = "1";
            StringCollection lst = (StringCollection)Application["usrlist"];
            if(!lst.Contains(nm)) lst.Add(nm);
            if (CheckBox1.Checked)
            {
                HttpCookie ck = new HttpCookie("lctmui");
                ck.Values.Add("usrnm", nm);
                ck.Values.Add("pwd", dbop.fmd5(pd));
                ck.Expires = DateTime.Now.AddDays(1d);
                Response.Cookies.Add(ck);
            }
            Session["logtime"] = DateTime.Now;
            Response.Redirect("room.aspx");
        }
        else
        {
            Label1.Text = "密码错误！";
        }
    }
}
