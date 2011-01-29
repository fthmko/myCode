<%@ Page Language="C#" AutoEventWireup="true" CodeFile="vkhv.aspx.cs" Inherits="vkhv" %>

<%@ Register src="head.ascx" tagname="head" tagprefix="uc1" %>

<%@ Register src="tail.ascx" tagname="tail" tagprefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Lctmui 聊天室 - 找回密码 - 信息验证</title>
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
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table style="border-style: none; width:600px;" align="center">
            <tr>
                <td>
                    <uc1:head ID="head1" runat="server" />
                </td>
            </tr>
            <tr>
                <td  background="tupm/bgr.jpg" align="center">
                    <br />
                    <table style="width:540px;">
                        <tr>
                            <td colspan="3" class="style1">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <asp:SiteMapPath ID="SiteMapPath1" runat="server">
                                </asp:SiteMapPath>
                            </td>
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
                            <td align="right" class="style2">
                                用户名：</td>
                            <td class="style3">
                                <asp:TextBox ID="TextBox1" runat="server" Width="100%" MaxLength="20"></asp:TextBox>
                            </td>
                            <td>
                            &nbsp;<asp:Label ID="Label1" runat="server" style="font-size: small; color: #0000FF"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style2">
                                注册邮箱：</td>
                            <td class="style3">
                                <asp:TextBox ID="TextBox2" runat="server" Width="100%" MaxLength="20"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;<asp:Label ID="Label2" runat="server" style="font-size: small; color: #0000FF"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style1" colspan="3">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style2">
                                &nbsp;</td>
                            <td class="style3">
                                <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="下一步" />
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
