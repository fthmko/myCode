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

public partial class data : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        show();
    }
    protected void show()
    {
        DataSet ds = dbop.getnew((DateTime)Session["logtime"]);
        if(dbop.lstsq)
        {
            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                Response.Write(((DateTime)dr["dat"]).TimeOfDay.ToString());                //发言时间
                Response.Write(" "+dr["usr_nm"].ToString()+" ");            //发言用户
                Response.Write("说：");                        
                Response.Write(dbop.strdec(dr["txt"].ToString()));                    //发言内容
                Response.Write("<br>");
            }
        }
    }
}
