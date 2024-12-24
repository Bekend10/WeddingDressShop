<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductDetails.aspx.cs" Inherits="E_WeddingDressShop.Views.Clients.ProductDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label runat="server" Text="Tên sản phẩm"/>
            <asp:TextBox ID="txttensp" runat="server" ReadOnly="true" />
            <br />
            <asp:Label runat="server" Text="Mô tả"/>
            <asp:TextBox ID="txtmota" runat="server" ReadOnly="true"/>
            <br />
            <asp:Label runat="server" Text="Giá"/>
            <asp:TextBox ID="txtgia" runat="server" ReadOnly="true"/>
            <br />
            <asp:Label runat="server" Text="Số lượng còn lại" />
            <asp:TextBox ID="txtsoluongcon" runat="server" ReadOnly="true"/>
            <br />
            <asp:Label runat="server" Text="Thể loại" ReadOnly="true"/>
            <asp:TextBox ID="txttheloai" runat="server" ReadOnly="true"/>
            <br />
            <asp:Label runat="server" Text="Ảnh" ReadOnly="true"/>
            <asp:TextBox ID="txtanh" runat="server" ReadOnly="true"/>
            <br />
            <asp:Button Text="Thêm vào giỏ hàng" runat="server" />
            <asp:Button Text="Về trang chủ" runat="server" PostBackUrl="~/Views/Clients/DashBoard.aspx"/>
            <br />
            <asp:Label ID="errmsg" Text="errmsg" runat="server"/>
        </div>
    </form>
</body>
</html>
