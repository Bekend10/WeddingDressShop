﻿using System;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using E_WeddingDressShop.Controllers;
using E_WeddingDressShop.Models;

namespace E_WeddingDressShop.Views.Admin
{
    public partial class ProductManage : Page
    {
        ProductController productController = new ProductController();
        CategoryController categoryController = new CategoryController();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCategories();
                LoadProducts();
            }
        }

        private void LoadCategories()
        {
            ddlCategory.DataSource = categoryController.getListCategory();
            ddlCategory.DataTextField = "CategoryName";
            ddlCategory.DataValueField = "CategoryID";
            ddlCategory.DataBind();

            ddlCategory.Items.Insert(0, new ListItem("-- Chọn danh mục --", "0"));
        }

        private void LoadProducts()
        {
            gvProducts.DataSource = productController.getListProduct();
            gvProducts.DataBind();
        }

        // Xử lý sự kiện thêm hoặc cập nhật sản phẩm
        protected void btnAddOrUpdate_Click(object sender, EventArgs e)
        {
            int categoryId = int.Parse(ddlCategory.SelectedValue);
            if (categoryId == 0)
            {
                lblMessage.Text = "Vui lòng chọn danh mục!";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Visible = true;
                return;
            }

            PRODUCT product = new PRODUCT
            {
                ProductID = string.IsNullOrEmpty(txtProductID.Text) ? 0 : int.Parse(txtProductID.Text),
                Name = txtProductName.Text.Trim(),
                Description = txtDescription.Text.Trim(),
                Price = float.Parse(txtPrice.Text),
                StockQuantity = int.Parse(txtStockQuantity.Text),
                CategoryID = categoryId,
                CreatedDate = DateTime.Now
            };

            // Kiểm tra và xử lý ảnh nếu có
            if (fileUploadImage.HasFile)
            {
                try
                {
                    string folderPath = Server.MapPath("~/UploadedImages/");
                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }

                    string fileName = Path.GetFileName(fileUploadImage.FileName);
                    string filePath = folderPath + fileName;
                    fileUploadImage.SaveAs(filePath);

                    // Cập nhật đường dẫn hình ảnh vào đối tượng sản phẩm
                    product.ImageUrl = "~/UploadedImages/" + fileName;
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "Lỗi khi tải lên hình ảnh: " + ex.Message;
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Visible = true;
                    return;
                }
            }
            else
            {
                // Nếu không có hình ảnh mới, giữ lại đường dẫn hình ảnh cũ
                if (!string.IsNullOrEmpty(txtImageUrl.Text))
                {
                    product.ImageUrl = txtImageUrl.Text;
                }
            }

            string result;
            if (product.ProductID == 0)
            {
                result = productController.AddProduct(product);
            }
            else
            {
                result = productController.UpdateProduct(product);
            }

            lblMessage.Text = result;
            lblMessage.ForeColor = result.Contains("thành công") ? System.Drawing.Color.Green : System.Drawing.Color.Red;
            lblMessage.Visible = true;

            ClearFields();
            LoadProducts();
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
                    ClearFields();
                    LoadProducts();
                }
            }
            catch (Exception ex)
            {
                ShowMessage($"Lỗi khi xóa danh mục: {ex.Message}", false);
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
                        ShowMessage("Không tìm thấy danh mục cần sửa.", false);
                    }
                }
            }
            catch (Exception ex)
            {
                ShowMessage($"Lỗi khi sửa danh mục: {ex.Message}", false);
            }
        }
        private void ClearFields()
        {
            txtProductID.Text = string.Empty;
            txtProductName.Text = string.Empty;
            txtDescription.Text = string.Empty;
            txtPrice.Text = string.Empty;
            txtStockQuantity.Text = string.Empty;
            txtImageUrl.Text = string.Empty;
            ddlCategory.SelectedIndex = 0;
            imgPreview.Visible = false;
        }

        private void ShowMessage(string message, bool isSuccess)
        {
            lblMessage.Text = message;
            lblMessage.ForeColor = isSuccess ? System.Drawing.Color.Green : System.Drawing.Color.Red;
            lblMessage.Visible = true;
        }
    }
}