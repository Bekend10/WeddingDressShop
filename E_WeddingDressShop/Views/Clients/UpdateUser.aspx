<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateUser.aspx.cs" Inherits="E_WeddingDressShop.Views.Clients.UpdateUser" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label runat="server" Text="Họ tên"/>
            <asp:TextBox ID="txthoten" runat="server" placeholder="Nhập họ và tên của bạn" />
            <br />
            <asp:Label runat="server" Text="Email"/>
            <asp:TextBox ID="txtemail" runat="server" placeholder="Nhập email của bạn" />
            <br />
            <asp:Label runat="server" Text="Số điện thoại"/>
            <asp:TextBox ID="txtphonenumber" runat="server" placeholder="Nhập số điện thoại" />
            <br />
            <asp:Label runat="server" Text="Địa chỉ"/>
            <asp:TextBox ID="txtdiachi" runat="server" placeholder="Nhập địa chỉ" />
            <br />
            <asp:Label runat="server" Text="Mật khẩu"/>
            <asp:TextBox ID="txtmatkhau" runat="server" placeholder="Nhập mật khẩu" />
            <br />
            <asp:Label runat="server" Text="Nhập lại mật khẩu"/>
            <asp:TextBox ID="txtnhaplaimatkhau" runat="server" placeholder="Nhập lại mật khẩu" />
            <br />
            <asp:Button runat="server" Text="Update" CommandName="UpdateUserNe" OnCommand="UpdateUserNe"/>
            <asp:Button runat="server" Text="Cancel" PostBackUrl="~/Views/Clients/DashBoard.aspx"/>
            <br />
            <asp:Label runat="server" ID="lblErrorMessage"></asp:Label>
        </div>
    </form>
</body>
</html>