<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Order.aspx.cs" Inherits="E_WeddingDressShop.Views.Clients.Order" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Danh sách đơn hàng</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 20px;
        }

        h1 {
            color: #333;
        }

        .table {
            width: 100%;
            border-collapse: collapse;
            margin-bottom: 20px;
        }

            .table th, .table td {
                border: 1px solid #ddd;
                padding: 8px;
                text-align: left;
            }

            .table th {
                background-color: #f4f4f4;
                font-weight: bold;
            }

        .message {
            color: red;
            font-style: italic;
        }

        .success {
            color: green;
        }

        .btn {
            background-color: green;
            color: white;
            padding: 10px 20px;
            border: none;
            border-radius: 4px;
            cursor: pointer;
        }

        .product-detail {
            margin-top: 10px;
            display: none;
            border-top: 2px solid #ddd;
            padding-top: 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Danh sách đơn hàng của bạn</h1>
            <asp:GridView ID="gvOrders" runat="server" AutoGenerateColumns="False" CssClass="table" OnRowCommand="gvOrders_RowCommand">
                <Columns>
                    <asp:BoundField DataField="OrderID" HeaderText="Mã Đơn Hàng" />
                    <asp:BoundField DataField="OrderDate" HeaderText="Ngày Đặt Hàng" DataFormatString="{0:dd/MM/yyyy}" />
                    <asp:BoundField DataField="TotalAmount" HeaderText="Tổng Tiền" DataFormatString="{0:N0} VNĐ" />
                    <asp:BoundField DataField="Status" HeaderText="Trạng Thái" />

                    <asp:TemplateField HeaderText="Chi Tiết">
                        <ItemTemplate>
                            <asp:Button ID="btnDetail" runat="server" Text="Xem Chi Tiết" CommandName="ViewDetail" CommandArgument='<%# Eval("OrderID") %>' CssClass="btn" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

            <asp:Label ID="lblMessage" runat="server" CssClass="message"></asp:Label>

            <%--<div id="orderDetailsDiv" runat="server" class="product-detail" style="display: none;">--%>
                <h2>Chi Tiết Đơn Hàng</h2>

                <asp:GridView ID="gvOrderDetails" runat="server" AutoGenerateColumns="False" CssClass="table">
                    <Columns>
                        <asp:BoundField DataField="ProductID" HeaderText="Mã Sản Phẩm" />
                        <asp:BoundField DataField="ProductName" HeaderText="Tên Sản Phẩm" />
                        <asp:TemplateField HeaderText="Hình Ảnh">
                            <ItemTemplate>
                                <img src='<%# ResolveUrl(Eval("ImageUrl").ToString()) %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Quantity" HeaderText="Số Lượng" />
                        <asp:BoundField DataField="UnitPrice" HeaderText="Đơn Giá" DataFormatString="{0:N0} VNĐ" />
                        <asp:BoundField DataField="TotalPrice" HeaderText="Tổng Tiền" DataFormatString="{0:N0} VNĐ" />
                    </Columns>
                </asp:GridView>
            </div>

    </form>
</body>
</html>
