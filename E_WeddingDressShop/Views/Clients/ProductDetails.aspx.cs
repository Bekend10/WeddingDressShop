﻿using E_WeddingDressShop.Controllers;
using E_WeddingDressShop.Models;
using System;
using System.Web.UI.WebControls;

namespace E_WeddingDressShop.Views.Clients
{
    public partial class ProductDetails : System.Web.UI.Page
    {
        ProductController productController = new ProductController();
        CategoryController categoryController = new CategoryController();
        CartController cartController = new CartController();
        UserController userController = new UserController();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string productIdStr = Request.QueryString["ProductID"];
                if (!string.IsNullOrEmpty(productIdStr) && int.TryParse(productIdStr, out int productId))
                {
                    string email = Session["UserEmail"].ToString();
                    int userID = userController.getUserByEmail(email);
                    string userName = userController.getUserByUserID(userID).FullName;
                    nameUser.InnerText = "Xin chào " + userName.ToString();
                    LoadCategory();
                    LoadProductDetails(productId);
                }
                else
                {
                    Response.Redirect("~/Views/Clients/DashBoard.aspx");
                }
            }
        }
        protected void View_Details(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "view")
            {
                int productId = Convert.ToInt32(e.CommandArgument);
                Response.Redirect($"~/Views/Clients/ProductDetails.aspx?ProductID={productId}");
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

        private void LoadProductDetails(int productId)
        {
            try
            {
                PRODUCT product = productController.getProductByID(productId);

                if (product != null)
                {
                    var pro = productController.getProductByID(productId);
                    string category  = categoryController.getCategoryNameByID(pro.CategoryID);
                    productImage.Src = ResolveUrl(product.ImageUrl);
                    productName.InnerText = product.Name;
                    productDescription.InnerText = product.Description;
                    productPrice.InnerText = $"{product.Price:N0} VNĐ";
                    productCategory.InnerText = $"{category}";
                    productStock.InnerText = $"{product.StockQuantity}";
                }
                else
                {
                    errmsg.Text = "Không tìm thấy sản phẩm.";
                    errmsg.Visible = true;
                }
            }
            catch (Exception ex)
            {
                errmsg.Text = $"Lỗi khi tải sản phẩm: {ex.Message}";
                errmsg.Visible = true;
            }
        }

        protected void AddToCart_Click(object sender, CommandEventArgs e)
        {
            try
            {
                if(e.CommandName == "AddCart")
                {
                    string productIdStr = Request.QueryString["ProductID"];
                    int productId = int.Parse(productIdStr);
                    string email = Session["UserEmail"].ToString();
                    int userId = userController.getUserByEmail(email);
                    int quantity = int.Parse(hdnProductQuantity.Value);
                    CART cart = new CART
                    {
                        UserID = userId,
                        ProductID = productId,
                        Quantity = quantity,
                    };
                    if (quantity > 0)
                    {
                        string isAdded = cartController.AddCart(cart);
                        if (isAdded.Contains("thành công") == true)
                        {
                            errmsg.Text = "Sản phẩm đã được thêm vào giỏ hàng thành công !";
                            errmsg.ForeColor = System.Drawing.Color.Green;
                            errmsg.Visible = true;
                        }
                        else
                        {
                            errmsg.Text = "Không thể thêm sản phẩm vào giỏ hàng !";
                            errmsg.Visible = true;
                        }
                    }   
                    else
                    {
                        errmsg.Text = "Dữ liệu không hợp lệ.";
                        errmsg.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                errmsg.Text = $"Đã xảy ra lỗi: {ex.Message}";
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
    }
}
