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

public partial class manage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Unload += new EventHandler(Page_Unload);
        if (Session["adml"].ToString() != "1")
        {
            Response.Redirect("adml.aspx");
            return;
        }
        Label1.Text = Session["admn"].ToString();
    }

    void Page_Unload(object sender, EventArgs e)
    {
        Session["adml"] = "0";
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Session["adml"] = "0";
        Response.Redirect("default.aspx");
    }
}
