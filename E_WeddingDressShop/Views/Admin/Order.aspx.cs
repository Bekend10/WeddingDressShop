using E_WeddingDressShop.Controllers;
using E_WeddingDressShop.Models;
using System;
using System.Web.UI.WebControls;

namespace E_WeddingDressShop.Views.Admin
{
    public partial class Order : System.Web.UI.Page
    {
        private OrderController orderController = new OrderController();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadOrders();
            }
        }

        private void LoadOrders()
        {
            gvOrders.DataSource = orderController.getListOrder();
            gvOrders.DataBind();
        }

        protected void gvOrders_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvOrders.PageIndex = e.NewPageIndex; // Cập nhật chỉ số trang
            LoadOrders(); // Tải lại dữ liệu
        }



        // Xử lý các lệnh từ GridView
        protected void gvOrders_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int orderId = Convert.ToInt32(e.CommandArgument);
                if (e.CommandName == "EditOrder")
                {
                    ORDER order = orderController.getORDERByID(orderId);

                    if (order != null)
                    {
                        hfOrderID.Value = order.OrderID.ToString();
                        txtUserID.Text = order.UserID.ToString();
                        txtFullName.Text = order.FullName;
                        txtOrderDate.Text = order.OrderDate.ToString("yyyy-MM-dd");
                        txtTotalAmount.Text = order.TotalAmount.ToString();
                        ddlStatus.SelectedValue = order.Status;
                    }
                }
                else if (e.CommandName == "DeleteOrder")
                {
                    string message = orderController.DeleteORDER(orderId);
                    lblMessage.Text = message;
                    lblMessage.ForeColor = System.Drawing.Color.Green; // Hiển thị thông báo màu xanh
                    LoadOrders();
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = $"Có lỗi xảy ra: {ex.Message}";
                lblMessage.ForeColor = System.Drawing.Color.Red; // Hiển thị thông báo màu đỏ
            }
        }

        // Lưu thông tin đơn hàng (thêm mới hoặc cập nhật)
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ORDER order = new ORDER
                {
                    OrderID = string.IsNullOrEmpty(hfOrderID.Value) ? 0 : Convert.ToInt32(hfOrderID.Value),
                    UserID = Convert.ToInt32(txtUserID.Text),
                    FullName = txtFullName.Text,
                    OrderDate = Convert.ToDateTime(txtOrderDate.Text),
                    TotalAmount = Convert.ToDecimal(txtTotalAmount.Text),
                    Status = ddlStatus.SelectedValue
                };

                string message;

                if (order.OrderID == 0) // Thêm mới
                {
                    int orderId = orderController.AddORDER(order);
                    if (orderId > 0)
                    {
                        message = "Đặt hàng thành công !";
                        lblMessage.Visible = true;
                    }
                    else
                    {
                       message = "Đặt hàng thất bại !";
                        lblMessage.Visible = true;
                    }
                }
                else // Cập nhật
                {
                    message = orderController.UpdateORDER(order);
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                }
                lblMessage.Text = message;
                LoadOrders();
            }
            catch (Exception ex)
            {
                lblMessage.Text = $"Có lỗi xảy ra: {ex.Message}";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}