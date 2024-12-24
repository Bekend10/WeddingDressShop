<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HistoryBuy.aspx.cs" Inherits="E_WeddingDressShop.Views.Clients.HistoryBuy" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Lịch sử Mua Hàng</title>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.4/css/all.min.css" />
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f9;
            padding: 20px;
        }
        .history-table {
            width: 100%;
            border-collapse: collapse;
            margin-top: 20px;
        }
        .history-table th, .history-table td {
            padding: 10px;
            text-align: left;
            border: 1px solid #ddd;
        }
        .history-table th {
            background-color: #f8f8f8;
        }
        .product-img {
            width: 50px;
            height: 50px;
            object-fit: cover;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Lịch sử Mua Hàng</h2>
            <asp:GridView ID="gvHistory" runat="server" AutoGenerateColumns="False" CssClass="history-table" EmptyDataText="Không có sản phẩm nào">
                <Columns>
                    <asp:TemplateField HeaderText="Sản phẩm">
                        <ItemTemplate>
                            <asp:Label ID="lblProductName" runat="server" Text='<%# Eval("Name") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Ảnh sản phẩm">
                        <ItemTemplate>
                            <img src='<%# ResolveUrl(Eval("ImageUrl").ToString()) %>' class="product-img" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="Số lượng" DataField="Quantity" SortExpression="Quantity" />
                    <asp:BoundField HeaderText="Giá" DataField="Price" SortExpression="Price" DataFormatString="{0:N0} VNĐ" />
                    <asp:BoundField HeaderText="Tổng giá trị" DataField="TotalPrice" SortExpression="TotalPrice" DataFormatString="{0:N0} VNĐ" />
                </Columns>
            </asp:GridView>
           <asp:Button ID ="back" runat="server" PostBackUrl="~/Views/Clients/DashBoard.aspx" Text="Trở về" CssClass="btn btn-primary"/>
        </div>
    </form>
</body>
</html>
