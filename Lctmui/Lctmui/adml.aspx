<%@ Page Language="C#" AutoEventWireup="true" CodeFile="adml.aspx.cs" Inherits="adml" %>

<%@ Register src="tail.ascx" tagname="tail" tagprefix="uc2" %>
<%@ Register src="head.ascx" tagname="head" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Lctmui 聊天室 - 管理登陆</title>
    <style type="text/css">

        .style1
        {
            height: 10px;
        }
        .style2
        {
            width: 180px;
            text-align:right;
        }
        .style3
        {
            width: 200px;
        }
        a:link 
        {
        	text-decoration: none;
            color: #666666;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table style="border-style: none; width:600px;" align="center">
            <tr>
                <td>
                    <uc1:head ID="head2" runat="server" />
                </td>
            </tr>
            <tr>
                <td  background="tupm/bgr.jpg" align="center">
                <br />
                    <table style="width:540px">
                        <tr>
                            <td colspan="3" class="style1">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" colspan="3">
                                管理员登录</td>
                        </tr>
                        <tr>
                            <td class="style1" colspan="3">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style1" colspan="3">
                            </td>
                        </tr>
                        <tr>
                            <td class="style2">
                                账号：</td>
                            <td class="style3">
                                <asp:TextBox ID="TextBox1" runat="server" Width="100%" MaxLength="20"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="Label1" runat="server" style="font-size: small; color: #0000FF"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style2">
                                密码：</td>
                            <td class="style3">
                                <asp:TextBox ID="TextBox2" runat="server" Width="100%" MaxLength="20" 
                                    TextMode="Password"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="3" class="style1">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style2">
                                &nbsp;</td>
                            <td class="style3">
                                <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text=" 登 录 " />
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="3" class="style1">
                                &nbsp;</td>
                        </tr>
                    </table>
                <br />
                </td>
            </tr>
            <tr>
                <td align="center">
                    <uc2:tail ID="tail1" runat="server" />
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
