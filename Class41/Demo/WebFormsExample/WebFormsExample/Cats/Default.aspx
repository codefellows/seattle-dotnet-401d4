<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebFormsExample.Cats.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1 runat="server" id="header"></h1>

        <asp:Label runat="server">Cat Name</asp:Label>
        <asp:TextBox runat="server" ID="CatName"></asp:TextBox>
        <asp:Button ID="MyNewButton" runat="server" OnClick="MyNewButton_Click" Text="My New Button" />
        <br />
        <asp:Label runat="server">Cat Age</asp:Label>
        <asp:TextBox runat="server" ID="CatAge"></asp:TextBox>

        <asp:Button runat="server" OnClick="OnClick" Text="Submit" />

        <asp:ListView runat="server" ID="CatList">
            <LayoutTemplate>
                <table cellpadding="2" width="640px" border="1" runat="server" id="tblCats">
                    <tr runat="server">
                        <th runat="server">Name</th>
                        <th runat="server">Age</th>
                    </tr>
                    <tr runat="server" id="itemPlaceholder" />
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr runat="server">
                    <td>
                        <asp:Label ID="FirstLabel" runat="Server" Text='<%#Eval("Name") %>' />
                    </td>
                    <td>
                        <asp:Label ID="AgeLabel" runat="Server" Text='<%#Eval("Age") %>' />
                    </td>
                </tr>
            </ItemTemplate>

        </asp:ListView>

        <asp:SqlDataSource ID="CatDirectoryDS" runat="server"
            ConnectionString="<%$ ConnectionStrings:myConnectionString %>"
            SelectCommand="SELECT [Name], [Age] FROM dbo.Cat"></asp:SqlDataSource>

    </form>
</body>
</html>

