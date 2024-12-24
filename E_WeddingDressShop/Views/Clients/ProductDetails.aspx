<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductDetails.aspx.cs" Inherits="E_WeddingDressShop.Views.Clients.ProductDetails" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Chi tiết sản phẩm</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="product-card-wrapper">
            <div class="product-card">
                <img id="productImage" runat="server" alt="Ảnh sản phẩm" class="product-image" />
                <div class="d-flex justify-content-between mt-2">
                    <div>
                        <h3 id="productName" runat="server" class="mb-2"></h3>
                        <p id="productDescription" runat="server" class="mb-0"></p>
                    </div>
                    <p id="productPrice" runat="server" class="price"></p>
                </div>
                <p id="productCategory" runat="server" class="category"></p>
                <p id="productStock" runat="server" class="stock"></p>
                <asp:Button ID="btnAddToCart" runat="server" Text="Thêm vào giỏ hàng" OnClick="AddToCart_Click" />
               <asp:Button runat="server" CommandName="view" Text="Xem chi tiết" 
    CommandArgument='<%# Eval("ProductID") %>' 
    OnCommand="View_Details" />
            </div>
            <br />
            <asp:Label ID="errmsg" Text="errmsg" runat="server" Enabled ="false"/>
        </div>
    </form>
</body>
</html>
