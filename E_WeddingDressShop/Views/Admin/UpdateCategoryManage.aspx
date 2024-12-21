<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateCategoryManage.aspx.cs" Inherits="E_WeddingDressShop.Views.Admin.UpdateCategoryManage" %>

<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Update Category</title>
    <link rel="stylesheet" type="text/css" href="styles.css">
        <!-- Toastify CSS -->
    <link rel="stylesheet" type="text/css" href="https://cdn.jsdelivr.net/npm/toastify-js/src/toastify.min.css">
    <!-- Toastify JavaScript -->
    <script type="text/javascript" src="https://cdn.jsdelivr.net/npm/toastify-js"></script>
<style>
    /* Global styles */
        body {
            font-family: Arial, sans-serif;
            background-color: #f7f7f7;
            margin: 0;
            padding: 0;
        }
        
        /* Main container */
        .container {
            width: 30%;
            margin: 50px auto;
            background-color: #ffffff;
            padding: 20px;
            border-radius: 8px;
            box-shadow: 0 2px 10px rgba(0, 0, 0, 0.1);
        }
        
        /* Heading */
        h2 {
            text-align: center;
            color: #333;
        }
        
        /* Table for form inputs */
        .category-table {
            width: 100%;
            margin-top: 20px;
        }
        
        .category-table th, .category-table td {
            padding: 12px;
            text-align: left;
        }
        
        .category-table th {
            width: 20%;
        }
        
        .category-table td {
            width: 80%;
        }
        
        /* Input fields */
        .input-field {
            width: 100%;
            padding: 8px;
            font-size: 14px;
            border: 1px solid #ccc;
            border-radius: 4px;
            background-color: #f1f1f1;
        }
        
        .input-field:focus {
            outline: none;
            border-color: #66afe9;
            background-color: #fff;
        }
        
        /* Buttons */
        .buttons {
            display: flex;
            justify-content: space-between;
            margin-top: 20px;
        }
        
        .btn-save, .btn-cancel {
            padding: 10px 20px;
            font-size: 16px;
            cursor: pointer;
            border-radius: 4px;
        }
        
        .btn-save {
            background-color: #4CAF50;
            color: white;
            border: none;
        }
        
        .btn-save:hover {
            background-color: #45a049;
        }
        
        .btn-cancel {
            background-color: #f44336;
            color: white;
            border: none;
        }
        
        .btn-cancel:hover {
            background-color: #e53935;
        }
        
        /* Message label */
        .message-label {
            color: #555;
            font-style: italic;
            margin-top: 15px;
            text-align: center;
        }
        
</style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <div class="container">
            <h2>Cập Nhật Danh Mục</h2>
            <asp:Table runat="server" ID="t1" class="category-table">
                <asp:TableRow>
                    <asp:TableCell>Mã Danh Mục</asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtCategoryID" runat="server" class="input-field" Enabled="false" />
                    </asp:TableCell></asp:TableRow><asp:TableRow>
                    <asp:TableCell>Tên Danh Mục</asp:TableCell><asp:TableCell>
                        <asp:TextBox ID="txtCategoryName" runat="server" class="input-field" />
                    </asp:TableCell></asp:TableRow><asp:TableRow>
                    <asp:TableCell>Mô tả</asp:TableCell><asp:TableCell>
                        <asp:TextBox ID="txtDescription" runat="server" class="input-field" />
                    </asp:TableCell></asp:TableRow></asp:Table><div class="buttons">
                <asp:Button ID="btnSua" runat="server" Text="Lưu thay đổi" OnClick="btnSua_Click" class="btn-save" />
                <asp:Button ID="btnBoQua" runat="server" Text="Hủy bỏ" class="btn-cancel" />
            </div>
            <p>
                <asp:Label ID="msg" runat="server" class="message-label" Font-Italic="true" />
            </p>
        </div>
    </form>
</body>
</html>
