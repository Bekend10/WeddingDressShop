<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="E_WeddingDressShop.Views.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Đăng nhập</title>
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
            height: 100vh;
            font-family: 'Montserrat', sans-serif;
            background: linear-gradient(rgba(0, 0, 0, 0.6), rgba(0, 0, 0, 0.6)), url('../../Template/image/titleAD.png') no-repeat center;
            background-size: cover;
            display: flex;
            align-items: center;
            justify-content: center;
        }

        .wrapper-login {
            display: flex;
            border-radius: 5px;
            overflow: hidden;
            opacity: 0; /* Ẩn trước khi hiển thị */
            animation: fadeIn 1s forwards; /* Hiệu ứng xuất hiện */
        }

        /* Ảnh: Hiệu ứng từ trái sang */
        .wrapper-login img {
            width: 200px;
            height: 450px;
            object-fit: cover;
            transform: translateX(-100%); /* Ban đầu ở ngoài khung nhìn */
            animation: slideInFromLeft 0.8s ease-out forwards 0.5s; /* Hiệu ứng vào */
        }

        /* Form: Hiệu ứng từ phải sang */
        .login-container {
            width: 400px;
            background: rgb(255 241 200);
            box-shadow: 0px 0px 10px rgba(0, 0, 0, 0.1);
            padding: 20px;
            transform: translateX(100%); /* Ban đầu ở ngoài khung nhìn */
            animation: slideInFromRight 0.8s ease-out forwards 0.5s; /* Hiệu ứng vào, delay 0.5s */
        }

        /* Tiêu đề */
        .login-container .title {
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
        .login-container label {
            display: block;
            margin-top: 10px;
            font-size: 18px;
            font-weight: 500;
            font-family: 'Housttely';
        }

        .login-container .form-control {
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

        .login-container .form-control::placeholder {
            font-family: 'Housttely';
        }

        #btnLogin {
            background-color: transparent;
            border: 2px solid #ffb648;
            font-family: 'Quicksand';
            padding: 10px 0;
            margin-top: 10px;
            width: 100%;
        }

        /* Hiệu ứng keyframes */
        @keyframes slideInFromLeft {
            0% {
                transform: translateX(-100%);
                opacity: 0;
            }
            100% {
                transform: translateX(0);
                opacity: 1;
            }
        }

        @keyframes slideInFromRight {
            0% {
                transform: translateX(100%);
                opacity: 0;
            }
            100% {
                transform: translateX(0);
                opacity: 1;
            }
        }

        @keyframes fadeIn {
            0% {
                opacity: 0;
            }
            100% {
                opacity: 1;
            }
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <div class="wrapper-login">
            <img src="../../Template/image/anh4.png" />
            <div class="login-container">
                <span class="title">Đăng  Nhập</span>
                <label for="txtEmail">Email</label>
                <asp:TextBox runat="server" ID="txtEmail" class="form-control" CssClass="form-control" TextMode="Email" placeholder="nhập email của bạn"  required="required" />
                <br />
                <label for="txtPassword">Mật khẩu</label>
                <asp:TextBox runat="server" ID="txtPassword" class="form-control" CssClass="form-control" TextMode="Password" placeholder="nhập mật khẩu của bạn"  required="required" />
                <br />
                <asp:Button runat="server" ID="btnLogin" Text="Đăng Nhập" CssClass="btn btn-primary" OnClick="btnLogin_Click" />

                <br />
                <asp:Label runat="server" ID="lblErrorMessage" CssClass="error-message" Visible="false"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
