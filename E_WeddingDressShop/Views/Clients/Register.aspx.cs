using E_WeddingDressShop.Controllers;
using E_WeddingDressShop.DTO;
using System;
using System.Text;

namespace E_WeddingDressShop.Views
{
    public partial class Register : System.Web.UI.Page
    {
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string fullName = txtFullName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();
            string numberPhone = txtNumberPhone.Text.Trim();
            string address = txtAddress.Text.Trim();
            string role = ddlRole.SelectedValue;

            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(password) || string.IsNullOrEmpty(numberPhone) ||
                string.IsNullOrEmpty(address))
            {
                lblMessage.Text = "Vui lòng nhập đầy đủ thông tin!";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if (!IsValidEmail(email))
            {
                lblMessage.Text = "Địa chỉ email không hợp lệ!";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if (password.Length < 8)
            {
                lblMessage.Text = "Mật khẩu phải có ít nhất 8 ký tự!";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if (!long.TryParse(numberPhone, out _) || numberPhone.Length < 9)
            {
                lblMessage.Text = "Số điện thoại không hợp lệ!";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            USER user = new USER
            {
                FullName = fullName,
                Email = email,
                PasswordHash = password,
                NumberPhone = numberPhone,
                Address = address,
                Role = role,
                CreatedDate = DateTime.Now
            };

            UserController dto = new UserController();
            string result = dto.RegisterUser(user);

            lblMessage.Text = result;
            lblMessage.ForeColor = result.Contains("thành công") ? System.Drawing.Color.Green : System.Drawing.Color.Red;

            if (result.Contains("thành công"))
            {
                // Xóa các trường nhập sau khi đăng ký thành công
                txtFullName.Text = string.Empty;
                txtEmail.Text = string.Empty;
                txtPassword.Text = string.Empty;
                txtNumberPhone.Text = string.Empty;
                txtAddress.Text = string.Empty;
            }
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
