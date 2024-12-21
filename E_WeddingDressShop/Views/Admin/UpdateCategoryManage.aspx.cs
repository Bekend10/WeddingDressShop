using E_WeddingDressShop.Controllers;
using E_WeddingDressShop.Models;
using System;
using System.Web.UI;

namespace E_WeddingDressShop.Views.Admin
{
    public partial class UpdateCategoryManage : System.Web.UI.Page
    {
        private readonly CategoryController categoryController = new CategoryController();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["sv"] is CATEGORY sv)
                {
                    txtCategoryID.Text = sv.CategoryID.ToString();
                    txtCategoryName.Text = sv.CategoryName;
                    txtDescription.Text = sv.Description;
                }
                else
                {
                    msg.Text = "Không có danh mục nào để cập nhật.";
                    msg.ForeColor = System.Drawing.Color.Red;
                    btnSua.Enabled = false; 
                }
            }
        }

        protected void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtCategoryID.Text) ||
                    string.IsNullOrWhiteSpace(txtCategoryName.Text) ||
                    string.IsNullOrWhiteSpace(txtDescription.Text))
                {
                    msg.Text = "Vui lòng điền đầy đủ thông tin trước khi cập nhật.";
                    msg.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                CATEGORY updatedCategory = new CATEGORY
                {
                    CategoryID = int.Parse(txtCategoryID.Text),
                    CategoryName = txtCategoryName.Text.Trim(),
                    Description = txtDescription.Text.Trim()
                };

                string result = categoryController.UpdateCategory(updatedCategory);

                /*                msg.Text = result.Contains("thành công") ? "Cập nhật thành công!" : result;
                                msg.ForeColor = result.Contains("thành công") ? System.Drawing.Color.Green : System.Drawing.Color.Red;*/
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
                    }

                    ", true);
                    // Gọi showToast sau khi script đã được tải
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ToastMessage", "showToast('Cập nhật Danh mục thành công!');", true);
                    msg.Text = "Cập nhật Danh mục thành công!";
                    msg.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    msg.Text = result;
                    msg.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                msg.Text = $"Lỗi khi cập nhật danh mục: {ex.Message}";
                msg.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}
