<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="E_WeddingDressShop.Views.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Đăng nhập</title>
    <link href="../../Assets/Login.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-container">
            <h2>Đăng nhập</h2>
            
            <label for="txtEmail">Email</label>
            <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" TextMode="Email" required="required" />
            <br />
            <label for="txtPassword">Mật khẩu</label>
            <asp:TextBox runat="server" ID="txtPassword" CssClass="form-control" TextMode="Password" required="required" />
            <br />
            <asp:Button runat="server" ID="btnLogin" Text="Đăng nhập" CssClass="btn btn-primary" OnClick="btnLogin_Click" />
            <br />
            <asp:Label runat="server" ID="lblErrorMessage" CssClass="error-message" Visible="false"></asp:Label>
        </div>
    </form>
</body>
</html>
