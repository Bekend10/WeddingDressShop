using E_WeddingDressShop.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_WeddingDressShop.Views
{
    public partial class DashBoard : System.Web.UI.Page
    {
        private UserController userController = new UserController();
        private ProductController productController = new ProductController();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserEmail"] == null)
            {
                Response.Redirect("~/Views/Clients/Login.aspx");
            }
            else
            {
                string email = Session["UserEmail"].ToString();
                int userID = userController.getUserByEmail(email);
                string userName = userController.getUserByUserID(userID).FullName;
                nameUser.InnerText = "Xin chào " + userName.ToString();
                LoadNewProducts();
            }
        }

        protected void logout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("~/Views/Clients/Login.aspx");
        }

        private void LoadNewProducts()
        {
            var products = productController.getListProduct(); 
            rptNewProducts.DataSource = products;
            rptNewProducts.DataBind();
        }

    }
}