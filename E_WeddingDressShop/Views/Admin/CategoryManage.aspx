<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CategoryManage.aspx.cs" Inherits="E_WeddingDressShop.Views.Admin.CategoryManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Quản lý danh mục</title>
    <link href="../../Assets/CategoryManage.css" rel="stylesheet" />
        <style>
        body {
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
            background-color: #f9f9f9;
        }

        .form-container, .grid-container {
            width: 80%;
            margin: 20px auto;
            padding: 20px;
            background-color: #ffffff;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
            border-radius: 8px;
        }

        h2 {
            text-align: center;
            color: #333333;
        }

        label {
            display: block;
            font-weight: bold;
            margin-bottom: 5px;
            color: #555555;
        }

        input[type="text"], textarea {
            width: 100%;
            padding: 10px;
            margin-bottom: 15px;
            border: 1px solid #cccccc;
            border-radius: 4px;
            font-size: 14px;
        }

        .button {
            display: inline-block;
            padding: 10px 20px;
            font-size: 14px;
            color: #ffffff;
            background-color: #007bff;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            text-align: center;
        }

        .button:hover {
            background-color: #0056b3;
        }

        .table {
            width: 100%;
            border-collapse: collapse;
            margin-top: 20px;
        }

        .table th, .table td {
            padding: 12px;
            text-align: left;
            border: 1px solid #dddddd;
        }

        .table th {
            background-color: #f2f2f2;
            font-weight: bold;
        }

        .sua, .xoa {
            display: inline-block;
            padding: 8px 16px;
            font-size: 12px;
            color: #ffffff;
            border: none;
            border-radius: 4px;
            cursor: pointer;
        }

        .sua {
            background-color: #28a745;
        }

        .sua:hover {
            background-color: #218838;
        }

        .xoa {
            background-color: #dc3545;
        }

        .xoa:hover {
            background-color: #c82333;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <div class="form-container">
            <h2>Thêm</h2>
            <asp:Label ID="lblCategoryID" runat="server" Text="ID danh mục (chỉ dùng khi cập nhật):" Visible="false"></asp:Label>
            <asp:TextBox ID="txtCategoryID" runat="server" Visible="false"></asp:TextBox>

            <label for="txtCategoryName">Tên danh mục:</label>
            <asp:TextBox ID="txtCategoryName" runat="server"></asp:TextBox>

            <label for="txtDescription">Mô tả danh mục:</label>
            <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Rows="4"></asp:TextBox>

            <asp:Button ID="btnAddOrUpdate" runat="server" Text="Thêm / Cập nhật" OnClick="btnAddOrUpdate_Click" CssClass="button" />
            <asp:Label ID="lblMessage" runat="server" ForeColor="Green" Visible="false"></asp:Label>
        </div>

        <div class="grid-container">
            <h2>Danh sách danh mỤc</h2>
            <asp:GridView ID="gvCategories" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered">
                <Columns>
                    <asp:BoundField DataField="CategoryID" HeaderText="ID" ReadOnly="True" />
                    <asp:BoundField DataField="CategoryName" HeaderText="Tên danh mục" />
                    <asp:BoundField DataField="Description" HeaderText="Mô tả" />
                    <asp:TemplateField HeaderText="Sửa">
                        <ItemTemplate>
                            <asp:Button runat="server" ID="sua" CommandName="SUA" OnCommand="Sua_Click" Text="Sửa" CommandArgument='<%# Bind("CategoryID") %>' CssClass="sua"></asp:Button>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Xoá">
                        <ItemTemplate>
                            <asp:Button runat="server" ID="xoa" CommandName="XOA" OnCommand="Xoa_Click" Text="Xoá" CommandArgument='<%# Bind("CategoryID") %>'
                                OnClientClick="return confirm('Bạn có chắc chắn xoá không ?') " CssClass="xoa"></asp:Button>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
