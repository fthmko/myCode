<%@ Page Language="C#" AutoEventWireup="true" CodeFile="xxyi.aspx.cs" Inherits="xxyi" %>

<%@ Register src="head.ascx" tagname="head" tagprefix="uc1" %>

<%@ Register src="tail.ascx" tagname="tail" tagprefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Lctmui 聊天室 - 使用协议</title>
    <style type="text/css">
        .style1
        {
            font-size: xx-large;
            font-weight: bold;
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
                <td align="center">
                    <br />
                    <span class="style1">想干啥都行！</span><br />
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
