using E_WeddingDressShop.Controllers;
using E_WeddingDressShop.Models;
using System;
using System.Web.UI.WebControls;

namespace E_WeddingDressShop.Views.Clients
{
    public partial class ProductDetails : System.Web.UI.Page
    {
        ProductController productController = new ProductController();
        CategoryController categoryController = new CategoryController();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Lấy ProductID từ query string
                string productIdStr = Request.QueryString["ProductID"];
                if (!string.IsNullOrEmpty(productIdStr) && int.TryParse(productIdStr, out int productId))
                {
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
                    productCategory.InnerText = $"Thể loại:{category}";
                    productStock.InnerText = $"Số lượng còn lại: {product.StockQuantity}";
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

        protected void AddToCart_Click(object sender, EventArgs e)
        {
            // Logic thêm sản phẩm vào giỏ hàng (tùy thuộc vào hệ thống của bạn)
            Response.Redirect("~/Views/Clients/Cart.aspx");
        }
    }
}
