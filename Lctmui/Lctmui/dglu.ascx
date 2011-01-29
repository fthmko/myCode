<%@ Control Language="C#" AutoEventWireup="true" CodeFile="dglu.ascx.cs" Inherits="dglu" %>
<style type="text/css">
    .style1
    {
        width: 68px;
    }
    .style2
    {
        width: 125px;
    }
    .style4
    {
        width: 68px;
        font-size: medium;
        color: #000000;
    }
    .style5
    {
        width: 68px;
        font-size: x-small;
        color: #003366;
        height: 59px;
    }
    .style6
    {
        width: 125px;
        height: 59px;
        font-family: "Arial Unicode MS";
        font-size: large;
    }
    .style7
    {
        height: 59px;
    }
    .style8
    {
        width: 68px;
        height: 44px;
    }
    .style9
    {
        width: 125px;
        height: 44px;
    }
    .style10
    {
        height: 44px;
    }
    .style11
    {
        font-size: medium;
    }
</style>
<table style="border: 4px solid #FFFFFF; width: 280px;">
    <tr>
        <td class="style5">
            </td>
        <td class="style6" align="center">
            Lctmui 聊天室<br />
            <asp:Label ID="Label1" runat="server" Text="请登录" 
                
                
                
                style="font-size: small; color: #0066CC; font-family: 宋体, Arial, Helvetica, sans-serif;"></asp:Label>
        </td>
        <td class="style7">
            </td>
    </tr>
    <tr>
        <td align="right" class="style4">
            <span class="style11">用户</span>名：</td>
        <td class="style2">
            <asp:TextBox ID="TextBox1" runat="server" Font-Bold="True" MaxLength="16" 
                Width="120px" TabIndex="1"></asp:TextBox>
        </td>
        <td>
            <asp:HyperLink ID="HyperLink2" runat="server" Font-Bold="False" 
                Font-Underline="False" NavigateUrl="~/vuce.aspx" 
                style="font-size: small; color: #0066CC;" TabIndex="4">还没注册？</asp:HyperLink>
        </td>
    </tr>
    <tr>
        <td align="right" class="style4">
            密　码：</td>
        <td class="style2">
            <asp:TextBox ID="TextBox2" runat="server" Font-Bold="True" MaxLength="16" 
                TextMode="Password" Width="120px" TabIndex="2"></asp:TextBox>
        </td>
        <td>
            <asp:HyperLink ID="HyperLink1" runat="server" Font-Underline="False" 
                ForeColor="#003300" NavigateUrl="~/vkhv.aspx" 
                style="font-size: small; color: #0066CC;" TabIndex="5">忘记密码？</asp:HyperLink>
        </td>
    </tr>
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td class="style2">
            <asp:CheckBox ID="CheckBox1" runat="server" 
                
                style="font-size: small; color: #000000; font-family: 宋体, Arial, Helvetica, sans-serif;" 
                Text="下次不用登录" TabIndex="6" />
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style8">
            </td>
        <td class="style9">
            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/tupm/lgb.jpg" onclick="Button1_Click" TabIndex="3"/>
        </td>
        <td class="style10">
            </td>
    </tr>
</table>
            
        
