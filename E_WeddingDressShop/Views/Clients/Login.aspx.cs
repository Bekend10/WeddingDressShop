using E_WeddingDressShop.Controllers;
using System;
using System.Web.UI;

namespace E_WeddingDressShop.Views
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserEmail"] != null)
            {
                Response.Redirect("~/Views/Dashboard.aspx");
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                lblErrorMessage.Visible = true;
                lblErrorMessage.Text = "Vui lòng nhập đầy đủ thông tin!";
                return;
            }

            UserController dto = new UserController();
            string result = dto.LoginUser(email, password);

            if (result == "Đăng nhập thành công!")
            {
                Session["UserEmail"] = email;
                Response.Redirect("~/Views/Dashboard.aspx");
            }
            else
            {
                lblErrorMessage.Visible = true;
                lblErrorMessage.Text = result;

                // Chỉ xóa mật khẩu, giữ lại email
                txtPassword.Text = string.Empty;
            }
        }
    }
}
