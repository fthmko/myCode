<%@ Page Language="C#" AutoEventWireup="true" CodeFile="vuce.aspx.cs" Inherits="vuce" %>

<%@ Register src="head.ascx" tagname="head" tagprefix="uc1" %>

<%@ Register src="tail.ascx" tagname="tail" tagprefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Lctmui 聊天室 - 用户注册</title>
    <style type="text/css">
        .style3
        {
            text-align:right;
            height:26px;
        }
        .style4
        {
        	width:200px;
        }
        .style5
        {
            height:26px;
        }
        .style6
        {
            font-size: small;
            color: #808080;
            width: 220px;
        }
        .style7
        {
            text-align: right;
            height: 10px;
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
                <td  background="tupm/bgv.jpg" align="center">
                    <br />
                    <table style="width:540px;">
                        <tr>
                            <td class="style3">
                                &nbsp;</td>
                            <td class="style4">
                                <asp:Label ID="Label2" runat="server" style="color: #FF0000"></asp:Label>
                            </td>
                            <td class="style6">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style3">
                                用户名：       
                                </td>
                                <td class="style4">
                                <asp:TextBox ID="TextBox1" runat="server" MaxLength="20" Width="100%"></asp:TextBox>
                            </td>
                            <td class="style6">
                                &nbsp;由小写字母和数字组成<br />
                                &nbsp;长度为4~20个字符</td>
                        </tr>
                        <tr>
                            <td class="style3">
                                &nbsp;</td>
                            <td class="style4">
                                <asp:Button ID="Button1" runat="server" Text="验证用户名" onclick="Button1_Click" />
                                <asp:Label ID="Label1" runat="server" style="color: #0000FF; font-size: small;"></asp:Label>
                            </td>
                            <td class="style6">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style7" colspan="3">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style3">
                                密&nbsp; 码：</td>
                            <td class="style4">
                                <asp:TextBox ID="TextBox2" runat="server" MaxLength="20" Width="100%" 
                                    TextMode="Password"></asp:TextBox>
                            </td>
                            <td class="style6">
                                &nbsp;4~20位</td>
                        </tr>
                        <tr>
                            <td class="style3">
                                确认密码：</td>
                            <td class="style4">
                                <asp:TextBox ID="TextBox3" runat="server" MaxLength="20" Width="100%" 
                                    TextMode="Password"></asp:TextBox>
                            </td>
                            <td class="style6">
                                &nbsp;同密码</td>
                        </tr>
                        <tr>
                            <td class="style7" colspan="3">
                                </td>
                        </tr>
                        <tr>
                            <td class="style3">
                                邮&nbsp; 箱：</td>
                            <td class="style4">
                                <asp:TextBox ID="TextBox4" runat="server" MaxLength="20" Width="100%"></asp:TextBox>
                            </td>
                            <td class="style6">
                                &nbsp;找回密码时使用,请牢记</td>
                        </tr>
                        <tr>
                            <td class="style7" colspan="3">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style3">
                                &nbsp;</td>
                            <td colspan="2">
                                <asp:CheckBox ID="CheckBox1" runat="server" Text="我已看过并同意" 
                                    style="font-size: small" />
                                <asp:HyperLink ID="HyperLink1" runat="server" 
                                    style="font-weight: 700; font-size: small; color: #003366;" 
                                    NavigateUrl="~/xxyi.aspx" Target="_blank">聊天室规定</asp:HyperLink>
                            </td>
                        </tr>
                        <tr>
                            <td class="style3">
                                &nbsp;</td>
                            <td class="style5" colspan="2">
                                <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="注册账号" />
                            </td>
                        </tr>
                        <tr>
                            <td class="style7" colspan="3">
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
