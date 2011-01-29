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

public partial class adml : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["adml"] = "0";
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string fail = "登录失败";
        string nm = TextBox1.Text.Trim().ToLowerInvariant();
        if (!dbop.checkstr(nm))
        {
            Label1.Text = fail;
            return;
        }
        if (!dbop.check2("adm", "adm_nm", nm))
        {
            Label1.Text = fail;
            return;
        }
        string pd = TextBox2.Text;
        if (dbop.fmd5(pd) != dbop.getp(nm, "adm", "adm_nm", "adm_pwd").Trim())
        {
            Label1.Text = fail;
        }
        Session["admn"] = nm;
        Session["adml"] = "1";
        Response.Redirect("manage.aspx");
    }
}
