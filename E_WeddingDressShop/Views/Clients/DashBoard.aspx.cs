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
        CategoryController categoryController = new CategoryController();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCategory();
            }
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
                LoadTopProducts();
            }
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
            cbotheloai.Items.Insert(0, new ListItem("-- Dress Wedding --", ""));
        }
        protected void logout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("~/Views/Clients/Login.aspx");
        }

        private void LoadNewProducts()
        {
            List<PRODUCT> products = productController.getListNewProduct();
            rptNewProducts.DataSource = products;
            rptNewProducts.DataBind();
        }

        private void LoadTopProducts()
        {
            List<PRODUCT> products = productController.getListTopProduct();
            rptTopProducts.DataSource = products;
            rptTopProducts.DataBind();
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
        protected void cbotheloai_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCategoryID = cbotheloai.SelectedValue;

            Response.Redirect($"CategoryPage.aspx?CategoryID={selectedCategoryID}");
        }
    }
}