<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DashBoard.aspx.cs" Inherits="E_WeddingDressShop.Views.Admin.DashBoard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Wedding Dress Shop</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        body {
            font-family: Arial, sans-serif;
        }

        .sidebar {
            display: flex;
            flex-direction: column;
            justify-content: space-between; /* Phân bổ khoảng cách giữa các phần tử */
            align-items: center; /* Căn giữa theo chiều ngang */
            height: 100vh; /* Chiều cao toàn màn hình */
            background-color: #f8f9fa; /* Màu nền sidebar */
            padding: 20px;
            position: relative;
        }

        .user-profile {
            margin-top: auto; /* Đẩy profile xuống cuối sidebar */
            text-align: center;
            background-color: #ffffff; /* Màu nền user profile */
            border-radius: 8px;
            padding: 15px;
            width: 100%; /* Đảm bảo rộng theo sidebar */
            box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1); /* Hiệu ứng đổ bóng */
        }

        .sidecont {
            position: absolute;
            left: 30px;
        }

        .sidebar .menu-item {
            color: #6c757d;
            text-decoration: none;
            margin-bottom: 15px;
            display: block;
            font-weight: 500;
        }

            .sidebar .menu-item:hover {
                color: #000;
            }

        .header {
            padding: 15px;
            background-color: #fff;
            box-shadow: 0 2px 5px rgba(0, 0, 0, 0.1);
            position: sticky;
            top: 0;
            z-index: 1000;
        }

            .header input {
                border-radius: 20px;
                border: 1px solid #ced4da;
                width: 300px;
                text-align: center;
            }

        .card {
            border: none;
            border-radius: 10px;
            box-shadow: 0 2px 5px rgba(0, 0, 0, 0.1);
            padding: 20px;
            margin-bottom: 20px;
        }

        .chart-container {
            height: 200px;
        }

        .sidebar .menu-item {
            font-size: 18px; /* Tăng kích cỡ chữ */
            color: #6c757d;
            text-decoration: none;
            margin-bottom: 15px;
            display: block;
            font-weight: 500;
            padding-left: 10px;
        }

        .sidebar img {
            width: 50px;
        }

        .user-profile {
            background-color: #fff;
            border-radius: 10px;
            padding: 15px;
            text-align: center;
            font-family: Arial, sans-serif;
            box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
        }

        .profile-header {
            display: flex;
            align-items: center;
            justify-content: start;
            gap: 10px;
            margin-bottom: 15px;
        }

        .profile-picture {
            width: 50px;
            height: 50px;
            border-radius: 50%;
            object-fit: cover;
        }

        .profile-info {
            text-align: left;
        }

        .profile-name {
            font-size: 16px;
            font-weight: bold;
            color: #007bff;
        }

        .profile-role {
            display: block;
            font-size: 14px;
            color: #6c757d;
        }

        .profile-actions {
            display: flex;
            justify-content: space-around;
            margin-top: 10px;
        }

        .action-item {
            font-size: 14px;
            color: #6c757d;
            text-decoration: none;
            display: flex;
            align-items: center;
            gap: 5px;
        }

            .action-item i {
                font-size: 16px;
            }

            .action-item:hover {
                color: #007bff;
            }

        .hienthi {
            height: calc(100vh - 100px); /* Điều chỉnh chiều cao nếu cần */
            overflow: hidden;
            position: relative;
        }

            .hienthi iframe {
                width: 100%;
                height: 100%;
                border: none;
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid">
            <div class="row">
                <!-- Sidebar -->
                <div class="col-2 sidebar">
                    <div class="sidecont">
                        <h3 style="padding-bottom: 20px;">Category</h3>
                        <div>
                            <a href="#" class="menu-item" onclick="loadPage('/Views/Admin/Home.aspx')">Home</a>
                            <a href="#" class="menu-item" onclick="loadPage('/Views/Admin/CategoryManage.aspx')">Quản lý danh mục</a>
                            <a href="#" class="menu-item" onclick="loadPage('/Views/Admin/ProductManage.aspx')">Quản lý sản phẩm</a>
                            <a href="#" class="menu-item" onclick="loadPage('/Views/Admin/ListProduct.aspx')">Danh sách sản phẩm</a>
                            <a href="#" class="menu-item" onclick="loadPage('/Views/Admin/Order.aspx')">Đơn hàng</a>
                            <a href="#" class="menu-item">Email</a>
                            <a href="#" class="menu-item">Tickets</a>
                            <a href="#" class="menu-item">Tree View</a>
                            <a href="#" class="menu-item">Pricing</a>
                        </div>
                    </div>

                    <div class="user-profile">
                        <div class="profile-header">
                            <img src="   https://cdn-icons-png.flaticon.com/512/17003/17003310.png " alt="Profile Picture" class="profile-picture" />
                            <div class="profile-info">
                                <span class="profile-name" id="userName"></span>
                                <span class="profile-role" id="role"></span>
                            </div>
                        </div>
                        <div class="profile-actions">
                            <a href="#" class="action-item">
                                <i class="fa fa-cog"></i>Setting
                        </a>
                            <a href="#" class="action-item">
                                <i class="fa fa-sign-out-alt"></i>Log out
                        </a>
                        </div>
                    </div>

                </div>

                <!-- Main Content -->
                <div class="col-10">
                    <!-- Header -->
                    <div class="header d-flex justify-content-between align-items-center">
                        <h4>Dashboard</h4>
                        <input type="text" class="form-control" placeholder="Search..." />
                    </div>
                    <div class="hienthi">
                       <iframe id="contentFrame" src="Home.aspx" frameborder="0" style="width: 100%; height: 100%;"></iframe>


                    </div>

                </div>
            </div>
        </div>
    </form>
    <script>
        function loadPage(page) {
            document.getElementById("contentFrame").src = page;
        }
        </script>
</body>
</html>
