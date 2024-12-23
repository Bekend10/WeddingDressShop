<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="E_WeddingDressShop.Views.Clients.Cart" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Giỏ hàng của bạn</h1>
            <asp:GridView ID="gvOrders" runat="server" AutoGenerateColumns="False" CssClass="table-orders">
                <Columns>
                    <asp:BoundField DataField="CartID" HeaderText="Card ID" />
                    <asp:BoundField DataField="ProductName" HeaderText="Tên sản phẩm"/>
                    <asp:BoundField DataField="Quantity" HeaderText="Số lượng" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnOrder" runat="server" Text="Đặt hàng" CommandName="Order" CommandArgument='<%# Eval("CartID") %>' CssClass="btn" OnCommand="Dat_Hang_Click"/>
                            <asp:Button ID="btnDelete" runat="server" Text="Xóa" CommandName="DeleteCart" CommandArgument='<%# Eval("CartID") %>' CssClass="btn btn-danger" OnCommand="Xoa_Click"
                                OnClientClick="return confirm('Bạn có chắc chắn xoá không ?') "
                                />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red" />
        </div>
    </form>
</body>
</html>