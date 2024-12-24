using E_WeddingDressShop.Controllers;
using E_WeddingDressShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace E_WeddingDressShop.Views.Admin
{
    public partial class ListProduct : System.Web.UI.Page
    {
        ProductController productController = new ProductController();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadProducts();
            }
        }

        private void LoadProducts(string searchKeyword = null)
        {
            try
            {
                List<PRODUCT> products;

                if (!string.IsNullOrEmpty(searchKeyword))
                {
                    products = productController.getListProductByName(searchKeyword);
                }
                else
                {
                    products = productController.getListProduct();
                }

                if (products == null || products.Count == 0)
                {
                    ShowMessage($"Không tìm thấy sản phẩm nào với từ khóa '{searchKeyword}'.", false);
                }
                else
                {
                    lblMessage.Visible = false;
                }

                gvProducts.DataSource = products;
                gvProducts.DataBind();
            }
            catch (Exception ex)
            {
                ShowMessage($"Lỗi khi tải danh sách sản phẩm: {ex.Message}", false);
            }
        }

        protected void Xoa_Click(object sender, CommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "XOA")
                {
                    int productID = Convert.ToInt32(e.CommandArgument);
                    string result = productController.DeleteProduct(productID);

                    ShowMessage(result, result.Contains("thành công"));
                    LoadProducts();
                }
            }
            catch (Exception ex)
            {
                ShowMessage($"Lỗi khi xóa sản phẩm: {ex.Message}", false);
            }
        }

        protected void Sua_Click(object sender, CommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "SUA")
                {
                    int productId = Convert.ToInt32(e.CommandArgument);
                    PRODUCT product = productController.getProductByID(productId);

                    if (product != null)
                    {
                        Session["sp"] = product;
                        Response.Redirect("UpdateProductManage.aspx");
                    }
                    else
                    {
                        ShowMessage("Không tìm thấy sản phẩm cần sửa.", false);
                    }
                }
            }
            catch (Exception ex)
            {
                ShowMessage($"Lỗi khi sửa sản phẩm: {ex.Message}", false);
            }
        }

        private void ShowMessage(string message, bool isSuccess)
        {
            lblMessage.Text = message;
            lblMessage.ForeColor = isSuccess ? System.Drawing.Color.Green : System.Drawing.Color.Red;
            lblMessage.Visible = true;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string searchKeyword = txtSearch.Text.Trim();
            LoadProducts(searchKeyword);
        }

        protected void gvProducts_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvProducts.PageIndex = e.NewPageIndex; // Cập nhật chỉ số trang hiện tại
            string searchKeyword = txtSearch.Text.Trim(); // Duy trì từ khóa tìm kiếm
            LoadProducts(searchKeyword);
        }
    }
}
