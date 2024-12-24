using E_WeddingDressShop.Controllers;
using E_WeddingDressShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_WeddingDressShop.Views.Clients
{
    public partial class Cart : System.Web.UI.Page
    {
        public CartController cartController = new CartController();
        public UserController userController = new UserController();
        public OrderController orderController = new OrderController();
        public ProductController productController = new ProductController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Loaded();
            }
        }
        public void Loaded()
        {
            string email = Session["UserEmail"].ToString();
            int userId = userController.getUserByEmail(email);
            gvOrders.DataSource = cartController.getList(userId);
            gvOrders.DataBind();
        }
        protected void Xoa_Click(object sender, CommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "DeleteCart")
                {
                    //string email = Session["UserEmail"].ToString();
                    //int userId = userController.getUserByEmail(email);
                    int cartID = Convert.ToInt32(e.CommandArgument);
                    string result = cartController.DeleteCart(cartID);
                    ShowMessage(result, result.Contains("thành công"));
                    Loaded();
                }
            }
            catch (Exception ex)
            {
                ShowMessage($"Lỗi khi xóa danh mục: {ex.Message}", false);
            }
        }
        private void ShowMessage(string message, bool isSuccess)
        {
            lblMessage.Text = message;
            lblMessage.ForeColor = isSuccess ? System.Drawing.Color.Green : System.Drawing.Color.Red;
            lblMessage.Visible = true;
        }
        protected void Dat_Hang_Click(object sender, CommandEventArgs e)
        {
            try
            {
                ORDER od = new ORDER();
                string email = Session["UserEmail"].ToString();
                int userId = userController.getUserByEmail(email);
                int cartID = Convert.ToInt32(e.CommandArgument);
                //string fullName = userController.getUserByUserID(userId);
                int productId = cartController.getProductIDByCartID(cartID);
                float price = productController.getPriceByID(productId);
                int quantity = cartController.getQuantityByID(cartID);
                od.UserID = userId;
                od.FullName = userController.getUserByUserID(userId).FullName;
                od.OrderDate = DateTime.Now;
                od.Status = "Processing";
                od.TotalAmount = Convert.ToDecimal(price * quantity);
                string result = orderController.AddORDER(od);
                ShowMessage(result, result.Contains("thành công"));
                cartController.DeleteCart(cartID);
                Loaded();
            }
            catch (Exception e1)
            {
                ShowMessage("Có lỗi sảy ra: " + e1.Message, false);
            }
        }
        protected void logout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("~/Views/Clients/Login.aspx");
        }
    }
}