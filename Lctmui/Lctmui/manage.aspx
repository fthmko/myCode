<%@ Page Language="C#" AutoEventWireup="true" CodeFile="manage.aspx.cs" Inherits="manage" %>

<%@ Register src="tail.ascx" tagname="tail" tagprefix="uc2" %>
<%@ Register src="head.ascx" tagname="head" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Lctmui 聊天室 - 用户管理</title>
    <style type="text/css">
        .style1
        {
            width: 515px;
        }

    </style>
</head>

<body>
    <form id="form1" method="post" runat="server">
    
        <table style="border-style: none; width:500px;" align="center">
            <tr>
                <td colspan="2">
                    <uc1:head ID="head2" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="style1">
                    当前用户：<asp:Label ID="Label1" runat="server" style="color: #0066CC" Text="Label"></asp:Label>
                </td>
                <td align="right">
                    <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click" 
                        style="color: #0066CC">退出</asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                        AutoGenerateColumns="False" CellPadding="4" DataKeyNames="UID" 
                        DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" 
                        CellSpacing="3">
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <Columns>
                            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                            <asp:BoundField DataField="UID" HeaderText="UID" InsertVisible="False" 
                                ReadOnly="True" SortExpression="UID" />
                            <asp:BoundField DataField="usr_nm" HeaderText="用户名" SortExpression="usr_nm" />
                            <asp:BoundField DataField="usr_mail" HeaderText="注册邮箱" 
                                SortExpression="usr_mail" />
                        </Columns>
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <EditRowStyle BackColor="#999999" />
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                        ConflictDetection="CompareAllValues" 
                        ConnectionString="<%$ ConnectionStrings:DBCONN %>" 
                        DeleteCommand="DELETE FROM [usr] WHERE [UID] = @original_UID AND [usr_nm] = @original_usr_nm AND [usr_mail] = @original_usr_mail" 
                        InsertCommand="INSERT INTO [usr] ([usr_nm], [usr_mail]) VALUES (@usr_nm, @usr_mail)" 
                        OldValuesParameterFormatString="original_{0}" 
                        SelectCommand="SELECT [UID], [usr_nm], [usr_mail] FROM [usr]" 
                        UpdateCommand="UPDATE [usr] SET [usr_nm] = @usr_nm, [usr_mail] = @usr_mail WHERE [UID] = @original_UID AND [usr_nm] = @original_usr_nm AND [usr_mail] = @original_usr_mail">
                        <DeleteParameters>
                            <asp:Parameter Name="original_UID" Type="Int32" />
                            <asp:Parameter Name="original_usr_nm" Type="String" />
                            <asp:Parameter Name="original_usr_mail" Type="String" />
                        </DeleteParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="usr_nm" Type="String" />
                            <asp:Parameter Name="usr_mail" Type="String" />
                            <asp:Parameter Name="original_UID" Type="Int32" />
                            <asp:Parameter Name="original_usr_nm" Type="String" />
                            <asp:Parameter Name="original_usr_mail" Type="String" />
                        </UpdateParameters>
                        <InsertParameters>
                            <asp:Parameter Name="usr_nm" Type="String" />
                            <asp:Parameter Name="usr_mail" Type="String" />
                        </InsertParameters>
                    </asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <uc2:tail ID="tail1" runat="server" />
                </td>
            </tr>
        </table>
    
    <div>
    
    </div>
    </form>
</body>
</html>
