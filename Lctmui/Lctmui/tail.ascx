<%@ Control Language="C#" AutoEventWireup="true" CodeFile="tail.ascx.cs" Inherits="tail" %>
<style type="text/css">
    a:link {text-decoration: none;
        color: #666666;
    }
a:visited {text-decoration: none;}
a:active {text-decoration: none;}
a:hover {text-decoration: none;}
</style>
<table style="width: 600px;">
    <tr>
        <td style="height: 10px">
        </td>
    </tr>
    <tr>
        <td align="center" style="font-size: small; color: #666666">
            版权所有 CopyRight
            ©2008 Lctmui聊天室&nbsp; 
            <asp:HyperLink ID="HyperLink1" runat="server" Font-Underline="False" 
                NavigateUrl="~/xxyi.aspx" style="color: #666666" Target="_blank">使用协议</asp:HyperLink>
        &nbsp;<a href="http://hi.baidu.com/choso" target="_blank"><font color="#666666" >联系方式</font></a>
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/adml.aspx">管理登录</asp:HyperLink>
        &nbsp;<asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/default.aspx">返回首页</asp:HyperLink>
        </td>
    </tr>
</table>