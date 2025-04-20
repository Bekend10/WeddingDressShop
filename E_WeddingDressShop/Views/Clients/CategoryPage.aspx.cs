using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using E_WeddingDressShop.Controllers;
using E_WeddingDressShop.Models;

namespace E_WeddingDressShop.Views.Clients
{
    public partial class CategoryPage : System.Web.UI.Page
    {
        ProductController productcontroller = new ProductController();
        UserController userController = new UserController();
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
            cbotheloai.Items.Insert(0, new ListItem("-- Select --", ""));

        }
        private void LoadNewProducts()
        {
            try
            {
                string categoryIdStr = Request.QueryString["CategoryID"];
                int categoryID = int.Parse(categoryIdStr);
                List<PRODUCT> products = productcontroller.getListByCategoryID(categoryID);
                rptNewProducts.DataSource = products;
                rptNewProducts.DataBind();
            }
            catch 
            {
                throw new Exception($"Lỗi");
            }
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
        protected void logout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("~/Views/Clients/Login.aspx");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string searchQuery = txtSearch.Text.Trim();
            if (!string.IsNullOrEmpty(searchQuery))
            {
                var products = productcontroller.getListProductByName(searchQuery);
                if (products.Count > 0)
                {
                    rptNewProducts.DataSource = products;
                    rptNewProducts.DataBind();
                    lblNoProducts.Visible = false;
                }
                else
                {
                    rptNewProducts.DataSource = null;
                    rptNewProducts.DataBind();
                    lblNoProducts.Visible = true;
                }
            }
            else
            {
                lblNoProducts.Visible = false;
                LoadNewProducts();
            }
        }
    }

}