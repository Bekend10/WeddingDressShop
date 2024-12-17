<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateProductManage.aspx.cs" Inherits="E_WeddingDressShop.Views.Admin.UpdateProductManage" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sửa sản phẩm</title>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Sửa sản phẩm</h2>
        <asp:Table runat="server" ID="t1">
            <asp:TableRow>
                <asp:TableCell>Product ID</asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtProductID" runat="server" Enabled="false" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>Name</asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtProductName" runat="server" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>Description</asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Rows="4" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>Price</asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtPrice" runat="server" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>Stock Quantity</asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtStockQuantity" runat="server" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>Category</asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="ddlCategory" runat="server" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>Image</asp:TableCell>
                <asp:TableCell>
                    <asp:Image ID="imgPreview" runat="server" Width="200px" Height="200px" Visible="false" />
                    <br />
                    <asp:FileUpload ID="fileUploadImage" runat="server" />
                    <asp:Label ID="lblUploadMessage" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                    <asp:TextBox ID="txtImageUrl" runat="server" Visible="false"></asp:TextBox>
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
