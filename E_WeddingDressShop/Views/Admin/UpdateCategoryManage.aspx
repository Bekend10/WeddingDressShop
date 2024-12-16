<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateCategoryManage.aspx.cs" Inherits="E_WeddingDressShop.Views.Admin.UpdateCategoryManage" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Update Category</title>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Sửa</h2>
        <asp:Table runat="server" ID="t1">
            <asp:TableRow>
                <asp:TableCell>Category ID</asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtCategoryID" runat="server" Enabled="false" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>Category Name</asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtCategoryName" runat="server" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>Description</asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtDescription" runat="server" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <asp:Button ID="btnSua" runat="server" Text="Sửa" OnClick="btnSua_Click" />
        <asp:Button ID="btnBoQua" runat="server" Text="Bỏ qua" />
        <p>
            <asp:Label ID="msg" runat="server" Font-Italic="true" />
        </p>
    </form>
</body>
</html>
