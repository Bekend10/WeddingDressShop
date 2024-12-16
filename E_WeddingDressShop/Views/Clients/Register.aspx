<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="E_WeddingDressShop.Views.Register" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Đăng Ký</title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="width: 300px; margin: auto;">
            <h2>Đăng Ký Tài Khoản</h2>
            <label for="txtFullName">Họ và Tên:</label><br />
            <asp:TextBox ID="txtFullName" runat="server" CssClass="form-control" /><br />

            <label for="txtEmail">Email:</label><br />
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" /><br />

            <label for="txtPassword">Mật khẩu:</label><br />
            <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" CssClass="form-control" /><br />

            <label for="txtNumberPhone">Số điện thoại:</label><br />
            <asp:TextBox ID="txtNumberPhone" runat="server" CssClass="form-control" /><br />

            <label for="txtAddress">Địa chỉ:</label><br />
            <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" /><br />

            <label for="ddlRole">Vai trò:</label><br />
            <asp:DropDownList ID="ddlRole" runat="server" CssClass="form-control">
                <asp:ListItem Text="Người dùng" Value="User" />
                <asp:ListItem Text="Quản trị viên" Value="Admin" />
            </asp:DropDownList><br />

            <asp:Button ID="btnRegister" Text="Đăng Ký" runat="server" CssClass="btn btn-primary" OnClick="btnRegister_Click" />
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red" />
        </div>
    </form>
</body>
</html>
