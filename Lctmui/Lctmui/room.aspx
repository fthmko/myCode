<%@ Page Language="C#" AutoEventWireup="true" CodeFile="room.aspx.cs" Inherits="room" %>

<%@ Register src="head.ascx" tagname="head" tagprefix="uc1" %>

<%@ Register src="tail.ascx" tagname="tail" tagprefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Lctmui 聊天室</title>
    <style type="text/css">
        .style5
        {
            width: 130px;
        }
        .style6
        {
            width: 45px;
            font-size: small;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table style="width:800px;" align="center">
            <tr>
                <td>
                    <uc1:head ID="head1" runat="server" />
                </td>
            </tr>
            <tr>
                <td background="tupm/bgc.jpg" align="center">
                    <br />
                    <table style="width: 740px;">
                        <tr>
                            <td colspan="2" style="width: 600px; height: 450px">
                                <iframe src="data.aspx" height="440px" 
                                    style="border: 1px solid #66CCFF; width: 600px;"></iframe></td>
                            <td class="style5">
                                <asp:ListBox ID="ListBox1" runat="server" Height="445px" Width="130px" 
                                    BackColor="#F7FDFD">
                                </asp:ListBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style6">
                                我说：</td>
                            <td style="width: 550px">
                                <asp:TextBox ID="TextBox2" runat="server" Width="543px" MaxLength="50"></asp:TextBox>
                            </td>
                            <td class="style5">
                                <asp:Button ID="Button1" runat="server" Text="发送" onclick="Button1_Click" 
                                    Width="60px" />
                                <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="退出" 
                                    Width="60px" />
                            </td>
                        </tr>
                    </table>
                    <br />
                </td>
            </tr>
            <tr>
                <td align="center">
                    &nbsp;</td>
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
