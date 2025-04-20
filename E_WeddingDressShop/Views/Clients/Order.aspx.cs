using E_WeddingDressShop.Controllers;
using E_WeddingDressShop.Models;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace E_WeddingDressShop.Views.Clients
{
    public partial class Order : System.Web.UI.Page
    {
        private readonly OrderController orderController = new OrderController();
        private readonly UserController userController = new UserController();
        private readonly OrderDetailController orderDetailController = new OrderDetailController();
        CategoryController categoryController = new CategoryController();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string email = Session["UserEmail"].ToString();
                int userID = userController.getUserByEmail(email);
                string userName = userController.getUserByUserID(userID).FullName;
                nameUser.InnerText = "Xin chào " + userName.ToString();
                LoadOrdersForClient();
                LoadCategory();

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
        
        protected void logout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("~/Views/Clients/Login.aspx");
        }
        protected void cbotheloai_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCategoryID = cbotheloai.SelectedValue;

            Response.Redirect($"CategoryPage.aspx?CategoryID={selectedCategoryID}");
        }
        protected void LoadCategory()
        {
            var list = categoryController.getListCategory();
            cbotheloai.DataSource = list;
            cbotheloai.DataTextField = "CategoryName";
            cbotheloai.DataValueField = "CategoryID";
            //cbotheloai.Items.Insert(0, new ListItem("-- Select --", string.Empty));
            //cbotheloai.SelectedIndex = 0;
            cbotheloai.DataBind();
            cbotheloai.Items.Insert(0, new ListItem("-- Select --", ""));
        }
    }
}