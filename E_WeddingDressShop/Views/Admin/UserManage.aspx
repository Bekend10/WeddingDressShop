<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserManage.aspx.cs" Inherits="E_WeddingDressShop.Views.Admin.UserManage" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Quản lý người dùng</title>
    <link href="../../Assets/UserManage.css" rel="stylesheet" />
    <style>
        /* Định dạng chung */
        body {
            font-family: Arial, sans-serif;
            background-color: #f8f9fa;
            margin: 0;
            padding: 0;
        }
        .container {
            max-width: 1200px;
            margin: 50px auto;
            padding: 20px;
            background-color: #fff;
            border-radius: 8px;
            box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
        }
        h1 {
            text-align: center;
            margin-bottom: 30px;
            color: #343a40;
        }
        /* Định dạng khu vực tìm kiếm */
        .search-container {
            margin-bottom: 20px;
            display: flex;
            align-items: center;
            gap: 10px;
        }
            .search-container label {
                font-weight: bold;
                color: #495057;
            }
        .form-control {
            flex: 1;
            padding: 10px;
            border: 1px solid #ced4da;
            border-radius: 4px;
            font-size: 14px;
        }
        .btn {
            padding: 10px 20px;
            background-color: #007bff;
            color: #fff;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            font-size: 14px;
            transition: background-color 0.3s;
        }
            .btn:hover {
                background-color: #0056b3;
            }
        /* Định dạng bảng */
        .table {
            width: 100%;
            border-collapse: collapse;
            margin-top: 20px;
        }
            .table th, .table td {
                text-align: left;
                padding: 12px 15px;
                border: 1px solid #dee2e6;
            }
            .table th {
                background-color: #007bff;
                color: #fff;
                font-weight: bold;
            }
            .table td {
                background-color: #f9f9f9;
            }
        .table-bordered {
            border: 1px solid #dee2e6;
        }
        /* Nút xóa và nâng quyền */
        .btn-danger {
            background-color: #dc3545;
        }
            .btn-danger:hover {
                background-color: #c82333;
            }
        .btn-success {
            background-color: #28a745;
        }
            .btn-success:hover {
                background-color: #218838;
            }
        /* Thông báo */
        .message {
            margin-top: 20px;
            padding: 10px;
            border-radius: 4px;
            text-align: center;
            font-size: 14px;
        }
            .message.success {
                background-color: #d4edda;
                color: #155724;
                border: 1px solid #c3e6cb;
            }
            .message.error {
                background-color: #f8d7da;
                color: #721c24;
                border: 1px solid #f5c6cb;
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>Quản lý người dùng</h1>
            <div class="search-container">
                <label for="txtSearch">Tìm kiếm theo tên hoặc email:</label>
                <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" />
                <asp:Button ID="btnSearch" runat="server" Text="Tìm kiếm" CssClass="btn" OnClick="btnSearch_Click" />
            </div>
            <asp:GridView ID="gvUsers" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered"
                AllowPaging="True" PageSize="5" OnPageIndexChanging="gvUsers_PageIndexChanging">
                <Columns>
                    <asp:BoundField DataField="UserID" HeaderText="ID" ReadOnly="True" />
                    <asp:BoundField DataField="FullName" HeaderText="Họ và tên" />
                    <asp:BoundField DataField="Email" HeaderText="Email" />
                    <asp:BoundField DataField="NumberPhone" HeaderText="Số điện thoại" />
                    <asp:BoundField DataField="Address" HeaderText="Địa chỉ" />
                    <asp:BoundField DataField="Role" HeaderText="Quyền" />
                    <asp:TemplateField HeaderText="Xóa quyền người dùng">
                        <ItemTemplate>
                            <asp:Button runat="server" ID="btnDeleteRole" CommandName="DELETE_ROLE" Text="Xóa quyền"
                                CommandArgument='<%# Bind("UserID") %>' OnCommand="btnDelete_Click"
                                OnClientClick="return confirm('Bạn có chắc chắn muốn xóa quyền người dùng này?');" CssClass="btn btn-danger" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Lên quyền Admin">
                        <ItemTemplate>
                            <asp:Button runat="server" ID="btnPromoteRole" CommandName="PROMOTE_ROLE" Text="Lên quyền Admin"
                                CommandArgument='<%# Bind("UserID") %>' OnCommand="btnEdit_Click"
                                OnClientClick="return confirm('Bạn có chắc chắn muốn nâng quyền người dùng này?');"
                                CssClass="btn btn-success" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:Label ID="lblMessage" runat="server" CssClass="message" Visible="false"></asp:Label>
        </div>
    </form>
</body>
</html>