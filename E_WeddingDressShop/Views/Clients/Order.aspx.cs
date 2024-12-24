using E_WeddingDressShop.Controllers;
using E_WeddingDressShop.Models;
using System;
using System.Collections.Generic;

namespace E_WeddingDressShop.Views.Clients
{
    public partial class Order : System.Web.UI.Page
    {
        private readonly OrderController orderController = new OrderController();
        private readonly UserController userController = new UserController();
        private readonly OrderDetailController orderDetailController = new OrderDetailController();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadOrdersForClient();
            }
        }

        private void LoadOrdersForClient()
        {
            try
            {
                if (Session["UserEmail"] != null)
                {
                    string email = Session["UserEmail"].ToString();
                    int userId = userController.getUserByEmail(email);

                    if (userId > 0)
                    {
                        List<ORDER> orders = orderController.getListOrderForClient(userId);
                        if (orders.Count > 0)
                        {
                            gvOrders.DataSource = orders;
                            gvOrders.DataBind();
                        }
                        else
                        {
                            lblMessage.Text = "Không tìm thấy đơn hàng nào.";
                        }
                    }
                    else
                    {
                        lblMessage.Text = "Không tìm thấy người dùng.";
                    }
                }
                else
                {
                    lblMessage.Text = "Bạn cần đăng nhập để xem đơn hàng.";
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Đã xảy ra lỗi: " + ex.Message;
            }
        }

        protected void gvOrders_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewDetail")
            {
                int orderId = Convert.ToInt32(e.CommandArgument);
                LoadOrderDetails(orderId); 
            }
        }

        private void LoadOrderDetails(int orderId)
        {
            try
            {
                List<ORDERDETAILS> orderDetails = orderDetailController.getOrderDetailsByOrderId(orderId);
                if (orderDetails.Count > 0)
                {
                    gvOrderDetails.DataSource = orderDetails;
                    gvOrderDetails.DataBind();

                    //orderDetailsDiv.Visible = true;
                }
                else
                {
                    lblMessage.Text = "Không có chi tiết cho đơn hàng này.";
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Đã xảy ra lỗi khi tải chi tiết đơn hàng: " + ex.Message;
            }
        }
    }
}