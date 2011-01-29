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

public partial class reset : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Unload += new EventHandler(Page_Unload);
        if (Session["vkhvchk"].ToString() != "1")Response.Redirect("vkhv.aspx");
    }

    void Page_Unload(object sender, EventArgs e)
    {
        Session["vkhvchk"] = "0";
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string pwd = TextBox1.Text;
        if (pwd.Length < 4)
        {
            Label1.Text = "密码过短";
            return;
        }
        if (pwd != TextBox2.Text)
        {
            Label1.Text = "两次密码必须相同";
            return;
        }
        string upd = "update usr set usr_pwd = '" + dbop.fmd5(pwd) + "' where usr_nm='" + Session["vkhvnm"].ToString() + "'";
        dbop.excsql(upd);
        Session["vkhvchk"] = "0";
        Response.Redirect("default.aspx");
    }
}
