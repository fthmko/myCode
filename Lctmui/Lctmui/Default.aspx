<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register src="dglu.ascx" tagname="dglu" tagprefix="uc1" %>

<%@ Register src="head.ascx" tagname="head" tagprefix="uc2" %>

<%@ Register src="tail.ascx" tagname="tail" tagprefix="uc3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Lctmui 聊天室 - 用户登陆</title>
    <style type="text/css">
        .style11
        {
            height:10px;
        }
        .style14
        {
            width: 460px;
            height: 320px;
        }
        .style15
        {
            height: 320px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table style="width:800px;" align="center">
            <tr>
                <td colspan="2">
                    <uc2:head ID="head1" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="style11" colspan="2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style14" background="tupm/mn.jpg">
                    </td>
                <td align="center" background="tupm/bgl.jpg" class="style15">
                    <table style="width:275px">
                        <tr>
                            <td>
                                <uc1:dglu ID="dglu1" runat="server" />
                            </td>
                        </tr>
                    </table>
                <br /><br />
                </td>
            </tr>
            <tr>
                <td class="style11" colspan="2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <uc3:tail ID="tail1" runat="server" />
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
