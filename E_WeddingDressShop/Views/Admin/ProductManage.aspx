<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductManage.aspx.cs" Inherits="E_WeddingDressShop.Views.Admin.ProductManage" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Quản lý sản phẩm</title>
    <link href="../../Assets/ProductManage.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="form-container">
            <h2>Thêm sản phẩm</h2>

            <asp:Label ID="lblProductID" runat="server" Text="ID sản phẩm (chỉ dùng khi cập nhật):" Visible="false"></asp:Label>
            <asp:TextBox ID="txtProductID" runat="server" Visible="false"></asp:TextBox>

            <label for="txtProductName">Tên sản phẩm:</label>
            <asp:TextBox ID="txtProductName" runat="server"></asp:TextBox>

            <label for="txtDescription">Mô tả sản phẩm:</label>
            <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Rows="4"></asp:TextBox>

            <label for="txtPrice">Giá:</label>
            <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>

            <label for="txtStockQuantity">Số lượng tồn:</label>
            <asp:TextBox ID="txtStockQuantity" runat="server"></asp:TextBox>

            <label for="txtImageUrl">Hình ảnh:</label>
            <asp:Label ID="lblUploadMessage" runat="server" ForeColor="Red" Visible="false"></asp:Label>
            <asp:Image ID="imgPreview" runat="server" Visible="false" Width="200px" Height="200px" />
            <asp:FileUpload ID="fileUploadImage" runat="server" />
            <asp:TextBox ID="txtImageUrl" runat="server" Visible="false"></asp:TextBox>

            <label for="ddlCategory">Danh mục:</label>
            <asp:DropDownList ID="ddlCategory" runat="server"></asp:DropDownList>

            <asp:Button ID="btnAddOrUpdate" runat="server" Text="Thêm" OnClick="btnAddOrUpdate_Click" CssClass="btn-blue"/>
            <asp:Label ID="lblMessage" runat="server" ForeColor="Green" Visible="false"></asp:Label>
        </div>

        <div class="grid-container">
            <h2>Danh sách sản phẩm</h2>
            <asp:GridView ID="gvProducts" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered">
                <Columns>
                    <asp:BoundField DataField="ProductID" HeaderText="ID" ReadOnly="True" />
                    <asp:BoundField DataField="Name" HeaderText="Tên sản phẩm" />
                    <asp:ImageField DataImageUrlField="ImageUrl" HeaderText="Hình ảnh" SortExpression="ImageUrl" />
                    <asp:BoundField DataField="Description" HeaderText="Mô tả" />
                    <asp:BoundField DataField="Price" HeaderText="Giá" DataFormatString="{0:C}" />
                    <asp:BoundField DataField="StockQuantity" HeaderText="Số lượng tồn" />
                    <asp:BoundField DataField="CategoryName" HeaderText="Danh mục" />
                    <asp:TemplateField HeaderText="Sửa">
                        <ItemTemplate>
                            <asp:Button runat="server" ID="sua" CommandName="SUA" OnCommand="Sua_Click"
                                Text="Sửa" CommandArgument='<%# Bind("ProductID") %>' CssClass="btn-blue"></asp:Button>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Xoá">
                        <ItemTemplate>
                            <asp:Button runat="server" ID="xoa" CommandName="XOA" OnCommand="Xoa_Click"
                                Text="Xoá" CommandArgument='<%# Bind("ProductID") %>' CssClass="btn-red"
                                OnClientClick="return confirm('Bạn có chắc chắn xoá không ?') "></asp:Button>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
