<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        //在应用程序启动时运行的代码
        Application["usrlist"] = new StringCollection();
    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //在应用程序关闭时运行的代码

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        //在出现未处理的错误时运行的代码
      
    }

    void Session_Start(object sender, EventArgs e) 
    {
        //在新会话启动时运行的代码
        Session["usrnm"] = "";
        Session["adml"] = "0";
        Session["loged"] = "0";
        Session["vkhvchk"] = "0";
        Session["logtime"] = DateTime.Now;
        HttpCookie ck = Request.Cookies["lctmui"];
        if(null != ck)
        {
            string unm = ck.Values["usrnm"].ToString();
            string pwd = ck.Values["pwd"].ToString();
            if (pwd != dbop.getpwd(unm).Trim()) return;
            Session["usrnm"] = unm;
            Session["loged"] = "1";
            StringCollection lst = (StringCollection)Application["usrlist"];
            if(!lst.Contains(unm)) lst.Add(unm);
        }
    }

    void Session_End(object sender, EventArgs e) 
    {
        //在会话结束时运行的代码。 
        // 注意: 只有在 Web.config 文件中的 sessionstate 模式设置为
        // InProc 时，才会引发 Session_End 事件。如果会话模式 
        //设置为 StateServer 或 SQLServer，则不会引发该事件。
        if (Session["loged"].ToString() == "1") ((StringCollection)Application["usrlist"]).Remove(Session["usrnm"].ToString());
    }
       
</script>
