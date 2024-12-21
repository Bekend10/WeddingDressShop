using E_WeddingDressShop.Controllers;
using E_WeddingDressShop.Models;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_WeddingDressShop.Views.Admin
{
    public partial class CategoryManage : System.Web.UI.Page
    {
        private readonly CategoryController categoryController = new CategoryController();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCategories();
            }
        }

        private void LoadCategories()
        {
            try
            {
                List<CATEGORY> categories = categoryController.getListCategory();
                gvCategories.DataSource = categories;
                gvCategories.DataBind();
                lblMessage.Visible = false; // Hide the message label on successful load
            }
            catch (Exception ex)
            {
                ShowMessage($"Lỗi khi tải danh sách danh mục: {ex.Message}", false);
            }
        }

        protected void btnAddOrUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtCategoryName.Text.Trim();
                string description = txtDescription.Text.Trim();

                if (string.IsNullOrEmpty(name))
                {
                    ShowMessage("Tên danh mục không được để trống!", false);
                    return;
                }

                CATEGORY category = new CATEGORY
                {
                    CategoryName = name,
                    Description = description
                };

                string result;
                if (!string.IsNullOrEmpty(txtCategoryID.Text))
                {
                    // Update category
                    category.CategoryID = int.Parse(txtCategoryID.Text);
                    result = categoryController.UpdateCategory(category);
                }
                else
                {
                    // Add new category
                    result = categoryController.AddCategory(category);
                }
                if (result.Contains("thành công"))
                {
                    // Gọi JavaScript để hiển thị Toastify thông báo thành công
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ShowToast", @"
                    function showToast(message) {
                        Toastify({
                            text: message,
                            duration: 3000,  // Thời gian hiển thị là 3 giây
                            close: true,  // Có nút đóng
                            gravity: 'top',  // Vị trí ở phía trên
                            position: 'right',  // Vị trí ở bên phải
                            backgroundColor: 'green',  // Đặt màu nền thành màu xanh
                            stopOnFocus: true  // Dừng khi hover vào Toast
                        }).showToast();
                    }", true);
                    // Gọi showToast sau khi script đã được tải
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ToastMessage", "showToast('Thêm Danh mục thành công!');", true);
                }
                else if (result.Contains("Lỗi"))
                {
                    // Gọi JavaScript để hiển thị Toastify thông báo thành công
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ShowToast", @"
                    function showToast(message) {
                        Toastify({
                            text: message,
                            duration: 3000,  // Thời gian hiển thị là 3 giây
                            close: true,  // Có nút đóng
                            gravity: 'top',  // Vị trí ở phía trên
                            position: 'right',  // Vị trí ở bên phải
                            backgroundColor: 'Red',  // Đặt màu nền thành màu xanh
                            stopOnFocus: true  // Dừng khi hover vào Toast
                        }).showToast();
                    }", true);
                    // Gọi showToast sau khi script đã được tải
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ToastMessage", "showToast('Lỗi thêm danh mục!');", true);
                }
                ShowMessage(result, result.Contains("thành công"));

                // Kiểm tra kết quả trả về

                ClearFields();
                LoadCategories();
            }
            catch (Exception ex)
            {
                ShowMessage($"Lỗi khi thêm/cập nhật danh mục: {ex.Message}", false);
            }
        }

        protected void Sua_Click(object sender, CommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "SUA")
                {
                    int categoryId = Convert.ToInt32(e.CommandArgument);
                    CATEGORY category = categoryController.getCategoryByID(categoryId);

                    if (category != null)
                    {
                        Session["sv"] = category;
                        Response.Redirect("UpdateCategoryManage.aspx");
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

        protected void Xoa_Click(object sender, CommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "XOA")
                {
                    int categoryId = Convert.ToInt32(e.CommandArgument);
                    string result = categoryController.DeleteCategory(categoryId);

                    ShowMessage(result, result.Contains("thành công"));
                    ClearFields();
                    LoadCategories();
                }
            }
            catch (Exception ex)
            {
                ShowMessage($"Lỗi khi xóa danh mục: {ex.Message}", false);
            }
        }

        private void ClearFields()
        {
            txtCategoryID.Text = string.Empty;
            txtCategoryName.Text = string.Empty;
            txtDescription.Text = string.Empty;
        }

        private void ShowMessage(string message, bool isSuccess)
        {
            lblMessage.Text = message;
            lblMessage.ForeColor = isSuccess ? System.Drawing.Color.Green : System.Drawing.Color.Red;
            lblMessage.Visible = true;
        }
    }
}
