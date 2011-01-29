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

public partial class vuce : System.Web.UI.Page
{
    bool chk = false;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Label2.Text = "";
        string nm = TextBox1.Text.Trim().ToLowerInvariant();
        Label1.Text = nmchk(nm);
    }
    private string nmchk(string nm)
    {
        if (!dbop.checkstr(nm)) return "无效的用户名";
        if (dbop.check2("usr", "usr_nm", nm)) return "重复的用户名";
        chk = true;
        return "你可以使用这个名字";
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Label1.Text = "";
        string unm = TextBox1.Text.Trim().ToLowerInvariant();
        string tmp = nmchk(unm);
        if (!chk)
        {
            Label2.Text = tmp;
            return;
        }
        string pwd = TextBox2.Text;
        if (pwd.Length < 4)
        {
            Label2.Text = "密码过短";
            return;
        }
        if (pwd != TextBox3.Text)
        {
            Label2.Text = "两次密码必须相同";
            return;
        }
        string mail = TextBox4.Text.Trim();
        if (mail.Length < 5)
        {
            Label2.Text = "请输入有效的邮箱";
            return;
        }
        if (!CheckBox1.Checked)
        {
            Label2.Text = "不同意就不给注册";
            return;
        }
        string regins = string.Format("insert into usr(usr_nm,usr_pwd,usr_mail) values('{0}','{1}','{2}')",unm,dbop.fmd5(pwd),mail);
        dbop.excsql(regins);
        Response.Redirect("default.aspx");
    }
}
