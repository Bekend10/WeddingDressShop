using E_WeddingDressShop.Controllers;
using E_WeddingDressShop.Models;
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
            List<PRODUCT> products = productController.getListProduct();
            rptNewProducts.DataSource = products;
            rptNewProducts.DataBind();
        }
        protected void View_Details(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "view")
            {
                int productID;
                if (int.TryParse(e.CommandArgument.ToString(), out productID))
                {
                    Response.Redirect("~/Views/Clients/ProductDetails.aspx?productID=" + productID);
                }

            }
        }
    }
}