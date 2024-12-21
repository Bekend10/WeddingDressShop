<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListProduct.aspx.cs" Inherits="E_WeddingDressShop.Views.Admin.ListProduct" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Danh sách sản phẩm</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Danh sách sản phẩm</h2>
            <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" Placeholder="Nhập tên sản phẩm..." />
            <asp:Button ID="btnSearch" runat="server" Text="Tìm kiếm" CssClass="btn btn-primary" OnClick="btnSearch_Click" />
        </div>
        <br />
        <div class="grid-container">
            <asp:GridView ID="gvProducts" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered">
                <Columns>
                    <asp:BoundField DataField="ProductID" HeaderText="ID" ReadOnly="True" />
                    <asp:BoundField DataField="Name" HeaderText="Tên sản phẩm" />
                    <asp:ImageField DataImageUrlField="ImageUrl" HeaderText="Hình ảnh" SortExpression="ImageUrl" />
                    <asp:BoundField DataField="Description" HeaderText="Mô tả" />
                    <asp:BoundField DataField="Price" HeaderText="Giá" DataFormatString="{0:N0} VNĐ" />
                    <asp:BoundField DataField="StockQuantity" HeaderText="Số lượng tồn" />
                    <asp:BoundField DataField="CategoryName" HeaderText="Danh mục" />
                    <asp:TemplateField HeaderText="Sửa">
                        <ItemTemplate>
                            <asp:Button runat="server" ID="sua" CommandName="SUA" OnCommand="Sua_Click" Text="Sửa" CommandArgument='<%# Bind("ProductID") %>'></asp:Button>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Xoá">
                        <ItemTemplate>
                            <asp:Button runat="server" ID="xoa" CommandName="XOA" OnCommand="Xoa_Click" Text="Xoá" CommandArgument='<%# Bind("ProductID") %>'
                                OnClientClick="return confirm('Bạn có chắc chắn xoá không ?') "></asp:Button>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <asp:Label ID="lblMessage" runat="server" ForeColor="Green" Visible="false"></asp:Label>
    </form>
</body>
</html>