﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="E_WeddingDressShop.Views.Register" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Đăng Ký</title>
    <link rel="stylesheet" type="text/css" href="https://cdn.jsdelivr.net/npm/toastify-js/src/toastify.min.css"/>
    <script type="text/javascript" src="https://cdn.jsdelivr.net/npm/toastify-js"></script>

    <style>
        @import url('https://fonts.googleapis.com/css2?family=Quicksand:wght@300..700&display=swap');
        @import url('https://fonts.googleapis.com/css2?family=Montserrat:ital,wght@0,100..900;1,100..900&display=swap');
        @font-face {
            font-family: "Housttely";
            src: url("../../Template/fonts/SVN-HousttelySignature-Regular.eot");
            src: url("../../Template/fonts/SVN-HousttelySignature-Regular.eot?#iefix") format("embedded-opentype"), 
                url("../../Template/fonts/SVN-HousttelySignature-Regular.woff2") format("woff2"), 
                url("../../Template/fonts/SVN-HousttelySignature-Regular.woff") format("woff"), 
                url("../../Template/fonts/SVN-HousttelySignature-Regular.ttf") format("truetype"), 
                url("../../Template/fonts/SVN-HousttelySignature-Regular.svg#SVN-HousttelySignature-Regular") format("svg");
            font-weight: normal;
            font-style: normal;
            font-display: swap;
        }

        * {
            margin: 0;
            padding: 0;
            box-sizing: border-box;
        }

        body {
            display: block;
            width: 100%;
            height: 100%;
            font-family: 'Montserrat', sans-serif;
            background: linear-gradient(rgba(0, 0, 0, 0.6), rgba(0, 0, 0, 0.6)), url('../../Template/image/titleAD.png') no-repeat center;
            background-size: cover;
            display: flex;
            justify-content: center;
        }

        /* Wrapper chiếm toàn màn hình */
        .wrapper-register {
            position: relative;
            width: 600px;
            display: flex;
            background-color: #fff;
            padding: 20px;
            margin: 80px 0;
            overflow: hidden;
            transform: translateY(100%); /* Ban đầu trượt ngoài màn hình bên phải */
            animation: slideInFromBottom 1.5s ease-in-out forwards 0.1s; /* Hiệu ứng trượt từ phải */
        }
    
        /* Ảnh: Hiệu ứng từ trái sang */
        .wrapper-register img {
            width: 600px;
            object-fit: cover;
            position: absolute;
            top: 150px;
            left: 0;
        }

        /* Form đăng nhập */
        .register-container {
            width: 100%;
            z-index: 2;
        }

        /* Tiêu đề */
        .register-container .title {
            display: block;
            width: 100%;
            text-align: center;
            color: #ffb648;
            font-size: 22px;
            font-weight: 500;
            font-family: 'Housttely';
            letter-spacing: 2px;
        }

        /* Label */
        .register-container label {
            color: #ffb648;
            display: block;
            margin-top: 10px;
            font-size: 18px;
            font-weight: 500;
            font-family: 'Housttely';
        }

        .register-container .form-control {
            width: 100%;
            padding: 5px 10px;
            border: none;
            outline: none;
            border-bottom: 1px solid #ffb648;
            background-color: transparent;
            letter-spacing: 1px;
            font-size: 18px;
            font-family: "Quicksand";
        }

        .register-container .form-control::placeholder {
            font-family: 'Housttely';
        }

        #btnRegister {
            background-color: transparent;
            border: 2px solid #ffb648;
            border-radius: 30px;
            font-family: 'Quicksand';
            font-size: 20px;
            margin-top: 30px;
            padding: 8px 0;
            cursor: pointer;
            color: #ffb648;
            width: 100%;
            transition: all 0.3s ease;
        }

        #btnRegister:hover {
            color: #fff;
            background-color: #ffb648;
            box-shadow: 0 0 10px #ffb648;
            border: 2px solid #ffb64852;
            letter-spacing: 1px;
        }

        /* Hiệu ứng trượt từ phải */
        @keyframes slideInFromBottom {
            0% {
                transform: translateY(100%);
                opacity: 0.5;
            }
            100% {
                transform: translateY(0);
                opacity: 1;
            }
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <div class="wrapper-register">
            <img src="../../Template/image/main-img.png" />
            <div class="register-container">
                <span class="title">Đăng Ký Tài Khoản</span>
                <label for="txtFullName">Họ và Tên:</label><br />
                <asp:TextBox ID="txtFullName" runat="server" CssClass="form-control" placeholder="nhập họ và tên của bạn" /><br />

                <label for="txtEmail">Email:</label><br />
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="nhập email của bạn" /><br />

                <label for="txtPassword">Mật khẩu:</label><br />
                <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" CssClass="form-control" placeholder="nhập mật khẩu của bạn" /><br />

                <label for="txtNumberPhone">Số điện thoại:</label><br />
                <asp:TextBox ID="txtNumberPhone" runat="server" CssClass="form-control" placeholder="nhập số điện thoại của bạn" /><br />

                <label for="txtAddress">Địa chỉ:</label><br />
                <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" placeholder="nhập địa chỉ của bạn" /><br />

                <label for="ddlRole">Vai trò:</label><br />
                <asp:DropDownList ID="ddlRole" runat="server" CssClass="form-control">
                    <asp:ListItem Text="Người dùng" Value="User" />
                    <asp:ListItem Text="Quản trị viên" Value="Admin" />
                </asp:DropDownList><br />

                <asp:Button ID="btnRegister" Text="Đăng Ký" runat="server" CssClass="btn btn-primary" OnClick="btnRegister_Click" />
            </div>
        </div>
    </form>
</body>
</html>
